// j2sc#0207.cs: Tamsay�larla aritmetik, mant�ksal, bitsel, artan/azalan ve b�l�m hesaplamalar� �rne�i.

using System;
namespace VeriTipleri {
    class Tamsay�Hesap {
        static void Main() {
            Console.Write ("Tamsay�larla aritmetik (-+*/), atama (=), ta�ma (MaxValue+1), bitsel AND/VE/&, mant�ksal true/false (>?, =?), �nce/sonra artan/azalan (++i, i--), tamsay� b�l�m ve kalan gibi hesaplamalar yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sabitlerle: 10 / 3 = " + 10 / 3);
            Console.WriteLine ("Sabitlerle: 10 % 3 = " + 10 % 3);
            int ts1 = 10, ts2 = 3, ts3 = 2023;
            Console.WriteLine ("De�i�kenlerle: ts1 / ts2 = " + ts1 / ts2);
            Console.WriteLine ("De�i�kenlerle: ts1 % ts2 = " + ts1 % ts2);

            Console.WriteLine ("\na={0} b={1} c={2}", ts1, ts2, ts3);
            ts1 = ts2 = ts3;
            Console.WriteLine ("'a=b=c' atama sonras�: a={0} b={1} c={2}", ts1, ts2, ts3);

            ts1 = int.MaxValue;
            ts1 +=1;
            Console.WriteLine ("\nint.MaxValue ({0}) + 1 = {1} ==>Ta�ma", int.MaxValue, ts1);

            Gir1: Console.Write ("\nBir tamsay� gir: ");
            try {ts1 = Convert.ToInt32 (Console.ReadLine());}catch {Console.WriteLine ("HATA..."); goto Gir1;}
            Console.WriteLine ("Bitsel: {0} & 10 = {1}", ts1, (ts1 & 10)); //d10=b1010

            Console.WriteLine ("\nGirdi�iniz: {0} < 10? {1}", ts1, (ts1 < 10));
            Console.WriteLine ("Girdi�iniz: {0} >= 0 ve <= 100? {1}", ts1, ((0 <= ts1) && (ts1 <= 100)));

            Console.WriteLine ("\nint ({0}): {1}++, {2}++, {3}, {4}--, {5}--, {6}", ts2, ts2++, ts2++, ts2, ts2--, ts2--, ts2);
            Console.WriteLine ("int ({0}): ++{1}, ++{2}, {3}, --{4}, --{5}, {6}", ts3, ++ts3, ++ts3, ts3, --ts3, --ts3, ts3);

            var r=new Random();
            ts1=r.Next (1000, 10000);
            ts2=r.Next (1, 1000);
            int kalan;
            ts3 = ts1 / ts2;
            kalan = ts1 % ts2;
            Console.WriteLine ("\n{0} / {1} = {2} ve kalan = {3}", ts1, ts2, ts3, kalan);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}