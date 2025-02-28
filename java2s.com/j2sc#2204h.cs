// j2sc#2204h.cs: Gruplama, 'group a into b' veya 'a.GroupBy/GroupJoin' �rne�i.

using System;
using System.Linq; //Select i�in
//using System.Collections; //ArrayList i�in
using System.Collections.Generic; //IEqualityComparer<> i�in
namespace Query_Sorgu {
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
    class Group_By_Join {
        public class K�yasc�: IEqualityComparer<string> {
            public bool Equals (string x, string y) {return dizgeyiAl (x) == dizgeyiAl (y);}
            public int GetHashCode (string ns) {return dizgeyiAl (ns).GetHashCode();}
            private string dizgeyiAl (string dizge) {
                char[] krk = dizge.ToCharArray();
                Array.Sort<char> (krk);
                return new string (krk);
            }
        }
        static List<M��teri> M��teriListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nNo = 1881, �r�nAd� = "Kalem", Katagori = "K�rtasite", BirimFiyat = 43, Sipari�Adedi = 1500, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1914, �r�nAd� = "Defter", Katagori = "K�rtasite", BirimFiyat = 452, Sipari�Adedi = 130, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1919, �r�nAd� = "Silgi", Katagori = "K�rtasite", BirimFiyat = 25, Sipari�Adedi = 680, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1920, �r�nAd� = "Cetvel", Katagori = "K�rtasite", BirimFiyat = 112, Sipari�Adedi = 700, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1923, �r�nAd� = "Kitap", Katagori = "K�rtasite", BirimFiyat = 257, Sipari�Adedi = 1600, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1930, �r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            �r�nListesi.Add (new �r�n {�r�nNo = 1938, �r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 290, Sipari�Tarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
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
            Console.Write ("'group by a into gr' yada 'a.GroupBy()' ayn� a verileri birle�ik grupland�r�r. 'a.GroupJoin(b)' ise 2 ayr� veriyi ortak anahtarla birle�tirip, grupland�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ar�iv tamsay� metot gruplar� ve grup i�i metotlar:");
            var sorgu1a = from m in typeof (int).GetMethods()
                select m.Name;
            Console.WriteLine ("-->T�m {0} adet (int)Metot adlar�: ", sorgu1a.Count());
            foreach(var m in sorgu1a) Console.WriteLine (m);
            var sorgu1b = from m in typeof(int).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key};
            Console.WriteLine ("-->T�m {0} adet (int)Metot gruplar�: ", sorgu1b.Count());
            foreach(var m in sorgu1b) Console.WriteLine (m);
            var sorgu1c = from m in typeof(int).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key, Metotlar = gr};
            Console.WriteLine ("-->T�m {0} adet (int)Metot gruplar�: ", sorgu1c.Count());
            foreach(var g in sorgu1c) {
                Console.WriteLine ("\t{0} adl� metot grubu", g.Ad);
                foreach (var m in g.Metotlar) Console.WriteLine (m);
            }
            var sorgu1d = from m in typeof (double).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key, Adet = gr.Count()};
            Console.WriteLine ("-->T�m {0} adet (double)Metot adlar�: ", sorgu1d.Count());
            foreach(var m in sorgu1d) Console.WriteLine (m);


            Console.WriteLine ("\nPeygamberlerin uzunluk gruplar� ve grup i�i peygamberler:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Zerd��t", "Buda", "Brahman", "Konfi�yus"};
            var sorgu2a = from p in peygamberler
                orderby p ascending
                group p by p.Length into uzgr
                orderby uzgr.Key descending
                select new {Uzunluk = uzgr.Key, Peygamberler = uzgr};
            Console.WriteLine ("-->T�m {0} adet azalan uzunluk gruplar�: ", sorgu2a.Count());
            foreach (var g in sorgu2a) {
                Console.WriteLine ("Grup i�i artan peygamberlerin uzunlu�u: {0}", g.Uzunluk);
                foreach (string p in g.Peygamberler)
                Console.WriteLine ("  " + p);
            }
            var sorgu2b = from p in peygamberler
                orderby p descending
                group p by p.Length into uzgr
                orderby uzgr.Key ascending
                select new {Uzunluk = uzgr.Key, Peygamberler = uzgr};
            Console.WriteLine ("-->T�m {0} adet artan uzunluk gruplar�: ", sorgu2b.Count());
            foreach (var g in sorgu2b) {
                Console.WriteLine ("Grup i�i azalan peygamberlerin uzunlu�u: {0}", g.Uzunluk);
                foreach (string p in g.Peygamberler)
                Console.WriteLine ("  " + p);
            }
            var sorgu2c = from p in peygamberler
                orderby p descending
                group p by p.Substring (0, 1) into gr
                orderby gr.Key
                select gr;
            Console.WriteLine ("-->T�m {0} adet artan ilkharf gruplar� ve azalan peygamberler: ", sorgu2c.Count());
            foreach (var g in sorgu2c) {
                Console.WriteLine ("�lkharf: " + g.Key);
                foreach (String p in g) Console.WriteLine ("\t" + p);
            }
            var sorgu2d = from p in peygamberler
                orderby p ascending
                group p by p.Substring (0, 1) into gr
                orderby gr.Key descending
                select gr;
            Console.WriteLine ("-->T�m {0} adet azalan ilkharf gruplar� ve artan peygamberler: ", sorgu2d.Count());
            foreach (var g in sorgu2d) {
                Console.WriteLine ("�lkharf: " + g.Key);
                foreach (String p in g) Console.WriteLine ("\t" + p);
            }
            string[] anagramlar = {"  kelam ", "yava�", "from ", " salt", " earn ", "kafana  ", " last ", "sava� ", "kalem ", " anafak", " near ", " form ", " nafaka   ", " anakaf  "};
            var sorgu2e = anagramlar.GroupBy (//Ayn� harflerle farkl� kelime dizilimleri
                p => p.Trim(),
                p => p.ToUpper(),
                new K�yasc�()).Select (a=>a);
            Console.Write ("-->T�m {0} adet kelimelerden {1} anagramik farkl�lar�: ", anagramlar.Length, sorgu2d.Count());
            foreach (var a in sorgu2e) Console.Write (a.Key+" "); Console.WriteLine();

            Console.WriteLine ("\n�irketler ve sipari� detaylar� sorgusu:");
            List<M��teri> m��teriler = M��teriListesiniAl();
            var sorgu3a = 
                from m in m��teriler
                select new {
                    m.�irketAd�,
                    Y�lGruplar� =
                        from s in m.Sipari�ler
                        group s by s.Sipari�Tarihi.Year into yg
                        select new {
                            Y�l = yg.Key,
                            AyGruplar� =
                                from s in yg
                                group s by s.Sipari�Tarihi.Month into mg
                                select new {Ay = mg.Key, Sipari�ler = mg}}};
            Console.WriteLine ("-->T�m {0} adet �irket gruplar� ve sipari� detaylar�: ", sorgu3a.Count());
            foreach (var � in sorgu3a) {
                Console.WriteLine ("  �irket ad�: " + �.�irketAd�);
                foreach (var y in �.Y�lGruplar�) {
                    Console.Write ("    Sipari� tarihi: " + y.Y�l);
                    foreach (var a in y.AyGruplar�) {
                        Console.Write ("/"+a.Ay+"\n    Sipari�ler ad ve adetleri: ");
                        foreach (var s in a.Sipari�ler) Console.Write (s.�r�nAd�+":"+s.Sipari�Adedi+" "); Console.WriteLine();}}};
            List<�r�n> �r�nler = �r�nListesiniAl();
            var sorgu3b =
                from � in �r�nler
                group � by �.Katagori into g
                select new {Katagori = g.Key, �r�nler = g};
            Console.WriteLine ("-->T�m {0} adet �r�n katagori grup ve detaylar�: ", sorgu3b.Count());
            foreach (var k in sorgu3b) {
                Console.WriteLine (k.Katagori);
                foreach (var � in k.�r�nler) Console.WriteLine ("  �r�n ad�: {0}, Birim fiyat�: {1:#,0} TL", �.�r�nAd�, �.BirimFiyat);
            }

            Console.WriteLine ("\nEnumerable.Range(1881,58) % 5 ve 10 kalanl� y�l gruplamas�:");
            var sorgu4a = from y�l in Enumerable.Range (1881, 58)
                group y�l by y�l % 5 into g
                select new {Kalan = g.Key, Y�llar = g};
            Console.WriteLine ("-->T�m {0} adet [1881:1938]%5 kalanl� gruplama: ", sorgu4a.Count());
            foreach (var g in sorgu4a) {
                Console.Write ("  Y�l%5={0} y�llar: ", g.Kalan);
                foreach (var y in g.Y�llar) Console.Write (y+" "); Console.WriteLine();
            }
            var sorgu4b = from y�l in Enumerable.Range (1881, 58)
                group y�l by y�l % 10 into g
                select new {Kalan = g.Key, Y�llar = g};
            Console.WriteLine ("-->T�m {0} adet [1881:1938]%5 kalanl� gruplama: ", sorgu4b.Count());
            foreach (var g in sorgu4b) {
                Console.Write ("\tY�l%10 kalan� = {0} olan y�llar: ", g.Kalan);
                foreach (var y in g.Y�llar) Console.Write (y+" "); Console.WriteLine();
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}