// jtpc#1103.cs: Kapsüllenen öðrenci sýnýf özelliklerine eriþim örneði.

using System;
namespace Aduzamlar {  
    class Öðrenci {
        public int no {get; set;} //Get-set ile yaratýlan özellikler
        public string isim {get; set;}
        public string Eposta {get; set;}
    }
}
namespace Aduzamlar {
    class Kapsülleme {
        static void Main() {
            Console.Write ("Kapsülleme, sýnýfýn tüm üyelerini tek bir sýnýf birimine sarmalayýp, eriþimi sadece alýcý-koyucu/get-set fonksiyonu yoluyla mümkün kýlar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Öðrenci ö1 = new Öðrenci(); ö1.no=101; ö1.isim="M.Nihat Yavaþ"; ö1.Eposta="mnyavas@gmail.com";
            Öðrenci ö2 = new Öðrenci(); ö2.no=102; ö2.isim="Hatice Yavaþ"; ö2.Eposta="hyavas@gmail.com";
            Öðrenci ö3 = new Öðrenci(); ö3.no=103; ö3.isim="Süheyla Yavaþ"; ö3.Eposta="syavas@gmail.com";
            Console.WriteLine ("{0} no'lu {1}'ýn eposta adresi: {2}", ö1.no, ö1.isim, ö1.Eposta);
            Console.WriteLine ("{0} no'lu {1}'ýn eposta adresi: {2}", ö2.no, ö2.isim, ö2.Eposta);
            Console.WriteLine ("{0} no'lu {1}'ýn eposta adresi: {2}", ö3.no, ö3.isim, ö3.Eposta);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}