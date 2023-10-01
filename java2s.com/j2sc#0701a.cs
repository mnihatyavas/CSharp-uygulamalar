// j2sc#0701a.cs: S�n�f alan, metot, ebeveyn ta�mas�, i�i�e s�n�f �a��rma �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {public int x = 0;}
    class Nokta {
        public int x;
        public int y;
        public Nokta (int x, int y) {this.x = x; this.y = y;} //S�n�f kurucusu
    }
    class Bina {
        public int kat;
        public int alan;
        public int mukim;
    }
    class Dikd�rtgen {
        private uint en;
        private uint boy;
        private uint alan;
        public uint En {get {return en;} set {en = value; Alan�Hesapla();} }
        public uint Boy {get {return boy;} set {boy = value; Alan�Hesapla();} }
        public uint Alan {get {return alan;} }
        private void Alan�Hesapla() {alan = en * boy;}
    }
    public class Araba {
        private int h�z;
        private Ara�Radyosu m�zik = new Ara�Radyosu();
        public Araba() {h�z = 100;}
        public int H�z {get {return h�z;} set {h�z = value;} }
        public void RadyoyuD��mele (bool durum) {m�zik.A��kM� (durum);}
    }
    public class Ara�Radyosu {
        public void A��kM� (bool drm) {
            if (drm) Console.WriteLine ("A�IK...");
            else Console.WriteLine ("KAPALI...");
        }
    }
    class TemelS�n�f {
        public string Alan1 = "TemelS�n�f Alan1";
        public void Metod1 (string dizge) {Console.WriteLine ("TemelS�n�f Metod1(): {0}", dizge);}
        public void Yaz() {Console.WriteLine ("Bu TemelS�n�f'�n Yaz() metodudur.");}
    }
    class T�rediS�n�f: TemelS�n�f {
        public string Alan2 = "T�rediS�n�f Alan2";
        public void Metod2 (string dizge) {Console.WriteLine ("T�rediS�n�f Metod2(): {0}", dizge);}
        public void Yaz() {Console.WriteLine ("Bu T�rediS�n�f'�n Yaz() metodudur.");}
    }
    class S�n�fTan�m�1 {
        S�n�fTan�m�1() {Console.WriteLine ("S�n�fTan�m�1 kurucusu �a�r�ld�.");}
        ~S�n�fTan�m�1() {Console.WriteLine ("S�n�fTan�m�1 y�k�c�s� �a�r�ld�.");}
        void MesajYaz (string mesaj) {Console.WriteLine ("MesajYaz(): {0}", mesaj);}
        void Dispose() {GC.SuppressFinalize (this);}
        static void Main() {
            Console.Write ("S�n�f/class bir nesne tiplemesi olup, tan�ml� �yeler ve metodlar �ablonudur. Tipleme de�i�kenleri 'eri�im tip ad'la tan�mlan�r, 'nesne.�ye'yle eri�ilir. Nesnel tip s�n�f kopyalar� referanssal oldu�undan de�i�iklikler birbirlerini etkiler. T�retilen yavru s�n�f kendi alan ve metodlar�n�n yan�s�ra miraslad��� ebeveyninkileri de (ayn�ysa ta�ma/overload �nceli�iyle) kullanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f tan�mlar� ve �yelerine eri�imler:");
            var r=new Random();
            S�n�f1 s1 = new S�n�f1(); s1.x = r.Next (-10000, 10000);
            Console.WriteLine ("s1.GetType() = {0}\ns1.x = {1}", s1.GetType(), s1.x);
            Console.WriteLine ("\t==>Main() metod anas�n�f� S�n�fTan�m�1()'n�n tepesi.");
            S�n�fTan�m�1 uyg = new S�n�fTan�m�1();
            uyg.MesajYaz ("S�n�fTan�m�1 s�n�f�ndan herkese selamlar!");
            Console.WriteLine("\t==>Main() fonksiyonun dibi.");
            uyg.Dispose();
            Nokta n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);
            n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);
            n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);

            Console.WriteLine ("\nEvi�i kullan�m alan�n�n mukim ki�iba�� m^2 pay�:");
            Bina ev1 = new Bina();
            int ki�iba��Alan; ev1.mukim = 11; ev1.alan = 200; ev1.kat = 2; ki�iba��Alan = ev1.alan / ev1.mukim;
            Console.WriteLine ("Evin katsay�s�={0}\tHanehalk�={1}\tAlan = {2}\tKi�iba�� alan={3}", ev1.kat, ev1.mukim, ev1.alan, ki�iba��Alan);
            Bina ev2 = new Bina(); ev2.mukim = 4; ev2.alan = 2500; ev2.kat = 2; Console.WriteLine ("Evin katsay�s�={0}\tHanehalk�={1}\tAlan = {2}\tKi�iba�� alan={3}", ev2.kat, ev2.mukim, ev2.alan, ev2.alan / ev2.mukim);
            Bina ev3 = new Bina(); ev3.mukim = 7; ev3.alan = 300; ev3.kat = 3; Console.WriteLine ("Evin katsay�s�={0}\tHanehalk�={1}\tAlan = {2}\tKi�iba�� alan={3}", ev3.kat, ev3.mukim, ev3.alan, ev3.alan / ev3.mukim);

            Console.WriteLine ("\nNesnel tip s�n�f�n kopyas� birbirlerini etkiler:");
            S�n�f1 a = new S�n�f1(); S�n�f1 b = new S�n�f1();
            a.x = r.Next (0, 10000);  b.x = r.Next (0, 10000); Console.WriteLine ("Ayr�k: a.x = {0}\tb.x = {1}", a.x, b.x);
            a = b; b.x = r.Next (0, 10000); Console.WriteLine ("Kopyal�: a.x = {0}\tb.x = {1}", a.x, b.x);
            a.x = r.Next (0, 10000); Console.WriteLine ("Kopyal�: a.x = {0}\tb.x = {1}", a.x, b.x);
            Dikd�rtgen d1 = new Dikd�rtgen(); Dikd�rtgen d2 = new Dikd�rtgen();
            d1.En = (uint)r.Next (0, 100); d1.Boy = (uint)r.Next (0, 100); d2.En = (uint)r.Next (0, 100); d2.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Ayr�k: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);
            d1 = d2; d1.En = (uint)r.Next (0, 100); d1.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Kopyal�: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);
            d2.En = (uint)r.Next (0, 100); d2.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Kopyal�: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);

            Console.WriteLine ("\n��i�e Araba/Radyo s�n�flar�yla s�rat de�i�tir/oku ve m�zi�i a�/kapa:");
            Araba a1 = new Araba();
            a1.H�z = r.Next (0, 150); Console.WriteLine ("Araban�n �uanki h�z� = {0} km/st", a1.H�z);
            Console.Write ("L�tfen radyoyu a�ar m�s�n? "); a1.RadyoyuD��mele (true);
            a1.H�z = r.Next (0, 150); Console.WriteLine ("Araban�n �uanki h�z� = {0} km/st", a1.H�z);
            Console.Write ("L�tfen radyoyu kapar m�s�n? "); a1.RadyoyuD��mele (false);

            Console.WriteLine ("\nT�redi s�n�f kendi ve temel s�n�f�n metotlar�nda t�m alanlar� kullanabilir:");
            T�rediS�n�f ts1 = new T�rediS�n�f();
            ts1.Metod1(ts1.Alan1);
            ts1.Metod1(ts1.Alan2);
            ts1.Metod2(ts1.Alan1);
            ts1.Metod2(ts1.Alan2);
            //ts1 = new T�rediS�n�f();
            TemelS�n�f es1 = (TemelS�n�f)ts1;
            ts1.Yaz(); //Yavru ta�ma/overload �nceli�i
            es1.Yaz(); //Ebeveyn ta�ma/overload �nceli�i

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}