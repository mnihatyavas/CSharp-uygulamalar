// jtpc#2302b.cs: Statik uzant� tiplemeli metodun �a�r�lmas� �rne�i.

using System;
namespace Yeni�zellikler {
    public static class DizgeYard�mc� {
        public static string B�y�kHarfle (this string dizge) {return dizge.ToUpper();}
    }
    public static class ��renciYard�mc� {
        public static string B�y�kHarfleAl (this ��renci ��renci) {return ��renci.ad.ToUpper();}
    }  
    public class ��renci {
        public string ad = "M.Nihat Yava�";
        public string Ad�Al() {return this.ad;}
    }
    class Uzant�Metodu {
        static string d = "javatpoint";
        static void Main() {
            Console.Write ("Uzant� metodu parametre listesinin ilkinde s�n�f ad�na atfen 'this' anahtarkelimesi kullanmal�, statik olmal� ve tipleme metodu olarak �a�r�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string diz = d.B�y�kHarfle(); //Statik uzant� metod tiplemesi
            Console.WriteLine ("K���kharfli [{0}]'in b�y�kharflisi: [{1}]", d, diz);

            ��renci ��r = new ��renci();
            Console.WriteLine ("K���kharfli [{0}]'in b�y�kharflisi: [{1}]", ��r.Ad�Al(), ��r.B�y�kHarfleAl());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}