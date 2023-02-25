// jtpc#2101m.cs: Düðme olaylarýyla veri tablo kayýtlarýný aktarma örneði.

using System;
using System.Windows.Forms;
using System.Drawing;
using System. Data;
namespace Formlar {
    public partial class ÇokluOlaylar: Form {
        private Button düðme1, düðme2, düðme3, düðme4, düðme5, düðme6;
        private ListBox listeKutusu1, listeKutusu2;
        private DataTable veritablosu1, veritablosu2;
        private DataGridView ýzgaralýGörüntü1;

        public ÇokluOlaylar() {
            //Tüm tanýmlý bileþenleri yarat
            düðme1 = new Button(); düðme1.Text = "Tek kurs saða"; düðme1.Location = new Point (250, 10); düðme1.Size = new Size (100, 20);
            düðme2 = new Button(); düðme2.Text = "Tek kurs sola"; düðme2.Location = new Point (250, 35); düðme2.Size = new Size (100, 20);
            düðme3 = new Button(); düðme3.Text = "Tüm kurslar saða"; düðme3.Location = new Point (250, 60); düðme3.Size = new Size (100, 20);
            düðme4 = new Button(); düðme4.Text = "Tüm kurslar sola"; düðme4.Location = new Point (250, 85); düðme4.Size = new Size (100, 20);
            düðme5 = new Button(); düðme5.Text = "Bir kurs sonu"; düðme5.Location = new Point (250, 110); düðme5.Size = new Size (100, 20);
            düðme6 = new Button(); düðme6.Text = "ÇIK"; düðme6.Location = new Point (250, 140); düðme6.Size = new Size (100, 20); düðme6.BackColor = Color.Brown; düðme6.ForeColor = Color.Yellow;
            listeKutusu1 = new ListBox(); listeKutusu1.Location = new Point (10, 10); listeKutusu1.Size = new Size (200, 150); listeKutusu1.BackColor = Color.Khaki; listeKutusu1.ForeColor = Color.DarkGreen;
            listeKutusu2 = new ListBox(); listeKutusu2.Location = new Point (400, 10); listeKutusu2.Size = new Size (200, 150); listeKutusu2.BackColor = Color.DarkKhaki; listeKutusu2.ForeColor = Color.Red;
            veritablosu1 = new DataTable();
            veritablosu2 = new DataTable();
            ýzgaralýGörüntü1 = new DataGridView(); ýzgaralýGörüntü1.Location = new Point (10, 180); ýzgaralýGörüntü1.Size = new Size (590, 150);
            //Kurslar tablolarýný hazýrla
            KurslarTablosu1();
            KurslarTablosu2();
            //Listekutularýnda kurslar tablosunun hangi kolonu/alaný görünecek
            listeKutusu1.DataSource = veritablosu1;
            listeKutusu1.DisplayMember = "KursunAdý";
            listeKutusu2.DataSource = veritablosu2;
            listeKutusu2.DisplayMember = "KursunAdý";
            //Bileþenleri form'a ekle
            Controls.AddRange (new Control[] {
                düðme1, düðme2, düðme3, düðme4, düðme5, düðme6,
                listeKutusu1, listeKutusu2,
                ýzgaralýGörüntü1});
            //Buton týklama olay metodlarýný kur
            düðme1.Click += new System.EventHandler (TekEkle);
            düðme2.Click += new System.EventHandler (TekSil);
            düðme3.Click += new System.EventHandler (TümEkle);
            düðme4.Click += new System.EventHandler (TümSil);
            düðme5.Click += new System.EventHandler (Sonlandýr);
            düðme6.Click += (a,b)=>Close();
            Text = "Olaylý Butonlar";
            BackColor = Color.DarkSlateGray;
            ForeColor = Color.Magenta;
            ClientSize = new Size (610, 350);
            CenterToScreen();
        }

        private void KurslarTablosu1() {
            //Tablonun kolon adlarý
            veritablosu1.Columns.Add ("KursNO", typeof(int));
            veritablosu1.Columns.Add ("KursunAdý");
            veritablosu1.Columns.Add ("KursunSüresi");
            //Tablonun verili kayýt satýrlarý
            veritablosu1.Rows.Add (1, "HTML-CSS-JS", "8 Ay");
            veritablosu1.Rows.Add (2, "Python", "5 Ay");
            veritablosu1.Rows.Add (3, "Java", "6 Ay");
            veritablosu1.Rows.Add (4, "C++", "4 Ay");
            veritablosu1.Rows.Add (5, "C#", "6 Ay");
            veritablosu1.Rows.Add (6, "JavaScript", "3 Ay");
            veritablosu1.Rows.Add (7, "BashScript", "2 Ay");
            veritablosu1.Rows.Add (8, "Win-7 ve Linux os", "1.5 Ay");
            veritablosu1.Rows.Add (9, "Sigil-epub", "1 Ay");
        }

        private void KurslarTablosu2() {
            veritablosu2.Columns.Add ("KursNO", typeof(int));
            veritablosu2.Columns.Add ("KursunAdý");
            veritablosu2.Columns.Add ("KursunSüresi");
        }

        private void TekEkle (object nesne, System.EventArgs olay) {
            if (listeKutusu1.Items.Count > 0) {//Seçili listeKutusu1 kaydý listeKutusu2'ye kopyalanýr ve ilki silinir
                veritablosu2.ImportRow (veritablosu1.Rows [listeKutusu1.SelectedIndex]);
                veritablosu1.Rows [listeKutusu1.SelectedIndex].Delete();
            }
        }

        private void TekSil (object nesne, System.EventArgs olay) {
            if (listeKutusu2.Items.Count > 0) {//Seçili listeKutusu2 kaydý silinir
                veritablosu1.ImportRow (veritablosu2.Rows [listeKutusu2.SelectedIndex]);
                veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
            }
        }

        private void TümEkle (object nesne, System.EventArgs olay) {
            if (listeKutusu1.Items.Count > 0) {//Tüm listeKutusu1 kayýtlarý listeKutusu2'ye kopyalanýp, ilkleri silinir
                int sayaç = veritablosu1.Rows.Count;
                for (int i=sayaç-1; i>= 0;i--) {
                    veritablosu2.ImportRow (veritablosu1.Rows [listeKutusu1.SelectedIndex]);
                    veritablosu1.Rows [listeKutusu1.SelectedIndex].Delete();
                }
            }
        }
  
        private void TümSil (object nesne, System.EventArgs olay) {
            if (listeKutusu2.Items.Count > 0) {//Tüm listeKutusu2 kayýtlarý silinir
                int sayaç = veritablosu2.Rows.Count;
                for (int i = sayaç - 1;i >= 0;i--) {
                    veritablosu1.ImportRow (veritablosu2.Rows [listeKutusu2.SelectedIndex]);
                    veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
                }
            }
        }

        private void Sonlandýr (object nesne, System.EventArgs o) {
            DialogResult cevap = MessageBox.Show ("Seçili kursu sonlandýrmak istediðinden emin misin?", "Mesaj Kutusu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) {
                ýzgaralýGörüntü1.DataSource = veritablosu2;
                veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
                //ýzgaralýGörüntü1.Enabled = false; //Varsayýlý deðerleri "true"dur
                //ýzgaralýGörüntü1.Columns [0].Visible = false;
                //ýzgaralýGörüntü1.RowHeadersVisible = false;
            }else {MessageBox.Show ("Lütfen enaz bir kurs seçin","DÝKKAT", 0, MessageBoxIcon.Warning);}
        }

        static void Main() {Application.Run (new ÇokluOlaylar());}
    }
}