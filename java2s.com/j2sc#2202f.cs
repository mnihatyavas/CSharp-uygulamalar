// j2sc#2202f.cs: Aggregate ile k�m�latif topla-��kar-�arp-b�l, adlar� ekle-tersle �rne�i.

using System;
using System.Linq;
using System.Collections.Generic; //IEnumerable<> i�in
namespace LinqMetot {
    class Aggregate {
        private static string Tersten (string dizge) {
            List<string> adlar = new List<string>(dizge.Split (' ').ToList());
            return adlar.Aggregate ((a, b) => b + " " + a);            
        }
        static void Main() {
            Console.Write ("Aggregate toplam (Sum) gibi anla��lsa da, ikili lambda parametreyle her t�rl� ard���k i�lemi yapmakta. Burada a dizinin ilk eleman�, b de ikincisi olup, toplar, ��kar�r, �arpar, b�ler vb. Sonras�nda a ilk i�lem sonucu, b de dizinin 3.eleman�d�r... b�ylece dizi sonuna de�in i�lemi s�rd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("dizi.Aggregate, lambda i�lemini (�arp, topla, ��kar vb) ard���k yapar:");
            int i, ts=1, ts2=0;
            int[] tsDizi = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var �arp = tsDizi.Aggregate ((a, b) => a * b); //T�m say�lar� ilkine ard���k �arpar
            var topla = tsDizi.Aggregate ((a, b) => a + b); //T�m say�lar� ilkine ard���k toplar
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", 9, �arp, topla);
            for(i=0;i<tsDizi.Length;i++) {ts*=tsDizi [i]; ts2+=tsDizi [i];}
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", 9, ts, ts2);
            var r=new Random(); ts=r.Next(1,21);
            IEnumerable<int> seri = Enumerable.Range (1, ts);
            Console.Write  ("-->Range(1,{0}): ", ts);
            foreach (int n in seri) Console.Write  (n+" "); Console.WriteLine();
            �arp = seri.Aggregate ((x, y) => x * y);
            topla = seri.Aggregate ((x, y) => x + y);
            Console.WriteLine ("{0}! = {1}\tToplam = {2}", ts, �arp, topla);
            for(i=0;i<tsDizi.Length;i++) {ts=r.Next(1,20); tsDizi [i]=ts;}
            Console.Write  ("-->tsDizi[{0}]: ", tsDizi.Length);
            foreach (int n in tsDizi) Console.Write  (n+" "); Console.WriteLine();
            �arp = tsDizi.Aggregate ((a, b) => a * b);
            topla = tsDizi.Aggregate ((a, b) => a + b);
            var ��kar = tsDizi.Aggregate ((a, b) => a - b); //T�m say�lar� ilkinden ard���k ��kar�r
            Console.WriteLine ("�arp = {0}\tTopla = {1}\t��kar = {2}", �arp, topla, ��kar);
            double ds; double[] dsDizi=new double[10];
            for(i=0;i<dsDizi.Length;i++) {ds=r.Next(1,20)+r.Next(10,100)/100d; dsDizi [i]=ds;}
            Console.Write  ("-->dsDizi[{0}]: ", dsDizi.Length);
            foreach (var n in dsDizi) Console.Write  (n+" "); Console.WriteLine();
            var �arp2 = dsDizi.Aggregate ((a, b) => a * b);
            var b�l = dsDizi.Aggregate ((a, b) => a / b);
            Console.WriteLine ("�arp = {0}\tB�l = {1}", �arp2, b�l);

            Console.WriteLine ("\nPeygamber adlar�, uzunluk, ekleme, ters s�ralama:");
            string c�mle="Adlar�n boy toplam�:";
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            foreach(string ad in peygamberler) c�mle+=" "+ad;
            Console.WriteLine (c�mle);
            Console.WriteLine ("-->�lk a��klama ve ara bo�luk dahil {0} adet peygamber ad uzunluklar� toplam� = {1}", peygamberler.Length, peygamberler.Aggregate<string, string, int>("Adlar�n boy toplam�: ", (a, b) => a + " " + b, a => a.Length));
            Console.WriteLine (peygamberler.Aggregate<string, string, string>("-->Peygamberler: ", (a, b) => a + " " + b, a => a));
            Console.WriteLine ("-->Ara bo�luksuz peygamber adlar�n� ekler = " + peygamberler.Aggregate ((a, b) => a + b));
            Console.WriteLine ("-->Ara bo�luksuz peygamber ad uzunluklar� toplam� = " + peygamberler.Aggregate<string, int>(0, (a, b) => a + b.Length));
            Console.WriteLine ("-->Altalta peygamber adlar�:\n" + peygamberler.Aggregate ((bu, sonraki) => bu + "\r\n" + sonraki));
            Console.WriteLine ("-->Peygamberler tersten: " + Tersten (peygamberler.Aggregate ((a, b) => a + " " + b)) );

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}