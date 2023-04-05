// j2sc#0102a.cs: Genel bir XML belgeleme yorum elemanlar� �rne�i.

using System;
namespace DilTemelleri {
    // <summary>: �zet; program�n tek sat�rl�k �zetlenmesi</summary>
    // <remarks>: a��klama; program�n detayl� a��klamas�</remarks>
    class BelgelemeYorumlar�1 {
        // <summary>Bir �ye de�i�ken</summary>
        private string �ye_dizge;

        // <summary>Bir �zellik al</summary>
        // <remarks>�zellik koyman�n detaylar�</remarks>
        public string �yeDizgeAl {get {return �ye_dizge;} }

        // <summary>Bir metod �rne�i (�zellik koy)</summary>
        // <param name="val">Parametrik dizge de�eri �ye de�i�kene konulacak</param>
        // <returns>Atanan dizge uzunlu�u geri d�nd�r�lecek</returns>
        public int �yeDizgeKoy (string de�er) {�ye_dizge = de�er; return de�er.Length;}

        // <summary>Program�n ilkba�latma Main() metodu</summary>
        // <param name="args">Komut sat�r arg�manlar� (girilirse)</param>
        public static void Main (string[] arg�manlar) {
            Console.Write ("XML d�k�manlama yorum elemanlar� genel bir C# program�n aduzam, s�n�f, �ye de�i�ken, �zellik al ve �zellik koy metodlar�, program�n ba�lama noktas� olan Main() metod katagorileriyle genel anlamda �ablonlanm��t�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ki�i = new BelgelemeYorumlar�1();
            ki�i.�yeDizgeKoy ("M.Nihat Yava�"); Console.WriteLine ("Konulan �ye dizge de�erinin al�n���: {0}", ki�i.�yeDizgeAl);
            ki�i.�yeDizgeKoy ("M.Nedim Yava�"); Console.WriteLine ("Konulan �ye dizge de�erinin al�n���: {0}", ki�i.�yeDizgeAl);
            ki�i.�yeDizgeKoy ("Zafer N.Candan"); Console.WriteLine ("Konulan �ye dizge de�erinin al�n���: {0}", ki�i.�yeDizgeAl);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}