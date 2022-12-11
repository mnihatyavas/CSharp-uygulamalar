// tpc#17b.cs: Yap�sal Kitap'�n "new" ile yarat�lmas� ve fonksiyonlu de�er atama-g�sterme �rne�i.

using System;
struct Kitap {
    public string ba�l�k;
    public string yazar;
    public string konu;
    public short toplamSayfa;
    public int kimlikNo;

    public void de�erleriAl (string b, string y, string k, short ts, int no) {
        ba�l�k = b;
        yazar = y;
        konu = k;
        toplamSayfa = ts;
        kimlikNo = no;
    }
    public void g�ster() {
        Console.WriteLine ("\nKitab�n ba�l���: {0}", ba�l�k);
        Console.WriteLine ("Yazar�: {0}", yazar);
        Console.WriteLine ("Konusu: {0}", konu);
        Console.WriteLine ("Sayfa say�s�: {0}", toplamSayfa);
        Console.WriteLine ("Kimlik no'su: {0}", kimlikNo);
    }
}; // struct sonu...
namespace Yap�lar {
    class NewYap�salKay�t {
        static void Main (string[] args) {
            Console.Write ("Yap�larda metod, alan, endeksleyici, �zellik, i�lemci metodu ve olay bulunabilir.\nYap� kurucusu haricen de�il otomatikmen tan�mlan�r.\nYap� alanlar� abstract/soyut, virtual/sanal ve protected/korumal� olmaz.\nHerbir yap�sal kay�t de�er atama yada \"new\" i�lemci ile yarat�labilir.\nS�n�f referans, yap� ise de�er tiplidir.\nTu�..."); Console.ReadKey();

            Kitap Kitap1 = new Kitap(); // Kitap tipli Kitap1'in beyan�
            Kitap Kitap2 = new Kitap(); Kitap Kitap3 = new Kitap(); Kitap Kitap4 = new Kitap();

            // Kitap kay�tlar�n�n �zellik ve de�erleri
            Kitap1.de�erleriAl ("C# Programlama", "Hac� Ali Amanat", "C# programlama e�itimi", 645, 6495407);
            Kitap2.de�erleriAl ("Elektroni�in Temeli", "Memet Amanat", "LTspice ile elektronik devre sim�lasyonlar�", 892, 6495700);
            Kitap3.de�erleriAl ("HTML, CSS, JS", "Sabri Amanat", "MDN Mozilla-Firefox ile internet sayfa tasar�m�", 1534, 64957803);
            Kitap4.de�erleriAl ("Pythom Programlama", "B�lent Amanat", "Python ile programc�l�k, matriks, grafik ve pencereler", 1262, 6495908);

            // Kitap bilgilerinin ��kt�ya yazd�r�lmas�
            Kitap1.g�ster(); Kitap2.g�ster(); Kitap3.g�ster(); Kitap4.g�ster();
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}