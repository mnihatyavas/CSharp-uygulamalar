// tpc#24c.cs: "using aduzam"la içiçe üç farklý aduzamlardaki ayný adlý fonksiyonlarý çaðýrma örneði.

using System;
using ÝlkAduzam;
using ÝlkAduzam.ÝkinciAduzam;
using ÝlkAduzam.ÝkinciAduzam.ÜçüncüAduzam;
namespace ÝlkAduzam {
    class Sýnýf1 {public void fonk() {Console.WriteLine ("Ýlk aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");} }
    namespace ÝkinciAduzam {
        class Sýnýf2 {public void fonk() {Console.WriteLine ("Ýlk aduzam içindeki ikinci aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");} }
        namespace ÜçüncüAduzam {
            class Sýnýf3 {public void fonk() {Console.WriteLine ("\n\nÝlk aduzam içindeki ikinci aduzam içindeki üçüncü aduzam içindeki farklý adlý sýnýfýn ayný adlý fonksiyonundayým.");} }
            class ÜçlüAduzam3 {
                static void Main() {
                    Console.Write ("Ýçiçe 'using aduzam' anahtarkelimeli kullaným (farklý) sýnýf adlarý kullanýlýrken baþýna (System gibi) aduzam isminin kullanýmýný gereksiz kýlar.\nTuþ..."); Console.ReadKey();

                    Sýnýf1 sýnýf1 = new Sýnýf1();
                    Sýnýf2 sýnýf2 = new Sýnýf2();
                    Sýnýf3 sýnýf3 = new Sýnýf3();
                    sýnýf3.fonk();
                    sýnýf1.fonk();
                    sýnýf2.fonk();

                    Console.Write ("Tuþ..."); Console.ReadKey();
                } // Main metodu
            } // ÜçlüAduzam3 sýnfý
        } // ÜçüncüAduzam
    } // ÝkinciAduzam
} // ÝlkAduzam