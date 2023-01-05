// tpc#29a.cs: �n-tan�ml� �artl� hata-ay�klay�c� vas�f �rne�i.

#define DEBUG
using System;
using System.Diagnostics;
namespace Vas�flar {
    public class Vas�fl�S�n�f�m {
        [Conditional ("DEBUG")]
        public static void Mesaj�m (string mesaj) {Console.WriteLine (mesaj);}
    }
    class �artl�Vas�f {
        static void fonk1() {Vas�fl�S�n�f�m.Mesaj�m ("�imdi �artl�Vas�f-->fonk1() i�indeyim."); fonk2();}
        static void fonk2() {Vas�fl�S�n�f�m.Mesaj�m ("�imdi �artl�Vas�f-->fonk2() i�indeyim.");}
        static void Main() {
            Console.Write ("Vas�flar, �al��mazaman�nda, s�n�f, metod, yap�, say�sallanan gibi elemanlara dair bilgi beyan etiketleridir; ve [] i�inde eleman �n�ndedir. �n-tan�ml� veya �zel-yap�l� olabilirler. �n-tan�ml�lar 3 t�rl�d�r: AttributeUsage/Vas�fKullan�m�, Conditional/�artl�, Obsolete/Demode.\n�lkine �rnek: [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = inherited)]\n�artl� ise derleme-zamanl� DEBUG gibi �ni�lemci direktifine hata-ay�klama kimlikleyici sunar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Vas�fl�S�n�f�m.Mesaj�m ("Vas�fl�S�n�f�m'�n DEBUG �artl� vas�fl� Mesaj�m metodunu kullanarak:\n�imdi �artl�Vas�f-->Main() i�indeyim.");
            fonk1();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}