// j2sc#1101a.cs: Dizi, tipi, ebat�, elemanlar�, endeksi, eri�im ve d�k�m �rne�i.

using System;
using System.Collections.Generic; //IEnumerable i�in
using System.Linq; //SequenceEqual i�in
namespace VeriYap�lar� {
    class VeriYap�s�1A {
        private static void Yaz<T>(IEnumerable<T> ��eler) {foreach (T ��e in ��eler) Console.WriteLine (��e);}
        public static void EndeksliDe�erleriYaz (ArraySegment<String> diziPar�as�) {
            for (int i = diziPar�as�.Offset; i < (diziPar�as�.Offset + diziPar�as�.Count); i++) Console.Write ("[{0}]={1} ", i, diziPar�as�.Array [i]);
            Console.WriteLine();
        }
        public static void EndeksliDe�erleriYaz (String[] dizi) {
            for (int i = 0; i < dizi.Length; i++) Console.Write ("[{0}]={1} ", i, dizi[i]);
            Console.WriteLine();
        }
        static void Main() {
            Console.Write ("Dizi ayn� adl� ve tipli de�erler koleksiyonudur, ilk endeksi=0 olup ebat�=dizi.Length'tir. �zellikler: IsFixedSize, IsReadOnly, IsSynchronized, Length, Rank, SyncRoot. Metotlar: BinarySearch, Clear, Clone, Copy, CopyTo, CreateInstance, Equals, GetEnumerator, GetLength, GetLowerBound, GetHashCode, GetTypeCode, GetUpperBound, GetValue, IndexOf, Initialize, LastIndexOf, Reverse, SetValue, Sort.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("57 elemanl� 'int tsDizi' dizisine veri koyma ve okuma:");
            int[] tsDizi = new int [58];
            int i, ts1, ts2;
            for(i = 0; i < 58; i = i+1) tsDizi [i] = i+1881;
            for(i=0;i<tsDizi.Length;i++) Console.Write ("tsDizi[{0}]={1}, ", i, tsDizi [i]);

            Console.WriteLine ("\n\nEbat� ekleme/��karmayla de�i�ebilen programlama dilleri dizisi:");
            string[] diller = new string[]{"Basic", "Fortran", "PL/1", "Cobol", "T.Pascal", "C", "C++", "Assembler", "Visual Basic", "C#", "Java", "Python", "HTML-CSS-JS"};
            for(i=0;i<diller.Length;i++) Console.Write ("{0}) {1}, ", i+1, diller [i]);
            Console.WriteLine ("\n�lk, orta, son diller: ({0}, {1}, {2})", diller [0], diller [diller.Length/2], diller [diller.Length-1]);

            Console.WriteLine ("\nDizi elemanlar�n� genel tiplemeli foreach'le d�k�mleme:");
            var d�nyaKupa2006Final = new[]{
                new {
                    Tak�mAd� = "Fransa",
                    Oyuncular = new string[]{"A","B","C","D","E","F","G","H","I","J","K","L",}
                },
                new {
                    Tak�mAd� = "�talya",
                    Oyuncular = new string[]{"M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",}
                },
                new {
                    Tak�mAd� = "T�rkiye",
                    Oyuncular = new string[]{"C","�","G","�","I","�","S","�","U","�","O","�",}
                }
            };
            Yaz (d�nyaKupa2006Final);

            Console.WriteLine ("\nRasgele ebatl� dizinin rasgele elemanlar�n�n toplam� ve ortalamas�:");
            var r=new Random();
            ts1=r.Next(2,100);
            int[] say�lar = new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(0,1000); say�lar [i]=ts2; Console.Write (ts2+", ");}
            ts2=0; for(i=0;i<ts1;i++) {ts2 +=say�lar [i];}
            Console.WriteLine ("\n{0} adet rasgele say�lar toplam� = {1},\tOrtalamas� = {2}", ts1, ts2, ts2/ts1);

            Console.WriteLine ("\nA-->Z harf dizgesini dizile�tirip d�z/ters d�k�mleme:");
            string dizge = "";
            for(i=0;i<26;i++) dizge += (char)(i+65) + " ";
            dizge=dizge.Substring (0, dizge.Length-1); Console.WriteLine ("Dizge: \"{0}\"", dizge); 
            string[] harfler = dizge.Split (' ');
            Console.WriteLine ("Ba�tan sona harfler: ");
            foreach (object harf in harfler) Console.Write (harf + ",  ");
            Console.WriteLine ("\nSondan ba�a harfler: ");
            for(i=harfler.Length-1;i>=0;i--) Console.Write (harfler [i] + ",  ");

            Console.WriteLine ("\n\n�stteki rasgele ebat ve say�l� tamsay� dizi �zellikleri:");
            Console.WriteLine ("Dizi ebat�: {0}", say�lar.Length);
            Console.WriteLine ("Dizinin tipi: {0}", say�lar.GetType());
            Console.WriteLine ("Dizi ka� boyutlu: {0}", say�lar.Rank);
            Console.WriteLine ("Dizinin ilk boyut uzunlu�u: {0}", say�lar.GetLength (0));

            Console.WriteLine ("\nA-Z diziyi iki ayr� metotla tam, orta dilimli, eleman de�i�imli yazma:");
            string[] dizi = harfler;
            ArraySegment<String> t�mDizi = new ArraySegment<String> (dizi);
            EndeksliDe�erleriYaz (t�mDizi);
            ArraySegment<String> ortaDizi = new ArraySegment<String> (dizi, harfler.Length/4, harfler.Length/2);
            EndeksliDe�erleriYaz (ortaDizi);
            t�mDizi.Array [harfler.Length/2] = "M.Nihat Yava�";
            EndeksliDe�erleriYaz (ortaDizi);

            Console.WriteLine ("\nT�m elemanlar� e�it olan ve olmayan dizilerin kar��la�t�r�lmas�:");
            String[] dizi1 = dizge.Split (' ');
            String[] dizi2 = dizge.Split (' ');
            bool e�itMi = dizi1.SequenceEqual (dizi2);
            Console.WriteLine ("dizi1({0}) = dizi2({1}): {2}", String.Join("",dizi1), String.Join("",dizi2), e�itMi.ToString());
            dizi2 [dizi2.Length-1]="X"; dizi2 [dizi2.Length-2]="X"; e�itMi = dizi1.SequenceEqual (dizi2);
            Console.WriteLine ("dizi1({0}) = dizi2({1}): {2}", String.Join("",dizi1), String.Join("",dizi2), e�itMi.ToString());


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}