// j2sc#1503d.cs: FileSystemWatcher'la seçili dosyanýn olaylara duyarlýlýk gözlemi örneði.

using System;
using System.IO;
using System.Windows.Forms; //Application için
namespace DosyaDizin {
    class ÇeþitliD : Form {
        private FileSystemWatcher gözcü;
        private delegate void GözcüDelege (string yeniMetin);
        private TextBox metinKutu;
        private Button düðme1;
        private Button düðme2;
        private Label etiket;
        private OpenFileDialog dosyaDiyaloðu;
        public ÇeþitliD() {//Kurucu
            AygýtlarýBaþlat();
            this.gözcü = new System.IO.FileSystemWatcher();
            this.gözcü.Deleted += new System.IO.FileSystemEventHandler (this.Silindi);
            this.gözcü.Renamed += new System.IO.RenamedEventHandler (this.AdýDeðiþti);
            this.gözcü.Changed += new System.IO.FileSystemEventHandler (this.ÝçerikDeðiþti);
            this.gözcü.Created += new System.IO.FileSystemEventHandler (this.Yaratýldý);
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
        }
        public void GözcüyüGüncelle (string yeniMetin) {etiket.Text = yeniMetin;}
        public void ÝçerikDeðiþti (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("kütük.txt", true);
                sw.WriteLine ("Dosya: {0} {1}", olay.FullPath, olay.ChangeType.ToString());
                sw.Close();
                this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle),"kütük.txt'e 'Changed' yazýldý");
            }catch (IOException) {this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle), "kütük.txt'e yazma hatasý");}
        }
        public void AdýDeðiþti (object kaynak, RenamedEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("kütük.txt", true);
                sw.WriteLine ("Dosya adý deðiþti: [{0}]-->[{1}]", olay.OldName, olay.FullPath);
                sw.Close();
                this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle),"kütük.txt'e 'Renamed' yazýldý");
            }catch (IOException) {this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle), "kütük.txt'e yazma hatasý");}
        }
        public void Silindi (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter ("kütük.txt", true);
                sw.WriteLine ("Dosya: [{0}] silindi", olay.FullPath);
                sw.Close();
                this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle),"kütük.txt'e 'Deleted' yazýldý");
            }catch (IOException) {this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle), "kütük.txt'e yazma hatasý");}
        }
        public void Yaratýldý (object kaynak, FileSystemEventArgs olay) {
            try {StreamWriter sw = new StreamWriter (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\kütük.txt", true);
                sw.WriteLine ("Dosya: [{0}] yaratýldý", olay.FullPath);
                sw.Close();
                this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle),"kütük.txt'e 'Created' yazýldý");
            }catch (IOException) {this.BeginInvoke (new GözcüDelege (GözcüyüGüncelle), "kütük.txt'e yazma hatasý");}
        }
        private void düðme1Týklandý (object gönderen, EventArgs olay) {
            if (dosyaDiyaloðu.ShowDialog() != DialogResult.Cancel) {
                metinKutu.Text = dosyaDiyaloðu.FileName;
                düðme2.Enabled = true;
            }
        }
        private void düðme2Týklandý (object gönderen, EventArgs olay) {
            gözcü.Path = Path.GetDirectoryName (metinKutu.Text);
            gözcü.Filter = Path.GetFileName (metinKutu.Text);
            gözcü.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            etiket.Text = "Gözlenen: " + metinKutu.Text;
            gözcü.EnableRaisingEvents = true;
        }
        private void AygýtlarýBaþlat() {
            this.metinKutu = new TextBox();
            this.düðme1 = new Button();
            this.düðme2 = new Button();
            this.etiket = new Label();
            this.dosyaDiyaloðu = new OpenFileDialog();
            this.SuspendLayout();
            // metinKutu
            this.metinKutu.Location = new System.Drawing.Point (8, 26);
            this.metinKutu.Name = "metinKutu";
            this.metinKutu.Size = new System.Drawing.Size (184, 20);
            this.metinKutu.TabIndex = 0;
            // düðme1
            this.düðme1.Location = new System.Drawing.Point (208, 24);
            this.düðme1.Name = "düðme1";
            this.düðme1.Size = new System.Drawing.Size (64, 24);
            this.düðme1.TabIndex = 1;
            this.düðme1.Text = "Tara...";
            this.düðme1.UseVisualStyleBackColor = true;
            this.düðme1.Click += new System.EventHandler (this.düðme1Týklandý);
            // düðme2
            this.düðme2.Enabled = false;
            this.düðme2.Location = new System.Drawing.Point (88, 56);
            this.düðme2.Name = "düðme2";
            this.düðme2.Size = new System.Drawing.Size (80, 32);
            this.düðme2.TabIndex = 2;
            this.düðme2.Text = "Gözle!";
            this.düðme2.UseVisualStyleBackColor = true;
            this.düðme2.Click += new System.EventHandler (this.düðme2Týklandý);
            // etiket
            this.etiket.AutoSize = true;
            this.etiket.Location = new System.Drawing.Point (8, 104);
            this.etiket.Name = "etiket";
            this.etiket.Size = new System.Drawing.Size (0, 13);
            this.etiket.TabIndex = 3;
            // dosyaDiyaloðu
            this.dosyaDiyaloðu.FileName = "dosyaDiyaloðu";
            this.dosyaDiyaloðu.Filter = "All Files|*.*";
            // ÇeþitliD
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (296, 135);
            this.Controls.Add (this.etiket);
            this.Controls.Add (this.düðme2);
            this.Controls.Add (this.düðme1);
            this.Controls.Add (this.metinKutu);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "ÇeþitliD";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dosya Gözcüsü";
            this.ResumeLayout (false);
            this.PerformLayout();
        }
        private static void Deðiþ (object yolla, FileSystemEventArgs olay) {Console.WriteLine ("DÝKKAT: [" + olay.FullPath + "] dosya deðiþti-->" + olay.ChangeType.ToString());}
        private static void Deðiþti (object yolla, FileSystemEventArgs olay) {Console.WriteLine ("DÝKKAT: [" + olay.FullPath + "] -->" + olay.ChangeType);}
        [STAThread]
        static void Main() {
            Console.Write ("ÇeþitliD:Form ile verili dizindeki istenen (Tara düðmesiyle) dosya seçilip atanmýþ olaylara duyarlý kýlýnýp Gözle düðmesiyle olaylarýn takibi baþlatýlýr. Olay sonuçlarý DOS pencerede, kütük.txt dosyada ve küçük Form pencerede takip edilebilir. Form pencere sað-üst kare tuþla büyütülür, X'le kapatýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'nihat1.bin' adlý dosyayý yaratma ve silmeye duyarlý gözlemci:");
            FileSystemWatcher gözle = new FileSystemWatcher();
            gözle.Path = Application.StartupPath;
            gözle.Filter = "*.*";
            gözle.IncludeSubdirectories = true;
            gözle.Created += new FileSystemEventHandler (Deðiþ);
            gözle.Deleted += new FileSystemEventHandler (Deðiþ);
            gözle.EnableRaisingEvents = true;
            if (File.Exists ("nihat1.bin")) File.Delete ("nihat1.bin");
            Console.Write ("Tuþ..."); Console.ReadKey();
            FileStream fs;
            using (fs = new FileStream ("nihat1.bin", FileMode.Create)) {}

            Console.WriteLine ("\nVerili dizindeki dosya içerik ve ad deðiþiminin gözlenmesi:");
            gözle = new FileSystemWatcher (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\", "*.*"); //argümanlar: path/yol, filter/süzgeç
            WaitForChangedResult deðiþim = gözle.WaitForChanged (WatcherChangeTypes.Changed | WatcherChangeTypes.Renamed);
            switch (deðiþim.ChangeType) {
                case WatcherChangeTypes.Changed: Console.WriteLine ("[{0}]'da dosya '{1}' içerik deðiþti.", DateTime.Now, deðiþim.Name); break;
                case WatcherChangeTypes.Renamed: Console.WriteLine ("[{0}]'da '{1}' yeniden adlandýrýldý-->'{2}'", DateTime.Now, deðiþim.OldName, deðiþim.Name); break;
            }

            Console.WriteLine ("\nVerili dizindeki *.cs dosyalarý deðiþ/yarat/sil/ad olaylarýna duyarlama:");
            gözle = new FileSystemWatcher();
            gözle.Path = @"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham";
            gözle.Filter = "*.cs";
            gözle.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            gözle.Changed += new FileSystemEventHandler (Deðiþti);
            gözle.Created += new FileSystemEventHandler (Deðiþti);
            gözle.Deleted += new FileSystemEventHandler (Deðiþti);
            gözle.Renamed += new RenamedEventHandler (Deðiþti);
            gözle.EnableRaisingEvents = true;

            Console.WriteLine ("\nSeçilen dosyanýn Deleted/Renamed/Changed/Created gözlemi:");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new ÇeþitliD()); //Gözlemi sonlandýrmak için küçük penceredeki X týkla

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}