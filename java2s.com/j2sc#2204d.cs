// j2sc#2204d.cs: Artan/azalan ikili sýralamada OrderBy/Descending().ThenBy/Descending() örneði.

using System;
using System.Linq; //OrderBy için
using System.Collections.Generic; //IComparer<> için
namespace Query_Sorgu {
    public class SýnýfA: IComparer<string> {public int Compare (string x, string y) {return string.Compare (x, y, true);}} //true: caseinsensitive
    class Personel {
        public string Ýsim {get; set;}
        public decimal Maaþ {get; set;}
    }
    class Departman {
        public string Ýsim {get; set;}
        List<Personel> elemanlar = new List<Personel>();
        public IList<Personel> Elemanlar {get {return elemanlar;}}
    }
    class Þirket {
        public string Ýsim {get; set;}
        List<Departman> departmanlar = new List<Departman>();
        public IList<Departman> Departmanlar {get {return departmanlar;}}
    }
    class OrderBy_ThenBy {
        static void Main() {
            Console.Write ("Artan/azalan ikili sýralama için 'sorgu.OrderBy/Descending().ThenBy/Descending()' kullanýlmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin çeþitli kriterlerle artan/azalan sýralanmasý:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Zerdüþt", "Buda", "Brahman", "Konfiçyus"};
            var sorgu1a = from p in peygamberler
                orderby p
                select p;
            Console.Write ("-->Tüm {0} adet artan sýralý peygamberler: ", sorgu1a.Count());
            foreach (var p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            var sorgu1b = from p in peygamberler
                orderby p.Length descending
                select p;
            Console.Write ("-->Tüm {0} adet azalan uzunluklu peygamberler: ", sorgu1b.Count());
            foreach (var p in sorgu1b) Console.Write (p+" "); Console.WriteLine();
            string[] peygamberler2=new string [peygamberler.Length];
            int i; for(i=0;i<peygamberler.Length;i++) {if(i%2==0) peygamberler2 [i]=peygamberler [i]; else peygamberler2 [i]=peygamberler [i].ToLower();}
            var sorgu1c = peygamberler2.OrderBy (p => p, new SýnýfA());
            Console.Write ("-->Tüm {0} adet artan (harfduyarsýz) sýralý peygamberler: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1d = peygamberler.OrderByDescending (p => p);
            Console.Write ("-->Tüm {0} adet azalan sýralý peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            var sorgu1e = peygamberler2.OrderBy (p => p.Length)
                .ThenByDescending (p => p, new SýnýfA());
            Console.Write ("-->Tüm {0} adet artan uzunluk ve harfduyarsýz azalan sýralý peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1f = peygamberler.OrderByDescending (p => p.Length).ThenBy (p => p);
            Console.Write ("-->Tüm {0} adet azalan uzunluk ve artan sýralý peygamberler: ", sorgu1f.Count());
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            var sorgu1g = peygamberler2.OrderBy (p => p.Length).ThenByDescending (p => p.Substring (0, 1));
            Console.Write ("-->Tüm {0} adet artan uzunluk ve harfduyarlý azalan sýralý peygamberler: ", sorgu1g.Count());
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1h = peygamberler.OrderByDescending (p => p.Length).ThenByDescending (p => p);
            Console.Write ("-->Tüm {0} adet azalan uzunluk ve azalan sýralý peygamberler: ", sorgu1h.Count());
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nÞirket departman personel toplam gider sorgusu:");
            var þirket = new Þirket {
                Ýsim = "Fadik A.Þ.",
                Departmanlar = {
                    new Departman { 
                        Ýsim = "Ýmalat", 
                        Elemanlar = {
                            new Personel {Ýsim = "Bekir Yavaþ", Maaþ = 25743.54m},
                            new Personel {Ýsim = "Haným Yavaþ", Maaþ = 25876.450m},
                            new Personel {Ýsim = "Süheyla Özbay", Maaþ = 28760.12m},
                            new Personel {Ýsim = "Zeliha Candan", Maaþ = 28562.23m},
                            new Personel {Ýsim = "M.Nihat Yavaþ", Maaþ = 15683.13m},
                            new Personel {Ýsim = "Sevim Yavaþ", Maaþ = 32451.28m}
                        }
                    },
                    new Departman { 
                        Ýsim = "Pazarlama", 
                        Elemanlar = {
                            new Personel {Ýsim = "Fatma Yavaþ", Maaþ = 67542.87m},
                            new Personel {Ýsim = "Memet Yavaþ", Maaþ = 65472.87m},
                            new Personel {Ýsim = "Hatice Kaçar", Maaþ = 63761.87m}
                        }
                    },
                    new Departman { 
                        Ýsim = "Muhasebe", 
                        Elemanlar = {
                            new Personel {Ýsim = "M.Nedim Yavaþ", Maaþ = 61342.89m},
                            new Personel {Ýsim = "Songül Gökyiðit", Maaþ = 57637.34m}
                        }
                    }
                }
            };
            var sorgu2a = þirket.Departmanlar
                .Select (d => new {d.Ýsim, Masraf = d.Elemanlar.Sum (p => p.Maaþ)})
                .OrderByDescending (dm => dm.Masraf);
            Console.WriteLine ("-->{0} adet azalan sýralý aylýk departman toplam eleman masraflarý:", sorgu2a.Count());
            foreach (var d in sorgu2a) Console.WriteLine (d);
            Console.WriteLine ("-->{0} adet departman personelleri listesi:", sorgu2a.Count());
            foreach (var birim in þirket.Departmanlar) {
                Console.WriteLine ("-->"+birim.Ýsim);
                for(i=0;i<birim.Elemanlar.Count();i++) Console.WriteLine ("{0}: {1:#,0.00} TL", birim.Elemanlar [i].Ýsim, birim.Elemanlar [i].Maaþ);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}