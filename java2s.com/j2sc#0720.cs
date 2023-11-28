// j2sc#0720.cs: Metodun parametrik giriþini this'le önuzantý'ya çevirme örneði.

using System;
using System.Reflection; //Assembly için
using System.IO; // Stream için
using System.Net; //WebRequest ve WebResponse için
using System.Linq; //Reverse() için
using System.Text; //StringBuilder için
namespace Sýnýflar {
    public static class UzantýA {
        public static void TanýmlýTümleþkeyiGöster (this object nesne) {
            Console.WriteLine ("Verili nesnenin tipi: {0}", nesne.GetType().Name);
            Console.WriteLine ("Verili nesne tipinin tümleþkesi: {0}", Assembly.GetAssembly (nesne.GetType()));
        }
        public static int RakamlarýTersle (this int i) {
            char[] rakamlar = i.ToString().ToCharArray();
            Array.Reverse (rakamlar);
            string terslenenRakamlar = new string (rakamlar);
            return int.Parse (terslenenRakamlar);
        }
    }
    public static class UzantýlýAkýþ {
        const int TamponEbatý = 8192; //8KBit=1KByte: 1024, 2048, 4096, 8192
        public static void Kopyasý (this Stream girdi, Stream çýktý) {
            byte[] tampon = new byte [TamponEbatý];
            int okunan;
            while ((okunan = girdi.Read (tampon, 0, tampon.Length)) > 0) {çýktý.Write (tampon, 0, okunan);}
        }
        /*public static byte[] TamOku (UzantýlýAkýþ Stream girdi) {//Kullanýlmýyor
            using (MemoryStream aracýAkýþ = new MemoryStream()) {
                Kopyasý (girdi, aracýAkýþ);
                if (aracýAkýþ.Length == aracýAkýþ.GetBuffer().Length) {return aracýAkýþ.GetBuffer();}
                return aracýAkýþ.ToArray();
            }
        }*/
    }
    public static class UzantýB {public static string DizgeyiTersle (this string dizge) {return new string (dizge.ToCharArray().Reverse().ToArray());}}
    public static class UzantýC {
        public static string BaþlýkYap (this string girdi, bool küçükharfliMi) {
            girdi = girdi.Trim(); //Ön ve arka boþluklarý kýrp
            if (girdi == "") {return "";}
            if (küçükharfliMi) {girdi = girdi.ToLower();}
            string[] girdiDizisi = girdi.Split (' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < girdiDizisi.Length; i++) {if (girdiDizisi [i].Length > 0) {sb.AppendFormat ("{0}{1} ", girdiDizisi [i].Substring (0, 1).ToUpper(), girdiDizisi [i].Substring (1));}} //Kelimelerin ilkharfini büyüt
            return sb.ToString (0, sb.Length - 1);
        }
    }
    static class NullMu {public static bool nullMu (this object x) {return x == null;}}
    public static class UzantýD {
        public static string DilimAl (this string s, int n, int m) {
            if (n < 0 || n > s.Length || n+m >= s.Length) return "";
            else return s.Substring (n, m);
        }
    }
    public static class ÖzelleriSay {
        public static int ÖzellerinSayýsý (this String dizge) {
            var karakterler = from bunuSay in dizge where
                bunuSay == '!' || bunuSay == '@' || bunuSay == ';' || bunuSay == ',' || bunuSay == ' ' || bunuSay == '?' || bunuSay == ':' || bunuSay == '&' || bunuSay == '%' || bunuSay == '$' || bunuSay == '#'
                select bunuSay;
            return karakterler.Count<Char>();
      }
   }
    class Uzantý {
        static void Main() {
            Console.Write ("Metot parametresini 'this object nesne' girerek, nesneyi parametre yerine 'önuzantý.' ile girebiliriz. Statik sýnýfta this kullanýlmalý, yerine sýnýfýn adýný kullanmak geçersizdir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Uzantýlý verili tamsayýnýn tipi, tümleþkesi ve terslenmesi:");
            int ts1 = 20231031, i;
            ts1.TanýmlýTümleþkeyiGöster();
            Console.WriteLine ("{0}'in tersi: {1}'dir.", ts1, ts1.RakamlarýTersle());
            var r=new Random();
            for(i=0;i<5;i++) {ts1=r.Next(10000000,100000000); Console.WriteLine ("\t{0}'in tersi: {1}'dir.", ts1, ts1.RakamlarýTersle());}

            Console.WriteLine ("\nÇevrimiçiyken 'java2s.com' site yanýtý 'veri.dat' dosyasýna kopyalanacak:");
            try {WebRequest aðTalebi = WebRequest.Create ("http://java2s.com");
                using (WebResponse aðYanýtý = aðTalebi.GetResponse())
                using (Stream yanýtAkýþý = aðYanýtý.GetResponseStream())
                using (FileStream çýktý = File.Create ("veri.dat")) {//Mevcut dizinde "veri.dat" dosyasý yaratýr, yanýt verilerini bu dosyaya kopyalar
                    yanýtAkýþý.Kopyasý (çýktý);
                }
            }catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}

            Console.WriteLine ("\nÖnuzantýlý tam isimlerin terslenmesi:");
            string[] adlar=new string[]{"Hatice Yavaþ Kaçar", "Süheyla Yavaþ Özbay", "Zeliha Nihal Yavaþ Candan", "Mahmut Nihat Yavaþ", "Songül Yavaþ Gökyiðit", "Mustafa Nedim Yavaþ", "Sevim Yavaþ"};
            for(i=0;i<adlar.Length;i++) Console.WriteLine ("\"{0}\"'ýn terslenmiþi: \"{1}\"", adlar [i], adlar [i].DizgeyiTersle());

            Console.WriteLine ("\nKüçükharfe çevrlen dizge kelimelerinin ilk harflerini büyütme:");
            string[] adlar2=new string[]{" haTice yaVaþ kaÇar  ", "sÜheyla yavaÞ Özbay", "zelÝha yAvaþ canDan  ", "  maHmut niHat Yavaþ", " sonGül yAVaþ gÖkyiÐit", "mustafa neDÝm yavaþ ", "  SEVÝM       YAVAÞ     "};
            for(i=0;i<adlar2.Length;i++) Console.WriteLine ("Orijinali: [{0}],\tBaþlýk hali: [{1}]", adlar2 [i], adlar2 [i].BaþlýkYap (true));

            Console.WriteLine ("\nDizi elemanýna deðer atamadan önce ve sonra null kontrolu:");
            Console.WriteLine ("\tÖnce:");
            string[] adlar3=new string [7];
            for(i=0;i<adlar3.Length;i++) Console.WriteLine ("adlar[{0}]=\"{1}\" null mu? {2}", i, adlar3 [i], adlar3 [i].nullMu());
            Console.WriteLine ("\tSonra:");
            adlar3=new string[]{"Hatice Yavaþ Kaçar", "Süheyla Yavaþ Özbay", "Zeliha Nihal Yavaþ Candan", "Mahmut Nihat Yavaþ", "Songül Yavaþ Gökyiðit", "Mustafa Nedim Yavaþ", "Sevim Yavaþ"};
            for(i=0;i<adlar3.Length;i++) Console.WriteLine ("adlar[{0}]=\"{1}\" null mu? {2}", i, adlar3 [i], adlar3 [i].nullMu());

            Console.WriteLine ("\nDizge içinden rasgele hatasýz dilimler alma:");
            string tümce = "Hatice Yavaþ Kaçar, Süheyla Yavaþ Özbay, Zeliha Yavaþ Candan, Mahmut Nihat Yavaþ, Songül Yavaþ Gökyiðit, Mustafa Nedim Yavaþ, Sevim Yavaþ";
            Console.WriteLine ("Orijinal dizge = [{0}]", tümce);
            Console.WriteLine ("\tdizge.DilimAl(-10, 10) = [{0}]", tümce.DilimAl (-10, 10));
            Console.WriteLine ("\tdizge.DilimAl(150,10) = [{0}]", tümce.DilimAl (150, 160));
            Console.WriteLine ("\tdizge.DilimAl(85,75) = [{0}]", tümce.DilimAl (85, 75));
            int ilk, uzun;
            for(i=0;i<5;i++) {
                ilk=r.Next(0, tümce.Length-5); uzun=r.Next(1, tümce.Length-ilk);
                Console.WriteLine ("dizge.DilimAl({0},{1}) = [{2}]", ilk, uzun, tümce.DilimAl (ilk, uzun));
            }

            Console.WriteLine ("\nDizge içindeki istenen özel karakterlerin toplam sayýsýný bulma:");
            tümce = "%&!Aile: Betteþ, Fadik;$# Mahammed, Ðaným?@½: Ðacce, Süleyha, Nihal, Mahmýt, Songül, Nadim, Sevim?+-!%...";
            Console.WriteLine ("Orijinal dizge = [{0}]\nDizgenin uzunluðu = [{1}]\nSayýlacak özel karakterler = [{2}]\nTespit edilen özel karakterlerin sayýsý = [{3}]", tümce, tümce.Length, "!@;, ?:&%$#", tümce.ÖzellerinSayýsý());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}