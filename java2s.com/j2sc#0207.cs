// j2sc#0207.cs: Tamsayýlarla aritmetik, mantýksal, bitsel, artan/azalan ve bölüm hesaplamalarý örneði.

using System;
namespace VeriTipleri {
    class TamsayýHesap {
        static void Main() {
            Console.Write ("Tamsayýlarla aritmetik (-+*/), atama (=), taþma (MaxValue+1), bitsel AND/VE/&, mantýksal true/false (>?, =?), önce/sonra artan/azalan (++i, i--), tamsayý bölüm ve kalan gibi hesaplamalar yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sabitlerle: 10 / 3 = " + 10 / 3);
            Console.WriteLine ("Sabitlerle: 10 % 3 = " + 10 % 3);
            int ts1 = 10, ts2 = 3, ts3 = 2023;
            Console.WriteLine ("Deðiþkenlerle: ts1 / ts2 = " + ts1 / ts2);
            Console.WriteLine ("Deðiþkenlerle: ts1 % ts2 = " + ts1 % ts2);

            Console.WriteLine ("\na={0} b={1} c={2}", ts1, ts2, ts3);
            ts1 = ts2 = ts3;
            Console.WriteLine ("'a=b=c' atama sonrasý: a={0} b={1} c={2}", ts1, ts2, ts3);

            ts1 = int.MaxValue;
            ts1 +=1;
            Console.WriteLine ("\nint.MaxValue ({0}) + 1 = {1} ==>Taþma", int.MaxValue, ts1);

            Gir1: Console.Write ("\nBir tamsayý gir: ");
            try {ts1 = Convert.ToInt32 (Console.ReadLine());}catch {Console.WriteLine ("HATA..."); goto Gir1;}
            Console.WriteLine ("Bitsel: {0} & 10 = {1}", ts1, (ts1 & 10)); //d10=b1010

            Console.WriteLine ("\nGirdiðiniz: {0} < 10? {1}", ts1, (ts1 < 10));
            Console.WriteLine ("Girdiðiniz: {0} >= 0 ve <= 100? {1}", ts1, ((0 <= ts1) && (ts1 <= 100)));

            Console.WriteLine ("\nint ({0}): {1}++, {2}++, {3}, {4}--, {5}--, {6}", ts2, ts2++, ts2++, ts2, ts2--, ts2--, ts2);
            Console.WriteLine ("int ({0}): ++{1}, ++{2}, {3}, --{4}, --{5}, {6}", ts3, ++ts3, ++ts3, ts3, --ts3, --ts3, ts3);

            var r=new Random();
            ts1=r.Next (1000, 10000);
            ts2=r.Next (1, 1000);
            int kalan;
            ts3 = ts1 / ts2;
            kalan = ts1 % ts2;
            Console.WriteLine ("\n{0} / {1} = {2} ve kalan = {3}", ts1, ts2, ts3, kalan);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}