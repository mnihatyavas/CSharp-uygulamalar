// jtpc#0701.cs: 'set-get'le de�er atan�p-okunan 'private" s�n�f alanl� �zellik �rne�i.

using System;
namespace �zellikler {
    public class ��g�ren1 {
        private string isim;
        public string �sim {get {return isim;} set {isim = value;} }// set-value yal�n
    }
    public class ��g�ren2 {
        private string isim;
        public string �sim {get {return isim;} set {isim = value + " Yava�";} }// set-value yal�n de�il, i�lenmi�
    }
    public class ��g�ren3 {
        private static int saya�;
        public ��g�ren3() {saya�++;} //Parametresiz kurucu
        public static int Saya� {get {return saya�;} } //Sadece-get/okunabilir
    }
    class �zellik {
        static void Main() {
            Console.Write ("�zellik s�n�f�n, de�eri genelde b�y�k-harfle ba�layan alan adl� ()'s�z set-get'le yaz�l�p-okunan, alandan gayr� belle�i olmayan private/�zel �yeleridir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ��g�ren1 i1 = new ��g�ren1(); i1.�sim = "M.Nihat Yava�";
            Console.WriteLine ("1.i�g�renin ismi: " + i1.�sim);
            //��g�ren1 i2 = new ��g�ren1(); i2.�sim = "M.Nedim Yava�";
            Console.WriteLine ("2.i�g�renin ismi: " + (new ��g�ren1().�sim = "M.Nedim Yava�"));

            ��g�ren2 i3 = new ��g�ren2(); i3.�sim = "Song�l G�kt�rk";
            Console.WriteLine ("\n3.i�g�renin ismi: " + i3.�sim);
            ��g�ren2 i4 = new ��g�ren2(); i4.�sim = "Hatice Ka�ar"; //(isim = value + " Yava�") i�ler
            Console.WriteLine ("4.i�g�renin ismi: " + i4.�sim);
            Console.WriteLine ("5.i�g�renin ismi: " + (new ��g�ren2().�sim = "Hatice Ka�ar")); //Sadece (isim = value) i�ler?..

            new ��g�ren3(); new ��g�ren3(); new ��g�ren3(); new ��g�ren3();
            Console.WriteLine ("\n��g�ren3'le kaydedilen amele say�s� = " + ��g�ren3.Saya�);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}