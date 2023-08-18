// j2sc#0404.cs: ForEach ile koleksiyondaki tip'li elemanlarýn taranmasý örneði.

using System;
namespace Ýfadeler {
    class ForEach {
        static void Main() {
            Console.Write ("ForEach döngüsü bir tipli koleksiyonun tüm elemanlarýný baþtan sona tarar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            float fs1 = 0; int i, j, k;
            float[] fsDizi1 = new float [10];
            for (i = 1; i <= 10; i++) fsDizi1 [i-1] = 2 * (float)Math.PI * i;
            Console.WriteLine ("ForEach'le 10'luk dizi elemanlarýnýn toplamý:");
            i=0;
            foreach (float fs in fsDizi1) {Console.WriteLine ("{0}.nci dizi eleman deðeri: {1}", ++i, fs);
                fs1+=fs;
            } Console.WriteLine ("{0} sayýnýn toplamý = {1}", fsDizi1.Length, fs1);

            Console.WriteLine ("\nForEach'le 10'luk dizinin ilk 5 elemanlarýnýn toplamý:");
            i=0; fs1=0;
            foreach (float fs in fsDizi1) {Console.WriteLine ("{0}.nci dizi eleman deðeri: {1}", ++i, fs);
                fs1+=fs;
                if (i >=5 ) break;
            } Console.WriteLine ("{0} sayýnýn toplamý = {1}", i, fs1);

            Console.WriteLine ("\nForEach'le [3, 5]'lik matrisin elemanlarýnýn toplamý:");
            float[,] fsDizi2 = new float [3,5];
            for (i = 0; i < 3; i++) for (j=0; j < 5; j++) fsDizi2 [i,j] = (i+1)*(j+1)*(float)Math.PI;
            i=0; fs1=0;
            foreach (float fs in fsDizi2) {Console.WriteLine ("{0}.nci dizi eleman deðeri: {1}", ++i, fs); fs1+=fs;}
            Console.WriteLine ("{0} sayýnýn toplamý = {1}", fsDizi2.Length, fs1);

            Console.WriteLine ("\nForEach'le 5, 10, 15]'lik matrisin tek rasgele elemanýnýn bulunmasý:");
            var r=new Random(); int ts1=r.Next (0, 400);
            int[,,] tsDizi = new int [5, 10, 15];
            for (i = 0; i < 5; i++) for (j=0; j < 10; j++) for (k=0; k < 15; k++) tsDizi [i,j,k] = r.Next (0, 400);
            bool bulunduMu = false; i=0;
            foreach (int x in tsDizi) {i++; if (x == ts1) {bulunduMu = true; break;}}
            Console.WriteLine ("{0} adet rasgele elemanlý dizide {1} bulundu mu? {2}: Konumu = {3}/{0}", tsDizi.Length, ts1, bulunduMu, (i < tsDizi.Length? i : -1));
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
/*
The foreach loop is used to cycle through the elements of a collection.

The general form of foreach is shown here:

foreach(type var-name in collection) 
       statement;
using System; 
 
class MainClass { 
  public static void Main() { 
    int sum = 0; 
    int[] nums = new int[10]; 
 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    Console.WriteLine("use foreach to display and sum the values");
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
    } 
    Console.WriteLine("Summation: " + sum); 
  } 
}
use foreach to display and sum the values
Value is: 0
Value is: 1
Value is: 2
Value is: 3
Value is: 4
Value is: 5
Value is: 6
Value is: 7
Value is: 8
Value is: 9
Summation: 45
------------------------------
using System; 
 
class MainClass { 
  public static void Main() { 
    int sum = 0; 
    int[] nums = new int[10]; 
 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
      if(x == 4) 
         break; // stop the loop when 4 is obtained 
    } 
    Console.WriteLine("Summation of first 5 elements: " + sum); 
  } 
}
Value is: 0
Value is: 1
Value is: 2
Value is: 3
Value is: 4
Summation of first 5 elements: 10
---------------------------
using System; 
 
class MainClass { 
  public static void Main() { 
    int sum = 0; 
    int[,] nums = new int[3,5]; 
 
    for(int i = 0; i < 3; i++)  
      for(int j=0; j < 5; j++) 
        nums[i,j] = (i+1)*(j+1); 
 
    foreach(int x in nums) { 
      Console.WriteLine("Value is: " + x); 
      sum += x; 
    } 
    Console.WriteLine("Summation: " + sum); 
  } 
}
Value is: 1
Value is: 2
Value is: 3
Value is: 4
Value is: 5
Value is: 2
Value is: 4
Value is: 6
Value is: 8
Value is: 10
Value is: 3
Value is: 6
Value is: 9
Value is: 12
Value is: 15
Summation: 90
--------------------------
using System; 
 
class MainClass { 
  public static void Main() { 
    int[] nums = new int[10]; 
    int val; 
    bool found = false; 
 
    for(int i = 0; i < 10; i++)  
      nums[i] = i; 
 
    val = 5; 
 
    foreach(int x in nums) { 
      if(x == val) { 
        found = true; 
        break; 
      } 
    } 
 
    if(found)  
      Console.WriteLine("Value found!"); 
  } 
}
Value found!
*/
