// j2sc#0122.cs: Throw ile fýrlatýlan Exception ve türevleri örneði.

using System;
using System.Collections;
namespace DilTemelleri {
    public class Ortalama {
        public void OrtalamayýHesapla() {
            try {
                int adet = 0;
                int ortalama = (10+20+60) / adet;
            }catch (DivideByZeroException h) {throw (new DivideByZeroException ("ortalama paydasýndaki adet=3 olmalýydý", h));}
        }
    }
    class ÝstisnaFýrlatýþ {
        public static void YenidenFýrlatýlanÝstisna() {
            int[] tsDizi = {4, 8};
            int d = 0;
            for (int i=0; i < 1000; i++) {
                try {Console.WriteLine (tsDizi [i] /d); d=2; //Buna ulaþýlmaz
                }catch (DivideByZeroException) {Console.WriteLine ("Sýfýra bölüm hatasý yakalandý (for döngüye devam)!");
                }catch (IndexOutOfRangeException) {
                    Console.WriteLine ("Dizi endeksi taþma hatasý yakalandý (for döngüsü kýrýlýr)!");
                    throw; //Bu istisna tekrar fýrlatýldý
                } 
            }
        }
        public static void Topla (int x,int y, out int toplam) {toplam = x + y;}
        static void Main() {
            Console.Write ("'throw new istisna' ile fýrlatýlan sýnýf nesnesi 'Exception' veya ondan türetilen mevcut istisnalardan biri olmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            try {Console.WriteLine ("Throw öncesi...");
                throw new DivideByZeroException ("Sýfýra bölüm istisnasý fýrlatýldý.");
                Console.WriteLine ("Throw sonrasý..."); //Buraya ulaþýlmaz
            }catch (DivideByZeroException hata) {Console.WriteLine ("Throw'la fýrlatýlan istisna yakalandý: [{0}]", hata.Message);}
            Console.WriteLine ("Try-catch bloðu sonrasý...\n");

            try {YenidenFýrlatýlanÝstisna();
            }catch (IndexOutOfRangeException h) {Console.WriteLine ("***Tekrar fýrlatýp yakalanan (kýrýcý) hata: [{0}]", h.Message);}

            var ort = new Ortalama();
            try {ort.OrtalamayýHesapla();
            }catch (Exception h) {Console.WriteLine ("\nYakalanýp yeniden fýrlatýlan hata: [{0}]\n", h);}

            try {
                try {var liste = new ArrayList();
                    liste.Add (1881); liste.Add (1938); liste.Add (2023);
                    Console.WriteLine ("Listenin 1, 2 ve 3.ncü birimleri = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                    Console.WriteLine ("Listenin 10.ncu birimi = {0}", liste [9]);
                }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("Ýstisna: [{0}]", h);
                }finally {Console.WriteLine ("Bellek temizliði yapýlýyor..." );
                    throw new Exception ("Finally blokta istisna fýrlatmayý seviyorum!");
                }
            }catch (Exception h) {Console.WriteLine ("Ýç finally blokta fýrlatýlan istisna: [{0}]", h.Message);}

            try {var istisnam = new Exception ("Benim özel istisnamsýn!");
                istisnam.HelpLink = "Readme.txt dosyasýna bakýnýz";
                istisnam.Source = "j2sc#0122.cs programý";
                throw istisnam;
            }catch (Exception h) {
                Console.WriteLine ("\nYardým baðlantýsý = " + h.HelpLink);
                Console.WriteLine ("Mesaj = " + h.Message);
                Console.WriteLine ("Kaynak = " + h.Source);
                Console.WriteLine ("Yýðýn izi = " + h.StackTrace);
                Console.WriteLine ("Hedef site = " + h.TargetSite);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}