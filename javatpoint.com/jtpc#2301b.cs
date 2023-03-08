// jtpc#2301b.cs: Dizi ve koleksiyon elemanlarýný yalýn ve yield-foreach'le tarama örneði.

using System;
using System.Collections.Generic;
namespace YeniÖzellikler {
    class Tarayýcýlar {
        public static IEnumerable<string> DiziyiAl() {
            var r = new Random();
            int[] dizi = new int[] {r.Next(1,10000), r.Next(1,10000), r.Next(1,10000), r.Next(1,10000), r.Next(1,10000)};
            foreach (var eleman in dizi) {yield return eleman.ToString();}
        }
        public static IEnumerable<string> ListeyiAl() {
            var liste = new List<string>();
            liste.Add ("Bayram Küçükbay"); liste.Add ("Adil Özbay"); liste.Add ("Hamza Candan"); liste.Add ("Sefer Göktürk");
            foreach (var eleman in liste) {yield return eleman;}
        }
        static void Main() {
            Console.Write ("Tarayýcý 'foreach' döngüsüyle dizi veya koleksiyon elemanlarýný, 'yield return eleman' ifadesiyle sonlanýncaya deðin alýr; yarýda kesmek için 'yield brake' kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r = new Random();
            int[] dizi = new int [20];
            for (int i=0; i < dizi.Length; i++) dizi [i] = r.Next (1, 10000);
            Console.WriteLine ("Rasgele 20 dizi elemanýný foreach-eleman'la tarama:");
            foreach (var eleman in dizi) Console.Write (eleman + ", ");

            Console.WriteLine ("\n\nRasgele 5 dizi elemanýný foreach-(yield return eleman)'la tarama:");
            IEnumerable<string> elemanlar = DiziyiAl();
            foreach (var eleman in elemanlar) {Console.Write (eleman + ", ");}

            var liste = new List<string>();
            liste.Add ("Nur Küçükbay"); liste.Add ("Yücel Küçükbay"); liste.Add ("Serap Küçükbay");
            liste.Add ("Sema Özbay"); liste.Add ("Selda Özbay"); liste.Add ("Fatih Özbay");
            liste.Add ("Canan Candan"); liste.Add ("Zafer N.Candan"); liste.Add ("Belkýs Candan");
            liste.Add ("Atilla Göktürk"); liste.Add ("Hilal Göktürk");
            Console.WriteLine ("\n\nListe koleksiyon elemanlarýný foreach-eleman'la tarama:");
            foreach (var eleman in liste) Console.Write (eleman + ", ");

            Console.WriteLine ("\nListe koleksiyon elemanlarýný foreach-(yield return eleman)'la tarama:");
            elemanlar = ListeyiAl();
            foreach (var eleman in elemanlar) {Console.Write (eleman + ", ");}

            Console.Write ("\n\nTuþ...");Console.ReadKey();
        }
    }
}