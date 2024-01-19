// j2sc#1102b.cs: DiziListe Add/InsertRange, Set/GetRange ve �zelle�tirilen Sort/Reverse �rne�i.

using System;
using System.Collections;
using System.Collections.Generic; //IEnumerable i�in
using System.Linq;
namespace VeriYap�lar� {
    class S�n�f1 {
        public string isim="";
        public S�n�f1 (string a) {isim=a;} //Kurucu
    }
    struct Ki�i : IComparer {
        public string ad, �ehir;
        public int ya�;
        public Ki�i (string a, string �, int y) {ad = a; �ehir = �; ya� = y;} //Kurucu
        public int Compare (object a, object b) {
            int ak;
            int �k;
            Ki�i ka = (Ki�i)a;
            Ki�i kb = (Ki�i)b;
            ak = String.Compare (ka.ad, kb.ad);
            if(ak != 0 ) return ak; //Adlar ayn�ysa �ehirleri de k�yaslar
            �k = String.Compare (ka.�ehir, kb.�ehir);
            return �k;
        }
    }
    class Araba {
        public string Ad�="Panter";
        public string Rengi="Mavi";
        public int H�z�=200;
        public string Markas�="BMW-SL";
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
    public class �r�n {
        string ad;
        public string Ad {get {return ad;}}
        decimal fiyat;
        public decimal Fiyat {get {return fiyat;}}
        public �r�n (string a, decimal f) {ad = a;fiyat = f;} //Kurucu
        public static ArrayList Ekli�r�nleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new �r�n ("Tuz", 24.64m)); liste.Add (new �r�n ("�eker", 32.75m)); liste.Add (new �r�n ("�ay", 85.25m)); liste.Add (new �r�n ("Sabun", 20m)); liste.Add (new �r�n ("Deterjan", 98.50m));
            return liste;
        }
        public override string ToString() {return string.Format ("{0}: {1}", Ad, Fiyat);}
    }
    class VeriYap�s�2B {
        public static void ListeyiG�ster (string ad, ArrayList liste) {
            for (int i = 0; i < liste.Count; i++) {Console.Write (ad + "[" + i + "]=" + liste [i] + " ");}
            Console.WriteLine();
        }
        public static void EndeksliListeyiG�ster (IEnumerable listem) {
            int i = 0;
            foreach (Object ns in listem) Console.Write ("[{0}]:{1} ", i++, ns); Console.WriteLine();
        }
        public class tersS�rala : IComparer {
            int IComparer.Compare (Object a, Object b) {return ((new CaseInsensitiveComparer()).Compare (b, a));}
        }
        class �r�nAd�K�yas� : IComparer {
            public int Compare (object a, object b) {
                �r�n ilk = (�r�n)a;
                �r�n ikinci = (�r�n)b;
                return ilk.Ad.CompareTo (ikinci.Ad);
            }
        }

        static void Main() {
            Console.Write ("DiziListe.SetRange(endeks,dizi) belirtilen konumdan itibaren tan�ml� dizi elemanlar�n� �ncekilerin yerine koyar. DiziListe.GetRange(endeks,adet) ise liste endeksinden itibaren tan�mlanan adet alt liste kopyalar. dl.TrimToSize() diziliste'nin katlamal� artan Capacity'yi mevcut eleman say�l� Count'a e�itler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DiziListe'ye s�n�f tiplemeli isimler girme ve sunma:");
            int i=0, j;
            ArrayList dl1 = new ArrayList();
            dl1.AddRange (new S�n�f1[] {new S�n�f1("Nihat"), new S�n�f1("Mahmut"), new S�n�f1("Sefer"), new S�n�f1("Adil"), new S�n�f1("Hamza")});
            Console.WriteLine ("Listedeki ��e say�s�: {0}", dl1.Count);
            dl1.Insert (2, new S�n�f1("Memet")); //2.konuma tipleme girme
            Console.WriteLine ("Listedeki ��e say�s�: {0}", dl1.Count);
            dl1.Insert (2, new S�n�f1("Bekir")); Console.WriteLine ("Listedeki ��e say�s�: {0}", dl1.Count);
            foreach (S�n�f1 ad in dl1) Console.Write ("{0}.ad={1} ", ++i, ad.isim);

            Console.WriteLine ("\n\nBir DiziListe'yi di�erinin tipleme parametresi olarak kopyalama:");
            ArrayList dl2 = new ArrayList();
            dl2.Add ("Bu"); dl2.Add ("bir"); dl2.Add ("dizge"); dl2.Add ("��eli"); dl2.Add ("dizi"); dl2.Add ("listesidir.");
            ArrayList dl2a = new ArrayList (dl2);
            Console.WriteLine ("dl2: {0}\tdl2a: {1}", dl2, dl2a);
            foreach (string kelime in dl2a) Console.Write (kelime+" ");
            Console.WriteLine ("\ndl2a.IsFixedSize: {0},\tdl2s.IsReadOnly: {1}",dl2a.IsFixedSize, dl2a.IsReadOnly);

            Console.WriteLine ("\nAdd, Insert, Add/InsertRange, Set/GetRange ile eleman girme/silme:");
            ArrayList dl3 = new ArrayList();
            dl3.Add ("bir"); dl3.Insert (0, "Bu");
            string[] dzg1 = {"Add", "AddRange"};
            dl3.AddRange (dzg1);
            string[] dzg2 = {"Insert", "InsertRange", "ile", "eleman", "girme", "�rne�idir."};
            dl3.InsertRange (dl3.Count, dzg2);
            ListeyiG�ster ("dl3", dl3);
            string[] dzg3 = {"�nceki", "elemanlar�n", "�st�ne", "yazar"};
            dl3.SetRange (0, dzg3);
            ListeyiG�ster ("dl3", dl3);
            dl3.Insert (0, "Nihat");  dl3.Insert (dl3.Count, "Nihatt");
            if (dl3.Contains ("Nihat")) {
                i = dl3.IndexOf ("Nihat");
                Console.WriteLine ("�LK: dl3 [{0}]='Nihat'", i);
                j = dl3.LastIndexOf ("Nihat");
                if(j!=i) Console.WriteLine ("SON: dl3 [{0}]='Nihat'", j);
            }
            dl3.RemoveAt (0); dl3.Remove ("Nihatt"); dl3.RemoveRange (0, 4);
            ListeyiG�ster ("dl3", dl3);
            dl3.Reverse();
            ListeyiG�ster ("dl3", dl3);
            Console.WriteLine ("dl3.Count={0},\tdl3.Capacity={1}", dl3.Count, dl3.Capacity);
            dl3.TrimToSize();
            Console.WriteLine ("dl3.Count={0},\tdl3.Capacity={1}", dl3.Count, dl3.Capacity);
            dl3.Reverse();
            ArrayList dl3a = dl3.GetRange (3, 3);
            ListeyiG�ster ("dl3a", dl3a);
            Console.Write ("GetEnumerator()'lu liste: ");
            IEnumerator ie = dl3a.GetEnumerator();
            while (ie.MoveNext()) {Console.Write (ie.Current+" ");}

            Console.WriteLine ("\n\nVarsay�l� IComparer:Compare() ad+�ehir ikili k�yasla s�ralanm��t�r:");
            ArrayList dl4 = new ArrayList();
            dl4.Add (new Ki�i ("Nihat", "Mersin", 67)); dl4.Add (new Ki�i ("Y�cel", "Bursa", 51)); dl4.Add (new Ki�i ("Canan", "Antalya", 48)); dl4.Add (new Ki�i ("Hilal", "Malatya", 42)); dl4.Add (new Ki�i ("Fatih", "�zmir", 44)); dl4.Add (new Ki�i ("Nihat", "Ku�adas�", 57));
            Console.WriteLine ("\t==>S�ralama �ncesi liste:");
            foreach (Ki�i k in dl4) {Console.WriteLine ("{0}, {1}, {2}", k.ad, k.�ehir, k.ya�);}
            // �zelle�tirilen IComparer ile s�ralama
            dl4.Sort (new Ki�i());
            Console.WriteLine ("\t==>�zelle�tirilen s�ralama sonras� liste:");
            foreach (Ki�i k in dl4) {Console.WriteLine ("{0}, {1}, {2}", k.ad, k.�ehir, k.ya�);}

            Console.WriteLine ("\nB�y�k/k���kharf duyars�z listeyi endeksli normal, s�ral� ve ters sunma:");
            ArrayList dl5 = new ArrayList();
            dl5.Add ("Nihat"); dl5.Add ("y�cel"); dl5.Add ("canan"); dl5.Add ("Hilal"); dl5.Add ("Fatih"); dl5.Add ("nihat");
            EndeksliListeyiG�ster (dl5);
            dl5.Sort(); EndeksliListeyiG�ster (dl5);
            IComparer ic = new tersS�rala(); dl5.Sort (ic);
            EndeksliListeyiG�ster (dl5);

            Console.WriteLine ("\nKarma liste elemanlar�ndan sadece int'lerinin sunulmas�:");
            ArrayList dl6 = new ArrayList();
            dl6.AddRange (new object[] {10, 400, 8, false, new Araba(), "dizgesel veri", 'A', 20240112});
            IEnumerable<int> ie2 = dl6.OfType<int>();
            foreach (int ts in ie2) Console.WriteLine ("int de�er: {0}", ts);
            ArrayList dl6a = new ArrayList();
            dl6a.AddRange (new object[] {10, 400, 8, false, new Araba().Ad�, new Araba().Rengi, new Araba().H�z�, new Araba().Markas�, new Araba().Kilometresi, "dizgesel veri", 'A', 20240112});
            IEnumerable<int> ie3 = dl6a.OfType<int>();
            foreach (int ts in ie3) Console.WriteLine ("\tint de�er: {0}", ts);

            Console.WriteLine ("\n�zel esge�en Add'le 2'den fazla ayr�k adlar�n eklenmesi:");
            KontrolluAd dl7 = new KontrolluAd();
            dl7.Add ("Nihat" ); dl7.Add ("M.Nihat"); dl7.Add ("M.Nihat Yava�"); dl7.Add ("Hatice Yava� Ka�ar "); dl7.Add ("Nihal Zeliha Yava� Candan"); dl7.Add ("ABCD"); dl7.Add ("ABCD XYZ");
            foreach (object ns in dl7) Console.WriteLine (ns);

            Console.WriteLine ("\nVerili �r�nleri �zelle�tirilen ad'la artan s�ralay�p sunma:");
            ArrayList �r�nler = �r�n.Ekli�r�nleriAl();
            �r�nler.Sort (new �r�nAd�K�yas�());
            i=0; foreach (�r�n �r�n in �r�nler) {Console.WriteLine ("{0}.�r�n) {1:0.00} TL", ++i, �r�n);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}