// jtpc#0206.cs: Veri tipleri, gruplama ve kapsamlarý örneði.

using System;
namespace CSEðitimi {
    class VeriTipleri {
        static void Main () {
            Console.Write ("Veri tipi deðiþkenin belleðe depoladýðý bilgi türüdür. Üç tip veri vardýr: deðer (öntanmlý: int, boolean, float; kullanýcýtýmlý: enum, struct), göstergeç (* ve & ile adres; int *a; char *krk;), referans (öntanýmlý: string, object; kullanýcýtanýmlý: class, interface).\nTüm 32-bit deðer tip, ebat ve kapsamlarý: char (1Byte, -128->+127), signed char (1B, -128->+127), unsigned char (1B, 0->+127/255?), short (2B, -32,768->32,767), unsigned short (2B, -32,768->32,767), signed short (2B, 0-> 65,535), int (4B, -2,147,483,648->2,147,483,647), signed int (4B, -2,147,483,648->2,147,483,647), unsigned int (4B, 0-> 4,294,967,295), long (9,223,372,036,854,775,808->9,223,372,036,854,775,807), signed long (9,223,372,036,854,775,808->9,223,372,036,854,775,807), unsigned long (0-> 18,446,744,073,709,551,615), float (4B, 1.5e-45->3.4e38, 7-hane ondalýk hassasiyet), double (8B, 5.0e-324->1.7e308, 15-hassas), decimal (16B, enaz  -7.9e28->7.9e28, 28-hassas).\n1B=2**(1*8)-1=255 hane, 16B=2**(16*8)-1=340282366920938463463374607431768211455 hane.\nDeðer tipli deðiþken kopyalarý bellekte ayrý konumlardayken referansýn kopyalarý ayný konumu gördüðünden, birindeki deðiþiklik tüm kopyalarýna da yansýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}