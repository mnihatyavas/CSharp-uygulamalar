// j2sc#0120.cs: Þarta baðlý olarak throw'la fýrlatýlan özel açýklamalý istisna örneði.

using System;
namespace DilTemelleri {
    class Throw {
        public static int ThrowFonksiyonu (int bölen) {
            if (bölen == 0) throw new DivideByZeroException ("Sýfýra bölüm hatasý fýrlatýldý!");
            int x = 20 / bölen;
            return x;
        }
        static void Main() {
            Console.Write ("Bir alt fonksiyonda try-catch kullanýlmadan þarta baðlý olarak fýrlatýlan ve istenilen özelleþtirilmiþ hata mesajýný içeren 'throw' çaðýran program tarafýndan (istenirse) yönetilebilmektedir. Throw istisna fýrlatýlýnca kalan kodlama iþletilmeden geridönülür; yönetilmezse akýþ devam etmez.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int bölüm; var r=new Random();
            for (int i=0; i<20; i++) {try {bölüm = ThrowFonksiyonu (r.Next(0, 10)); Console.WriteLine ("Bölüm sonucu = {0}", bölüm);}catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);} }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}