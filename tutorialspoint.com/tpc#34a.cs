// tpc#34a.cs: Delegeli olay�n girilen kullan�c� ad�n� yakalay�p cevaplamas� �rne�i.

using System;
namespace Olaylar {
    public delegate string Delegem (string dizge);
    class OlayYakalama {
        event Delegem Olay�m;
        public OlayYakalama() {this.Olay�m = new Delegem (this.OlayY�netici);}
        public string OlayY�netici (string kullan�c�Ad�) {return "Ho�geldin Say�n " + kullan�c�Ad� + "! Nas�ls�n?..";}

        static void Main() {
            Console.Write ("Olaylar t�klama, fare hareketi, tu�lama gibi hareketler yada sistem kesintileri/interrupt olup, bunlara kodlamal� olay y�netimi sa�lanabilir. Olay yay�nc� s�n�f�n delegesi, olaya abone ayn�/farkl�-s�n�f�n olay-y�netim metodunu �a��r�r. \nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            OlayYakalama nesne = new OlayYakalama();
            string cevap = nesne.Olay�m ("Song�l"); Console.WriteLine (cevap);
            cevap = nesne.Olay�m ("Atilla"); Console.WriteLine (cevap);
            cevap = nesne.Olay�m ("Hilal"); Console.WriteLine (cevap);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}