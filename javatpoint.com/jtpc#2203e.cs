// jtpc#2203e.cs: Aktüel tarihin mümkün tüm biçimlenmelerinin sunulmasý örneði.

using System;
namespace Çeþitli {
    class TarihZamanE {
        static void Main() {
            Console.Write ("tarih.GetDateTimeFormats() metodu verili tarihin muhtemel tüm biçimlemelerini dizileþtirir; istediðimizi seçebiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = DateTime.Now;
            int i=0;
            string[] biçimDizisi = tarih.GetDateTimeFormats();
            Console.WriteLine ("Aktüel [{0}] tarihin mümkün tüm biçimlenmeleri:\n---------------------------------------------------------------", tarih);
            foreach (string biçim in biçimDizisi) Console.WriteLine (i++ + ": [" + biçim + "]");
            Console.WriteLine ("\n7.nci biçimlenme: [{0}]", biçimDizisi [7]);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}