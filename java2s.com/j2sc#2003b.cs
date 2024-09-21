// j2sc#2003b.cs: Asenkron AsyncCallback ve IAsyncResult'la delegeli metot örneði.

using System;
using System.Threading; //Thread için
using System.Runtime.Remoting.Messaging; //AsyncResult için
using System.IO; //FileStream için
using System.Text; //Encoding için
namespace Sicimler {
    public delegate int delege3();
    public class DelegeliSýnýf {
        public delege3 delege3A;
        public void Koþ() {for(int i=0;i<10;i++) {if (delege3A != null) {foreach (delege3 dlg3 in delege3A.GetInvocationList()) {dlg3.BeginInvoke (new AsyncCallback (GeridönenSonuç), dlg3);}}}}
        private void GeridönenSonuç (IAsyncResult iar) {
            delege3 dlg3 = (delege3)iar.AsyncState;
            Console.WriteLine ("\tDelegeli geridönüþ sonucu: {0}", (int)dlg3.EndInvoke (iar));
        }
    }
    public class SayaçlýSýnýf {
        private int sayaç = 0;
        public void DelegeliSayaç (DelegeliSýnýf dlgSnf) {dlgSnf.delege3A += new delege3 (SayacýGöster);}
        public int SayacýGöster() {
            Thread.Sleep( 50);
            Console.WriteLine ("SayacýGöster çalýþmasýný sunuyor...");
            return ++sayaç;
        }
    }
    delegate void delege4();
    public class DosyaSunum {
        FileStream fs;
        public DosyaSunum() {//Kurucu
            fs= new FileStream ("j2sc#2003b.cs", FileMode.Open);
            int bayt;
            while ((bayt=fs.ReadByte()) != -1) Console.Write ((char)bayt);
            fs.Close();
        }
    }
    class Asenkron {
        delegate int delege1 (string dizge);
        static int Çalýþ1 (string dzg) {Console.WriteLine (dzg); return 20240911;}
        static void Çalýþ2 (IAsyncResult iar) {delege1 dlg = (delege1)((AsyncResult)iar).AsyncDelegate; dlg.EndInvoke (iar);}
        public delegate int delege2 (int x, int y);
        static int ekle (int x, int y) {
            Console.WriteLine ("ekle()'yi yürüten sicim no: {0}.", Thread.CurrentThread.ManagedThreadId); 
            Thread.Sleep (290);
            return x + y;
        }
        static void ekleGeridönüþünüGöster (IAsyncResult iar) {
            Console.WriteLine ("ekleGeridönüþünüGöster()'i yürüten sicim no {0}.", Thread.CurrentThread.ManagedThreadId);
            AsyncResult ar = (AsyncResult)iar;
            delege2 dlg2 = (delege2)ar.AsyncDelegate;
            Console.WriteLine (dlg2.EndInvoke (iar));
            //Console.WriteLine ((string)iar.AsyncState);
        }
        public static void Çalýþ3() {Thread.Sleep (200); Console.WriteLine ("Çalýþýyoruz ya. Meþgul etme!");}
        static FileStream VeriDosya;
        static byte[] ByteDizi;
        static IAsyncResult iarOku;
        static IAsyncResult iarYaz;
        static AsyncCallback acbOku;
        static AsyncCallback acbYaz;
        public static void OkunanByteTamamlanýnca (IAsyncResult iar) {
            Console.WriteLine ("Okunan toplam byte sayýsý = " + VeriDosya.EndRead (iar));
            for (int i = 0; i < 256; i++) {
                Console.Write ((char)ByteDizi [i] + " ");
                if (ByteDizi [i] != (byte)i) Console.WriteLine ("HATA: ByteDizi[{0}] != {0}", i);
            }
        }
        public static void YazýlanByteTamamlanýnca (IAsyncResult iar) {Console.WriteLine ("Veri dosyaya [0-->255] bayt yazýldý."); VeriDosya.EndWrite (iar);}
        static void Main() {
            Console.Write ("'new delege(metot).BeginInvoke(prm1,prm2,null,null)' yada 'new delege(metotBaþla).BeginInvoke(prm1,prm2, new AsyncCallback(metotBitir)' ile asenkron delegeli çoklu sicimli metotlar yürütülür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çalýþ1() metodu yalýn, asenkron geridönüþ delege1'li:");
            Console.WriteLine (Çalýþ1 ("Merhabalar!"));
            delege1 dlg1 = new delege1 (Çalýþ1);
            AsyncCallback acb = new AsyncCallback (Çalýþ2);
            IAsyncResult iar = dlg1.BeginInvoke ("Herkese selam!", acb, null);
            Console.WriteLine (iar);

            Thread.Sleep (1000); Console.WriteLine ("\nDelege2'li asenkron toplamanýn 2 ayrý sicimde icrasý:");
            var r=new Random(); int i, ts1, ts2;
            Console.WriteLine ("Main()'in sicim no'su: {0}.", Thread.CurrentThread.ManagedThreadId); 
            delege2 dlg2 = new delege2 (ekle);
            for(i=0;i<5;i++) {
                ts1=r.Next(1,10000); ts2=r.Next(1,10000);
                iar = dlg2.BeginInvoke (ts1, ts2, null, null);
                while (!iar.AsyncWaitHandle.WaitOne (100, true)) {Console.WriteLine ("Hala Main() sicimdeyim!");}
                Console.WriteLine ("{0} + {1} = {2:#,0}.", ts1, ts2, dlg2.EndInvoke (iar));
            } Thread.Sleep (2000);
            for(i=0;i<5;i++) {
                ts1=r.Next(1,10000); ts2=r.Next(1,10000);
                Console.WriteLine ("{0} + {1} = ?", ts1, ts2, dlg2.BeginInvoke (ts1, ts2, new AsyncCallback (ekleGeridönüþünüGöster), "Bu iki sayý ekleniyor..."));
            }

            Thread.Sleep (1000); Console.WriteLine ("\nÝçiçe çift delegelenen asenkron sayaç sonuçlarýnýn gösterimi:");
            DelegeliSýnýf dlgSnf = new DelegeliSýnýf();
            SayaçlýSýnýf ss = new SayaçlýSýnýf();
            ss.DelegeliSayaç (dlgSnf);
            dlgSnf.Koþ();

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron Çalýþ3() süresince 200/20 noktalýyor:");
            delege4 dlg4 = null;
            iar = null;
            for(i=0;i<5;i++) {
                try {dlg4 = new delege4 (Çalýþ3);
                    iar = dlg4.BeginInvoke (null, null);
                     while (!iar.AsyncWaitHandle.WaitOne (20, false)) {Console.Write ('.');}
                }finally {if (dlg4 != null && iar != null) dlg4.EndInvoke (iar);}
            }

            Thread.Sleep (1000); Console.WriteLine ("\n'mny.dat' dosyaya asenkron delege kontrollu 256 byte yaz/oku:");
            iarOku = null;
            VeriDosya = new FileStream ("mny.dat", FileMode.Create, FileAccess.ReadWrite);
            ByteDizi = new byte [256];
            acbYaz = new AsyncCallback (YazýlanByteTamamlanýnca);
            acbOku = new AsyncCallback (OkunanByteTamamlanýnca);
            for (i = 0; i < 256; i++) ByteDizi [i] = (byte)i;
            iarYaz = VeriDosya.BeginWrite (ByteDizi, 0, 256, acbYaz, null);
            WaitHandle bekle = iarYaz.AsyncWaitHandle; bekle.WaitOne();
            VeriDosya.Seek (0, SeekOrigin.Begin);
            iarOku = VeriDosya.BeginRead (ByteDizi, 0, 256, acbOku, null);
            bekle = iarOku.AsyncWaitHandle;
            bekle.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\n\nÝstenen metin dosyasýnýn senkron okunmasý:");
            new DosyaSunum();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}