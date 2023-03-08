// jtpc#2301b.cs: Dizi ve koleksiyon elemanlar�n� yal�n ve yield-foreach'le tarama �rne�i.

using System;
using System.Collections.Generic;
namespace Yeni�zellikler {
    class Taray�c�lar {
        public static IEnumerable<string> DiziyiAl() {
            var r = new Random();
            int[] dizi = new int[] {r.Next(1,10000), r.Next(1,10000), r.Next(1,10000), r.Next(1,10000), r.Next(1,10000)};
            foreach (var eleman in dizi) {yield return eleman.ToString();}
        }
        public static IEnumerable<string> ListeyiAl() {
            var liste = new List<string>();
            liste.Add ("Bayram K���kbay"); liste.Add ("Adil �zbay"); liste.Add ("Hamza Candan"); liste.Add ("Sefer G�kt�rk");
            foreach (var eleman in liste) {yield return eleman;}
        }
        static void Main() {
            Console.Write ("Taray�c� 'foreach' d�ng�s�yle dizi veya koleksiyon elemanlar�n�, 'yield return eleman' ifadesiyle sonlan�ncaya de�in al�r; yar�da kesmek i�in 'yield brake' kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r = new Random();
            int[] dizi = new int [20];
            for (int i=0; i < dizi.Length; i++) dizi [i] = r.Next (1, 10000);
            Console.WriteLine ("Rasgele 20 dizi eleman�n� foreach-eleman'la tarama:");
            foreach (var eleman in dizi) Console.Write (eleman + ", ");

            Console.WriteLine ("\n\nRasgele 5 dizi eleman�n� foreach-(yield return eleman)'la tarama:");
            IEnumerable<string> elemanlar = DiziyiAl();
            foreach (var eleman in elemanlar) {Console.Write (eleman + ", ");}

            var liste = new List<string>();
            liste.Add ("Nur K���kbay"); liste.Add ("Y�cel K���kbay"); liste.Add ("Serap K���kbay");
            liste.Add ("Sema �zbay"); liste.Add ("Selda �zbay"); liste.Add ("Fatih �zbay");
            liste.Add ("Canan Candan"); liste.Add ("Zafer N.Candan"); liste.Add ("Belk�s Candan");
            liste.Add ("Atilla G�kt�rk"); liste.Add ("Hilal G�kt�rk");
            Console.WriteLine ("\n\nListe koleksiyon elemanlar�n� foreach-eleman'la tarama:");
            foreach (var eleman in liste) Console.Write (eleman + ", ");

            Console.WriteLine ("\nListe koleksiyon elemanlar�n� foreach-(yield return eleman)'la tarama:");
            elemanlar = ListeyiAl();
            foreach (var eleman in elemanlar) {Console.Write (eleman + ", ");}

            Console.Write ("\n\nTu�...");Console.ReadKey();
        }
    }
}