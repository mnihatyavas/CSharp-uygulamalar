// jtpc#2101l2.cs: Form üzerine bir liste kutusu ekleme örneði.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    partial class ListeKutusuB: Form {
        public ListeKutusuB() {// Baþlat()'sýz doðrudan kurucuyla form kurma
            Text = "Liste Kutusu Uygulamasý";
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
            listeKutusu.Items.Add ("Fatma Yavaþ");
            listeKutusu.Items.Add ("Bekir Yavaþ");
            listeKutusu.Items.Add ("Haným Yavaþ");
            listeKutusu.Items.Add ("Memet Yavaþ");
            listeKutusu.Items.Add ("Hatice (Yavaþ) Kaçar");
            listeKutusu.Items.Add ("Süheyla (Yavaþ) Özbay");
            listeKutusu.Items.Add ("Zeliha (Yavaþ) Candan");
            listeKutusu.Items.Add ("M.Nihat Yavaþ");
            listeKutusu.Items.Add ("Songül (Yavaþ) Göktürk");
            listeKutusu.Items.Add ("M.Nedim Yavaþ");
            listeKutusu.Items.Add ("Sevim Yavaþ ");
            Controls.Add (listeKutusu);
        }
        static void Main() {Application.Run (new ListeKutusuB());}
    }
}