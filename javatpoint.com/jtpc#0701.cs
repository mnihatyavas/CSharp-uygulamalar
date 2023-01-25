// jtpc#0701.cs: 'set-get'le deðer atanýp-okunan 'private" sýnýf alanlý özellik örneði.

using System;
namespace Özellikler {
    public class Ýþgören1 {
        private string isim;
        public string Ýsim {get {return isim;} set {isim = value;} }// set-value yalýn
    }
    public class Ýþgören2 {
        private string isim;
        public string Ýsim {get {return isim;} set {isim = value + " Yavaþ";} }// set-value yalýn deðil, iþlenmiþ
    }
    public class Ýþgören3 {
        private static int sayaç;
        public Ýþgören3() {sayaç++;} //Parametresiz kurucu
        public static int Sayaç {get {return sayaç;} } //Sadece-get/okunabilir
    }
    class Özellik {
        static void Main() {
            Console.Write ("Özellik sýnýfýn, deðeri genelde büyük-harfle baþlayan alan adlý ()'sýz set-get'le yazýlýp-okunan, alandan gayrý belleði olmayan private/özel üyeleridir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Ýþgören1 i1 = new Ýþgören1(); i1.Ýsim = "M.Nihat Yavaþ";
            Console.WriteLine ("1.iþgörenin ismi: " + i1.Ýsim);
            //Ýþgören1 i2 = new Ýþgören1(); i2.Ýsim = "M.Nedim Yavaþ";
            Console.WriteLine ("2.iþgörenin ismi: " + (new Ýþgören1().Ýsim = "M.Nedim Yavaþ"));

            Ýþgören2 i3 = new Ýþgören2(); i3.Ýsim = "Songül Göktürk";
            Console.WriteLine ("\n3.iþgörenin ismi: " + i3.Ýsim);
            Ýþgören2 i4 = new Ýþgören2(); i4.Ýsim = "Hatice Kaçar"; //(isim = value + " Yavaþ") iþler
            Console.WriteLine ("4.iþgörenin ismi: " + i4.Ýsim);
            Console.WriteLine ("5.iþgörenin ismi: " + (new Ýþgören2().Ýsim = "Hatice Kaçar")); //Sadece (isim = value) iþler?..

            new Ýþgören3(); new Ýþgören3(); new Ýþgören3(); new Ýþgören3();
            Console.WriteLine ("\nÝþgören3'le kaydedilen amele sayýsý = " + Ýþgören3.Sayaç);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}