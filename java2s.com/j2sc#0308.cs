// j2sc#0308.cs: Üçlemeli "ifade1 ? ifade2 : ifade3" örneði.

using System;
namespace Ýþlemciler {
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
    class ÜçlemeliÝþlemci {
        static void Main() {
            Console.Write ("? iþlemcisi if-else gibidir, ilk ifade true ise ikincisi, deðilse ayný tipli üçüncüsü iþlenir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10, ts2=2, sonuç;
            sonuç = ts2 != 0? ts1 % ts2 : -1;
            Console.WriteLine ("'sonuç = ts2 != 0? ts1 % ts2 : -1' ise:");
            Console.WriteLine ("sonuç = ts1({0}) % ts2({1}): {2}", ts1, ts2, sonuç);
            ts2=0; sonuç = ts2 != 0? ts1 % ts2 : -1;
            Console.WriteLine ("sonuç = ts1({0}) % ts2({1}): {2}", ts1, ts2, sonuç);

            ts1=2023; ts2=1955;
            Console.WriteLine ("\nts1={0} ve ts2={1}' ise:", ts1, ts2);
            Console.WriteLine ("ts1, ts2'den büyük{0}", ts1 > ts2? "tür." : " deðildir.");
            ts2=2050; Console.WriteLine ("ts1={0} ve ts2={1}' ise:", ts1, ts2);
            Console.WriteLine ("ts1, ts2'den büyük{0}", ts1 > ts2? "tür." : " deðildir.");

            Console.WriteLine ("\nSýfýra bölüm kontrollu for döngüsü:");
            for (ts1 = -10; ts1 <= 10; ts1+=2) {
                sonuç = ts1 != 0 ? 100 / ts1 : 0;
                if (ts1 != 0) Console.WriteLine ("100 / " + ts1 + " = " + sonuç);
            }

            Console.WriteLine ("\nArþiv ve özel veritipli iþlemci-operator metotlarý:");
            VerTipi vtSayý = (VerTipi) 2023; // "operator VeriTipi (int 2023)" çaðrýlýr, geridönen "Ýþlemciler.VeriTipi"
            ts1 = (int) vtSayý; // "operator int (VeriTipi Ýþlemciler.VeriTipi)" çaðrýlýr, geridönen "1881"
            Console.WriteLine (ts1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}