// jtpc#230301.cs: Tipleri çalýþma zamanlý dinamik baðlanan deðiþken ve metodlar örneði.

using System;
namespace YeniÖzellikler {
    public class Öðrenci {
        public dynamic Ýsim {get; set;} //Dinamik tipleme
        public dynamic YaþýGöster (int yaþ) {return yaþ;} //Dinamik geridönen tipleme
    }
    class DinamikBaðlama {
        static void Main() {
            Console.Write ("'dynamic' anahtarkelimeli deðiþken ve metod tipleri nesne tipli farzedilerek derlenir fakat esas tiplenmeleri çalýþma zamanýnda dinamik olarak baðlanarak sabitlenir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            dynamic d1 = 2023;
            object d2 = 2023;
            Console.WriteLine ("Dinamik {0} ilkdeðerli deðiþken tipi: {1}", d1, d1.GetType());
            Console.WriteLine ("Nesnel {0} ilkdeðerli deðiþken tipi: {1}", d2, d2.GetType());

            d1 +=-66;
            //d2 +=-66; //Derleme hatalý
            d2 = 1957; //Derleme hatasýz
            Console.WriteLine ("\nDinamik Int32 deðiþkene tamsayý ekleme: {0}", d1);
            Console.WriteLine ("Nesnel Int32 deðiþkene yeni tamsayý atama: {0}", d2);

            var öðr = new Öðrenci(); öðr.Ýsim = "Zafer N.Candan";
            Console.WriteLine ("", öðr.Ýsim);
            dynamic yaþ = öðr.YaþýGöster (2023);
            Console.WriteLine ("Dinamik {0} yaþ'a eksi dinamik metod geridönüþünü ekleme: {1}", yaþ, (yaþ +=-66));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}