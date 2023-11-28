// j2sc#0722c.cs: Parametrik sýnýf, sabitler ve serileþtirme/serisizleþtirme örneði.

using System;
using System.Collections.Generic; //List için
using System.IO; //Stream için
namespace Sýnýflar {
    class Kiþi {
        public string isim;
        public int yaþ;
        public Kiþi (string a, int y) {isim = a; yaþ = y;} //Kurucu
        public void Bilgilendir() {Console.WriteLine ("{0}'ýn yaþý {1}'dir.", isim, yaþ);}
    }
    class Hayvan {public virtual void konuþ() {Console.WriteLine ("Grooaav!..");}}
    class Köpek : Hayvan {public override void konuþ() {Console.WriteLine ("Hav hav!..");}}
    class Kedi : Hayvan {public override void konuþ() {Console.WriteLine ("Miyav, miyav!..");}}
    class Davar : Hayvan {public override void konuþ() {Console.WriteLine ("Me, me!..");}}
    class Sýðýr : Hayvan {public override void konuþ() {Console.WriteLine ("Moo, möö!..");}}
    class Sabitler {
        public const long deðer1 = 20231108073645987;
        public const string deðer2 = "M.Nihat Yavaþ";
    }
    struct Ýþgören {
        public string isim;
        public long tcno;
        public byte derece;
        public bool sözleþmeliMi;
        public byte yaþ;
        public float maaþ;
        public Ýþgören (string isim, long tcno, byte derece, bool sözleþmeliMi, byte yaþ, float maaþ) {
            this.isim = isim;
            this.tcno = tcno;
            this.derece = derece;
            this.sözleþmeliMi = sözleþmeliMi;
            this.yaþ = yaþ;
            this.maaþ = maaþ;
        }
        public override string ToString() {return string.Format ("{0}, {1}, {2}, {3}, {4}, {5}", isim, tcno, derece, sözleþmeliMi, yaþ, maaþ);}
    }
    class Çeþitli3 {
        public static void RefSýnýf (ref Kiþi k) {k = new Kiþi ("\tNihal Candan", 69);}
        static void DinleBeni (Hayvan hayvan) {hayvan.konuþ();}
        private static List<Ýþgören> ÝþgörenListesi() {
            var r=new Random(); long ls; float fs; byte b1, b2; bool b;
            List<Ýþgören> iþgörenler = new List<Ýþgören>();
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Bekir Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Fadime Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Memet Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Haným Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Hatice Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Süheyla Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Zeliha Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("M.Nihat Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Songül Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("M.Nedim Yavaþ", ls, b1, b, b2, fs));
            ls=1L*r.Next(3000000,10000000)*r.Next(4000,10000); fs=r.Next(7865,100000)+r.Next(10,100)/100F; b=false; if(ls%2==0) b=true; b1=(byte)r.Next(0,10); b2=(byte)r.Next(18,100);
            iþgörenler.Add (new Ýþgören ("Sevim Yavaþ", ls, b1, b, b2, fs));
            return iþgörenler;
        }
        private static void ÝþgSerile (Stream akýþ, IEnumerable<Ýþgören> iþgörenler) {
            BinaryWriter yazýcý = new BinaryWriter (akýþ);
            foreach (Ýþgören iþg in iþgörenler) {
                yazýcý.Write (iþg.isim);
                yazýcý.Write (iþg.tcno);
                yazýcý.Write (iþg.derece);
                yazýcý.Write (iþg.sözleþmeliMi);
                yazýcý.Write (iþg.yaþ);
                yazýcý.Write (iþg.maaþ);
                Console.WriteLine ("Yazýlan: {0}", iþg.ToString());
            }
        }
        private static List<Ýþgören> ÝþgSerisizle (Stream akýþ) {
            List<Ýþgören> iþgörenler = new List<Ýþgören>();
            BinaryReader okuyucu = new BinaryReader (akýþ);
            try {
                while (true) {
                    Ýþgören iþg = new Ýþgören();
                    iþg.isim = okuyucu.ReadString();
                    iþg.tcno = okuyucu.ReadInt64();
                    iþg.derece = okuyucu.ReadByte();
                    iþg.sözleþmeliMi = okuyucu.ReadBoolean();
                    iþg.yaþ = okuyucu.ReadByte();
                    iþg.maaþ = okuyucu.ReadSingle();
                    iþgörenler.Add (iþg);
                    Console.WriteLine ("\tOkunan: {0}", iþg.ToString());
                }
            }catch (EndOfStreamException){}
            return iþgörenler;
        }
        static void Main() {
            Console.Write ("Sýnýf tiplemeleri de metotlara parametre olarak geçirilebilir. Sabit const deðiþken statik imalý olup, beyanýnda ilkdeðer atanýp deðiþirilemez. BinaryWriter ve BinaryReader verileri 01-ikiliye çevirip bellek akýþýna/Stream yazar ve okur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tiplenen Kiþi nesnesinin ref parametreli metotla deðiþtirilmesi:");
            Kiþi k = new Kiþi ("Belkýs Candan", 42); k.Bilgilendir();
            RefSýnýf (ref k); k.Bilgilendir();
            k = new Kiþi ("Canan Candan", 49); k.Bilgilendir();
            RefSýnýf (ref k); k.Bilgilendir();
            k = new Kiþi ("Zafer Candan", 45); k.Bilgilendir();
            RefSýnýf (ref k); k.Bilgilendir();

            Console.WriteLine ("\nParametrik hayvan sýnýflarýn metoda geçirilip konuþturulmalarý:");
            Hayvan h1 = new Hayvan(); DinleBeni (h1);
            Köpek h2 = new Köpek(); DinleBeni (h2);
            Kedi h3 = new Kedi(); DinleBeni (h3);
            Davar h4 = new Davar(); DinleBeni (h4);
            Sýðýr h5 = new Sýðýr(); DinleBeni (h5);

            Console.WriteLine ("\nÝlkdeðerleri deðiþtirilemeyen 'const' deðiþken deðerleri:");
            Console.WriteLine ("Ýsim: {0},\tTarih: {1}", Sabitler.deðer2, Sabitler.deðer1);
            //Sabitler.deðer2="Mithat Savaþ"; //Derleme hatasý

            Console.WriteLine ("\nSabit PI ile farklý daire (yarýçap,çevre,alan) hesaplarý:");
            const double PI = 3.141592653589793;
            double ds1, çevre, alan; int i; var r=new Random();
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100)+r.Next(1000,10000)/10000D;
                çevre=2*PI*ds1;
                alan=PI*ds1*ds1;
                Console.WriteLine ("(y,ç,a) = ({0,7:#0.0000}, {1,7:0.000}, {2,9:#,0.00})", ds1, çevre, alan);
            }

            Console.WriteLine ("\nBellek akýþýna iþgören listesini serileþtirip yazma ve serisizleþtirip okuma:");
            Stream akýþ = new MemoryStream();
            IEnumerable<Ýþgören> iþgörenler = ÝþgörenListesi();
            ÝþgSerile (akýþ, iþgörenler);
            akýþ.Seek (0, SeekOrigin.Begin);
            ÝþgSerisizle (akýþ);
            Console.Write ("Ýkiliye serileþen Hexa iþgören verileri: ");
            akýþ.Seek (0, SeekOrigin.Begin);
            while ((i = akýþ.ReadByte()) != -1) Console.Write ("{0:X} ", i);

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}