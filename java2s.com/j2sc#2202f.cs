// j2sc#2202f.cs: Aggregate ile kümülatif topla-çýkar-çarp-böl, adlarý ekle-tersle örneði.

using System;
using System.Linq;
using System.Collections.Generic; //IEnumerable<> için
namespace LinqMetot {
    class Aggregate {
        private static string Tersten (string dizge) {
            List<string> adlar = new List<string>(dizge.Split (' ').ToList());
            return adlar.Aggregate ((a, b) => b + " " + a);            
        }
        static void Main() {
            Console.Write ("Aggregate toplam (Sum) gibi anlaþýlsa da, ikili lambda parametreyle her türlü ardýþýk iþlemi yapmakta. Burada a dizinin ilk elemaný, b de ikincisi olup, toplar, çýkarýr, çarpar, böler vb. Sonrasýnda a ilk iþlem sonucu, b de dizinin 3.elemanýdýr... böylece dizi sonuna deðin iþlemi sürdürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("dizi.Aggregate, lambda iþlemini (çarp, topla, çýkar vb) ardýþýk yapar:");
            int i, ts=1, ts2=0;
            int[] tsDizi = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var çarp = tsDizi.Aggregate ((a, b) => a * b); //Tüm sayýlarý ilkine ardýþýk çarpar
            var topla = tsDizi.Aggregate ((a, b) => a + b); //Tüm sayýlarý ilkine ardýþýk toplar
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", 9, çarp, topla);
            for(i=0;i<tsDizi.Length;i++) {ts*=tsDizi [i]; ts2+=tsDizi [i];}
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", 9, ts, ts2);
            var r=new Random(); ts=r.Next(1,21);
            IEnumerable<int> seri = Enumerable.Range (1, ts);
            Console.Write  ("-->Range(1,{0}): ", ts);
            foreach (int n in seri) Console.Write  (n+" "); Console.WriteLine();
            çarp = seri.Aggregate ((x, y) => x * y);
            topla = seri.Aggregate ((x, y) => x + y);
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", ts, çarp, topla);
            for(i=0;i<tsDizi.Length;i++) {ts=r.Next(1,20); tsDizi [i]=ts;}
            Console.Write  ("-->tsDizi[{0}]: ", tsDizi.Length);
            foreach (int n in tsDizi) Console.Write  (n+" "); Console.WriteLine();
            çarp = tsDizi.Aggregate ((a, b) => a * b);
            topla = tsDizi.Aggregate ((a, b) => a + b);
            var çýkar = tsDizi.Aggregate ((a, b) => a - b); //Tüm sayýlarý ilkinden ardýþýk çýkarýr
            Console.WriteLine ("Çarp = {0}\tTopla = {1}\tÇýkar = {2}", çarp, topla, çýkar);
            double ds; double[] dsDizi=new double[10];
            for(i=0;i<dsDizi.Length;i++) {ds=r.Next(1,20)+r.Next(10,100)/100d; dsDizi [i]=ds;}
            Console.Write  ("-->dsDizi[{0}]: ", dsDizi.Length);
            foreach (var n in dsDizi) Console.Write  (n+" "); Console.WriteLine();
            var çarp2 = dsDizi.Aggregate ((a, b) => a * b);
            var böl = dsDizi.Aggregate ((a, b) => a / b);
            Console.WriteLine ("Çarp = {0}\tBöl = {1}", çarp2, böl);

            Console.WriteLine ("\nPeygamber adlarý, uzunluk, ekleme, ters sýralama:");
            string cümle="Adlarýn boy toplamý:";
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            foreach(string ad in peygamberler) cümle+=" "+ad;
            Console.WriteLine (cümle);
            Console.WriteLine ("-->Ýlk açýklama ve ara boþluk dahil {0} adet peygamber ad uzunluklarý toplamý = {1}", peygamberler.Length, peygamberler.Aggregate<string, string, int>("Adlarýn boy toplamý: ", (a, b) => a + " " + b, a => a.Length));
            Console.WriteLine (peygamberler.Aggregate<string, string, string>("-->Peygamberler: ", (a, b) => a + " " + b, a => a));
            Console.WriteLine ("-->Ara boþluksuz peygamber adlarýný ekler = " + peygamberler.Aggregate ((a, b) => a + b));
            Console.WriteLine ("-->Ara boþluksuz peygamber ad uzunluklarý toplamý = " + peygamberler.Aggregate<string, int>(0, (a, b) => a + b.Length));
            Console.WriteLine ("-->Altalta peygamber adlarý:\n" + peygamberler.Aggregate ((bu, sonraki) => bu + "\r\n" + sonraki));
            Console.WriteLine ("-->Peygamberler tersten: " + Tersten (peygamberler.Aggregate ((a, b) => a + " " + b)) );

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}