// j2sc#2202p.cs: ForEach, FindAll ve Enumerable.Range örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; // Enumerable.Range için
namespace LinqMetot {
    class Film {
        public string FilminAdý {get; set;}
        public int VizyonYýlý {get; set;}
        public string Baþrolde {get; set;}
        public override string ToString() {return string.Format ("FilminAdý={0}, VizyonYýlý={1}, Baþrolde={2}", FilminAdý, VizyonYýlý, Baþrolde);}
    }
    class FindAll_Range {
        static void Main() {
            Console.Write ("ForEach gibi 'using System.Linq' gerektirmeyen 'dizi.FindAll(þart)' þartý saðlayanlarý seçer. 'Enumerable.Range(x,y)' x'den itibaren y adet birartan sayýlar üretir. \nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm filimlerin ve þartý saðlayanlarýn dökümleri:");
            var filimler = new List<Film>{
                new Film {FilminAdý="Ýstanbul'da Macera", Baþrolde="Bruce Lee", VizyonYýlý=1975},
                new Film {FilminAdý="Malkoçoðlu", Baþrolde="Cüneyt Arkýn", VizyonYýlý=1968},
                new Film {FilminAdý="Psikopat", Baþrolde="Bruce Willis", VizyonYýlý=1995},
                new Film {FilminAdý="Tarkan", Baþrolde="Kartal Tibet", VizyonYýlý=1969},
                new Film {FilminAdý="Antalya'da Aþk", Baþrolde="Ediz Hun", VizyonYýlý=1965}
            };
            Action<Film> yaz = filim => Console.WriteLine (filim);
            Console.WriteLine ("-->Tüm filimler:");
            filimler.ForEach (yaz);
            Console.WriteLine ("-->Antika (<1970) filimler:");
            filimler.FindAll (film => film.VizyonYýlý < 1970).ForEach (yaz);
            Console.WriteLine ("-->Film adýyla artan sýralý:");
            filimler.Sort ((f1, f2) => f1.FilminAdý.CompareTo (f2.FilminAdý));
            filimler.ForEach (yaz);
            Console.WriteLine ("-->Vizyon yýlýyla azalan sýralý:");
            filimler.Sort ((f1, f2) => f2.VizyonYýlý.CompareTo (f1.VizyonYýlý));
            filimler.ForEach (yaz);

            Console.WriteLine ("\nRange sol'dan baþlar, sað'a deðin birer artar:");
            var sorgu1 = from sol in Enumerable.Range (1, 4) //Kapsam:[1,4] (son 4 dahil)
                from sað in Enumerable.Range (11, sol)
                select new {Sol = sol, Sað = sað};
            foreach (var çift in sorgu1) Console.WriteLine ("Sol={0}\tSað={1}", çift.Sol, çift.Sað);

            Console.WriteLine ("\nRange(1881,58) ile çeþitli sorgulu seçimler:");
            var kapsam1 = Enumerable.Range (1881, 58);
            Console.Write ("-->Range(1881,58): ");
            foreach (var yýl in kapsam1) Console.Write (yýl+" "); Console.WriteLine();
            kapsam1 = Enumerable.Range (1881, 58)
                .Where (y => y % 2 != 0) //Tek yýllar
                .Reverse(); //Sonuç tersten
            Console.Write ("-->Range(1881,58), Tek yýllar, tersten: ");
            foreach (var ty in kapsam1) Console.Write (ty+" "); Console.WriteLine();
            var kapsam2 = Enumerable.Range (-1938, 58)
                .Select (y => new {Orijinal = y, Karesi = y * y, Karekökü = Math.Sqrt (-y)})
                .OrderByDescending (y => y.Karesi)
                .ThenBy (y => y.Orijinal);
            Console.WriteLine ("-->Range(-1881,58), artan sýralý: ");
            foreach (var birim in kapsam2) Console.WriteLine (birim);
            var kapsam3 = Enumerable.Range (1881, 58)
                .Where (y => y % 2 == 0) //Çift yýllar
                .Reverse() //Tersle-->azalan
                .Select (y => new {Orijinal = y, Küpkök = Math.Pow (y, 1/3d), Pentakök = Math.Pow (y, 1/5d)});
            Console.WriteLine ("-->Range(1881,58), çift yýllar, ters: ");
            foreach (var birim in kapsam3) Console.WriteLine (birim);
            IEnumerable<int> yýllar = Enumerable.Range (1881, 58).Reverse();
            Console.Write ("-->Range(1881,58).Reverse(): ");
            foreach (var yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            var tekçift = from y in Enumerable.Range (1881, 58)
                select new {Yýl = y, TekÇift = y % 2 == 1 ? "TEK" : "ÇÝFT"};
            Console.Write ("-->Range(1881,58), TEK/ÇÝFT: ");
            foreach (var yýl in tekçift) Console.Write (yýl.Yýl+":"+yýl.TekÇift+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}