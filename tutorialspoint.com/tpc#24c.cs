// tpc#24c.cs: "using aduzam"la i�i�e �� farkl� aduzamlardaki ayn� adl� fonksiyonlar� �a��rma �rne�i.

using System;
using �lkAduzam;
using �lkAduzam.�kinciAduzam;
using �lkAduzam.�kinciAduzam.���nc�Aduzam;
namespace �lkAduzam {
    class S�n�f1 {public void fonk() {Console.WriteLine ("�lk aduzam i�indeki farkl� adl� s�n�f�n ayn� adl� fonksiyonunday�m.");} }
    namespace �kinciAduzam {
        class S�n�f2 {public void fonk() {Console.WriteLine ("�lk aduzam i�indeki ikinci aduzam i�indeki farkl� adl� s�n�f�n ayn� adl� fonksiyonunday�m.");} }
        namespace ���nc�Aduzam {
            class S�n�f3 {public void fonk() {Console.WriteLine ("\n\n�lk aduzam i�indeki ikinci aduzam i�indeki ���nc� aduzam i�indeki farkl� adl� s�n�f�n ayn� adl� fonksiyonunday�m.");} }
            class ��l�Aduzam3 {
                static void Main() {
                    Console.Write ("��i�e 'using aduzam' anahtarkelimeli kullan�m (farkl�) s�n�f adlar� kullan�l�rken ba��na (System gibi) aduzam isminin kullan�m�n� gereksiz k�lar.\nTu�..."); Console.ReadKey();

                    S�n�f1 s�n�f1 = new S�n�f1();
                    S�n�f2 s�n�f2 = new S�n�f2();
                    S�n�f3 s�n�f3 = new S�n�f3();
                    s�n�f3.fonk();
                    s�n�f1.fonk();
                    s�n�f2.fonk();

                    Console.Write ("Tu�..."); Console.ReadKey();
                } // Main metodu
            } // ��l�Aduzam3 s�nf�
        } // ���nc�Aduzam
    } // �kinciAduzam
} // �lkAduzam