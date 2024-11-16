// j2sc#2201c.cs: Anonim Action, Predicate, delegeli lambda, Select �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; //Select i�in
namespace Anonimler {
    class ���i {
        public string Ad {get; set;}
        public decimal Maa� {get; set;}
    }
    class Departman {
        public string Ad {get; set;}
        List<���i> i��iler = new List<���i>();
        public IList<���i> ���iler {get {return i��iler;}}
    }
    class �irket {
        public string Ad {get; set;}
        List<Departman> bran�lar = new List<Departman>();
        public IList<Departman> Bran�lar {get {return bran�lar;}}
    }
    class Delege {
        static void Main() {
            Console.Write ("Select-Sum istenen grubun toplam�n�, OrderByDescending/Ascending istenen alanla azalan/artan s�ralama yapar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim Action delegelenmeyle say�lar�n karek�klerini sunma:");
            var r=new Random(); int i, ts;
            Action<int> karek�k = delegate (int say�) {Console.WriteLine ("Karek�k({0,10:#,0}) = {1,10:#,0.0000}", say�, Math.Sqrt (say�));};
            for(i=0;i<5;i++) {ts=r.Next(2,20241024); karek�k (ts);}

            Console.WriteLine ("\nAnonim Predicate delegelenmeyle say�lar�n tek/�ift kontrolu:");
            Predicate<int> �iftMi = delegate (int x) {return x % 2 == 0;};
            for(i=0;i<5;i++) {ts=r.Next(1881,1939); Console.WriteLine ("{0} say�s� �ift mi? {1}", ts, �iftMi (ts)?"Evet":"Hay�r");}

            Console.WriteLine ("\nListeye ekli adlar�n delegeli Find ile bulunmas�:");
            string[] adlar=new string[]{"Fatma", "Bekir", "Han�m", "Memet", "Hatice"};
            List<string> adListesi = new List<string>();
            for(i=0;i<adlar.Length;i++) adListesi.Add (adlar [i]);
            string adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[2]);});
            string ad="Han�m"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hay�r");
            adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[3]);});
            ad="Mehmet"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hay�r");
            adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[3]);});
            ad="Memet"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hay�r");

            Console.WriteLine ("\nAnonim var ki�iler dizisi'nin sunumu ve e�itlik kontrolu:");
            var ki�iler = new[] {
                new {Ad� = "M.Nihat", Soyad�= "Yava�", Ya�� = 2024-1957},
                new {Ad� = "Sevim", Soyad�= "Yava�", Ya�� = 2024-1963},
                new {Ad� = "Memet", Soyad�= "Yava�", Ya�� = 2024-1934}
            };
            for(i=0;i<ki�iler.Length;i++) Console.WriteLine (ki�iler [i]);
            for(i=0;i<ki�iler.Length;i++) Console.WriteLine ("Bellek adresi: " + ki�iler [i].GetHashCode());
            Console.WriteLine ("1.ki�i.E�it(2.ki�i) mi? " +ki�iler [0].Equals (ki�iler [1]));
            Console.WriteLine ("1.ki�i.E�it(1.ki�i) mi? " +ki�iler [0].Equals (ki�iler [0]));
            Console.WriteLine ("3.ki�i == 2.ki�i mi? " +(ki�iler [2] == ki�iler [1]));
            Console.WriteLine ("3.ki�i == 3.ki�i mi? " +(ki�iler [2] == ki�iler [2]));

            Console.WriteLine ("\n�irket bran� eleman maa�lar� ve her bran� toplam�:");
            var �irket = new �irket {
                Ad = "BEB�M A�",
                Bran�lar = {
                    new Departman { 
                        Ad = "AR-GE", 
                        ���iler = {
                            new ���i {Ad = "Nihat", Maa� = 14581.67m},
                            new ���i {Ad = "Veysel", Maa� = 45368.43m},
                            new ���i {Ad = "Orkun", Maa� = 150643.89m}
                        }
                    },
                    new Departman { 
                        Ad = "E�itim", 
                        ���iler = {
                            new ���i {Ad = "Dilek", Maa� = 212356.32m},
                            new ���i {Ad = "Neslihan", Maa� = 120683.15m}
                        }
                    }
                }
            };
            var sorgu1 = �irket.Bran�lar
                .Select (dal => new {dal.Ad, Toplam_Maliyet = dal.���iler.Sum (i��i => i��i.Maa�)})
                .OrderByDescending (dalMaliyet => dalMaliyet.Toplam_Maliyet);
            foreach (var birim in sorgu1) Console.WriteLine (birim);
            foreach (var birim in �irket.Bran�lar) {
                Console.WriteLine ("-->"+birim.Ad);
                for(i=0;i<birim.���iler.Count;i++) Console.WriteLine ("{0}: {1:#,0.00} TL", birim.���iler[i].Ad, birim.���iler[i].Maa�);
            }

            Console.WriteLine ("\nAnonim kitaplar dizisinin varsay�l� ve bilgi-alanl� sunumu:");
            var kitaplar = new []{new {YazarAd�="W.Smith", KitapAd� = "Y�rt�c� Ku�", Yay�nY�l� = "1984"},
                new {YazarAd�="L.Kindross", KitapAd� = "Atat�rk", Yay�nY�l� = "1940"},
                new {YazarAd�="A.Hitler", KitapAd� = "Kavgam", Yay�nY�l� = "1935"},
                new {YazarAd�="GD.Villiers", KitapAd� = "SAS �stanbul'da", Yay�nY�l� = "2001"},
                new {YazarAd�="C.Dickens", KitapAd� = "Antikac� D�kkan�", Yay�nY�l� = "1965"}

            };
            for(i=0;i<kitaplar.Length;i++) Console.WriteLine (kitaplar [i]);
            foreach(var kitap in kitaplar) Console.WriteLine ("-->Yazar ad�: {0,-12}Kitap ad�: {1,-17}Yay�n y�l�:{2,5}", kitap.YazarAd�, kitap.KitapAd�, kitap.Yay�nY�l�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}