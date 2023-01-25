// jtpc#0603.cs: Sýnýf tiplemelerinin varsayýlý parametresiz yýkýcýlarý örneði.

using System;
namespace NesneSýnýfý {
    public class Öðrenci1 {
        public int no;
        public String isim;
        public Öðrenci1() {Console.WriteLine ("Öðrenci1 sýnýfýnýn varsayýlý kurucusu iþletildi");}
        ~Öðrenci1() {Console.WriteLine ("Öðrenci1 sýnýfýnýn yýkýcýsý iþletildi");}
    }
    public class Öðrenci2 {
        public int no;
        public String isim;
        public Öðrenci2 (int n, String i) {// Veri üyesi metod
            Console.WriteLine ("Öðrenci2 sýnýfýnýn parametreli kurucusu iþletildi");
            no = n;
            isim = i;
        }
        public void Göster() {Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", no, isim);}
        ~Öðrenci2() {Console.WriteLine ("Öðrenci2 sýnýfýnýn yýkýcýsý iþletildi");}
    }
    class Yýkýcý {
        int no; //Veri üyesi deðiþken
        String isim;
        public Yýkýcý() {Console.WriteLine ("Yýkýcý sýnýfýnýn varsayýlý kurucusu iþletildi");}
        ~Yýkýcý() {Console.WriteLine ("Yýkýcý sýnýfýnýn yýkýcýsý iþletildi");}
        static void Main() {
            Console.Write ("Yýkýcý da kurucu gibi sýnýfla ayný adlý fakat önünde '~' sembolü vardýr. Ancak önlerinde baþkaca belirteç kullanýlmaz. Parametresizdir ve program sonlanýrken ve yaratýlan nesne yok olurken otomatikmen iþletilirler.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Yýkýcý n1 = new Yýkýcý(); //AYNI Yýkýcý sýnýfýnýn bir nesnel tipleme yaratýmý
            Yýkýcý n2 = new Yýkýcý();
            n1.no = 571; n1.isim = "M.Nihat Yavaþ";
            n2.no = 1044; n2.isim = "Sami Celepsoy";
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n1.no, n1.isim);
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n2.no, n2.isim);

            Console.WriteLine();
            Öðrenci1 n3 = new Öðrenci1(); //AYRI Öðrenci1 sýnýfýnýn bir nesnel tipleme yaratýmý
            Öðrenci1 n4 = new Öðrenci1();
            n3.no = 576; n3.isim = "M.Nedim Yavaþ";
            n4.no = 1047; n4.isim = "Zafer N.Candan";
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n3.no, n3.isim);
            Console.WriteLine ("{0} no'lu öðrencinin ismi: {1}", n4.no, n4.isim);

            Console.WriteLine();
            Öðrenci2 n5 = new Öðrenci2 (575, "Sevim Yavaþ"); //AYRI Öðrenci2 sýnýfýnýn bir nesnel tipleme yaratýmý
            Öðrenci2 n6 = new Öðrenci2 (1049, "Hatice Yavaþ Kaçar");
            n5.Göster();
            n6.Göster();

            Console.Write ("\nTuþ.."); Console.ReadKey();
            Console.WriteLine ("\n"); //Yýkýcý mesajlarý dökümlenecek
        }
    }
}