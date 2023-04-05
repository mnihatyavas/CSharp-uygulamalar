// j2sc#0112.cs: Metodun 'out' parametrik çoklu geridönüş sağlaması örneği.

using System;
namespace DilTemelleri {
    class Nokta {
        int x, y;
        public Nokta (int x, int y) {this.x = x; this.y = y;}
        public void NoktayıAl1 (out int x, out int y) {x = this.x; y = this.y;}
        public void NoktayıAl2 (ref int x, ref int y) {x = this.x; y = this.y;}
    }
    class Ayrıştır {
        public int parçala (double sayı, out double küsürat) { 
            int tamsayı = (int)sayı; 
            küsürat = sayı - tamsayı; //'out' ile geridönüş
            return tamsayı; // 'return' ile geridönüş
        }
    }
    class OrtakBölen {
        public bool ortakBölenVarmı (int x, int y, out string d) {
            d="";
            int kere; if (x > y) kere=y; else kere=x;
            for (int i=2; i <= (int)kere/2; i++) {if ((double)x%i==0d & (double)y%i==0d) d+=i+" ";}
            if (d=="") return false; else return true;
        }
    }
    class Out {
        public static void Topla (int x,int y, out int toplam) {toplam = x + y;}
        static void Main() {
            Console.Write ("'out' argümana ilkdeğer ataması gerekmez, ancak atansa dahi 'out' parametresi atanmamış addeder. Ama metod geridönüşü öncesi tüm 'out' parametreleri değer yüklü ister. Yani 'ref' çift taraflı değer aktarımı sağlarken, 'out' sadece metoddan geridönüş sağlar.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            var r = new Random();int cevap, r1=r.Next (1, 1000), r2=r.Next (1, 1000);
            Topla (r1, r2, out cevap);
            Console.WriteLine ("Toplam: {0} + {1} = {2}", r1, r2, cevap);
            r1=r.Next (1, 1000); r2=r.Next (1, 1000); Topla (r1, r2, out cevap);
            Console.WriteLine ("Toplam: {0} + {1} = {2}", r1, r2, cevap);

            int x, y; // 'out' ilkdeğer atanması istemez
            var noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.NoktayıAl1 (out x, out y); Console.WriteLine ("\n'out' ile Nokta ({0}, {1})", x, y);
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.NoktayıAl1 (out x, out y); Console.WriteLine ("'out' ile Nokta ({0}, {1})", x, y);

            int a=0, b=0; // 'ref' ilkdeğer atanması ister
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.NoktayıAl2 (ref a, ref b); Console.WriteLine ("\n'ref' ile Nokta ({0}, {1})", a, b);
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.NoktayıAl2 (ref a, ref b); Console.WriteLine ("'ref' ile Nokta ({0}, {1})", a, b);

            var ayrıştır = new Ayrıştır();
            int ts; double sy, ksr;
            ts = ayrıştır.parçala (sy = r.Next (1, 1000000) / 10000d, out ksr); Console.WriteLine ("\nAyrıştırma: {0} = {1} + {2:0.0###}", sy, ts, ksr);
            ts = ayrıştır.parçala (sy = r.Next (1, 1000000) / 10000d, out ksr); Console.WriteLine ("Ayrıştırma: {0} = {1} + {2:0.0###}", sy, ts, ksr);

            var ob = new OrtakBölen();
            x = r.Next (1, 1000); y = r.Next (1, 1000); string sonuç; //x=24, y=768 veya 216 ve 168 dene
            if (ob.ortakBölenVarmı (x, y, out sonuç) ) Console.WriteLine ("\n{0} ve {1} sayılarının ortak bölenleri: {2}", x, y, sonuç);
            else Console.WriteLine ("\n{0} ve {1} sayılarının ortak bölenleri: YOK", x, y);
            x = r.Next (1, 1000); y = r.Next (1, 1000);
            if (ob.ortakBölenVarmı (x, y, out sonuç) ) Console.WriteLine ("{0} ve {1} sayılarının ortak bölenleri: {2}", x, y, sonuç);
            else Console.WriteLine ("{0} ve {1} sayılarının ortak bölenleri: YOK", x, y);

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}