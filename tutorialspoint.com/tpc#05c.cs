// tpc#05c.cs: C# referans ve gösterge veri tipleri örneði.

using System;
namespace VeriTipleri {
    class ReferansGöstergeTipler {
        static void Main (string[] args) {
            Console.WriteLine ("Built-in/arþiv referanslar: object/nesne, dinamik ve string/dizge veri tipleridir. Deðiþkenler burda deðer deðil deðerin bellek adresini içerir.");
            Console.WriteLine ("Tipi nesneye çevirmeye boxing/kutulama; tersine de unboxing/kutusuzlama denir (object nesne = 100;).\nDinamiðin tip kontrolu derlemede deðil çalýþma anýnda yapýlýr (dinamic d = 20;).\nDizge deðiþkene deðer atama doðrudan yada @ ile yapýlýr (String dizge = 'Nihat', veya @'Nihat').");
            Console.WriteLine ("Kullanýcý-tanýmlý referans tipler: class/sýnýf, interface/arabaðlaç ve delegate/yetkiaktarýmý.");
            Console.Write ("\nPointer/gösterge veri tipi, baþka tipin adresini saklar (char* krkgösterge; int* tamsayýgösterge;).\nTuþ...");
            Console.ReadKey();
        }
    }
}