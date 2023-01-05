// tpc#23a.cs: Arayüzde tanýmlý metodlarýn türev altsýnýfta içi doldurulup kullanýlmalarý örneði.

/*  using System.Collections.Generic;
    using System.Linq;
    using System.Text;
*/
using System;
namespace Arayüzler {
    public interface ÝþlemArayüzü {
        // Ýçiboþ arayüz metodlarý
        void iþlemiGöster();
        double tutarýAl();
    }
    public class Ýþlem: ÝþlemArayüzü {
        private string iþlemKodu;
        private string iþlemTarihi;
        private double iþlemTutarý;
        public Ýþlem() {// Sýfýr ilkdeðerli parametresiz kurucu metod
            iþlemKodu = " "; iþlemTarihi = " "; iþlemTutarý = 0.0;
        }
        public Ýþlem (string kod, string tarih, double tutar) {// Parametreli kurucu metod
            iþlemKodu = kod; iþlemTarihi = tarih; iþlemTutarý = tutar;
        }
        public double tutarýAl() {return iþlemTutarý;}
        public void iþlemiGöster() {
            Console.WriteLine ("\nÝþlem Kodu: [{0}]", iþlemKodu);
            Console.WriteLine ("Ýþlem tarihi: [{0}]", iþlemTarihi);
            Console.WriteLine ("Ýþlem tutarý: [{0}]", tutarýAl());
        }
    }
    class ArayüzBeyaný {
        static void Main() {
            Console.Write ("Arayüzlerin içerdiði özellik, olay ve metodlarýn içi boþ olup, türevci mirascýlarýn gereksinimleriyle doldurulur, onlara yol-gösterici katagorileþtirici iskeletler-þablonlar sunarlar; varsayýlý public/genel eriþimlidler. Soyut sýnýflar da benzer olmakla beraber model metodlarý daha sýnýrlýdýr.\nTuþ..."); Console.ReadKey();

            new Ýþlem(); // Hesap açýlýþý
            Ýþlem iþ1 = new Ýþlem ("A-047", "1/12/2022", 78900.50); // Ýlk hareket kaydýný iþler
            Ýþlem iþ2 = new Ýþlem ("A-048", "9/12/2022", 451900.65);
            Ýþlem iþ3 = new Ýþlem ("A-049", "19/12/2022", 125192.45);
            iþ1.iþlemiGöster(); iþ2.iþlemiGöster(); iþ3.iþlemiGöster(); // Tüm kayýtlarý görüntüler

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}