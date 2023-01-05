// tpc#24b.cs: "using aduzam"la farklý aduzamlardaki ayný adlý fonksiyonlarý çaðýrma örneði.

using System;
using ÝlkAduzam;
using ÝkinciAduzam;
using ÜçüncüAduzam;
namespace ÝlkAduzam {
    class Sýnýf1 {
        public void fonk() {Console.WriteLine ("Ýlk aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");}
    }
}
namespace ÝkinciAduzam {
    class Sýnýf2 {
        public void fonk() {Console.WriteLine ("Ýkinci aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");}
    }
}
namespace ÜçüncüAduzam {
    class Sýnýf3 {
        public void fonk() {Console.WriteLine ("\n\nÜçüncü aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");}
    }
    class ÜçlüAduzam2 {
        static void Main() {
            Console.Write ("'using aduzam' anahtarkelimeli kullaným (farklý) sýnýf adlarý kullanýlýrken baþýna (System gibi) aduzam isminin kullanýmýný gereksiz kýlar.\nTuþ..."); Console.ReadKey();

            Sýnýf1 sýnýf1 = new Sýnýf1();
            Sýnýf2 sýnýf2 = new Sýnýf2();
            Sýnýf3 sýnýf3 = new Sýnýf3();
            sýnýf3.fonk();
            sýnýf1.fonk();
            sýnýf2.fonk();

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}