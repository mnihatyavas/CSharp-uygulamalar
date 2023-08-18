// j2sc#0506.cs: Büyük/Küçük-harf ve baþlýk-illharfý metotlarý örneði.

using System;
using System.Globalization;
namespace Dizgeler {
    class DizgeselEkleme {
        static void Main() {
            Console.Write ("ToLower küçükharfe, ToUpper büyükharfe, ToTitleCase her kelime ilkini büyükharfe çevirir. Büyük/küçük-harf ASCII kodlarý farklýlýðýndan dolayý Compare eþit=0 vermez. Türkçe, Amerikanca kültürel alfabe farklarý mevcuttur (Örn. Ýi, Iý, Ii), ayrýca ascii kod farký vardýr (Örn.Ý=49 veya 130 hex).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgedeki küçükleri büyük-harfe ve büyükleri küçüðe çevirme:");
            string dizge1 = "ABCDEFGHIJKLM-nopqrstuvwxyz1234567890";
            Console.WriteLine ("Büyükharfli: " +  dizge1.ToUpper());
            Console.WriteLine ("Küçükharfli: " +  dizge1.ToLower());

            Console.WriteLine ("\nKüçük ile büyükharf ASCII kod farklýlýðý:");
            Console.WriteLine ("ASCII a = {0} > A = {1}", (int)'a', (int)'A');
            dizge1 = "Bu bir 'a' harfidir.";
            string dizge2 = "Bu bir 'A' harfidir.";
            Console.WriteLine ("Küçük/büyük harf duyarlý: \"{0}\" = \"{1}\"? {2}", dizge1, dizge2, String.Compare (dizge1, dizge2));
            Console.WriteLine ("Küçük/büyük harf duyarsýz: \"{0}\" = \"{1}\"? {2}", dizge1, dizge2, String.Compare (dizge1, dizge2, true));

            dizge1 = "es-sabah-Il þerifleriniz hayrola!";
            Console.WriteLine ("\n'en-US' kültürel farklýlýkla orijinal dizge: \"{0}\"", dizge1);
            TextInfo TI = new CultureInfo ("en-US", false).TextInfo;
            Console.WriteLine ("Küçükharfli: {0}", TI.ToLower (dizge1));
            Console.WriteLine ("Büyükharfli: {0}", TI.ToUpper (dizge1));
            Console.WriteLine ("Baþlýkharfli: {0}", TI.ToTitleCase (dizge1));
            Console.WriteLine ("\n'tr-TR' kültürel farklýlýkla orijinal dizge: \"{0}\"", dizge1);
            TI = new CultureInfo ("tr-TR", false).TextInfo;
            Console.WriteLine ("Küçükharfli: {0}", TI.ToLower (dizge1));
            Console.WriteLine ("Büyükharfli: {0}", TI.ToUpper (dizge1));
            Console.WriteLine ("Baþlýkharfli: {0}", TI.ToTitleCase (dizge1));

            Console.WriteLine ("\n'en-US' ve 'tr-TR' ayný dizgenin farklý HEX kodlarý:");
            String dizge3;
            dizge2 = dizge1.ToUpper (new CultureInfo ("en-US", false));
            dizge3 = dizge1.ToUpper (new CultureInfo ("tr-TR", false));
            Console.WriteLine ("'en-US' dizge = 'tr-TR' dizge? {0}", String.CompareOrdinal (dizge2, dizge3));
            Console.WriteLine ("==>Orijinal dizge = \"{0}\": ", dizge1);
            foreach (ushort u in dizge1) Console.Write ("{0:x2} ", u); Console.WriteLine();
            Console.WriteLine ("==>Büyükharfli 'en-US' dizge = \"{0}\": ", dizge2);
            foreach (ushort u in dizge2) Console.Write ("{0:x2} ", u); Console.WriteLine();
            Console.WriteLine ("==>Büyükharfli 'tr-TR' dizge = \"{0}\": ", dizge3);
            foreach (ushort u in dizge3) Console.Write ("{0:x2} ", u); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}