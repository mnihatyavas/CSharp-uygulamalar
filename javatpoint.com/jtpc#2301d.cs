// jtpc#2301d.cs: Ebeveyn delegeli metodlarýn tipleme geridönüþleri örneði.

using System;
namespace YeniÖzellikler {
    class A {}
    class B: A {}
    class C: B {}
    class D {}
    class DelegeEþdeðiþinti {
    delegate A Delegem();
    static A MetodA() {Console.WriteLine ("MetodA'nýn A ebeveyn-sýnýf tiplemeli geridönüþü"); return new A();}
    static B MetodB() {Console.WriteLine ("MetodB'nin B çocuk-sýnýf tiplemeli geridönüþü"); return new B();}
    static C MetodC() {Console.WriteLine ("MetodC'nin C torun-sýnýf tiplemeli geridönüþü"); return new C();}
    static D MetodD() {Console.WriteLine ("MetodD'nýn A delegeyle D-sýnýf tiplemeli geridönüþü"); return new D();}
        static void Main() {
            Console.Write ("Ebeveyn delegeli metod ebeveyn ve yavrularýnýn tiplemesini döndürebilir. Ebevyn yavrusu olmayan tipleme geridönüþleri derleme hatasý verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Delegem delege1 = MetodA; delege1();
            Delegem delege2 = MetodB; delege2();
            Delegem delege3 = MetodC; delege3();
            //Delegem delege4 = MetodD; delege4(); //A delege, yavrusu olmayan D-sýnýf metod çaðrýsýna derleme hatasý verir

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}