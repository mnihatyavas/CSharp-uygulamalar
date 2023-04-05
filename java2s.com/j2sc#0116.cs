// j2sc#0116.cs: De�i�ebilir adet metot arg�manlar�n�n 'params' ile idaresi �rne�i.

using System;
namespace DilTemelleri {
    class EnK���kB�y�k {
        public int enk���kB�y�k (out int enb�y�k, params int[] say�lar) {
            //if (say�lar.Length == 0) {Console.WriteLine ("HATA: Arg�man YOK."); return 0;}
            int enk���k = enb�y�k = say�lar [0];
            for (int i=1; i < say�lar.Length; i++) {
                if (say�lar [i] < enk���k) enk���k = say�lar [i];
                if (say�lar [i] > enb�y�k) enb�y�k = say�lar [i];
            }
            return enk���k;
        }
    }
    class Arg�manlar�G�ster {
        public void arg�manlar�G�ster (string mesaj, params int[] say�lar) {
            int n=0; Console.Write ("\n" + mesaj + ": ");
            foreach (int i in say�lar) {++n; Console.Write (i + " ");} Console.WriteLine ("\n ==>Arg�man say�s�: " + n);
        }
    }
    class �ah�s {
        public string isim;
        public int ya�;
        public �ah�s (string i, int y) {isim = i; ya� = y;}
        public void G�ster() {Console.WriteLine ("{0} adl� �ah�s {1} ya��ndad�r.", isim, ya�);}
    }
    class Params {
        public static void NesnelerDizisi (params object[] dizi) {
            for (int i = 0 ; i < dizi.Length ; i++ ) {   
                if (dizi [i] is �ah�s) {((�ah�s)dizi [i]).G�ster();
                }else Console.WriteLine (dizi [i]);
            }
        }
        static void Main() {
            Console.Write ("Her veri tipli de�i�ebilir say�daki metot arg�manlar� 'params tip[] dizi' ile y�netilebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new EnK���kB�y�k(); int b�y�k; var r=new Random();
            var dizi = new int[] {2023, 1951}; Console.WriteLine ("{0} elemanl� tamsay� dizinin enk���k ve enb�y�k elemanlar�: ({1}, {2})", dizi.Length, nesne1.enk���kB�y�k (out b�y�k, dizi), b�y�k);
            dizi = new int[] {2023, 1951, 1938, 1881}; Console.WriteLine ("{0} elemanl� tamsay� dizinin enk���k ve enb�y�k elemanlar�: ({1}, {2})", dizi.Length, nesne1.enk���kB�y�k (out b�y�k, dizi), b�y�k);
            dizi = new int[] {2023, 1951, 1938, 1881, -450, 0}; Console.WriteLine ("{0} elemanl� tamsay� dizinin enk���k ve enb�y�k elemanlar�: ({1}, {2})", dizi.Length, nesne1.enk���kB�y�k (out b�y�k, dizi), b�y�k);
            int n=r.Next (2, 100);
            dizi=new int [n]; for (int i=0; i < n; i++) dizi [i]=r.Next (-10000, 10000);
            Console.WriteLine ("{0} elemanl� tamsay� dizinin enk���k ve enb�y�k elemanlar�: ({1}, {2})", n, nesne1.enk���kB�y�k (out b�y�k, dizi), b�y�k);

            var nesne2 = new Arg�manlar�G�ster(); 
            nesne2.arg�manlar�G�ster ("��te birka� tamsay�", 1, 2, 3, 4, 5);
            nesne2.arg�manlar�G�ster ("��te birka� y�l", 1881, 1938, 1951, 2023);
            nesne2.arg�manlar�G�ster ("Al sana ekstra M� ve MS y�llar", dizi);

            var �1 = new �ah�s ("M.Nihat Yava�", 2023-1957);
            var �2 = new �ah�s ("Sevim Yava�", 2023-1963);
            var �3 = new �ah�s ("Zafer N.Candan", 2023-1977);
            Console.WriteLine(); NesnelerDizisi (true, �1, 1938-1881, �2, "System.String", �3, "Merhabalar!..", (1==0));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}