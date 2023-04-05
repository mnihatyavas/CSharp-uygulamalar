// j2sc#0105a.cs: 'using System' ve içiçe aduzamlar örneði.

using System;
namespace DilTemelleri {
    class Aduzam1 {
        static void Main() {
            Console.Write ("Bir aduzam, bir katagoriyi diðerinden ayýrýr. 'System' aduzamý .NET Framework sýnýf dll kütüphanesi için ayrýlmýþtýr. Bir aduzamdaki isimler diðerlerinde de aynen bulunsa da birbirleriyle karýþtýrýlmazlar. 'using' ayrýlmýþ kelimesi adýgeçen aduzamdaki isimleri kullanacaðýný beyan eder.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");
/*
namespace DýþAduzam {
    namespace ÝçAduzam {
        //...
    }
}
==>
namespace DýþAduzam.ÝçAduzam {
    // ...
}
*/
            Console.WriteLine ("Ýçiçe aduzamlar, içiçe {} bloklarla temsil edilirler. Ýçiçe aduzamlar noktalamalý tek bloða da çevrilebilir.");
            System.Console.WriteLine ("'using' kullanýlmazsa ilgili aduzam komut baþlarýna gelmelidir.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}