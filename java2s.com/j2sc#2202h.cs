// j2sc#2202h.cs: Take, Skip, TakeWhile, SkipWhile �ncekiler-sonrakiler �rne�i.

using System;
using System.Linq; //Take i�in
using System.Collections.Generic; //IEnumerable<> i�in
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
    class Take_TakeWhile {
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
            Console.Write ("'dizi.Take(n)' dizinin ilk n elaman�n� al�r. 'dizi.Skip(n)' dizinin ilk n eleman�n� atlay�p, sona kalanlar� al�r. 'dizi.TakeWhile/SkipWhile' alma ve atlamaya lambda �art� uygular.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�lk 3'� al, ilk 4'� atlay�p kalan� al, al/atlay� y�l<=1917+index �artl� yap:");
            int[] y�llar = {1881, 1914, 1918, 1919, 1920, 1923, 1930, 1938};
            Console.Write ("-->T�m y�llar: "); foreach(var y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            IEnumerable<int> al3 = y�llar.Take (3);
            IEnumerable<int> atla4 = y�llar.Skip (4);
            var �artl�Al = y�llar.TakeWhile ((y�l, index) => y�l <= (1917+index));
            var �artl�Atla = y�llar.SkipWhile ((y�l, index) => y�l <= (1917+index));
            Console.Write ("-->y�llar.Take(3): "); foreach(var y�l in al3) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->y�llar.Skip(4): "); foreach(var y�l in atla4) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->y�llar.TakeWhile(y�l<=1917+index): "); foreach(var y�l in �artl�Al) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->y�llar.SkipWhile(y�l<=1917+index): "); foreach(var y�l in �artl�Atla) Console.Write (y�l+" "); Console.WriteLine();
   
            Console.WriteLine ("\n�lk 5 peygamber ve krk'lerinin ard���k dizilimi:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.Write ("-->T�m peygamberler: "); foreach(var pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            var al5=peygamberler.Take (5);
            Console.Write ("-->peygamberler.Take(5): "); foreach(var pey in al5) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<char> krk5 = peygamberler.Take (5).SelectMany (k => k.ToArray());
            Console.Write ("-->peygamberler.Take(5).SelectMany(k=>k.ToArray()): "); foreach(var k in krk5) Console.Write (k.ToString().ToLower()); Console.WriteLine();

            Console.WriteLine ("\nT�m Ankara'l� m��terilerin ilk ve son 3 sipari� bilgileri:");
            List<M��teri> m��teriler = M��teriListesiniAl();
            var sorgu1 = (
                from m in m��teriler
                from s in m.Sipari�ler
                where m.Adresi == "Ankara"
                select new {m.M��teriNo, s.�r�nNo, s.Sipari�Tarihi})
            .Take (3);
            Console.WriteLine ("-->Ankara'l� m��terilerin ilk/Take(3) 3 sipari�leri:");
            foreach (var sip in sorgu1) Console.WriteLine (sip);
            var sorgu2 = (
                from m in m��teriler
                from s in m.Sipari�ler
                where m.Adresi == "Ankara"
                select new {m.M��teriNo, s.�r�nNo, s.Sipari�Tarihi})
            .Skip (11);
            Console.WriteLine ("-->Ankara'l� m��terilerin son/Skip(11) 3 sipari�leri:");
            foreach (var sip in sorgu2) Console.WriteLine (sip);

            Console.WriteLine ("\nTakeWhile ile say�sal/dizgesel �artl� ilkil al�mlar:");            
            var �nce1919 = y�llar.TakeWhile (y => y < 1919);
            var sonra1919 = y�llar.SkipWhile (y => y < 1919);
            IEnumerable<int> istisna1918 = y�llar.TakeWhile (y => y.CompareTo (1918) != 0);
            IEnumerable<string> uzun10_5 = peygamberler.TakeWhile ((p, i) => p.Length < 10 && i < 5);
            var atlaAl = peygamberler.SkipWhile (p => p != "Davut").TakeWhile (p => p != "Buda");
            Console.Write ("-->y�llar.TakeWhile(y=>y<1919): "); foreach(var y�l in �nce1919) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->y�llar.SkipWhile(y=>y<1919): "); foreach(var y�l in sonra1919) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->y�llar.TakeWhile(y!=1918): "); foreach(var y�l in istisna1918) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("-->peygamberler.TakeWhile(p.Length<10&&i<5): "); foreach(var pey in uzun10_5) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->peygamberler.Take/Skip-While('Davut'<=p<'Buda': "); foreach(var pey in atlaAl) Console.Write (pey+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}