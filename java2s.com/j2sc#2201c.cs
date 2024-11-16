// j2sc#2201c.cs: Anonim Action, Predicate, delegeli lambda, Select örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; //Select için
namespace Anonimler {
    class Ýþçi {
        public string Ad {get; set;}
        public decimal Maaþ {get; set;}
    }
    class Departman {
        public string Ad {get; set;}
        List<Ýþçi> iþçiler = new List<Ýþçi>();
        public IList<Ýþçi> Ýþçiler {get {return iþçiler;}}
    }
    class Þirket {
        public string Ad {get; set;}
        List<Departman> branþlar = new List<Departman>();
        public IList<Departman> Branþlar {get {return branþlar;}}
    }
    class Delege {
        static void Main() {
            Console.Write ("Select-Sum istenen grubun toplamýný, OrderByDescending/Ascending istenen alanla azalan/artan sýralama yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim Action delegelenmeyle sayýlarýn kareköklerini sunma:");
            var r=new Random(); int i, ts;
            Action<int> karekök = delegate (int sayý) {Console.WriteLine ("Karekök({0,10:#,0}) = {1,10:#,0.0000}", sayý, Math.Sqrt (sayý));};
            for(i=0;i<5;i++) {ts=r.Next(2,20241024); karekök (ts);}

            Console.WriteLine ("\nAnonim Predicate delegelenmeyle sayýlarýn tek/çift kontrolu:");
            Predicate<int> çiftMi = delegate (int x) {return x % 2 == 0;};
            for(i=0;i<5;i++) {ts=r.Next(1881,1939); Console.WriteLine ("{0} sayýsý çift mi? {1}", ts, çiftMi (ts)?"Evet":"Hayýr");}

            Console.WriteLine ("\nListeye ekli adlarýn delegeli Find ile bulunmasý:");
            string[] adlar=new string[]{"Fatma", "Bekir", "Haným", "Memet", "Hatice"};
            List<string> adListesi = new List<string>();
            for(i=0;i<adlar.Length;i++) adListesi.Add (adlar [i]);
            string adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[2]);});
            string ad="Haným"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hayýr");
            adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[3]);});
            ad="Mehmet"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hayýr");
            adBul = adListesi.Find (delegate (string a) {return a.Equals (adlar[3]);});
            ad="Memet"; Console.WriteLine ("'{0}' listede mevcut mu? {1}", ad, adBul==ad?"Evet":"Hayýr");

            Console.WriteLine ("\nAnonim var kiþiler dizisi'nin sunumu ve eþitlik kontrolu:");
            var kiþiler = new[] {
                new {Adý = "M.Nihat", Soyadý= "Yavaþ", Yaþý = 2024-1957},
                new {Adý = "Sevim", Soyadý= "Yavaþ", Yaþý = 2024-1963},
                new {Adý = "Memet", Soyadý= "Yavaþ", Yaþý = 2024-1934}
            };
            for(i=0;i<kiþiler.Length;i++) Console.WriteLine (kiþiler [i]);
            for(i=0;i<kiþiler.Length;i++) Console.WriteLine ("Bellek adresi: " + kiþiler [i].GetHashCode());
            Console.WriteLine ("1.kiþi.Eþit(2.kiþi) mi? " +kiþiler [0].Equals (kiþiler [1]));
            Console.WriteLine ("1.kiþi.Eþit(1.kiþi) mi? " +kiþiler [0].Equals (kiþiler [0]));
            Console.WriteLine ("3.kiþi == 2.kiþi mi? " +(kiþiler [2] == kiþiler [1]));
            Console.WriteLine ("3.kiþi == 3.kiþi mi? " +(kiþiler [2] == kiþiler [2]));

            Console.WriteLine ("\nÞirket branþ eleman maaþlarý ve her branþ toplamý:");
            var þirket = new Þirket {
                Ad = "BEBÝM AÞ",
                Branþlar = {
                    new Departman { 
                        Ad = "AR-GE", 
                        Ýþçiler = {
                            new Ýþçi {Ad = "Nihat", Maaþ = 14581.67m},
                            new Ýþçi {Ad = "Veysel", Maaþ = 45368.43m},
                            new Ýþçi {Ad = "Orkun", Maaþ = 150643.89m}
                        }
                    },
                    new Departman { 
                        Ad = "Eðitim", 
                        Ýþçiler = {
                            new Ýþçi {Ad = "Dilek", Maaþ = 212356.32m},
                            new Ýþçi {Ad = "Neslihan", Maaþ = 120683.15m}
                        }
                    }
                }
            };
            var sorgu1 = þirket.Branþlar
                .Select (dal => new {dal.Ad, Toplam_Maliyet = dal.Ýþçiler.Sum (iþçi => iþçi.Maaþ)})
                .OrderByDescending (dalMaliyet => dalMaliyet.Toplam_Maliyet);
            foreach (var birim in sorgu1) Console.WriteLine (birim);
            foreach (var birim in þirket.Branþlar) {
                Console.WriteLine ("-->"+birim.Ad);
                for(i=0;i<birim.Ýþçiler.Count;i++) Console.WriteLine ("{0}: {1:#,0.00} TL", birim.Ýþçiler[i].Ad, birim.Ýþçiler[i].Maaþ);
            }

            Console.WriteLine ("\nAnonim kitaplar dizisinin varsayýlý ve bilgi-alanlý sunumu:");
            var kitaplar = new []{new {YazarAdý="W.Smith", KitapAdý = "Yýrtýcý Kuþ", YayýnYýlý = "1984"},
                new {YazarAdý="L.Kindross", KitapAdý = "Atatürk", YayýnYýlý = "1940"},
                new {YazarAdý="A.Hitler", KitapAdý = "Kavgam", YayýnYýlý = "1935"},
                new {YazarAdý="GD.Villiers", KitapAdý = "SAS Ýstanbul'da", YayýnYýlý = "2001"},
                new {YazarAdý="C.Dickens", KitapAdý = "Antikacý Dükkaný", YayýnYýlý = "1965"}

            };
            for(i=0;i<kitaplar.Length;i++) Console.WriteLine (kitaplar [i]);
            foreach(var kitap in kitaplar) Console.WriteLine ("-->Yazar adý: {0,-12}Kitap adý: {1,-17}Yayýn yýlý:{2,5}", kitap.YazarAdý, kitap.KitapAdý, kitap.YayýnYýlý);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}