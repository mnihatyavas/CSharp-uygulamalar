// jtpc#230301.cs: Tipleri �al��ma zamanl� dinamik ba�lanan de�i�ken ve metodlar �rne�i.

using System;
namespace Yeni�zellikler {
    public class ��renci {
        public dynamic �sim {get; set;} //Dinamik tipleme
        public dynamic Ya��G�ster (int ya�) {return ya�;} //Dinamik gerid�nen tipleme
    }
    class DinamikBa�lama {
        static void Main() {
            Console.Write ("'dynamic' anahtarkelimeli de�i�ken ve metod tipleri nesne tipli farzedilerek derlenir fakat esas tiplenmeleri �al��ma zaman�nda dinamik olarak ba�lanarak sabitlenir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            dynamic d1 = 2023;
            object d2 = 2023;
            Console.WriteLine ("Dinamik {0} ilkde�erli de�i�ken tipi: {1}", d1, d1.GetType());
            Console.WriteLine ("Nesnel {0} ilkde�erli de�i�ken tipi: {1}", d2, d2.GetType());

            d1 +=-66;
            //d2 +=-66; //Derleme hatal�
            d2 = 1957; //Derleme hatas�z
            Console.WriteLine ("\nDinamik Int32 de�i�kene tamsay� ekleme: {0}", d1);
            Console.WriteLine ("Nesnel Int32 de�i�kene yeni tamsay� atama: {0}", d2);

            var ��r = new ��renci(); ��r.�sim = "Zafer N.Candan";
            Console.WriteLine ("", ��r.�sim);
            dynamic ya� = ��r.Ya��G�ster (2023);
            Console.WriteLine ("Dinamik {0} ya�'a eksi dinamik metod gerid�n���n� ekleme: {1}", ya�, (ya� +=-66));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}