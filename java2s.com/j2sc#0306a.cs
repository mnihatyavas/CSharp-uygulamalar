// j2sc#0306a.cs: Baðýntýsal iþlemcilerle seçici bilgiye eriþme örneði.

using System;
namespace Ýþlemciler {
    class MantýksalBaðýntýsalÝþlemci1 {
        static void Main() {
            Console.Write ("Baðýntýsal iþlemciler: ==, !=, >, <, >=, <=.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int a=10, b=20;
            bool c=false;
            Console.WriteLine ("Kýsadevre &&'de ilk false, ||'da ilk true, !'da false yeterlidir:");
            if (!(a < 10 && b < 30)) c = true;
            Console.WriteLine ("Kýsadevre: '!(a({0}) < 10 && b({1}) < 30)'? {2}", a, b, c);
            if (a < 15 || b < 20) c = true;
            Console.WriteLine ("Kýsadevre: 'a < 15 || b < 20'? {0}", c);
            if (!(a == 15)) c = true;
            Console.WriteLine ("NOT false: '!(a == 15)'? {0}", c);

            string sonuç="";
            Console.WriteLine ("\nif-else ile tüm baðýntýsal iþlemcilerin denenmesi:");
            if (a > b) {sonuç = "a > b"; goto yaz1;}
            else if (b < a) {sonuç = "b < a"; goto yaz1;}
            else if (a >= b) {sonuç = "a >= b"; goto yaz1;}
            else if (b <= a) {sonuç = "b <= a"; goto yaz1;}
            else if (b != a) {sonuç = "b != a"; goto yaz1;}
            else if (a == b) sonuç = "a == b";
            yaz1: Console.WriteLine ("a({0}) ve b({1}) için sonuç = \"{2}\"", a, b, sonuç);

            Console.WriteLine ("\na = {0} ve b = {1} ise:", a, b);
            if (a < b) Console.WriteLine ("a < b");
            if (a <= b) Console.WriteLine("a <= b");
            if (a != b) Console.WriteLine ("a != b");
            if (a == b) Console.WriteLine ("Bu iþletilmez");
            if (a >= b) Console.WriteLine ("Bu iþletilmez");
            if (a > b) Console.WriteLine ("Bu iþletilmez");
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}