// jtpc#0601.cs: S�n�ftan yarat�lan nesnel tiplemenin de�i�ken ve metod �yeleri �rne�i.

using System;
namespace NesneS�n�f� {
    public class ��renci1 {
        public int no; //Veri �yesi (ayr�ca tipleme de�i�keni)
        public String isim;
    }
    public class ��renci2 {
        public int no; //Veri �yesi (ayr�ca tipleme de�i�keni)
        public String isim;
        public void Koy (int n, String i) {// Veri �yesi metod
            no = n;
            isim = i;
        }
        public void G�ster() {Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", no, isim);}
    }
    class NesneS�n�f {
        int no; //Veri �yesi (ayr�ca tipleme de�i�keni)
        String isim;
        static void Main() {
            Console.Write ("Nesne, s�n�f�n �al��mazaman� yarat�lan tiplemesi olup davran�� fonksiyonaliteli ve durum de�erlidir. S�n�f ise nesnel �ablonun yarat�ld���, alan, metod ve kuruculu benzer nesneler grubudur.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            NesneS�n�f n1 = new NesneS�n�f(); //AYNI NesneS�n�f s�n�f�n�n bir nesnel tipleme yarat�m�
            NesneS�n�f n2 = new NesneS�n�f();
            n1.no = 571; n1.isim = "M.Nihat Yava�";
            n2.no = 1044; n2.isim = "Sami Celepsoy";
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n1.no, n1.isim);
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n2.no, n2.isim);

            ��renci1 n3 = new ��renci1(); //AYRI ��renci1 s�n�f�n�n bir nesnel tipleme yarat�m�
            ��renci1 n4 = new ��renci1();
            n3.no = 576; n3.isim = "M.Nedim Yava�";
            n4.no = 1047; n4.isim = "Zafer N.Candan";
            Console.WriteLine ("\n{0} no'lu ��rencinin ismi: {1}", n3.no, n3.isim);
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n4.no, n4.isim);

            ��renci2 n5 = new ��renci2(); //AYRI ��renci2 s�n�f�n�n bir nesnel tipleme yarat�m�
            ��renci2 n6 = new ��renci2();
            n5.Koy (575, "Sevim Yava�");
            n6.Koy (1049, "Hatice Yava� Ka�ar");
            Console.WriteLine();
            n5.G�ster();
            n6.G�ster();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}