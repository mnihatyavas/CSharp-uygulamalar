// j2sc#0224b.cs: Taþma hatasýz/hatalý unchecked/checked bloklarý ve daralan/geniþleyen atama farký örneði.

using System;
namespace VeriTipleri {
    class TipUyarlama2 {
        static int IntY (int m, int x, int b) {return (m * x) + b;}
        static double DoubleY (double m, double x, double b) {return (m * x) + b;}
        static void Main() {
            Console.Write ("Daralan sayý tipine atamalarda, 'checked' bloðu try-catch gerektirirken, 'unchecked' bloðu yada bloksuzluk taþaný veri kayýplý daralana uyarlarken hata fýrlatmayacaðýndan try-catch yönetimi gerekmez.\nDardan geniþleyen tipe atamalarda (tip) bildirimi gerekmez.\nDardan geniþleyene atama kurallarý:\n1) sbyte: short, int, long, float, double, decimal\n2) byte: short, ushort, int, uint, long, ulong, float, double, decimal\n3) short: int, long, float, double, decimal\n4) ushort: int, uint, long, ulong, float, double, decimal\n5) int: long, float, double, decimal\n6) uint: long, ulong, float, double, decimal\n7) long, ulong: float, double, decimal\n8) float: double\n9) char: ushort, int, uint, long, ulong, float, double, decimal\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            uint its1 = (uint)r.Next (0, 1000);
            byte bs1, bs2=127, bs3=127;
            Console.WriteLine ("Daralan uyarlama taþmasýnda unchecked/checked bloklarý:");
            Console.WriteLine ("byte bs1=unchecked((byte)(uint its1({0}))): {1}", its1, (bs1=unchecked((byte)its1))); //Asla kontrol edilmez
            try {Console.WriteLine ("byte bs1=checked((byte)(uint its1({0}))): {1}", its1, (bs1=checked((byte)its1))); //Daima kontrol edilir
                }catch{Console.WriteLine ("checked blokta yakalanan taþma hatasý...");}
            Console.WriteLine ("byte bs1=(byte)(uint its1({0})): {1}", its1, (bs1=(byte)its1)); //(Taþma) gerekiyorsa kontrol edilir

            try {bs1 = unchecked ((byte) (bs2 * bs3)); Console.WriteLine ("\nUnchecked/kontrolsuz bloklu 127*127 = {0}", bs1);
                bs1 = checked ((byte) (bs2 * bs3)); Console.WriteLine ("Checked/kontrollu bloklu 127*127 = Hata fýrlatýr, buraya ulaþmaz");
            }catch (OverflowException h) {Console.WriteLine ("Checked/kontrollu blok hatasý: [{0}]", h.Message);}

            ushort iss1 = (ushort)r.Next (1000, 10000);
            bs1 = unchecked ((byte) iss1); //Hatasýz uyarlar
            Console.WriteLine ("\nbyte bs1 = unchecked ((byte) ushort iss1({0})): [{1}]", iss1, bs1);
            try {bs1 = checked ((byte) iss1); //Taþma hatasý fýrlatýr
            }catch (OverflowException h) {Console.WriteLine ("byte bs1 = checked ((byte) ushort iss1({0})):\n\t[{1}]", iss1, h.Message);}

            int ts1 = r.Next (65, 91);
            Console.WriteLine ("\nint ts1 = {0},\tTip: {1}", ts1, ts1.GetTypeCode());
            char krk1 = (char)ts1;  
            Console.WriteLine ("char krk1 = (char)int ts1({0}) = {1},\tTip: {2}", ts1, krk1, krk1.GetTypeCode());

            ts1 = r.Next (0, 1000); bs1 = (byte)ts1;
            Console.WriteLine ("\nbyte bs1 = (byte)int ts1({0}) = {1}", ts1, bs1);
            try {bs1 = Convert.ToByte (ts1); Console.WriteLine ("byte bs1 = Convert.ToByte(ts1({0})) = {1}", ts1, bs1);
            }catch (OverflowException h) {Console.WriteLine ("byte bs1 = Convert.ToByte(ts1({0})) = [{1}]", ts1, h.Message);}

            ts1 = int.MaxValue;
            long ls1 = ts1;
            Console.WriteLine ("\nGeniþleyen long ls1 = int ts1({0}) = {1}", ts1, ls1);
            ls1 = (long)ts1; //Geniþleyene atamada tip bildirimi fuzuli
            Console.WriteLine ("Geniþleyen long ls1 = (long)(int ts1({0})) = {1}", ts1, ls1);

            int x, m, b;
            double xd, md, bd;
            m = r.Next (0, 10); x = r.Next (0, 10); b = r.Next (0, 10);
            md = m + r.Next (0, 1000)/1000.0; xd = x + r.Next (0, 1000)/1000.0; bd = b + r.Next (0, 1000)/1000.0;
            Console.WriteLine ("\nint fonksiyon ve int argümanlarla y=m*x+b:\n\tIntY (m({0}), x({1}), b({2})) = {3}", m, x, b, IntY (m, x, b));
            Console.WriteLine ("int fonksiyon ve double argümanlarla y=md*xd+bd:\n\tIntY ((int)md({0}), (int)xd({1}), (int)bd({2})) = {3}", md, xd, bd, IntY ((int)md, (int)xd, (int)bd));
            Console.WriteLine ("double fonksiyon ve double argümanlarla yd=md*xd+bd:\n\tDoubleY (md({0}), xd({1}), bd({2})) = {3}", md, xd, bd, DoubleY (md, xd, bd));
            Console.WriteLine ("double fonksiyon ve int argümanlarla yd=m*x+b:\n\tDoubleY (m({0}), x({1}), b({2})) = {3}", m, x, b, DoubleY (m, x, b));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}