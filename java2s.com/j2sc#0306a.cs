// j2sc#0306a.cs: Ba��nt�sal i�lemcilerle se�ici bilgiye eri�me �rne�i.

using System;
namespace ��lemciler {
    class Mant�ksalBa��nt�sal��lemci1 {
        static void Main() {
            Console.Write ("Ba��nt�sal i�lemciler: ==, !=, >, <, >=, <=.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int a=10, b=20;
            bool c=false;
            Console.WriteLine ("K�sadevre &&'de ilk false, ||'da ilk true, !'da false yeterlidir:");
            if (!(a < 10 && b < 30)) c = true;
            Console.WriteLine ("K�sadevre: '!(a({0}) < 10 && b({1}) < 30)'? {2}", a, b, c);
            if (a < 15 || b < 20) c = true;
            Console.WriteLine ("K�sadevre: 'a < 15 || b < 20'? {0}", c);
            if (!(a == 15)) c = true;
            Console.WriteLine ("NOT false: '!(a == 15)'? {0}", c);

            string sonu�="";
            Console.WriteLine ("\nif-else ile t�m ba��nt�sal i�lemcilerin denenmesi:");
            if (a > b) {sonu� = "a > b"; goto yaz1;}
            else if (b < a) {sonu� = "b < a"; goto yaz1;}
            else if (a >= b) {sonu� = "a >= b"; goto yaz1;}
            else if (b <= a) {sonu� = "b <= a"; goto yaz1;}
            else if (b != a) {sonu� = "b != a"; goto yaz1;}
            else if (a == b) sonu� = "a == b";
            yaz1: Console.WriteLine ("a({0}) ve b({1}) i�in sonu� = \"{2}\"", a, b, sonu�);

            Console.WriteLine ("\na = {0} ve b = {1} ise:", a, b);
            if (a < b) Console.WriteLine ("a < b");
            if (a <= b) Console.WriteLine("a <= b");
            if (a != b) Console.WriteLine ("a != b");
            if (a == b) Console.WriteLine ("Bu i�letilmez");
            if (a >= b) Console.WriteLine ("Bu i�letilmez");
            if (a > b) Console.WriteLine ("Bu i�letilmez");
 
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}