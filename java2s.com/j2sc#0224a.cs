// j2sc#0224a.cs: Geniþten dar sayý tiplerine atamanýn veri kaybý oluþturabilmesi örneði.

using System;
namespace VeriTipleri {
    class TipUyarlama1 {
        static void Main() {
            Console.Write ("Sayý tipleri farklýysa, daralarak veri kaybý oluþturmamak için otomatik tip deðiþimi daima mevcuttakilerin en geniþine uyarlanýr (double, float, decimal, ulong, long, uint, int).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            short ss1 = short.MinValue;
            int ts1 =  int.MaxValue;
            Console.WriteLine ("short kapsamý = [{0}, {1}]\nint kapsamý = [{2}, {3}]", short.MinValue, short.MaxValue, int.MinValue, int.MaxValue);
            Console.WriteLine ("short ss1 = {0}\nint ts1 = {1}", ss1, ts1);
            ss1-=10;  ts1+=10;
            Console.WriteLine ("ss1-=10: {0}\nts1+=10: {1}", ss1, ts1);

            long ls1;
            double ds1;
            ls1 = long.MaxValue;
            ds1 = ls1; 
            Console.WriteLine ("\nDizgeyle toplam tüm sayý tiplerini dizgeleþtirir:");
            Console.WriteLine ("ls1({0}) + \" Mersin \" + ds1({2}) =\n   {3}", ls1, "Mersin", ds1, (ls1 + " Mersin " + ds1) );

            Console.WriteLine ("\nKüsüratlý sayý tamsayýya atanýrken küsüratlar atýlýr:");
            ls1 = (long) (ds1 / ss1);
            Console.WriteLine ("(long) (ds1({0}) / ss1({1})) = {2}", ds1, ss1, ls1);

            Console.WriteLine ("\nBüyük kapsamlý küçüðe atanýrken taþan kaybolur:");
            byte bs1 = (byte) ls1;
            Console.WriteLine ("byte bs1 = (byte) ls1({0}): {1}", ls1, bs1);
            uint uts1=32000; ss1=(short)uts1;
            Console.WriteLine ("short ss1 = (short) uts1({0}): {1}: Veri kaybý yok", uts1, ss1);
            Console.WriteLine ("short ss1 = (short) uts1({0}): {1}: Veri kaybý var", (uts1=64000), (ss1=(short)uts1));
            bs1=88; char krk1=(char) bs1; 
            Console.WriteLine ("char krk1 = (char) bs1({0}): {1}: ascii(88)=X", bs1, krk1);

            Console.WriteLine ("\nKareköklerin tamsayý ve küsüratlarýný ayrýþtýrma:");
            for(ds1 = 1.0; ds1 <= 10; ds1++) {Console.WriteLine ("Karekök({0})={1} ==>Tamsayý={2} ve Küsürat={3}", ds1, Math.Sqrt(ds1), (int)Math.Sqrt(ds1), (Math.Sqrt(ds1) - (int)Math.Sqrt(ds1)) );}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}