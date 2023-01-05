// tpc#24a.cs: Farklý aduzamlardaki ayný adlý sýnýf ve fonksiyonlarý çaðýrma örneði.

using System;
namespace ÝlkAduzam {
    class Sýnýf {
        public void fonk() {Console.WriteLine ("Ýlk aduzam içindeki ayný adlý sýnýflý fonksiyondayým.");}
    }
}
namespace ÝkinciAduzam {
    class Sýnýf {
        public void fonk() {Console.WriteLine ("Ýkinci aduzam içindeki ayný adlý sýnýflý fonksiyondayým.");}
    }
}
namespace ÜçüncüAduzam {
    class Sýnýf {
        public void fonk() {Console.WriteLine ("\n\nÜçüncü aduzam içindeki ayný adlý sýnýflý fonksiyondayým.");}
    }
    class ÜçlüAduzam1 {
        static void Main() {
            Console.Write ("Bir aduzamdaki ayný sýnýf adý farklý aduzamdakiyle karýþmaz. Çaðrýlma: aduzam.sýnýf/fonk/deðiþken.\nTuþ..."); Console.ReadKey();

            ÝlkAduzam.Sýnýf sýnýf1 = new ÝlkAduzam.Sýnýf();
            ÝkinciAduzam.Sýnýf sýnýf2 = new ÝkinciAduzam.Sýnýf();
            ÜçüncüAduzam.Sýnýf sýnýf3 = new ÜçüncüAduzam.Sýnýf();
            sýnýf3.fonk();
            sýnýf1.fonk();
            sýnýf2.fonk();

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}