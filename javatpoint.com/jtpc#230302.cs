// jtpc#230302.cs: Adl� ve se�enekli arg�manlarla metod �a��rma �rne�i.

using System;
namespace Yeni�zellikler {
    class Adl�Se�enekliArg�man {
        static string Tam�smiAl (string ad, string soyad) {return ad + " " + soyad;}
        static void topla (int a, int b = 12, int c = 3) {Console.WriteLine (a+b+c);} //�lk de�erin aktar�lmas� zorunlu, di�erleri se�enekli
        static void Main() {
            Console.Write ("Adl� arg�manlara de�er aktarma adlar�n geli�ig�zel s�ralamas�yla yap�labilir. Se�enekli arg�man ilkde�erli olup, de�er aktar�lmad���nda bu varsay�lan de�er al�n�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string isim1 = Tam�smiAl ("M.Nihat", "Yava�"); //Ads�z arg�man de�erleri ge�irme
            string isim2 = Tam�smiAl (ad: "M.Nihat", soyad: "Yava�"); //Ads�z arg�man de�erleri ge�irme
            string isim3 = Tam�smiAl (soyad:"Yava�", ad:"M.Nihat"); //Ads�z arg�man de�erlerini geli�ig�zel s�rada ge�irme
            Console.WriteLine ("Ads�z arg�man aktarmal� isim: " + isim1);
            Console.WriteLine ("Normal s�ral� adl� arg�man aktarmal� isim: " + isim2);
            Console.WriteLine ("Geli�ig�zel s�ral� adl� arg�man aktarmal� isim: {0}\n", isim3);

            //topla(); //�lk arg�man zorunlu�u derleme hatas� verdirir.
            topla (10); //Sadece ilk zorunlu de�er aktar�m�
            topla (10, 15); //�lk zorunlu ve ikinci se�enekli de�er aktar�m�
            topla (10, 15, 5); //�lk zorunlu ve ikinciyle ���nc� se�enekli de�erler aktar�m�

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}