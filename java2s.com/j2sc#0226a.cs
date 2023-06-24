// j2sc#0226a.cs: Hi�lenebilir de�i�kenlerin de�er kontrollar� ve yans�t�lmalar� �rne�i.

using System;
namespace VeriTipleri {
    public class ��g�ren {
        public string �sim;
        public long? sgkNo;
        public Nullable<DateTime> ayr�l��Tarihi;
        public ��g�ren (string �sim) {//Kurucu metot
            this.�sim = �sim;
            this.sgkNo = default (Nullable<long>);
            this.ayr�l��Tarihi = null;
        }
    }
    class Nokta1 {
        public int? x;
        public int? y;
        public Nokta1() {x = null; y = null;}
    }
    struct Nokta2 {
        public int x;
        public int y;
        public Nokta2 (int a, int b) {x = a; y = b;}
    }
    class Hi�lenebilir1 {
        static double nullBakiye() {Console.Write ("Null bakiye: "); return 0.0;}
        static void Main() {
            Console.Write ("Hi� (null) de�erli de�i�kenin tipi (GetType) yoktur, ancak de�er atan�rsa tiplenir. Hi�lenebilir tan�m� '<tip>?', 'Nullable<tip>', 'new <tip>?()' ile yap�l�r ve hi� de�er atamas� 'null'dur. Hi�lenebilir Struct �ye de�erlerine class'taki gibi do�rudan de�il 'Value' ile eri�ilebilir. Null kontrolu 'say�.HasValue', 'say� != null', 'say� ?? -1' veya 'say� == null ? -1 : say�' ile kontrol edilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int? ts1 = null;
            int? ts2 = new int?();
            int? ts3 = 2023;
            int? ts4 = new int? (1951);
            Console.WriteLine ("{0}...{1}...{2}...{3}", ts1, ts2, ts3, ts4);
            Console.WriteLine ("ts1 == null? {0}", ts1 == null);
            object ns1 = ts1; Console.WriteLine ("ns1 == null? {0}", ns1 == null);
            try {Console.WriteLine ("ts3: {0}", ts3.GetType()); Console.WriteLine ("ts1: {0}", ts1.GetType());} catch (Exception h) {Console.WriteLine ("\tts1: "+h.Message);}
            object ns2 = ts3; try {Console.WriteLine ("ns2: {0}", ns2.GetType()); Console.WriteLine ("ns1: {0}", ns1.GetType());} catch (Exception h) {Console.WriteLine ("\tns1: "+h.Message);}

            Console.WriteLine ("\n��g�renlerin isim, sgk-no, terk-tarih bilgileri:");
            var i�g1 = new ��g�ren ("Hatice Yava�"); i�g1.sgkNo = 1234567890;
            Console.WriteLine ("�sim: {0}", i�g1.�sim);
            long ge�iciNo = i�g1.sgkNo ?? -1; Console.WriteLine ("\tSGK No: {0}", ge�iciNo);
            if (i�g1.ayr�l��Tarihi.HasValue) {Console.WriteLine ("\t��ten ayr�l�� tarihi: {0}", i�g1.ayr�l��Tarihi);}

            var i�g2 = new ��g�ren ("M.Nihat Yava�"); i�g2.sgkNo = 9876543210; i�g2.ayr�l��Tarihi = new DateTime (2023, 5, 27);
            Console.WriteLine ("�sim: {0}", i�g2.�sim);
            ge�iciNo = i�g2.sgkNo ?? -1; Console.WriteLine ("\tSGK No: {0}", ge�iciNo);
            if (i�g2.ayr�l��Tarihi.HasValue) Console.WriteLine ("\t��ten ayr�l�� tarihi: {0}", i�g2.ayr�l��Tarihi);

            var i�g3 = new ��g�ren ("Sevim Yava�"); i�g3.ayr�l��Tarihi = new DateTime (2022, 12, 31, 18, 30, 0, 0);
            Console.WriteLine ("�sim: {0}", i�g3.�sim);
            Console.WriteLine ("\tSGK No: {0}", (i�g3.sgkNo ?? -1));
            if (i�g2.ayr�l��Tarihi.HasValue) Console.WriteLine ("\t��ten ayr�l�� tarihi: {0}", i�g3.ayr�l��Tarihi);

            Console.WriteLine ("\nclas Nokta1 ve hi�lenebilir nokta koordinatlar�:");
            Nokta1 n1 = new Nokta1(); n1.x=6; n1.y=12;
            Nokta1 n2 = new Nokta1(); n2.x=5; n2.y=10;
            Nokta1 n3 = new Nokta1(); n3.x=5; n3.y=null;
            Nokta1 n4 = new Nokta1(); n4.x=null; n4.y=10;
            Nokta1 n5 = new Nokta1(); n5.x=null; n5.y=null;
            Console.WriteLine ("Nokta11 (x, y) = ({0}, {1})", n1.x, n1.y);
            Console.WriteLine ("Nokta12 (x, y) = ({0}, {1})", n2.x, n2.y);
            Console.WriteLine ("Hi�lenebilir Nokta13 (x, y) = ({0}, {1})", n3.x, n3.y);
            Console.WriteLine ("Hi�lenebilir Nokta14 (x, y) = ({0}, {1})", n4.x, n4.y);
            Console.WriteLine ("Hi�lenebilir Nokta15 (x, y) = ({0}, {1})", n5.x, n5.y);

            Console.WriteLine ("\nstruct Nokta2 ve hi�lenebilir nokta koordinatlar�:");
            Nokta2 n21 = new Nokta2 (6, 12);
            Nokta2? n22 = new Nokta2 (5, 10); //Hi�lenebilir
            Console.WriteLine ("Nokta21 (x, y) = ({0}, {1})", n21.x, n21.y);
            Console.WriteLine ("Hi�lenebilir Nokta22 (x, y) = ({0}, {1})", n22.Value.x, n22.Value.y);

            Console.WriteLine ("\nHi�lenebilir de�i�kenin de�er kontrolu:");
            if (!ts1.HasValue) Console.WriteLine ("Hi�lenebilir ts1 null/de�ersizdir.");
            else Console.WriteLine ("Hi�lenebilir ts1 = {0}", ts1);
            Console.WriteLine ("int? ts1 null'{0}.", ts1 == null ? "dur" : "de�ildir");
            Console.WriteLine ("int? ts1 = {0}", ts1 ?? -1);
            ts1=2023;
            if (ts1 == null) Console.WriteLine ("Hi�lenebilir ts1 null/de�ersizdir.");
            else Console.WriteLine ("Hi�lenebilir ts1 = {0} veya {1}", ts1, ts1.Value);
            Console.WriteLine ("int? ts1 null {0}.", ts1 == null ? "dur" : "de�ildir");
            Console.WriteLine ("int? ts1 = {0}", ts1 ?? -1);

            Console.WriteLine ("\nnull ile her i�lem sonucu da null'dur:");
            Console.WriteLine ("int? ts2 + 10 * 3 - 15 = {0}", (ts2 = ts2 + 10 * 3 - 15));
            Console.WriteLine ("int? ts1 + 10 * 3 - 15 = {0}", (ts1 = ts1 + 10 * 3 - 15));

            Console.WriteLine ("\nBakiye null ise 0 g�sterilebilir:");
            double? i�lem = 1500, bakiye;
            bakiye = (i�lem + 3*i�lem - i�lem) ?? nullBakiye();
            Console.WriteLine (bakiye);
            i�lem = null;
            bakiye = (i�lem + 3*i�lem - i�lem) ?? nullBakiye();
            Console.WriteLine (bakiye);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}