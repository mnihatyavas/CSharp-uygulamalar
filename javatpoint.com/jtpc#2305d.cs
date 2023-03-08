// jtpc#2305d.cs: Oto ilkde�erlemeyle �zelli�e kurucusuz de�er atama �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci1 {public string �sim {get; set;} /*= "Mahmut Nihat Yava�";*/}
    class ��renci2 {public string �sim {get; private set;} public void adKoy(){�sim="Mehmet Nihat Yava�";}}
    class Oto�lkde�erleme {
        public string �sim {get; set;}
        Oto�lkde�erleme() {�sim = "M.Nihat Yava�";}
        static void Main() {
            Console.Write ("�nceden s�n�f �zellik ilkde�erleme ayn� adl� kurucu metodla yap�l�rken, oto ilkde�erleme kurucu gerektirmez, hatta private get-set'le harici m�dahele de s�n�rlanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new Oto�lkde�erleme(); Console.WriteLine ("Kuruculu ilkde�erlemeli isim: [{0}]", nesne1.�sim);
            var nesne2 = new ��renci1(); nesne2.�sim = "Mahmut Nihat Yava�"; Console.WriteLine ("Kurucusuz atamal� isim: [{0}]", nesne2.�sim);
            var nesne3 = new ��renci2(); /*nesne3.�sim = "Mehmet Nihat Yava�";*/ nesne3.adKoy(); Console.WriteLine ("Kurucusuz ilkde�erlemeli isim: [{0}]", nesne3.�sim);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}