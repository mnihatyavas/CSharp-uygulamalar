// jtpc#0601.cs: Sýnýftan yaratýlan nesnel tiplemenin deðiþken ve metod üyeleri örneði.

using System;
namespace NesneSýnýfý {
    public class Öðrenci1 {
        public int no; //Veri üyesi (ayrýca tipleme deðiþkeni)
        public String isim;
    }
    public class Öðrenci2 {
        public int no; //Veri üyesi (ayrýca tipleme deðiþkeni)
        public String isim;
        public void Koy (int n, String i) {// Veri üyesi metod
            no = n;
            isim = i;
        }
        public void Göster() {Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", no, isim);}
    }
    class NesneSýnýf {
        int no; //Veri üyesi (ayrýca tipleme deðiþkeni)
        String isim;
        static void Main() {
            Console.Write ("Nesne, sýnýfýn çalýþmazamaný yaratýlan tiplemesi olup davranýþ fonksiyonaliteli ve durum deðerlidir. Sýnýf ise nesnel þablonun yaratýldýðý, alan, metod ve kuruculu benzer nesneler grubudur.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            NesneSýnýf n1 = new NesneSýnýf(); //AYNI NesneSýnýf sýnýfýnýn bir nesnel tipleme yaratýmý
            NesneSýnýf n2 = new NesneSýnýf();
            n1.no = 571; n1.isim = "M.Nihat Yavaþ";
            n2.no = 1044; n2.isim = "Sami Celepsoy";
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n1.no, n1.isim);
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n2.no, n2.isim);

            Öðrenci1 n3 = new Öðrenci1(); //AYRI Öðrenci1 sýnýfýnýn bir nesnel tipleme yaratýmý
            Öðrenci1 n4 = new Öðrenci1();
            n3.no = 576; n3.isim = "M.Nedim Yavaþ";
            n4.no = 1047; n4.isim = "Zafer N.Candan";
            Console.WriteLine ("\n{0} no'lu öðrencinin ismi: {1}", n3.no, n3.isim);
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n4.no, n4.isim);

            Öðrenci2 n5 = new Öðrenci2(); //AYRI Öðrenci2 sýnýfýnýn bir nesnel tipleme yaratýmý
            Öðrenci2 n6 = new Öðrenci2();
            n5.Koy (575, "Sevim Yavaþ");
            n6.Koy (1049, "Hatice Yavaþ Kaçar");
            Console.WriteLine();
            n5.Göster();
            n6.Göster();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}