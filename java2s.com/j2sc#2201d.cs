// j2sc#2201d.cs: Func, delegeli ve lambda'l� fonksiyonlar �rne�i.

using System;
using System.Collections.Generic; // Soysal IEnumerable<> i�in
using System.Linq; //Select i�in
using System.Linq.Expressions; //Expression i�in
using System.Collections; //ArrayList i�in
namespace Anonimler {
    delegate int Y�lDelegesi();
    delegate double Karek�kDelegesi (int i);
    class �r�n {
        public string ad {get; private set;}
        public int adet {get; private set;}
        public decimal fiyat {get; private set;}
        public �r�n (string a, int adt, decimal f) {ad = a; adet=adt; fiyat = f;} //Kurucu-parametreli
        �r�n(){}  //Kurucu-parametresiz
        public static List<�r�n> �r�nleriAl() {
            return new List<�r�n> {
                new �r�n {ad="Cetvel", adet=1265, fiyat = 57.35m},
                new �r�n {ad="Kalem", adet=8261, fiyat=45.87m},
                new �r�n {ad="Defter", adet=879, fiyat=1165.75m},
                new �r�n {ad="Silgi", adet=12653, fiyat=35.72m},
                new �r�n {ad="�anta", adet=657, fiyat=587.93m}
            };
        }
        public override string ToString() {return string.Format ("Ad: {0}\tFiyat: {1,8:#,0.00} TL\tAdet: {2:#,0}", ad, fiyat, adet);}
    }
    class Lambda {
        static Y�lDelegesi Y�lSayac�() {
            int y�l = 1881;
            return () => y�l++;
        }
        public delegate Boolean �ehirKontrolu (String dizge);
        public static String[] �ehirSe�imi (String[] �ehirler, �ehirKontrolu se�) {
            ArrayList se�iliListe = new ArrayList();
            foreach(String �ehir in �ehirler) if (se� (�ehir)) se�iliListe.Add (�ehir);
            return (String[])se�iliListe.ToArray (typeof (String));
        }
        static void Main() {
            Console.Write ("Func<int,bool> anonim fonksiyonda parametre <int>, d�nen <bool> olmal�d�r; delegeli '=delegate(int x){return (x&1)==1}' yerine lambda 'x=>(x&1)==1' kullan�lm��t�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("[1881,1938] aras� rasgele tek/�ift y�llar:");
            var r=new Random(); int i, ts1, ts2;
            Func<int, bool> tekMi = x => (x & 1) == 1; //bool &'le sonu 1 yada 0?
            for(i = 0; i < 10; i++) {
               ts1=r.Next(1881,1938);
               if (tekMi (ts1)) Console.WriteLine (ts1 + " tek y�l'd�r");
               else Console.WriteLine (ts1 + " �ift y�l'd�r");
            }
            Console.WriteLine ("-->Func lambda �rne�in Expression derlenmi� s�r�m�:");
            Expression <Func<int, bool>> TekMi = n => (n & 1) == 1;
            Func<int, bool> tekMiDerle = TekMi.Compile();
            for (i = 0; i < 10; i++) {
               ts1=r.Next(1881,1938);
               if (tekMiDerle (ts1)) Console.WriteLine (ts1 + " tek y�l'd�r");
               else Console.WriteLine (ts1 + " �ift y�l'd�r");
            }

            Console.WriteLine ("\nyyyyaagg y�llar ve yyyy-aa-gg se�ili sorgu sunumlar�:");
            int[] y�llar = new int[1939-1881];
            for(i=0;i<=(1938-1881);i++) {
                ts1=r.Next(1,13); ts2=r.Next(1,32);
                y�llar [i] = ((i+1881)*100+ts1)*100+ts2;
            }
            IEnumerable<int> y�lAyG�n = y�llar.Select (y�l => y�l);
            foreach(var y�l in y�llar) Console.Write (y�l + " "); Console.WriteLine();
            foreach(var y�l in y�lAyG�n) Console.Write ("{0}-{1}-{2} ", y�l/10000, (y�l-(y�l/10000)*10000)/100, Int32.Parse ((y�l.ToString()).Substring (6,2)) ); Console.WriteLine();

            Console.WriteLine ("\nDelegeli lambda d�n��l� [1881,1938]:57 d�ng�l� saya� �a�r�s�:");
            Y�lDelegesi ysaya� = Y�lSayac�();
            for(i=0;i<=(1938-1881);i++) Console.Write (ysaya�()+" "); Console.WriteLine();
            Console.WriteLine ("-->Delegeli lambda d�n��l� [1881,1938]:57 d�ng�l� ifade �a�r�s�:");
            ts1 = 1881;
            Y�lDelegesi ydlg = () => ts1++;
            for(i=0;i<=(1938-1881);i++) Console.Write (ydlg()+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 10 tamsan�n karesi (Func) ve karek�k� (delege):");
            Func<int, int> kare = x => x * x;
            Karek�kDelegesi karek�k = x => Math.Sqrt (x);
            for(i=0;i<10;i++) {
                ts1=r.Next(1881,2024);
                Console.WriteLine ("Tamsay�: {0}\tKaresi: {1:#,0}\tKarek�k�: {2:0.0000}", ts1, kare (ts1), karek�k (ts1));
            }

            Console.WriteLine ("\nHer �� alan i�in Sort'la lambda artan/azalan s�ralamal� d�k�mler:");
            List<�r�n> �r�nler = �r�n.�r�nleriAl();
            double ds=0;
            �r�nler.Sort ((ilk, ikinci) => ilk.ad.CompareTo (ikinci.ad));
            Console.WriteLine ("-->Ad'la A-->Z artan s�ral�:");
            foreach (�r�n �r�n in �r�nler) Console.WriteLine (�r�n);
            �r�nler.Sort ((ilk, ikinci) => ikinci.fiyat.CompareTo (ilk.fiyat));
            Console.WriteLine ("-->Fiyat'la 9-->0 azalan s�ral�:");
            foreach (�r�n �r�n in �r�nler) Console.WriteLine (�r�n);
            �r�nler.Sort ((ilk, ikinci) => ilk.adet.CompareTo (ikinci.adet));
            Console.WriteLine ("-->Adet'le 0--9 artan s�ral�:");
            foreach (�r�n �r�n in �r�nler) {Console.WriteLine (�r�n); ds+=(double)(�r�n.fiyat * �r�n.adet);}
            Console.WriteLine ("T�m �r�nlerin envanter de�eri: {0:#,0.00} TL", ds);

            Console.WriteLine ("\n10 �ehrin uzunluk ve ilkharf k�stasl� delegeli lambda se�ilimleri:");
            string[] �ehirler = {"�anl�Urfa", "Mersin", "Bursa", "Malatya", "Van", "�stanbul", "Ankara", "�zmir", "KahramanMara�", "Bolu"};
            String[] se�ili�ehirler = �ehirSe�imi (�ehirler, �ehir => �ehir.Length > 6);
            Console.Write ("'�ehir.Length > 6' s�zgeci: ");
            foreach (String �ehir in se�ili�ehirler) Console.Write (�ehir+" "); Console.WriteLine();
            se�ili�ehirler = �ehirSe�imi (�ehirler, �ehir => �ehir.Length <= 6);
            Console.Write ("'�ehir.Length <= 6' s�zgeci: ");
            foreach (String �ehir in se�ili�ehirler) Console.Write (�ehir+" "); Console.WriteLine();
            se�ili�ehirler = �ehirSe�imi (�ehirler, �ehir => �ehir [0] == 'M' | �ehir [0] == '�');
            Console.Write ("'M ve �' s�zgeci: ");
            foreach (String �ehir in se�ili�ehirler) Console.Write (�ehir+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}