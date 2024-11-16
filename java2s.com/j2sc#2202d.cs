// j2sc#2202d.cs: IComparable<T>.CompareTo (T �u) ile �zel k�yas alan� �rne�i.

using System;
using System.Linq; //from-select i�in
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
    class Compareto {
        static List<M��teri> M��teriListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nNo = 1881, �r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1500, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1914, �r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 130, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1919, �r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 680, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1920, �r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 700, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1923, �r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, Sipari�Adedi = 1600, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1930, �r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1938, �r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            List<M��teri> m��teriListesi = new List<M��teri>();
            m��teriListesi.Add (new M��teri {�irketAd� = "Abdulkerim Ltd", Adresi = "Rize", Sipari�ler = �r�nListesi, M��teriNo = 10});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ziyadede A�", Adresi = "Kayseri", Sipari�ler = �r�nListesi, M��teriNo = 4});
            m��teriListesi.Add (new M��teri {�irketAd� = "P�narba�� Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 25});
            m��teriListesi.Add (new M��teri {�irketAd� = "Billiruye A�", Adresi = "Zonguldak", Sipari�ler = �r�nListesi, M��teriNo = 93});
            m��teriListesi.Add (new M��teri {�irketAd� = "�emseddinpa�a A�", Adresi = "Kars", Sipari�ler = �r�nListesi, M��teriNo = 64});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ke�i�ren Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 164});
            return m��teriListesi;
        }
        static void Main() {
            Console.Write ("�ki �ok-alanl� nesne k�yaslan�rken 'IComparable<T>.CompareTo (T �u)' ile k�yas�n hangi alanla yap�laca�� tan�mlan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�ki say� dizisinde (a < b) �iftleri:");
            int[] say�larA = {10, 20, 40, 15, 65, 850, 999};
            int[] say�larB = {10, 30, 50, 70, 82};
            Console.Write ("A say� dizisi: "); foreach(var n in say�larA) Console.Write (n+" "); Console.WriteLine();
            Console.Write ("B say� dizisi: "); foreach(var n in say�larB) Console.Write (n+" "); Console.WriteLine();
            var �iftler =
                from a in say�larA //��i�e for-i --> for-j misali A'n�n her bir say�s� B'nin ba�tan sona t�m say�lar�yla k�yaslan�r
                from b in say�larB
                where a < b
                select new {a, b};
            Console.Write ("a < b �iftleri: "); foreach (var �ift in �iftler) Console.Write ("({0} < {1})  ", �ift.a, �ift.b); Console.WriteLine();

            Console.WriteLine ("\nHerbir m��terinin farkl� kriterli sipari� listeleri:");
            List<M��teri> m��teriler = M��teriListesiniAl();
            var sipari�ler =
                from m�� in m��teriler
                from sip in m��.Sipari�ler
                where sip.Sipari�Adedi < 500 // ">= 500" de denenebilir
                select new {m��.M��teriNo, sip.�r�nNo, sip.�r�nAd�, sip.Sipari�Adedi};
            Console.WriteLine ("-->Herbir m��terinin 'Sipari�Adedi < 500' olan sipari�leri:");
            foreach(var sip in sipari�ler) Console.WriteLine (sip);
            Console.WriteLine ("-->'Ankara'l� herbir endeksli m��terinin sipari� �r�n no'lar�:");
            DateTime SonTarih = DateTime.Now;
            var sipari�ler2 =
                from m�� in m��teriler
                where m��.Adresi == "Ankara"
                from sip in m��.Sipari�ler
                where sip.Sipari�Tarihi < SonTarih
                select new {m��.�irketAd�, sip.Sipari�Tarihi};
            foreach(var sip in sipari�ler2) Console.WriteLine (sip);
            Console.WriteLine ("-->Herbir 'Ankara'l� endeksli m��terinin sipari� �r�n no'lar�:");
            var sipari�ler3 =
                m��teriler.Where (m�� => m��.Adresi == "Ankara")
                .SelectMany ((m��, m��Endeks) => m��.Sipari�ler.Select (sip => "M��teri#" + (m��Endeks + 1) + "'e ait �r�n no: " + sip.�r�nNo));
            foreach(var sip in sipari�ler3) Console.WriteLine (sip);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}