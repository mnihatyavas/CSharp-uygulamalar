// j2sc#1503d.cs: FileSystemWatcher'la se�ili dosyan�n olaylara duyarl�l�k g�zlemi �rne�i.

using System;
using System.IO;
using System.Windows.Forms; //Application i�in
namespace DosyaDizin {
    class �e�itliD : Form {
        private FileSystemWatcher g�zc�;
        private delegate void G�zc�Delege (string yeniMetin);
        private TextBox metinKutu;
        private Button d��me1;
        private Button d��me2;
        private Label etiket;
        private OpenFileDialog dosyaDiyalo�u;
        public �e�itliD() {//Kurucu
            Ayg�tlar�Ba�lat();
            this.g�zc� = new System.IO.FileSystemWatcher();
            this.g�zc�.Deleted += new System.IO.FileSystemEventHandler (this.Silindi);
            this.g�zc�.Renamed += new System.IO.RenamedEventHandler (this.Ad�De�i�ti);
            this.g�zc�.Changed += new System.IO.FileSystemEventHandler (this.��erikDe�i�ti);
            this.g�zc�.Created += new System.IO.FileSystemEventHandler (this.Yarat�ld�);
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
        }
        public void G�zc�y�G�ncelle (string yeniMetin) {etiket.Text = yeniMetin;}
        public void ��erikDe�i�ti (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("k�t�k.txt", true);
                sw.WriteLine ("Dosya: {0} {1}", olay.FullPath, olay.ChangeType.ToString());
                sw.Close();
                this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle),"k�t�k.txt'e 'Changed' yaz�ld�");
            }catch (IOException) {this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle), "k�t�k.txt'e yazma hatas�");}
        }
        public void Ad�De�i�ti (object kaynak, RenamedEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("k�t�k.txt", true);
                sw.WriteLine ("Dosya ad� de�i�ti: [{0}]-->[{1}]", olay.OldName, olay.FullPath);
                sw.Close();
                this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle),"k�t�k.txt'e 'Renamed' yaz�ld�");
            }catch (IOException) {this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle), "k�t�k.txt'e yazma hatas�");}
        }
        public void Silindi (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("k�t�k.txt", true);
                sw.WriteLine ("Dosya: [{0}] silindi", olay.FullPath);
                sw.Close();
                this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle),"k�t�k.txt'e 'Deleted' yaz�ld�");
            }catch (IOException) {this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle), "k�t�k.txt'e yazma hatas�");}
        }
        public void Yarat�ld� (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\k�t�k.txt", true);
                sw.WriteLine ("Dosya: [{0}] yarat�ld�", olay.FullPath);
                sw.Close();
                this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle),"k�t�k.txt'e 'Created' yaz�ld�");
            }catch (IOException) {this.BeginInvoke (new G�zc�Delege (G�zc�y�G�ncelle), "k�t�k.txt'e yazma hatas�");}
        }
        private void d��me1T�kland� (object g�nderen, EventArgs olay) {
            if (dosyaDiyalo�u.ShowDialog() != DialogResult.Cancel) {
                metinKutu.Text = dosyaDiyalo�u.FileName;
                d��me2.Enabled = true;
            }
        }
        private void d��me2T�kland� (object g�nderen, EventArgs olay) {
            g�zc�.Path = Path.GetDirectoryName (metinKutu.Text);
            g�zc�.Filter = Path.GetFileName (metinKutu.Text);
            g�zc�.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            etiket.Text = "G�zlenen: " + metinKutu.Text;
            g�zc�.EnableRaisingEvents = true;
        }
        private void Ayg�tlar�Ba�lat() {
            this.metinKutu = new TextBox();
            this.d��me1 = new Button();
            this.d��me2 = new Button();
            this.etiket = new Label();
            this.dosyaDiyalo�u = new OpenFileDialog();
            this.SuspendLayout();
            // metinKutu
            this.metinKutu.Location = new System.Drawing.Point (8, 26);
            this.metinKutu.Name = "metinKutu";
            this.metinKutu.Size = new System.Drawing.Size (184, 20);
            this.metinKutu.TabIndex = 0;
            // d��me1
            this.d��me1.Location = new System.Drawing.Point (208, 24);
            this.d��me1.Name = "d��me1";
            this.d��me1.Size = new System.Drawing.Size (64, 24);
            this.d��me1.TabIndex = 1;
            this.d��me1.Text = "Tara...";
            this.d��me1.UseVisualStyleBackColor = true;
            this.d��me1.Click += new System.EventHandler (this.d��me1T�kland�);
            // d��me2
            this.d��me2.Enabled = false;
            this.d��me2.Location = new System.Drawing.Point (88, 56);
            this.d��me2.Name = "d��me2";
            this.d��me2.Size = new System.Drawing.Size (80, 32);
            this.d��me2.TabIndex = 2;
            this.d��me2.Text = "G�zle!";
            this.d��me2.UseVisualStyleBackColor = true;
            this.d��me2.Click += new System.EventHandler (this.d��me2T�kland�);
            // etiket
            this.etiket.AutoSize = true;
            this.etiket.Location = new System.Drawing.Point (8, 104);
            this.etiket.Name = "etiket";
            this.etiket.Size = new System.Drawing.Size (0, 13);
            this.etiket.TabIndex = 3;
            // dosyaDiyalo�u
            this.dosyaDiyalo�u.FileName = "dosyaDiyalo�u";
            this.dosyaDiyalo�u.Filter = "All Files|*.*";
            // �e�itliD
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (296, 135);
            this.Controls.Add (this.etiket);
            this.Controls.Add (this.d��me2);
            this.Controls.Add (this.d��me1);
            this.Controls.Add (this.metinKutu);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "�e�itliD";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dosya G�zc�s�";
            this.ResumeLayout (false);
            this.PerformLayout();
        }
        private static void De�i� (object yolla, FileSystemEventArgs olay) {Console.WriteLine ("D�KKAT: [" + olay.FullPath + "] dosya de�i�ti-->" + olay.ChangeType.ToString());}
        private static void De�i�ti (object yolla, FileSystemEventArgs olay) {Console.WriteLine ("D�KKAT: [" + olay.FullPath + "] -->" + olay.ChangeType);}
        [STAThread]
        static void Main() {
            Console.Write ("�e�itliD:Form ile verili dizindeki istenen (Tara d��mesiyle) dosya se�ilip atanm�� olaylara duyarl� k�l�n�p G�zle d��mesiyle olaylar�n takibi ba�lat�l�r. Olay sonu�lar� DOS pencerede, k�t�k.txt dosyada ve k���k Form pencerede takip edilebilir. Form pencere sa�-�st kare tu�la b�y�t�l�r, X'le kapat�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'nihat1.bin' adl� dosyay� yaratma ve silmeye duyarl� g�zlemci:");
            FileSystemWatcher g�zle = new FileSystemWatcher();
            g�zle.Path = Application.StartupPath;
            g�zle.Filter = "*.*";
            g�zle.IncludeSubdirectories = true;
            g�zle.Created += new FileSystemEventHandler (De�i�);
            g�zle.Deleted += new FileSystemEventHandler (De�i�);
            g�zle.EnableRaisingEvents = true;
            if (File.Exists ("nihat1.bin")) File.Delete ("nihat1.bin");
            Console.Write ("Tu�..."); Console.ReadKey();
            FileStream fs;
            using (fs = new FileStream ("nihat1.bin", FileMode.Create)) {}

            Console.WriteLine ("\nVerili dizindeki dosya i�erik ve ad de�i�iminin g�zlenmesi:");
            g�zle = new FileSystemWatcher (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\", "*.*"); //arg�manlar: path/yol, filter/s�zge�
            WaitForChangedResult de�i�im = g�zle.WaitForChanged (WatcherChangeTypes.Changed | WatcherChangeTypes.Renamed);
            switch (de�i�im.ChangeType) {
                case WatcherChangeTypes.Changed: Console.WriteLine ("[{0}]'da dosya '{1}' i�erik de�i�ti.", DateTime.Now, de�i�im.Name); break;
                case WatcherChangeTypes.Renamed: Console.WriteLine ("[{0}]'da '{1}' yeniden adland�r�ld�-->'{2}'", DateTime.Now, de�i�im.OldName, de�i�im.Name); break;
            }

            Console.WriteLine ("\nVerili dizindeki *.cs dosyalar� de�i�/yarat/sil/ad olaylar�na duyarlama:");
            g�zle = new FileSystemWatcher();
            g�zle.Path = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham";
            g�zle.Filter = "*.cs";
            g�zle.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            g�zle.Changed += new FileSystemEventHandler (De�i�ti);
            g�zle.Created += new FileSystemEventHandler (De�i�ti);
            g�zle.Deleted += new FileSystemEventHandler (De�i�ti);
            g�zle.Renamed += new RenamedEventHandler (De�i�ti);
            g�zle.EnableRaisingEvents = true;

            Console.WriteLine ("\nSe�ilen dosyan�n Deleted/Renamed/Changed/Created g�zlemi:");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new �e�itliD()); //G�zlemi sonland�rmak i�in k���k penceredeki X t�kla

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}