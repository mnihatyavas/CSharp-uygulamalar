// j2sc#0605b.cs: De�er/ref aktar�m, yap�sal dizi, aray�zl� kutulama/kutusuzlama �rne�i.

using System;
namespace Yap�lar {
    public struct Yap�1 {public int ts;}
    struct KompleksSay� {
        public float ger�el;
        public float sanal;
        public KompleksSay� (float ger�el, float sanal) {this.ger�el = ger�el; this.sanal = sanal;} //Kurucu
        public override string ToString() {return String.Format ("({0} + j{0})", ger�el, sanal);}
    }
    struct ��G�REN {
        public string ad;
        public short b�l�mNO;
        public ��G�REN (string n, short d) {ad = n; b�l�mNO = d;} //Kurucu
    }
    public interface IYap� {int X {get; set;} }
    public struct Yap�2: IYap� {// Aray�z ebeveynli yap�
        public int x;
        public int X {get {return x;} set {x = value;} }
        public override string ToString() {return x.ToString();}
    }
    public interface IG�ster {void Yaz();}
    public struct Yap�3 : IG�ster {
        public int x;
        public void Yaz() {Console.WriteLine ("{0}", x);}
    }
    class Yap�Alanlar�2 {
        static void De�erAktarma (Yap�1 y1) {Console.Write (y1.ts); y1.ts = 2023; Console.WriteLine (" --> " + y1.ts);}
        static void ReferansAktarma (ref Yap�1 y1) {y1.ts = 1952;}
        public static void fn_int (int k) {k = 1938;}
        public static void fn_Int32(ref Int32 k) {k = 1881;}
        public static void kutusuzla (object ns) {��G�REN arac� = (��G�REN)ns; Console.WriteLine ("��g�ren ad� ve b�l�m no: ({0}, {1})", arac�.ad, arac�.b�l�mNO);}
        static void Main() {
            Console.Write ("De�er aktarma metot d��� yap�y� etkilemez, ref/adres aktarma etkiler. Kutulama object'le yap�l�r, kutusuzlama tekrar orijinal tipine �evirir. Aray�z alan�na public de�er get-set metodu yavruda tan�mlanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("De�er ve referans aktarman�n etki fark�;");
            Yap�1 y1 = new Yap�1();
            y1.ts = 1963; Console.WriteLine ("y1.ts = {0}", y1.ts);
            De�erAktarma (y1); Console.WriteLine ("De�erAktarma sonucu: y1.ts = {0}", y1.ts);
            ReferansAktarma (ref y1); Console.WriteLine ("ReferansAktarma sonucu: y1.ts = {0}", y1.ts);
            y1.ts = 2023-1963; Console.WriteLine ("y1.ts = {0}", y1.ts);
            De�erAktarma (y1); Console.WriteLine ("De�erAktarma sonucu: y1.ts = {0}", y1.ts);
            ReferansAktarma (ref y1); Console.WriteLine ("ReferansAktarma sonucu: y1.ts = {0}", y1.ts);

            Console.WriteLine ("\nNormal metotlara de�er ve ref arg�man ge�irme fark�:");
            int ts1 = 0; Console.WriteLine ("Orijinal: ts1 = {0}", ts1);
            fn_int (ts1); Console.WriteLine ("fn_int(ts1) sonras�: ts1 = {0}", ts1);
            fn_Int32 (ref ts1); Console.WriteLine ("fn_Int32(ref ts1) sonras�: ts1 = {0}", ts1);
            Int32 ts2 = 1; Console.WriteLine ("Orijinal: ts2 = {0}", ts2);
            fn_int (ts2); Console.WriteLine ("fn_int(ts2) sonras�: ts2 = {0}", ts2);
            fn_Int32 (ref ts2); Console.WriteLine ("fn_Int32(ref ts2) sonras�: ts2 = {0}", ts2);

            Console.WriteLine ("\nKompleks say�lar dizisinin arg�mans�z yarat�l��� ve de�er atan���:");
            var r=new Random();
            KompleksSay�[] ksDizi = new KompleksSay� [5];
            for (int i=0; i<ksDizi.Length; i++) {Console.WriteLine ("ksDizi[{0}] = {1}", i, ksDizi [i]); ksDizi [i].ger�el = r.Next (-100, 100) + r.Next (1000, 10000) / 10000F; ksDizi [i].sanal = r.Next (-100, 100) + r.Next (1000, 10000) / 10000F;}
            for (int i=0; i<ksDizi.Length; i++) Console.WriteLine ("ksDizi[{0}] = {1}", i, ksDizi [i]);

            Console.WriteLine ("\nYap�'n�n kutula2ect tiple kutulanmas� ve tekrar kutusuzlanmas�:");
            ��G�REN i�g = new ��G�REN ("nihat", 2023); i�g.ad = "Nihat"; object kutula = i�g; kutusuzla (kutula);
            i�g = new ��G�REN ("Zeliha", 1955); i�g.ad = "Nihal"; kutula = i�g; kutusuzla (kutula);
            i�g = new ��G�REN ("Canan", 1975); kutula = i�g; kutusuzla (kutula);
            i�g = new ��G�REN ("Zafer", 1977); kutula = i�g; kutusuzla (kutula);
            i�g = new ��G�REN ("Belk�s", 1982); kutula = i�g; kutusuzla (kutula);

            Console.WriteLine ("\nAray�z mirasl� yap�n�n kutulan�p kutusuzlanmas�:");
            Yap�2 y21 = new Yap�2(); y21.x = r.Next (-10000, 10000);
            object kutula2 = y21;
            Console.WriteLine ("y21.x = {0}\tkutula2.x = {1}", y21, kutula2.ToString());
            IYap� iy2 = (IYap�) kutula2;
            iy2.X = r.Next (-10000, 10000); kutula2 = iy2;
            Console.WriteLine ("Aray�z iy2.X = {0}\tkutula2.x = {1}", iy2, kutula2.ToString());
            Yap�2 y22 = (Yap�2) kutula2;
            Console.WriteLine ("Kutusuzla y22.x = {0}", y22);

            Console.WriteLine ("\nKutulayan aray�z metodu yavruda public tan�mla �a�r�labilir:");
            Yap�3 y31 = new Yap�3(); y31.x = r.Next (-10000, 10000);
            y31.Yaz(); //Kutusuz Yaz()
            IG�ster yaz�c� = y31;
            yaz�c�.Yaz(); //Aray�z yaz�c�'yla kutulu Yaz()
            y31.x = r.Next (-10000, 10000); yaz�c� = y31; y31.Yaz(); yaz�c�.Yaz();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}