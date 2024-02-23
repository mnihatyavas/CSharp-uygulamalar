// j2sc#1109e.cs: Hashtable'n IDictionaryEnumerator'la taranmas� �rne�i.

using System;
using System.Collections; //IEnumerator ve IEnumerable i�in
using System.Collections.Generic; //IEnumerable<T> i�in

namespace VeriYap�lar� {
    class KoleksiyonTaray�c� : IEnumerator {
        public TarananKoleksiyon klsyn;
        public int cariKonum;
        internal KoleksiyonTaray�c� (TarananKoleksiyon klsyn) {//Kurucu
            this.klsyn = klsyn;
            cariKonum = -1;
        }
        public bool MoveNext() {
            if (cariKonum != klsyn.nsDizi.Length) {cariKonum++;}
             return cariKonum < klsyn.nsDizi.Length;
        }
        public object Current {
            get {
                if (cariKonum == -1 || cariKonum == klsyn.nsDizi.Length) {throw new InvalidOperationException();}
                int endeks = (cariKonum + klsyn.ilkKonum);
                endeks = endeks % klsyn.nsDizi.Length;
                return klsyn.nsDizi [endeks];
            }
        }
        public void Reset() {cariKonum = -1;}
    }
    class TarananKoleksiyon : IEnumerable {
        public object[] nsDizi;
        public int ilkKonum;
        public TarananKoleksiyon (object[] nsDizi, int ilkKonum) {//Kurucu
            this.nsDizi = nsDizi;
            this.ilkKonum = ilkKonum;
        }
        public IEnumerator GetEnumerator() {return new KoleksiyonTaray�c� (this);}
    }

    class VeriYap�s�9E {
        static readonly string �nBo�luk = new string (' ', 7);
        static IEnumerable<int> GetEnumerable() {
            for(int i = 1919; i <= 1923; i++) {
                Console.WriteLine ("{0}Birazdan �retilecek y�l: {1}", �nBo�luk, i);
                yield return i;
                Console.WriteLine ("{0}Y�l �retimi sonras�", �nBo�luk);
            }
            yield return -1;
        }
        static void KoleksiyonuYaz (string klkAd�, IEnumerator klkTaray�c�) {
            Console.WriteLine ("\tKoleksiyonun ad�: [{0}]", klkAd�);
            Console.WriteLine ("Taray�c� tipi: [{0}]", klkTaray�c�.GetType().ToString());
            Console.Write ("Koleksiyon de�erleri: ");
            while (klkTaray�c�.MoveNext()) {
                if (klkTaray�c�.Current.GetType() == Type.GetType ("System.Collections.DictionaryEntry")) Console.Write (((DictionaryEntry) klkTaray�c�.Current).Value.ToString() + " " );
                else Console.Write (klkTaray�c�.Current.ToString() + " " );
            } Console.WriteLine();
        }
        static void AdrTabloYaz (Hashtable ht) {
            IDictionaryEnumerator htTara = ht.GetEnumerator();
            while (htTara.MoveNext()) {Console.Write ("{0}:{1} ", htTara.Key, htTara.Value);} Console.WriteLine();
            foreach (int anh in ht.Keys) Console.Write (anh+" "); Console.WriteLine();
            foreach (string d�r in ht.Values) Console.Write (d�r+" "); Console.WriteLine();
        }
        static void Main() {
            Console.Write ("Hashtable say�sal anahtar� otomatikmen azalan s�ralarken, dizgesel anahtar rasgeledir. Ayn� anahtar� tekrarl� giri� hata verir, try-catch'le y�netilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("52 adet A-z'yi farkl� ilk konumlardan ba�lat�p bitirme:");
            int i, j, ts1, ts2; var r=new Random();
            object[] nsDizi=new object [52];
            for(i=0;i<26;i++) nsDizi [i]=(char)('A'+i);
            for(i=0;i<26;i++) nsDizi [i+26]=(char)('a'+i);
            TarananKoleksiyon koleksiyon;
            for(i=0;i<5;i++) {
                ts1=r.Next(0, 52);
                Console.Write ("{0,2:#0}.konumdan: ", ts1);
                koleksiyon = new TarananKoleksiyon (nsDizi, ts1);
                foreach (object x in koleksiyon) Console.Write (x); Console.WriteLine();
            }

            Console.WriteLine ("\nVarsay�l� GetEnumerable() ve GetEnumerator() ile d�ng�l� y�l �retimi:");
            IEnumerable<int> taranabilir = GetEnumerable();
            IEnumerator<int> taray�c� = taranabilir.GetEnumerator();
            while (true) {//break'le ��k�l�r
                bool sonMu = taray�c�.MoveNext();
                Console.WriteLine (sonMu?"Devam":"Bitti");
                if (!sonMu) break;
                Console.WriteLine (taray�c�.Current); //y�l �retimi
            }

            Console.WriteLine ("\n�e�itli tipte dizi ve listenin ad�, taray�c�s� ve de�erleri:");
            int[] tsDizi = {1919, 1920, 1921, 1922, 1923};
            ArrayList diziListe = new ArrayList (tsDizi);
            bool[] ikiliDizi = {true, true, false, false, true};
            BitArray ikiliListe = new BitArray (ikiliDizi);
            Hashtable adrTablo = new Hashtable();
            adrTablo.Add (1920, "TBMM" );
            adrTablo.Add (1922, "A�ustos30" );
            adrTablo.Add (1923, "Cumhuriyet" );
            adrTablo.Add (1921, "�ocukbayram�" );
            adrTablo.Add (1919, "Samsun" );
            KoleksiyonuYaz ("Integer dizi", tsDizi.GetEnumerator());
            KoleksiyonuYaz ("ArrayList", diziListe.GetEnumerator());
            KoleksiyonuYaz ("Bool dizi", ikiliDizi.GetEnumerator());
            KoleksiyonuYaz ("BitArray", ikiliListe.GetEnumerator());
            KoleksiyonuYaz ("Hashtable", adrTablo.GetEnumerator()); //Anahtarla azalan s�rada

            Console.WriteLine ("\nadrTablo'ya anahtar:string/de�er:int ekleyip, movenext-reset'le sunma:");
            string a;
            Hashtable adrsTablo = new Hashtable();
            for(i=0;i<10;i++) {
                a=""; ts1=r.Next(1,6); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); a+=(char)(65+ts2);}
                ts1=r.Next(1881,1939);
                adrsTablo.Add (a, ts1);
            }
            IDictionaryEnumerator ide = adrsTablo.GetEnumerator(); 
            Console.WriteLine ("\tEntry ile Key/anahtar ve Value/de�er:"); 
            while (ide.MoveNext()) Console.WriteLine (ide.Entry.Key + ": " + ide.Entry.Value);
            Console.WriteLine ("\tDo�rudan Key ve Value d�k�m�:"); 
            ide.Reset();
            while (ide.MoveNext()) Console.WriteLine (ide.Key + ": " + ide.Value);

            Console.WriteLine ("\nadrTablo2'ye anahtar:int/de�er:string ekleyip, while/foreach'le sunma:");
            Hashtable adrsTablo2 = new Hashtable();
            for(i=0;i<100;i++) {
                a=""; ts1=r.Next(1,6); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); a+=(char)(65+ts2);}
                ts1=r.Next(1881,1939);
                try {adrsTablo2.Add (ts1, a);}catch{}
            }
            do {Console.Write ("[1881, 1938] yada [��k=-1]: ");
                try {ts2 = int.Parse (Console.ReadLine());}catch {ts2=1923;}
                if (adrsTablo2 [ts2] != null) Console.WriteLine (adrsTablo2 [ts2]); else Console.WriteLine ("{0} anahtar namevcut.", ts2);
            } while (ts2 != -1);
            AdrTabloYaz (adrsTablo2);
            adrsTablo2.Remove (1915); adrsTablo2.Remove (1938); //Namevcutsa bir�ey silmez
            AdrTabloYaz (adrsTablo2);
            adrsTablo2.Clear();
            //AdrTabloYaz (adrsTablo2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
/*
using System; 
using System.Collections; 
 
class MainClass { 
  public static void Main() { 
    // Create a hash table. 
    Hashtable ht = new Hashtable(); 
     
    // Add elements to the table 
    ht.Add("A", "3"); 
    ht.Add("B", "9"); 
    ht.Add("C", "3"); 
    ht.Add("D", "7"); 
 
    // Demonstrate enumerator 
    IDictionaryEnumerator etr = ht.GetEnumerator(); 
    Console.WriteLine("Display info using Entry."); 
    while(etr.MoveNext())  
     Console.WriteLine(etr.Entry.Key + ": " +  
                       etr.Entry.Value); 
 
    Console.WriteLine(); 
 
    Console.WriteLine("Display info using Key and Value directly."); 
    etr.Reset(); 
    while(etr.MoveNext())  
     Console.WriteLine(etr.Key + ": " +  
                       etr.Value); 
     
  } 
}
Display info using Entry.
A: 3
B: 9
C: 3
D: 7

Display info using Key and Value directly.
A: 3
B: 9
C: 3
D: 7
----------------------------------
using System;
using System.Collections;

  class Class1
  {
    [STAThread]
    static void Main(string[] args)
    {
            Hashtable dir = new Hashtable();
            dir.Add( 'N', "North" );
            dir.Add( 'S', "South." );
            dir.Add( 'W', "West" );
            dir.Add( 'E', "East" );
            dir.Add( 'Q', "Goodbye" );

            char input;

            do
            {
                Console.Write( "Enter a direction (N,S,E,W) or Q to quit: " );
                input = Char.ToUpper(Console.ReadLine()[0]);
                Console.WriteLine( dir[Char.ToUpper(input)]);

            } while( input != 'Q' );

            PrintHashtable( dir );
            dir.Remove( 'Q' );
            dir.Clear();
    }

        static void PrintHashtable( Hashtable ht )
        {
            IDictionaryEnumerator htEnum = ht.GetEnumerator();
            while( htEnum.MoveNext() )
            {
                Console.WriteLine( "Key: {0}\tValue: {1}", htEnum.Key, htEnum.Value );
            }

            foreach( char key in ht.Keys )
            {
                Console.WriteLine( key );
            }
        }
  }
*/