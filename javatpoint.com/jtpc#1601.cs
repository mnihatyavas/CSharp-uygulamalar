// jtpc#1601.cs: Genel <Tip>'li soysal s�n�f kurucu parametresini doldurma �rne�i.

using System;
//using System.Collections.Generic; //Tan�m gereksiz
namespace Soysallar {
    class SoysalS�n�f<Tip> {
        public SoysalS�n�f (Tip mesaj) {Console.WriteLine (mesaj);}
    }
    public class Soysal {
        static void Main() {
            Console.Write ("Soysal s�n�f ve metodla <Tip> genel tip tan�mlar, �a��rma esnas�ndaysa bu genel tipi istedi�imiz farkl� tipli veriyi derlemezamanl� arg�man aktar�m�nda kullanabiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            SoysalS�n�f<string> genelTiplemeDizge = new SoysalS�n�f<string> ("Bu, soysal s�n�f�n parametreli kurucusunun dizgesel mesaj�d�r.");
            SoysalS�n�f<int> genelTiplemeTamsay� = new SoysalS�n�f<int> (2023); //Tamsay� mesaj
            SoysalS�n�f<char> genelTiplemeKrk = new SoysalS�n�f<char> ('M');  //Krk mesaj
            SoysalS�n�f<bool> genelTipleme�kisel = new SoysalS�n�f<bool> (true);  //�kisel mesaj
            /*SoysalS�n�f<double>*/ var genelTiplemeDuble = new SoysalS�n�f<double> (2*3.141592653589793d + 3*2.718281828459045d);  //Duble mesaj
            new SoysalS�n�f<float> (2*3.141592653589793f + 3*2.718281828459045f);  //Kayan mesaj

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}