// j2sc#0308.cs: ��lemeli "ifade1 ? ifade2 : ifade3" �rne�i.

using System;
namespace ��lemciler {
    class VerTipi {
        public static explicit operator int (VerTipi x) {
            Console.WriteLine ("explicit operator int: " + x);
            return 1881;
        }
        public static explicit operator VerTipi (int x) {
            Console.WriteLine ("public static explicit operator VerTipi: " + x);
            return new VerTipi();
        }

    }
    class ��lemeli��lemci {
        static void Main() {
            Console.Write ("? i�lemcisi if-else gibidir, ilk ifade true ise ikincisi, de�ilse ayn� tipli ���nc�s� i�lenir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10, ts2=2, sonu�;
            sonu� = ts2 != 0? ts1 % ts2 : -1;
            Console.WriteLine ("'sonu� = ts2 != 0? ts1 % ts2 : -1' ise:");
            Console.WriteLine ("sonu� = ts1({0}) % ts2({1}): {2}", ts1, ts2, sonu�);
            ts2=0; sonu� = ts2 != 0? ts1 % ts2 : -1;
            Console.WriteLine ("sonu� = ts1({0}) % ts2({1}): {2}", ts1, ts2, sonu�);

            ts1=2023; ts2=1955;
            Console.WriteLine ("\nts1={0} ve ts2={1}' ise:", ts1, ts2);
            Console.WriteLine ("ts1, ts2'den b�y�k{0}", ts1 > ts2? "t�r." : " de�ildir.");
            ts2=2050; Console.WriteLine ("ts1={0} ve ts2={1}' ise:", ts1, ts2);
            Console.WriteLine ("ts1, ts2'den b�y�k{0}", ts1 > ts2? "t�r." : " de�ildir.");

            Console.WriteLine ("\nS�f�ra b�l�m kontrollu for d�ng�s�:");
            for (ts1 = -10; ts1 <= 10; ts1+=2) {
                sonu� = ts1 != 0 ? 100 / ts1 : 0;
                if (ts1 != 0) Console.WriteLine ("100 / " + ts1 + " = " + sonu�);
            }

            Console.WriteLine ("\nAr�iv ve �zel veritipli i�lemci-operator metotlar�:");
            VerTipi vtSay� = (VerTipi) 2023; // "operator VeriTipi (int 2023)" �a�r�l�r, gerid�nen "��lemciler.VeriTipi"
            ts1 = (int) vtSay�; // "operator int (VeriTipi ��lemciler.VeriTipi)" �a�r�l�r, gerid�nen "1881"
            Console.WriteLine (ts1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}