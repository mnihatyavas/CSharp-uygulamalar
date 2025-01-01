// j2sc#2202m.cs: Skip, Take, SkipWhile, TakeWhile k�yaslar� �rne�i.

using System;
using System.Collections.Generic; //IEnumerable<> i�in
using System.Linq; //Skip i�in
namespace LinqMetot {
    class Skip_SWhile {
        static void Main() {
            Console.Write ("'dizi.Skip(n)' ilk n eleman� atlay�p sondakileri al�r. 'dizi.SkipWhile(n=>n{�art})' �art� sa�layan ilk elemandan sonrakileri al�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Say�sal y�llar�n Skip'le sabit adetli, SkipWhile'la �artl� sonda kalanlar:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[50];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("-->T�m rasgele {0} adet y�llar: ", y�llar.Length);
            foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            ts=r.Next(1,y�llar.Length);
            IEnumerable<int> atla1 = y�llar.Skip (ts);
            Console.Write ("-->�lk {0} eleman atlanarak sonda {1} adet kalanlar: ", ts, atla1.Count());
            foreach(int y�l in atla1) Console.Write (y�l+" "); Console.WriteLine();
            atla1 = y�llar.SkipWhile (y=>y.CompareTo (1938) != 0);
            Console.Write ("-->�lk {0} rasland�ktan sonraki {1} adet kalanlar: ", 1938, atla1.Count());
            foreach(int y�l in atla1) Console.Write (y�l+" "); Console.WriteLine();
            var al1 = y�llar.Take (10);
            atla1 = y�llar.Skip (40);
            Console.Write ("-->�lk {0}'u almak: ", 10);
            foreach(int y�l in al1) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->Son {0}'u almak: ", y�llar.Length-40);
            foreach(int y�l in atla1) Console.Write (y�l+" "); Console.WriteLine();
            al1 = y�llar.TakeWhile ((n, endx) => n-y�llar [ts] >= endx);
            atla1 = y�llar.SkipWhile ((n, endx) => n-y�llar [ts] >= endx);
            Console.Write ("-->�lk n-y�llar[{0}] >= endx almak: ", ts);
            foreach(int y�l in al1) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->Son n-y�llar[{0}] >= endx almak: ", ts);
            foreach(int y�l in atla1) Console.Write (y�l+" "); Console.WriteLine();
            al1 = y�llar.TakeWhile (n => n % 1881 != 0);
            atla1 = y�llar.SkipWhile (n => n % 1881 != 0);
            Console.Write ("-->�lk n%{0}!=0 almak: ", 1881);
            foreach(int y�l in al1) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->Son n%{0}!=0 almak: ", 1881);
            foreach(int y�l in atla1) Console.Write (y�l+" "); Console.WriteLine();

            Console.WriteLine ("\nPeygamberlere Take-While ve Skip-While uygulamak:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.Write ("-->T�m {0} peygamberler: ", peygamberler.Length);
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<string> al2 = peygamberler.TakeWhile (p => !p.StartsWith ("S"));
            IEnumerable<string> atla2 = peygamberler.SkipWhile (p => !p.StartsWith ("S"));
            Console.Write ("-->�lk pey[0]!='{0}' almak: ", "S");
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son pey[0]!='{0}' almak: ", "S");
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();
            al2 = peygamberler.TakeWhile ((p, x) => p.Length != 5 && i > 2);
            atla2 = peygamberler.SkipWhile ((p, x) => p.Length != 5 && i > 2);
            Console.Write ("-->�lk pey.Length!=5 && i>2 almak: ", "S");
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son pey.Length!=5 && i>2 almak: ", "S");
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();
            ts=r.Next(1,peygamberler.Length);
            al2 = peygamberler.Take (ts);
            atla2 = peygamberler.Skip (ts);
            Console.Write ("-->�lk peygamberler.Take({0}) almak: ", ts);
            foreach(var pey in al2) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->Son peygamberler.Skip({0}) almak: ", ts);
            foreach(var pey in atla2) Console.Write (pey+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}