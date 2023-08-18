// j2sc#0605b.cs: Deðer/ref aktarým, yapýsal dizi, arayüzlü kutulama/kutusuzlama örneði.

using System;
namespace Yapýlar {
    public struct Yapý1 {public int ts;}
    struct KompleksSayý {
        public float gerçel;
        public float sanal;
        public KompleksSayý (float gerçel, float sanal) {this.gerçel = gerçel; this.sanal = sanal;} //Kurucu
        public override string ToString() {return String.Format ("({0} + j{0})", gerçel, sanal);}
    }
    struct ÝÞGÖREN {
        public string ad;
        public short bölümNO;
        public ÝÞGÖREN (string n, short d) {ad = n; bölümNO = d;} //Kurucu
    }
    public interface IYapý {int X {get; set;} }
    public struct Yapý2: IYapý {// Arayüz ebeveynli yapý
        public int x;
        public int X {get {return x;} set {x = value;} }
        public override string ToString() {return x.ToString();}
    }
    public interface IGöster {void Yaz();}
    public struct Yapý3 : IGöster {
        public int x;
        public void Yaz() {Console.WriteLine ("{0}", x);}
    }
    class YapýAlanlarý2 {
        static void DeðerAktarma (Yapý1 y1) {Console.Write (y1.ts); y1.ts = 2023; Console.WriteLine (" --> " + y1.ts);}
        static void ReferansAktarma (ref Yapý1 y1) {y1.ts = 1952;}
        public static void fn_int (int k) {k = 1938;}
        public static void fn_Int32(ref Int32 k) {k = 1881;}
        public static void kutusuzla (object ns) {ÝÞGÖREN aracý = (ÝÞGÖREN)ns; Console.WriteLine ("Ýþgören adý ve bölüm no: ({0}, {1})", aracý.ad, aracý.bölümNO);}
        static void Main() {
            Console.Write ("Deðer aktarma metot dýþý yapýyý etkilemez, ref/adres aktarma etkiler. Kutulama object'le yapýlýr, kutusuzlama tekrar orijinal tipine çevirir. Arayüz alanýna public deðer get-set metodu yavruda tanýmlanmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Deðer ve referans aktarmanýn etki farký;");
            Yapý1 y1 = new Yapý1();
            y1.ts = 1963; Console.WriteLine ("y1.ts = {0}", y1.ts);
            DeðerAktarma (y1); Console.WriteLine ("DeðerAktarma sonucu: y1.ts = {0}", y1.ts);
            ReferansAktarma (ref y1); Console.WriteLine ("ReferansAktarma sonucu: y1.ts = {0}", y1.ts);
            y1.ts = 2023-1963; Console.WriteLine ("y1.ts = {0}", y1.ts);
            DeðerAktarma (y1); Console.WriteLine ("DeðerAktarma sonucu: y1.ts = {0}", y1.ts);
            ReferansAktarma (ref y1); Console.WriteLine ("ReferansAktarma sonucu: y1.ts = {0}", y1.ts);

            Console.WriteLine ("\nNormal metotlara deðer ve ref argüman geçirme farký:");
            int ts1 = 0; Console.WriteLine ("Orijinal: ts1 = {0}", ts1);
            fn_int (ts1); Console.WriteLine ("fn_int(ts1) sonrasý: ts1 = {0}", ts1);
            fn_Int32 (ref ts1); Console.WriteLine ("fn_Int32(ref ts1) sonrasý: ts1 = {0}", ts1);
            Int32 ts2 = 1; Console.WriteLine ("Orijinal: ts2 = {0}", ts2);
            fn_int (ts2); Console.WriteLine ("fn_int(ts2) sonrasý: ts2 = {0}", ts2);
            fn_Int32 (ref ts2); Console.WriteLine ("fn_Int32(ref ts2) sonrasý: ts2 = {0}", ts2);

            Console.WriteLine ("\nKompleks sayýlar dizisinin argümansýz yaratýlýþý ve deðer atanýþý:");
            var r=new Random();
            KompleksSayý[] ksDizi = new KompleksSayý [5];
            for (int i=0; i<ksDizi.Length; i++) {Console.WriteLine ("ksDizi[{0}] = {1}", i, ksDizi [i]); ksDizi [i].gerçel = r.Next (-100, 100) + r.Next (1000, 10000) / 10000F; ksDizi [i].sanal = r.Next (-100, 100) + r.Next (1000, 10000) / 10000F;}
            for (int i=0; i<ksDizi.Length; i++) Console.WriteLine ("ksDizi[{0}] = {1}", i, ksDizi [i]);

            Console.WriteLine ("\nYapý'nýn kutula2ect tiple kutulanmasý ve tekrar kutusuzlanmasý:");
            ÝÞGÖREN iþg = new ÝÞGÖREN ("nihat", 2023); iþg.ad = "Nihat"; object kutula = iþg; kutusuzla (kutula);
            iþg = new ÝÞGÖREN ("Zeliha", 1955); iþg.ad = "Nihal"; kutula = iþg; kutusuzla (kutula);
            iþg = new ÝÞGÖREN ("Canan", 1975); kutula = iþg; kutusuzla (kutula);
            iþg = new ÝÞGÖREN ("Zafer", 1977); kutula = iþg; kutusuzla (kutula);
            iþg = new ÝÞGÖREN ("Belkýs", 1982); kutula = iþg; kutusuzla (kutula);

            Console.WriteLine ("\nArayüz miraslý yapýnýn kutulanýp kutusuzlanmasý:");
            Yapý2 y21 = new Yapý2(); y21.x = r.Next (-10000, 10000);
            object kutula2 = y21;
            Console.WriteLine ("y21.x = {0}\tkutula2.x = {1}", y21, kutula2.ToString());
            IYapý iy2 = (IYapý) kutula2;
            iy2.X = r.Next (-10000, 10000); kutula2 = iy2;
            Console.WriteLine ("Arayüz iy2.X = {0}\tkutula2.x = {1}", iy2, kutula2.ToString());
            Yapý2 y22 = (Yapý2) kutula2;
            Console.WriteLine ("Kutusuzla y22.x = {0}", y22);

            Console.WriteLine ("\nKutulayan arayüz metodu yavruda public tanýmla çaðrýlabilir:");
            Yapý3 y31 = new Yapý3(); y31.x = r.Next (-10000, 10000);
            y31.Yaz(); //Kutusuz Yaz()
            IGöster yazýcý = y31;
            yazýcý.Yaz(); //Arayüz yazýcý'yla kutulu Yaz()
            y31.x = r.Next (-10000, 10000); yazýcý = y31; y31.Yaz(); yazýcý.Yaz();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}