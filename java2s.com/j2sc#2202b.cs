// j2sc#2202b.cs: Union ve concat'le dizilerin do�rudan/sorgulu birle�imleri �rne�i.

using System;
using System.Linq; //Union ve Concat i�in
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
    class Bayii {
        public string BayiiNo {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro {get; set;}
    }
    class Sipari� {
        public string BayiiNo {get; set;}
        public decimal Tutar {get; set;}
    }
    class Union_Concat {
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasiye", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasiye", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasiye", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasiye", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            return �r�nListesi;
        }
        static List<M��teri> M��teriListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasiye", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasiye", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasiye", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasiye", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            List<M��teri> m��teriListesi = new List<M��teri>();
            m��teriListesi.Add (new M��teri {�irketAd� = "Abdulkerim Ltd", Adresi = "Rize", Sipari�ler = �r�nListesi, M��teriNo = 10});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ziyadede A�", Adresi = "Kayseri", Sipari�ler = �r�nListesi, M��teriNo = 4});
            m��teriListesi.Add (new M��teri {�irketAd� = "Camiba�� Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 25});
            m��teriListesi.Add (new M��teri {�irketAd� = "Billiruye A�", Adresi = "Zonguldak", Sipari�ler = �r�nListesi, M��teriNo = 93});
            m��teriListesi.Add (new M��teri {�irketAd� = "�emseddinpa�a A�", Adresi = "Kars", Sipari�ler = �r�nListesi, M��teriNo = 64});
            m��teriListesi.Add (new M��teri {�irketAd� = "Ke�i�ren Ltd", Adresi = "Ankara", Sipari�ler = �r�nListesi, M��teriNo = 164});
            return m��teriListesi;
        }
        static void Main() {
            Console.Write ("Linq-Union dizilerin yegane elemanlar�n�, Concat ise ard���k eklenimlerini birle�tirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Union sadece yegane adlar� birle�tirirken, concat hepsini birle�tirir:");
            string[] adlar1 = {"Fatma", "Bekir", "Han�m", "Memet"};
            string[] adlar2 = {"Hatice", "S�heyla", "Zeliha", "Nihat", "Song�l", "Nedim", "Sevim"};
            var union1 = adlar1.Union (adlar2).Union (adlar2); //Sadece yegane dizi elemanlar�n� birle�tirir
            var concat1 = adlar1.Concat (adlar2).Concat (adlar2); //�oklu elemanlar� da aynen birle�tiri
            Console.Write ("Adlar-->Union: "); foreach (String ad in union1) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("Adlar-->Concat: "); foreach (String ad in concat1) Console.Write (ad+" "); Console.WriteLine();
            int[] do�umlar1 = {1895, 1891, 1932, 1933};
            int[] do�umlar2 = {1951, 1953, 1955, 1957, 1959, 1961, 1963};
            var union2 = do�umlar1.Union (do�umlar2).Union (do�umlar2);
            var concat2 = do�umlar1.Concat (do�umlar2).Concat (do�umlar2);
            Console.Write ("Do�umlar-->Union: "); foreach (var y�l in union2) Console.Write (y�l+" "); Console.WriteLine();
            Console.Write ("Do�umlar-->Concat: "); foreach (var y�l in concat2) Console.Write (y�l+" "); Console.WriteLine();
            int[] boylar = {165, 185, 170, 167, 165, 168, 167, 171, 168, 169, 164};
            int[] kilolar = {55, 78, 60, 85, 105, 65, 80, 59, 62, 70, 62};
            var union3 = boylar.Union (kilolar);
            var concat3 = boylar.Concat (kilolar);
            Console.Write ("Boy+Kilo-->Union: "); foreach (var bk in union3) Console.Write (bk+" "); Console.WriteLine();
            Console.Write ("Boy+Kilo-->Concat: "); foreach (var bk in concat3) Console.Write (bk+" "); Console.WriteLine();

            Console.WriteLine ("\nAlt��ar �r�n ve firma adlar� ilkharflerinin yegane ve eklemeli d�k�mleri:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            List<M��teri> m��teriler = M��teriListesiniAl();
            var �r�nad�Sorgusu = from �r�n in �r�nler select �r�n.�r�nAd� [0];
            var �irketad�Sorgusu = from �irket in m��teriler select �irket.�irketAd� [0];
            var �r�n�irket�lkharfUnion = �r�nad�Sorgusu.Union (�irketad�Sorgusu);
            var �r�n�irket�lkharfConcat = �r�nad�Sorgusu.Concat (�irketad�Sorgusu);
            Console.Write ("�r�n-�irket ilkharf-->Union: "); foreach (var k in �r�n�irket�lkharfUnion) Console.Write (k+" "); Console.WriteLine();
            Console.Write ("�r�n-�irket ilkharf-->Concat: "); foreach (var k in �r�n�irket�lkharfConcat) Console.Write (k+" "); Console.WriteLine();

            Console.WriteLine ("\nUnion 5+7=12-10=2 �rt��eni d��larken Concat 12 ekler:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> ilkBe� = peygamberler.Take (5);
            IEnumerable<string> ��Atla = peygamberler.Skip (3);
            IEnumerable<string> concat4 = ilkBe�.Concat<string>(��Atla);
            IEnumerable<string> union4 = ilkBe�.Union<string>(��Atla);
            Console.Write ("Peygamberler: "); foreach (var pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.WriteLine ("T�m peygamber say�s�: " + peygamberler.Count());
            Console.WriteLine ("ilkBe� dizi say�s�: " + ilkBe�.Count());
            Console.WriteLine ("��Atla dizi say�s�: " + ��Atla.Count());
            Console.WriteLine ("Concat dizi say�s�: " + concat4.Count());
            Console.WriteLine ("Union dizi say�s�: " + union4.Count());
            IEnumerable<string> concat5 = peygamberler.Take (5).Concat (peygamberler.Skip (3));
            Console.Write ("�lkBe�+��Atla-->Concat ard���k: "); foreach (string pey in concat5) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<string> concat6 = new[]{peygamberler.Take (5), peygamberler.Skip (3)}.SelectMany (pyg => pyg);
            Console.Write ("�lkBe�+��Atla-->Concat new[]-selectLambda: "); foreach (string pey in concat6) Console.Write (pey+" "); Console.WriteLine();

            Console.WriteLine ("\nUluslararas� bayiler ve sipari�lerinin yegane-Union ve eklemeli-Concat listesi:");
            List<Sipari�> sipari�ler = new List<Sipari�> {
                new Sipari� {BayiiNo="King", Tutar=9000},
                new Sipari� {BayiiNo="Wolf", Tutar=1000},
                new Sipari� {BayiiNo="Queen", Tutar=10000},
                new Sipari� {BayiiNo="Lion", Tutar=1800},
                new Sipari� {BayiiNo="Diamond", Tutar=1100}
            };
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {BayiiNo="King", �ehir="London", �lke="UK", K�ta="Europe", Ciro=80000},
                new Bayii {BayiiNo="Queen", �ehir="Beijing", �lke="China", K�ta="Asia", Ciro=90000},
                new Bayii {BayiiNo="Lion", �ehir="�stanbul", �lke="Turkey", K�ta="Europe", Ciro=1240000},
                new Bayii {BayiiNo="Wolf", �ehir="Cairo", �lke="Eygpt", K�ta="Africa", Ciro=124000},
                new Bayii {BayiiNo="Parrot", �ehir="SaoPaola", �lke="Brazil", K�ta="South America", Ciro=40000},
                new Bayii {BayiiNo="Diamond", �ehir="Lima", �lke="Peru", K�ta="South America", Ciro=315000}
            };
            var bayinoSorgusu = from bayi in bayiler select bayi.BayiiNo;
            var sipari�noSorgusu = from sipari� in sipari�ler select sipari�.BayiiNo;
            var bayisipari�Union = sipari�noSorgusu.Union (bayinoSorgusu);
            var bayisipari�Concat = sipari�noSorgusu.Concat (bayinoSorgusu);
            Console.Write ("Bayii+Sipari�-->Union: "); foreach (var no in bayisipari�Union) Console.Write (no+" "); Console.WriteLine();
            Console.Write ("Bayii+Sipari�-->Concat: "); foreach (var no in bayisipari�Concat) Console.Write (no+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}