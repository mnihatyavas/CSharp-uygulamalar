// j2sc#1106c.cs: LinkedList<T> AddFirst/Last/Before/After ekleme ve d��me takibi �rne�i.

using System;
using System.Collections.Generic;
namespace VeriYap�lar� {
    class VeriYap�s�6C {
        public static void �zellikleriG�ster (LinkedListNode<String> b�Lst )  {
            Console.WriteLine ("\t==>Yeni inceleme:");
            if (b�Lst.List == null) Console.WriteLine ("D���m hi�bir listeye ba�l� de�il.");
            else Console.WriteLine ("D���m {0} elemanl� bir ba�l� listeye ait.", b�Lst.List.Count);
            if (b�Lst.Previous == null) Console.WriteLine ("�nceki d���m hi�'tir.");
            else Console.WriteLine ("�nceki d���m�n de�eri: {0}", b�Lst.Previous.Value);
            Console.WriteLine ("Akt�el d��menin de�eri: {0}", b�Lst.Value);
            if (b�Lst.Next == null) Console.WriteLine ("Sonraki d���m hi�'tir.");
            else Console.WriteLine ("Sonraki d���m�n de�eri: {0}", b�Lst.Next.Value);
        }
        static void Main() {
            Console.Write ("List<T> i�in referans IList<T>, tipleme ise List<T>'dir. LinkedList<T>/Ba�l�Liste.AddBefore/After'da ilk arg�man ba�l�Liste.First/Last gibi bir Node/d���m olmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IList<double> referansl� 'new List<double>()' tiplemeli ba�l�Liste sunumlar�:");
            int i, ts1; double ds1; var r=new Random();
            IList<double> iListe = new List<double>();
            for(i=0;i<9;i++) {
                ds1=r.Next(-100, 1000)+r.Next(10,100)/100d;
                iListe.Add (ds1);
            }
            ds1=r.Next(-100, 1000)+r.Next(10,100)/100d;iListe.Insert (3, ds1);
            bool silindiMi=iListe.Remove (2023.1231);
            Console.WriteLine ("Remove (2023.1231) silindi mi?: " + silindiMi);
            silindiMi=iListe.Remove (ds1);
            Console.WriteLine ("Remove ({0}) silindi mi?: {1}", ds1, silindiMi?"Evet":"Hay�r");
            for(i=0;i<iListe.Count;i++) Console.Write (iListe [i]+"  "); Console.WriteLine();
            Console.WriteLine ("Ortadakinin de�eri: " + (ds1=iListe [iListe.Count/2]));
            Console.WriteLine ("Ortadakinin endeksi: " + iListe.IndexOf (ds1));
            Console.WriteLine ("'2023.1231'in endeksi: " + iListe.IndexOf (2023.1231));

            Console.WriteLine ("\nLinkedList<T> ile AddFirst/Last/Before/After ve Node-while:");
            LinkedList<int> ba�l�Liste = new LinkedList<int>();
            for(i=0;i<10;i++) {
                ts1=r.Next(-100, 1000);
                ba�l�Liste.AddLast (ts1);
            }
            ts1=r.Next(-100, 1000); ba�l�Liste.AddFirst (ts1);
            ts1=r.Next(-100, 1000); ba�l�Liste.AddAfter (ba�l�Liste.First, ts1);
            ts1=r.Next(-100, 1000); ba�l�Liste.AddFirst (ts1);
            ts1=r.Next(-100, 1000); ba�l�Liste.AddLast (ts1);
            ts1=r.Next(-100, 1000); ba�l�Liste.AddBefore (ba�l�Liste.Last, ts1);
            LinkedListNode<int> d���m = ba�l�Liste.First;
            while (d���m != null) {
                Console.Write (d���m.Value+" ");
                d���m = d���m.Next;
            } Console.WriteLine();

            Console.WriteLine ("\nLinkedList<char>' karakter ekleme, silme ve for/foreach suumlar�:");
            LinkedList<char> b�Lst1 = new LinkedList<char>();
            for(i=0;i<20;i++) {
                ts1=r.Next(0, 26);
                b�Lst1.AddFirst ((char)(ts1+65));
            }
            LinkedListNode<char> d�m; Console.Write ("{0} karakter: ", b�Lst1.Count);
            for (d�m = b�Lst1.First; d�m != null; d�m = d�m.Next) Console.Write (d�m.Value + " "); Console.WriteLine();
            Console.Write ("foreach'le: "); foreach (char k in b�Lst1) Console.Write (k + " "); Console.WriteLine();
            Console.Write ("for-d�m'le tersten: "); for (d�m = b�Lst1.Last; d�m != null; d�m = d�m.Previous) Console.Write (d�m.Value + " "); Console.WriteLine();
            b�Lst1.Remove ('a'); b�Lst1.Remove ((char)(ts1+65)); b�Lst1.Remove (b�Lst1.First);  b�Lst1.Remove (b�Lst1.Last);
            Console.WriteLine ("Silinenler sonras� karakter say�s�: {0}", b�Lst1.Count);
            for(i=0;i<=21-b�Lst1.Count;i++) {
                ts1=r.Next(0, 26);
                b�Lst1.AddLast ((char)(ts1+65));
            }
            Console.Write ("{0} karakter: ", b�Lst1.Count); foreach (char k in b�Lst1) Console.Write (k + " "); Console.WriteLine();

            Console.WriteLine ("\nBa�s�z ve listeye ba�lanan d���m�n a�amal� �zellikleri:");
            LinkedListNode<String> b�Lst2 = new LinkedListNode<String> ("Nihat");
            �zellikleriG�ster (b�Lst2);
            LinkedList<String> b�Lst2a = new LinkedList<String>();
            b�Lst2a.AddLast (b�Lst2);
            �zellikleriG�ster (b�Lst2);
            b�Lst2a.AddFirst ("Nihal");
            b�Lst2a.AddLast ("Canan");
            �zellikleriG�ster (b�Lst2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}