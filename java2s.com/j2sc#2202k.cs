// j2sc#2202k.cs: Except/Intersect ile d��layan/jesi�en elemanlar �rne�i.

using System;
using System.Linq; //Except ve Intersect i�in
using System.Collections.Generic; //IEnumerable<> ve List<>i�in
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
    class Bayii {
        public string No {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro;
    }
    class Sipari� {
        public string No {get; set;}
        public decimal Tutar {get; set;}
    }
    class Except_Intersect {
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
            m��teriListesi.Add (new M��teri {�irketAd� = "Cihan Ltd", Adresi = "Rize", Sipari�ler = �r�nListesi, M��teriNo = 10});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ziyadede A�", Adresi = "Kayseri", Sipari�ler = �r�nListesi, M��teriNo = 4});
            m��teriListesi.Add (new M��teri {�irketAd� = "P�narba�� Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 25});
            m��teriListesi.Add (new M��teri {�irketAd� = "Billiruye A�", Adresi = "Zonguldak", Sipari�ler = �r�nListesi, M��teriNo = 93});
            m��teriListesi.Add (new M��teri {�irketAd� = "�emseddinpa�a A�", Adresi = "Kars", Sipari�ler = �r�nListesi, M��teriNo = 64});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ke�i�ren Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 164});
            return m��teriListesi;
        }
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nNo = 1881, �r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1500, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1914, �r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 130, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1919, �r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 680, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1920, �r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 700, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1923, �r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, Sipari�Adedi = 1600, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1930, �r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1938, �r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return �r�nListesi;
        }
        static void Main() {
            Console.Write ("'dizi1.Except(dizi2)' ilk diziden ikincileri d��layan yegane elemanlar�n altk�mesini d�nd�r�r. 'dizi1.Intersect(dizi2)' ilk diziden ikincilerle �ak��an yegane elemanlar�n altk�mesini d�nd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�ki dizi elemanlar�ndan yegane istisna ve ortak olanlar:");
            String[] say�lar1 = {"Bir", "�ki", "�ki", "��", "D�rt"};
            String[] say�lar2 = {"��", "��", "D�rt", "Be�", "Alt�"};
            var hari�1 = say�lar1.Except (say�lar2);
            Console.Write ("say�lar1.Except (say�lar2): ");
            foreach (var n in hari�1) Console.Write (n+" "); Console.WriteLine();
            var kesi�en1 = say�lar1.Intersect (say�lar2);
            Console.Write ("say�lar1.Intersect (say�lar2): ");
            foreach (var n in kesi�en1) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\n�ki y�llar dizinin d��layan ve kesi�en elemanlar�:");
            int[] y�llarA = {1919, 1920, 1921, 1922, 1923, 1927, 1938};
            int[] y�llarB = {1920, 1923, 1926, 1930, 1938};
            IEnumerable<int> hari�2 = y�llarA.Except (y�llarB);
            Console.Write ("y�llarA.Except (y�llarB): ");
            foreach (var n in hari�2) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> kesi�en2 = y�llarA.Intersect (y�llarB);
            Console.Write ("y�llarA.Intersect (y�llarB): ");
            foreach (var n in kesi�en2) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\n�r�n ve m��teri ilk harflerinin d��layan ve kesi�enleri:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            List<M��teri> m��teriler = M��teriListesiniAl();
            var �r�nHarf = from � in �r�nler select �.�r�nAd� [0];
            var m��teriHarf = from m in m��teriler select m.�irketAd� [0];
            var hari�3 = �r�nHarf.Except (m��teriHarf);
            Console.Write ("�r�nHarf.Except (m��teriHarf): ");
            foreach (var k in hari�3) Console.Write (k+" "); Console.WriteLine();
            var kesi�en3 = �r�nHarf.Intersect (m��teriHarf);
            Console.Write ("�r�nHarf.Intersect (m��teriHarf): ");
            foreach (var k in kesi�en3) Console.Write (k+" "); Console.WriteLine();

            Console.WriteLine ("\nBayiler ve sipari�lerinin d��layan ve kesi�en no'lar�:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", �ehir="Tahran", �lke="�ran", K�ta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m}
            };
            List<Sipari�> sipari�ler = new List<Sipari�> {
                new Sipari� {No="2024R", Tutar=912.66m},
                new Sipari� {No="2024S", Tutar=1054.38m},
                new Sipari� {No="2024T", Tutar=897.56m}
            };
            var bnolar = from b in bayiler select b.No;
            var snolar = from s in sipari�ler select s.No;
            var hari�4 = bnolar.Except (snolar);
            Console.Write ("bnolar.Except (snolar): ");
            foreach (var no in hari�4) Console.Write ("{0} ", no); Console.WriteLine();
            var kesi�en4 = bnolar.Intersect (snolar);
            Console.Write ("bnolar.Intersect (snolar): ");
            foreach (var no in kesi�en4) Console.Write ("{0} ", no); Console.WriteLine();

            Console.WriteLine ("\nPeygamberlerin Take/Skip altk�melerinin d��layan ve �ak��anlar�:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> pey1 = peygamberler.Take (7);
            IEnumerable<string> pey2 = peygamberler.Skip (4);
            IEnumerable<string> hari�5 = pey1.Except (pey2);
            IEnumerable<string> kesi�en5 = pey1.Intersect (pey2);
            Console.WriteLine ("Peygamberlerin say�s�: " + peygamberler.Count());
            Console.WriteLine ("�lk pey1 dizinin say�s�: " + pey1.Count());
            Console.WriteLine ("�kinci pey2 dizinin say�s�: " + pey2.Count());
            Console.WriteLine ("D��layan dizinin say�s�: " + hari�5.Count());
            Console.WriteLine ("�ak��an dizinin say�s�: " + kesi�en5.Count());
            Console.Write ("T�m peygamberler: ");
            foreach (string ad in peygamberler) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("pey1.Except (pey2): ");
            foreach (string ad in hari�5) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("pey1.Intersect (pey2): ");
            foreach (string ad in kesi�en5) Console.Write (ad+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}