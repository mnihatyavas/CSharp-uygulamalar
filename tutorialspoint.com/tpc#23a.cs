// tpc#23a.cs: Aray�zde tan�ml� metodlar�n t�rev alts�n�fta i�i doldurulup kullan�lmalar� �rne�i.

/*  using System.Collections.Generic;
    using System.Linq;
    using System.Text;
*/
using System;
namespace Aray�zler {
    public interface ��lemAray�z� {
        // ��ibo� aray�z metodlar�
        void i�lemiG�ster();
        double tutar�Al();
    }
    public class ��lem: ��lemAray�z� {
        private string i�lemKodu;
        private string i�lemTarihi;
        private double i�lemTutar�;
        public ��lem() {// S�f�r ilkde�erli parametresiz kurucu metod
            i�lemKodu = " "; i�lemTarihi = " "; i�lemTutar� = 0.0;
        }
        public ��lem (string kod, string tarih, double tutar) {// Parametreli kurucu metod
            i�lemKodu = kod; i�lemTarihi = tarih; i�lemTutar� = tutar;
        }
        public double tutar�Al() {return i�lemTutar�;}
        public void i�lemiG�ster() {
            Console.WriteLine ("\n��lem Kodu: [{0}]", i�lemKodu);
            Console.WriteLine ("��lem tarihi: [{0}]", i�lemTarihi);
            Console.WriteLine ("��lem tutar�: [{0}]", tutar�Al());
        }
    }
    class Aray�zBeyan� {
        static void Main() {
            Console.Write ("Aray�zlerin i�erdi�i �zellik, olay ve metodlar�n i�i bo� olup, t�revci mirasc�lar�n gereksinimleriyle doldurulur, onlara yol-g�sterici katagorile�tirici iskeletler-�ablonlar sunarlar; varsay�l� public/genel eri�imlidler. Soyut s�n�flar da benzer olmakla beraber model metodlar� daha s�n�rl�d�r.\nTu�..."); Console.ReadKey();

            new ��lem(); // Hesap a��l���
            ��lem i�1 = new ��lem ("A-047", "1/12/2022", 78900.50); // �lk hareket kayd�n� i�ler
            ��lem i�2 = new ��lem ("A-048", "9/12/2022", 451900.65);
            ��lem i�3 = new ��lem ("A-049", "19/12/2022", 125192.45);
            i�1.i�lemiG�ster(); i�2.i�lemiG�ster(); i�3.i�lemiG�ster(); // T�m kay�tlar� g�r�nt�ler

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}