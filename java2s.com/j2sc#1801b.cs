// j2sc#1801b.cs: Soysal<T> normal, delegeli ve aksiyonlu koleksiyonlar �rne�i.

using System;
using System.Collections.Generic; //IList<T> i�in
using System.Collections.ObjectModel; //Collection<T> i�in
namespace SoysalListe {
    class �evirenKoleksiyon<T> : Collection<T> {
        private Converter<T,T> �evir; //delegeyle b�y�kharfle
        public �evirenKoleksiyon (Converter<T,T> �evir) {this.�evir = �evir;} //Kuucu
        protected override void InsertItem (int endeks, T kay�t) {base.InsertItem (endeks, �evir (kay�t));}
    }
    class EylemKoleksiyou<T> : Collection<T> {
        private Action<T> eylem; //konsoldan yans�t
        public EylemKoleksiyou (Action<T> eylem) {this.eylem = eylem;}
        protected override void InsertItem (int e, T k) {eylem (k); base.InsertItem (e, k);}
    }
    class Koleksiyon {
        static void Main() {
            Console.Write ("'Collection<T> k = new Collection<T>()' ile yarat�lan koleksiyona 'k.Add(kyt)'la T tipli kay�tlar eklenir. �zel delegeli ve eylemli koleksiyonlar da m�mk�nd�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Collection<T> ve Collection<Collection<T>> ile y�llar ve adlar:");
            var r=new Random(); int i, j, ts; string ad;
            Collection<int> y�llar = new Collection<int>();
            for(i=0;i<5;i++) {
                ts=r.Next(1900,2025);
                y�llar.Add (ts);
            }
            Console.Write ("Y�llar: "); for(i=0;i<5;i++) Console.Write (y�llar [i] + " "); Console.WriteLine();
            Collection<string> adlar = new Collection<string>();
            for(i=0;i<5;i++) {
                ad="";
                for(j=0;j<7;j++) {ts=r.Next(65,91); ad+=(char)ts;}
                adlar.Add (ad);
            }
            Console.Write ("Adlar: "); for(i=0;i<5;i++) Console.Write (adlar [i] + " "); Console.WriteLine();
            Collection<Collection<int>> y�llar2 = new Collection<Collection<int>>();
            y�llar2.Add (y�llar);
            Console.Write ("Y�llar-2: "); for(i=0;i<y�llar2.Count;i++) for(j=0;j<y�llar2 [0].Count;j++) Console.Write (y�llar2 [i] [j] + " "); Console.WriteLine();
            Collection<Collection<string>> adlar2 = new Collection<Collection<string>>();
            adlar2.Add (adlar);
            Console.Write ("Adlar-2: "); for(i=0;i<adlar2.Count;i++) for(j=0;j<adlar2 [i].Count;j++)Console.Write (adlar2 [i] [j] + " "); Console.WriteLine();
            IList<int> y�lListe = y�llar;
            Console.Write ("Y�llar listesi: "); foreach(int y�l in y�lListe) Console.Write (y�l+" "); Console.WriteLine();
            IList<string> adListe = adlar;
            Console.Write ("Adlar listesi: "); foreach(string a in adListe) Console.Write (a+" "); Console.WriteLine();

            Console.WriteLine ("\nKay�tlar� delegeli b�y�kharfleyen �evirici koleksiyon:");
            �evirenKoleksiyon<string> �k = new �evirenKoleksiyon<string> (delegate (string kay�t) {return kay�t.ToUpper();});
            �k.Add ("Merhaba"); �k.Add ("Nihal"); �k.Add ("bug�n"); �k.Add ("nas�ls�n"); �k.Add ("iyi misin?");
            Console.Write ("D�z kay�tlar: "); foreach (string kay�t in �k) Console.Write (kay�t+" "); Console.WriteLine();
            Console.Write ("Ters kay�tlar: "); for(i=�k.Count-1;i>=0;i--) Console.Write (�k [i]+" "); Console.WriteLine();

            Console.WriteLine ("\nKay�tlar� eklerken konsola ��kt�layan eylem koleksiyonu:");
            EylemKoleksiyou <string> ek = new EylemKoleksiyou<string> (Console.WriteLine);
            ek.Add ("Merhaba"); ek.Add ("Nihal"); ek.Add ("bug�n"); ek.Add ("nas�ls�n"); ek.Add ("iyi misin?");
            Console.Write ("D�z kay�tlar: "); foreach (string kay�t in ek) Console.Write (kay�t+" "); Console.WriteLine();
            Console.Write ("Ters kay�tlar: "); for(i=ek.Count-1;i>=0;i--) Console.Write (ek [i]+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}