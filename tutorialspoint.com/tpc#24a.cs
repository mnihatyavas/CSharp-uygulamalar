// tpc#24a.cs: Farkl� aduzamlardaki ayn� adl� s�n�f ve fonksiyonlar� �a��rma �rne�i.

using System;
namespace �lkAduzam {
    class S�n�f {
        public void fonk() {Console.WriteLine ("�lk aduzam i�indeki ayn� adl� s�n�fl� fonksiyonday�m.");}
    }
}
namespace �kinciAduzam {
    class S�n�f {
        public void fonk() {Console.WriteLine ("�kinci aduzam i�indeki ayn� adl� s�n�fl� fonksiyonday�m.");}
    }
}
namespace ���nc�Aduzam {
    class S�n�f {
        public void fonk() {Console.WriteLine ("\n\n���nc� aduzam i�indeki ayn� adl� s�n�fl� fonksiyonday�m.");}
    }
    class ��l�Aduzam1 {
        static void Main() {
            Console.Write ("Bir aduzamdaki ayn� s�n�f ad� farkl� aduzamdakiyle kar��maz. �a�r�lma: aduzam.s�n�f/fonk/de�i�ken.\nTu�..."); Console.ReadKey();

            �lkAduzam.S�n�f s�n�f1 = new �lkAduzam.S�n�f();
            �kinciAduzam.S�n�f s�n�f2 = new �kinciAduzam.S�n�f();
            ���nc�Aduzam.S�n�f s�n�f3 = new ���nc�Aduzam.S�n�f();
            s�n�f3.fonk();
            s�n�f1.fonk();
            s�n�f2.fonk();

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}