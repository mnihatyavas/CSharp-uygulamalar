// tpc#03b.cs: Ana program A sýnýfýndan altprogram B sýnýflý metodu çaðýrma örneði.
// ">csc /r:tpc#03bx.dll tpc#03b.cs" ve ">tpc#03b" Enter'la

using System;
namespace ProgramYapýsý {
    class A {
        static void Main (string[] args) {
            Console.WriteLine ("Þuanda A içindeyim.");
            var b = new B();
            b.metod2();
            Console.ReadKey();
        }
    }
}