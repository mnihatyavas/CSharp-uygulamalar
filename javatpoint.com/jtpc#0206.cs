// jtpc#0206.cs: Veri tipleri, gruplama ve kapsamlar� �rne�i.

using System;
namespace CSE�itimi {
    class VeriTipleri {
        static void Main () {
            Console.Write ("Veri tipi de�i�kenin belle�e depolad��� bilgi t�r�d�r. �� tip veri vard�r: de�er (�ntanml�: int, boolean, float; kullan�c�t�ml�: enum, struct), g�sterge� (* ve & ile adres; int *a; char *krk;), referans (�ntan�ml�: string, object; kullan�c�tan�ml�: class, interface).\nT�m 32-bit de�er tip, ebat ve kapsamlar�: char (1Byte, -128->+127), signed char (1B, -128->+127), unsigned char (1B, 0->+127/255?), short (2B, -32,768->32,767), unsigned short (2B, -32,768->32,767), signed short (2B, 0-> 65,535), int (4B, -2,147,483,648->2,147,483,647), signed int (4B, -2,147,483,648->2,147,483,647), unsigned int (4B, 0-> 4,294,967,295), long (9,223,372,036,854,775,808->9,223,372,036,854,775,807), signed long (9,223,372,036,854,775,808->9,223,372,036,854,775,807), unsigned long (0-> 18,446,744,073,709,551,615), float (4B, 1.5e-45->3.4e38, 7-hane ondal�k hassasiyet), double (8B, 5.0e-324->1.7e308, 15-hassas), decimal (16B, enaz  -7.9e28->7.9e28, 28-hassas).\n1B=2**(1*8)-1=255 hane, 16B=2**(16*8)-1=340282366920938463463374607431768211455 hane.\nDe�er tipli de�i�ken kopyalar� bellekte ayr� konumlardayken referans�n kopyalar� ayn� konumu g�rd���nden, birindeki de�i�iklik t�m kopyalar�na da yans�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}