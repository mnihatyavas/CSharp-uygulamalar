// j2sc#1408e.cs: Action, Context, EventArgs, Evidence, Installer �rne�i.

using System;
using System.Windows.Forms; //MessageBox i�in
using System.Threading; //Thread i�in
using System.Runtime.Remoting.Contexts; //[Synchronization] i�in
using System.Reflection; //Assembly i�in
using System.Collections; //IEnumerator i�in
using System.Security.Policy; //Evidence i�in
using System.Configuration.Install; //Installer i�in
using System.Diagnostics; //EventLogInstaller i�in
using System.ComponentModel; //[RunInstaller] i�in
using System.Runtime.CompilerServices; //RuntimeHelpers i�in
namespace Geli�imler {
    public class Araba1 {
        public Araba1() {//Kurucu
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("{0} s�n�f nesnesi {1} i�erikNo'dad�r.", this.ToString(), i�rk.ContextID);
            foreach (IContextProperty i��z in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik ad�: {0}", i��z.Name);
        }
    }
    [Synchronization]
    public class Araba2 : ContextBoundObject {
        public Araba2() {//Kurucu
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("{0} s�n�f nesnesi {1} i�erikNo'dad�r.", this.ToString(), i�rk.ContextID);
            foreach (IContextProperty i��z in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik ad�: {0}", i��z.Name);
        }
    }
    public delegate void YetersizBakiye (object ns, Bankac�l�kOlay� olay);
    public class Banka {
        public event YetersizBakiye D���kFon;
        private decimal bakiye = 0;
        public decimal Bakiye {get {return bakiye;}}
        public decimal Yat�r�lan (decimal tutar) {bakiye += tutar; return bakiye;}
        public decimal �ekilen (decimal tutar) {
            decimal sonBakiye = bakiye - tutar;
            if (sonBakiye < 0) {
                if (D���kFon != null) {
                    Bankac�l�kOlay� arg�manlar = new Bankac�l�kOlay� (Bakiye, tutar);
                    D���kFon (this, arg�manlar);
                }
                return bakiye;
            }
            return bakiye = sonBakiye;
        }
    }
    public class Bankac�l�kOlay� : EventArgs {
        private decimal bakiye;
        public decimal Bakiye {get {return bakiye;}}
        private decimal i�lem;
        public decimal ��lem {get {return i�lem;}}
        public Bankac�l�kOlay� (decimal bky, decimal i�lm) {//Kurucu
            bakiye = bky;
            i�lem = i�lm;
        }
    }
    [RunInstaller (true)]
    class �e�itliE : Installer {
        private static void PencereMesaj� (string msj) {MessageBox.Show (msj);}
        public static void D���kFonY�netimi (object ns, Bankac�l�kOlay� oly) {
            Console.WriteLine ("D���kFon ��lemi olu�tu...");
            Console.WriteLine ("Bakiye: {0:#,00.00}TL", oly.Bakiye);
            Console.WriteLine ("��lem: {0:#,00.00}TL",oly.��lem);
        }
        EventLogInstaller kurucum = new EventLogInstaller();
        public override void Install (IDictionary sakl�Durum) {//Kur
            kurucum.Log = "log";
            kurucum.Source = "MySource";
            Installers.Add (kurucum);
            base.Install (sakl�Durum);
        }
        public override void Commit (IDictionary sakl�Durum) {base.Commit (sakl�Durum);} //Onay
        public override void Rollback (IDictionary sakl�Durum) {base.Rollback (sakl�Durum);}
        public override void Uninstall (IDictionary sakl�Durum) {//S�k
            kurucum.Source = "MySource";
            kurucum.UninstallAction = System.Configuration.Install.UninstallAction.NoAction;
            Installers.Add (kurucum);
            base.Uninstall (sakl�Durum);
        }
        static void Main() {// Main(string[] args) gerekmez
            Console.Write ("Action, Context, EventArgs, Evidence, Installer, PerformanceCounterCategory ve RuntimeHelpers.GetHashCode uygulamalar� i�in verili �rneklere bak�n.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Action<string>'le �artl� metotlar y�r�t�lebilir:");
            Action<string> mesajHedefi; //"c#>j2sc#1408e M. Nihat Yava�" komut sat�r arg�manl� da ko�tur
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = PencereMesaj�;
            else mesajHedefi = Console.WriteLine;
            mesajHedefi ("Merhaba, ben Action'la hedeflenen metodum!");
            Console.WriteLine ("\tDelegeli mesajHedefi atamas�:");
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = delegate (string msj) {MessageBox.Show (msj);};
            else mesajHedefi = delegate (string msj) {Console.WriteLine (msj);};
            mesajHedefi ("Merhaba, ben Action'la delegeli hedeflenen metodum!");
            Console.WriteLine ("\t'mesaj=>' ile mesajHedefi atamas�:");
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = mesaj=>{MessageBox.Show (mesaj);};
            else mesajHedefi = mesaj=>{Console.WriteLine (mesaj);};
            mesajHedefi ("Merhaba, ben Action'la 'mesaj=>' y�ntemiyle hedeflenen metodum!");

            Console.WriteLine ("\nAraba1/2 i�erik/sicim-no ve i�erik �zellik adlar�:");
            Araba1 a11 = new Araba1(); Araba1 a12 = new Araba1(); a12 = new Araba1();
            Araba2 a21 = new Araba2(); Araba2 a22 = new Araba2(); a22 = new Araba2();

            Console.WriteLine ("\nBanka hesab�ndaki yetersiz bakiye olay y�netimi:");
            Banka hesab�m = new Banka();
            hesab�m.D���kFon += D���kFonY�netimi;
            hesab�m.Yat�r�lan (50000.75m);
            hesab�m.�ekilen (17500.15m); hesab�m.�ekilen (22500.45m); hesab�m.�ekilen (12000.65m);

            Console.WriteLine ("\nSystem.Security.Policy.GacInstalled/Url/Zone/Hash/Publisher delil bilgileri:");
            Type nesnelTip = Type.GetType ("System.Object");
            Assembly nesnelKurgu = Assembly.GetAssembly (nesnelTip);
            Evidence nesnelDelil = nesnelKurgu.Evidence;
            IEnumerator delilEnum = nesnelDelil.GetEnumerator();
            while (delilEnum.MoveNext()) Console.WriteLine (delilEnum.Current);

            Console.WriteLine ("\nKurulum/s�k�l�m programla s�zl�k.exe kurma/s�kme:");
            Console.WriteLine ("Kurulum s�zdizimi: installer.exe s�zl�k.exe");
            Console.WriteLine ("S�k�m s�zdizimi: uninstaller.exe s�zl�k.exe");

            Console.WriteLine ("\nPerformansSaya�Katagorisi ve makine ad�, yard�m metni:");
            PerformanceCounterCategory pcc = new PerformanceCounterCategory();
            try {
                Console.WriteLine ("Katagori ad�:  {0}", pcc.CategoryName);
                Console.WriteLine ("Bilgisayar ad�:  {0}", pcc.MachineName);
                Console.WriteLine ("Katagori yard�m metni: {0}", pcc.CategoryHelp);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nRuntimeHelpers/Ko�uZamanl�Yard�mc�'n�n k�yma kodu:");
            int k�yma = RuntimeHelpers.GetHashCode (0);
            Console.WriteLine ("0 veya 20240413 i�in k�yma kodu: " + k�yma);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}