// tpc#31b.cs: Öðrenci özelliklerini soyut aþýrýyüklü türev eriþimcilerle yazma ve okuma örneði.

using System;
namespace Özellikler {
    public abstract class Þahýs {
        public abstract string Ad {get; set;}
        public abstract int Yaþ {get; set;}
    }
    class Öðrenci: Þahýs {
        private string no = "MD"; // Mevcut Deðil
        private string ad = "Bilinmiyor";
        private int yaþ = 0;
        // No, Ad, Yaþ özellik beyanlarý ve set/get eriþimcileri
        public string No {get {return no;} set {no = value;} }
        public override string Ad {get {return ad;} set {ad = value;} }
        public override int Yaþ {get {return yaþ;} set {yaþ = value;} }
        // Aþýrýyüklenen metod
        public override string ToString() {return "No'su = " + No +", Adý = " + Ad + ", Yaþý = " + Yaþ;}
    }
    class SoyutÖzellikler {
        static void Main() {
            Console.Write ("Soyut özellikler soyut sýnýfta tanýmlanýr ve türev sýnýflardaki aþýrýyüklü özelliklerce yürütülürler.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

           Öðrenci öðr = new Öðrenci(); // Bir Öðrenci nesnesi yaratma
           öðr.No = "A-002"; öðr.Ad = "Z.Nihal Candan"; öðr.Yaþ = 2022 - 1955; Console.WriteLine ("Öðrenci Bilgileri:\n{0}\n", öðr);
           öðr.Yaþ += 1; öðr.No = "B-002"; Console.WriteLine ("Sýnýfýný geçen Öðrenci Bilgileri:\n{0}\n", öðr);
           öðr.Yaþ += 1; öðr.No = "C-002"; Console.WriteLine ("Sýnýfýný geçen Öðrenci Bilgileri:\n{0}\n", öðr);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}