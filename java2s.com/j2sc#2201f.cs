// j2sc#2201f.cs: Anonim soysal delegeli/lambda'lý Func<> örneði.

using System;
using System.Linq; // Where ve Select için
namespace AnonimFunc {
    static class SýnýfA {
        public static Func<T, T> Üçle<T> (this Func<T, T> ilkFunc) {return x => ilkFunc (ilkFunc (ilkFunc (x)));}
    }
    static class SýnýfB {
        public static Func<A, Func<B, R>> uzantý<A, B, R> (this Func<A, B, R > f) {return a => b => f (a, b);}
    }
    class Delegeli_Lambdalý {
        static void yürüt (Func<int> deðer) {Console.WriteLine ("Parametrik 'deðer' bir int-tamsayý'dýr: [{0}]", deðer());}
        static void yürüt (Func<double> deðer) {Console.WriteLine ("Parametrik 'deðer' bir double-dublesayý'dýr: [{0}]", deðer());}
        static void yürüt (Func<bool> deðer) {Console.WriteLine ("Parametrik 'deðer' bir bool-ikili'dir: [{0}]", deðer());}
        static void yürüt (Func<string> deðer) {Console.WriteLine ("Parametrik 'deðer' bir string-dizge'dir: [{0}]", deðer());}
        static void Main() {
            Console.Write ("'Func<int,int,string> f = (x, y) => (x + y).ToString()' lambda'lý anonim soysal fonksiyonda int-x, int-y girenler, string-return ise geri dönen tip-deðer'lerdir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim lambda Func'la sayýnýn bir ve üç katýný döndürme:");
            int i, j, ts;
            Func<int, int> birartýr = x => x + x;
            Func<int, int> üçartýr = birartýr.Üçle();
            for(i=1;i<11;i++) Console.WriteLine ("Sýralý sayý: {0}\tÝki katý: {1}\tÜç katý: {2}", i, birartýr (i), üçartýr (i));

            Console.WriteLine ("\nÝçiçe for-i[0-->10+=100]-j[1000-->1008] ile topla-toplayýcý (11x9) üretme:");
            Func<int, Func<int, int>> toplayýcý = (n => (x => n += x+100));
            var topla=toplayýcý (0);
            for(i=0;i<=10;i++) {
                topla = toplayýcý (i);
                for(j=1000;j<1009;j++) Console.Write (topla (j) + " "); Console.WriteLine();
            }

            Console.WriteLine ("\nÇoklu Func'la 1881+=[0-->57] ikili toplama sonuçlarýný sunma:");
            Func<int, int, int> toplaTek = (x, y) => (x + y);
            Func<int, Func<int, int>> uzantýlýToplaTek = toplaTek.uzantý();
            Func<int, int> toplaÝki = uzantýlýToplaTek (1881);
            for(i=0;i<=57;i++) Console.Write (toplaÝki (i) + " "); Console.WriteLine();

            Console.WriteLine ("\nFunc ve Where-OrderBy-Select'le tüm, uzn>6 ve uzn<=6 þehirleri listeleme:");
            string[] þehirler = {"ÞanlýUrfa", "Mersin", "Bursa", "Malatya", "Van", "Ýstanbul", "Ankara", "Ýzmir", "KahramanMaraþ", "Bolu"};
            Func<string, bool> þartlýArama1 = delegate (string þehir) {return þehir.Length > 6;};
            Func<string, bool> þartlýArama2 = delegate (string þehir) {return þehir.Length <= 6;};
            Func<string, string> þehirleriTarama = delegate (string þehir) {return þehir;};
            var seçilenÞehirler = þehirler
                //.Where (þartlýArama1)
                .OrderBy (þehirleriTarama) //Artan sýralar
                .Select (þehirleriTarama);
            Console.Write ("Tüm þehirler: "); foreach (var þehir in /*seçilenÞehirler*/ þehirler) Console.Write (þehir+" "); Console.WriteLine();
            seçilenÞehirler = þehirler
                .Where (þartlýArama1)
                .OrderBy (þehirleriTarama) //Artan sýralar
                .Select (þehirleriTarama);
            Console.Write ("Þehir.Length > 6: "); foreach (var þehir in seçilenÞehirler) Console.Write (þehir+" "); Console.WriteLine();
            seçilenÞehirler = þehirler
                .Where (þartlýArama2)
                .OrderBy (þehirleriTarama) //Artan sýralar
                .Select (þehirleriTarama);
            Console.Write ("Þehir.Length <= 6: "); foreach (var þehir in seçilenÞehirler) Console.Write (þehir+" "); Console.WriteLine();

            Console.WriteLine ("\nSoysal Func<T> uygun argüman tipli fonksiyonun yürütülmesi:");
            yürüt (() => "Nihat");
            yürüt (() => 2*2==5);
            yürüt (() => 20241102);
            yürüt (() => 20241102.1707);

            Console.WriteLine ("\nLambda'lý Func'la rasgele dizge uzunluðu ve yýla toplam sunumlarý:");
            string dzg; var r=new Random();
            Func<int, int, string> yýl = (x, y) => (x + y).ToString();
            Func<string, int> uzn = (string str) => {return str.Length;};
            for(i=0;i<=10;i++) {
                dzg=""; ts=r.Next(3,10); for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(0,58); dzg+="-->"+ts; 
                Console.WriteLine ("Dizge: {0,-25}\tUzunluk: {1}\tYýl: {2}", dzg, uzn (dzg), yýl (ts, 1881));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}