// j2sc#1801c.cs: Stack yýðýna Push, Peek ve Pop'la kayýt koyma/alma örneði.

using System;
using System.Collections.Generic;
namespace SoysalListe {
    class Sýnýfým {
        int n;
        public Sýnýfým (int i) {n=i;} //Kurucu
        public override string ToString() {return "Benim "+n+".sýnýfým";}
    }
    class Yýðýným<T> {
        int AzamiYýðýn = 1938-1881+1;
        T[] YýðýnDizi;
        public int YýðýnGöstergeç = 0;
        public Yýðýným() {YýðýnDizi = new T [AzamiYýðýn];} //Kurucu
        public void ÜsteKoy (T x) {if (YýðýnGöstergeç < AzamiYýðýn) YýðýnDizi [YýðýnGöstergeç++] = x;}
        public T ÜsttenÇýkar() {return (YýðýnGöstergeç > 0)? YýðýnDizi [--YýðýnGöstergeç] : YýðýnDizi [0];}
        public void Göster() {for(int i = YýðýnGöstergeç - 1; i >= 0; i--) Console.Write (YýðýnDizi [i] + " "); Console.WriteLine();}
    }
    class Yýðýn {
        static void Main() {
            Console.Write ("Stack yýðýna kayýtlar Push'la üstüste yýðýlýrken, Peek'le üstteki gözlenir, Pop'la da üstten alta boþaltýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal Stack<Sýnýfým> yýðýna üstüste kayýt ekleme ve üstten çýkarma:");
            Stack<Sýnýfým> yýðýn = new Stack<Sýnýfým>();
            int i, n;
            Console.WriteLine ("Yýðýn'daki ilk kayýt sayýsý: " + yýðýn.Count);
            for(i=1;i<=5;i++) {
                yýðýn.Push (new Sýnýfým (i));
                Sýnýfým snf = yýðýn.Peek();
                Console.WriteLine ("Push'lanan kayda peek: [{0}]\tArtan kayýt sayýsý: {1}", snf, yýðýn.Count);
            }
            //Liste ve koleksiyonlar gibi yýðýna endeksle eriþilemez...
            //Console.Write ("==>Alttan üste endeksli kayýtlar: "); for(i=0;i<yýðýn.Count;i++) Console.WriteLine (yýðýn [i]);
            //Console.Write ("==>Üstten alta endeksli kayýtlar: "); for(i=yýðýn.Count-1;i>=0;i--) Console.WriteLine (yýðýn [i]);
            for(i=0;i<5;i++) {
                Sýnýfým snf = yýðýn.Pop();
                Console.WriteLine ("Pop'lanan kayýt: [{0}]\tKalan kayýt sayýsý: {1}", snf, yýðýn.Count);
            }

            Console.WriteLine ("\nPush:ÜsteKoy ve Pop:ÜsttenÇýkar'la kendi özel soysal<T> yýðýnýmýz:");
            Yýðýným<int> TamsayýYýðýn = new Yýðýným<int>();
            Yýðýným<string> DizgeYýðýn = new Yýðýným<string>();
            Console.WriteLine ("==>TamsayýYýðýn'daki ilk kayýt sayýsý: " + TamsayýYýðýn.YýðýnGöstergeç);
            for(i=1881;i<=1938;i++) TamsayýYýðýn.ÜsteKoy (i);
            Console.WriteLine ("==>TamsayýYýðýn'daki ÜsteKoy/Push sonrasý kayýt sayýsý: " + TamsayýYýðýn.YýðýnGöstergeç);
            Console.Write ("YýðýnDizi'yle yýllar: "); TamsayýYýðýn.Göster();
            Console.WriteLine ("==>TamsayýYýðýn'daki Göster/YýðýnDizi sonrasý kayýt sayýsý: " + TamsayýYýðýn.YýðýnGöstergeç);
            Console.Write ("ÜsttenÇýkar()'la yýllar: "); n=TamsayýYýðýn.YýðýnGöstergeç; for(i=0;i<n;i++) Console.Write (TamsayýYýðýn.ÜsttenÇýkar()+" "); Console.WriteLine();
            Console.WriteLine ("==>TamsayýYýðýn'daki ÜsttenÇýkar/Pop sonrasý kayýt sayýsý: " + TamsayýYýðýn.YýðýnGöstergeç);
            Console.WriteLine ("==>DizgeYýðýn'daki ilk kayýt sayýsý: " + DizgeYýðýn.YýðýnGöstergeç);
            for(i=1919;i<=1938;i++) DizgeYýðýn.ÜsteKoy ("Atatürk"+"-"+i);
            Console.WriteLine ("==>DizgeYýðýn'daki ÜsteKoy/Push sonrasý kayýt sayýsý: " + DizgeYýðýn.YýðýnGöstergeç);
            Console.Write ("YýðýnDizi'yle dizgeler: "); DizgeYýðýn.Göster();
            Console.WriteLine ("==>DizgeYýðýn'daki Göster/YýðýnDizi sonrasý kayýt sayýsý: " + DizgeYýðýn.YýðýnGöstergeç);
            Console.Write ("ÜsttenÇýkar()'la dizgeler: "); n=DizgeYýðýn.YýðýnGöstergeç; for(i=0;i<n;i++) Console.Write (DizgeYýðýn.ÜsttenÇýkar()+" "); Console.WriteLine();
            Console.WriteLine ("==>DizgeYýðýn'daki ÜsttenÇýkar/Pop sonrasý kayýt sayýsý: " + DizgeYýðýn.YýðýnGöstergeç);

            Console.WriteLine ("\nPush, Peek ve Pop'la yýðýn kayýt üsteleme, gözetme ve eksiltme:");
            Stack<string> yýðýn2 = new Stack<string>();
            Console.WriteLine ("==>Dizgesel yýðýn2'deki ilk kayýt sayýsý: " + yýðýn2.Count);
            Console.Write ("Kayýt Push: ");
            for(i=1957;i<=2024;i++) {
                yýðýn2.Push ("Nihat-"+i);
                Console.Write (yýðýn2.Peek()+" ");
            }
            Console.WriteLine ("\n==>Dizgesel yýðýn2'deki Push sonrasý kayýt sayýsý: " + yýðýn2.Count);
            Console.Write ("Kayýt Pop: ");
            while(yýðýn2.Count > 0) Console.Write (yýðýn2.Pop() + " ");
            Console.WriteLine ("\n==>Dizgesel yýðýn2'deki Pop sonrasý kayýt sayýsý: " + yýðýn2.Count);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}