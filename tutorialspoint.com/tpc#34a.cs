// tpc#34a.cs: Delegeli olayýn girilen kullanýcý adýný yakalayýp cevaplamasý örneði.

using System;
namespace Olaylar {
    public delegate string Delegem (string dizge);
    class OlayYakalama {
        event Delegem Olayým;
        public OlayYakalama() {this.Olayým = new Delegem (this.OlayYönetici);}
        public string OlayYönetici (string kullanýcýAdý) {return "Hoþgeldin Sayýn " + kullanýcýAdý + "! Nasýlsýn?..";}

        static void Main() {
            Console.Write ("Olaylar týklama, fare hareketi, tuþlama gibi hareketler yada sistem kesintileri/interrupt olup, bunlara kodlamalý olay yönetimi saðlanabilir. Olay yayýncý sýnýfýn delegesi, olaya abone ayný/farklý-sýnýfýn olay-yönetim metodunu çaðýrýr. \nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            OlayYakalama nesne = new OlayYakalama();
            string cevap = nesne.Olayým ("Songül"); Console.WriteLine (cevap);
            cevap = nesne.Olayým ("Atilla"); Console.WriteLine (cevap);
            cevap = nesne.Olayým ("Hilal"); Console.WriteLine (cevap);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}