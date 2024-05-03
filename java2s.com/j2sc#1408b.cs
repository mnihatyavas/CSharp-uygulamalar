// j2sc#1408b.cs: GC.Dispose(), Guid, BooleanSwitch ve PrinterSettings �rne�i.

using System;
using System.Diagnostics; //BooleanSwitch i�in
using System.Drawing.Printing; //PrinterSettings i�in
namespace Geli�imler {
    public class Araba : IDisposable {
        public Araba() {Console.WriteLine ("Kurucuday�m!");}
        ~Araba() {Console.WriteLine ("Y�k�c�day�m!");}
        public void Dispose() {Console.WriteLine ("Elle temizlik-1!"); GC.SuppressFinalize (this);}
        public void Temizle() {Console.WriteLine ("Elle temizlik-2!"); GC.SuppressFinalize (this);}
    }
    class Nesne {
        public Nesne() {Console.WriteLine ("Nesne yarat�ld�");}
        ~Nesne() {Console.WriteLine ("Nesne imha edildi");}
    }
    class �e�itliB {
        static BooleanSwitch dyD��me = new BooleanSwitch ("Veri", "Mod�l");
        static void Main() {
            Console.Write ("nesne.Dispose()'la kontrollu temizlik, ~Araba()'le program sonlan�rken elle temizlenmeyenlerin otomatik temizlik yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��p temizleyicinin bellek art���/azal���na etkisi:");
            long ls=GC.GetTotalMemory (false);
            Console.WriteLine ("Bu program i�in gereken bellek: {0} Byte", ls);
            Console.WriteLine ("GC.Collect() zorluyor...");
            GC.Collect();
            Console.WriteLine ("Tekrar bellek �l��m�: {0} Byte\nGC art���/azal���: {1} Byte", GC.GetTotalMemory (false), GC.GetTotalMemory (false) - ls);

            Console.WriteLine ("\nDispose/Temizle ve ~Araba() y�k�c�yla nesnelerin bellekten temizli�i:");
            Araba arb1, arb2, arb3, arb4, arb5, arb6, arb7, arb8, arb9, arb10;
            arb1 = new Araba(); arb2 = new Araba(); arb3 = new Araba(); arb4 = new Araba(); arb5 = new Araba();
            Console.WriteLine ("\t�lk 5 araban�n �retimi");
            Console.WriteLine ("arb1 �retiliyor", GC.GetGeneration (arb1));
            Console.WriteLine ("arb2 �retiliyor", GC.GetGeneration (arb2));
            Console.WriteLine ("arb3 �retiliyor", GC.GetGeneration (arb3));
            Console.WriteLine ("arb4 �retiliyor", GC.GetGeneration (arb4));
            Console.WriteLine ("arb5 �retiliyor", GC.GetGeneration (arb5));
            Console.WriteLine ("\tArabalar�n Dispose()/Temizle()'yle elle imhas�");
            arb1.Temizle(); arb2.Temizle(); arb3.Temizle(); arb4.Dispose(); arb4.Dispose();
            Console.WriteLine ("\t�kinci 5 araban�n �retimi");
            arb6 = new Araba(); arb7 = new Araba(); arb8 = new Araba(); arb9 = new Araba(); arb10 = new Araba();
            Console.WriteLine ("\t�kinci 5 araba program sonlan�rken y�k�c�yla otomatikmen imha edilecek");

            Console.WriteLine ("\nNesnelerin null ve GC.Collect()'le temizli�i:");
            Nesne ns; int i;
            for(i=0;i<5;i++) {ns = new Nesne(); ns = null; GC.Collect();} //Yarat�ld� ve imha edildi
            for(i=0;i<5;i++) {ns = new Nesne();} //Yarat�ld�lar, sonlan�rken imha edilecekler
            object nesne = new object();
            WeakReference zay�fRef = new WeakReference (nesne);
            Console.WriteLine ("Zay�f referansl� nesne canl� m�?: {0}", zay�fRef.IsAlive);
            GC.Collect();
            Console.WriteLine ("GC.Collect() sonras� hala canl� m�?: {0}", zay�fRef.IsAlive);

            Console.WriteLine ("\nGraphicalUserInterface Guid.NewGuid() ile kimlik no �retimi:");
            Guid no = Guid.NewGuid();
            Console.WriteLine ("Her ko�turmada farkl� Guid no: " +  no);

            Console.WriteLine ("\nBooleanSwitch.Enabled/TrueFalse ile hata olu�mas�n�n kontrolu:");
            if (!dyD��me.Enabled) Console.WriteLine ("!BooleanSwitch.Enabled: Hen�z hata olu�mad�!");
            dyD��me.Enabled = true;
            if (dyD��me.Enabled) Console.WriteLine ("BooleanSwitch.Enabled: Hata olu�tu!");

            Console.WriteLine ("\nBilgisayar�n�zdaki yaz�c�lar, ��z�n�rl�kleri ve ka��t ebatlar�:");
            PrinterSettings yaz�c� = new PrinterSettings();
            i=0; foreach (string yaz�c�Ad� in PrinterSettings.InstalledPrinters) Console.WriteLine ("{0}.Yaz�c�: {1}", ++i, yaz�c�Ad�);
            i=0; foreach (string yaz�c�Ad� in PrinterSettings.InstalledPrinters) {
                Console.Write ("{0}.Yaz�c�: [{1}] ", ++i, yaz�c�Ad�);
                yaz�c�.PrinterName = yaz�c�Ad�;
                if (yaz�c�.IsValid) {
                    Console.WriteLine ("i�in desteklenen ��z�n�rl�kler:");
                    foreach (PrinterResolution ��z in yaz�c�.PrinterResolutions) Console.WriteLine ("\t{0}", ��z);
                }
            }
            i=0; foreach (string yaz�c�Ad� in PrinterSettings.InstalledPrinters) {
                Console.Write ("{0}.Yaz�c�: [{1}] ", ++i, yaz�c�Ad�);
                yaz�c�.PrinterName = yaz�c�Ad�;
                if (yaz�c�.IsValid) {
                    Console.WriteLine ("i�in desteklenen ka��t ebatlar�:");
                    foreach (PaperSize ebat in yaz�c�.PaperSizes) {
                        if (Enum.IsDefined (ebat.Kind.GetType(), ebat.Kind)) Console.WriteLine ("\t{0}", ebat);
                    }
                }
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}