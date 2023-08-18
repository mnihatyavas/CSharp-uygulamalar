// j2sc#0506.cs: B�y�k/K���k-harf ve ba�l�k-illharf� metotlar� �rne�i.

using System;
using System.Globalization;
namespace Dizgeler {
    class DizgeselEkleme {
        static void Main() {
            Console.Write ("ToLower k���kharfe, ToUpper b�y�kharfe, ToTitleCase her kelime ilkini b�y�kharfe �evirir. B�y�k/k���k-harf ASCII kodlar� farkl�l���ndan dolay� Compare e�it=0 vermez. T�rk�e, Amerikanca k�lt�rel alfabe farklar� mevcuttur (�rn. �i, I�, Ii), ayr�ca ascii kod fark� vard�r (�rn.�=49 veya 130 hex).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgedeki k���kleri b�y�k-harfe ve b�y�kleri k����e �evirme:");
            string dizge1 = "ABCDEFGHIJKLM-nopqrstuvwxyz1234567890";
            Console.WriteLine ("B�y�kharfli: " +  dizge1.ToUpper());
            Console.WriteLine ("K���kharfli: " +  dizge1.ToLower());

            Console.WriteLine ("\nK���k ile b�y�kharf ASCII kod farkl�l���:");
            Console.WriteLine ("ASCII a = {0} > A = {1}", (int)'a', (int)'A');
            dizge1 = "Bu bir 'a' harfidir.";
            string dizge2 = "Bu bir 'A' harfidir.";
            Console.WriteLine ("K���k/b�y�k harf duyarl�: \"{0}\" = \"{1}\"? {2}", dizge1, dizge2, String.Compare (dizge1, dizge2));
            Console.WriteLine ("K���k/b�y�k harf duyars�z: \"{0}\" = \"{1}\"? {2}", dizge1, dizge2, String.Compare (dizge1, dizge2, true));

            dizge1 = "es-sabah-Il �erifleriniz hayrola!";
            Console.WriteLine ("\n'en-US' k�lt�rel farkl�l�kla orijinal dizge: \"{0}\"", dizge1);
            TextInfo TI = new CultureInfo ("en-US", false).TextInfo;
            Console.WriteLine ("K���kharfli: {0}", TI.ToLower (dizge1));
            Console.WriteLine ("B�y�kharfli: {0}", TI.ToUpper (dizge1));
            Console.WriteLine ("Ba�l�kharfli: {0}", TI.ToTitleCase (dizge1));
            Console.WriteLine ("\n'tr-TR' k�lt�rel farkl�l�kla orijinal dizge: \"{0}\"", dizge1);
            TI = new CultureInfo ("tr-TR", false).TextInfo;
            Console.WriteLine ("K���kharfli: {0}", TI.ToLower (dizge1));
            Console.WriteLine ("B�y�kharfli: {0}", TI.ToUpper (dizge1));
            Console.WriteLine ("Ba�l�kharfli: {0}", TI.ToTitleCase (dizge1));

            Console.WriteLine ("\n'en-US' ve 'tr-TR' ayn� dizgenin farkl� HEX kodlar�:");
            String dizge3;
            dizge2 = dizge1.ToUpper (new CultureInfo ("en-US", false));
            dizge3 = dizge1.ToUpper (new CultureInfo ("tr-TR", false));
            Console.WriteLine ("'en-US' dizge = 'tr-TR' dizge? {0}", String.CompareOrdinal (dizge2, dizge3));
            Console.WriteLine ("==>Orijinal dizge = \"{0}\": ", dizge1);
            foreach (ushort u in dizge1) Console.Write ("{0:x2} ", u); Console.WriteLine();
            Console.WriteLine ("==>B�y�kharfli 'en-US' dizge = \"{0}\": ", dizge2);
            foreach (ushort u in dizge2) Console.Write ("{0:x2} ", u); Console.WriteLine();
            Console.WriteLine ("==>B�y�kharfli 'tr-TR' dizge = \"{0}\": ", dizge3);
            foreach (ushort u in dizge3) Console.Write ("{0:x2} ", u); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}