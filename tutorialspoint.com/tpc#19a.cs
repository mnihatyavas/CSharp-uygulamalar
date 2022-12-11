// tpc#19a.cs: Sýnýf tanýmýyla kutularýn hacimleri hesabý örneði.

using System;
namespace Sýnýflar {
    class Kutu {
        public double uzunluk;
        public double yükseklik;
        public double geniþlik;
    }
    class KutuHacmi {
        static void Main (string[] args) {
            Console.Write ("Sýnýf tiplemeleri nesnedir. Deðiþken ve metodlar sýnýf üyeleridir.\nVarsayýlý üye eriþim belirteci private/özel, sýnýfýnki ise internal/içsel'dir.\nMetod veri tipi döndürülecek veriye dairdir.\nÜyelere eriþim 'sýnýfAdý.üyeAdý' nokta iþlemcisiyledir.\nTuþ..."); Console.ReadKey();

            Kutu Kutu1 = new Kutu(); Kutu1.uzunluk = 2; Kutu1.yükseklik = 1; Kutu1.geniþlik = 0.45;
            Kutu Kutu2 = new Kutu(); Kutu2.uzunluk = 5.5; Kutu2.yükseklik = 2.5; Kutu2.geniþlik = 1.65;
            Kutu Kutu3 = new Kutu(); Kutu3.uzunluk = 7.65; Kutu3.yükseklik = 3.45; Kutu3.geniþlik = 2.15;
            double hacim = 0;

            hacim = Kutu1.uzunluk * Kutu1.yükseklik * Kutu1.geniþlik; Console.WriteLine ("\n\nÝlk kutunun hacmi = [{0}] birim-küp.", hacim);
            hacim = Kutu2.uzunluk * Kutu2.yükseklik * Kutu2.geniþlik; Console.WriteLine ("Ýkinci kutunun hacmi = [{0}] birim-küp.", hacim);
            hacim = Kutu3.uzunluk * Kutu3.yükseklik * Kutu3.geniþlik; Console.WriteLine ("Üçüncü kutunun hacmi = [{0}] birim-küp.", hacim);
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}