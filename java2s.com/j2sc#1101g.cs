// j2sc#1101g.cs: Array.Sort/Reverse(dizi), Array.ConverAll ve IEnumerator �rne�i.

using System;
using System.Collections; //IEnumerator i�in
namespace VeriYap�lar� {
    public class ��g�ren: IComparable {
        string ad;
        int maa�;
        public override string ToString() {return (String.Format ("{0}:{1}", ad, maa�));}

        public ��g�ren (string ad, int maa�) {this.ad = ad; this.maa� = maa�;} //Kurucu
        int IComparable.CompareTo (object nes) {
            ��g�ren i�g = (��g�ren) nes;
            if (this.maa� > i�g.maa�) return(1);
            if (this.maa� < i�g.maa�) return(-1);
            else return(0);
        }
    }
    class VeriYap�s�1G {
        static void Main() {
            Console.Write ("Array.Sort(dizi) dizi elemanlar�n� artan s�ralarken Array.Reverse(dizi) ise artan s�ral� diziyi tersler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, ts1; var r=new Random();
            ts1=r.Next(2,50);
            Console.WriteLine ("Rasgele tsDizi1[{0}] tamsay� dizi elemanlar�n� artan ve azalan s�ralama:", ts1);
            int[] tsDizi1 = new int[ts1];
            for(i=0;i<tsDizi1.Length;i++) {ts1=r.Next(-200,1000); tsDizi1 [i]=ts1;}
            int[] tsDizi2 = tsDizi1;
            Console.Write ("\tOrijinal d�zen: "); foreach(int k in tsDizi1) Console.Write (k + " ");
            Array.Sort (tsDizi1);
            Console.Write ("\n\tArtan s�ral� d�zen: "); foreach(int k in tsDizi1) Console.Write (k + " ");
            Array.Reverse (tsDizi1);
            Console.Write ("\n\tAzalan s�ral� d�zen: "); foreach(int k in tsDizi1) Console.Write (k + " ");

            ts1=r.Next(1,20); string ad;
            Console.WriteLine ("\n\n��g�renleri i�gDizi[{0}] dizide maa�la artan/azalan s�ralama", ts1);
            ��g�ren[] i�gDizi = new ��g�ren [ts1];
            for(i=0;i<i�gDizi.Length;i++) {ad=""; for(j=0;j<5;j++) {ts1=r.Next(65,91); ad+=(char)ts1;} ts1=r.Next(7500,100000); i�gDizi [i]=new ��g�ren (ad, ts1);}
            Console.Write ("\tOrijinal d�zen: "); foreach(��g�ren i�g in i�gDizi) Console.Write (i�g + " ");
            Array.Sort (i�gDizi);
            Console.Write ("\n\tArtan maa� d�zeni: "); foreach(��g�ren i�g in i�gDizi) Console.Write (i�g + " ");
            ��g�ren bul = new ��g�ren (null, ts1);
            i = Array.BinarySearch (i�gDizi, bul);
            Console.Write ("\n\t==>Maa�� {0} TL eleman bordoda mevcut mu? ", ts1);
            if (i >= 0) Console.Write ("Bulundu: {0}", i�gDizi [i]);
            else Console.Write ("Bulunamad�!");
            Array.Reverse (i�gDizi);
            Console.Write ("\n\tAzalan maa� d�zeni: "); foreach(��g�ren i�g in i�gDizi) Console.Write (i�g + " ");

            string[] diller = new string[] {"JavaScript", "Assembler", "C#", "COBOL", "Java", "C++", "VisualBasic", "TurboPascal", "Fortran", "Python"};
            Console.WriteLine ("\n\nProgramlama diller[{0}] rasgele, artan, azalan listeleri:", diller.Length);
            Console.Write ("\tOrijinal d�zen: "); foreach(string dil in diller) Console.Write (dil + " ");
            Array.Sort (diller);
            Console.Write ("\n\tA-Z artan d�zen: "); foreach(string dil in diller) Console.Write (dil + " ");
            ad = "COBOL";
            i = Array.BinarySearch (diller, ad);
            Console.WriteLine ("\n\t==>{0} dilinin listedeki endeks no'su: {1}", ad, i);
            Array.Reverse (diller);
            Console.Write ("\tZ-A azalan d�zen: "); foreach(string dil in diller) Console.Write (dil + " ");
            Array.Clear (diller, 0, diller.Length);
            Console.WriteLine ("\n\tDizi Clear/silindikten sonra uzunlu�u hala: {0}", diller.Length);
            Console.WriteLine ("\tSilinen ilk dil: \"{0,5}\",\tson dil: \"{1,5}\"", diller [0], diller [diller.Length-1]);

            ts1=r.Next(2,50); double ds1;
            Console.WriteLine ("\nString dzgDizi[{0}] dizisini t�mden double dblDizi[{0}]'ye �evirme:", ts1);
            string[] dzgDizi = new string [ts1];
            for(i=0;i<dzgDizi.Length;i++) {ds1=r.Next(-200,1000)+r.Next(10,100)/100D; dzgDizi [i]=ds1.ToString();}
            Console.Write ("\tdzgDizi: "); foreach(string d in dzgDizi) Console.Write ("\"{0}\" ", d);
            double[] dblDizi = Array.ConvertAll<string, double> (dzgDizi, Convert.ToDouble);
            Console.Write ("\n\tdblDizi: "); Array.ForEach<double>(dblDizi, delegate (double x) {Console.Write ("{0} ", x);});

            Console.WriteLine ("\n\nProgramlama diller[{0}]'i t�mden b�y�kharfe �evirme:", diller.Length);
            diller = new string[] {"JavaScript", "Assembler", "C#", "COBOL", "Java", "C++", "VisualBasic", "TurboPascal", "Fortran", "Python"};
            Console.Write ("\tB�y�k-harfe �evirmeden �nce: ");
            Array.ForEach<string>(diller, delegate (string x) {Console.Write (x + " ");});
            string[] bhDiller = Array.ConvertAll<string, string>(diller, delegate (string dil) {return dil.ToUpper();});
            Console.Write ("\n\tB�y�k-harfe �evirdikten sonra: ");
            Array.ForEach<string>(bhDiller, delegate (string x) {Console.Write (x + " ");});

            Console.WriteLine ("\n\ntsDizi2[{0}] elemanlar�n� IEnumerator ve while-MoveNext()'le tarama:", tsDizi2.Length);
            IEnumerator ie = tsDizi2.GetEnumerator();
            while (ie.MoveNext() == true) {Console.Write("{0} ", ie.Current);}

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}