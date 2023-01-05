// tpc#33c.cs: Ekrana ve diskdosyas�na yazan metodlar�n delegelendirilmesi �rne�i.

using System;
using System.IO;
namespace Delegeler {
    class EkranaDiske {
        static FileStream da; //DosyaAk���
        static StreamWriter ay; // Ak��Yaz�c�
        public delegate void dizgeyiYaz (string d); // Delege beyan�
        public static void ekranaYaz (string d) {Console.WriteLine ("Mesaj: [{0}]", d);}
        public static void diskeYaz (string d) {
            da = new FileStream (
                "mny1.txt",
                FileMode.Append, FileAccess.Write);
                ay = new StreamWriter (da);
                ay.WriteLine (d);
                ay.Flush(); // ak�� tamponu bo�alt�l�r
                ay.Close(); // Ak��lar kapat�l�r
                da.Close();
        }
        public static void dizgeyiG�nder(dizgeyiYaz yaz) { // Parametrik delegeye dizge arg�man� g�nderir
            yaz ("Merhaba C# d�nyas�!");
            yaz ("Parametrik delegeyle arg�mansal dizge yazd�r�lmaktad�r.");
            yaz ("T�m �ok-sat�rl� mesajlar bu y�ntemle yazd�r�labilir...");
        }
        static void Main() {
            Console.Write ("Ekrana ve disk dosyas�na yazan metodlar�, gerid�n�� tipsiz (void) delege tiplemeleriyle kullanma.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            dizgeyiYaz dy1 = new dizgeyiYaz (ekranaYaz);
            dizgeyiYaz dy2 = new dizgeyiYaz (diskeYaz);
            dizgeyiG�nder (dy1);
            dizgeyiG�nder (dy2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}