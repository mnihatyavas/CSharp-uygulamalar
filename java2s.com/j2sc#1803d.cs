// j2sc#1803d.cs: Ebeveyn, new(), class, struct ve Main<T> kýsýtlamalarý örneði.

using System;
namespace SoysalSýnýf {
    class SýnýfA {public void selam() {Console.WriteLine ("Merhabalar!");}}
    class SýnýfB: SýnýfA {}
    class SýnýfC {public SýnýfC() {}}
    class SýnýfZ<T> where T: SýnýfA {
        T ns; 
        public SýnýfZ (T n) {ns = n;} //Kurucu
        public void selamla() {ns.selam();}
    }
    class SýnýfX<T> where T: new() {
        public T ns1;
        public T ns2 = default (T);
        public SýnýfX() {ns1 = new T();}
    } 
    class SýnýfY<T> where T: class {
        public T ns;
        public SýnýfY() {ns = null;} //Kurucu
    }
    struct YapýA {}
    class SýnýfQ<T> where T: struct {
        T ns;
        public SýnýfQ (T x) {ns = x;}
    }
    class SýnýfT {//Main() sýnýfý SýnýfT<T> soysal olamaz
        public static string alan;
        public static void AlanYaz() {Console.WriteLine ("alan: {0}\t Tipi: {1}", alan, typeof(SýnýfT).Name);
            }
        static void Main() {
            Console.Write ("'SýnýfZ<T> where T: SýnýfA' ebeveynsiz SýnýfC hata verir. new() ebeveynli 'ns1 = new T()' null'u nesne yapar. Ebeveyn class veya struct ise diðer tiplemeler hata verir. Main sýnýf soysal olamaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SoysalSýnýf<T>'nin derleme hatasý verecek birkaç sýnýrlamalarý:");
            SýnýfA a = new SýnýfA();
            SýnýfB b = new SýnýfB();
            SýnýfC c = new SýnýfC();
            SýnýfZ<SýnýfA> z1 = new SýnýfZ<SýnýfA> (a);
            z1.selamla();
            SýnýfZ<SýnýfB> z2 = new SýnýfZ<SýnýfB> (b);
            z2.selamla();
            //SýnýfZ<SýnýfC> z3 = new SýnýfZ<SýnýfC> (c); //Hata! Çünkü SýnýfC SýnýfA'yi görmüyor
            Console.WriteLine ("'new T()' ile yaratýlan nesne artýk null deðildir:");
            SýnýfX<SýnýfC> x1 = new SýnýfX<SýnýfC>();
            Console.WriteLine ("'ns1=new T()' null mu? {0}\n'ns2' null mu? {1}", x1.ns1==null, x1.ns2==null);
            SýnýfY<SýnýfB> y1 = new SýnýfY<SýnýfB>();
            Console.WriteLine ("'y1.ns == null mu? {0}", y1.ns == null);
            // SýnýfY<int> y2 = new SýnýfY<int>(); //Hata, çünkü int, class deðil
            SýnýfQ<YapýA> q1 = new SýnýfQ<YapýA> (new YapýA());
            SýnýfQ<int> q2 = new SýnýfQ<int> (20240729);
            SýnýfQ<double> q3 = new SýnýfQ<double> (20240729.0359);
            //SýnýfQ<string> q4 = new SýnýfQ<string> ("M.Nihat Yavaþ"); //Hata, çünkü string, non-nullable deðil
            //SýnýfQ<SýnýfB> q4 = new SýnýfQ<SýnýfB> (new SýnýfB()); //Hata, çünkü SýnýfB, struct deðil
            SýnýfT.alan = "M.Nihat Yavaþ";
            SýnýfT.AlanYaz();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}