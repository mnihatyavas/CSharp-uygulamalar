// j2sc#2204d.cs: Artan/azalan ikili s�ralamada OrderBy/Descending().ThenBy/Descending() �rne�i.

using System;
using System.Linq; //OrderBy i�in
using System.Collections.Generic; //IComparer<> i�in
namespace Query_Sorgu {
    public class S�n�fA: IComparer<string> {public int Compare (string x, string y) {return string.Compare (x, y, true);}} //true: caseinsensitive
    class Personel {
        public string �sim {get; set;}
        public decimal Maa� {get; set;}
    }
    class Departman {
        public string �sim {get; set;}
        List<Personel> elemanlar = new List<Personel>();
        public IList<Personel> Elemanlar {get {return elemanlar;}}
    }
    class �irket {
        public string �sim {get; set;}
        List<Departman> departmanlar = new List<Departman>();
        public IList<Departman> Departmanlar {get {return departmanlar;}}
    }
    class OrderBy_ThenBy {
        static void Main() {
            Console.Write ("Artan/azalan ikili s�ralama i�in 'sorgu.OrderBy/Descending().ThenBy/Descending()' kullan�lmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin �e�itli kriterlerle artan/azalan s�ralanmas�:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Zerd��t", "Buda", "Brahman", "Konfi�yus"};
            var sorgu1a = from p in peygamberler
                orderby p
                select p;
            Console.Write ("-->T�m {0} adet artan s�ral� peygamberler: ", sorgu1a.Count());
            foreach (var p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            var sorgu1b = from p in peygamberler
                orderby p.Length descending
                select p;
            Console.Write ("-->T�m {0} adet azalan uzunluklu peygamberler: ", sorgu1b.Count());
            foreach (var p in sorgu1b) Console.Write (p+" "); Console.WriteLine();
            string[] peygamberler2=new string [peygamberler.Length];
            int i; for(i=0;i<peygamberler.Length;i++) {if(i%2==0) peygamberler2 [i]=peygamberler [i]; else peygamberler2 [i]=peygamberler [i].ToLower();}
            var sorgu1c = peygamberler2.OrderBy (p => p, new S�n�fA());
            Console.Write ("-->T�m {0} adet artan (harfduyars�z) s�ral� peygamberler: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1d = peygamberler.OrderByDescending (p => p);
            Console.Write ("-->T�m {0} adet azalan s�ral� peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            var sorgu1e = peygamberler2.OrderBy (p => p.Length)
                .ThenByDescending (p => p, new S�n�fA());
            Console.Write ("-->T�m {0} adet artan uzunluk ve harfduyars�z azalan s�ral� peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1f = peygamberler.OrderByDescending (p => p.Length).ThenBy (p => p);
            Console.Write ("-->T�m {0} adet azalan uzunluk ve artan s�ral� peygamberler: ", sorgu1f.Count());
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            var sorgu1g = peygamberler2.OrderBy (p => p.Length).ThenByDescending (p => p.Substring (0, 1));
            Console.Write ("-->T�m {0} adet artan uzunluk ve harfduyarl� azalan s�ral� peygamberler: ", sorgu1g.Count());
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1h = peygamberler.OrderByDescending (p => p.Length).ThenByDescending (p => p);
            Console.Write ("-->T�m {0} adet azalan uzunluk ve azalan s�ral� peygamberler: ", sorgu1h.Count());
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\n�irket departman personel toplam gider sorgusu:");
            var �irket = new �irket {
                �sim = "Fadik A.�.",
                Departmanlar = {
                    new Departman { 
                        �sim = "�malat", 
                        Elemanlar = {
                            new Personel {�sim = "Bekir Yava�", Maa� = 25743.54m},
                            new Personel {�sim = "Han�m Yava�", Maa� = 25876.450m},
                            new Personel {�sim = "S�heyla �zbay", Maa� = 28760.12m},
                            new Personel {�sim = "Zeliha Candan", Maa� = 28562.23m},
                            new Personel {�sim = "M.Nihat Yava�", Maa� = 15683.13m},
                            new Personel {�sim = "Sevim Yava�", Maa� = 32451.28m}
                        }
                    },
                    new Departman { 
                        �sim = "Pazarlama", 
                        Elemanlar = {
                            new Personel {�sim = "Fatma Yava�", Maa� = 67542.87m},
                            new Personel {�sim = "Memet Yava�", Maa� = 65472.87m},
                            new Personel {�sim = "Hatice Ka�ar", Maa� = 63761.87m}
                        }
                    },
                    new Departman { 
                        �sim = "Muhasebe", 
                        Elemanlar = {
                            new Personel {�sim = "M.Nedim Yava�", Maa� = 61342.89m},
                            new Personel {�sim = "Song�l G�kyi�it", Maa� = 57637.34m}
                        }
                    }
                }
            };
            var sorgu2a = �irket.Departmanlar
                .Select (d => new {d.�sim, Masraf = d.Elemanlar.Sum (p => p.Maa�)})
                .OrderByDescending (dm => dm.Masraf);
            Console.WriteLine ("-->{0} adet azalan s�ral� ayl�k departman toplam eleman masraflar�:", sorgu2a.Count());
            foreach (var d in sorgu2a) Console.WriteLine (d);
            Console.WriteLine ("-->{0} adet departman personelleri listesi:", sorgu2a.Count());
            foreach (var birim in �irket.Departmanlar) {
                Console.WriteLine ("-->"+birim.�sim);
                for(i=0;i<birim.Elemanlar.Count();i++) Console.WriteLine ("{0}: {1:#,0.00} TL", birim.Elemanlar [i].�sim, birim.Elemanlar [i].Maa�);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}