// j2sc#2202j.cs: Linq-->First/OrDefault(), Last/OrDefault() metotlar� �rne�i.

using System;
using System.Linq; //First(), Last() i�in
using System.Collections.Generic; //IEnumerable<>, List<> i�in i�in
namespace LinqMetot {
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
    class First_Last {
        static List<�r�n> �r�nListesiniAl() {
            List<�r�n> �r�nListesi = new List<�r�n>();
            �r�nListesi.Add (new �r�n {�r�nAd� = "Kalem", Katagori = "K�rtasiye", BirimFiyat = 43, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 12});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Defter", Katagori = "K�rtasiye", BirimFiyat = 452, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 23});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Silgi", Katagori = "K�rtasiye", BirimFiyat = 25, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 8});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Cetvel", Katagori = "K�rtasiye", BirimFiyat = 112, Sipari�Adedi = 1000, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 14});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 1235, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "�anta", Katagori = "Valiz", BirimFiyat = 3265, Sipari�Adedi = 120, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 123});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 2368, Sipari�Adedi = 200, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            �r�nListesi.Add (new �r�n {�r�nAd� = "Forma", Katagori = "Giysi", BirimFiyat = 3278, Sipari�Adedi = 85, Sipari�Tarihi = new DateTime (2024, 11, 06, 01, 34, 45), �r�nNo = 243});
            return �r�nListesi;
        }
        static void Main() {
            Console.Write ("'dizi.First()/Last()' mevcutsa ilk/son eleman�, namevcutsa hata d�nd�r�r. 'dizi.First/LastOrDefault()' namevcutsa 0/bo�/null d�nd�r�r, hata f�rlatmaz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Say�sal dizinin ilk, son, varsay�l� elemanlar�:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[10];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("T�m y�llar: "); foreach(var y in y�llar) Console.Write (y+" "); Console.WriteLine();
            Console.WriteLine ("y�llar.First() = {0}", y�llar.First());
            Console.WriteLine ("y�llar.Last() = {0}", y�llar.Last());
            Console.WriteLine ("y�llar.ElementAt (y�llar.Length/2) = {0}", y�llar.ElementAt (y�llar.Length/2));
            Console.WriteLine ("y�llar.FirstOrDefault (n => n % 2 == 0) = {0}", y�llar.FirstOrDefault (n => n % 2 == 0));
            Console.WriteLine ("y�llar.LastOrDefault (n => n % 2 == 1) = {0}", y�llar.LastOrDefault (n => n % 2 == 1));
            int[] y�llar2 = {};
            Console.WriteLine ("Bo� say�sal dizinin ilk eleman�: {0}", y�llar2.FirstOrDefault());
            Console.WriteLine ("Bo� say�sal dizinin son eleman�: {0}", y�llar2.LastOrDefault());

            Console.WriteLine ("\nPeygamberlerin ilkharfli ve s�ral� ilk/son elemanlar�:");
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.WriteLine ("'M' ile ba�layan ilk peygamber = {0}", peygamberler.First (p => p.StartsWith ("M")));
            Console.WriteLine ("'M' ile ba�layan son peygamber = {0}", peygamberler.Last (p => p.StartsWith ("M")));
            Console.WriteLine ("'J' ile ba�layan/varsay�l� ilk peygamber = [{0}]", peygamberler.FirstOrDefault (p => p.StartsWith ("J")));
            Console.WriteLine ("'J' ile ba�layan/varsay�l� son peygamber = [{0}]", peygamberler.LastOrDefault (p => p.StartsWith ("J")));
            Console.WriteLine ("Artan s�ral� ilk peygamber = {0}", peygamberler.OrderBy (p => p).First());
            Console.WriteLine ("Azalan s�ral� ilk peygamber = {0}", peygamberler.OrderByDescending (p => p).First());
            Console.WriteLine ("Artan s�ral� son peygamber = {0}", peygamberler.OrderBy (p => p).Last());
            Console.WriteLine ("Azalan s�ral� son peygamber = {0}", peygamberler.OrderByDescending (p => p).Last());

            Console.WriteLine ("\n�r�n s�n�f tipli listenin �art� sa�layan ilk/son eleman�:");
            List<�r�n> �r�nler = �r�nListesiniAl();
            �r�n �r�n = (from p in �r�nler where p.�r�nNo == 123 select p).First();
            Console.WriteLine ("�r�nNo=={0} olan ilk �r�n: {1}({2}) = {3:#,0.00} TL", 123, �r�n.Katagori, �r�n.�r�nAd�, �r�n.BirimFiyat);
            �r�n = (from p in �r�nler where p.�r�nNo == 123 select p).Last();
            Console.WriteLine ("�r�nNo=={0} olan son �r�n: {1}({2}) = {3:#,0.00} TL", 123, �r�n.Katagori, �r�n.�r�nAd�, �r�n.BirimFiyat);
            �r�n = �r�nler.FirstOrDefault (� => �.�r�nNo == 123);
            Console.WriteLine ("�r�n 123 mevcut mu?: {0}", �r�n != null?"EVET":"HAYIR");
            �r�n = �r�nler.LastOrDefault (� => �.�r�nNo == 2024);
            Console.WriteLine ("�r�n {0} mevcut mu?: {1}", 2024, �r�n != null?"EVET":"HAYIR");

            Console.WriteLine ("\nBayii s�n�f tipli listenin 'K�ta' �artl� ilk/son eleman�:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", �ehir="Tahran", �lke="�ran", K�ta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m}
            };
            var sorgu = from b in bayiler select new {b.K�ta, b.�lke, b.�ehir};
            Console.WriteLine ("{0}'da bayimiz var m�? {1}", "Afrika", sorgu.FirstOrDefault (b => b.K�ta == "Afrika")!=null?"VAR":"YOK");
            Console.WriteLine ("{0}'daki ilk bayii �ehri: {1}", "Avrupa", sorgu.FirstOrDefault (b => b.K�ta == "Avrupa").�ehir);
            Console.WriteLine ("{0}'daki son bayii �ehri: {1}", "Avrupa", sorgu.LastOrDefault (b => b.K�ta == "Avrupa").�ehir);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}