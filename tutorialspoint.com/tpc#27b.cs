// tpc#27b.cs: Try-catch bloðuyla özel throw fýrlatarak sýfýra bölüm hatasýnýn yakalanmasý örneði.

using System;
namespace ÝstisnaYönetimi {
    class FýrlatýlanHata {
        public void göster (int a, int b) {
            try {new Bölüm().böl (a, b);
            } catch (SýfýraBölümÝstisnasý hata) {Console.WriteLine ("SýfýraBölümÝstisnasý ({0}/{1}): {2}", a, b, hata.Message);}
        }
        static void Main() {
            Console.Write ("Exeption/Ýstisna temel sýnýfýyla kendi özel hata fýrlatma/throw türev-sýnýfýmýzý yarabiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            new FýrlatýlanHata().göster (25, 0);
            new FýrlatýlanHata().göster (25, 5);
            new FýrlatýlanHata().göster (0, 0);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
    public class SýfýraBölümÝstisnasý: Exception {public SýfýraBölümÝstisnasý (string mesaj): base (mesaj){} }
    public class Bölüm {
        public void böl (int pay, int payda) {
            if (payda == 0) {throw (new SýfýraBölümÝstisnasý ("Sýfýra bölüm hatasý bulundu!.."));
            } else {Console.WriteLine ("[{0}/{1}] bölüm sonucu: {2}", pay, payda, pay/payda);}
        }
    }
}