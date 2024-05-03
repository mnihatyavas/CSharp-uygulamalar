// j2sc#1408b.cs: GC.Dispose(), Guid, BooleanSwitch ve PrinterSettings örneði.

using System;
using System.Diagnostics; //BooleanSwitch için
using System.Drawing.Printing; //PrinterSettings için
namespace Geliþimler {
    public class Araba : IDisposable {
        public Araba() {Console.WriteLine ("Kurucudayým!");}
        ~Araba() {Console.WriteLine ("Yýkýcýdayým!");}
        public void Dispose() {Console.WriteLine ("Elle temizlik-1!"); GC.SuppressFinalize (this);}
        public void Temizle() {Console.WriteLine ("Elle temizlik-2!"); GC.SuppressFinalize (this);}
    }
    class Nesne {
        public Nesne() {Console.WriteLine ("Nesne yaratýldý");}
        ~Nesne() {Console.WriteLine ("Nesne imha edildi");}
    }
    class ÇeþitliB {
        static BooleanSwitch dyDüðme = new BooleanSwitch ("Veri", "Modül");
        static void Main() {
            Console.Write ("nesne.Dispose()'la kontrollu temizlik, ~Araba()'le program sonlanýrken elle temizlenmeyenlerin otomatik temizlik yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çöp temizleyicinin bellek artýþý/azalýþýna etkisi:");
            long ls=GC.GetTotalMemory (false);
            Console.WriteLine ("Bu program için gereken bellek: {0} Byte", ls);
            Console.WriteLine ("GC.Collect() zorluyor...");
            GC.Collect();
            Console.WriteLine ("Tekrar bellek ölçümü: {0} Byte\nGC artýþý/azalýþý: {1} Byte", GC.GetTotalMemory (false), GC.GetTotalMemory (false) - ls);

            Console.WriteLine ("\nDispose/Temizle ve ~Araba() yýkýcýyla nesnelerin bellekten temizliði:");
            Araba arb1, arb2, arb3, arb4, arb5, arb6, arb7, arb8, arb9, arb10;
            arb1 = new Araba(); arb2 = new Araba(); arb3 = new Araba(); arb4 = new Araba(); arb5 = new Araba();
            Console.WriteLine ("\tÝlk 5 arabanýn üretimi");
            Console.WriteLine ("arb1 üretiliyor", GC.GetGeneration (arb1));
            Console.WriteLine ("arb2 üretiliyor", GC.GetGeneration (arb2));
            Console.WriteLine ("arb3 üretiliyor", GC.GetGeneration (arb3));
            Console.WriteLine ("arb4 üretiliyor", GC.GetGeneration (arb4));
            Console.WriteLine ("arb5 üretiliyor", GC.GetGeneration (arb5));
            Console.WriteLine ("\tArabalarýn Dispose()/Temizle()'yle elle imhasý");
            arb1.Temizle(); arb2.Temizle(); arb3.Temizle(); arb4.Dispose(); arb4.Dispose();
            Console.WriteLine ("\tÝkinci 5 arabanýn üretimi");
            arb6 = new Araba(); arb7 = new Araba(); arb8 = new Araba(); arb9 = new Araba(); arb10 = new Araba();
            Console.WriteLine ("\tÝkinci 5 araba program sonlanýrken yýkýcýyla otomatikmen imha edilecek");

            Console.WriteLine ("\nNesnelerin null ve GC.Collect()'le temizliði:");
            Nesne ns; int i;
            for(i=0;i<5;i++) {ns = new Nesne(); ns = null; GC.Collect();} //Yaratýldý ve imha edildi
            for(i=0;i<5;i++) {ns = new Nesne();} //Yaratýldýlar, sonlanýrken imha edilecekler
            object nesne = new object();
            WeakReference zayýfRef = new WeakReference (nesne);
            Console.WriteLine ("Zayýf referanslý nesne canlý mý?: {0}", zayýfRef.IsAlive);
            GC.Collect();
            Console.WriteLine ("GC.Collect() sonrasý hala canlý mý?: {0}", zayýfRef.IsAlive);

            Console.WriteLine ("\nGraphicalUserInterface Guid.NewGuid() ile kimlik no üretimi:");
            Guid no = Guid.NewGuid();
            Console.WriteLine ("Her koþturmada farklý Guid no: " +  no);

            Console.WriteLine ("\nBooleanSwitch.Enabled/TrueFalse ile hata oluþmasýnýn kontrolu:");
            if (!dyDüðme.Enabled) Console.WriteLine ("!BooleanSwitch.Enabled: Henüz hata oluþmadý!");
            dyDüðme.Enabled = true;
            if (dyDüðme.Enabled) Console.WriteLine ("BooleanSwitch.Enabled: Hata oluþtu!");

            Console.WriteLine ("\nBilgisayarýnýzdaki yazýcýlar, çözünürlükleri ve kaðýt ebatlarý:");
            PrinterSettings yazýcý = new PrinterSettings();
            i=0; foreach (string yazýcýAdý in PrinterSettings.InstalledPrinters) Console.WriteLine ("{0}.Yazýcý: {1}", ++i, yazýcýAdý);
            i=0; foreach (string yazýcýAdý in PrinterSettings.InstalledPrinters) {
                Console.Write ("{0}.Yazýcý: [{1}] ", ++i, yazýcýAdý);
                yazýcý.PrinterName = yazýcýAdý;
                if (yazýcý.IsValid) {
                    Console.WriteLine ("için desteklenen çözünürlükler:");
                    foreach (PrinterResolution çöz in yazýcý.PrinterResolutions) Console.WriteLine ("\t{0}", çöz);
                }
            }
            i=0; foreach (string yazýcýAdý in PrinterSettings.InstalledPrinters) {
                Console.Write ("{0}.Yazýcý: [{1}] ", ++i, yazýcýAdý);
                yazýcý.PrinterName = yazýcýAdý;
                if (yazýcý.IsValid) {
                    Console.WriteLine ("için desteklenen kaðýt ebatlarý:");
                    foreach (PaperSize ebat in yazýcý.PaperSizes) {
                        if (Enum.IsDefined (ebat.Kind.GetType(), ebat.Kind)) Console.WriteLine ("\t{0}", ebat);
                    }
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}