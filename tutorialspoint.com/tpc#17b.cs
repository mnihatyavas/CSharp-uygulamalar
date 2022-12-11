// tpc#17b.cs: Yapýsal Kitap'ýn "new" ile yaratýlmasý ve fonksiyonlu deðer atama-gösterme örneði.

using System;
struct Kitap {
    public string baþlýk;
    public string yazar;
    public string konu;
    public short toplamSayfa;
    public int kimlikNo;

    public void deðerleriAl (string b, string y, string k, short ts, int no) {
        baþlýk = b;
        yazar = y;
        konu = k;
        toplamSayfa = ts;
        kimlikNo = no;
    }
    public void göster() {
        Console.WriteLine ("\nKitabýn baþlýðý: {0}", baþlýk);
        Console.WriteLine ("Yazarý: {0}", yazar);
        Console.WriteLine ("Konusu: {0}", konu);
        Console.WriteLine ("Sayfa sayýsý: {0}", toplamSayfa);
        Console.WriteLine ("Kimlik no'su: {0}", kimlikNo);
    }
}; // struct sonu...
namespace Yapýlar {
    class NewYapýsalKayýt {
        static void Main (string[] args) {
            Console.Write ("Yapýlarda metod, alan, endeksleyici, özellik, iþlemci metodu ve olay bulunabilir.\nYapý kurucusu haricen deðil otomatikmen tanýmlanýr.\nYapý alanlarý abstract/soyut, virtual/sanal ve protected/korumalý olmaz.\nHerbir yapýsal kayýt deðer atama yada \"new\" iþlemci ile yaratýlabilir.\nSýnýf referans, yapý ise deðer tiplidir.\nTuþ..."); Console.ReadKey();

            Kitap Kitap1 = new Kitap(); // Kitap tipli Kitap1'in beyaný
            Kitap Kitap2 = new Kitap(); Kitap Kitap3 = new Kitap(); Kitap Kitap4 = new Kitap();

            // Kitap kayýtlarýnýn özellik ve deðerleri
            Kitap1.deðerleriAl ("C# Programlama", "Hacý Ali Amanat", "C# programlama eðitimi", 645, 6495407);
            Kitap2.deðerleriAl ("Elektroniðin Temeli", "Memet Amanat", "LTspice ile elektronik devre simülasyonlarý", 892, 6495700);
            Kitap3.deðerleriAl ("HTML, CSS, JS", "Sabri Amanat", "MDN Mozilla-Firefox ile internet sayfa tasarýmý", 1534, 64957803);
            Kitap4.deðerleriAl ("Pythom Programlama", "Bülent Amanat", "Python ile programcýlýk, matriks, grafik ve pencereler", 1262, 6495908);

            // Kitap bilgilerinin çýktýya yazdýrýlmasý
            Kitap1.göster(); Kitap2.göster(); Kitap3.göster(); Kitap4.göster();
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}