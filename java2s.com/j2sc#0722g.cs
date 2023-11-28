// j2sc#0722g.cs: ICloneable.Clone() aray�z �ablonlu klonla kopyalama �rne�i.

using System;
using System.Collections.Generic; //List i�in
using System.Text; //StringBuilder i�in
namespace S�n�flar {
    class De�er {
        public int say�;
        public De�er (int n) {say� = n;} //Kurucu
    }
    class Nesne: ICloneable {
        public De�er de�er;
        public Nesne (int m) {de�er = new De�er (m);} //Kurucu
        public object Clone() {
            Console.Write("Nesne.Clone()");
            return(new Nesne (de�er.say�));
        }
    }
    public class �ah�s : ICloneable {
        public string isim;
        public string meslek;
        public int ya�;
        public �ah�s (string i, string m, int y) {isim = i; meslek = m; ya� = y;} //Kurucu
        public object Clone() {return MemberwiseClone();}
        public override string ToString() {return string.Format ("(ad,meslek,ya�): (\"{0}\", {1}, {2}", isim, meslek, ya�);}
    }
    public class �ah�sListesi : ICloneable {
        public List<�ah�s> �L�yeleri =  new List<�ah�s>();
        public �ah�sListesi(){} //Varsay�l� parametresiz kurucu
        public object Clone() {return new �ah�sListesi (this.�L�yeleri);} //Alttaki private kurucuyu kullan�r
        private �ah�sListesi (List<�ah�s> �yeler) { //private parametreli kurucu
            foreach (�ah�s � in �yeler) {�L�yeleri.Add ((�ah�s)�.Clone());} //�ah�s.Clone()'unu kullan�r
        }
        public void �yeEkle(�ah�s �ye) {�L�yeleri.Add (�ye);}
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (�ah�s � in �L�yeleri) {sb.AppendFormat ("\t{0}\n", �);}
            return sb.ToString();
        }
    }
    public class NoktaTasviri {
        public string ad;
        public Guid no;
        public NoktaTasviri() {ad = "3BoyutluNokta"; no = Guid.NewGuid();} //�lkde�erleyen parametresiz kurucu
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
    class �e�itli7 {
        static void Main() {
            Console.Write ("ICloneable klonlanabilir aray�z Clone() metodunu �ablonlar. Sonras�nda birnde yap�lacak de�i�iklik di�erini etkilemez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Clone() metoduyla kurucu say�s�n� koyma ve alma:");
            Nesne nes1; Nesne kln1; int ts1, ts2, ts3, i; var r=new Random();
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000);
                nes1 = new Nesne (ts1);
                kln1 = (Nesne) nes1.Clone();
                Console.WriteLine (": {0}\tAsl�: {1}", kln1.de�er.say�, nes1.de�er.say�);
            }

            Console.WriteLine ("\n�ah�slar ekler, klon kopyalar, asl�n� de�i�tirir, d�k�mler:");
            �ah�sListesi tak�m = new �ah�sListesi();
            tak�m.�yeEkle (new �ah�s ("Bekir Yava�", "Emekli", 81+49));
            tak�m.�yeEkle (new �ah�s ("Fatma Yava�", "�stade", 75+55));
            tak�m.�yeEkle (new �ah�s ("Memet Yava�", "Bahc�van", 84+7));
            tak�m.�yeEkle (new �ah�s ("Han�m Yava�", "Evhan�m�", 84+9));
            tak�m.�yeEkle (new �ah�s ("Song�l Yava�", "��retmen", 45+0));
            �ah�sListesi klon = (�ah�sListesi)tak�m.Clone();
            Console.WriteLine ("Orijinal �ah�sListesi:"); Console.Write (tak�m);
            Console.WriteLine ("Klon �ah�sListesi:"); Console.Write (klon);
            Console.WriteLine ("*** Orijinal tak�mda ve kopya klonda de�i�iklik ***");
            tak�m.�L�yeleri [4].isim = "Song�l G�kt�rk"; tak�m.�L�yeleri [4].meslek = "Emekli"; tak�m.�L�yeleri [4].ya� = 64;
            klon.�L�yeleri [3].meslek = "Patron";
            Console.WriteLine ("Orijinal �ah�sListesi:"); Console.Write (tak�m);
            Console.WriteLine ("Klon �ah�sListesi:"); Console.Write (klon);

            Console.WriteLine ("\n3 boyutlu, ad ve no'lu farkl� kuruculu nokta, klonu, de�i�iklik ve d�k�mler:");
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

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}