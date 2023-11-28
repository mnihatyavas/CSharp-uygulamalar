// j2sc#0722g.cs: ICloneable.Clone() arayüz þablonlu klonla kopyalama örneði.

using System;
using System.Collections.Generic; //List için
using System.Text; //StringBuilder için
namespace Sýnýflar {
    class Deðer {
        public int sayý;
        public Deðer (int n) {sayý = n;} //Kurucu
    }
    class Nesne: ICloneable {
        public Deðer deðer;
        public Nesne (int m) {deðer = new Deðer (m);} //Kurucu
        public object Clone() {
            Console.Write("Nesne.Clone()");
            return(new Nesne (deðer.sayý));
        }
    }
    public class Þahýs : ICloneable {
        public string isim;
        public string meslek;
        public int yaþ;
        public Þahýs (string i, string m, int y) {isim = i; meslek = m; yaþ = y;} //Kurucu
        public object Clone() {return MemberwiseClone();}
        public override string ToString() {return string.Format ("(ad,meslek,yaþ): (\"{0}\", {1}, {2}", isim, meslek, yaþ);}
    }
    public class ÞahýsListesi : ICloneable {
        public List<Þahýs> ÞLÜyeleri =  new List<Þahýs>();
        public ÞahýsListesi(){} //Varsayýlý parametresiz kurucu
        public object Clone() {return new ÞahýsListesi (this.ÞLÜyeleri);} //Alttaki private kurucuyu kullanýr
        private ÞahýsListesi (List<Þahýs> üyeler) { //private parametreli kurucu
            foreach (Þahýs þ in üyeler) {ÞLÜyeleri.Add ((Þahýs)þ.Clone());} //Þahýs.Clone()'unu kullanýr
        }
        public void ÜyeEkle(Þahýs üye) {ÞLÜyeleri.Add (üye);}
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (Þahýs þ in ÞLÜyeleri) {sb.AppendFormat ("\t{0}\n", þ);}
            return sb.ToString();
        }
    }
    public class NoktaTasviri {
        public string ad;
        public Guid no;
        public NoktaTasviri() {ad = "3BoyutluNokta"; no = Guid.NewGuid();} //Ýlkdeðerleyen parametresiz kurucu
    }
    public class Nokta : ICloneable {
        public int x, y, z;
        public NoktaTasviri tasvir = new NoktaTasviri();
        public Nokta(){} //Parametresiz kurucu
        public Nokta (int x, int y, int z) {this.x = x; this.y = y; this.z = z;} //3 parametreli kurucu
        public Nokta (int x, int y, int z, string ad) {this.x = x; this.y = y; this.z = z; tasvir.ad = ad;} //4 parametreli kurucu
        public object Clone() {
            Nokta klon = (Nokta)MemberwiseClone();
            NoktaTasviri nt = new NoktaTasviri();
            nt.ad = tasvir.ad;
            klon.tasvir = nt;
            return klon;
        }
        public override string ToString() {return string.Format ("(x,y,z,ad,no) = ({0}, {1}, {2}, {3}, {4})", x, y, z, tasvir.ad, tasvir.no.ToString().Substring(0,8));}
    }
    class Çeþitli7 {
        static void Main() {
            Console.Write ("ICloneable klonlanabilir arayüz Clone() metodunu þablonlar. Sonrasýnda birnde yapýlacak deðiþiklik diðerini etkilemez.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Clone() metoduyla kurucu sayýsýný koyma ve alma:");
            Nesne nes1; Nesne kln1; int ts1, ts2, ts3, i; var r=new Random();
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000);
                nes1 = new Nesne (ts1);
                kln1 = (Nesne) nes1.Clone();
                Console.WriteLine (": {0}\tAslý: {1}", kln1.deðer.sayý, nes1.deðer.sayý);
            }

            Console.WriteLine ("\nÞahýslar ekler, klon kopyalar, aslýný deðiþtirir, dökümler:");
            ÞahýsListesi takým = new ÞahýsListesi();
            takým.ÜyeEkle (new Þahýs ("Bekir Yavaþ", "Emekli", 81+49));
            takým.ÜyeEkle (new Þahýs ("Fatma Yavaþ", "Üstade", 75+55));
            takým.ÜyeEkle (new Þahýs ("Memet Yavaþ", "Bahcývan", 84+7));
            takým.ÜyeEkle (new Þahýs ("Haným Yavaþ", "Evhanýmý", 84+9));
            takým.ÜyeEkle (new Þahýs ("Songül Yavaþ", "Öðretmen", 45+0));
            ÞahýsListesi klon = (ÞahýsListesi)takým.Clone();
            Console.WriteLine ("Orijinal ÞahýsListesi:"); Console.Write (takým);
            Console.WriteLine ("Klon ÞahýsListesi:"); Console.Write (klon);
            Console.WriteLine ("*** Orijinal takýmda ve kopya klonda deðiþiklik ***");
            takým.ÞLÜyeleri [4].isim = "Songül Göktürk"; takým.ÞLÜyeleri [4].meslek = "Emekli"; takým.ÞLÜyeleri [4].yaþ = 64;
            klon.ÞLÜyeleri [3].meslek = "Patron";
            Console.WriteLine ("Orijinal ÞahýsListesi:"); Console.Write (takým);
            Console.WriteLine ("Klon ÞahýsListesi:"); Console.Write (klon);

            Console.WriteLine ("\n3 boyutlu, ad ve no'lu farklý kuruculu nokta, klonu, deðiþiklik ve dökümler:");
            ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100);
            Nokta n1 = new Nokta (ts1, ts2, ts3);
            Nokta n2 = n1; ts1=r.Next(-100,100); n2.x = ts1;
            Console.WriteLine ("n1: {0}", n1); Console.WriteLine ("n2: {0}", n2);
            ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100);
            Nokta n3 = new Nokta (ts1, ts2, ts3, "Nihat");
            Nokta n4 = (Nokta)n3.Clone();
            Console.WriteLine ("n3: {0}", n3); Console.WriteLine ("n4: {0}", n4);
            n4.tasvir.ad = "Bay Mithat"; ts1=r.Next(-100,100); n4.x = ts1;
            Console.WriteLine ("n3: {0}", n3); Console.WriteLine ("n4: {0}", n4);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}