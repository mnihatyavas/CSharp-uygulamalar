// tpc#03b.cs: Ana program A s�n�f�ndan altprogram B s�n�fl� metodu �a��rma �rne�i.
// ">csc /r:tpc#03bx.dll tpc#03b.cs" ve ">tpc#03b" Enter'la

using System;
namespace ProgramYap�s� {
    class A {
        static void Main (string[] args) {
            Console.WriteLine ("�uanda A i�indeyim.");
            var b = new B();
            b.metod2();
            Console.ReadKey();
        }
    }
}