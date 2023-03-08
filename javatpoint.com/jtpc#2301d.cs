// jtpc#2301d.cs: Ebeveyn delegeli metodlar�n tipleme gerid�n��leri �rne�i.

using System;
namespace Yeni�zellikler {
    class A {}
    class B: A {}
    class C: B {}
    class D {}
    class DelegeE�de�i�inti {
    delegate A Delegem();
    static A MetodA() {Console.WriteLine ("MetodA'n�n A ebeveyn-s�n�f tiplemeli gerid�n���"); return new A();}
    static B MetodB() {Console.WriteLine ("MetodB'nin B �ocuk-s�n�f tiplemeli gerid�n���"); return new B();}
    static C MetodC() {Console.WriteLine ("MetodC'nin C torun-s�n�f tiplemeli gerid�n���"); return new C();}
    static D MetodD() {Console.WriteLine ("MetodD'n�n A delegeyle D-s�n�f tiplemeli gerid�n���"); return new D();}
        static void Main() {
            Console.Write ("Ebeveyn delegeli metod ebeveyn ve yavrular�n�n tiplemesini d�nd�rebilir. Ebevyn yavrusu olmayan tipleme gerid�n��leri derleme hatas� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Delegem delege1 = MetodA; delege1();
            Delegem delege2 = MetodB; delege2();
            Delegem delege3 = MetodC; delege3();
            //Delegem delege4 = MetodD; delege4(); //A delege, yavrusu olmayan D-s�n�f metod �a�r�s�na derleme hatas� verir

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}