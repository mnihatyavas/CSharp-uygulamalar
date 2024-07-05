// j2sc#1801b.cs: Soysal<T> normal, delegeli ve aksiyonlu koleksiyonlar örneði.

using System;
using System.Collections.Generic; //IList<T> için
using System.Collections.ObjectModel; //Collection<T> için
namespace SoysalListe {
    class ÇevirenKoleksiyon<T> : Collection<T> {
        private Converter<T,T> çevir; //delegeyle büyükharfle
        public ÇevirenKoleksiyon (Converter<T,T> çevir) {this.çevir = çevir;} //Kuucu
        protected override void InsertItem (int endeks, T kayýt) {base.InsertItem (endeks, çevir (kayýt));}
    }
    class EylemKoleksiyou<T> : Collection<T> {
        private Action<T> eylem; //konsoldan yansýt
        public EylemKoleksiyou (Action<T> eylem) {this.eylem = eylem;}
        protected override void InsertItem (int e, T k) {eylem (k); base.InsertItem (e, k);}
    }
    class Koleksiyon {
        static void Main() {
            Console.Write ("'Collection<T> k = new Collection<T>()' ile yaratýlan koleksiyona 'k.Add(kyt)'la T tipli kayýtlar eklenir. Özel delegeli ve eylemli koleksiyonlar da mümkündür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Collection<T> ve Collection<Collection<T>> ile yýllar ve adlar:");
            var r=new Random(); int i, j, ts; string ad;
            Collection<int> yýllar = new Collection<int>();
            for(i=0;i<5;i++) {
                ts=r.Next(1900,2025);
                yýllar.Add (ts);
            }
            Console.Write ("Yýllar: "); for(i=0;i<5;i++) Console.Write (yýllar [i] + " "); Console.WriteLine();
            Collection<string> adlar = new Collection<string>();
            for(i=0;i<5;i++) {
                ad="";
                for(j=0;j<7;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                adlar.Add (ad);
            }
            Console.Write ("Adlar: "); for(i=0;i<5;i++) Console.Write (adlar [i] + " "); Console.WriteLine();
            Collection<Collection<int>> yýllar2 = new Collection<Collection<int>>();
            yýllar2.Add (yýllar);
            Console.Write ("Yýllar-2: "); for(i=0;i<yýllar2.Count;i++) for(j=0;j<yýllar2 [0].Count;j++) Console.Write (yýllar2 [i] [j] + " "); Console.WriteLine();
            Collection<Collection<string>> adlar2 = new Collection<Collection<string>>();
            adlar2.Add (adlar);
            Console.Write ("Adlar-2: "); for(i=0;i<adlar2.Count;i++) for(j=0;j<adlar2 [i].Count;j++)Console.Write (adlar2 [i] [j] + " "); Console.WriteLine();
            IList<int> yýlListe = yýllar;
            Console.Write ("Yýllar listesi: "); foreach(int yýl in yýlListe) Console.Write (yýl+" "); Console.WriteLine();
            IList<string> adListe = adlar;
            Console.Write ("Adlar listesi: "); foreach(string a in adListe) Console.Write (a+" "); Console.WriteLine();

            Console.WriteLine ("\nKayýtlarý delegeli büyükharfleyen çevirici koleksiyon:");
            ÇevirenKoleksiyon<string> çk = new ÇevirenKoleksiyon<string> (delegate (string kayýt) {return kayýt.ToUpper();});
            çk.Add ("Merhaba"); çk.Add ("Nihal"); çk.Add ("bugün"); çk.Add ("nasýlsýn"); çk.Add ("iyi misin?");
            Console.Write ("Düz kayýtlar: "); foreach (string kayýt in çk) Console.Write (kayýt+" "); Console.WriteLine();
            Console.Write ("Ters kayýtlar: "); for(i=çk.Count-1;i>=0;i--) Console.Write (çk [i]+" "); Console.WriteLine();

            Console.WriteLine ("\nKayýtlarý eklerken konsola çýktýlayan eylem koleksiyonu:");
            EylemKoleksiyou <string> ek = new EylemKoleksiyou<string> (Console.WriteLine);
            ek.Add ("Merhaba"); ek.Add ("Nihal"); ek.Add ("bugün"); ek.Add ("nasýlsýn"); ek.Add ("iyi misin?");
            Console.Write ("Düz kayýtlar: "); foreach (string kayýt in ek) Console.Write (kayýt+" "); Console.WriteLine();
            Console.Write ("Ters kayýtlar: "); for(i=ek.Count-1;i>=0;i--) Console.Write (ek [i]+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}