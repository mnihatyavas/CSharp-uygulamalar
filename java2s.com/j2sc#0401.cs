// j2sc#0401.cs: Çeþitli iþ(þart1){ifadeler}else if(þart2){ifadeler}...else{ifadeler} örneði.

using System;
namespace Ýfadeler {
    class Ýf {
        static void Main() {
            Console.Write ("if/eðer þart bool true/doðru ise takipeden tek yada bloklu çoklu ifadeler icra edilir. Sonrasýz, else/deðilse yada zincirleme else-if/deðilse-eðer sonralý kurulabilir.\nÝf bool-þartlarý: <, <=, >, >=, == veya != olabilir; bileþik mantýksal þartlar (&, &&, |, ||, ^, !) kurulabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int a=1881, b=1938, c;  
            if (a < b) Console.WriteLine ("a({0}) b({1})'den küçüktür.", a, b);
            if (a == b) Console.WriteLine ("Bu þart mevcut verilerle gerçekleþmez.");
            c = b - a;
            if (c >= 0) Console.WriteLine ("c=b-a={0}: negatif deðildir.", c); 
            if (c < 0) Console.WriteLine ("Bu þart oluþmaz.");
            c = a - b;
            if (c >= 0) Console.WriteLine ("Bu þart oluþmaz.");
            if (c < 0) Console.WriteLine ("c=a-b={0}: negatif'tir.", c);

            Console.WriteLine ("\n'if (true)' þartlý ifade iþletme:");
            bool b1 = true; if (b1) Console.WriteLine ("'if (b1:{0}) Bu ifade iþletilir.", b1);
            b1 = false; if (!b1) Console.WriteLine ("'if (!b1:!{0}) Bu ifade iþletilir.", b1);

            Console.WriteLine ("\nif-else ile negatif/pozitif sayýlarýn kontrolu:");
            for (a=-3; a <= 3; a++) {
                Console.Write ("Kontrol edilen " + a + ": ");
                if (a < 0) Console.WriteLine ("Bir negatif sayýdýr.");
                else Console.WriteLine ("Bir pozitif sayýdýr.");
            }

            Console.WriteLine ("\nif ile && ve || karmaþýk þartlý kontrollar:");
            if (a != b & b > c) Console.WriteLine ("int a = {0}", a);
            if ((a > c) || (a == b)) Console.WriteLine ("int b = {0}", b);
            if ((a >= c) && !(b <= c)) Console.WriteLine ("int c = {0}", c);

            Console.WriteLine ("\nif-else-if ile negatif/sýfýr/pozitif sayýlarýn kontrolu:");
            for (a=-3; a <= 3; a++) {
                Console.Write ("Kontrol edilen " + a + ": ");
                if (a < 0) Console.WriteLine ("Bir negatif sayýdýr.");
                else if (a == 0) Console.WriteLine ("Bir iþaretsiz sayýdýr.");
                else Console.WriteLine ("Bir pozitif sayýdýr.");
            }

            Console.WriteLine ("\nif-else {ifade; if} ile þart{çoklu ifade} yapýsý:");
            var r=new Random(); a=r.Next (0, 2);
            if (a == 0) b1=false; else b1=true;
            if (b > 2023) {Console.WriteLine ("int b > 2023");
            }else {
                Console.WriteLine ("int b <= 2023");
                if (b1) {Console.WriteLine ("bool b1 = {0}/kapalýdevre", b1);}
                else {Console.WriteLine ("bool b1 = {0}/açýkdevre", b1);}
            }

            Console.WriteLine ("\nif(þart){çoklu-ifade}else{çoklu-ifade} yapýsý:");
            a=r.Next(0,5); b=r.Next(0,5);
            if (a > b) {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'den", b);
                Console.Write (" BÜYÜKTÜR.");
            }else if (a == b) {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'ye", b);
                Console.Write (" EÞÝTTÝR.");
            }else {
                Console.Write ("a({0})", a);
                Console.Write (" b({0})'den", b);
                Console.Write (" KÜÇÜKTÜR.");
            }

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}