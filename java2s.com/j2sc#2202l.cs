// j2sc#2202l.cs: Min()/Max() ile dizi elemanlar�n�n enk�����/enb�y��� �rne�i.

using System;
using System.Linq; //Min() ve Max i�in
using System.Collections; //ArrayList i�in
using System.Collections.Generic; //List<> i�in
namespace LinqMetot {
    public class ���i {
        public int y�l;
        public string ad;
        public string soyad;
        public static ArrayList ���iListesiniAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new ���i {y�l = 1891, ad = "Fatma", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1899, ad = "Bekir", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1931, ad = "Han�m", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1934, ad = "Memet", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1951, ad = "Hatice", soyad = "Ka�ar"});
            liste.Add (new ���i {y�l = 1953, ad = "S�heyla", soyad = "�zbay"});
            liste.Add (new ���i {y�l = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new ���i {y�l = 1957, ad = "M.Nihat", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1959, ad = "Song�l", soyad = "G�kyi�it"});
            liste.Add (new ���i {y�l = 1961, ad = "M.Nedim", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1963, ad = "Sevim", soyad = "Yava�"});
            return (liste);
        }
        public static ���i[] ListeyiAl() {return ((���i[])���iListesiniAl().ToArray (typeof(���i)));}
    }
    class Bayii {
        public string No {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro;
    }
    class Maa� {
        int _no, _y�l;
        double _maa�;
        public int No {get {return _no;} set {_no = value;}}
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
        public double Maa�� {get {return _maa�;} set {_maa� = value;}}
    }
    class ���i2 {
        int _no, _bran�;
        string _soyad, _ad;
        public int No {get {return _no;} set {_no = value;}}
        public int Bran�� {get {return _bran�;} set {_bran� = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    class Max_Min {
        static void Main() {
            Console.Write ("'dizi.Min()/Max()' dizinin enk���k/enb�y�k, 'diziMin(e=>e.Length)' dizgesel dizinin enk�sa uzunluktaki eleman�n�, 'liste.Max(a=>a.Maa�)' liste kayd� maa� alan�n�n enb�y���n� d�nd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Say�sal ve dizgesel dizilerin enk���k/enb�y�k elemanlar�:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[10];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("-->T�m rasgele [1881,1938] y�llar: ");
            foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("Y�l(enk���k,enb�y�k) = ({0}, {1})", y�llar.Min(), y�llar.Max());
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            Console.Write ("-->T�m peygamberler: ");
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.WriteLine ("Peygamber(enk���k,enb�y�k)[A->Z] = ({0}, {1})", peygamberler.Min(), peygamberler.Max());
            Console.WriteLine ("Peygamber(enk���k,enb�y�k)[Length] = ({0}, {1})", peygamberler.Min (x=>x.Length), peygamberler.Max (x=>x.Length));

            Console.WriteLine ("\n���i listesi ���i[] diziye �evrilip 3 alan�n�n enk���k/enb�y�k tespiti:");
            ���i[] i��iler = ���i.ListeyiAl();
            Console.WriteLine ("���i-Ya�(enk���k,enb�y�k) = ({0}, {1})", i��iler.Min (a => a.y�l), i��iler.Max (a => a.y�l));
            Console.WriteLine ("���i-Ad(enk���k,enb�y�k) = ({0}, {1})", i��iler.Min (a => a.ad), i��iler.Max (a => a.ad));
            Console.WriteLine ("���i-Soyad(enk���k,enb�y�k) = ({0}, {1})", i��iler.Min (a => a.soyad), i��iler.Max (a => a.soyad));

            Console.WriteLine ("\nD�nyadaki bayilerinin enk���k/enb�y�k ciro, k�ta, �lke ve �ehirleri:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", �ehir="Tahran", �lke="�ran", K�ta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("Bayi-Ciro(enk���k, enb�y�k) = (${0:#,0.00}, ${1:#,0.00})", bayiler.Min (a=>a.Ciro), bayiler.Max (a=>a.Ciro));
            Console.WriteLine ("Bayi-K�ta(enk���k, enb�y�k) = ({0}, {1})", bayiler.Min (a=>a.K�ta), bayiler.Max (a=>a.K�ta));
            Console.WriteLine ("Bayi-�lke(enk���k, enb�y�k) = ({0}, {1})", bayiler.Min (a=>a.�lke), bayiler.Max (a=>a.�lke));
            Console.WriteLine ("Bayi-�ehir(enk���k, enb�y�k) = ({0}, {1})", bayiler.Min (a=>a.�ehir), bayiler.Max (a=>a.�ehir));

            Console.WriteLine ("\nBirle�ik i��i ve maa� liste eleman alanlar�n�n enk���k/enb�y���:");
            List<���i2> i��iler2 = new List<���i2> {//Bran��=1: Y�netim; 2: Muhasebe; 3: Vardiya
                new ���i2 {No = 1951, Bran�� = 1, Soyad = "Ka�ar", Ad = "Hatice"},
                new ���i2 {No = 1953, Bran�� = 3, Soyad = "�zbay", Ad = "S�heyla"},
                new ���i2 {No = 1955, Bran�� = 2, Soyad = "Candan", Ad = "Zeliha"},
                new ���i2 {No = 1957, Bran�� = 3, Soyad = "Yava�", Ad = "M.Nihat"},
                new ���i2 {No = 1959, Bran�� = 3, Soyad = "G�kyi�it", Ad = "Song�l"},
                new ���i2 {No = 1961, Bran�� = 2, Soyad = "Yava�", Ad = "M.Nedim"},
                new ���i2 {No = 1963, Bran�� = 1, Soyad = "Yava�", Ad = "Sevim"}
            };
            List<Maa�> maa�lar = new List<Maa�> {
                new Maa� {No = 1951, Y�l = 2024, Maa�� = 120675.87},
                new Maa� {No = 1953, Y�l = 2024, Maa�� = 105302.15},
                new Maa� {No = 1955, Y�l = 2024, Maa�� = 118765.54},
                new Maa� {No = 1957, Y�l = 2024, Maa�� = 165674.43},
                new Maa� {No = 1959, Y�l = 2024, Maa�� = 218765.43},
                new Maa� {No = 1961, Y�l = 2024, Maa�� = 146734.17},
                new Maa� {No = 1963, Y�l = 2024, Maa�� = 215458.98}
            };
            var sorgu1 = from i� in i��iler2
                join m in maa�lar on i�.No equals m.No
                select new {no=i�.No, ad=i�.Ad, soyad=i�.Soyad, maa�=m.Maa��, dy�l=i�.No};
            Console.WriteLine ("���i-Maa�(enk���k,enb�y�k) = ({0:#,0.00}TL, {1:#,0.00}TL)", sorgu1.Min (a=>a.maa�), sorgu1.Max (a=>a.maa�));
            Console.WriteLine ("���i-Ad(enk���k,enb�y�k) = ({0}, {1})", sorgu1.Min (a=>a.ad), sorgu1.Max (a=>a.ad));
            Console.WriteLine ("���i-Soyad(enk���k,enb�y�k) = ({0}, {1})", sorgu1.Min (a=>a.soyad), sorgu1.Max (a=>a.soyad));
            Console.WriteLine ("���i-DY�l(enk���k,enb�y�k) = ({0}, {1})", sorgu1.Min (a=>a.dy�l), sorgu1.Max (a=>a.dy�l));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}