// j2sc#0118.cs: Try-catch-finally anahtarkelimelerle istisnalarýn yönetilmesi örneði.

using System;
namespace DilTemelleri {
    class TryCatch {
        public static int Sýfýr = 0;
        static void Fonksiyon1() {
            try {int j = 22 / Sýfýr;
            }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("ArgumentOutOfRangeException hatasý: [{0}]", h.Message);} //Bu hata oluþmaz
            Console.WriteLine ("Fonksiyon1() içindeyim."); //Buraya ulaþmaz
        }
        static void Fonksiyon2() {
            var tsDizi = new int [4];
            Console.WriteLine ("Ýstisna üretilmeden öncesi...");
            for (int i=0; i < 10; i++) {//Yönetilmeyen IndexOutOfRangeException istisnasý
               tsDizi [i] = i*i*i;
               Console.WriteLine ("tsDizi [{0}]: {1}", i, tsDizi [i]);
            } 
        }
        static void Fonksiyon3() {
            int x = 1, y = 0;
            try {x = x/y;
            }catch (IndexOutOfRangeException) {Console.WriteLine ("Catch bloðu"); //Ýstisnayý yakalamaz
            }finally {Console.WriteLine ("Finally bloðu");}
        }
        static void Main() {
            Console.Write ("Çalýþmazamanlý istisnalar, program akýþýnýn kýrýlmamasý için: try-catch-finally anahtarkelimeleriyle yönetilir. Bunlarla yönetilmeyen istisna hatayý yansýtarak programý sonlandýrýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Try-catch ÖNCESÝ...");
            try {int j = 22 / Sýfýr; //Hata yakalar
                Console.WriteLine ("Buraya ULAÞMAZ...");
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message);}
            Console.WriteLine ("Try-catch SONRASI...");

            try {int i = 1/Sýfýr;
                Console.WriteLine ("Buraya ULAÞMAZ...");
            }catch (DivideByZeroException) {Console.WriteLine ("\nHATA: [{0}]", "Sýfýra bölüm hatasý!");}

            var tsDizi1 = new int[]{4, 8, 16}; Console.WriteLine();
            for (int i=0; i < 5; i++) {
                try {Console.WriteLine (tsDizi1 [i]/Sýfýr);
                }catch (DivideByZeroException) {Console.WriteLine ("Sýfýra bölüm hatasý!");
                }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizide endeks taþma hatasý!");}
            }

            int[] tsDizi2 = {4, 8}; Console.WriteLine();
            for (int i=0; i < 4; i++) {
                try {Console.WriteLine (tsDizi2 [i]/Sýfýr);
                }catch {Console.WriteLine ("Bir hata oluþtu!");}
            }

            try {Console.WriteLine(); //Dýþ try
                for(int i=0; i < 5; i++) {
                    try {//Ýç try
                        Console.WriteLine (tsDizi1 [i]/Sýfýr);
                    }catch (DivideByZeroException) {Console.WriteLine ("Sýfýra bölüm hatasý!");
                    }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizide endeks taþma hatasý!");}
                }
            }finally {Console.WriteLine ("Vahim hatalar oluþtu!");}

            try {Fonksiyon1();
            }catch (ArgumentException h) {Console.WriteLine ("ArgumentException hatasý: [{0}]", h.Message); //Bu hata oluþmaz
            }catch (Exception h){Console.WriteLine ("\nException hatasý: [{0}]", h.Message);} //Bu hata oluþur

            try {Console.WriteLine ("\nTry bloðunda, sýfýra bölüm arifesindeyim");
                int j = 1 / Sýfýr;
                Console.WriteLine ("Hata oluþtuðundan, buraya ulaþýlmaz, catch'e atlar");
            }catch {Console.WriteLine ("Catch bloðundayým, bir istisna fýrlatýldý");
            }finally {Console.WriteLine ("Finally bloðundayým, son bellek temizliði yapýlabilir");}

            try {Console.WriteLine ("\nTry bloðunda, sýfýra bölüm arifesindeyim");
                int j = 1 / Sýfýr;
            }catch (DivideByZeroException h) {
                Console.WriteLine ("Hata mesajý: [{0}]", h.Message);
                Console.WriteLine ("Yýðýn izi: [{0}]", h.StackTrace);
            }

            while (true) {
                Gir: Console.Write ("\nSeç [1, 2, 9=Son]: ");
                try {Sýfýr = Convert.ToInt32 (Console.ReadLine());}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message); goto Gir;}
                if (Sýfýr == 9) break;
                if (Sýfýr < 1 || Sýfýr > 2) goto Gir;
                if (Sýfýr == 1) Fonksiyon2(); else Fonksiyon3();
            }

            try {string dizge = null; dizge.ToUpper();
            }catch (NullReferenceException) {Console.WriteLine ("\nCatch bloðunda NullReferenceException istisnasý.");
            }finally {Console.WriteLine ("Finally bloðunda son try-catch-finally iþlemleri.");}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}