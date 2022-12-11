// tpc#17a.cs: Kitap yap�sal kayd�, �zellik ve de�erleri �rne�i.

using System;
struct Kitap {
    public string ba�l�k;
    public string yazar;
    public string konu;
    public short toplamSayfa;
    public int kimlikNo;
};
namespace Yap�lar {
    class Yap�salKay�t {
        static void Main (string[] args) {
            Console.Write ("struct-ure/yap� ile, COBOL'daki kay�t yada JS'deki �zellik-de�er �iftli nesnel veri tipi yarat�l�r.\nTu�..."); Console.ReadKey();

            Kitap Kitap1; // Kitap tipli Kitap1'in beyan�
            Kitap Kitap2; // Kitap tipli Kitap2'nin beyan�

            // Kitap1 kayd�n�n �zellik ve de�erleri
            Kitap1.ba�l�k = "C Programlama";
            Kitap1.yazar = "Hac� Ali Amanat";
            Kitap1.konu = "C Programlama e�itimi";
            Kitap1.toplamSayfa = 645;
            Kitap1.kimlikNo = 6495407;
            // Kitap2 kayd�n�n �zellik ve de�erleri
            Kitap2.ba�l�k = "Elektroni�in Temeli";
            Kitap2.yazar = "Memet Amanat";
            Kitap2.konu = "LTspice ile elektronik devre sim�lasyonlar�";
            Kitap2.toplamSayfa = 892;
            Kitap2.kimlikNo = 6495700;

            // Kitap1 bilgilerinin ��kt�ya yazd�r�lmas�
            Console.WriteLine ("\nKitap1'in ba�l���: {0}", Kitap1.ba�l�k);
            Console.WriteLine ("Kitap1'in yazar�: {0}", Kitap1.yazar);
            Console.WriteLine ("Kitap1'in konusu: {0}", Kitap1.konu);
            Console.WriteLine ("Kitap1'in sayfa say�s�: {0}", Kitap1.toplamSayfa);
            Console.WriteLine ("Kitap1'in kimlik no'su: {0}", Kitap1.kimlikNo);
            Console.Write ("Tu�..."); Console.ReadKey();
            // Kitap2 bilgilerinin ��kt�ya yazd�r�lmas�
            Console.WriteLine ("\nKitap2'nin ba�l���: {0}", Kitap2.ba�l�k);
            Console.WriteLine ("Kitap2'nin yazar�: {0}", Kitap2.yazar);
            Console.WriteLine ("Kitap2'nin konusu: {0}", Kitap2.konu);
            Console.WriteLine ("Kitap2'nin sayfa say�s�: {0}", Kitap2.toplamSayfa);
            Console.WriteLine ("Kitap2'nin kimlik no'su: {0}", Kitap2.kimlikNo);
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}