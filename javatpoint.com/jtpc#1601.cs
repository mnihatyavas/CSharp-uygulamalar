// jtpc#1601.cs: Genel <Tip>'li soysal sýnýf kurucu parametresini doldurma örneði.

using System;
//using System.Collections.Generic; //Taným gereksiz
namespace Soysallar {
    class SoysalSýnýf<Tip> {
        public SoysalSýnýf (Tip mesaj) {Console.WriteLine (mesaj);}
    }
    public class Soysal {
        static void Main() {
            Console.Write ("Soysal sýnýf ve metodla <Tip> genel tip tanýmlar, çaðýrma esnasýndaysa bu genel tipi istediðimiz farklý tipli veriyi derlemezamanlý argüman aktarýmýnda kullanabiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            SoysalSýnýf<string> genelTiplemeDizge = new SoysalSýnýf<string> ("Bu, soysal sýnýfýn parametreli kurucusunun dizgesel mesajýdýr.");
            SoysalSýnýf<int> genelTiplemeTamsayý = new SoysalSýnýf<int> (2023); //Tamsayý mesaj
            SoysalSýnýf<char> genelTiplemeKrk = new SoysalSýnýf<char> ('M');  //Krk mesaj
            SoysalSýnýf<bool> genelTiplemeÝkisel = new SoysalSýnýf<bool> (true);  //Ýkisel mesaj
            /*SoysalSýnýf<double>*/ var genelTiplemeDuble = new SoysalSýnýf<double> (2*3.141592653589793d + 3*2.718281828459045d);  //Duble mesaj
            new SoysalSýnýf<float> (2*3.141592653589793f + 3*2.718281828459045f);  //Kayan mesaj

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}