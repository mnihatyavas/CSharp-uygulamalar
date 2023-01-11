// jtpc#0102.cs: CLR ile ilgili k�sa a��klamalar �rne�i.

using System;
namespace A��skeleti {
    class CLR {
        static void Main() {
            Console.Write (".NET CLR-4.6'n�n bir .CS program�n� derleme a�amalar�: C# kodlamas�-->CSC derleyici-->MSIL kod ve Metadata-->JIT derleyici-->Exe ko�turulabilir kod.\nDe�er tipli de�i�kenler (say�, ikili, krk, tarih; kullan�c�-tan�ml�; say�sallanan) do�rudan de�er i�erir; referans tipler ise (dizge, g�sterge�, s�n�f) bellek y���ndaki de�erin adresini i�erir.\nCLS (CommonLanguageSpecification/GenelDilTan�m�), a�iskeletin destekledi�i dillerdeki kodlamalar�n kar��l�kl�-i�letilebilirli�ini sa�lar.\nGarbageCollection/��pToplama tekni�i programda i�i biten de�i�ken ve nesnelerin bellek ba�lar�n� kopararak o y���n belle�in tekrar kullan�labilirli�ini, g�venli�ini, nesnelerin birdi�erinin de�erini kullananamas�n� g�venceye al�r.\nCLR fonksiyonlar�: CS kodu yerli EXE koda derler; istisnalar� y�netir; tip g�venli�i sa�lar; bellek y�netimi; g�venlik sa�lar; ileri performans; dilden ba��ms�z; platform ba��ms�z; ��p toplama; nesneye y�nelik programlar�n miras, aray�z, a��r�y�kleme vb �zelliklerini sa�lar; y�netilen ve y�netilmeyen kodlar aras� i�letilebilirlik.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}