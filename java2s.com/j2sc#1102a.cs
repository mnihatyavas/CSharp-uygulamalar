// j2sc#1102a.cs: ArrayList yaratma, eleman ekleme, silme, arayagirme ve sunum örneði.

using System;
using System.Collections;
namespace VeriYapýlarý {
    class VeriYapýsý2A {
        static void Main() {
            Console.Write ("ArrayList için 'using System.Collections' tanýmlanmalýdýr. Remove(konum,adet)/Insert(konum, eleman/dizi)Range azami 2 argüman (eleman veya dizi) kabul eder, kapasite aþýlýrsa +kapasite artar. Dizi ebatý Length/uzunluk iken DiziListe ebatý Count/adet'dir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli ArrayList yaratma, ebatlama, eleman-lar ekleme/silme/gösterme:");
            int i, ts1; var r=new Random();
            ArrayList dl1 = new ArrayList(); //Ebatsýz
            ArrayList dl2 = new ArrayList (10); //10 ebatlý
            int[] tsDizi1 = new int [5]; //5 ebatlý
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
            Console.WriteLine ("dl5'in ilk ebatý: " + dl5.Count);
            for(i=0;i<10;i++) {
                ts1=r.Next(-100, 1000);
                dl5.Add (ts1);
                Console.Write ("{0}.Ebat={1}, ", i+2, dl5.Count);
            }
            Console.WriteLine ("\ndl5({0}) elemanlarý: ", dl5.Count); foreach(object ns in dl5) Console.Write (ns+" ");
            Console.Write ("\nTek tek eleman silme: "); for(i=0;i<10;i++) {dl5.RemoveRange (0, 1); Console.Write ("Kalan={0}, ", dl5.Count);}

            Console.WriteLine ("\n\nDiziListe elemanlarýý Add'le ekleme ve DiziListe[i] ile deðiþtirme:");
            ArrayList dl6 = new ArrayList();
            for(i=0;i<26;i++) dl6.Add ((char)('a' + i));
            Console.Write ("dl6({0}) elemanlarý: ", dl6.Count); foreach(char k in dl6) Console.Write (k+" ");
            for(i=0;i<26;i++) dl6 [i]=(dl6[i]).ToString().ToUpper();
            Console.Write ("\ndl6({0}) elemanlarý: ", dl6.Count); foreach(string k in dl6) Console.Write (k+" ");

            Console.WriteLine ("\n\nDiziListe'yi sýralama, eleman arama, tersleme ve sunumlar:");
            ArrayList dl7 = new ArrayList();
            for(i=0;i<100;i++) {ts1=r.Next(0, 100); dl7.Add (ts1);}
            Console.Write ("==>dl7({0}) elemanlarý: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");
            dl7.Sort();
            Console.Write ("\n==>Artan sýralý dl7({0}) elemanlarý: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");
            ts1=r.Next(0, 100); Console.WriteLine ("\n==>dl7({0}) içindeki {1}'nin endeksi: {2}", dl7.Count, ts1, dl7.BinarySearch (ts1)<0?-1:dl7.BinarySearch (ts1));
            dl7.Reverse();
            Console.Write ("==>Azalan sýralý dl7({0}) elemanlarý: ", dl7.Count); foreach(int ts in dl7) Console.Write (ts + " ");

            Console.WriteLine ("\n\nRemoveAt elemaný tektek silerken, Clear mevcut elemanlarýn tmünü siler:");
            ArrayList dl8 = new ArrayList (1); 
            for(i=0;i<50;i++) {ts1=r.Next(-100, 100); dl8.Add (ts1);}
            IEnumerator ie = dl8.GetEnumerator();
            Console.Write ("==>dl8({0}) elemanlarý: ", dl8.Count); while (ie.MoveNext()) Console.Write (ie.Current + " ");
            for(i=0;i<25;i++) dl8.RemoveAt (0);
            Console.Write ("\n==>dl8({0}) elemanlarý: ", dl8.Count); foreach(int ts in dl8) Console.Write (ts + " ");
            dl8.RemoveAt (0); dl8.RemoveRange (0, 5); dl8.Clear();
            Console.Write ("\n==>dl8({0}) elemanlarý: ", dl8.Count); foreach(int ts in dl8) Console.Write (ts + " ");

            Console.WriteLine ("\n\nDiziListe'yi NesneDizi ve DizgeDizi'ye kopyalama, int'e kutusuzlayýp sunma:");
            ArrayList dl9 = new ArrayList();
            for(i=0;i<50;i++) {ts1=r.Next(-50, 1000); dl9.Add (ts1);}
            object[] nsDizi = dl9.ToArray();
            string[] dzgDizi = new string [dl9.Count]; for(i=0;i<dzgDizi.Length;i++) dzgDizi [i]=dl9 [i].ToString();
            Console.Write ("==>dl9({0}) elemanlarý: ", dl9.Count); foreach(int ts in dl9) Console.Write (ts + " ");
            Console.Write ("\n==>nsDizi[{0}] elemanlarý: ", nsDizi.Length); foreach(object ns in nsDizi) {i=(int)ns; Console.Write (i + " ");}
            Console.Write ("\n==>dzgDizi[{0}] elemanlarý: ", dzgDizi.Length); for(i=0;i<dzgDizi.Length;i++) {ts1=int.Parse (dzgDizi [i]); Console.Write (ts1 + " ");}

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}