// jtpc#0102.cs: CLR ile ilgili kýsa açýklamalar örneði.

using System;
namespace AðÝskeleti {
    class CLR {
        static void Main() {
            Console.Write (".NET CLR-4.6'nýn bir .CS programýný derleme aþamalarý: C# kodlamasý-->CSC derleyici-->MSIL kod ve Metadata-->JIT derleyici-->Exe koþturulabilir kod.\nDeðer tipli deðiþkenler (sayý, ikili, krk, tarih; kullanýcý-tanýmlý; sayýsallanan) doðrudan deðer içerir; referans tipler ise (dizge, göstergeç, sýnýf) bellek yýðýndaki deðerin adresini içerir.\nCLS (CommonLanguageSpecification/GenelDilTanýmý), aðiskeletin desteklediði dillerdeki kodlamalarýn karþýlýklý-iþletilebilirliðini saðlar.\nGarbageCollection/ÇöpToplama tekniði programda iþi biten deðiþken ve nesnelerin bellek baðlarýný kopararak o yýðýn belleðin tekrar kullanýlabilirliðini, güvenliðini, nesnelerin birdiðerinin deðerini kullananamasýný güvenceye alýr.\nCLR fonksiyonlarý: CS kodu yerli EXE koda derler; istisnalarý yönetir; tip güvenliði saðlar; bellek yönetimi; güvenlik saðlar; ileri performans; dilden baðýmsýz; platform baðýmsýz; çöp toplama; nesneye yönelik programlarýn miras, arayüz, aþýrýyükleme vb özelliklerini saðlar; yönetilen ve yönetilmeyen kodlar arasý iþletilebilirlik.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}