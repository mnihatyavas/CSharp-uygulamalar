// tpc#22b.cs: Statik iþlemci aþýrýyükleniþiyle birkaç kutunun hacmi, toplamý ve kýyasý örneði.

using System;
namespace StatikÝþlemciAþýrýyükleniþ {
    class Kutu {
        private double uzunluk;
        private double geniþlik;
        private double yükseklik;
 
        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void geniþlikKoy (double gen) {geniþlik = gen;}
        public void yükseklikKoy (double yük) {yükseklik = yük;}
        public double hacimAl() {return uzunluk * geniþlik * yükseklik;}

        // Ýki kutu nesnesinin ebatlarýný toplayan aþýrýyüklü iþlemci+
        public static Kutu operator + (Kutu k1, Kutu k2) {
            Kutu kutu = new Kutu();
            kutu.uzunluk = k1.uzunluk + k2.uzunluk;
            kutu.geniþlik = k1.geniþlik + k2.geniþlik;
            kutu.yükseklik = k1.yükseklik + k2.yükseklik;
            return kutu;
        }
        // Kutu nesnelerini birbirleriyle kýyaslayan aþýrýyüklü iþlemci fonksiyonlarý
        public static bool operator == (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk == sað.uzunluk && sol.geniþlik == sað.geniþlik && sol.yükseklik == sað.yükseklik) {durum = true;}
            return durum;
        }
        public static bool operator != (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk != sað.uzunluk || sol.geniþlik != sað.geniþlik || sol.yükseklik != sað.yükseklik) {durum = true;}
            return durum;
        }
        public static bool operator < (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk < sað.uzunluk && sol.geniþlik < sað.geniþlik && sol.yükseklik < sað.yükseklik) {durum = true;}
            return durum;
        }
        public static bool operator > (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk > sað.uzunluk && sol.geniþlik > sað.geniþlik && sol.yükseklik > sað.yükseklik) {durum = true;}
            return durum;
        }
        public static bool operator <= (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk <= sað.uzunluk && sol.geniþlik <= sað.geniþlik && sol.yükseklik <= sað.yükseklik) {durum = true;}
            return durum;
        }
        public static bool operator >= (Kutu sol, Kutu sað) {
            bool durum = false;
            if (sol.uzunluk >= sað.uzunluk && sol.geniþlik >= sað.geniþlik && sol.yükseklik >= sað.yükseklik) {durum = true;}
            return durum;
        }

        // Aþýrýyüklü dinamik fonksiyon
        public override string ToString() {return String.Format ("({0}, {1}, {2})", uzunluk, yükseklik, geniþlik);}

    }
    class ÝþlemciAþýrýyüklenenYüklenmeyen {
        static void Main() {
            Console.Write ("Aþýrýyüklenebilen iþlemciler:\nBirli iþlemciler: +, -, !, ~, ++, --\nÝkili iþlemciler: +, -, *, /, %\nKarþýlaþtýrma iþlemcileri: ==, !=, <, >, <=, >=\n\nDoðrudan aþýrýyüklenemeyen iþlemciler:\nÞartlý mantýksal iþlemciler: &&, ||\n\nAþýrýyüklenemeyen iþlemciler:\nAtama iþlemcileri: +=, -=, *=, /=, %=\nDiðer: =, ., ?:, ->, new, is, sizeof, typeof\nTuþ..."); Console.ReadKey();

            Kutu kutu1 = new Kutu();
            Kutu kutu2 = new Kutu();
            Kutu kutu3 = new Kutu();
            Kutu kutu4 = new Kutu();

            kutu1.uzunlukKoy (6.2); kutu1.geniþlikKoy (7); kutu1.yükseklikKoy (5.5); Console.WriteLine ("\n\n{0} ölçekli Kutu1'in hacmi: {1}", kutu1.ToString(), kutu1.hacimAl());
            kutu2.uzunlukKoy (12); kutu2.geniþlikKoy (13.5); kutu2.yükseklikKoy (10.4); Console.WriteLine ("{0} ölçekli Kutu2'nin hacmi: {1}", kutu2.ToString(), kutu2.hacimAl());
            kutu3 = kutu1 + kutu2; // Aþýrýyüklenen operator+ fonksiyonu otomatikmen çaðrýlýr
            Console.WriteLine ("{0} ölçekli Kutu-3'ün hacmi: {1}", kutu3.ToString(), kutu3.hacimAl());
            kutu4 = kutu3; Console.WriteLine ("{0} ölçekli Kutu-4'ün hacmi: {1}", kutu4.ToString(), kutu4.hacimAl());

            if (kutu1 > kutu2) Console.WriteLine ("\nKutu1, Kutu2'den BÜYÜKTÜR.");
            else if (kutu1 < kutu2) Console.WriteLine ("\nKutu1,Kutu2'den KÜÇÜKTÜR.");
            else Console.WriteLine ("\nKutu1, Kutu2'ye EÞÝTTÝR.");

            if (kutu1 >= kutu2) Console.WriteLine ("Kutu1, Kutu2'den BÜYÜK veya EÞÝTTÝR.");
            else Console.WriteLine ("Kutu1, Kutu2'den BÜYÜK veya EÞÝT DEÐÝLDÝR.");

            if (kutu1 <= kutu2) Console.WriteLine ("Kutu1, Kutu2'den KÜÇÜK veya EÞÝTTÝR.");
            else Console.WriteLine ("Kutu1, Kutu2'den BÜYÜKTÜR.");

            if (kutu1 != kutu2) Console.WriteLine ("Kutu1, Kutu2'ye EÞÝT DEÐÝLDÝR.");
            else Console.WriteLine ("Kutu1, Kutu2'ye EÞÝTTÝR.");

            if (kutu3 == kutu4) Console.WriteLine ("Kutu3, Kutu4'e EÞÝTTÝR.");
            else Console.WriteLine ("Kutu3, Kutu4'e EÞÝT DEÐÝLDÝR.");

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}