// j2sc#0702.cs: 'new S�n�f()' tiplemesi, �yelerine de�er atama/okuma �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        public int alan;
        public static void Tarih1() {DateTime t = DateTime.Now; Console.WriteLine ("G�ncel tarih: [{0}]", t);}
        public void Tarih2() {DateTime t = DateTime.Now; Console.WriteLine ("G�ncel tarih: [{0}]", t);}
    }
    class S�n�f2 {
        int alan1; //Varsay�l� "private"
        static int alan2;
        public void De�erAta (int d1, int d2) {alan1 = d1; alan2 = d2;}
        public void G�ster() {Console.WriteLine ("alan1 = {0},\talan2 = {1}", alan1, alan2);}
        public int Topla() {return alan1 + alan2;}
    }
    public class S�n�f3 {
        public int i = 0;
        public int j = 0;
    }
    class S�n�fTiplemesi {
        static void Tarih1() {DateTime t = DateTime.Now; Console.WriteLine ("G�ncel tarih: [{0}]", t);}
        void Tarih2() {DateTime t = DateTime.Now; Console.WriteLine ("G�ncel tarih: [{0}]", t);}
        private int alan;
        public S�n�fTiplemesi() {alan = 0;}
        public void De�erAta (int a) {alan = a;}
        public int De�erAl() {return alan;}
        static void Main() {
            Console.Write ("Ayn�/ayr� s�n�f�n statik metotlar� do�rudan/s�n�f.metot() �a�r�labilirken, statik olmayanlar�n ayn�/ayr�-s�n�f tiplemeli/new �a�r�lmas� gerekmektedir. Tan�ml� s�n�f kurucusu alanlara parametresiz sabit yada parametreli de�i�ir de�er atayabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fi�i/d��� statiksiz metot, tiplemeli/new �a�r�lmal�d�r:");
            var r=new Random();
            Tarih1();
            new S�n�fTiplemesi().Tarih2();
            S�n�fTiplemesi t = new S�n�fTiplemesi(); t.Tarih2();
            S�n�f1.Tarih1();
            new S�n�f1().Tarih2();
            S�n�f1 t2 = new S�n�f1(); t2.Tarih2();
            t2.alan = r.Next (0, 10000); Console.WriteLine ("t2.alan = {0}", t2.alan);
            t2.alan = r.Next (0, 10000); Console.WriteLine ("t2.alan = {0}", t2.alan);

            Console.WriteLine ("\nPrivate alanlara public metotla de�er atanabilir/okunabilir:");
            S�n�f2 s21 = new S�n�f2(), s22 = new S�n�f2();
            s21.De�erAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s21.G�ster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s21.Topla() );
            s21.De�erAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s21.G�ster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s21.Topla() );
            s22.De�erAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s22.G�ster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s22.Topla() );
            s22.De�erAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s22.G�ster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s22.Topla() );

            Console.WriteLine ("\nS�n�f tiplemesi dizisine de�er atama ve alma:");
            S�n�fTiplemesi[] dizi = new S�n�fTiplemesi [10];
            int i, toplam=0;
            for (i = 0; i < dizi.Length; ++i) dizi [i] = new S�n�fTiplemesi();
            for (i = 0; i < dizi.Length; ++i) dizi [i].De�erAta (r.Next (-10000, 10000));
            for (i = 0; i < dizi.Length; ++i) {Console.WriteLine ("{0}.s�n�f nesnesi = {1}", (i+1), dizi [i].De�erAl()); toplam +=dizi [i].De�erAl();}
            Console.WriteLine ("\t{0} adet nesne de�erleri toplam� = {1}", dizi.Length, toplam);

            Console.WriteLine ("\n'object a' ile 'new S�n�f3()' nesnelerinin kar��la�t�r�lmas�:");
            object a;
            a = r.Next (-10000, 10000);
            Console.WriteLine ("\tobject a = {0}", a);
            Console.WriteLine ("a.ToString() = {0}", a.ToString());
            Console.WriteLine ("a'n�n tipi: {0}", a.GetType());
            S�n�f3 b = new S�n�f3(); b.i=r.Next (-10000, 10000); b.j=r.Next (-10000, 10000);
            Console.WriteLine ("\tb (new S�n�f3()) = {0}", b);
            Console.WriteLine ("b.ToString() = {0}", b.ToString());
            Console.WriteLine ("b'nin tipi: {0}", b.GetType());
            Console.WriteLine ("b'nin alan de�erleri (i, j) = ({0}, {1})", b.i, b.j);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}