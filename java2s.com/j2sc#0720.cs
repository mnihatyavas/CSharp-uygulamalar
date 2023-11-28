// j2sc#0720.cs: Metodun parametrik giri�ini this'le �nuzant�'ya �evirme �rne�i.

using System;
using System.Reflection; //Assembly i�in
using System.IO; // Stream i�in
using System.Net; //WebRequest ve WebResponse i�in
using System.Linq; //Reverse() i�in
using System.Text; //StringBuilder i�in
namespace S�n�flar {
    public static class Uzant�A {
        public static void Tan�ml�T�mle�keyiG�ster (this object nesne) {
            Console.WriteLine ("Verili nesnenin tipi: {0}", nesne.GetType().Name);
            Console.WriteLine ("Verili nesne tipinin t�mle�kesi: {0}", Assembly.GetAssembly (nesne.GetType()));
        }
        public static int Rakamlar�Tersle (this int i) {
            char[] rakamlar = i.ToString().ToCharArray();
            Array.Reverse (rakamlar);
            string terslenenRakamlar = new string (rakamlar);
            return int.Parse (terslenenRakamlar);
        }
    }
    public static class Uzant�l�Ak�� {
        const int TamponEbat� = 8192; //8KBit=1KByte: 1024, 2048, 4096, 8192
        public static void Kopyas� (this Stream girdi, Stream ��kt�) {
            byte[] tampon = new byte [TamponEbat�];
            int okunan;
            while ((okunan = girdi.Read (tampon, 0, tampon.Length)) > 0) {��kt�.Write (tampon, 0, okunan);}
        }
        /*public static byte[] TamOku (Uzant�l�Ak�� Stream girdi) {//Kullan�lm�yor
            using (MemoryStream arac�Ak�� = new MemoryStream()) {
                Kopyas� (girdi, arac�Ak��);
                if (arac�Ak��.Length == arac�Ak��.GetBuffer().Length) {return arac�Ak��.GetBuffer();}
                return arac�Ak��.ToArray();
            }
        }*/
    }
    public static class Uzant�B {public static string DizgeyiTersle (this string dizge) {return new string (dizge.ToCharArray().Reverse().ToArray());}}
    public static class Uzant�C {
        public static string Ba�l�kYap (this string girdi, bool k���kharfliMi) {
            girdi = girdi.Trim(); //�n ve arka bo�luklar� k�rp
            if (girdi == "") {return "";}
            if (k���kharfliMi) {girdi = girdi.ToLower();}
            string[] girdiDizisi = girdi.Split (' ');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < girdiDizisi.Length; i++) {if (girdiDizisi [i].Length > 0) {sb.AppendFormat ("{0}{1} ", girdiDizisi [i].Substring (0, 1).ToUpper(), girdiDizisi [i].Substring (1));}} //Kelimelerin ilkharfini b�y�t
            return sb.ToString (0, sb.Length - 1);
        }
    }
    static class NullMu {public static bool nullMu (this object x) {return x == null;}}
    public static class Uzant�D {
        public static string DilimAl (this string s, int n, int m) {
            if (n < 0 || n > s.Length || n+m >= s.Length) return "";
            else return s.Substring (n, m);
        }
    }
    public static class �zelleriSay {
        public static int �zellerinSay�s� (this String dizge) {
            var karakterler = from bunuSay in dizge where
                bunuSay == '!' || bunuSay == '@' || bunuSay == ';' || bunuSay == ',' || bunuSay == ' ' || bunuSay == '?' || bunuSay == ':' || bunuSay == '&' || bunuSay == '%' || bunuSay == '$' || bunuSay == '#'
                select bunuSay;
            return karakterler.Count<Char>();
      }
   }
    class Uzant� {
        static void Main() {
            Console.Write ("Metot parametresini 'this object nesne' girerek, nesneyi parametre yerine '�nuzant�.' ile girebiliriz. Statik s�n�fta this kullan�lmal�, yerine s�n�f�n ad�n� kullanmak ge�ersizdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Uzant�l� verili tamsay�n�n tipi, t�mle�kesi ve terslenmesi:");
            int ts1 = 20231031, i;
            ts1.Tan�ml�T�mle�keyiG�ster();
            Console.WriteLine ("{0}'in tersi: {1}'dir.", ts1, ts1.Rakamlar�Tersle());
            var r=new Random();
            for(i=0;i<5;i++) {ts1=r.Next(10000000,100000000); Console.WriteLine ("\t{0}'in tersi: {1}'dir.", ts1, ts1.Rakamlar�Tersle());}

            Console.WriteLine ("\n�evrimi�iyken 'java2s.com' site yan�t� 'veri.dat' dosyas�na kopyalanacak:");
            try {WebRequest a�Talebi = WebRequest.Create ("http://java2s.com");
                using (WebResponse a�Yan�t� = a�Talebi.GetResponse())
                using (Stream yan�tAk��� = a�Yan�t�.GetResponseStream())
                using (FileStream ��kt� = File.Create ("veri.dat")) {//Mevcut dizinde "veri.dat" dosyas� yarat�r, yan�t verilerini bu dosyaya kopyalar
                    yan�tAk���.Kopyas� (��kt�);
                }
            }catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}

            Console.WriteLine ("\n�nuzant�l� tam isimlerin terslenmesi:");
            string[] adlar=new string[]{"Hatice Yava� Ka�ar", "S�heyla Yava� �zbay", "Zeliha Nihal Yava� Candan", "Mahmut Nihat Yava�", "Song�l Yava� G�kyi�it", "Mustafa Nedim Yava�", "Sevim Yava�"};
            for(i=0;i<adlar.Length;i++) Console.WriteLine ("\"{0}\"'�n terslenmi�i: \"{1}\"", adlar [i], adlar [i].DizgeyiTersle());

            Console.WriteLine ("\nK���kharfe �evrlen dizge kelimelerinin ilk harflerini b�y�tme:");
            string[] adlar2=new string[]{" haTice yaVa� ka�ar  ", "s�heyla yava� �zbay", "zel�ha yAva� canDan  ", "  maHmut niHat Yava�", " sonG�l yAVa� g�kyi�it", "mustafa neD�m yava� ", "  SEV�M       YAVA�     "};
            for(i=0;i<adlar2.Length;i++) Console.WriteLine ("Orijinali: [{0}],\tBa�l�k hali: [{1}]", adlar2 [i], adlar2 [i].Ba�l�kYap (true));

            Console.WriteLine ("\nDizi eleman�na de�er atamadan �nce ve sonra null kontrolu:");
            Console.WriteLine ("\t�nce:");
            string[] adlar3=new string [7];
            for(i=0;i<adlar3.Length;i++) Console.WriteLine ("adlar[{0}]=\"{1}\" null mu? {2}", i, adlar3 [i], adlar3 [i].nullMu());
            Console.WriteLine ("\tSonra:");
            adlar3=new string[]{"Hatice Yava� Ka�ar", "S�heyla Yava� �zbay", "Zeliha Nihal Yava� Candan", "Mahmut Nihat Yava�", "Song�l Yava� G�kyi�it", "Mustafa Nedim Yava�", "Sevim Yava�"};
            for(i=0;i<adlar3.Length;i++) Console.WriteLine ("adlar[{0}]=\"{1}\" null mu? {2}", i, adlar3 [i], adlar3 [i].nullMu());

            Console.WriteLine ("\nDizge i�inden rasgele hatas�z dilimler alma:");
            string t�mce = "Hatice Yava� Ka�ar, S�heyla Yava� �zbay, Zeliha Yava� Candan, Mahmut Nihat Yava�, Song�l Yava� G�kyi�it, Mustafa Nedim Yava�, Sevim Yava�";
            Console.WriteLine ("Orijinal dizge = [{0}]", t�mce);
            Console.WriteLine ("\tdizge.DilimAl(-10, 10) = [{0}]", t�mce.DilimAl (-10, 10));
            Console.WriteLine ("\tdizge.DilimAl(150,10) = [{0}]", t�mce.DilimAl (150, 160));
            Console.WriteLine ("\tdizge.DilimAl(85,75) = [{0}]", t�mce.DilimAl (85, 75));
            int ilk, uzun;
            for(i=0;i<5;i++) {
                ilk=r.Next(0, t�mce.Length-5); uzun=r.Next(1, t�mce.Length-ilk);
                Console.WriteLine ("dizge.DilimAl({0},{1}) = [{2}]", ilk, uzun, t�mce.DilimAl (ilk, uzun));
            }

            Console.WriteLine ("\nDizge i�indeki istenen �zel karakterlerin toplam say�s�n� bulma:");
            t�mce = "%&!Aile: Bette�, Fadik;$# Mahammed, �an�m?@�: �acce, S�leyha, Nihal, Mahm�t, Song�l, Nadim, Sevim?+-!%...";
            Console.WriteLine ("Orijinal dizge = [{0}]\nDizgenin uzunlu�u = [{1}]\nSay�lacak �zel karakterler = [{2}]\nTespit edilen �zel karakterlerin say�s� = [{3}]", t�mce, t�mce.Length, "!@;, ?:&%$#", t�mce.�zellerinSay�s�());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}