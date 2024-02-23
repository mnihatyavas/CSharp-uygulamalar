// j2sc#1106c.cs: LinkedList<T> AddFirst/Last/Before/After ekleme ve düðme takibi örneði.

using System;
using System.Collections.Generic;
namespace VeriYapýlarý {
    class VeriYapýsý6C {
        public static void ÖzellikleriGöster (LinkedListNode<String> bðLst )  {
            Console.WriteLine ("\t==>Yeni inceleme:");
            if (bðLst.List == null) Console.WriteLine ("Düðüm hiçbir listeye baðlý deðil.");
            else Console.WriteLine ("Düðüm {0} elemanlý bir baðlý listeye ait.", bðLst.List.Count);
            if (bðLst.Previous == null) Console.WriteLine ("Önceki düðüm hiç'tir.");
            else Console.WriteLine ("Önceki düðümün deðeri: {0}", bðLst.Previous.Value);
            Console.WriteLine ("Aktüel düðmenin deðeri: {0}", bðLst.Value);
            if (bðLst.Next == null) Console.WriteLine ("Sonraki düðüm hiç'tir.");
            else Console.WriteLine ("Sonraki düðümün deðeri: {0}", bðLst.Next.Value);
        }
        static void Main() {
            Console.Write ("List<T> için referans IList<T>, tipleme ise List<T>'dir. LinkedList<T>/BaðlýListe.AddBefore/After'da ilk argüman baðlýListe.First/Last gibi bir Node/düðüm olmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("IList<double> referanslý 'new List<double>()' tiplemeli baðlýListe sunumlarý:");
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
            Console.WriteLine ("Remove ({0}) silindi mi?: {1}", ds1, silindiMi?"Evet":"Hayýr");
            for(i=0;i<iListe.Count;i++) Console.Write (iListe [i]+"  "); Console.WriteLine();
            Console.WriteLine ("Ortadakinin deðeri: " + (ds1=iListe [iListe.Count/2]));
            Console.WriteLine ("Ortadakinin endeksi: " + iListe.IndexOf (ds1));
            Console.WriteLine ("'2023.1231'in endeksi: " + iListe.IndexOf (2023.1231));

            Console.WriteLine ("\nLinkedList<T> ile AddFirst/Last/Before/After ve Node-while:");
            LinkedList<int> baðlýListe = new LinkedList<int>();
            for(i=0;i<10;i++) {
                ts1=r.Next(-100, 1000);
                baðlýListe.AddLast (ts1);
            }
            ts1=r.Next(-100, 1000); baðlýListe.AddFirst (ts1);
            ts1=r.Next(-100, 1000); baðlýListe.AddAfter (baðlýListe.First, ts1);
            ts1=r.Next(-100, 1000); baðlýListe.AddFirst (ts1);
            ts1=r.Next(-100, 1000); baðlýListe.AddLast (ts1);
            ts1=r.Next(-100, 1000); baðlýListe.AddBefore (baðlýListe.Last, ts1);
            LinkedListNode<int> düðüm = baðlýListe.First;
            while (düðüm != null) {
                Console.Write (düðüm.Value+" ");
                düðüm = düðüm.Next;
            } Console.WriteLine();

            Console.WriteLine ("\nLinkedList<char>' karakter ekleme, silme ve for/foreach suumlarý:");
            LinkedList<char> bðLst1 = new LinkedList<char>();
            for(i=0;i<20;i++) {
                ts1=r.Next(0, 26);
                bðLst1.AddFirst ((char)(ts1+65));
            }
            LinkedListNode<char> dðm; Console.Write ("{0} karakter: ", bðLst1.Count);
            for (dðm = bðLst1.First; dðm != null; dðm = dðm.Next) Console.Write (dðm.Value + " "); Console.WriteLine();
            Console.Write ("foreach'le: "); foreach (char k in bðLst1) Console.Write (k + " "); Console.WriteLine();
            Console.Write ("for-dðm'le tersten: "); for (dðm = bðLst1.Last; dðm != null; dðm = dðm.Previous) Console.Write (dðm.Value + " "); Console.WriteLine();
            bðLst1.Remove ('a'); bðLst1.Remove ((char)(ts1+65)); bðLst1.Remove (bðLst1.First);  bðLst1.Remove (bðLst1.Last);
            Console.WriteLine ("Silinenler sonrasý karakter sayýsý: {0}", bðLst1.Count);
            for(i=0;i<=21-bðLst1.Count;i++) {
                ts1=r.Next(0, 26);
                bðLst1.AddLast ((char)(ts1+65));
            }
            Console.Write ("{0} karakter: ", bðLst1.Count); foreach (char k in bðLst1) Console.Write (k + " "); Console.WriteLine();

            Console.WriteLine ("\nBaðsýz ve listeye baðlanan düðümün aþamalý özellikleri:");
            LinkedListNode<String> bðLst2 = new LinkedListNode<String> ("Nihat");
            ÖzellikleriGöster (bðLst2);
            LinkedList<String> bðLst2a = new LinkedList<String>();
            bðLst2a.AddLast (bðLst2);
            ÖzellikleriGöster (bðLst2);
            bðLst2a.AddFirst ("Nihal");
            bðLst2a.AddLast ("Canan");
            ÖzellikleriGöster (bðLst2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}