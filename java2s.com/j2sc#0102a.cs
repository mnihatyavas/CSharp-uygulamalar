// j2sc#0102a.cs: Genel bir XML belgeleme yorum elemanlarý örneði.

using System;
namespace DilTemelleri {
    // <summary>: özet; programýn tek satýrlýk özetlenmesi</summary>
    // <remarks>: açýklama; programýn detaylý açýklamasý</remarks>
    class BelgelemeYorumlarý1 {
        // <summary>Bir üye deðiþken</summary>
        private string üye_dizge;

        // <summary>Bir özellik al</summary>
        // <remarks>Özellik koymanýn detaylarý</remarks>
        public string ÜyeDizgeAl {get {return üye_dizge;} }

        // <summary>Bir metod örneði (özellik koy)</summary>
        // <param name="val">Parametrik dizge deðeri üye deðiþkene konulacak</param>
        // <returns>Atanan dizge uzunluðu geri döndürülecek</returns>
        public int ÜyeDizgeKoy (string deðer) {üye_dizge = deðer; return deðer.Length;}

        // <summary>Programýn ilkbaþlatma Main() metodu</summary>
        // <param name="args">Komut satýr argümanlarý (girilirse)</param>
        public static void Main (string[] argümanlar) {
            Console.Write ("XML dökümanlama yorum elemanlarý genel bir C# programýn aduzam, sýnýf, üye deðiþken, özellik al ve özellik koy metodlarý, programýn baþlama noktasý olan Main() metod katagorileriyle genel anlamda þablonlanmýþtýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var kiþi = new BelgelemeYorumlarý1();
            kiþi.ÜyeDizgeKoy ("M.Nihat Yavaþ"); Console.WriteLine ("Konulan üye dizge deðerinin alýnýþý: {0}", kiþi.ÜyeDizgeAl);
            kiþi.ÜyeDizgeKoy ("M.Nedim Yavaþ"); Console.WriteLine ("Konulan üye dizge deðerinin alýnýþý: {0}", kiþi.ÜyeDizgeAl);
            kiþi.ÜyeDizgeKoy ("Zafer N.Candan"); Console.WriteLine ("Konulan üye dizge deðerinin alýnýþý: {0}", kiþi.ÜyeDizgeAl);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}