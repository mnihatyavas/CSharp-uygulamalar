// j2sc#2202p.cs: ForEach, FindAll ve Enumerable.Range �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Linq; // Enumerable.Range i�in
namespace LinqMetot {
    class Film {
        public string FilminAd� {get; set;}
        public int VizyonY�l� {get; set;}
        public string Ba�rolde {get; set;}
        public override string ToString() {return string.Format ("FilminAd�={0}, VizyonY�l�={1}, Ba�rolde={2}", FilminAd�, VizyonY�l�, Ba�rolde);}
    }
    class FindAll_Range {
        static void Main() {
            Console.Write ("ForEach gibi 'using System.Linq' gerektirmeyen 'dizi.FindAll(�art)' �art� sa�layanlar� se�er. 'Enumerable.Range(x,y)' x'den itibaren y adet birartan say�lar �retir. \nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�m filimlerin ve �art� sa�layanlar�n d�k�mleri:");
            var filimler = new List<Film>{
                new Film {FilminAd�="�stanbul'da Macera", Ba�rolde="Bruce Lee", VizyonY�l�=1975},
                new Film {FilminAd�="Malko�o�lu", Ba�rolde="C�neyt Ark�n", VizyonY�l�=1968},
                new Film {FilminAd�="Psikopat", Ba�rolde="Bruce Willis", VizyonY�l�=1995},
                new Film {FilminAd�="Tarkan", Ba�rolde="Kartal Tibet", VizyonY�l�=1969},
                new Film {FilminAd�="Antalya'da A�k", Ba�rolde="Ediz Hun", VizyonY�l�=1965}
            };
            Action<Film> yaz = filim => Console.WriteLine (filim);
            Console.WriteLine ("-->T�m filimler:");
            filimler.ForEach (yaz);
            Console.WriteLine ("-->Antika (<1970) filimler:");
            filimler.FindAll (film => film.VizyonY�l� < 1970).ForEach (yaz);
            Console.WriteLine ("-->Film ad�yla artan s�ral�:");
            filimler.Sort ((f1, f2) => f1.FilminAd�.CompareTo (f2.FilminAd�));
            filimler.ForEach (yaz);
            Console.WriteLine ("-->Vizyon y�l�yla azalan s�ral�:");
            filimler.Sort ((f1, f2) => f2.VizyonY�l�.CompareTo (f1.VizyonY�l�));
            filimler.ForEach (yaz);

            Console.WriteLine ("\nRange sol'dan ba�lar, sa�'a de�in birer artar:");
            var sorgu1 = from sol in Enumerable.Range (1, 4) //Kapsam:[1,4] (son 4 dahil)
                from sa� in Enumerable.Range (11, sol)
                select new {Sol = sol, Sa� = sa�};
            foreach (var �ift in sorgu1) Console.WriteLine ("Sol={0}\tSa�={1}", �ift.Sol, �ift.Sa�);

            Console.WriteLine ("\nRange(1881,58) ile �e�itli sorgulu se�imler:");
            var kapsam1 = Enumerable.Range (1881, 58);
            Console.Write ("-->Range(1881,58): ");
            foreach (var y�l in kapsam1) Console.Write (y�l+" "); Console.WriteLine();
            kapsam1 = Enumerable.Range (1881, 58)
                .Where (y => y % 2 != 0) //Tek y�llar
                .Reverse(); //Sonu� tersten
            Console.Write ("-->Range(1881,58), Tek y�llar, tersten: ");
            foreach (var ty in kapsam1) Console.Write (ty+" "); Console.WriteLine();
            var kapsam2 = Enumerable.Range (-1938, 58)
                .Select (y => new {Orijinal = y, Karesi = y * y, Karek�k� = Math.Sqrt (-y)})
                .OrderByDescending (y => y.Karesi)
                .ThenBy (y => y.Orijinal);
            Console.WriteLine ("-->Range(-1881,58), artan s�ral�: ");
            foreach (var birim in kapsam2) Console.WriteLine (birim);
            var kapsam3 = Enumerable.Range (1881, 58)
                .Where (y => y % 2 == 0) //�ift y�llar
                .Reverse() //Tersle-->azalan
                .Select (y => new {Orijinal = y, K�pk�k = Math.Pow (y, 1/3d), Pentak�k = Math.Pow (y, 1/5d)});
            Console.WriteLine ("-->Range(1881,58), �ift y�llar, ters: ");
            foreach (var birim in kapsam3) Console.WriteLine (birim);
            IEnumerable<int> y�llar = Enumerable.Range (1881, 58).Reverse();
            Console.Write ("-->Range(1881,58).Reverse(): ");
            foreach (var y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            var tek�ift = from y in Enumerable.Range (1881, 58)
                select new {Y�l = y, Tek�ift = y % 2 == 1 ? "TEK" : "��FT"};
            Console.Write ("-->Range(1881,58), TEK/��FT: ");
            foreach (var y�l in tek�ift) Console.Write (y�l.Y�l+":"+y�l.Tek�ift+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}