// jtpc#2101l1.cs: Windows.Forms içine bir listekutusu konumlandýrma örneði.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class ListeKutusuA: Form {
        public ListeKutusuA() {Baþlat();} //Parametresiz kurucu metodu
        private void Baþlat() {//ListeKutusu-->Baþlat metodu
            Text = "Liste Kutusu Uygulamasý"; //Form baþlýðý
            ClientSize = new Size (300, 150); //Form penceresi
            CenterToScreen(); //Formu ekrana ortalar
            ListBox listeKutusu = new ListBox(); //Liste kutusu
            listeKutusu.Location = new Point(70, 20);
            listeKutusu.Size = new Size (160, 100);
            listeKutusu.ForeColor = Color.Red;
            listeKutusu.BackColor = Color.Black;
            listeKutusu.Items.Add ("Fatma Yavaþ"); //Liste birimleri ekleme
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
            Controls.Add (listeKutusu); //Liste kutusunu Forma ekleme
        }
        static void Main() {
            Console.Write ("Form içi ListBox() liste kutusunu çalýþmazamanlý (Main metod içinden Application.Run(new ListeKutusuA()) ifadesiyle) yaratmak için ListeKutusuA:Form sýnýfýnýn kurucu metodunda Baþlat() metodunu çaðýrýrýz. Baþlat() metodu içinde öncelikle Text ile form baþlýðý, ClientSize ile ebatý ve CenterToScreen() ile de formumuzu ekranda sol-sað ile üst-alt arasýnda ortalarýz.\nSonra 'new ListBox()' liste kutusunu yaratýr ve Location, Size, ForeColor, BackColor ile kutuyu düzenler, Item.Add ile de kutuya ardýþýk liste birimlerini ekleriz.\nForm.Controls.Add(listeKutusu) ise kutumuzu form üzerine iliþtirir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
            Application.Run (new ListeKutusuA()); //"Application.Run" gerekli
        }
    }
}