// j2sc#1103.cs: 'ICollection<T>, new Collection<T>()' ve 'BitArray, new BitArray(byte)' örneði.

using System;
using System.Collections;
using System.Collections.Generic; //ICollection<T> için
using System.Collections.ObjectModel; //new Collection için
namespace VeriYapýlarý {
    class VeriYapýsý3 {
        static void Main() {
            Console.Write ("<T> tip için 'using System.Collections.Generic' gereklidir. BitArray'e atanan byte[0,127] deðer, 8 adet true/false'a çevrilir ve aralarýnda Not/Deðil, And/Ve, Or/Veya, Xor/Farklýysa iþlemleri mümkündür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("<T>ipli ICollection referanslý 'new Collection' tiplemeleri yaratma:");
            int i, ts1; var r=new Random();
            ICollection<int> ak1 = new Collection<int>();
            ICollection<string> ak2 = new Collection<string>();
            for(i=0;i<25;i++) {
                ts1=r.Next(1, 25); ak1.Add (ts1);
                ts1=r.Next(0, 26); ak2.Add (((char)(ts1+65)).ToString()+((char)(ts1+97)).ToString());
            }
            foreach(int ts in ak1) Console.Write (ts+" "); Console.WriteLine();
            foreach(string dzg in ak2) Console.Write (dzg+" "); Console.WriteLine();
            ts1=r.Next(1, 25);
            Console.WriteLine ("ak1({0}) mevcut mu? {1}", ts1, ak1.Contains (ts1));
            Console.WriteLine ("ak2({0}) mevcut mu? {1}", "Bb", ak2.Contains ("Bb"));
            if (ak1.Contains (ts1)) {ak1.Remove (ts1); Console.WriteLine ("ak1({0}) silindi.", ts1);}
            if (ak2.Contains ("Bb")) {ak2.Remove ("Bb"); Console.WriteLine ("ak2({0}) silindi.", "Bb");}

            Console.WriteLine ("\nak1'den dz1'e ve dz1'den de tüm diðer koleksiyonlara kopyalamalar:");
            int[] dz1 = new int [ak1.Count]; ak1.CopyTo (dz1, 0);
            string[] dz2 = new string [ak2.Count]; ak2.CopyTo (dz2, 0);
            for(i=0;i<dz1.Length;i++) Console.Write (dz1 [i] + " "); Console.WriteLine();
            for(i=0;i<dz2.Length;i++) Console.Write (dz2 [i] + " "); Console.WriteLine();
            ArrayList dl = new ArrayList(); dl.AddRange (dz1);
            Array d = (Array)dz1;
            IList ls = (IList)dz1;
            ICollection ik = (ICollection)dz1;
            ICollection<int> ikt = (ICollection<int>)dz1;
            IEnumerable ie = (IEnumerable)dz1;
            IEnumerable<int> iet = (IEnumerable<int>)dz1;

            Console.WriteLine ("\nÝki farklý BitArray'le mantýksal Not, Or, Xor, And iþlemleri:");
            ts1=r.Next(0, 128); byte[] b1 = {(byte)ts1}; BitArray ba1 = new BitArray (b1);
            Console.Write ("ba1({0}): ", ts1); for(i=0;i< ba1.Count;i++) Console.Write ("{0, -5} ", ba1 [i]); Console.WriteLine();
            ts1=r.Next(0, 128); b1[0] = (byte)ts1; BitArray ba2 = new BitArray (b1); 
            Console.Write ("ba2({0}): ", ts1); for(i=0;i< ba2.Count;i++) Console.Write ("{0, -5} ", ba2 [i]); Console.WriteLine();
            BitArray ba3 =  ba1.Not();
            Console.Write ("ba1.Not(): "); for(i=0;i<ba3.Count;i++) Console.Write ("{0, -5} ", ba3 [i]); Console.WriteLine();
            ba3 = ba1.Or(ba2);
            Console.Write ("ba1.Or(ba2): "); for(i=0;i<ba3.Count;i++) Console.Write ("{0, -5} ", ba3 [i]); Console.WriteLine();
            ba3 = ba1.Xor(ba2);
            Console.Write ("ba1.Xor(ba2): "); for(i=0;i<ba3.Count;i++) Console.Write ("{0, -5} ", ba3 [i]); Console.WriteLine();
            ba3 = ba1.Not().Xor(ba2).And(ba1);
            Console.Write ("ba1.Not().Xor(ba2).And(ba1): "); for(i=0;i<ba3.Count;i++) Console.Write ("{0, -5} ", ba3 [i]); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}