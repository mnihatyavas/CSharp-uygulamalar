// j2sc#0117.cs: 'try-catch' ile çalýþmazamanlý istisnalarýn idaresi örneði.

using System;
namespace DilTemelleri {
    class Ýstisna {
        public static void GeçersizDiziElemanýnaEriþim() {
            int[] tsDizi = new int [20]; //[0-->19]
            try {// Ýstisna çaðrýlan metotda yönetiliyor.
                Console.WriteLine ("Geçersiz dizi elemana eriþim deneniyor.");
                tsDizi [20] = 2020;
            }catch (IndexOutOfRangeException h) {
                Console.WriteLine ("IndexOutOfRangeException istisnasý yönetiliyor.");
                Console.WriteLine ("Hata mesajý = [{0}]", h.Message);
                Console.WriteLine ("Yýðýn izi = [{0}]", h.StackTrace);
            }
        }
        public static void SýfýraBölüm() {
            int sýfýr = 0;
            Console.WriteLine ("Sýfýra bölüm deneniyor.");
            int sonuç = 1 / sýfýr;
        }
        public static int ÝstisnaFýrlatanMetot (int n) {
            if (n == 0) throw new DivideByZeroException ("0 ile bölüm özel istisnasý fýrlatýldý!");
            int x = 2020 / n;
            return x;
        }
        static void Main() {
            Console.Write ("Tüm çalýþmazamanlý istisnalar System.Exception'dan türetilir. Ýstisna yönetimi try-catch için genel Exception, yada diðer odaklý istisnalar (ArrayTypeMismatchException, DivideByZeroException, IndexOutOfRangeException, InvalidCastException, OutOfMemoryException, OverflowException, NullReferenceException, StackOverflowException) veya kendi özel tanýmlý istisnanýzý fýrlatabilirsiniz. Ýstisna özellikleri: Message, StackTrace, TargetSite, TargetSite.DeclaringType, TargetSite.MemberType, Source, HelpLink; metodu: ToString().\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int Sýfýr = 0;
            try {int j = 1 / Sýfýr;
            }catch (DivideByZeroException hata) {Console.WriteLine ("DivideByZero/SýfýraBölüm hatasý: [{0}]", hata);
            }catch (Exception hata) {Console.WriteLine ("Exception/Ýstisna hatasý: [{0}]", hata);}

            try {
                var tsDizi = new int [4];
                Console.WriteLine ("\nEndeks taþma istisnasý öncesi...");
                for (int i=0; i < 10; i++) {tsDizi [i] = i;}
            }catch (IndexOutOfRangeException hata) {
                Console.WriteLine ("Standart hata mesajý: [{0}]", hata);
                Console.WriteLine ("Yýðýn izi: [{0}]", hata.StackTrace);
                Console.WriteLine ("Mesaj: [{0}]", hata.Message);
                Console.WriteLine ("Hedef site: [{0}]", hata.TargetSite);
                Console.WriteLine ("Ýstisnanýn tanýmlý sýnýfý: [{0}]", hata.TargetSite.DeclaringType);
                Console.WriteLine ("Ýstisna sýnýf üye tipi: [{0}]", hata.TargetSite.MemberType);
                Console.WriteLine ("Kaynak: [{0}.cs]", hata.Source);
                Console.WriteLine ("Yardým baðlantýsý: [{0}]", hata.HelpLink);
            }  
            Console.WriteLine ("Try-catch istisna yönetimi sonrasý...");

            Console.WriteLine ("\nGeçersizDiziElemanýnaEriþim() metodu çaðrýlýyor...");
            GeçersizDiziElemanýnaEriþim();
            try {// Çaðrýlan metotda fýrlatýlan istisna çaðýran metotda yönetiliyor.
                Console.WriteLine ("\nSýfýraBölüm() metodu çaðrýlýyor...");
                SýfýraBölüm();
            }catch (DivideByZeroException h) {
                Console.WriteLine ("DivideByZeroException istisnasý yönetiliyor.");
                Console.WriteLine ("Hata mesajý = [{0}]", h.Message);
                Console.WriteLine ("Yýðýn izi = [{0}]", h.StackTrace);
            }

            try {
                Console.WriteLine ("\nBölüm sonucu = {0}", ÝstisnaFýrlatanMetot (10)); //Sorunsuz
                Console.WriteLine ("Bölüm sonucu = {0}", ÝstisnaFýrlatanMetot (20)); //Sorunsuz
                Console.WriteLine ("Bölüm sonucu = {0}", ÝstisnaFýrlatanMetot (0)); //Ýstisna fýrlattý
            }catch (Exception h) {Console.WriteLine ("Fýrlatýlan bir istisna yakalandý: [{0}]\nProgram akýþý devam ediyor", h);}
            Console.WriteLine ("Try-catch tamamlandý...");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}