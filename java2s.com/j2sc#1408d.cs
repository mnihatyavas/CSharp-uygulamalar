// j2sc#1408d.cs: Application.Run, SoundPlayer, AsyncResult ve [Conditional('DEBUG')] �rne�i.

#define D�ZELT
using System;
using System.Windows.Forms; //OpenFileDialog, SaveFileDialog, DialogResult ve MessageBox i�in
using System.Media; //SoundPlayer i�in
using System.IO; //Dosya sakla/a� i�in
using System.Threading; //Thread i�in
//using QuartzTypeLib; //Ekstradan y�klense de �al��mad�
using System.Runtime.Remoting.Messaging; //AsyncResult i�in
using System.Diagnostics; //[Conditional] i�in
namespace Geli�imler {
    public delegate int �kili��lem (int x, int y);
    class �e�itliD : Form {
        static int ts1, ts2;
        static void Toplamay�Tamamla (IAsyncResult iAR) {
            AsyncResult ar = (AsyncResult)iAR;
            �kili��lem bi� = (�kili��lem)ar.AsyncDelegate;
            Console.WriteLine ("Toplam ({0} + {1}) sonucu: {2}.", ts1, ts2, bi�.EndInvoke (iAR));
            string mesaj = (string)iAR.AsyncState;
            Console.WriteLine (mesaj);
        }
        static int Topla (int x, int y) {
            Console.WriteLine ("Topla() {0}.sicimde y�r�t�lmekte.", Thread.CurrentThread.GetHashCode());
            Thread.Sleep (100);
            return x + y;
        }
        [Conditional ("D�ZELT")]
        public static void HataAr�nd�r() {Console.WriteLine ("Bu t�mce sadece '#define D�ZELT' eklentisiyle ��kt�lanabilir.");}
        [STAThread] //SaveFileDialog ve OpenFileDialog i�in
        static void Main() {
            Console.Write ("Application.Run(new �e�itliD()) i�in '�e�itliD : Form' miraslanmal�. Dosya saklama/a�ma i�in 'using System.Windows.Forms, using System.IO ve [STAThread]' gerekmektedir.\n[Conditional('DEBUG')] ��kt�lar�n�n sunumu i�in kodlama ba��nda '#define DEBUG' bulunmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli windows pencereleri ve m�zik�alar testleri:");
            //Windows.Forms.Form i�in
            Application.Run (new �e�itliD());
            //Mesaj kutusu
            MessageBox.Show ("Merhabalar...\nBen mesaj kutusuyum.");
            //Renk diyalo�u
            ColorDialog rd=new ColorDialog();
            rd.FullOpen = true;
            rd.ShowDialog();
            //Dosya saklama
            SaveFileDialog ds = new SaveFileDialog();
            ds.Filter = "RichText Files (*.rtf) | *.RTF | Text Files (*.txt) | *.TXT | All files (*.*) | *.*";
            ds.CheckFileExists = true;
            ds.InitialDirectory = Application.StartupPath;
            if (ds.ShowDialog() == DialogResult.OK) Console.WriteLine (ds.FileName);
            //Dosya (.wav) a�ma
            OpenFileDialog dad = new OpenFileDialog();
            dad.Filter = "WAV Files|*.wav|All Files|*.*";
            if (DialogResult.OK == dad.ShowDialog()) {
                SoundPlayer m�alar = new SoundPlayer (dad.FileName);
                try {m�alar.Play();
                }catch (Exception ht) {MessageBox.Show ("HATA: [{0}]", ht.Message);
                }finally {m�alar.Dispose();}
            }
            //Asterisk 'klik'lemesini �alar
            Thread.Sleep (1000); SystemSounds.Asterisk.Play(); Thread.Sleep (1000);
/*
            Console.WriteLine ("\nMp3 m�zik dosyalar�n�n QuartzTypeLib ile �al�nmas�:");
            dad = new OpenFileDialog();
            dad.Filter = "Media Files|*.wav;*.mp3;*.mp2;*.wma|All Files|*.*";
            if (DialogResult.OK == dad.ShowDialog()) {
                QuartzTypeLib.FilgraphManager grY�net = new QuartzTypeLib.FilgraphManager();
                QuartzTypeLib.IMediaControl mk = (QuartzTypeLib.IMediaControl)grY�net;
                mk.RenderFile (openFileDialog.FileName);
                mk.Run();
            }
*/
            Console.WriteLine ("\nAsenkron sicimli 5'li d�ng�yle iki rasgele say�n�n toplam�:");
            var r=new Random(); int i;
            �kili��lem bi�;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                bi� = new �kili��lem (Topla);
                IAsyncResult iAR = bi�.BeginInvoke (ts1, ts2, new AsyncCallback (Toplamay�Tamamla), "Main()==> Bu say�lar� toplad���n�z i�in size minnettar�m.");
                Thread.Sleep (1000);
            }

            Console.WriteLine ("\n[Conditional (\"D�ZELT\")] �artl� metot y�r�t�m� '#define D�ZELT'le m�mk�nd�r:");
            �e�itliD.HataAr�nd�r();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}