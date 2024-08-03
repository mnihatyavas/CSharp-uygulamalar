// j2sc#1803d.cs: Ebeveyn, new(), class, struct ve Main<T> k�s�tlamalar� �rne�i.

using System;
namespace SoysalS�n�f {
    class S�n�fA {public void selam() {Console.WriteLine ("Merhabalar!");}}
    class S�n�fB: S�n�fA {}
    class S�n�fC {public S�n�fC() {}}
    class S�n�fZ<T> where T: S�n�fA {
        T ns; 
        public S�n�fZ (T n) {ns = n;} //Kurucu
        public void selamla() {ns.selam();}
    }
    class S�n�fX<T> where T: new() {
        public T ns1;
        public T ns2 = default (T);
        public S�n�fX() {ns1 = new T();}
    } 
    class S�n�fY<T> where T: class {
        public T ns;
        public S�n�fY() {ns = null;} //Kurucu
    }
    struct Yap�A {}
    class S�n�fQ<T> where T: struct {
        T ns;
        public S�n�fQ (T x) {ns = x;}
    }
    class S�n�fT {//Main() s�n�f� S�n�fT<T> soysal olamaz
        public static string alan;
        public static void AlanYaz() {Console.WriteLine ("alan: {0}\t Tipi: {1}", alan, typeof(S�n�fT).Name);
            }
        static void Main() {
            Console.Write ("'S�n�fZ<T> where T: S�n�fA' ebeveynsiz S�n�fC hata verir. new() ebeveynli 'ns1 = new T()' null'u nesne yapar. Ebeveyn class veya struct ise di�er tiplemeler hata verir. Main s�n�f soysal olamaz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SoysalS�n�f<T>'nin derleme hatas� verecek birka� s�n�rlamalar�:");
            S�n�fA a = new S�n�fA();
            S�n�fB b = new S�n�fB();
            S�n�fC c = new S�n�fC();
            S�n�fZ<S�n�fA> z1 = new S�n�fZ<S�n�fA> (a);
            z1.selamla();
            S�n�fZ<S�n�fB> z2 = new S�n�fZ<S�n�fB> (b);
            z2.selamla();
            //S�n�fZ<S�n�fC> z3 = new S�n�fZ<S�n�fC> (c); //Hata! ��nk� S�n�fC S�n�fA'yi g�rm�yor
            Console.WriteLine ("'new T()' ile yarat�lan nesne art�k null de�ildir:");
            S�n�fX<S�n�fC> x1 = new S�n�fX<S�n�fC>();
            Console.WriteLine ("'ns1=new T()' null mu? {0}\n'ns2' null mu? {1}", x1.ns1==null, x1.ns2==null);
            S�n�fY<S�n�fB> y1 = new S�n�fY<S�n�fB>();
            Console.WriteLine ("'y1.ns == null mu? {0}", y1.ns == null);
            // S�n�fY<int> y2 = new S�n�fY<int>(); //Hata, ��nk� int, class de�il
            S�n�fQ<Yap�A> q1 = new S�n�fQ<Yap�A> (new Yap�A());
            S�n�fQ<int> q2 = new S�n�fQ<int> (20240729);
            S�n�fQ<double> q3 = new S�n�fQ<double> (20240729.0359);
            //S�n�fQ<string> q4 = new S�n�fQ<string> ("M.Nihat Yava�"); //Hata, ��nk� string, non-nullable de�il
            //S�n�fQ<S�n�fB> q4 = new S�n�fQ<S�n�fB> (new S�n�fB()); //Hata, ��nk� S�n�fB, struct de�il
            S�n�fT.alan = "M.Nihat Yava�";
            S�n�fT.AlanYaz();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}