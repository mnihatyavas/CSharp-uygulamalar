// jtpc#230204.cs: K�smi s�n�flardaki k�smi metodla mesajlar yans�tma �rne�i.

using System;
namespace Yeni�zellikler {
    partial class K�smiMetod {partial void mesaj�G�ster (string mesaj);}
    partial class K�smiMetod {partial void mesaj�G�ster (String m) {Console.WriteLine (m);}
        static void Main() {
            Console.Write ("K�smi metod iki ayr� (ayn� adl�) k�smi s�n�fta tan�mlan�r; ilkinde sadece imzas�, ikincide b�t�n tan�mlamas� yap�l�r. D�nen 'void' olup eri�imi i�sel 'private'dir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            new K�smiMetod().mesaj�G�ster ("www.javatpoint.com'a ho�geldiniz.");
            new K�smiMetod().mesaj�G�ster ("K�smi metodla mesaj beyan�n� g�rmektesiniz.");
            new K�smiMetod().mesaj�G�ster ("Bir sonraki derste g�r��mek �zere, ho��akal�n.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}