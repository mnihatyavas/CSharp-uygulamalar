// jtpc#1103.cs: Kaps�llenen ��renci s�n�f �zelliklerine eri�im �rne�i.

using System;
namespace Aduzamlar {  
    class ��renci {
        public int no {get; set;} //Get-set ile yarat�lan �zellikler
        public string isim {get; set;}
        public string Eposta {get; set;}
    }
}
namespace Aduzamlar {
    class Kaps�lleme {
        static void Main() {
            Console.Write ("Kaps�lleme, s�n�f�n t�m �yelerini tek bir s�n�f birimine sarmalay�p, eri�imi sadece al�c�-koyucu/get-set fonksiyonu yoluyla m�mk�n k�lar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ��renci �1 = new ��renci(); �1.no=101; �1.isim="M.Nihat Yava�"; �1.Eposta="mnyavas@gmail.com";
            ��renci �2 = new ��renci(); �2.no=102; �2.isim="Hatice Yava�"; �2.Eposta="hyavas@gmail.com";
            ��renci �3 = new ��renci(); �3.no=103; �3.isim="S�heyla Yava�"; �3.Eposta="syavas@gmail.com";
            Console.WriteLine ("{0} no'lu {1}'�n eposta adresi: {2}", �1.no, �1.isim, �1.Eposta);
            Console.WriteLine ("{0} no'lu {1}'�n eposta adresi: {2}", �2.no, �2.isim, �2.Eposta);
            Console.WriteLine ("{0} no'lu {1}'�n eposta adresi: {2}", �3.no, �3.isim, �3.Eposta);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}