// j2sc#0410.cs: Using aduzam.sýnýf ile arþiv veya özel tiplemelerin tanýmýný kýsaltma örneði.

using System;
using System1 = System;              
using Konsol1 = System.Console;
using Sayaç;
using Say = Sayaç.Sýnýf2;
namespace Sayaç {class Sýnýf2{public Sýnýf2(){Console.WriteLine ("Sayaç.Sýnýf2 Kurucusu");}} }
namespace Ýfadeler {
    public class Sýnýf1 : IDisposable {
        public Sýnýf1() {Console.WriteLine ("Kurucu");} //Nesne tiplemesinde otomatikmen iþletilir.
        ~Sýnýf1() {Console.WriteLine ("Yýkýcý");} //Program sonlanmasýnda nesne silinirken otomatikmen iþletilir.
        public void Dispose() {Console.WriteLine ("IDisposable.Dispose() metodunun using'le otomatikmen yürütülmesi.");}
        public void Metot() {Console.WriteLine ("Tiplemeyle çaðrýlýrsa iþletilir.");}
    }
    class Using {
        static void Main() {
            Console.Write ("'using' aduzam/namespace, alias/arma=ad, ve bazý metodlarýn otomatikmen yürütülmesinde kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ebeveyn IDisposable sýnýfýn Dispose() metodunun otomatik yürütülmesi:");
            using (Sýnýf1 Nesne1 = new Sýnýf1()){}
            Sýnýf1 Nesne2 = new Sýnýf1();
            Sýnýf1 Nesne3 = new Sýnýf1();
            using (Sýnýf1 Nesne4 = new Sýnýf1()){}
            Nesne2.Metot();

            Console.WriteLine ("\nSystem ve System.Console için 'using' ad kullanýlmasý:");
            System.Console.WriteLine ("System.Console.WriteLine ile yazdýrma");
            System1.Console.WriteLine ("System1.Console.WriteLine ile yazdýrma");
            Konsol1.WriteLine ("Konsol1.WriteLine ile yazdýrma");

            Console.WriteLine ("\nÖzel aduzam:Sayaç ve sýnýfý:Sýnýf2 için using'le nesnelerini yaratma:");
            Sýnýf2 ns1 = new Sýnýf2();
            Say ns2 = new Say();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}