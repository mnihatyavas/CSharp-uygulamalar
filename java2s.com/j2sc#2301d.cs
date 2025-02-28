// j2sc#2301d.cs: EventHandler(metot) ile olaylar�n y�netilmesi �rne�i.

using System;
using System.Windows.Forms; //Form, Button, Label i�in
using System.Drawing; //Size i�in
using System.ComponentModel; //CancelEventArgs i�in
namespace Formlar {
    public class Form1: Form {
        private Button d��me1 = new Button();
        private Label yafta1 = new Label();
        int xD��meEbat�, yD��meEbat�;
        public Form1() {//Kurucu
            d��me1.Parent = this;
            d��me1.Text = "Dinamik D��me �zellikleri";
            Size = new Size (400, 400);//Form1 ebat�
            xD��meEbat� = (int)(Font.Height * 0.75) * d��me1.Text.Length;
            yD��meEbat� = Font.Height * 2;
            d��me1.Size = new Size (xD��meEbat�, yD��meEbat�);
            d��me1.BackColor = Color.Red;
            d��me1.ForeColor = Color.Yellow;
            d��me1.Click += new EventHandler (d��me1_T�kland�);
            yafta1.ForeColor = Color.Blue;
            yafta1.Text = "Dinamik Ebat ve Konum Kontrolu";
            yafta1.AutoSize = true;
            yafta1.Parent = this;
            OnResize (EventArgs.Empty);
            BackColor = Color.Lime;
        }
        private void d��me1_T�kland� (object kim, EventArgs olay) {
            Console.WriteLine ("D��me Bottom: " + d��me1.Bottom.ToString());
            Console.WriteLine ("D��me Top: " + d��me1.Top);
            Console.WriteLine ("D��me Left: " + d��me1.Left);
            Console.WriteLine ("D��me Right: " + d��me1.Right);
            Console.WriteLine ("D��me Location: " + d��me1.Location);
            Console.WriteLine ("D��me Width: " + d��me1.Width);
            Console.WriteLine ("D��me Height: " + d��me1.Height);
            Console.WriteLine ("D��me Size: " + d��me1.Size);
            Console.WriteLine ("D��me ClientSize: " + d��me1.ClientSize);
            Console.WriteLine ("D��me Font: " + d��me1.Font);
        }
        protected override void OnResize (EventArgs oly) {//D��me1'in Form1 i�indeki  konum de�i�im g�ncelleme
            base.OnResize (oly);
            int xKonum = (int)(this.ClientSize.Width / 2) - (int)(xD��meEbat� / 2);
            int yKonum = (int)(this.ClientSize.Height / 2) - (int)(yD��meEbat� / 2);
            d��me1.Location = new Point (xKonum, yKonum);
        }
    }
    public partial class Form2: Form {
        public Form2() {Bile�eniBa�lat();} //Kurucu
        //T�m Form olaylar�n�n metotlar�
        private void Form2_Aktiflendi (object k, EventArgs o) {Console.WriteLine ("Aktiflenti");}
        private void Form2_OtoEbatDe�i�ti (object k, EventArgs o) {Console.WriteLine ("OtoEbatDe�i�ti");}
        private void Form2_OtoGe�erlilemeDe�i�ti (object k, EventArgs o) {Console.WriteLine ("OtoGe�erlilemeDe�i�ti");}
        private void Form2_ZeminRengiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("ZeminRengiDe�i�ti");}
        private void Form2_ZeminResmiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("ZeminResmiDe�i�ti");}
        private void Form2_ZeminResmiSerilimiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("ZeminResmiSerilimiDe�i�ti");}
        private void Form2_Ba�lamsal��erikDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Ba�lamsal��erikDe�i�ti");}
        private void Form2_NedenselGe�erlilemeDe�i�ti (object k, EventArgs o) {Console.WriteLine ("NedenselGe�erlilemeDe�i�ti");}
        private void Form2_KA�pu�lar�De�i�ti (object k, UICuesEventArgs o) {Console.WriteLine ("KA�pu�lar�De�i�ti");}
        private void Form2_T�kland� (object k, EventArgs o) {Console.WriteLine ("T�kland�");}
        private void Form2_Ba�lamMen��eridiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Ba�lamMen��eridiDe�i�ti");}
        private void Form2_KontrolEklendi (object k, ControlEventArgs o) {Console.WriteLine ("KontrolEklendi");}
        private void Form2_KontrolSilindi (object k, ControlEventArgs o) {Console.WriteLine ("KontrolSilindi");}
        private void Form2_�mle�De�i�ti (object k, EventArgs o) {Console.WriteLine ("�mle�De�i�ti");}
        private void Form2_Deaktiflendi (object k, EventArgs o) {Console.WriteLine ("Deaktiflendi");}
        private void Form2_HavuzDe�i�ti (object k, EventArgs o) {Console.WriteLine ("HavuzDe�i�ti");}
        private void Form2_�iftT�kland� (object k, EventArgs o) {Console.WriteLine ("�iftT�kland�");}
        private void Form2_S�r�kleB�rak (object k, DragEventArgs o) {Console.WriteLine ("S�r�kleB�rak");}
        private void Form2_S�r�kleTerk (object k, EventArgs o) {Console.WriteLine ("S�r�kleTerk");}
        private void Form2_S�r�kleGir (object k, DragEventArgs o) {Console.WriteLine ("S�r�kleGir");}
        private void Form2_�st�neS�r�kle (object k, DragEventArgs o) {Console.WriteLine ("�st�neS�r�kle");}
        private void Form2_Etkinle�enDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Etkinle�enDe�i�ti");}
        private void Form2_Gir (object k, EventArgs o) {Console.WriteLine ("Gir");}
        private void Form2_Yaz�fonuDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Yaz�fonuDe�i�ti");}
        private void Form2_Yaz�rengiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Yaz�rengiDe�i�ti");}
        private void Form2_FormKapand� (object k, FormClosedEventArgs o) {Console.WriteLine ("FormKapand�");}
        private void Form2_FormKapan�yor (object k, FormClosingEventArgs o) {Console.WriteLine ("FormKapan�yor");}
        private void Form2_GeribeslemeVer (object k, GiveFeedbackEventArgs o) {Console.WriteLine ("GeribeslemeVer");}
        private void Form2_D��meT�kland�Yard�m� (object k, CancelEventArgs o) {Console.WriteLine ("D��meT�kland�Yard�m�");}
        private void Form2_Yard�m�stendi (object k, HelpEventArgs hlpevent) {Console.WriteLine ("Yard�m�stendi");}
        private void Form2_ImeKipiDe�i�ti (object k, EventArgs o) {Console.WriteLine ("ImeKipiDe�i�ti");}
        private void Form2_Giri�DiliDe�i�ti (object k, InputLanguageChangedEventArgs o) {Console.WriteLine ("Giri�DiliDe�i�ti");}
        private void Form2_Giri�DiliDe�i�iyor (object k, InputLanguageChangingEventArgs o) {Console.WriteLine ("Giri�DiliDe�i�iyor");}
        private void Form2_Tu�A�a�� (object k, KeyEventArgs o) {Console.WriteLine ("Tu�A�a��");}
        private void Form2_Tu�Bas (object k, KeyPressEventArgs o) {Console.WriteLine ("Tu�Bas");}
        private void Form2_Tu�Yukar� (object k, KeyEventArgs o) {Console.WriteLine ("Tu�Yukar�");}
        private void Form2_Serilim (object k, LayoutEventArgs o) {Console.WriteLine ("Serilim");}
        private void Form2_Terket (object k, EventArgs o) {Console.WriteLine ("Terket");}
        private void Form2_Y�kle (object k, EventArgs o) {Console.WriteLine ("Y�kle");}
        private void Form2_KonumDe�i�ti (object k, EventArgs o) {Console.WriteLine ("KonumDe�i�ti");}
        private void Form2_MarjDe�i�ti (object k, EventArgs o) {Console.WriteLine ("MarjDe�i�ti");}
        private void Form2_AzamiS�n�rlarDe�i�ti (object k, EventArgs o) {Console.WriteLine ("AzamiS�n�rlarDe�i�ti");}
        private void Form2_AzamiEbatDe�i�ti (object k, EventArgs o) {Console.WriteLine ("AzamiEbatDe�i�ti");}
        private void Form2_MdiYavruAktif (object k, EventArgs o) {Console.WriteLine ("MdiYavruAktif");}
        private void Form2_Men�Tamam (object k, EventArgs o) {Console.WriteLine ("Men�Tamam");}
        private void Form2_Men�Ba�lar (object k, EventArgs o) {Console.WriteLine ("Men�Ba�lar");}
        private void Form2_AsgariEbatDe�i�ti (object k, EventArgs o) {Console.WriteLine ("AsgariEbatDe�i�ti");}
        private void Form2_FareTutkusuDe�i�ti (object k, EventArgs o) {Console.WriteLine ("FareTutkusuDe�i�ti");}
        private void Form2_FareT�kland� (object k, MouseEventArgs o) {Console.WriteLine ("FareT�kland�");}
        private void Form2_Fare�iftT�kland� (object k, MouseEventArgs o) {Console.WriteLine ("Fare�iftT�kland�");}
        private void Form2_FareA�a�� (object k, MouseEventArgs o) {Console.WriteLine ("FareA�a��");}
        private void Form2_FareGir (object k, EventArgs o) {Console.WriteLine ("FareGir");}
        private void Form2_Fare�stte (object k, EventArgs o) {Console.WriteLine ("Fare�stte");}
        private void Form2_FareTerk (object k, EventArgs o) {Console.WriteLine ("FareTerk");}
        private void Form2_FareTa�� (object k, MouseEventArgs o) {Console.WriteLine ("FareTa��");}
        private void Form2_FareYukar� (object k, MouseEventArgs o) {Console.WriteLine ("FareYukar�");}
        private void Form2_Ta�� (object k, EventArgs o) {Console.WriteLine ("Ta��");}
        private void Form2_TamponlamaDe�i�ti (object k, EventArgs o) {Console.WriteLine ("TamponlamaDe�i�ti");}
        private void Form2_Boya (object k, PaintEventArgs o) {Console.WriteLine ("Boya");}
        private void Form2_EbeveynDe�i�ti (object k, EventArgs o) {Console.WriteLine ("EbeveynDe�i�ti");}
        private void Form2_SorguEri�ebilirli�iYard�m� (object k, QueryAccessibilityHelpEventArgs o) {Console.WriteLine ("SorguEri�ebilirli�iYard�m�");}
        private void Form2_SorguDevamS�r�kle (object k, QueryContinueDragEventArgs o) {Console.WriteLine ("SorguDevamS�r�kle");}
        private void Form2_B�lgeDe�i�ti (object k, EventArgs o) {Console.WriteLine ("B�lgeDe�i�ti");}
        private void Form2_TkrEbatla (object k, EventArgs o) {Console.WriteLine ("TkrEbatla");}
        private void Form2_TkrEbatlaBa�� (object k, EventArgs o) {Console.WriteLine ("TkrEbatlaBa��");}
        private void Form2_TkrEbatlaSonu (object k, EventArgs o) {Console.WriteLine ("TkrEbatlaSonu");}
        private void Form2_Sa�danSolaDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Sa�danSolaDe�i�ti");}
        private void Form2_Sa�danSolaSerilimDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Sa�danSolaSerilimDe�i�ti");}
        private void Form2_Kayd�r (object k, ScrollEventArgs o) {Console.WriteLine ("Kayd�r");}
        private void Form2_G�r�nen (object k, EventArgs o) {Console.WriteLine ("G�r�nen");}
        private void Form2_EbatDe�i�ti (object k, EventArgs o) {Console.WriteLine ("EbatDe�i�ti");}
        private void Form2_Yaz�stiliDe�i�ti (object k, EventArgs o) {Console.WriteLine ("Yaz�stiliDe�i�ti");}
        private void Form2_SistemRenkleriDe�i�ti (object k, EventArgs o) {Console.WriteLine ("SistemRenkleriDe�i�ti");}
        private void Form2_MetinDe�i�ti (object k, EventArgs o) {Console.WriteLine ("MetinDe�i�ti");}
        private void Form2_Ge�erlilendi (object k, EventArgs o) {Console.WriteLine ("Ge�erlilendi");}
        private void Form2_Ge�erlileniyor (object k, CancelEventArgs o) {Console.WriteLine ("Ge�erlileniyor");}
        private void Form2_G�r�nebilirlikDe�i�ti (object k, EventArgs o) {Console.WriteLine ("G�r�nebilirlikDe�i�ti");}
    }
    partial class Form2 {//Form2'nin devam�
        Button d��me2;
        private void Bile�eniBa�lat() {
            d��me2 = new Button();
            SuspendLayout();
            // d��me2
            d��me2.Location = new Point (87, 79);
            d��me2.Name = "d��me2";
            d��me2.Size = new Size (125, 23);
            d��me2.TabIndex = 0;
            d��me2.Text = "Olays�z D��me";
            // Form2
            AutoScaleDimensions = new SizeF (6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (292, 266);
            Controls.Add (d��me2);
            Name = "Form2";
            Text = "Form2";
            CursorChanged += new EventHandler (Form2_�mle�De�i�ti);
            RightToLeftLayoutChanged += new EventHandler (Form2_Sa�danSolaSerilimDe�i�ti);
            QueryContinueDrag += new QueryContinueDragEventHandler (Form2_SorguDevamS�r�kle);
            Deactivate += new EventHandler (Form2_Deaktiflendi);
            Load += new EventHandler (Form2_Y�kle);
            BackgroundImageLayoutChanged += new EventHandler (Form2_ZeminResmiSerilimiDe�i�ti);
            RightToLeftChanged += new EventHandler (Form2_Sa�danSolaDe�i�ti);
            DragLeave += new EventHandler (Form2_S�r�kleTerk);
            InputLanguageChanged += new InputLanguageChangedEventHandler (Form2_Giri�DiliDe�i�ti);
            Validating += new CancelEventHandler (Form2_Ge�erlileniyor);
            BackgroundImageChanged += new EventHandler (Form2_ZeminResmiDe�i�ti);
            MouseDoubleClick += new MouseEventHandler (Form2_Fare�iftT�kland�);
            DragEnter += new DragEventHandler (Form2_S�r�kleGir);
            ControlAdded += new ControlEventHandler (Form2_KontrolEklendi);
            FontChanged += new EventHandler (Form2_Yaz�fonuDe�i�ti);
            MaximizedBoundsChanged += new EventHandler (Form2_AzamiS�n�rlarDe�i�ti);
            AutoSizeChanged += new EventHandler (Form2_OtoEbatDe�i�ti);
            Paint += new PaintEventHandler (Form2_Boya);
            VisibleChanged += new EventHandler (Form2_G�r�nebilirlikDe�i�ti);
            BindingContextChanged += new EventHandler (Form2_Ba�lamsal��erikDe�i�ti);
            HelpButtonClicked += new CancelEventHandler (Form2_D��meT�kland�Yard�m�);
            EnabledChanged += new EventHandler (Form2_Etkinle�enDe�i�ti);
            MouseDown += new MouseEventHandler (Form2_FareA�a��);
            ContextMenuStripChanged += new EventHandler (Form2_Ba�lamMen��eridiDe�i�ti);
            Scroll += new ScrollEventHandler (Form2_Kayd�r);
            MouseLeave += new EventHandler (Form2_FareTerk);
            MouseClick += new MouseEventHandler (Form2_FareT�kland�);
            Validated += new EventHandler (Form2_Ge�erlilendi);
            ParentChanged += new EventHandler (Form2_EbeveynDe�i�ti);
            Resize += new EventHandler (Form2_TkrEbatla);
            ControlRemoved += new ControlEventHandler (Form2_KontrolSilindi);
            Shown += new EventHandler (Form2_G�r�nen);
            AutoValidateChanged += new EventHandler (Form2_OtoGe�erlilemeDe�i�ti);
            SizeChanged += new EventHandler (Form2_EbatDe�i�ti);
            DoubleClick += new EventHandler (Form2_�iftT�kland�);
            Activated += new EventHandler (Form2_Aktiflendi);
            Enter += new EventHandler (Form2_Gir);
            Layout += new LayoutEventHandler (Form2_Serilim);
            MouseUp += new MouseEventHandler (Form2_FareYukar�);
            StyleChanged += new EventHandler (Form2_Yaz�stiliDe�i�ti);
            ForeColorChanged += new EventHandler (Form2_Yaz�rengiDe�i�ti);
            DragDrop += new DragEventHandler (Form2_S�r�kleB�rak);
            MouseEnter += new EventHandler (Form2_FareGir);
            MdiChildActivate += new EventHandler (Form2_MdiYavruAktif);
            Leave += new EventHandler (Form2_Terket);
            MouseMove += new MouseEventHandler (Form2_FareTa��);
            MinimumSizeChanged += new EventHandler (Form2_AsgariEbatDe�i�ti);
            Move += new EventHandler (Form2_Ta��);
            MouseCaptureChanged += new EventHandler (Form2_FareTutkusuDe�i�ti);
            FormClosed += new FormClosedEventHandler (Form2_FormKapand�);
            PaddingChanged += new EventHandler (Form2_TamponlamaDe�i�ti);
            KeyPress += new KeyPressEventHandler (Form2_Tu�Bas);
            ChangeUICues += new UICuesEventHandler (Form2_KA�pu�lar�De�i�ti); //KA:Kullan�c� Aray�z
            DockChanged += new EventHandler (Form2_HavuzDe�i�ti);
            GiveFeedback += new GiveFeedbackEventHandler (Form2_GeribeslemeVer);
            ImeModeChanged += new EventHandler (Form2_ImeKipiDe�i�ti);
            Click += new EventHandler (Form2_T�kland�);
            SystemColorsChanged += new EventHandler (Form2_SistemRenkleriDe�i�ti);
            QueryAccessibilityHelp += new QueryAccessibilityHelpEventHandler (Form2_SorguEri�ebilirli�iYard�m�);
            FormClosing += new FormClosingEventHandler (Form2_FormKapan�yor);
            RegionChanged += new EventHandler (Form2_B�lgeDe�i�ti);
            KeyUp += new KeyEventHandler (Form2_Tu�Yukar�);
            MarginChanged += new EventHandler (Form2_MarjDe�i�ti);
            TextChanged += new EventHandler (Form2_MetinDe�i�ti);
            ResizeBegin += new EventHandler (Form2_TkrEbatlaBa��);
            HelpRequested += new HelpEventHandler (Form2_Yard�m�stendi);
            LocationChanged += new EventHandler (Form2_KonumDe�i�ti);
            KeyDown += new KeyEventHandler (Form2_Tu�A�a��);
            BackColorChanged += new EventHandler (Form2_ZeminRengiDe�i�ti);
            InputLanguageChanging += new InputLanguageChangingEventHandler (Form2_Giri�DiliDe�i�iyor);
            MenuStart += new EventHandler (Form2_Men�Ba�lar);
            MouseHover += new EventHandler (Form2_Fare�stte);
            ResizeEnd += new EventHandler (Form2_TkrEbatlaSonu);
            DragOver += new DragEventHandler (Form2_�st�neS�r�kle);
            CausesValidationChanged += new EventHandler (Form2_NedenselGe�erlilemeDe�i�ti);
            MenuComplete += new EventHandler (Form2_Men�Tamam);
            MaximumSizeChanged += new EventHandler (Form2_AzamiEbatDe�i�ti);
            ResumeLayout (false);
        }
    }
    public class Form3: Form {
        private Container kab=null;
        public Form3() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (292, 273);
            BackColor=Color.Sienna;
            Text="Tekrar Ebatla";
            Resize += new EventHandler (Form3_TkrEbatla);
        }
        private void Form3_TkrEbatla (object k, System.EventArgs o) {
            Invalidate();
            Console.Write ("TkrEbatlan�yor ");
        }
        protected override void Dispose (bool ��p) {
            if(��p) if (kab != null) kab.Dispose();
            base.Dispose (��p);
        }
    }
    public class Form4: Form {
        private Container kab=null;
        public Form4() {Bile�eniBa�lat();} //Kurucu
        private void Bile�eniBa�lat() {
            AutoScaleBaseSize = new Size (5, 13);
            ClientSize = new Size (392, 173);
            BackColor=Color.Magenta;
            Text = "Boya ile metin yazma";
            Resize += new EventHandler (Form4_TkrEbatla);
            Paint += new PaintEventHandler (Form4_Boya);
        }
        private void Form4_TkrEbatla (object k, System.EventArgs o) {
            Invalidate();
            Console.Write ("TkrEbatlan�yor ");
        }
        protected override void Dispose (bool ��p) {
            if(��p) if (kab != null) kab.Dispose();
            base.Dispose (��p);
        }
        private void Form4_Boya (object k, PaintEventArgs o) {
            Graphics g = o.Graphics;
            g.DrawString ("M.Nihat Yava�", 
                new Font ("Times New Roman", 30), 
                new SolidBrush (Color.Navy), 
                DisplayRectangle);    
        }
    }
    class FormEvent {
        static Form form5a, form5b, form5c;
        static void BoyaY�netimi (object kim, PaintEventArgs o) {
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
            Console.Write ("Buton t�klama olay� 'd��me.Click += new EventHandler(d��me_T�kland�)' ile yakalan�r ve olay�n metodu 'void d��me_T�kland�(object g�nderen, EventArgs olay){}' ile �a�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Forma dair olaylar�n '+=EventHandler(metot)'la yakalan�p y�netilmesi:");
            Application.Run (new Form1());
            Application.EnableVisualStyles(); Application.Run (new Form2()); MessageBox.Show ("Sonland�rmak i�in [TAMAM] t�kla");
            Application.Run (new Form3()); Console.WriteLine();
            Application.Run (new Form4()); Console.WriteLine();
            form5a = new Form(); form5b = new Form(); form5c = new Form();
            form5a.Text = "�lk Form"; form5a.BackColor = Color.Black; form5a.Paint += new PaintEventHandler (BoyaY�netimi);
            form5b.Text = "�kinci Form"; form5b.BackColor = Color.Maroon; form5b.Paint += new PaintEventHandler (BoyaY�netimi); form5b.Show();
            form5c.Text = "���nc� Form"; form5c.BackColor = Color.DeepPink; form5c.Paint += new PaintEventHandler (BoyaY�netimi); form5c.Show();
            Application.Run (form5a);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}