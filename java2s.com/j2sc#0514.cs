// j2sc#0514.cs: S�k kullan�lan k��-tu�lar� (", n, t, \) �rne�i.

using System;
namespace Dizgeler {
    class Ka���Tu�lar� {
        static void Main() {
            Console.Write ("Esc/K�� tu�lar�: ', \", \\, \\a, \\n, \\r, \\t. Dizge ba��ndaki @, icap etti�inde tek \\ yerine ge�er.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli k��-tu� uygulamalar�:");
            string dizge1 = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#0514.cs"; Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            dizge1 = "C:\\Users\\nihet\\Desktop\\MyFiles\\3. Dersler\\c#\\j2sc#0514.exe"; Console.WriteLine ("dizge1 = \"{0}\"", dizge1);
            dizge1 = "Nihat herkese, \"G�nayd�n, nas�ls�n�z?\" dedi."; Console.WriteLine ("dizge1 = '{0}'", dizge1);
            Console.WriteLine ("Selam\tOrdaki\tHerkese");
            Console.WriteLine ("Herkes \"Merhaba D�nya!\" slogan�n� seviyor.");
            Console.WriteLine ("C:\\Uygulamalar�m\\exe\\debug");
            Console.Write ("\r\tMaalesef her�ey bitti.\n\r");
            dizge1 = "Bu hayata nas�l ba�lad���m�n hikayesidir."; Console.WriteLine (dizge1);
            dizge1 = dizge1.ToUpper(); Console.WriteLine (dizge1);
            Console.WriteLine ("\t\t\'*\"...\"*\'");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}