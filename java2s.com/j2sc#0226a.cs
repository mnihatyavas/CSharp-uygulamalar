// j2sc#0226a.cs: Hiçlenebilir deðiþkenlerin deðer kontrollarý ve yansýtýlmalarý örneði.

using System;
namespace VeriTipleri {
    public class Ýþgören {
        public string Ýsim;
        public long? sgkNo;
        public Nullable<DateTime> ayrýlýþTarihi;
        public Ýþgören (string Ýsim) {//Kurucu metot
            this.Ýsim = Ýsim;
            this.sgkNo = default (Nullable<long>);
            this.ayrýlýþTarihi = null;
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
    class Hiçlenebilir1 {
        static double nullBakiye() {Console.Write ("Null bakiye: "); return 0.0;}
        static void Main() {
            Console.Write ("Hiç (null) deðerli deðiþkenin tipi (GetType) yoktur, ancak deðer atanýrsa tiplenir. Hiçlenebilir tanýmý '<tip>?', 'Nullable<tip>', 'new <tip>?()' ile yapýlýr ve hiç deðer atamasý 'null'dur. Hiçlenebilir Struct üye deðerlerine class'taki gibi doðrudan deðil 'Value' ile eriþilebilir. Null kontrolu 'sayý.HasValue', 'sayý != null', 'sayý ?? -1' veya 'sayý == null ? -1 : sayý' ile kontrol edilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int? ts1 = null;
            int? ts2 = new int?();
            int? ts3 = 2023;
            int? ts4 = new int? (1951);
            Console.WriteLine ("{0}...{1}...{2}...{3}", ts1, ts2, ts3, ts4);
            Console.WriteLine ("ts1 == null? {0}", ts1 == null);
            object ns1 = ts1; Console.WriteLine ("ns1 == null? {0}", ns1 == null);
            try {Console.WriteLine ("ts3: {0}", ts3.GetType()); Console.WriteLine ("ts1: {0}", ts1.GetType());} catch (Exception h) {Console.WriteLine ("\tts1: "+h.Message);}
            object ns2 = ts3; try {Console.WriteLine ("ns2: {0}", ns2.GetType()); Console.WriteLine ("ns1: {0}", ns1.GetType());} catch (Exception h) {Console.WriteLine ("\tns1: "+h.Message);}

            Console.WriteLine ("\nÝþgörenlerin isim, sgk-no, terk-tarih bilgileri:");
            var iþg1 = new Ýþgören ("Hatice Yavaþ"); iþg1.sgkNo = 1234567890;
            Console.WriteLine ("Ýsim: {0}", iþg1.Ýsim);
            long geçiciNo = iþg1.sgkNo ?? -1; Console.WriteLine ("\tSGK No: {0}", geçiciNo);
            if (iþg1.ayrýlýþTarihi.HasValue) {Console.WriteLine ("\tÝþten ayrýlýþ tarihi: {0}", iþg1.ayrýlýþTarihi);}

            var iþg2 = new Ýþgören ("M.Nihat Yavaþ"); iþg2.sgkNo = 9876543210; iþg2.ayrýlýþTarihi = new DateTime (2023, 5, 27);
            Console.WriteLine ("Ýsim: {0}", iþg2.Ýsim);
            geçiciNo = iþg2.sgkNo ?? -1; Console.WriteLine ("\tSGK No: {0}", geçiciNo);
            if (iþg2.ayrýlýþTarihi.HasValue) Console.WriteLine ("\tÝþten ayrýlýþ tarihi: {0}", iþg2.ayrýlýþTarihi);

            var iþg3 = new Ýþgören ("Sevim Yavaþ"); iþg3.ayrýlýþTarihi = new DateTime (2022, 12, 31, 18, 30, 0, 0);
            Console.WriteLine ("Ýsim: {0}", iþg3.Ýsim);
            Console.WriteLine ("\tSGK No: {0}", (iþg3.sgkNo ?? -1));
            if (iþg2.ayrýlýþTarihi.HasValue) Console.WriteLine ("\tÝþten ayrýlýþ tarihi: {0}", iþg3.ayrýlýþTarihi);

            Console.WriteLine ("\nclas Nokta1 ve hiçlenebilir nokta koordinatlarý:");
            Nokta1 n1 = new Nokta1(); n1.x=6; n1.y=12;
            Nokta1 n2 = new Nokta1(); n2.x=5; n2.y=10;
            Nokta1 n3 = new Nokta1(); n3.x=5; n3.y=null;
            Nokta1 n4 = new Nokta1(); n4.x=null; n4.y=10;
            Nokta1 n5 = new Nokta1(); n5.x=null; n5.y=null;
            Console.WriteLine ("Nokta11 (x, y) = ({0}, {1})", n1.x, n1.y);
            Console.WriteLine ("Nokta12 (x, y) = ({0}, {1})", n2.x, n2.y);
            Console.WriteLine ("Hiçlenebilir Nokta13 (x, y) = ({0}, {1})", n3.x, n3.y);
            Console.WriteLine ("Hiçlenebilir Nokta14 (x, y) = ({0}, {1})", n4.x, n4.y);
            Console.WriteLine ("Hiçlenebilir Nokta15 (x, y) = ({0}, {1})", n5.x, n5.y);

            Console.WriteLine ("\nstruct Nokta2 ve hiçlenebilir nokta koordinatlarý:");
            Nokta2 n21 = new Nokta2 (6, 12);
            Nokta2? n22 = new Nokta2 (5, 10); //Hiçlenebilir
            Console.WriteLine ("Nokta21 (x, y) = ({0}, {1})", n21.x, n21.y);
            Console.WriteLine ("Hiçlenebilir Nokta22 (x, y) = ({0}, {1})", n22.Value.x, n22.Value.y);

            Console.WriteLine ("\nHiçlenebilir deðiþkenin deðer kontrolu:");
            if (!ts1.HasValue) Console.WriteLine ("Hiçlenebilir ts1 null/deðersizdir.");
            else Console.WriteLine ("Hiçlenebilir ts1 = {0}", ts1);
            Console.WriteLine ("int? ts1 null'{0}.", ts1 == null ? "dur" : "deðildir");
            Console.WriteLine ("int? ts1 = {0}", ts1 ?? -1);
            ts1=2023;
            if (ts1 == null) Console.WriteLine ("Hiçlenebilir ts1 null/deðersizdir.");
            else Console.WriteLine ("Hiçlenebilir ts1 = {0} veya {1}", ts1, ts1.Value);
            Console.WriteLine ("int? ts1 null {0}.", ts1 == null ? "dur" : "deðildir");
            Console.WriteLine ("int? ts1 = {0}", ts1 ?? -1);

            Console.WriteLine ("\nnull ile her iþlem sonucu da null'dur:");
            Console.WriteLine ("int? ts2 + 10 * 3 - 15 = {0}", (ts2 = ts2 + 10 * 3 - 15));
            Console.WriteLine ("int? ts1 + 10 * 3 - 15 = {0}", (ts1 = ts1 + 10 * 3 - 15));

            Console.WriteLine ("\nBakiye null ise 0 gösterilebilir:");
            double? iþlem = 1500, bakiye;
            bakiye = (iþlem + 3*iþlem - iþlem) ?? nullBakiye();
            Console.WriteLine (bakiye);
            iþlem = null;
            bakiye = (iþlem + 3*iþlem - iþlem) ?? nullBakiye();
            Console.WriteLine (bakiye);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}