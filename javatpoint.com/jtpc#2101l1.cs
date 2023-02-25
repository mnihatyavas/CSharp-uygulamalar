// jtpc#2101l1.cs: Windows.Forms i�ine bir listekutusu konumland�rma �rne�i.

using System;
using System.Windows.Forms;
using System.Drawing;
namespace Formlar {
    class ListeKutusuA: Form {
        public ListeKutusuA() {Ba�lat();} //Parametresiz kurucu metodu
        private void Ba�lat() {//ListeKutusu-->Ba�lat metodu
            Text = "Liste Kutusu Uygulamas�"; //Form ba�l���
            ClientSize = new Size (300, 150); //Form penceresi
            CenterToScreen(); //Formu ekrana ortalar
            ListBox listeKutusu = new ListBox(); //Liste kutusu
            listeKutusu.Location = new Point(70, 20);
            listeKutusu.Size = new Size (160, 100);
            listeKutusu.ForeColor = Color.Red;
            listeKutusu.BackColor = Color.Black;
            listeKutusu.Items.Add ("Fatma Yava�"); //Liste birimleri ekleme
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
            Controls.Add (listeKutusu); //Liste kutusunu Forma ekleme
        }
        static void Main() {
            Console.Write ("Form i�i ListBox() liste kutusunu �al��mazamanl� (Main metod i�inden Application.Run(new ListeKutusuA()) ifadesiyle) yaratmak i�in ListeKutusuA:Form s�n�f�n�n kurucu metodunda Ba�lat() metodunu �a��r�r�z. Ba�lat() metodu i�inde �ncelikle Text ile form ba�l���, ClientSize ile ebat� ve CenterToScreen() ile de formumuzu ekranda sol-sa� ile �st-alt aras�nda ortalar�z.\nSonra 'new ListBox()' liste kutusunu yarat�r ve Location, Size, ForeColor, BackColor ile kutuyu d�zenler, Item.Add ile de kutuya ard���k liste birimlerini ekleriz.\nForm.Controls.Add(listeKutusu) ise kutumuzu form �zerine ili�tirir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
            Application.Run (new ListeKutusuA()); //"Application.Run" gerekli
        }
    }
}