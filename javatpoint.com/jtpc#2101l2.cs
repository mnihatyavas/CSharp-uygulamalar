// jtpc#2101l2.cs: Form �zerine bir liste kutusu ekleme �rne�i.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    partial class ListeKutusuB: Form {
        public ListeKutusuB() {// Ba�lat()'s�z do�rudan kurucuyla form kurma
            Text = "Liste Kutusu Uygulamas�";
            ClientSize = new Size (280, 300);
            BackColor = Color.Maroon;
            CenterToScreen();
            ListBox listeKutusu = new ListBox();
            listeKutusu.Font = new Font ("Georgia", 14); 
            listeKutusu.Location = new Point (10, 10);
            //listeKutusu.Name = "Liste Kutusu";
            listeKutusu.Size = new Size (250, 280);
            listeKutusu.BackColor = Color.Navy;
            listeKutusu.ForeColor = Color.Lime;
            listeKutusu.Items.Add ("Fatma Yava�");
            listeKutusu.Items.Add ("Bekir Yava�");
            listeKutusu.Items.Add ("Han�m Yava�");
            listeKutusu.Items.Add ("Memet Yava�");
            listeKutusu.Items.Add ("Hatice (Yava�) Ka�ar");
            listeKutusu.Items.Add ("S�heyla (Yava�) �zbay");
            listeKutusu.Items.Add ("Zeliha (Yava�) Candan");
            listeKutusu.Items.Add ("M.Nihat Yava�");
            listeKutusu.Items.Add ("Song�l (Yava�) G�kt�rk");
            listeKutusu.Items.Add ("M.Nedim Yava�");
            listeKutusu.Items.Add ("Sevim Yava� ");
            Controls.Add (listeKutusu);
        }
        static void Main() {Application.Run (new ListeKutusuB());}
    }
}