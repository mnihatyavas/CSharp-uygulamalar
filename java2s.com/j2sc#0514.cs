// j2sc#0514.cs: Sýk kullanýlan kçþ-tuþlarý (", n, t, \) örneði.

using System;
namespace Dizgeler {
    class KaçýþTuþlarý {
        static void Main() {
            Console.Write ("Esc/Kçþ tuþlarý: ', \", \\, \\a, \\n, \\r, \\t. Dizge baþýndaki @, icap ettiðinde tek \\ yerine geçer.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli kçþ-tuþ uygulamalarý:");
            string dizge1 = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#0514.cs"; Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            dizge1 = "C:\\Users\\nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\j2sc#0514.exe"; Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            dizge1 = "Nihat herkese, \"Günaydýn, nasýlsýnýz?\" dedi."; Console.WriteLine ("dizge1 = '{0}'", dizge1);
            Console.WriteLine ("Selam\tOrdaki\tHerkese");
            Console.WriteLine ("Herkes \"Merhaba Dünya!\" sloganýný seviyor.");
            Console.WriteLine ("C:\\Uygulamalarým\\exe\\debug");
            Console.Write ("\r\tMaalesef herþey bitti.\n\r");
            dizge1 = "Bu hayata nasýl baþladýðýmýn hikayesidir."; Console.WriteLine (dizge1);
            dizge1 = dizge1.ToUpper(); Console.WriteLine (dizge1);
            Console.WriteLine ("\t\t\'*\"...\"*\'");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}