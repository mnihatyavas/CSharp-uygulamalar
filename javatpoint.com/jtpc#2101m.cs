// jtpc#2101m.cs: D��me olaylar�yla veri tablo kay�tlar�n� aktarma �rne�i.

using System;
using System.Windows.Forms;
using System.Drawing;
using System. Data;
namespace Formlar {
    public partial class �okluOlaylar: Form {
        private Button d��me1, d��me2, d��me3, d��me4, d��me5, d��me6;
        private ListBox listeKutusu1, listeKutusu2;
        private DataTable veritablosu1, veritablosu2;
        private DataGridView �zgaral�G�r�nt�1;

        public �okluOlaylar() {
            //T�m tan�ml� bile�enleri yarat
            d��me1 = new Button(); d��me1.Text = "Tek kurs sa�a"; d��me1.Location = new Point (250, 10); d��me1.Size = new Size (100, 20);
            d��me2 = new Button(); d��me2.Text = "Tek kurs sola"; d��me2.Location = new Point (250, 35); d��me2.Size = new Size (100, 20);
            d��me3 = new Button(); d��me3.Text = "T�m kurslar sa�a"; d��me3.Location = new Point (250, 60); d��me3.Size = new Size (100, 20);
            d��me4 = new Button(); d��me4.Text = "T�m kurslar sola"; d��me4.Location = new Point (250, 85); d��me4.Size = new Size (100, 20);
            d��me5 = new Button(); d��me5.Text = "Bir kurs sonu"; d��me5.Location = new Point (250, 110); d��me5.Size = new Size (100, 20);
            d��me6 = new Button(); d��me6.Text = "�IK"; d��me6.Location = new Point (250, 140); d��me6.Size = new Size (100, 20); d��me6.BackColor = Color.Brown; d��me6.ForeColor = Color.Yellow;
            listeKutusu1 = new ListBox(); listeKutusu1.Location = new Point (10, 10); listeKutusu1.Size = new Size (200, 150); listeKutusu1.BackColor = Color.Khaki; listeKutusu1.ForeColor = Color.DarkGreen;
            listeKutusu2 = new ListBox(); listeKutusu2.Location = new Point (400, 10); listeKutusu2.Size = new Size (200, 150); listeKutusu2.BackColor = Color.DarkKhaki; listeKutusu2.ForeColor = Color.Red;
            veritablosu1 = new DataTable();
            veritablosu2 = new DataTable();
            �zgaral�G�r�nt�1 = new DataGridView(); �zgaral�G�r�nt�1.Location = new Point (10, 180); �zgaral�G�r�nt�1.Size = new Size (590, 150);
            //Kurslar tablolar�n� haz�rla
            KurslarTablosu1();
            KurslarTablosu2();
            //Listekutular�nda kurslar tablosunun hangi kolonu/alan� g�r�necek
            listeKutusu1.DataSource = veritablosu1;
            listeKutusu1.DisplayMember = "KursunAd�";
            listeKutusu2.DataSource = veritablosu2;
            listeKutusu2.DisplayMember = "KursunAd�";
            //Bile�enleri form'a ekle
            Controls.AddRange (new Control[] {
                d��me1, d��me2, d��me3, d��me4, d��me5, d��me6,
                listeKutusu1, listeKutusu2,
                �zgaral�G�r�nt�1});
            //Buton t�klama olay metodlar�n� kur
            d��me1.Click += new System.EventHandler (TekEkle);
            d��me2.Click += new System.EventHandler (TekSil);
            d��me3.Click += new System.EventHandler (T�mEkle);
            d��me4.Click += new System.EventHandler (T�mSil);
            d��me5.Click += new System.EventHandler (Sonland�r);
            d��me6.Click += (a,b)=>Close();
            Text = "Olayl� Butonlar";
            BackColor = Color.DarkSlateGray;
            ForeColor = Color.Magenta;
            ClientSize = new Size (610, 350);
            CenterToScreen();
        }

        private void KurslarTablosu1() {
            //Tablonun kolon adlar�
            veritablosu1.Columns.Add ("KursNO", typeof(int));
            veritablosu1.Columns.Add ("KursunAd�");
            veritablosu1.Columns.Add ("KursunS�resi");
            //Tablonun verili kay�t sat�rlar�
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
            veritablosu2.Columns.Add ("KursunAd�");
            veritablosu2.Columns.Add ("KursunS�resi");
        }

        private void TekEkle (object nesne, System.EventArgs olay) {
            if (listeKutusu1.Items.Count > 0) {//Se�ili listeKutusu1 kayd� listeKutusu2'ye kopyalan�r ve ilki silinir
                veritablosu2.ImportRow (veritablosu1.Rows [listeKutusu1.SelectedIndex]);
                veritablosu1.Rows [listeKutusu1.SelectedIndex].Delete();
            }
        }

        private void TekSil (object nesne, System.EventArgs olay) {
            if (listeKutusu2.Items.Count > 0) {//Se�ili listeKutusu2 kayd� silinir
                veritablosu1.ImportRow (veritablosu2.Rows [listeKutusu2.SelectedIndex]);
                veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
            }
        }

        private void T�mEkle (object nesne, System.EventArgs olay) {
            if (listeKutusu1.Items.Count > 0) {//T�m listeKutusu1 kay�tlar� listeKutusu2'ye kopyalan�p, ilkleri silinir
                int saya� = veritablosu1.Rows.Count;
                for (int i=saya�-1; i>= 0;i--) {
                    veritablosu2.ImportRow (veritablosu1.Rows [listeKutusu1.SelectedIndex]);
                    veritablosu1.Rows [listeKutusu1.SelectedIndex].Delete();
                }
            }
        }
  
        private void T�mSil (object nesne, System.EventArgs olay) {
            if (listeKutusu2.Items.Count > 0) {//T�m listeKutusu2 kay�tlar� silinir
                int saya� = veritablosu2.Rows.Count;
                for (int i = saya� - 1;i >= 0;i--) {
                    veritablosu1.ImportRow (veritablosu2.Rows [listeKutusu2.SelectedIndex]);
                    veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
                }
            }
        }

        private void Sonland�r (object nesne, System.EventArgs o) {
            DialogResult cevap = MessageBox.Show ("Se�ili kursu sonland�rmak istedi�inden emin misin?", "Mesaj Kutusu", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes) {
                �zgaral�G�r�nt�1.DataSource = veritablosu2;
                veritablosu2.Rows [listeKutusu2.SelectedIndex].Delete();
                //�zgaral�G�r�nt�1.Enabled = false; //Varsay�l� de�erleri "true"dur
                //�zgaral�G�r�nt�1.Columns [0].Visible = false;
                //�zgaral�G�r�nt�1.RowHeadersVisible = false;
            }else {MessageBox.Show ("L�tfen enaz bir kurs se�in","D�KKAT", 0, MessageBoxIcon.Warning);}
        }

        static void Main() {Application.Run (new �okluOlaylar());}
    }
}