// jtpc#0602.cs: Sýnýf tiplemelerinin varsayýlý ve parametreli kurucularý örneði.

using System;
namespace NesneSýnýfý {
    public class Öðrenci1 {
        public int no;
        public String isim;
        public Öðrenci1() {Console.WriteLine ("Öðrenci1 sýnýfýnýn varsayýlý kurucusu iþletildi");}
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
    }
    class Kurucu {
        int no; //Veri üyesi deðiþken
        String isim;
        public Kurucu() {Console.WriteLine ("Kurucu sýnýfýnýn varsayýlý kurucusu iþletildi");}
        static void Main() {
            Console.Write ("Kurucu, sýnýfýn özel bir metodu olup sýnýfla ayný adlýdýr. Genelde sýnýf tiplemesi yaratýlýrken ya parametresiz varsayýlý bir açýklama sunar, yada deðiþken üyelere parametreli ilkdeðerlerini atar. Kurucularýn normal metodlar gibi (void, int vb) tipleri olmaz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Kurucu n1 = new Kurucu(); //AYNI Kurucu sýnýfýnýn bir nesnel tipleme yaratýmý
            Kurucu n2 = new Kurucu();
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
        }
    }
}