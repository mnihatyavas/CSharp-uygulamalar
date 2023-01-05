// tpc#31a.cs: Öðrenci özelliklerini eriþimcilerle yazma ve okuma örneði.

using System;
namespace Özellikler {
    class Öðrenci {
        private string no = "MD"; // Mevcut Deðil
        private string ad = "Bilinmiyor";
        private int yaþ = 0;
        // No, Ad, Yaþ özellik beyanlarý ve set/get eriþimcileri
        public string No {get {return no;} set {no = value;} }
        public string Ad {get {return ad;} set {ad = value;} }
        public int Yaþ {get {return yaþ;} set {yaþ = value;} }
        // Aþýrýyüklenen metod
        public override string ToString() {return "No'su = " + No +", Adý = " + Ad + ", Yaþý = " + Yaþ;}
    }
    class ÖzelliklereEriþim {
        static void Main() {
            Console.Write ("Sýnýf ve yapý deðiþken ve metodlarý birer alan olup, deðerleri özelliklerdir ve eriþimcilerle (set/koy ve get/al) yazýlýp okunurlar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

           Öðrenci öðr = new Öðrenci(); // Bir Öðrenci nesnesi yaratma
           öðr.No = "A-001"; öðr.Ad = "M.Nihat Yavaþ"; öðr.Yaþ = 2022 - 1957; Console.WriteLine ("Öðrenci Bilgileri:\n{0}\n", öðr);
           öðr.Yaþ += 1; öðr.No = "B-001"; Console.WriteLine ("Sýnýfýný geçen Öðrenci Bilgileri:\n{0}\n", öðr);
           öðr.Yaþ += 1; öðr.No = "C-001"; Console.WriteLine ("Sýnýfýný geçen Öðrenci Bilgileri:\n{0}\n", öðr);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}