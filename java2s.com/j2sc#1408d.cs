// j2sc#1408d.cs: Application.Run, SoundPlayer, AsyncResult ve [Conditional('DEBUG')] örneði.

#define DÜZELT
using System;
using System.Windows.Forms; //OpenFileDialog, SaveFileDialog, DialogResult ve MessageBox için
using System.Media; //SoundPlayer için
using System.IO; //Dosya sakla/aç için
using System.Threading; //Thread için
//using QuartzTypeLib; //Ekstradan yüklense de çalýþmadý
using System.Runtime.Remoting.Messaging; //AsyncResult için
using System.Diagnostics; //[Conditional] için
namespace Geliþimler {
    public delegate int ÝkiliÝþlem (int x, int y);
    class ÇeþitliD : Form {
        static int ts1, ts2;
        static void ToplamayýTamamla (IAsyncResult iAR) {
            AsyncResult ar = (AsyncResult)iAR;
            ÝkiliÝþlem biþ = (ÝkiliÝþlem)ar.AsyncDelegate;
            Console.WriteLine ("Toplam ({0} + {1}) sonucu: {2}.", ts1, ts2, biþ.EndInvoke (iAR));
            string mesaj = (string)iAR.AsyncState;
            Console.WriteLine (mesaj);
        }
        static int Topla (int x, int y) {
            Console.WriteLine ("Topla() {0}.sicimde yürütülmekte.", Thread.CurrentThread.GetHashCode());
            Thread.Sleep (100);
            return x + y;
        }
        [Conditional ("DÜZELT")]
        public static void HataArýndýr() {Console.WriteLine ("Bu tümce sadece '#define DÜZELT' eklentisiyle çýktýlanabilir.");}
        [STAThread] //SaveFileDialog ve OpenFileDialog için
        static void Main() {
            Console.Write ("Application.Run(new ÇeþitliD()) için 'ÇeþitliD : Form' miraslanmalý. Dosya saklama/açma için 'using System.Windows.Forms, using System.IO ve [STAThread]' gerekmektedir.\n[Conditional('DEBUG')] çýktýlarýnýn sunumu için kodlama baþýnda '#define DEBUG' bulunmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli windows pencereleri ve müzikçalar testleri:");
            //Windows.Forms.Form için
            Application.Run (new ÇeþitliD());
            //Mesaj kutusu
            MessageBox.Show ("Merhabalar...\nBen mesaj kutusuyum.");
            //Renk diyaloðu
            ColorDialog rd=new ColorDialog();
            rd.FullOpen = true;
            rd.ShowDialog();
            //Dosya saklama
            SaveFileDialog ds = new SaveFileDialog();
            ds.Filter = "RichText Files (*.rtf) | *.RTF | Text Files (*.txt) | *.TXT | All files (*.*) | *.*";
            ds.CheckFileExists = true;
            ds.InitialDirectory = Application.StartupPath;
            if (ds.ShowDialog() == DialogResult.OK) Console.WriteLine (ds.FileName);
            //Dosya (.wav) açma
            OpenFileDialog dad = new OpenFileDialog();
            dad.Filter = "WAV Files|*.wav|All Files|*.*";
            if (DialogResult.OK == dad.ShowDialog()) {
                SoundPlayer mçalar = new SoundPlayer (dad.FileName);
                try {mçalar.Play();
                }catch (Exception ht) {MessageBox.Show ("HATA: [{0}]", ht.Message);
                }finally {mçalar.Dispose();}
            }
            //Asterisk 'klik'lemesini çalar
            Thread.Sleep (1000); SystemSounds.Asterisk.Play(); Thread.Sleep (1000);
/*
            Console.WriteLine ("\nMp3 müzik dosyalarýnýn QuartzTypeLib ile çalýnmasý:");
            dad = new OpenFileDialog();
            dad.Filter = "Media Files|*.wav;*.mp3;*.mp2;*.wma|All Files|*.*";
            if (DialogResult.OK == dad.ShowDialog()) {
                QuartzTypeLib.FilgraphManager grYönet = new QuartzTypeLib.FilgraphManager();
                QuartzTypeLib.IMediaControl mk = (QuartzTypeLib.IMediaControl)grYönet;
                mk.RenderFile (openFileDialog.FileName);
                mk.Run();
            }
*/
            Console.WriteLine ("\nAsenkron sicimli 5'li döngüyle iki rasgele sayýnýn toplamý:");
            var r=new Random(); int i;
            ÝkiliÝþlem biþ;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                biþ = new ÝkiliÝþlem (Topla);
                IAsyncResult iAR = biþ.BeginInvoke (ts1, ts2, new AsyncCallback (ToplamayýTamamla), "Main()==> Bu sayýlarý topladýðýnýz için size minnettarým.");
                Thread.Sleep (1000);
            }

            Console.WriteLine ("\n[Conditional (\"DÜZELT\")] þartlý metot yürütümü '#define DÜZELT'le mümkündür:");
            ÇeþitliD.HataArýndýr();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}