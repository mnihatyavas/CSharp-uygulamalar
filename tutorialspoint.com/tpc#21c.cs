// tpc#21c.cs: Temel sýnýfýn sanal metodunu türev sýnýf aþýrýyüklemeli metoduyla dinamik çoklu çaðýrma örneði.

using System;
namespace Çoklubiçim {
    class Þekil {
        protected int en, boy;
        public Þekil (int e = 0, int b = 0) {en = e; boy = b;}
        public virtual int alan() {Console.WriteLine ("\nEbeveyn sýnýfýn sanal alan() metodu:"); return 0;} // Fiili çaðrýlmaz
    }
    class Dikdörtgen: Þekil {
        public Dikdörtgen (int e = 0, int b = 0): base (e, b) {}
        public override int alan () {Console.WriteLine ("\n\nDikdörtgen sýnýfýnýn alan() metodu:"); return (en * boy);}
    }
    class DikÜçgen: Þekil {
        public DikÜçgen (int e = 0, int b = 0): base (e, b) {}
        public override int alan() {Console.WriteLine ("\nDikÜçgen sýnýfýnýn alan() metodu:"); return (en * boy / 2);}
    }
    class Çaðýran {public void alanýÇaðýran (Þekil þ) {Console.WriteLine ("Alan: {0}", þ.alan());} } 
    class DinamikSanalMetod {
        static void Main() {
            Console.Write ("Farklý türev sýnýflarda farklý biçimde kullanýlacak aþýrýyüklenen fonksiyon temel sýnýfta virtual/sanal ve içi boþ kalýp olarak tanýmlanýr. Dinamik çoklubiçim soyut ve sanal fonksiyonlarca yürütülür.\nTuþ..."); Console.ReadKey();

            Çaðýran ç = new Çaðýran();
            Dikdörtgen dd = new Dikdörtgen (15, 6);
            DikÜçgen dü = new DikÜçgen (15, 6);
            ç.alanýÇaðýran (dd);
            ç.alanýÇaðýran (dü);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}