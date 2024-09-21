// j2sc#2003b.cs: Asenkron AsyncCallback ve IAsyncResult'la delegeli metot �rne�i.

using System;
using System.Threading; //Thread i�in
using System.Runtime.Remoting.Messaging; //AsyncResult i�in
using System.IO; //FileStream i�in
using System.Text; //Encoding i�in
namespace Sicimler {
    public delegate int delege3();
    public class DelegeliS�n�f {
        public delege3 delege3A;
        public void Ko�() {for(int i=0;i<10;i++) {if (delege3A != null) {foreach (delege3 dlg3 in delege3A.GetInvocationList()) {dlg3.BeginInvoke (new AsyncCallback (Gerid�nenSonu�), dlg3);}}}}
        private void Gerid�nenSonu� (IAsyncResult iar) {
            delege3 dlg3 = (delege3)iar.AsyncState;
            Console.WriteLine ("\tDelegeli gerid�n�� sonucu: {0}", (int)dlg3.EndInvoke (iar));
        }
    }
    public class Saya�l�S�n�f {
        private int saya� = 0;
        public void DelegeliSaya� (DelegeliS�n�f dlgSnf) {dlgSnf.delege3A += new delege3 (Sayac�G�ster);}
        public int Sayac�G�ster() {
            Thread.Sleep( 50);
            Console.WriteLine ("Sayac�G�ster �al��mas�n� sunuyor...");
            return ++saya�;
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
        static int �al��1 (string dzg) {Console.WriteLine (dzg); return 20240911;}
        static void �al��2 (IAsyncResult iar) {delege1 dlg = (delege1)((AsyncResult)iar).AsyncDelegate; dlg.EndInvoke (iar);}
        public delegate int delege2 (int x, int y);
        static int ekle (int x, int y) {
            Console.WriteLine ("ekle()'yi y�r�ten sicim no: {0}.", Thread.CurrentThread.ManagedThreadId); 
            Thread.Sleep (290);
            return x + y;
        }
        static void ekleGerid�n���n�G�ster (IAsyncResult iar) {
            Console.WriteLine ("ekleGerid�n���n�G�ster()'i y�r�ten sicim no {0}.", Thread.CurrentThread.ManagedThreadId);
            AsyncResult ar = (AsyncResult)iar;
            delege2 dlg2 = (delege2)ar.AsyncDelegate;
            Console.WriteLine (dlg2.EndInvoke (iar));
            //Console.WriteLine ((string)iar.AsyncState);
        }
        public static void �al��3() {Thread.Sleep (200); Console.WriteLine ("�al���yoruz ya. Me�gul etme!");}
        static FileStream VeriDosya;
        static byte[] ByteDizi;
        static IAsyncResult iarOku;
        static IAsyncResult iarYaz;
        static AsyncCallback acbOku;
        static AsyncCallback acbYaz;
        public static void OkunanByteTamamlan�nca (IAsyncResult iar) {
            Console.WriteLine ("Okunan toplam byte say�s� = " + VeriDosya.EndRead (iar));
            for (int i = 0; i < 256; i++) {
                Console.Write ((char)ByteDizi [i] + " ");
                if (ByteDizi [i] != (byte)i) Console.WriteLine ("HATA: ByteDizi[{0}] != {0}", i);
            }
        }
        public static void Yaz�lanByteTamamlan�nca (IAsyncResult iar) {Console.WriteLine ("Veri dosyaya [0-->255] bayt yaz�ld�."); VeriDosya.EndWrite (iar);}
        static void Main() {
            Console.Write ("'new delege(metot).BeginInvoke(prm1,prm2,null,null)' yada 'new delege(metotBa�la).BeginInvoke(prm1,prm2, new AsyncCallback(metotBitir)' ile asenkron delegeli �oklu sicimli metotlar y�r�t�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�al��1() metodu yal�n, asenkron gerid�n�� delege1'li:");
            Console.WriteLine (�al��1 ("Merhabalar!"));
            delege1 dlg1 = new delege1 (�al��1);
            AsyncCallback acb = new AsyncCallback (�al��2);
            IAsyncResult iar = dlg1.BeginInvoke ("Herkese selam!", acb, null);
            Console.WriteLine (iar);

            Thread.Sleep (1000); Console.WriteLine ("\nDelege2'li asenkron toplaman�n 2 ayr� sicimde icras�:");
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
                Console.WriteLine ("{0} + {1} = ?", ts1, ts2, dlg2.BeginInvoke (ts1, ts2, new AsyncCallback (ekleGerid�n���n�G�ster), "Bu iki say� ekleniyor..."));
            }

            Thread.Sleep (1000); Console.WriteLine ("\n��i�e �ift delegelenen asenkron saya� sonu�lar�n�n g�sterimi:");
            DelegeliS�n�f dlgSnf = new DelegeliS�n�f();
            Saya�l�S�n�f ss = new Saya�l�S�n�f();
            ss.DelegeliSaya� (dlgSnf);
            dlgSnf.Ko�();

            Thread.Sleep (1000); Console.WriteLine ("\nDelegeli asenkron �al��3() s�resince 200/20 noktal�yor:");
            delege4 dlg4 = null;
            iar = null;
            for(i=0;i<5;i++) {
                try {dlg4 = new delege4 (�al��3);
                    iar = dlg4.BeginInvoke (null, null);
                     while (!iar.AsyncWaitHandle.WaitOne (20, false)) {Console.Write ('.');}
                }finally {if (dlg4 != null && iar != null) dlg4.EndInvoke (iar);}
            }

            Thread.Sleep (1000); Console.WriteLine ("\n'mny.dat' dosyaya asenkron delege kontrollu 256 byte yaz/oku:");
            iarOku = null;
            VeriDosya = new FileStream ("mny.dat", FileMode.Create, FileAccess.ReadWrite);
            ByteDizi = new byte [256];
            acbYaz = new AsyncCallback (Yaz�lanByteTamamlan�nca);
            acbOku = new AsyncCallback (OkunanByteTamamlan�nca);
            for (i = 0; i < 256; i++) ByteDizi [i] = (byte)i;
            iarYaz = VeriDosya.BeginWrite (ByteDizi, 0, 256, acbYaz, null);
            WaitHandle bekle = iarYaz.AsyncWaitHandle; bekle.WaitOne();
            VeriDosya.Seek (0, SeekOrigin.Begin);
            iarOku = VeriDosya.BeginRead (ByteDizi, 0, 256, acbOku, null);
            bekle = iarOku.AsyncWaitHandle;
            bekle.WaitOne();

            Thread.Sleep (1000); Console.WriteLine ("\n\n�stenen metin dosyas�n�n senkron okunmas�:");
            new DosyaSunum();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}