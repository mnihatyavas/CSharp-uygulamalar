// j2sc#0722c.cs: Parametrik s�n�f, sabitler ve serile�tirme/serisizle�tirme �rne�i.

using System;
using System.Collections.Generic; //List i�in
using System.IO; //Stream i�in
namespace S�n�flar {
    class Ki�i {
        public string isim;
        public int ya�;
        public Ki�i (string a, int y) {isim = a; ya� = y;} //Kurucu
        public void Bilgilendir() {Console.WriteLine ("{0}'�n ya�� {1}'dir.", isim, ya�);}
    }
    class Hayvan {public virtual void konu�() {Console.WriteLine ("Grooaav!..");}}
    class K�pek : Hayvan {public override void konu�() {Console.WriteLine ("Hav hav!..");}}
    class Kedi : Hayvan {public override void konu�() {Console.WriteLine ("Miyav, miyav!..");}}
    class Davar : Hayvan {public override void konu�() {Console.WriteLine ("Me, me!..");}}
    class S���r : Hayvan {public override void konu�() {Console.WriteLine ("Moo, m��!..");}}
    class Sabitler {
        public const long de�er1 = 20231108073645987;
        public const string de�er2 = "M.Nihat Yava�";
    }
    struct ��g�ren {
        public string isim;
        public long tcno;
        public byte derece;
        public bool s�zle�meliMi;
        public byte ya�;
        public float maa�;
        public ��g�ren (string isim, long tcno, byte derece, bool s�zle�meliMi, byte ya�, float maa�) {
            this.isim = isim;
            this.tcno = tcno;
            this.derece = derece;
            this.s�zle�meliMi = s�zle�meliMi;
            this.ya� = ya�;
            this.maa� = maa�;
        }
        public override string ToString() {return string.Format ("{0}, {1}, {2}, {3}, {4}, {5}", isim, tcno, derece, s�zle�meliMi, ya�, maa�);}
    }
    class �e�itli3 {
        public static void RefS�n�f (ref Ki�i k) {k = new Ki�i ("\tNihal Candan", 69);}
        static void DinleBeni (Hayvan hayvan) {hayvan.konu�();}
        private static List<��g�ren> ��g�renListesi() {
            var r=new Random(); long ls; float fs; byte b1, b2; bool b;
            List<��g�ren> i�g�renler = new List<��g�ren>();
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Bekir Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Fadime Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Memet Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Han�m Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Hatice Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("S�heyla Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Zeliha Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("M.Nihat Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Song�l Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("M.Nedim Yava�", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            i�g�renler.Add (new ��g�ren ("Sevim Yava�", ls, b1, b, b2, fs));
            return i�g�renler;
        }
        private static void ��gSerile (Stream ak��, IEnumerable<��g�ren> i�g�renler) {
            BinaryWriter yaz�c� = new BinaryWriter (ak��);
            foreach (��g�ren i�g in i�g�renler) {
                yaz�c�.Write (i�g.isim);
                yaz�c�.Write (i�g.tcno);
                yaz�c�.Write (i�g.derece);
                yaz�c�.Write (i�g.s�zle�meliMi);
                yaz�c�.Write (i�g.ya�);
                yaz�c�.Write (i�g.maa�);
                Console.WriteLine ("Yaz�lan: {0}", i�g.ToString());
            }
        }
        private static List<��g�ren> ��gSerisizle (Stream ak��) {
            List<��g�ren> i�g�renler = new List<��g�ren>();
            BinaryReader okuyucu = new BinaryReader (ak��);
            try {
                while (true) {
                    ��g�ren i�g = new ��g�ren();
                    i�g.isim = okuyucu.ReadString();
                    i�g.tcno = okuyucu.ReadInt64();
                    i�g.derece = okuyucu.ReadByte();
                    i�g.s�zle�meliMi = okuyucu.ReadBoolean();
                    i�g.ya� = okuyucu.ReadByte();
                    i�g.maa� = okuyucu.ReadSingle();
                    i�g�renler.Add (i�g);
                    Console.WriteLine ("\tOkunan: {0}", i�g.ToString());
                }
            }catch (EndOfStreamException){}
            return i�g�renler;
        }
        static void Main() {
            Console.Write ("S�n�f tiplemeleri de metotlara parametre olarak ge�irilebilir. Sabit const de�i�ken statik imal� olup, beyan�nda ilkde�er atan�p de�i�irilemez. BinaryWriter ve BinaryReader verileri 01-ikiliye �evirip bellek ak���na/Stream yazar ve okur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tiplenen Ki�i nesnesinin ref parametreli metotla de�i�tirilmesi:");
            Ki�i k = new Ki�i ("Belk�s Candan", 42); k.Bilgilendir();
            RefS�n�f (ref k); k.Bilgilendir();
            k = new Ki�i ("Canan Candan", 49); k.Bilgilendir();
            RefS�n�f (ref k); k.Bilgilendir();
            k = new Ki�i ("Zafer Candan", 45); k.Bilgilendir();
            RefS�n�f (ref k); k.Bilgilendir();

            Console.WriteLine ("\nParametrik hayvan s�n�flar�n metoda ge�irilip konu�turulmalar�:");
            Hayvan h1 = new Hayvan(); DinleBeni (h1);
            K�pek h2 = new K�pek(); DinleBeni (h2);
            Kedi h3 = new Kedi(); DinleBeni (h3);
            Davar h4 = new Davar(); DinleBeni (h4);
            S���r h5 = new S���r(); DinleBeni (h5);

            Console.WriteLine ("\n�lkde�erleri de�i�tirilemeyen 'const' de�i�ken de�erleri:");
            Console.WriteLine ("�sim: {0},\tTarih: {1}", Sabitler.de�er2, Sabitler.de�er1);
            //Sabitler.de�er2="Mithat Sava�"; //Derleme hatas�

            Console.WriteLine ("\nSabit PI ile farkl� daire (yar��ap,�evre,alan) hesaplar�:");
            const double PI = 3.141592653589793;
            double ds1, �evre, alan; int i; var r=new Random();
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100)+r.Next(1000,10000)/10000D;
                �evre=2*PI*ds1;
                alan=PI*ds1*ds1;
                Console.WriteLine ("(y,�,a) = ({0,7:#0.0000}, {1,7:0.000}, {2,9:#,0.00})", ds1, �evre, alan);
            }

            Console.WriteLine ("\nBellek ak���na i�g�ren listesini serile�tirip yazma ve serisizle�tirip okuma:");
            Stream ak�� = new MemoryStream();
            IEnumerable<��g�ren> i�g�renler = ��g�renListesi();
            ��gSerile (ak��, i�g�renler);
            ak��.Seek (0, SeekOrigin.Begin);
            ��gSerisizle (ak��);
            Console.Write ("�kiliye serile�en Hexa i�g�ren verileri: ");
            ak��.Seek (0, SeekOrigin.Begin);
            while ((i = ak��.ReadByte()) != -1) Console.Write ("{0:X} ", i);

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}