// j2sc#2301d.cs: EventHandler(metot) ile olaylarýn yönetilmesi örneði.

using System;
using System.Windows.Forms; //Form, Button, Label için
using System.Drawing; //Size için
using System.ComponentModel; //CancelEventArgs için
namespace Formlar {
    public class Form1: Form {
        private Button düðme1 = new Button();
        private Label yafta1 = new Label();
        int xDüðmeEbatý, yDüðmeEbatý;
        public Form1() {//Kurucu
            düðme1.Parent = this;
            düðme1.Text = "Dinamik Düðme Özellikleri";
            Size = new Size (400, 400);//Form1 ebatý
            xDüðmeEbatý = (int)(Font.Height * 0.75) * düðme1.Text.Length;
            yDüðmeEbatý = Font.Height * 2;
            düðme1.Size = new Size (xDüðmeEbatý, yDüðmeEbatý);
            düðme1.BackColor = Color.Red;
            düðme1.ForeColor = Color.Yellow;
            düðme1.Click += new EventHandler (düðme1_Týklandý);
            yafta1.ForeColor = Color.Blue;
            yafta1.Text = "Dinamik Ebat ve Konum Kontrolu";
            yafta1.AutoSize = true;
            yafta1.Parent = this;
            OnResize (EventArgs.Empty);
            BackColor = Color.Lime;
        }
        private void düðme1_Týklandý (object kim, EventArgs olay) {
            Console.WriteLine ("Düðme Bottom: " + düðme1.Bottom.ToString());
            Console.WriteLine ("Düðme Top: " + düðme1.Top);
            Console.WriteLine ("Düðme Left: " + düðme1.Left);
            Console.WriteLine ("Düðme Right: " + düðme1.Right);
            Console.WriteLine ("Düðme Location: " + düðme1.Location);
            Console.WriteLine ("Düðme Width: " + düðme1.Width);
            Console.WriteLine ("Düðme Height: " + düðme1.Height);
            Console.WriteLine ("Düðme Size: " + düðme1.Size);
            Console.WriteLine ("Düðme ClientSize: " + düðme1.ClientSize);
            Console.WriteLine ("Düðme Font: " + düðme1.Font);
        }
        protected override void OnResize (EventArgs oly) {//Düðme1'in Form1 içindeki  konum deðiþim güncelleme
            base.OnResize (oly);
            int xKonum = (int)(this.ClientSize.Width / 2) - (int)(xDüðmeEbatý / 2);
            int yKonum = (int)(this.ClientSize.Height / 2) - (int)(yDüðmeEbatý / 2);
            düðme1.Location = new Point (xKonum, yKonum);
        }
    }
    public partial class Form2: Form {
        public Form2() {BileþeniBaþlat();} //Kurucu
        //Tüm Form olaylarýnýn metotlarý
        private void Form2_Aktiflendi (object k, EventArgs o) {Console.WriteLine ("Aktiflenti");}
        private void Form2_OtoEbatDeðiþti (object k, EventArgs o) {Console.WriteLine ("OtoEbatDeðiþti");}
        private void Form2_OtoGeçerlilemeDeðiþti (object k, EventArgs o) {Console.WriteLine ("OtoGeçerlilemeDeðiþti");}
        private void Form2_ZeminRengiDeðiþti (object k, EventArgs o) {Console.WriteLine ("ZeminRengiDeðiþti");}
        private void Form2_ZeminResmiDeðiþti (object k, EventArgs o) {Console.WriteLine ("ZeminResmiDeðiþti");}
        private void Form2_ZeminResmiSerilimiDeðiþti (object k, EventArgs o) {Console.WriteLine ("ZeminResmiSerilimiDeðiþti");}
        private void Form2_BaðlamsalÝçerikDeðiþti (object k, EventArgs o) {Console.WriteLine ("BaðlamsalÝçerikDeðiþti");}
        private void Form2_NedenselGeçerlilemeDeðiþti (object k, EventArgs o) {Console.WriteLine ("NedenselGeçerlilemeDeðiþti");}
        private void Form2_KAÝpuçlarýDeðiþti (object k, UICuesEventArgs o) {Console.WriteLine ("KAÝpuçlarýDeðiþti");}
        private void Form2_Týklandý (object k, EventArgs o) {Console.WriteLine ("Týklandý");}
        private void Form2_BaðlamMenüÞeridiDeðiþti (object k, EventArgs o) {Console.WriteLine ("BaðlamMenüÞeridiDeðiþti");}
        private void Form2_KontrolEklendi (object k, ControlEventArgs o) {Console.WriteLine ("KontrolEklendi");}
        private void Form2_KontrolSilindi (object k, ControlEventArgs o) {Console.WriteLine ("KontrolSilindi");}
        private void Form2_ÝmleçDeðiþti (object k, EventArgs o) {Console.WriteLine ("ÝmleçDeðiþti");}
        private void Form2_Deaktiflendi (object k, EventArgs o) {Console.WriteLine ("Deaktiflendi");}
        private void Form2_HavuzDeðiþti (object k, EventArgs o) {Console.WriteLine ("HavuzDeðiþti");}
        private void Form2_ÇiftTýklandý (object k, EventArgs o) {Console.WriteLine ("ÇiftTýklandý");}
        private void Form2_SürükleBýrak (object k, DragEventArgs o) {Console.WriteLine ("SürükleBýrak");}
        private void Form2_SürükleTerk (object k, EventArgs o) {Console.WriteLine ("SürükleTerk");}
        private void Form2_SürükleGir (object k, DragEventArgs o) {Console.WriteLine ("SürükleGir");}
        private void Form2_ÜstüneSürükle (object k, DragEventArgs o) {Console.WriteLine ("ÜstüneSürükle");}
        private void Form2_EtkinleþenDeðiþti (object k, EventArgs o) {Console.WriteLine ("EtkinleþenDeðiþti");}
        private void Form2_Gir (object k, EventArgs o) {Console.WriteLine ("Gir");}
        private void Form2_YazýfonuDeðiþti (object k, EventArgs o) {Console.WriteLine ("YazýfonuDeðiþti");}
        private void Form2_YazýrengiDeðiþti (object k, EventArgs o) {Console.WriteLine ("YazýrengiDeðiþti");}
        private void Form2_FormKapandý (object k, FormClosedEventArgs o) {Console.WriteLine ("FormKapandý");}
        private void Form2_FormKapanýyor (object k, FormClosingEventArgs o) {Console.WriteLine ("FormKapanýyor");}
        private void Form2_GeribeslemeVer (object k, GiveFeedbackEventArgs o) {Console.WriteLine ("GeribeslemeVer");}
        private void Form2_DüðmeTýklandýYardýmý (object k, CancelEventArgs o) {Console.WriteLine ("DüðmeTýklandýYardýmý");}
        private void Form2_YardýmÝstendi (object k, HelpEventArgs hlpevent) {Console.WriteLine ("YardýmÝstendi");}
        private void Form2_ImeKipiDeðiþti (object k, EventArgs o) {Console.WriteLine ("ImeKipiDeðiþti");}
        private void Form2_GiriþDiliDeðiþti (object k, InputLanguageChangedEventArgs o) {Console.WriteLine ("GiriþDiliDeðiþti");}
        private void Form2_GiriþDiliDeðiþiyor (object k, InputLanguageChangingEventArgs o) {Console.WriteLine ("GiriþDiliDeðiþiyor");}
        private void Form2_TuþAþaðý (object k, KeyEventArgs o) {Console.WriteLine ("TuþAþaðý");}
        private void Form2_TuþBas (object k, KeyPressEventArgs o) {Console.WriteLine ("TuþBas");}
        private void Form2_TuþYukarý (object k, KeyEventArgs o) {Console.WriteLine ("TuþYukarý");}
        private void Form2_Serilim (object k, LayoutEventArgs o) {Console.WriteLine ("Serilim");}
        private void Form2_Terket (object k, EventArgs o) {Console.WriteLine ("Terket");}
        private void Form2_Yükle (object k, EventArgs o) {Console.WriteLine ("Yükle");}
        private void Form2_KonumDeðiþti (object k, EventArgs o) {Console.WriteLine ("KonumDeðiþti");}
        private void Form2_MarjDeðiþti (object k, EventArgs o) {Console.WriteLine ("MarjDeðiþti");}
        private void Form2_AzamiSýnýrlarDeðiþti (object k, EventArgs o) {Console.WriteLine ("AzamiSýnýrlarDeðiþti");}
        private void Form2_AzamiEbatDeðiþti (object k, EventArgs o) {Console.WriteLine ("AzamiEbatDeðiþti");}
        private void Form2_MdiYavruAktif (object k, EventArgs o) {Console.WriteLine ("MdiYavruAktif");}
        private void Form2_MenüTamam (object k, EventArgs o) {Console.WriteLine ("MenüTamam");}
        private void Form2_MenüBaþlar (object k, EventArgs o) {Console.WriteLine ("MenüBaþlar");}
        private void Form2_AsgariEbatDeðiþti (object k, EventArgs o) {Console.WriteLine ("AsgariEbatDeðiþti");}
        private void Form2_FareTutkusuDeðiþti (object k, EventArgs o) {Console.WriteLine ("FareTutkusuDeðiþti");}
        private void Form2_FareTýklandý (object k, MouseEventArgs o) {Console.WriteLine ("FareTýklandý");}
        private void Form2_FareÇiftTýklandý (object k, MouseEventArgs o) {Console.WriteLine ("FareÇiftTýklandý");}
        private void Form2_FareAþaðý (object k, MouseEventArgs o) {Console.WriteLine ("FareAþaðý");}
        private void Form2_FareGir (object k, EventArgs o) {Console.WriteLine ("FareGir");}
        private void Form2_FareÜstte (object k, EventArgs o) {Console.WriteLine ("FareÜstte");}
        private void Form2_FareTerk (object k, EventArgs o) {Console.WriteLine ("FareTerk");}
        private void Form2_FareTaþý (object k, MouseEventArgs o) {Console.WriteLine ("FareTaþý");}
        private void Form2_FareYukarý (object k, MouseEventArgs o) {Console.WriteLine ("FareYukarý");}
        private void Form2_Taþý (object k, EventArgs o) {Console.WriteLine ("Taþý");}
        private void Form2_TamponlamaDeðiþti (object k, EventArgs o) {Console.WriteLine ("TamponlamaDeðiþti");}
        private void Form2_Boya (object k, PaintEventArgs o) {Console.WriteLine ("Boya");}
        private void Form2_EbeveynDeðiþti (object k, EventArgs o) {Console.WriteLine ("EbeveynDeðiþti");}
        private void Form2_SorguEriþebilirliðiYardýmý (object k, QueryAccessibilityHelpEventArgs o) {Console.WriteLine ("SorguEriþebilirliðiYardýmý");}
        private void Form2_SorguDevamSürükle (object k, QueryContinueDragEventArgs o) {Console.WriteLine ("SorguDevamSürükle");}
        private void Form2_BölgeDeðiþti (object k, EventArgs o) {Console.WriteLine ("BölgeDeðiþti");}
        private void Form2_TkrEbatla (object k, EventArgs o) {Console.WriteLine ("TkrEbatla");}
        private void Form2_TkrEbatlaBaþý (object k, EventArgs o) {Console.WriteLine ("TkrEbatlaBaþý");}
        private void Form2_TkrEbatlaSonu (object k, EventArgs o) {Console.WriteLine ("TkrEbatlaSonu");}
        private void Form2_SaðdanSolaDeðiþti (object k, EventArgs o) {Console.WriteLine ("SaðdanSolaDeðiþti");}
        private void Form2_SaðdanSolaSerilimDeðiþti (object k, EventArgs o) {Console.WriteLine ("SaðdanSolaSerilimDeðiþti");}
        private void Form2_Kaydýr (object k, ScrollEventArgs o) {Console.WriteLine ("Kaydýr");}
        private void Form2_Görünen (object k, EventArgs o) {Console.WriteLine ("Görünen");}
        private void Form2_EbatDeðiþti (object k, EventArgs o) {Console.WriteLine ("EbatDeðiþti");}
        private void Form2_YazýstiliDeðiþti (object k, EventArgs o) {Console.WriteLine ("YazýstiliDeðiþti");}
        private void Form2_SistemRenkleriDeðiþti (object k, EventArgs o) {Console.WriteLine ("SistemRenkleriDeðiþti");}
        private void Form2_MetinDeðiþti (object k, EventArgs o) {Console.WriteLine ("MetinDeðiþti");}
        private void Form2_Geçerlilendi (object k, EventArgs o) {Console.WriteLine ("Geçerlilendi");}
        private void Form2_Geçerlileniyor (object k, CancelEventArgs o) {Console.WriteLine ("Geçerlileniyor");}
        private void Form2_GörünebilirlikDeðiþti (object k, EventArgs o) {Console.WriteLine ("GörünebilirlikDeðiþti");}
    }
    partial class Form2 {//Form2'nin devamý
        Button düðme2;
        private void BileþeniBaþlat() {
            düðme2 = new Button();
            SuspendLayout();
            // düðme2
            düðme2.Location = new Point (87, 79);
            düðme2.Name = "düðme2";
            düðme2.Size = new Size (125, 23);
            düðme2.TabIndex = 0;
            düðme2.Text = "Olaysýz Düðme";
            // Form2
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (düðme2);
            Name = "Form2";
            Text = "Form2";
            CursorChanged += new EventHandler (Form2_ÝmleçDeðiþti);
            RightToLeftLayoutChanged += new EventHandler (Form2_SaðdanSolaSerilimDeðiþti);
            QueryContinueDrag += new QueryContinueDragEventHandler (Form2_SorguDevamSürükle);
            Deactivate += new EventHandler (Form2_Deaktiflendi);
            Load += new EventHandler (Form2_Yükle);
            BackgroundImageLayoutChanged += new EventHandler (Form2_ZeminResmiSerilimiDeðiþti);
            RightToLeftChanged += new EventHandler (Form2_SaðdanSolaDeðiþti);
            DragLeave += new EventHandler (Form2_SürükleTerk);
            InputLanguageChanged += new InputLanguageChangedEventHandler (Form2_GiriþDiliDeðiþti);
            Validating += new CancelEventHandler (Form2_Geçerlileniyor);
            BackgroundImageChanged += new EventHandler (Form2_ZeminResmiDeðiþti);
            MouseDoubleClick += new MouseEventHandler (Form2_FareÇiftTýklandý);
            DragEnter += new DragEventHandler (Form2_SürükleGir);
            ControlAdded += new ControlEventHandler (Form2_KontrolEklendi);
            FontChanged += new EventHandler (Form2_YazýfonuDeðiþti);
            MaximizedBoundsChanged += new EventHandler (Form2_AzamiSýnýrlarDeðiþti);
            AutoSizeChanged += new EventHandler (Form2_OtoEbatDeðiþti);
            Paint += new PaintEventHandler (Form2_Boya);
            VisibleChanged += new EventHandler (Form2_GörünebilirlikDeðiþti);
            BindingContextChanged += new EventHandler (Form2_BaðlamsalÝçerikDeðiþti);
            HelpButtonClicked += new CancelEventHandler (Form2_DüðmeTýklandýYardýmý);
            EnabledChanged += new EventHandler (Form2_EtkinleþenDeðiþti);
            MouseDown += new MouseEventHandler (Form2_FareAþaðý);
            ContextMenuStripChanged += new EventHandler (Form2_BaðlamMenüÞeridiDeðiþti);
            Scroll += new ScrollEventHandler (Form2_Kaydýr);
            MouseLeave += new EventHandler (Form2_FareTerk);
            MouseClick += new MouseEventHandler (Form2_FareTýklandý);
            Validated += new EventHandler (Form2_Geçerlilendi);
            ParentChanged += new EventHandler (Form2_EbeveynDeðiþti);
            Resize += new EventHandler (Form2_TkrEbatla);
            ControlRemoved += new ControlEventHandler (Form2_KontrolSilindi);
            Shown += new EventHandler (Form2_Görünen);
            AutoValidateChanged += new EventHandler (Form2_OtoGeçerlilemeDeðiþti);
            SizeChanged += new EventHandler (Form2_EbatDeðiþti);
            DoubleClick += new EventHandler (Form2_ÇiftTýklandý);
            Activated += new EventHandler (Form2_Aktiflendi);
            Enter += new EventHandler (Form2_Gir);
            Layout += new LayoutEventHandler (Form2_Serilim);
            MouseUp += new MouseEventHandler (Form2_FareYukarý);
            StyleChanged += new EventHandler (Form2_YazýstiliDeðiþti);
            ForeColorChanged += new EventHandler (Form2_YazýrengiDeðiþti);
            DragDrop += new DragEventHandler (Form2_SürükleBýrak);
            MouseEnter += new EventHandler (Form2_FareGir);
            MdiChildActivate += new EventHandler (Form2_MdiYavruAktif);
            Leave += new EventHandler (Form2_Terket);
            MouseMove += new MouseEventHandler (Form2_FareTaþý);
            MinimumSizeChanged += new EventHandler (Form2_AsgariEbatDeðiþti);
            Move += new EventHandler (Form2_Taþý);
            MouseCaptureChanged += new EventHandler (Form2_FareTutkusuDeðiþti);
            FormClosed += new FormClosedEventHandler (Form2_FormKapandý);
            PaddingChanged += new EventHandler (Form2_TamponlamaDeðiþti);
            KeyPress += new KeyPressEventHandler (Form2_TuþBas);
            ChangeUICues += new UICuesEventHandler (Form2_KAÝpuçlarýDeðiþti); //KA:Kullanýcý Arayüz
            DockChanged += new EventHandler (Form2_HavuzDeðiþti);
            GiveFeedback += new GiveFeedbackEventHandler (Form2_GeribeslemeVer);
            ImeModeChanged += new EventHandler (Form2_ImeKipiDeðiþti);
            Click += new EventHandler (Form2_Týklandý);
            SystemColorsChanged += new EventHandler (Form2_SistemRenkleriDeðiþti);
            QueryAccessibilityHelp += new QueryAccessibilityHelpEventHandler (Form2_SorguEriþebilirliðiYardýmý);
            FormClosing += new FormClosingEventHandler (Form2_FormKapanýyor);
            RegionChanged += new EventHandler (Form2_BölgeDeðiþti);
            KeyUp += new KeyEventHandler (Form2_TuþYukarý);
            MarginChanged += new EventHandler (Form2_MarjDeðiþti);
            TextChanged += new EventHandler (Form2_MetinDeðiþti);
            ResizeBegin += new EventHandler (Form2_TkrEbatlaBaþý);
            HelpRequested += new HelpEventHandler (Form2_YardýmÝstendi);
            LocationChanged += new EventHandler (Form2_KonumDeðiþti);
            KeyDown += new KeyEventHandler (Form2_TuþAþaðý);
            BackColorChanged += new EventHandler (Form2_ZeminRengiDeðiþti);
            InputLanguageChanging += new InputLanguageChangingEventHandler (Form2_GiriþDiliDeðiþiyor);
            MenuStart += new EventHandler (Form2_MenüBaþlar);
            MouseHover += new EventHandler (Form2_FareÜstte);
            ResizeEnd += new EventHandler (Form2_TkrEbatlaSonu);
            DragOver += new DragEventHandler (Form2_ÜstüneSürükle);
            CausesValidationChanged += new EventHandler (Form2_NedenselGeçerlilemeDeðiþti);
            MenuComplete += new EventHandler (Form2_MenüTamam);
            MaximumSizeChanged += new EventHandler (Form2_AzamiEbatDeðiþti);
            ResumeLayout (false);
        }
    }
    public class Form3: Form {
        private Container kab=null;
        public Form3() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            BackColor=Color.Sienna;
            Text="Tekrar Ebatla";
            Resize += new EventHandler (Form3_TkrEbatla);
        }
        private void Form3_TkrEbatla (object k, System.EventArgs o) {
            Invalidate();
            Console.Write ("TkrEbatlanýyor ");
        }
        protected override void Dispose (bool çöp) {
            if(çöp) if (kab != null) kab.Dispose();
            base.Dispose (çöp);
        }
    }
    public class Form4: Form {
        private Container kab=null;
        public Form4() {BileþeniBaþlat();} //Kurucu
        private void BileþeniBaþlat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (392, 173);
            BackColor=Color.Magenta;
            Text = "Boya ile metin yazma";
            Resize += new EventHandler (Form4_TkrEbatla);
            Paint += new PaintEventHandler (Form4_Boya);
        }
        private void Form4_TkrEbatla (object k, System.EventArgs o) {
            Invalidate();
            Console.Write ("TkrEbatlanýyor ");
        }
        protected override void Dispose (bool çöp) {
            if(çöp) if (kab != null) kab.Dispose();
            base.Dispose (çöp);
        }
        private void Form4_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yavaþ", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Navy), 
                DisplayRectangle);    
        }
    }
    class FormEvent {
        static Form form5a, form5b, form5c;
        static void BoyaYönetimi (object kim, PaintEventArgs o) {
            Form form = (Form)kim;
            Graphics gr = o.Graphics;
            string dizge;
            if(form == form5a) dizge = "Form5a'dan merhabalar";
            else if(form == form5c) dizge = "Form5b'den merhabalar";
            else dizge = "Form5c'den merhabalar";
            gr.DrawString (dizge, new Font ("Times New Roman", 20), Brushes.Ivory, 0, 0);
        }
        [STAThread]
        static void Main() {
            Console.Write ("Buton týklama olayý 'düðme.Click += new EventHandler(düðme_Týklandý)' ile yakalanýr ve olayýn metodu 'void düðme_Týklandý(object gönderen, EventArgs olay){}' ile çaðrýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Forma dair olaylarýn '+=EventHandler(metot)'la yakalanýp yönetilmesi:");
            Application.Run (new Form1());
            Application.EnableVisualStyles(); Application.Run (new Form2()); MessageBox.Show ("Sonlandýrmak için [TAMAM] týkla");
            Application.Run (new Form3()); Console.WriteLine();
            Application.Run (new Form4()); Console.WriteLine();
            form5a = new Form(); form5b = new Form(); form5c = new Form();
            form5a.Text = "Ýlk Form"; form5a.BackColor = Color.Black; form5a.Paint += new PaintEventHandler (BoyaYönetimi);
            form5b.Text = "Ýkinci Form"; form5b.BackColor = Color.Maroon; form5b.Paint += new PaintEventHandler (BoyaYönetimi); form5b.Show();
            form5c.Text = "Üçüncü Form"; form5c.BackColor = Color.DeepPink; form5c.Paint += new PaintEventHandler (BoyaYönetimi); form5c.Show();
            Application.Run (form5a);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}