// jtpc#0603.cs: S�n�f tiplemelerinin varsay�l� parametresiz y�k�c�lar� �rne�i.

using System;
namespace NesneS�n�f� {
    public class ��renci1 {
        public int no;
        public String isim;
        public ��renci1() {Console.WriteLine ("��renci1 s�n�f�n�n varsay�l� kurucusu i�letildi");}
        ~��renci1() {Console.WriteLine ("��renci1 s�n�f�n�n y�k�c�s� i�letildi");}
    }
    public class ��renci2 {
        public int no;
        public String isim;
        public ��renci2 (int n, String i) {// Veri �yesi metod
            Console.WriteLine ("��renci2 s�n�f�n�n parametreli kurucusu i�letildi");
            no = n;
            isim = i;
        }
        public void G�ster() {Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", no, isim);}
        ~��renci2() {Console.WriteLine ("��renci2 s�n�f�n�n y�k�c�s� i�letildi");}
    }
    class Y�k�c� {
        int no; //Veri �yesi de�i�ken
        String isim;
        public Y�k�c�() {Console.WriteLine ("Y�k�c� s�n�f�n�n varsay�l� kurucusu i�letildi");}
        ~Y�k�c�() {Console.WriteLine ("Y�k�c� s�n�f�n�n y�k�c�s� i�letildi");}
        static void Main() {
            Console.Write ("Y�k�c� da kurucu gibi s�n�fla ayn� adl� fakat �n�nde '~' sembol� vard�r. Ancak �nlerinde ba�kaca belirte� kullan�lmaz. Parametresizdir ve program sonlan�rken ve yarat�lan nesne yok olurken otomatikmen i�letilirler.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Y�k�c� n1 = new Y�k�c�(); //AYNI Y�k�c� s�n�f�n�n bir nesnel tipleme yarat�m�
            Y�k�c� n2 = new Y�k�c�();
            n1.no = 571; n1.isim = "M.Nihat Yava�";
            n2.no = 1044; n2.isim = "Sami Celepsoy";
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n1.no, n1.isim);
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n2.no, n2.isim);

            Console.WriteLine();
            ��renci1 n3 = new ��renci1(); //AYRI ��renci1 s�n�f�n�n bir nesnel tipleme yarat�m�
            ��renci1 n4 = new ��renci1();
            n3.no = 576; n3.isim = "M.Nedim Yava�";
            n4.no = 1047; n4.isim = "Zafer N.Candan";
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n3.no, n3.isim);
            Console.WriteLine ("{0} no'lu ��rencinin ismi: {1}", n4.no, n4.isim);

            Console.WriteLine();
            ��renci2 n5 = new ��renci2 (575, "Sevim Yava�"); //AYRI ��renci2 s�n�f�n�n bir nesnel tipleme yarat�m�
            ��renci2 n6 = new ��renci2 (1049, "Hatice Yava� Ka�ar");
            n5.G�ster();
            n6.G�ster();

            Console.Write ("\nTu�.."); Console.ReadKey();
            Console.WriteLine ("\n"); //Y�k�c� mesajlar� d�k�mlenecek
        }
    }
}