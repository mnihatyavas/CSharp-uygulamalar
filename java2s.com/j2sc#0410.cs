// j2sc#0410.cs: Using aduzam.s�n�f ile ar�iv veya �zel tiplemelerin tan�m�n� k�saltma �rne�i.

using System;
using System1 = System;              
using Konsol1 = System.Console;
using Saya�;
using Say = Saya�.S�n�f2;
namespace Saya� {class S�n�f2{public S�n�f2(){Console.WriteLine ("Saya�.S�n�f2 Kurucusu");}} }
namespace �fadeler {
    public class S�n�f1 : IDisposable {
        public S�n�f1() {Console.WriteLine ("Kurucu");} //Nesne tiplemesinde otomatikmen i�letilir.
        ~S�n�f1() {Console.WriteLine ("Y�k�c�");} //Program sonlanmas�nda nesne silinirken otomatikmen i�letilir.
        public void Dispose() {Console.WriteLine ("IDisposable.Dispose() metodunun using'le otomatikmen y�r�t�lmesi.");}
        public void Metot() {Console.WriteLine ("Tiplemeyle �a�r�l�rsa i�letilir.");}
    }
    class Using {
        static void Main() {
            Console.Write ("'using' aduzam/namespace, alias/arma=ad, ve baz� metodlar�n otomatikmen y�r�t�lmesinde kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ebeveyn IDisposable s�n�f�n Dispose() metodunun otomatik y�r�t�lmesi:");
            using (S�n�f1 Nesne1 = new S�n�f1()){}
            S�n�f1 Nesne2 = new S�n�f1();
            S�n�f1 Nesne3 = new S�n�f1();
            using (S�n�f1 Nesne4 = new S�n�f1()){}
            Nesne2.Metot();

            Console.WriteLine ("\nSystem ve System.Console i�in 'using' ad kullan�lmas�:");
            System.Console.WriteLine ("System.Console.WriteLine ile yazd�rma");
            System1.Console.WriteLine ("System1.Console.WriteLine ile yazd�rma");
            Konsol1.WriteLine ("Konsol1.WriteLine ile yazd�rma");

            Console.WriteLine ("\n�zel aduzam:Saya� ve s�n�f�:S�n�f2 i�in using'le nesnelerini yaratma:");
            S�n�f2 ns1 = new S�n�f2();
            Say ns2 = new Say();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}