// j2sc#1101g.cs: Array.Sort/Reverse(dizi), Array.ConverAll ve IEnumerator örneði.

using System;
using System.Collections; //IEnumerator için
namespace VeriYapýlarý {
    public class Ýþgören: IComparable {
        string ad;
        int maaþ;
        public override string ToString() {return (String.Format ("{0}:{1}", ad, maaþ));}

        public Ýþgören (string ad, int maaþ) {this.ad = ad; this.maaþ = maaþ;} //Kurucu
        int IComparable.CompareTo (object nes) {
            Ýþgören iþg = (Ýþgören) nes;
            if (this.maaþ > iþg.maaþ) return(1);
            if (this.maaþ < iþg.maaþ) return(-1);
            else return(0);
        }
    }
    class VeriYapýsý1G {
        static void Main() {
            Console.Write ("Array.Sort(dizi) dizi elemanlarýný artan sýralarken Array.Reverse(dizi) ise artan sýralý diziyi tersler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, ts1; var r=new Random();
            ts1=r.Next(2,50);
            Console.WriteLine ("Rasgele tsDizi1[{0}] tamsayý dizi elemanlarýný artan ve azalan sýralama:", ts1);
            int[] tsDizi1 = new int[ts1];
            for(i=0;i<tsDizi1.Length;i++) {ts1=r.Next(-200,1000); tsDizi1 [i]=ts1;}
            int[] tsDizi2 = tsDizi1;
            Console.Write ("\tOrijinal düzen: "); foreach(int k in tsDizi1) Console.Write (k + " ");
            Array.Sort (tsDizi1);
            Console.Write ("\n\tArtan sýralý düzen: "); foreach(int k in tsDizi1) Console.Write (k + " ");
            Array.Reverse (tsDizi1);
            Console.Write ("\n\tAzalan sýralý düzen: "); foreach(int k in tsDizi1) Console.Write (k + " ");

            ts1=r.Next(1,20); string ad;
            Console.WriteLine ("\n\nÝþgörenleri iþgDizi[{0}] dizide maaþla artan/azalan sýralama", ts1);
            Ýþgören[] iþgDizi = new Ýþgören [ts1];
            for(i=0;i<iþgDizi.Length;i++) {ad=""; for(j=0;j<5;j++) {ts1=r.Next(65,91); ad+=(char)ts1;} ts1=r.Next(7500,100000); iþgDizi [i]=new Ýþgören (ad, ts1);}
            Console.Write ("\tOrijinal düzen: "); foreach(Ýþgören iþg in iþgDizi) Console.Write (iþg + " ");
            Array.Sort (iþgDizi);
            Console.Write ("\n\tArtan maaþ düzeni: "); foreach(Ýþgören iþg in iþgDizi) Console.Write (iþg + " ");
            Ýþgören bul = new Ýþgören (null, ts1);
            i = Array.BinarySearch (iþgDizi, bul);
            Console.Write ("\n\t==>Maaþý {0} TL eleman bordoda mevcut mu? ", ts1);
            if (i >= 0) Console.Write ("Bulundu: {0}", iþgDizi [i]);
            else Console.Write ("Bulunamadý!");
            Array.Reverse (iþgDizi);
            Console.Write ("\n\tAzalan maaþ düzeni: "); foreach(Ýþgören iþg in iþgDizi) Console.Write (iþg + " ");

            string[] diller = new string[] {"JavaScript", "Assembler", "C#", "COBOL", "Java", "C++", "VisualBasic", "TurboPascal", "Fortran", "Python"};
            Console.WriteLine ("\n\nProgramlama diller[{0}] rasgele, artan, azalan listeleri:", diller.Length);
            Console.Write ("\tOrijinal düzen: "); foreach(string dil in diller) Console.Write (dil + " ");
            Array.Sort (diller);
            Console.Write ("\n\tA-Z artan düzen: "); foreach(string dil in diller) Console.Write (dil + " ");
            ad = "COBOL";
            i = Array.BinarySearch (diller, ad);
            Console.WriteLine ("\n\t==>{0} dilinin listedeki endeks no'su: {1}", ad, i);
            Array.Reverse (diller);
            Console.Write ("\tZ-A azalan düzen: "); foreach(string dil in diller) Console.Write (dil + " ");
            Array.Clear (diller, 0, diller.Length);
            Console.WriteLine ("\n\tDizi Clear/silindikten sonra uzunluðu hala: {0}", diller.Length);
            Console.WriteLine ("\tSilinen ilk dil: \"{0,5}\",\tson dil: \"{1,5}\"", diller [0], diller [diller.Length-1]);

            ts1=r.Next(2,50); double ds1;
            Console.WriteLine ("\nString dzgDizi[{0}] dizisini tümden double dblDizi[{0}]'ye çevirme:", ts1);
            string[] dzgDizi = new string [ts1];
            for(i=0;i<dzgDizi.Length;i++) {ds1=r.Next(-200,1000)+r.Next(10,100)/100D; dzgDizi [i]=ds1.ToString();}
            Console.Write ("\tdzgDizi: "); foreach(string d in dzgDizi) Console.Write ("\"{0}\" ", d);
            double[] dblDizi = Array.ConvertAll<string, double> (dzgDizi, Convert.ToDouble);
            Console.Write ("\n\tdblDizi: "); Array.ForEach<double>(dblDizi, delegate (double x) {Console.Write ("{0} ", x);});

            Console.WriteLine ("\n\nProgramlama diller[{0}]'i tümden büyükharfe çevirme:", diller.Length);
            diller = new string[] {"JavaScript", "Assembler", "C#", "COBOL", "Java", "C++", "VisualBasic", "TurboPascal", "Fortran", "Python"};
            Console.Write ("\tBüyük-harfe çevirmeden önce: ");
            Array.ForEach<string>(diller, delegate (string x) {Console.Write (x + " ");});
            string[] bhDiller = Array.ConvertAll<string, string>(diller, delegate (string dil) {return dil.ToUpper();});
            Console.Write ("\n\tBüyük-harfe çevirdikten sonra: ");
            Array.ForEach<string>(bhDiller, delegate (string x) {Console.Write (x + " ");});

            Console.WriteLine ("\n\ntsDizi2[{0}] elemanlarýný IEnumerator ve while-MoveNext()'le tarama:", tsDizi2.Length);
            IEnumerator ie = tsDizi2.GetEnumerator();
            while (ie.MoveNext() == true) {Console.Write("{0} ", ie.Current);}

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}