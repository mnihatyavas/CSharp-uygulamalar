// j2sc#1102a.cs: ArrayList yaratma, eleman ekleme, silme, arayagirme ve sunum �rne�i.

using System;
using System.Collections;
namespace VeriYap�lar� {
    class VeriYap�s�2A {
        static void Main() {
            Console.Write ("ArrayList i�in 'using System.Collections' tan�mlanmal�d�r. Remove(konum,adet)/Insert(konum, eleman/dizi)Range azami 2 arg�man (eleman veya dizi) kabul eder, kapasite a��l�rsa +kapasite artar. Dizi ebat� Length/uzunluk iken DiziListe ebat� Count/adet'dir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli ArrayList yaratma, ebatlama, eleman-lar ekleme/silme/g�sterme:");
            int i, ts1; var r=new Random();
            ArrayList dl1 = new ArrayList(); //Ebats�z
            ArrayList dl2 = new ArrayList (10); //10 ebatl�
            int[] tsDizi1 = new int [5]; //5 ebatl�
            for(i=0;i<tsDizi1.Length;i++) {ts1=r.Next(-100, 1000); tsDizi1 [i]=ts1;}
            Console.Write ("tsDizi1[{0}]: ", tsDizi1.Length); foreach(int ts in tsDizi1) Console.Write (ts+" ");
            ArrayList dl3 = new ArrayList (tsDizi1);
            Console.Write ("\ndl3[{0}]: ", dl3.Capacity); foreach(object ns in dl3) Console.Write (ns+" ");
            ArrayList dl4 = new ArrayList();
            dl4.Capacity = 9;
            dl4.Add (2021); dl4.Add (2022); dl4.Add (2023); dl4.Add (2024);
            dl4.AddRange (tsDizi1);
            Console.WriteLine ("\ndl4.Capacity: " +  dl4.Capacity);
            dl4.Remove (2023);
            dl4.RemoveRange (2, 2);
            dl4.Insert (0, 2023);
            dl4.InsertRange (4, tsDizi1);
            dl4.Add (2024);
            Console.Write ("dl4[{0}]: ", dl4.Capacity); foreach(object ns in dl4) Console.Write (ns+" ");

            Console.WriteLine ("\n\nDiziListe'ye Add'le eleman ekleme, RemoveRange'le silme, Count'la ebat sorma:");
            ArrayList dl5 = new ArrayList();
            Console.WriteLine ("dl5'in ilk ebat�: " + dl5.Count);
            for(i=0;i<10;i++) {
                ts1=r.Next(-100, 1000);
                dl5.Add (ts1);
                Console.Write ("{0}.Ebat={1}, ", i+2, dl5.Count);
            }
            Console.WriteLine ("\ndl5({0}) elemanlar�: ", dl5.Count); foreach(object ns in dl5) Console.Write (ns+" ");
            Console.Write ("\nTek tek eleman silme: "); for(i=0;i<10;i++) {dl5.RemoveRange (0, 1); Console.Write ("Kalan={0}, ", dl5.Count);}

            Console.WriteLine ("\n\nDiziListe elemanlar�� Add'le ekleme ve DiziListe[i] ile de�i�tirme:");
            ArrayList dl6 = new ArrayList();
            for(i=0;i<26;i++) dl6.Add ((char)('a' + i));
            Console.Write ("dl6({0}) elemanlar�: ", dl6.Count); foreach(char k in dl6) Console.Write (k+" ");
            for(i=0;i<26;i++) dl6 [i]=(dl6[i]).ToString().ToUpper();
            Console.Write ("\ndl6({0}) elemanlar�: ", dl6.Count); foreach(string k in dl6) Console.Write (k+" ");

            Console.WriteLine ("\n\nDiziListe'yi s�ralama, eleman arama, tersleme ve sunumlar:");
            ArrayList dl7 = new ArrayList();
            for(i=0;i<100;i++) {ts1=r.Next(0, 100); dl7.Add (ts1);}
            Console.Write ("==>dl7({0}) elemanlar�: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");
            dl7.Sort();
            Console.Write ("\n==>Artan s�ral� dl7({0}) elemanlar�: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");
            ts1=r.Next(0, 100); Console.WriteLine ("\n==>dl7({0}) i�indeki {1}'nin endeksi: {2}", dl7.Count, ts1, dl7.BinarySearch (ts1)<0?-1:dl7.BinarySearch (ts1));
            dl7.Reverse();
            Console.Write ("==>Azalan s�ral� dl7({0}) elemanlar�: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");

            Console.WriteLine ("\n\nRemoveAt eleman� tektek silerken, Clear mevcut elemanlar�n tm�n� siler:");
            ArrayList dl8 = new ArrayList (1); 
            for(i=0;i<50;i++) {ts1=r.Next(-100, 100); dl8.Add (ts1);}
            IEnumerator ie = dl8.GetEnumerator();
            Console.Write ("==>dl8({0}) elemanlar�: ", dl8.Count); while (ie.MoveNext()) Console.Write (ie.Current + " ");
            for(i=0;i<25;i++) dl8.RemoveAt (0);
            Console.Write ("\n==>dl8({0}) elemanlar�: ", dl8.Count); foreach(int ts in dl8) Console.Write (ts + " ");
            dl8.RemoveAt (0); dl8.RemoveRange (0, 5); dl8.Clear();
            Console.Write ("\n==>dl8({0}) elemanlar�: ", dl8.Count); foreach(int ts in dl8) Console.Write (ts + " ");

            Console.WriteLine ("\n\nDiziListe'yi NesneDizi ve DizgeDizi'ye kopyalama, int'e kutusuzlay�p sunma:");
            ArrayList dl9 = new ArrayList();
            for(i=0;i<50;i++) {ts1=r.Next(-50, 1000); dl9.Add (ts1);}
            object[] nsDizi = dl9.ToArray();
            string[] dzgDizi = new string [dl9.Count]; for(i=0;i<dzgDizi.Length;i++) dzgDizi [i]=dl9 [i].ToString();
            Console.Write ("==>dl9({0}) elemanlar�: ", dl9.Count); foreach(int ts in dl9) Console.Write (ts + " ");
            Console.Write ("\n==>nsDizi[{0}] elemanlar�: ", nsDizi.Length); foreach(object ns in nsDizi) {i=(int)ns; Console.Write (i + " ");}
            Console.Write ("\n==>dzgDizi[{0}] elemanlar�: ", dzgDizi.Length); for(i=0;i<dzgDizi.Length;i++) {ts1=int.Parse (dzgDizi [i]); Console.Write (ts1 + " ");}

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}