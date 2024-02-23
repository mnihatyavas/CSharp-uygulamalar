// j2sc#1106a.cs: List<T> ve select-from ile listeleri s�zge�leme/s�ralama �rne�i.

using System;
using System.Collections.Generic; // List<T> i�in
using System.Collections.ObjectModel; // ReadOnlyCollection<T> i�in
using System.Text; //StringBuilder i�in
using System.Linq; //from-select i�in
namespace VeriYap�lar� {
    public static class Vekt�rDelegeleri {
        public static int K�yasla (Vekt�r x, Vekt�r y) {
            if (x.Y� > y.Y�) {return 1;
            }else if (x.Y� < y.Y�) {return -1;}
            return 0;
        }
        public static bool �stSa��eyrekMi (Vekt�r vekt�r) {
            if (vekt�r.A�� >= 0.0 && vekt�r.A�� <= 90.0) {return true;
            }else {return false;}
        }
    }
    public class Vekt�rler : List<Vekt�r> {
        public Vekt�rler() {} //Kurucu-1
        public Vekt�rler (IEnumerable<Vekt�r> vekt�rler) {//Kurucu-2
            foreach (Vekt�r vekt�r in vekt�rler) {Add (vekt�r);}
        }
        public string Toplam() {
            StringBuilder sb = new StringBuilder();
            Vekt�r akt�elNokta = new Vekt�r (0.0, 0.0);
            sb.Append ("==>(0.0, 0.0)");
            foreach (Vekt�r vekt�r in this) {
                sb.AppendFormat (" + {0}", vekt�r);
                akt�elNokta += vekt�r;
            }
            sb.AppendFormat (" = {0}", akt�elNokta);
            return sb.ToString();
        }
    }
    public class Vekt�r {
        public double? Y� = null;
        public double? A�� = null;
        public double? RadyanA�� {get {return (A�� * Math.PI / 180.0);}}
        public Vekt�r (double? y, double? a��) {//Kurucu
            if (y < 0) {y = -y; a�� += 180;}
            a�� = a�� % 360;
            Y� = y;
            A�� = a��;
        }
        public static Vekt�r operator +(Vekt�r i�1, Vekt�r i�2) {
            try {
                double yeniX = i�1.Y�.Value * Math.Sin (i�1.RadyanA��.Value) + i�2.Y�.Value * Math.Sin (i�2.RadyanA��.Value);
                double yeniY = i�1.Y�.Value * Math.Cos (i�1.RadyanA��.Value) + i�2.Y�.Value * Math.Cos (i�2.RadyanA��.Value);
                double yeniY� = Math.Sqrt (yeniX * yeniX + yeniY * yeniY);
                double yeniA�� = Math.Atan2 (yeniX, yeniY) * 180.0 / Math.PI;
                return new Vekt�r (yeniY�, yeniA��);
            }catch {return new Vekt�r (null, null);}
        }
/*      //"-y�-->+y�, a��+=180" oldu�undan �rnekte -operator kullan�lm�yor.
        public static Vekt�r operator -(Vekt�r i�1) {return new Vekt�r (-i�1.Y�, i�1.A��);}
        public static Vekt�r operator -(Vekt�r i�1, Vekt�r i�2) {return i�1 + (-i�2);}
*/
        public override string ToString() {
            string y�Dzg = Y�.HasValue ? Y�.ToString() : "null";
            string a��Dzg = A��.HasValue ? A��.ToString() : "null";
            return string.Format ("({0}, {1})", y�Dzg, a��Dzg);
        }
    }
    public class �r�n {
        string ad;
        decimal fiyat;
        public string Ad {get {return ad;}}
        public decimal Fiyat {get {return fiyat;}}
        public �r�n (string a, decimal f) {ad = a; fiyat = f;} //Kurucu
        public override string ToString() {return string.Format ("{0}={1:#,0.00}TL ", ad, fiyat);}
    }
    class �r�nad�K�yasc� : IComparer<�r�n> {public int Compare (�r�n �1, �r�n �2) {return �2.Ad.CompareTo (�1.Ad);}}
    class Kodlu�r�n {
        public string Ad {get; private set;}
        public decimal Fiyat {get; private set;}
        public int Toptanc�Kodu {get; private set;}
        public Kodlu�r�n (string a, decimal f) {Ad = a; Fiyat = f;} //Kurucu-1
        Kodlu�r�n(){} //Kurucu-2
        public static List<Kodlu�r�n> �r�nleriAl() {
            return new List<Kodlu�r�n> {
                new Kodlu�r�n {Ad="Ca", Fiyat= 9.99m, Toptanc�Kodu=1},
                new Kodlu�r�n {Ad="Ab", Fiyat=14.99m, Toptanc�Kodu=2},
                new Kodlu�r�n {Ad="Fc", Fiyat=13.99m, Toptanc�Kodu=1},
                new Kodlu�r�n {Ad="Sd", Fiyat=10.99m, Toptanc�Kodu=3},
                new Kodlu�r�n {Ad="Se", Fiyat=17.99m, Toptanc�Kodu=4},
                new Kodlu�r�n {Ad="Kf", Fiyat=11.99m, Toptanc�Kodu=1},
                new Kodlu�r�n {Ad="Kf", Fiyat=10.99m, Toptanc�Kodu=1},
                new Kodlu�r�n {Ad="Lg", Fiyat=15.99m, Toptanc�Kodu=5}
            };
        }
        public override string ToString() {return string.Format ("{0}={1}TL ", Ad, Fiyat);}
    }
    class Toptanc� {
        public string Ad {get; private set;}
        public int Toptanc�Kodu {get; private set;}
        Toptanc�(){} //Kurucu
        public static List<Toptanc�> Toptanc�leriAl() {
            return new List<Toptanc�> {
                new Toptanc� {Ad="Sa", Toptanc�Kodu=1},
                new Toptanc� {Ad="Cb", Toptanc�Kodu=2},
                new Toptanc� {Ad="Bc", Toptanc�Kodu=3},
                new Toptanc� {Ad="De", Toptanc�Kodu=4}
            };
        }
    }
    class VeriYap�s�6A {
        private static int DizgedenTamsay�ya (string liste) {
            int sonu�;
            if (!int.TryParse (liste, out sonu�)) sonu� = -1;
            return sonu�;
        }
        public static List<�r�n> �r�nleriAl() {
            int i, j, ts; decimal m; string a; var r=new Random();
            List<�r�n> liste = new List<�r�n>();
            for(i=0;i<10;i++) {
               a=""; for(j=0;j<5;j++) {ts=r.Next(0,26); a+=(char)(ts+65);}
               m=r.Next(10,1500)+r.Next(10,100)/100M;
               liste.Add (new �r�n (a, m));
            }
            return liste;
        }
        static void Main() {
            Console.Write ("List<S�n�f> ile her �e�it (vekt�r, �r�n, i�g�ren vb) s�n�f/yap� liste eleman� olabilmektedir. Linq-->from-select filitresiyle �art� sa�layan liste elemanlar� alt-listeye d�n��ebilmektedir. Liste<T>.OrderBy/orderby ile select-from veya foreach-liste istenilen tek/�ok anahtarla s�ralanabilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�nce List<T> ve delegesi, sonra kopyas� ReadOnlyCollection<T> liste sunumlar�:");
            int i, ts1; var r=new Random();
            List<int> lst1 = new List<int>();
            for(i=0;i<18;i++) {ts1=r.Next(-100,1000); lst1.Add (ts1);}
            for(i=0;i<lst1.Count;i++) Console.Write (lst1 [i] + " "); Console.WriteLine();
            lst1.ForEach (delegate (int x) {Console.Write (x+" "); }); Console.WriteLine();
            ReadOnlyCollection<int> sol1 = lst1.AsReadOnly();
            for(i=0;i<sol1.Count;i++) Console.Write (sol1 [i] + " "); Console.WriteLine();
            Console.WriteLine ("\tListeyi �nce dizgeye sonra tekrar tamsay�ya �evirme:");
            List<string> lst1a = lst1.ConvertAll<string> (Convert.ToString);
            for(i=0;i<lst1a.Count;i++) Console.Write (lst1a [i] + " "); Console.WriteLine();
            List<int> lst1b = lst1a.ConvertAll<int> (Convert.ToInt32);
            for(i=0;i<lst1b.Count;i++) Console.Write (lst1b [i] + " "); Console.WriteLine();
            List<int> lst1c = lst1a.ConvertAll<int> (DizgedenTamsay�ya);
            for(i=0;i<lst1c.Count;i++) Console.Write (lst1c [i] + " "); Console.WriteLine();

            Console.WriteLine ("\n(y�,a��)'l� List<Vekt�r>'leri normal/s�ral� ve ilk�eyrektekileri toplama:");
            double ds1, ds2;
            Vekt�rler vekt�rler = new Vekt�rler();
            for(i=0;i<10;i++) {
                ds1=r.Next(-10,10)+r.Next(10,100)/100D; ds2=r.Next(0,1000)+r.Next(10,100)/100D;
                vekt�rler.Add (new Vekt�r (ds1, ds2));
            }
            Console.WriteLine (vekt�rler.Toplam()); //T�m vekt�rlerin normal toplam�
            Comparison<Vekt�r> s�ralay�c� = new Comparison<Vekt�r> (Vekt�rDelegeleri.K�yasla);
            vekt�rler.Sort (s�ralay�c�);
            Console.WriteLine (vekt�rler.Toplam()); //T�m vekt�rlerin yar��ap'la artan s�ral� toplam�
            Predicate<Vekt�r> aray�c� = new Predicate<Vekt�r> (Vekt�rDelegeleri.�stSa��eyrekMi);
            Vekt�rler ilk�eyrekVekt�rler = new Vekt�rler (vekt�rler.FindAll (aray�c�));
             Console.WriteLine (ilk�eyrekVekt�rler.Toplam());

            Console.WriteLine ("\nT�m �r�nlerin ve se�ilenlerin ad=fiyat'l� sunumlar�:");
            List<�r�n> �r�nler = �r�nleriAl();
            var se�ilenler = from �r�n � in �r�nler
                    where �.Fiyat > 755
                    select �;
            Console.Write ("==>T�m �r�nler: "); foreach (�r�n � in �r�nler) Console.Write (�); Console.WriteLine();
            Console.Write ("==>Ad'la s�ral� t�m �r�nler: "); foreach (�r�n � in �r�nler.OrderBy (� => �.Ad)) Console.Write (�); Console.WriteLine();
            Console.Write ("==>Fiyat'la s�ral� t�m �r�nler: "); foreach (�r�n � in �r�nler.OrderBy (� => �.Fiyat)) Console.Write (�); Console.WriteLine();
            Console.Write ("==>Fiyat > 755 �r�nler: "); foreach (�r�n � in se�ilenler) Console.Write (�); Console.WriteLine();
            Console.Write ("==>Ad'la s�ral�, fiyat > 755 �r�nler: "); foreach (�r�n � in se�ilenler.OrderBy (s => s.Ad)) Console.Write (�); Console.WriteLine();
            Console.Write ("==>Fiyat'la s�ral�, fiyat > 755 �r�nler: "); foreach (�r�n � in se�ilenler.OrderBy (s => s.Fiyat)) Console.Write (�); Console.WriteLine();
            Console.WriteLine ("\tPredicate-filitre ve Action-delege'yle se�ilen (fyt>1000) sunma:");
            Predicate<�r�n> test = delegate (�r�n �) {return �.Fiyat > 1000m;};
            List<�r�n> uyan = �r�nler.FindAll (test);
            Action<�r�n> yaz = delegate (�r�n �) {Console.Write (�+" ");};
            uyan.ForEach (yaz); Console.WriteLine();
            Console.WriteLine ("\tDelegeli FindAll ve ForEach'le se�ilen (f>500 && f < 1000) sunma:");
            �r�nler.FindAll (delegate (�r�n �) {return �.Fiyat > 500 && �.Fiyat < 1000;})
                    .ForEach (delegate (�r�n �) {Console.Write (�+" ");}); Console.WriteLine();
            Console.WriteLine ("\tDo�rudn foreach-where ile se�ilen (f < 500) sunma:");
            foreach (�r�n �rn in �r�nler.Where (� => �.Fiyat < 500)) Console.Write (�rn+" "); Console.WriteLine();
            Console.WriteLine ("\t�zelle�en Sort'la se�ilen (f < 1000) azalan s�ral� sunma:");
            �r�nler.Sort (new �r�nad�K�yasc�());
            foreach (�r�n � in �r�nler.Where (� => �.Fiyat < 1000)) Console.Write (�+" "); Console.WriteLine();
            Console.WriteLine ("\tDelegeli Sort'la se�ilen (f < 1000) artan s�ral� sunma:");
            �r�nler.Sort (delegate (�r�n �1, �r�n �2) {return �1.Ad.CompareTo (�2.Ad);});
            foreach (�r�n �r in �r�nler.Where (� => �.Fiyat < 1000)) Console.Write (�r+" "); Console.WriteLine();

            Console.WriteLine ("\n�r�nler ve toptanc�lardan fiyat ve kod kriterli se�ilenlerin s�ral� listesi:");
            List<Kodlu�r�n> �r�nler2 = Kodlu�r�n.�r�nleriAl();
            List<Toptanc�> tedarik�iler = Toptanc�.Toptanc�leriAl();
            var se�ilenler2 = from � in �r�nler2
                    join t in tedarik�iler
                    on �.Toptanc�Kodu equals t.Toptanc�Kodu
                    where �.Fiyat > 10
                    orderby t.Ad, �.Ad, �.Fiyat //Artan s�ralama anahtarlar�: kod+ad+fiyat
                    select new {
                        Toptanc�Kodu = t.Toptanc�Kodu,
                        Toptanc�Ad� = t.Ad,
                        �r�nAd� = �.Ad,
                        �r�nFiyat� = �.Fiyat
                    };
            foreach (var s in se�ilenler2) Console.WriteLine ("Toptanc�Ad�={0}; �r�nAd�={1}; Tedarik�iKodu={2}; �r�nFiyat�={3}TL",
                    s.Toptanc�Ad�, s.�r�nAd�, s.Toptanc�Kodu, s.�r�nFiyat�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}