// jtpc#2203e.cs: Akt�el tarihin m�mk�n t�m bi�imlenmelerinin sunulmas� �rne�i.

using System;
namespace �e�itli {
    class TarihZamanE {
        static void Main() {
            Console.Write ("tarih.GetDateTimeFormats() metodu verili tarihin muhtemel t�m bi�imlemelerini dizile�tirir; istedi�imizi se�ebiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = DateTime.Now;
            int i=0;
            string[] bi�imDizisi = tarih.GetDateTimeFormats();
            Console.WriteLine ("Akt�el [{0}] tarihin m�mk�n t�m bi�imlenmeleri:\n---------------------------------------------------------------", tarih);
            foreach (string bi�im in bi�imDizisi) Console.WriteLine (i++ + ": [" + bi�im + "]");
            Console.WriteLine ("\n7.nci bi�imlenme: [{0}]", bi�imDizisi [7]);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}