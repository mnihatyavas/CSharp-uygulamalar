// j2sc#0702.cs: 'new Sýnýf()' tiplemesi, üyelerine deðer atama/okuma örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        public int alan;
        public static void Tarih1() {DateTime t = DateTime.Now; Console.WriteLine ("Güncel tarih: [{0}]", t);}
        public void Tarih2() {DateTime t = DateTime.Now; Console.WriteLine ("Güncel tarih: [{0}]", t);}
    }
    class Sýnýf2 {
        int alan1; //Varsayýlý "private"
        static int alan2;
        public void DeðerAta (int d1, int d2) {alan1 = d1; alan2 = d2;}
        public void Göster() {Console.WriteLine ("alan1 = {0},\talan2 = {1}", alan1, alan2);}
        public int Topla() {return alan1 + alan2;}
    }
    public class Sýnýf3 {
        public int i = 0;
        public int j = 0;
    }
    class SýnýfTiplemesi {
        static void Tarih1() {DateTime t = DateTime.Now; Console.WriteLine ("Güncel tarih: [{0}]", t);}
        void Tarih2() {DateTime t = DateTime.Now; Console.WriteLine ("Güncel tarih: [{0}]", t);}
        private int alan;
        public SýnýfTiplemesi() {alan = 0;}
        public void DeðerAta (int a) {alan = a;}
        public int DeðerAl() {return alan;}
        static void Main() {
            Console.Write ("Ayný/ayrý sýnýfýn statik metotlarý doðrudan/sýnýf.metot() çaðrýlabilirken, statik olmayanlarýn ayný/ayrý-sýnýf tiplemeli/new çaðrýlmasý gerekmektedir. Tanýmlý sýnýf kurucusu alanlara parametresiz sabit yada parametreli deðiþir deðer atayabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýfiçi/dýþý statiksiz metot, tiplemeli/new çaðrýlmalýdýr:");
            var r=new Random();
            Tarih1();
            new SýnýfTiplemesi().Tarih2();
            SýnýfTiplemesi t = new SýnýfTiplemesi(); t.Tarih2();
            Sýnýf1.Tarih1();
            new Sýnýf1().Tarih2();
            Sýnýf1 t2 = new Sýnýf1(); t2.Tarih2();
            t2.alan = r.Next (0, 10000); Console.WriteLine ("t2.alan = {0}", t2.alan);
            t2.alan = r.Next (0, 10000); Console.WriteLine ("t2.alan = {0}", t2.alan);

            Console.WriteLine ("\nPrivate alanlara public metotla deðer atanabilir/okunabilir:");
            Sýnýf2 s21 = new Sýnýf2(), s22 = new Sýnýf2();
            s21.DeðerAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s21.Göster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s21.Topla() );
            s21.DeðerAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s21.Göster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s21.Topla() );
            s22.DeðerAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s22.Göster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s22.Topla() );
            s22.DeðerAta (r.Next (-10000, 10000), r.Next (-10000, 10000)); s22.Göster(); Console.WriteLine ("\tToplam (alan1 + alan2) = {0}", s22.Topla() );

            Console.WriteLine ("\nSýnýf tiplemesi dizisine deðer atama ve alma:");
            SýnýfTiplemesi[] dizi = new SýnýfTiplemesi [10];
            int i, toplam=0;
            for (i = 0; i < dizi.Length; ++i) dizi [i] = new SýnýfTiplemesi();
            for (i = 0; i < dizi.Length; ++i) dizi [i].DeðerAta (r.Next (-10000, 10000));
            for (i = 0; i < dizi.Length; ++i) {Console.WriteLine ("{0}.sýnýf nesnesi = {1}", (i+1), dizi [i].DeðerAl()); toplam +=dizi [i].DeðerAl();}
            Console.WriteLine ("\t{0} adet nesne deðerleri toplamý = {1}", dizi.Length, toplam);

            Console.WriteLine ("\n'object a' ile 'new Sýnýf3()' nesnelerinin karþýlaþtýrýlmasý:");
            object a;
            a = r.Next (-10000, 10000);
            Console.WriteLine ("\tobject a = {0}", a);
            Console.WriteLine ("a.ToString() = {0}", a.ToString());
            Console.WriteLine ("a'nýn tipi: {0}", a.GetType());
            Sýnýf3 b = new Sýnýf3(); b.i=r.Next (-10000, 10000); b.j=r.Next (-10000, 10000);
            Console.WriteLine ("\tb (new Sýnýf3()) = {0}", b);
            Console.WriteLine ("b.ToString() = {0}", b.ToString());
            Console.WriteLine ("b'nin tipi: {0}", b.GetType());
            Console.WriteLine ("b'nin alan deðerleri (i, j) = ({0}, {1})", b.i, b.j);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}