// jtpc#1101.cs: Be� farkl� aduzam�n ayn�/farkl� adl� s�n�f ve metodunu �a��rma �rne�i.

using System;
using D�rd�nc�Aduzam;
using Be�inciAduzam;

namespace �lkAduzam {public class Selam {public void selamla() {System.Console.WriteLine ("Merhaba �lkAduzam");}} } // Ayn� s�n�f adlar�
namespace �kinciAduzam {public class Selam {public void selamla() {Console.WriteLine ("Merhaba �kinciAduzam");}} }
namespace ���nc�Aduzam {public class Selam {public void selamla() {Console.WriteLine ("Merhaba ���nc�Aduzam");}} }

namespace D�rd�nc�Aduzam {public class Selam4 {public void selamla() {Console.WriteLine ("\nMerhaba D�rd�nc�Aduzam");}} } // Farkl� s�n�f adlar�
namespace Be�inciAduzam {public class Selam5 {public void selamla() {Console.WriteLine ("Merhaba Be�inciAduzam");}} }

namespace Aduzamlar {
    class Aduzam {
        static void Main() {
            Console.Write ("Aduzam, s�n�flar�n organizasyonunda kullan�l�r. 'using' anahtarkelimesiyle belirtilen aduzam�n art�k s�n�f�n�n ba��nda bulunmas� gerekmez. 'system' .net Framework'�n global aduzam�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            �lkAduzam.Selam s1 = new �lkAduzam.Selam();
            �kinciAduzam.Selam s2 = new �kinciAduzam.Selam();
            ���nc�Aduzam.Selam s3 = new ���nc�Aduzam.Selam();
            s1.selamla(); s2.selamla(); s3.selamla();

            Selam4 s4 = new Selam4();
            Selam5 s5 = new Selam5();
            s4.selamla(); s5.selamla();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}