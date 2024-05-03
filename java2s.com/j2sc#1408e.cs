// j2sc#1408e.cs: Action, Context, EventArgs, Evidence, Installer örneði.

using System;
using System.Windows.Forms; //MessageBox için
using System.Threading; //Thread için
using System.Runtime.Remoting.Contexts; //[Synchronization] için
using System.Reflection; //Assembly için
using System.Collections; //IEnumerator için
using System.Security.Policy; //Evidence için
using System.Configuration.Install; //Installer için
using System.Diagnostics; //EventLogInstaller için
using System.ComponentModel; //[RunInstaller] için
using System.Runtime.CompilerServices; //RuntimeHelpers için
namespace Geliþimler {
    public class Araba1 {
        public Araba1() {//Kurucu
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("{0} sýnýf nesnesi {1} içerikNo'dadýr.", this.ToString(), içrk.ContextID);
            foreach (IContextProperty içöz in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik adý: {0}", içöz.Name);
        }
    }
    [Synchronization]
    public class Araba2 : ContextBoundObject {
        public Araba2() {//Kurucu
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("{0} sýnýf nesnesi {1} içerikNo'dadýr.", this.ToString(), içrk.ContextID);
            foreach (IContextProperty içöz in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik adý: {0}", içöz.Name);
        }
    }
    public delegate void YetersizBakiye (object ns, BankacýlýkOlayý olay);
    public class Banka {
        public event YetersizBakiye DüþükFon;
        private decimal bakiye = 0;
        public decimal Bakiye {get {return bakiye;}}
        public decimal Yatýrýlan (decimal tutar) {bakiye += tutar; return bakiye;}
        public decimal Çekilen (decimal tutar) {
            decimal sonBakiye = bakiye - tutar;
            if (sonBakiye < 0) {
                if (DüþükFon != null) {
                    BankacýlýkOlayý argümanlar = new BankacýlýkOlayý (Bakiye, tutar);
                    DüþükFon (this, argümanlar);
                }
                return bakiye;
            }
            return bakiye = sonBakiye;
        }
    }
    public class BankacýlýkOlayý : EventArgs {
        private decimal bakiye;
        public decimal Bakiye {get {return bakiye;}}
        private decimal iþlem;
        public decimal Ýþlem {get {return iþlem;}}
        public BankacýlýkOlayý (decimal bky, decimal iþlm) {//Kurucu
            bakiye = bky;
            iþlem = iþlm;
        }
    }
    [RunInstaller (true)]
    class ÇeþitliE : Installer {
        private static void PencereMesajý (string msj) {MessageBox.Show (msj);}
        public static void DüþükFonYönetimi (object ns, BankacýlýkOlayý oly) {
            Console.WriteLine ("DüþükFon Ýþlemi oluþtu...");
            Console.WriteLine ("Bakiye: {0:#,00.00}TL", oly.Bakiye);
            Console.WriteLine ("Ýþlem: {0:#,00.00}TL",oly.Ýþlem);
        }
        EventLogInstaller kurucum = new EventLogInstaller();
        public override void Install (IDictionary saklýDurum) {//Kur
            kurucum.Log = "log";
            kurucum.Source = "MySource";
            Installers.Add (kurucum);
            base.Install (saklýDurum);
        }
        public override void Commit (IDictionary saklýDurum) {base.Commit (saklýDurum);} //Onay
        public override void Rollback (IDictionary saklýDurum) {base.Rollback (saklýDurum);}
        public override void Uninstall (IDictionary saklýDurum) {//Sök
            kurucum.Source = "MySource";
            kurucum.UninstallAction = System.Configuration.Install.UninstallAction.NoAction;
            Installers.Add (kurucum);
            base.Uninstall (saklýDurum);
        }
        static void Main() {// Main(string[] args) gerekmez
            Console.Write ("Action, Context, EventArgs, Evidence, Installer, PerformanceCounterCategory ve RuntimeHelpers.GetHashCode uygulamalarý için verili örneklere bakýn.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Action<string>'le þartlý metotlar yürütülebilir:");
            Action<string> mesajHedefi; //"c#>j2sc#1408e M. Nihat Yavaþ" komut satýr argümanlý da koþtur
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = PencereMesajý;
            else mesajHedefi = Console.WriteLine;
            mesajHedefi ("Merhaba, ben Action'la hedeflenen metodum!");
            Console.WriteLine ("\tDelegeli mesajHedefi atamasý:");
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = delegate (string msj) {MessageBox.Show (msj);};
            else mesajHedefi = delegate (string msj) {Console.WriteLine (msj);};
            mesajHedefi ("Merhaba, ben Action'la delegeli hedeflenen metodum!");
            Console.WriteLine ("\t'mesaj=>' ile mesajHedefi atamasý:");
            if (Environment.GetCommandLineArgs().Length > 1) mesajHedefi = mesaj=>{MessageBox.Show (mesaj);};
            else mesajHedefi = mesaj=>{Console.WriteLine (mesaj);};
            mesajHedefi ("Merhaba, ben Action'la 'mesaj=>' yöntemiyle hedeflenen metodum!");

            Console.WriteLine ("\nAraba1/2 içerik/sicim-no ve içerik özellik adlarý:");
            Araba1 a11 = new Araba1(); Araba1 a12 = new Araba1(); a12 = new Araba1();
            Araba2 a21 = new Araba2(); Araba2 a22 = new Araba2(); a22 = new Araba2();

            Console.WriteLine ("\nBanka hesabýndaki yetersiz bakiye olay yönetimi:");
            Banka hesabým = new Banka();
            hesabým.DüþükFon += DüþükFonYönetimi;
            hesabým.Yatýrýlan (50000.75m);
            hesabým.Çekilen (17500.15m); hesabým.Çekilen (22500.45m); hesabým.Çekilen (12000.65m);

            Console.WriteLine ("\nSystem.Security.Policy.GacInstalled/Url/Zone/Hash/Publisher delil bilgileri:");
            Type nesnelTip = Type.GetType ("System.Object");
            Assembly nesnelKurgu = Assembly.GetAssembly (nesnelTip);
            Evidence nesnelDelil = nesnelKurgu.Evidence;
            IEnumerator delilEnum = nesnelDelil.GetEnumerator();
            while (delilEnum.MoveNext()) Console.WriteLine (delilEnum.Current);

            Console.WriteLine ("\nKurulum/sökülüm programla sözlük.exe kurma/sökme:");
            Console.WriteLine ("Kurulum sözdizimi: installer.exe sözlük.exe");
            Console.WriteLine ("Söküm sözdizimi: uninstaller.exe sözlük.exe");

            Console.WriteLine ("\nPerformansSayaçKatagorisi ve makine adý, yardým metni:");
            PerformanceCounterCategory pcc = new PerformanceCounterCategory();
            try {
                Console.WriteLine ("Katagori adý:  {0}", pcc.CategoryName);
                Console.WriteLine ("Bilgisayar adý:  {0}", pcc.MachineName);
                Console.WriteLine ("Katagori yardým metni: {0}", pcc.CategoryHelp);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nRuntimeHelpers/KoþuZamanlýYardýmcý'nýn kýyma kodu:");
            int kýyma = RuntimeHelpers.GetHashCode (0);
            Console.WriteLine ("0 veya 20240413 için kýyma kodu: " + kýyma);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}