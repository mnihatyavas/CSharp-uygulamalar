// tpc#17a.cs: Kitap yapýsal kaydý, özellik ve deðerleri örneði.

using System;
struct Kitap {
    public string baþlýk;
    public string yazar;
    public string konu;
    public short toplamSayfa;
    public int kimlikNo;
};
namespace Yapýlar {
    class YapýsalKayýt {
        static void Main (string[] args) {
            Console.Write ("struct-ure/yapý ile, COBOL'daki kayýt yada JS'deki özellik-deðer çiftli nesnel veri tipi yaratýlýr.\nTuþ..."); Console.ReadKey();

            Kitap Kitap1; // Kitap tipli Kitap1'in beyaný
            Kitap Kitap2; // Kitap tipli Kitap2'nin beyaný

            // Kitap1 kaydýnýn özellik ve deðerleri
            Kitap1.baþlýk = "C Programlama";
            Kitap1.yazar = "Hacý Ali Amanat";
            Kitap1.konu = "C Programlama eðitimi";
            Kitap1.toplamSayfa = 645;
            Kitap1.kimlikNo = 6495407;
            // Kitap2 kaydýnýn özellik ve deðerleri
            Kitap2.baþlýk = "Elektroniðin Temeli";
            Kitap2.yazar = "Memet Amanat";
            Kitap2.konu = "LTspice ile elektronik devre simülasyonlarý";
            Kitap2.toplamSayfa = 892;
            Kitap2.kimlikNo = 6495700;

            // Kitap1 bilgilerinin çýktýya yazdýrýlmasý
            Console.WriteLine ("\nKitap1'in baþlýðý: {0}", Kitap1.baþlýk);
            Console.WriteLine ("Kitap1'in yazarý: {0}", Kitap1.yazar);
            Console.WriteLine ("Kitap1'in konusu: {0}", Kitap1.konu);
            Console.WriteLine ("Kitap1'in sayfa sayýsý: {0}", Kitap1.toplamSayfa);
            Console.WriteLine ("Kitap1'in kimlik no'su: {0}", Kitap1.kimlikNo);
            Console.Write ("Tuþ..."); Console.ReadKey();
            // Kitap2 bilgilerinin çýktýya yazdýrýlmasý
            Console.WriteLine ("\nKitap2'nin baþlýðý: {0}", Kitap2.baþlýk);
            Console.WriteLine ("Kitap2'nin yazarý: {0}", Kitap2.yazar);
            Console.WriteLine ("Kitap2'nin konusu: {0}", Kitap2.konu);
            Console.WriteLine ("Kitap2'nin sayfa sayýsý: {0}", Kitap2.toplamSayfa);
            Console.WriteLine ("Kitap2'nin kimlik no'su: {0}", Kitap2.kimlikNo);
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}