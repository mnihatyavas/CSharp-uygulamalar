// j2sc#2202c.cs: Linq-Count, Min, Max, Distinct, Range, LongCount metotlar� �rne�i.

using System;
using System.Linq; // Count i�in
using System.Collections.Generic; //List<> i�in
namespace LinqMetot {
    class M��teri : IComparable<M��teri> {
        public int M��teriNo {get; set;}
        public string �irketAd� {get; set;}
        public string Adresi {get; set;}
        public List<�r�n> Sipari�ler {get; set;}
        public override string ToString() {return String.Format ("M��teri no: {0}, �irket ad�: {1}, Adresi: {3}", this.M��teriNo, this.�irketAd�, this.Adresi);}
        int IComparable<M��teri>.CompareTo (M��teri �u) {
            if (�u == null) return 1;
            if (this.M��teriNo > �u.M��teriNo) return 1;
            if (this.M��teriNo < �u.M��teriNo) return -1;
            return 0;
        }
    }
    class �r�n : IComparable<�r�n> {
        public int �r�nNo {get; set;}
        public string �r�nAd� {get; set;}
        public string Katagori {get; set;}
        public int BirimFiyat {get; set;}
        public int Sipari�Adedi {get; set;}
        public DateTime Sipari�Tarihi {get; set;}
        public override string ToString() {return String.Format ("�r�n no: {0}, �r�n ad�: {1} , Katagori: {3}", this.�r�nNo, this.�r�nAd�, this.Katagori);}
        int IComparable<�r�n>.CompareTo (�r�n �u) {
            if (�u == null) return 1;
            if (this.�r�nNo > �u.�r�nNo) return 1;
            if (this.�r�nNo < �u.�r�nNo) return -1;
            return 0;
        }
    }
    class Dikd�rtgen {
        public int en {get; set;}
        public int boy {get; set;}
        public override string ToString() {return string.Format ("(En, Boy= = ({0}, {1})", en, boy);}
    }
    class Count_Long {
        static List<M��teri> M��teriListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 58});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            List<M��teri> m��teriListesi = new List<M��teri>();
            m��teriListesi.Add (new M��teri {�irketAd� = "Abdulkerim Ltd", Adresi = "Rize", Sipari�ler = �r�nListesi, M��teriNo = 10});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ziyadede A�", Adresi = "Kayseri", Sipari�ler = �r�nListesi, M��teriNo = 4});
            m��teriListesi.Add (new M��teri {�irketAd� = "P�narba�� Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 25});
            m��teriListesi.Add (new M��teri {�irketAd� = "Billiruye A�", Adresi = "Zonguldak", Sipari�ler = �r�nListesi, M��teriNo = 93});
            m��teriListesi.Add (new M��teri {�irketAd� = "�emseddinpa�a A�", Adresi = "Kars", Sipari�ler = �r�nListesi, M��teriNo = 64});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ke�i�ren Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 164});
            return m��teriListesi;
        }
        static void listeyiG�ster1<T>(IEnumerable<T> liste) {foreach (var �l�� in liste) {Console.WriteLine (�l��);}}
        static void listeyiG�ster2<T>(IEnumerable<T> liste) {foreach (var �l�� in liste) {Console.Write (�l��+" ");} Console.WriteLine();}
        static void Main() {
            Console.Write ("Linq'in dizi.Count()/Min()/Max()/Distinct()/Range()/LongCount metotlar�.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Linq-Count() metoduyla t�m ve lambda sorgulu peygamber say�lar�:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.Write ("Peygamberler dizisi: "); foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            int say� = peygamberler.Count(); Console.WriteLine ("Dizideki peygamber say�s�: " + say�);
            say� = peygamberler.Count (p => p.StartsWith ("M")); Console.WriteLine ("'M'yle ba�layan peygamber say�s�: " + say�);

            Console.WriteLine ("\nLinq-y�llar.Count(), y�llar.Min() ve y�llar.Max():");
            int i, ts;
            int[] y�llar = new int [1939-1881];
            for(i=0;i<y�llar.Length;i++) y�llar [i]=i+1881;
            Console.Write ("Ard���k y�llar dizisi: "); foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("Toplam y�l say�s�: " + y�llar.Count());
            Console.WriteLine ("Y�l(enk���k, enb�y�k) = ({0}, {1})", y�llar.Min(), y�llar.Max());
              
            Console.WriteLine ("\nRasgele y�llar�n t�m, yegane, tek/�ift y�l say�lar�:");
            var r=new Random();
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i]=ts;} Array.Sort (y�llar);
            Console.Write ("Rasgele y�llar dizisi: "); foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("T�m y�lar say�s�: " + y�llar.Count());
            Console.WriteLine ("Yegane y�lar say�s�: " + y�llar.Distinct().Count());
            Console.WriteLine ("Say�(teky�llar, �ifty�llar) = ({0}, {1})", y�llar.Count (n => n % 2 == 1), y�llar.Count (n => n % 2 == 0));

            Console.WriteLine ("\nListedeki herbir m��terinin verdi�i sipari� say�lar�n�n sorgulanmas�:");
            List<M��teri> m��teriler = M��teriListesiniAl();
            var sipari�Say�Sorgusu = from m�� in m��teriler
                orderby m��.M��teriNo
                select new {m��.M��teriNo, sipari�Say�s� = m��.Sipari�ler.Count()};
            foreach (var sip in sipari�Say�Sorgusu) Console.WriteLine (sip);

            Console.WriteLine ("\nRasgele 100.000 say�n�n her 10.000 barem adedi ve ortalamas� 10.000 civar�d�r:");
            int[] say�lar = new int [100000];
            for(i = 0; i < 100000; i++) say�lar [i] = r.Next(0,100000);
            IEnumerable<int> say�Sorgusu=null; ts=0;
            for(i=0;i<100000;i+=10000) {
                say�Sorgusu = from n in say�lar where n > i & n <= i+10000 select n;
                Console.WriteLine ("Say�({0} < n <= {1}) = {2}", i, i+10000, say�Sorgusu.Count());
                ts+=say�Sorgusu.Count();
            }
            Console.WriteLine ("10 sorgu say�s�n�n ortalamas� = " + ts/10d);

            Console.WriteLine ("\nRasgele dikd�rtgen(en,boy) say�lar� ve Range (1881,58):");
            int ts2, ts3=r.Next(2,10);
            List<Dikd�rtgen> �l��ler = new List<Dikd�rtgen>();
            for(i=0;i<ts3;i++) {
                ts=r.Next(1,100); ts2=r.Next(1,100);
                �l��ler.Add (new Dikd�rtgen {boy = ts, en = ts2});
            }
            listeyiG�ster1 (�l��ler);
            Console.WriteLine ("Dikd�rtgen say�s�: {0}", �l��ler.Count());
            var seneler = Enumerable.Range (1881, 58);
            listeyiG�ster2 (seneler);
            Console.WriteLine ("Senelerin say�s�: {0}\t�ift sene say�s�: {1}", seneler.Count(), seneler.Count (n => n % 2 == 0));

            Console.WriteLine ("\n�ok bekleten 'long Range(0,int.MaxValue).Concat(0,int.MaxValue)' say�s� (4.294.967.294):");
/*            long adet = Enumerable.Range (0, int.MaxValue).Concat (Enumerable.Range (0, int.MaxValue)).LongCount(); Console.WriteLine ("2 kat Range(0,int.MaxValue) say�s�: {0:#,0}", adet);
            //adet = Enumerable.Range (0, int.MaxValue).Concat (Enumerable.Range (0, int.MaxValue)).LongCount (n => n > 1 && n < 4); Console.WriteLine (adet);
*/
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}