// j2sc#1102b.cs: DiziListe Add/InsertRange, Set/GetRange ve özelleþtirilen Sort/Reverse örneði.

using System;
using System.Collections;
using System.Collections.Generic; //IEnumerable için
using System.Linq;
namespace VeriYapýlarý {
    class Sýnýf1 {
        public string isim="";
        public Sýnýf1 (string a) {isim=a;} //Kurucu
    }
    struct Kiþi : IComparer {
        public string ad, þehir;
        public int yaþ;
        public Kiþi (string a, string þ, int y) {ad = a; þehir = þ; yaþ = y;} //Kurucu
        public int Compare (object a, object b) {
            int ak;
            int þk;
            Kiþi ka = (Kiþi)a;
            Kiþi kb = (Kiþi)b;
            ak = String.Compare (ka.ad, kb.ad);
            if(ak != 0 ) return ak; //Adlar aynýysa þehirleri de kýyaslar
            þk = String.Compare (ka.þehir, kb.þehir);
            return þk;
        }
    }
    class Araba {
        public string Adý="Panter";
        public string Rengi="Mavi";
        public int Hýzý=200;
        public string Markasý="BMW-SL";
        public int Kilometresi=20231231;
    }
    class KontrolluAd : ArrayList {
        public override int Add (object nesne) {
            if (nesne.GetType() == Type.GetType ("System.String")) {
                string[] adlar = ((string)nesne).Split (' ');
                if (adlar.Length >= 2) return base.Add (nesne);
            }
            return -1;
        }
    }
    public class Ürün {
        string ad;
        public string Ad {get {return ad;}}
        decimal fiyat;
        public decimal Fiyat {get {return fiyat;}}
        public Ürün (string a, decimal f) {ad = a;fiyat = f;} //Kurucu
        public static ArrayList EkliÜrünleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new Ürün ("Tuz", 24.64m)); liste.Add (new Ürün ("Þeker", 32.75m)); liste.Add (new Ürün ("Çay", 85.25m)); liste.Add (new Ürün ("Sabun", 20m)); liste.Add (new Ürün ("Deterjan", 98.50m));
            return liste;
        }
        public override string ToString() {return string.Format ("{0}: {1}", Ad, Fiyat);}
    }
    class VeriYapýsý2B {
        public static void ListeyiGöster (string ad, ArrayList liste) {
            for (int i = 0; i < liste.Count; i++) {Console.Write (ad + "[" + i + "]=" + liste [i] + " ");}
            Console.WriteLine();
        }
        public static void EndeksliListeyiGöster (IEnumerable listem) {
            int i = 0;
            foreach (Object ns in listem) Console.Write ("[{0}]:{1} ", i++, ns); Console.WriteLine();
        }
        public class tersSýrala : IComparer {
            int IComparer.Compare (Object a, Object b) {return ((new CaseInsensitiveComparer()).Compare (b, a));}
        }
        class ÜrünAdýKýyasý : IComparer {
            public int Compare (object a, object b) {
                Ürün ilk = (Ürün)a;
                Ürün ikinci = (Ürün)b;
                return ilk.Ad.CompareTo (ikinci.Ad);
            }
        }

        static void Main() {
            Console.Write ("DiziListe.SetRange(endeks,dizi) belirtilen konumdan itibaren tanýmlý dizi elemanlarýný öncekilerin yerine koyar. DiziListe.GetRange(endeks,adet) ise liste endeksinden itibaren tanýmlanan adet alt liste kopyalar. dl.TrimToSize() diziliste'nin katlamalý artan Capacity'yi mevcut eleman sayýlý Count'a eþitler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DiziListe'ye sýnýf tiplemeli isimler girme ve sunma:");
            int i=0, j;
            ArrayList dl1 = new ArrayList();
            dl1.AddRange (new Sýnýf1[] {new Sýnýf1("Nihat"), new Sýnýf1("Mahmut"), new Sýnýf1("Sefer"), new Sýnýf1("Adil"), new Sýnýf1("Hamza")});
            Console.WriteLine ("Listedeki öðe sayýsý: {0}", dl1.Count);
            dl1.Insert (2, new Sýnýf1("Memet")); //2.konuma tipleme girme
            Console.WriteLine ("Listedeki öðe sayýsý: {0}", dl1.Count);
            dl1.Insert (2, new Sýnýf1("Bekir")); Console.WriteLine ("Listedeki öðe sayýsý: {0}", dl1.Count);
            foreach (Sýnýf1 ad in dl1) Console.Write ("{0}.ad={1} ", ++i, ad.isim);

            Console.WriteLine ("\n\nBir DiziListe'yi diðerinin tipleme parametresi olarak kopyalama:");
            ArrayList dl2 = new ArrayList();
            dl2.Add ("Bu"); dl2.Add ("bir"); dl2.Add ("dizge"); dl2.Add ("öðeli"); dl2.Add ("dizi"); dl2.Add ("listesidir.");
            ArrayList dl2a = new ArrayList (dl2);
            Console.WriteLine ("dl2: {0}\tdl2a: {1}", dl2, dl2a);
            foreach (string kelime in dl2a) Console.Write (kelime+" ");
            Console.WriteLine ("\ndl2a.IsFixedSize: {0},\tdl2s.IsReadOnly: {1}",dl2a.IsFixedSize, dl2a.IsReadOnly);

            Console.WriteLine ("\nAdd, Insert, Add/InsertRange, Set/GetRange ile eleman girme/silme:");
            ArrayList dl3 = new ArrayList();
            dl3.Add ("bir"); dl3.Insert (0, "Bu");
            string[] dzg1 = {"Add", "AddRange"};
            dl3.AddRange (dzg1);
            string[] dzg2 = {"Insert", "InsertRange", "ile", "eleman", "girme", "örneðidir."};
            dl3.InsertRange (dl3.Count, dzg2);
            ListeyiGöster ("dl3", dl3);
            string[] dzg3 = {"Önceki", "elemanlarýn", "üstüne", "yazar"};
            dl3.SetRange (0, dzg3);
            ListeyiGöster ("dl3", dl3);
            dl3.Insert (0, "Nihat");  dl3.Insert (dl3.Count, "Nihatt");
            if (dl3.Contains ("Nihat")) {
                i = dl3.IndexOf ("Nihat");
                Console.WriteLine ("ÝLK: dl3 [{0}]='Nihat'", i);
                j = dl3.LastIndexOf ("Nihat");
                if(j!=i) Console.WriteLine ("SON: dl3 [{0}]='Nihat'", j);
            }
            dl3.RemoveAt (0); dl3.Remove ("Nihatt"); dl3.RemoveRange (0, 4);
            ListeyiGöster ("dl3", dl3);
            dl3.Reverse();
            ListeyiGöster ("dl3", dl3);
            Console.WriteLine ("dl3.Count={0},\tdl3.Capacity={1}", dl3.Count, dl3.Capacity);
            dl3.TrimToSize();
            Console.WriteLine ("dl3.Count={0},\tdl3.Capacity={1}", dl3.Count, dl3.Capacity);
            dl3.Reverse();
            ArrayList dl3a = dl3.GetRange (3, 3);
            ListeyiGöster ("dl3a", dl3a);
            Console.Write ("GetEnumerator()'lu liste: ");
            IEnumerator ie = dl3a.GetEnumerator();
            while (ie.MoveNext()) {Console.Write (ie.Current+" ");}

            Console.WriteLine ("\n\nVarsayýlý IComparer:Compare() ad+þehir ikili kýyasla sýralanmýþtýr:");
            ArrayList dl4 = new ArrayList();
            dl4.Add (new Kiþi ("Nihat", "Mersin", 67)); dl4.Add (new Kiþi ("Yücel", "Bursa", 51)); dl4.Add (new Kiþi ("Canan", "Antalya", 48)); dl4.Add (new Kiþi ("Hilal", "Malatya", 42)); dl4.Add (new Kiþi ("Fatih", "Ýzmir", 44)); dl4.Add (new Kiþi ("Nihat", "Kuþadasý", 57));
            Console.WriteLine ("\t==>Sýralama öncesi liste:");
            foreach (Kiþi k in dl4) {Console.WriteLine ("{0}, {1}, {2}", k.ad, k.þehir, k.yaþ);}
            // Özelleþtirilen IComparer ile sýralama
            dl4.Sort (new Kiþi());
            Console.WriteLine ("\t==>Özelleþtirilen sýralama sonrasý liste:");
            foreach (Kiþi k in dl4) {Console.WriteLine ("{0}, {1}, {2}", k.ad, k.þehir, k.yaþ);}

            Console.WriteLine ("\nBüyük/küçükharf duyarsýz listeyi endeksli normal, sýralý ve ters sunma:");
            ArrayList dl5 = new ArrayList();
            dl5.Add ("Nihat"); dl5.Add ("yücel"); dl5.Add ("canan"); dl5.Add ("Hilal"); dl5.Add ("Fatih"); dl5.Add ("nihat");
            EndeksliListeyiGöster (dl5);
            dl5.Sort(); EndeksliListeyiGöster (dl5);
            IComparer ic = new tersSýrala(); dl5.Sort (ic);
            EndeksliListeyiGöster (dl5);

            Console.WriteLine ("\nKarma liste elemanlarýndan sadece int'lerinin sunulmasý:");
            ArrayList dl6 = new ArrayList();
            dl6.AddRange (new object[] {10, 400, 8, false, new Araba(), "dizgesel veri", 'A', 20240112});
            IEnumerable<int> ie2 = dl6.OfType<int>();
            foreach (int ts in ie2) Console.WriteLine ("int deðer: {0}", ts);
            ArrayList dl6a = new ArrayList();
            dl6a.AddRange (new object[] {10, 400, 8, false, new Araba().Adý, new Araba().Rengi, new Araba().Hýzý, new Araba().Markasý, new Araba().Kilometresi, "dizgesel veri", 'A', 20240112});
            IEnumerable<int> ie3 = dl6a.OfType<int>();
            foreach (int ts in ie3) Console.WriteLine ("\tint deðer: {0}", ts);

            Console.WriteLine ("\nÖzel esgeçen Add'le 2'den fazla ayrýk adlarýn eklenmesi:");
            KontrolluAd dl7 = new KontrolluAd();
            dl7.Add ("Nihat" ); dl7.Add ("M.Nihat"); dl7.Add ("M.Nihat Yavaþ"); dl7.Add ("Hatice Yavaþ Kaçar "); dl7.Add ("Nihal Zeliha Yavaþ Candan"); dl7.Add ("ABCD"); dl7.Add ("ABCD XYZ");
            foreach (object ns in dl7) Console.WriteLine (ns);

            Console.WriteLine ("\nVerili ürünleri özelleþtirilen ad'la artan sýralayýp sunma:");
            ArrayList ürünler = Ürün.EkliÜrünleriAl();
            ürünler.Sort (new ÜrünAdýKýyasý());
            i=0; foreach (Ürün ürün in ürünler) {Console.WriteLine ("{0}.ürün) {1:0.00} TL", ++i, ürün);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}