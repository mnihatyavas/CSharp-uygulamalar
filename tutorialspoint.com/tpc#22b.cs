// tpc#22b.cs: Statik i�lemci a��r�y�kleni�iyle birka� kutunun hacmi, toplam� ve k�yas� �rne�i.

using System;
namespace Statik��lemciA��r�y�kleni� {
    class Kutu {
        private double uzunluk;
        private double geni�lik;
        private double y�kseklik;
 
        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void geni�likKoy (double gen) {geni�lik = gen;}
        public void y�kseklikKoy (double y�k) {y�kseklik = y�k;}
        public double hacimAl() {return uzunluk * geni�lik * y�kseklik;}

        // �ki kutu nesnesinin ebatlar�n� toplayan a��r�y�kl� i�lemci+
        public static Kutu operator + (Kutu k1, Kutu k2) {
            Kutu kutu = new Kutu();
            kutu.uzunluk = k1.uzunluk + k2.uzunluk;
            kutu.geni�lik = k1.geni�lik + k2.geni�lik;
            kutu.y�kseklik = k1.y�kseklik + k2.y�kseklik;
            return kutu;
        }
        // Kutu nesnelerini birbirleriyle k�yaslayan a��r�y�kl� i�lemci fonksiyonlar�
        public static bool operator == (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk == sa�.uzunluk && sol.geni�lik == sa�.geni�lik && sol.y�kseklik == sa�.y�kseklik) {durum = true;}
            return durum;
        }
        public static bool operator != (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk != sa�.uzunluk || sol.geni�lik != sa�.geni�lik || sol.y�kseklik != sa�.y�kseklik) {durum = true;}
            return durum;
        }
        public static bool operator < (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk < sa�.uzunluk && sol.geni�lik < sa�.geni�lik && sol.y�kseklik < sa�.y�kseklik) {durum = true;}
            return durum;
        }
        public static bool operator > (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk > sa�.uzunluk && sol.geni�lik > sa�.geni�lik && sol.y�kseklik > sa�.y�kseklik) {durum = true;}
            return durum;
        }
        public static bool operator <= (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk <= sa�.uzunluk && sol.geni�lik <= sa�.geni�lik && sol.y�kseklik <= sa�.y�kseklik) {durum = true;}
            return durum;
        }
        public static bool operator >= (Kutu sol, Kutu sa�) {
            bool durum = false;
            if (sol.uzunluk >= sa�.uzunluk && sol.geni�lik >= sa�.geni�lik && sol.y�kseklik >= sa�.y�kseklik) {durum = true;}
            return durum;
        }

        // A��r�y�kl� dinamik fonksiyon
        public override string ToString() {return String.Format ("({0}, {1}, {2})", uzunluk, y�kseklik, geni�lik);}

    }
    class ��lemciA��r�y�klenenY�klenmeyen {
        static void Main() {
            Console.Write ("A��r�y�klenebilen i�lemciler:\nBirli i�lemciler: +, -, !, ~, ++, --\n�kili i�lemciler: +, -, *, /, %\nKar��la�t�rma i�lemcileri: ==, !=, <, >, <=, >=\n\nDo�rudan a��r�y�klenemeyen i�lemciler:\n�artl� mant�ksal i�lemciler: &&, ||\n\nA��r�y�klenemeyen i�lemciler:\nAtama i�lemcileri: +=, -=, *=, /=, %=\nDi�er: =, ., ?:, ->, new, is, sizeof, typeof\nTu�..."); Console.ReadKey();

            Kutu kutu1 = new Kutu();
            Kutu kutu2 = new Kutu();
            Kutu kutu3 = new Kutu();
            Kutu kutu4 = new Kutu();

            kutu1.uzunlukKoy (6.2); kutu1.geni�likKoy (7); kutu1.y�kseklikKoy (5.5); Console.WriteLine ("\n\n{0} �l�ekli Kutu1'in hacmi: {1}", kutu1.ToString(), kutu1.hacimAl());
            kutu2.uzunlukKoy (12); kutu2.geni�likKoy (13.5); kutu2.y�kseklikKoy (10.4); Console.WriteLine ("{0} �l�ekli Kutu2'nin hacmi: {1}", kutu2.ToString(), kutu2.hacimAl());
            kutu3 = kutu1 + kutu2; // A��r�y�klenen operator+ fonksiyonu otomatikmen �a�r�l�r
            Console.WriteLine ("{0} �l�ekli Kutu-3'�n hacmi: {1}", kutu3.ToString(), kutu3.hacimAl());
            kutu4 = kutu3; Console.WriteLine ("{0} �l�ekli Kutu-4'�n hacmi: {1}", kutu4.ToString(), kutu4.hacimAl());

            if (kutu1 > kutu2) Console.WriteLine ("\nKutu1, Kutu2'den B�Y�KT�R.");
            else if (kutu1 < kutu2) Console.WriteLine ("\nKutu1,Kutu2'den K���KT�R.");
            else Console.WriteLine ("\nKutu1, Kutu2'ye E��TT�R.");

            if (kutu1 >= kutu2) Console.WriteLine ("Kutu1, Kutu2'den B�Y�K veya E��TT�R.");
            else Console.WriteLine ("Kutu1, Kutu2'den B�Y�K veya E��T DE��LD�R.");

            if (kutu1 <= kutu2) Console.WriteLine ("Kutu1, Kutu2'den K���K veya E��TT�R.");
            else Console.WriteLine ("Kutu1, Kutu2'den B�Y�KT�R.");

            if (kutu1 != kutu2) Console.WriteLine ("Kutu1, Kutu2'ye E��T DE��LD�R.");
            else Console.WriteLine ("Kutu1, Kutu2'ye E��TT�R.");

            if (kutu3 == kutu4) Console.WriteLine ("Kutu3, Kutu4'e E��TT�R.");
            else Console.WriteLine ("Kutu3, Kutu4'e E��T DE��LD�R.");

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}