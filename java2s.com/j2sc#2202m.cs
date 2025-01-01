// j2sc#2202m.cs: Skip, Take, SkipWhile, TakeWhile kýyaslarý örneði.

using System;
using System.Collections.Generic; //IEnumerable<> için
using System.Linq; //Skip için
namespace LinqMetot {
    class Skip_SWhile {
        static void Main() {
            Console.Write ("'dizi.Skip(n)' ilk n elemaný atlayýp sondakileri alýr. 'dizi.SkipWhile(n=>n{þart})' þartý saðlayan ilk elemandan sonrakileri alýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sayýsal yýllarýn Skip'le sabit adetli, SkipWhile'la þartlý sonda kalanlar:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[50];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("-->Tüm rasgele {0} adet yýllar: ", yýllar.Length);
            foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            ts=r.Next(1,yýllar.Length);
            IEnumerable<int> atla1 = yýllar.Skip (ts);
            Console.Write ("-->Ýlk {0} eleman atlanarak sonda {1} adet kalanlar: ", ts, atla1.Count());
            foreach(int yýl in atla1) Console.Write (yýl+" "); Console.WriteLine();
            atla1 = yýllar.SkipWhile (y=>y.CompareTo (1938) != 0);
            Console.Write ("-->Ýlk {0} raslandýktan sonraki {1} adet kalanlar: ", 1938, atla1.Count());
            foreach(int yýl in atla1) Console.Write (yýl+" "); Console.WriteLine();
            var al1 = yýllar.Take (10);
            atla1 = yýllar.Skip (40);
            Console.Write ("-->Ýlk {0}'u almak: ", 10);
            foreach(int yýl in al1) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->Son {0}'u almak: ", yýllar.Length-40);
            foreach(int yýl in atla1) Console.Write (yýl+" "); Console.WriteLine();
            al1 = yýllar.TakeWhile ((n, endx) => n-yýllar [ts] >= endx);
            atla1 = yýllar.SkipWhile ((n, endx) => n-yýllar [ts] >= endx);
            Console.Write ("-->Ýlk n-yýllar[{0}] >= endx almak: ", ts);
            foreach(int yýl in al1) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->Son n-yýllar[{0}] >= endx almak: ", ts);
            foreach(int yýl in atla1) Console.Write (yýl+" "); Console.WriteLine();
            al1 = yýllar.TakeWhile (n => n % 1881 != 0);
            atla1 = yýllar.SkipWhile (n => n % 1881 != 0);
            Console.Write ("-->Ýlk n%{0}!=0 almak: ", 1881);
            foreach(int yýl in al1) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->Son n%{0}!=0 almak: ", 1881);
            foreach(int yýl in atla1) Console.Write (yýl+" "); Console.WriteLine();

            Console.WriteLine ("\nPeygamberlere Take-While ve Skip-While uygulamak:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.Write ("-->Tüm {0} peygamberler: ", peygamberler.Length);
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<string> al2 = peygamberler.TakeWhile (p => !p.StartsWith ("S"));
            IEnumerable<string> atla2 = peygamberler.SkipWhile (p => !p.StartsWith ("S"));
            Console.Write ("-->Ýlk pey[0]!='{0}' almak: ", "S");
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son pey[0]!='{0}' almak: ", "S");
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();
            al2 = peygamberler.TakeWhile ((p, x) => p.Length != 5 && i > 2);
            atla2 = peygamberler.SkipWhile ((p, x) => p.Length != 5 && i > 2);
            Console.Write ("-->Ýlk pey.Length!=5 && i>2 almak: ", "S");
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son pey.Length!=5 && i>2 almak: ", "S");
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();
            ts=r.Next(1,peygamberler.Length);
            al2 = peygamberler.Take (ts);
            atla2 = peygamberler.Skip (ts);
            Console.Write ("-->Ýlk peygamberler.Take({0}) almak: ", ts);
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son peygamberler.Skip({0}) almak: ", ts);
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}