// j2sc#1101a.cs: Dizi, tipi, ebatý, elemanlarý, endeksi, eriþim ve döküm örneði.

using System;
using System.Collections.Generic; //IEnumerable için
using System.Linq; //SequenceEqual için
namespace VeriYapýlarý {
    class VeriYapýsý1A {
        private static void Yaz<T>(IEnumerable<T> öðeler) {foreach (T öðe in öðeler) Console.WriteLine (öðe);}
        public static void EndeksliDeðerleriYaz (ArraySegment<String> diziParçasý) {
            for (int i = diziParçasý.Offset; i < (diziParçasý.Offset + diziParçasý.Count); i++) Console.Write ("[{0}]={1} ", i, diziParçasý.Array [i]);
            Console.WriteLine();
        }
        public static void EndeksliDeðerleriYaz (String[] dizi) {
            for (int i = 0; i < dizi.Length; i++) Console.Write ("[{0}]={1} ", i, dizi[i]);
            Console.WriteLine();
        }
        static void Main() {
            Console.Write ("Dizi ayný adlý ve tipli deðerler koleksiyonudur, ilk endeksi=0 olup ebatý=dizi.Length'tir. Özellikler: IsFixedSize, IsReadOnly, IsSynchronized, Length, Rank, SyncRoot. Metotlar: BinarySearch, Clear, Clone, Copy, CopyTo, CreateInstance, Equals, GetEnumerator, GetLength, GetLowerBound, GetHashCode, GetTypeCode, GetUpperBound, GetValue, IndexOf, Initialize, LastIndexOf, Reverse, SetValue, Sort.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("57 elemanlý 'int tsDizi' dizisine veri koyma ve okuma:");
            int[] tsDizi = new int [58];
            int i, ts1, ts2;
            for(i = 0; i < 58; i = i+1) tsDizi [i] = i+1881;
            for(i=0;i<tsDizi.Length;i++) Console.Write ("tsDizi[{0}]={1}, ", i, tsDizi [i]);

            Console.WriteLine ("\n\nEbatý ekleme/çýkarmayla deðiþebilen programlama dilleri dizisi:");
            string[] diller = new string[]{"Basic", "Fortran", "PL/1", "Cobol", "T.Pascal", "C", "C++", "Assembler", "Visual Basic", "C#", "Java", "Python", "HTML-CSS-JS"};
            for(i=0;i<diller.Length;i++) Console.Write ("{0}) {1}, ", i+1, diller [i]);
            Console.WriteLine ("\nÝlk, orta, son diller: ({0}, {1}, {2})", diller [0], diller [diller.Length/2], diller [diller.Length-1]);

            Console.WriteLine ("\nDizi elemanlarýný genel tiplemeli foreach'le dökümleme:");
            var dünyaKupa2006Final = new[]{
                new {
                    TakýmAdý = "Fransa",
                    Oyuncular = new string[]{"A","B","C","D","E","F","G","H","I","J","K","L",}
                },
                new {
                    TakýmAdý = "Ýtalya",
                    Oyuncular = new string[]{"M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",}
                },
                new {
                    TakýmAdý = "Türkiye",
                    Oyuncular = new string[]{"C","Ç","G","Ð","I","Ý","S","Þ","U","Ü","O","Ö",}
                }
            };
            Yaz (dünyaKupa2006Final);

            Console.WriteLine ("\nRasgele ebatlý dizinin rasgele elemanlarýnýn toplamý ve ortalamasý:");
            var r=new Random();
            ts1=r.Next(2,100);
            int[] sayýlar = new int [ts1];
            for(i=0;i<ts1;i++) {ts2=r.Next(0,1000); sayýlar [i]=ts2; Console.Write (ts2+", ");}
            ts2=0; for(i=0;i<ts1;i++) {ts2 +=sayýlar [i];}
            Console.WriteLine ("\n{0} adet rasgele sayýlar toplamý = {1},\tOrtalamasý = {2}", ts1, ts2, ts2/ts1);

            Console.WriteLine ("\nA-->Z harf dizgesini dizileþtirip düz/ters dökümleme:");
            string dizge = "";
            for(i=0;i<26;i++) dizge += (char)(i+65) + " ";
            dizge=dizge.Substring (0, dizge.Length-1); Console.WriteLine ("Dizge: \"{0}\"", dizge); 
            string[] harfler = dizge.Split (' ');
            Console.WriteLine ("Baþtan sona harfler: ");
            foreach (object harf in harfler) Console.Write (harf + ",  ");
            Console.WriteLine ("\nSondan baþa harfler: ");
            for(i=harfler.Length-1;i>=0;i--) Console.Write (harfler [i] + ",  ");

            Console.WriteLine ("\n\nÜstteki rasgele ebat ve sayýlý tamsayý dizi özellikleri:");
            Console.WriteLine ("Dizi ebatý: {0}", sayýlar.Length);
            Console.WriteLine ("Dizinin tipi: {0}", sayýlar.GetType());
            Console.WriteLine ("Dizi kaç boyutlu: {0}", sayýlar.Rank);
            Console.WriteLine ("Dizinin ilk boyut uzunluðu: {0}", sayýlar.GetLength (0));

            Console.WriteLine ("\nA-Z diziyi iki ayrý metotla tam, orta dilimli, eleman deðiþimli yazma:");
            string[] dizi = harfler;
            ArraySegment<String> tümDizi = new ArraySegment<String> (dizi);
            EndeksliDeðerleriYaz (tümDizi);
            ArraySegment<String> ortaDizi = new ArraySegment<String> (dizi, harfler.Length/4, harfler.Length/2);
            EndeksliDeðerleriYaz (ortaDizi);
            tümDizi.Array [harfler.Length/2] = "M.Nihat Yavaþ";
            EndeksliDeðerleriYaz (ortaDizi);

            Console.WriteLine ("\nTüm elemanlarý eþit olan ve olmayan dizilerin karþýlaþtýrýlmasý:");
            String[] dizi1 = dizge.Split (' ');
            String[] dizi2 = dizge.Split (' ');
            bool eþitMi = dizi1.SequenceEqual (dizi2);
            Console.WriteLine ("dizi1({0}) = dizi2({1}): {2}", String.Join("",dizi1), String.Join("",dizi2), eþitMi.ToString());
            dizi2 [dizi2.Length-1]="X"; dizi2 [dizi2.Length-2]="X"; eþitMi = dizi1.SequenceEqual (dizi2);
            Console.WriteLine ("dizi1({0}) = dizi2({1}): {2}", String.Join("",dizi1), String.Join("",dizi2), eþitMi.ToString());


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}