// j2sc#1109e.cs: Hashtable'n IDictionaryEnumerator'la taranmasý örneði.

using System;
using System.Collections; //IEnumerator ve IEnumerable için
using System.Collections.Generic; //IEnumerable<T> için

namespace VeriYapýlarý {
    class KoleksiyonTarayýcý : IEnumerator {
        public TarananKoleksiyon klsyn;
        public int cariKonum;
        internal KoleksiyonTarayýcý (TarananKoleksiyon klsyn) {//Kurucu
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
        public IEnumerator GetEnumerator() {return new KoleksiyonTarayýcý (this);}
    }

    class VeriYapýsý9E {
        static readonly string önBoþluk = new string (' ', 7);
        static IEnumerable<int> GetEnumerable() {
            for(int i = 1919; i <= 1923; i++) {
                Console.WriteLine ("{0}Birazdan üretilecek yýl: {1}", önBoþluk, i);
                yield return i;
                Console.WriteLine ("{0}Yýl üretimi sonrasý", önBoþluk);
            }
            yield return -1;
        }
        static void KoleksiyonuYaz (string klkAdý, IEnumerator klkTarayýcý) {
            Console.WriteLine ("\tKoleksiyonun adý: [{0}]", klkAdý);
            Console.WriteLine ("Tarayýcý tipi: [{0}]", klkTarayýcý.GetType().ToString());
            Console.Write ("Koleksiyon deðerleri: ");
            while (klkTarayýcý.MoveNext()) {
                if (klkTarayýcý.Current.GetType() == Type.GetType ("System.Collections.DictionaryEntry")) Console.Write (((DictionaryEntry) klkTarayýcý.Current).Value.ToString() + " " );
                else Console.Write (klkTarayýcý.Current.ToString() + " " );
            } Console.WriteLine();
        }
        static void AdrTabloYaz (Hashtable ht) {
            IDictionaryEnumerator htTara = ht.GetEnumerator();
            while (htTara.MoveNext()) {Console.Write ("{0}:{1} ", htTara.Key, htTara.Value);} Console.WriteLine();
            foreach (int anh in ht.Keys) Console.Write (anh+" "); Console.WriteLine();
            foreach (string dðr in ht.Values) Console.Write (dðr+" "); Console.WriteLine();
        }
        static void Main() {
            Console.Write ("Hashtable sayýsal anahtarý otomatikmen azalan sýralarken, dizgesel anahtar rasgeledir. Ayný anahtarý tekrarlý giriþ hata verir, try-catch'le yönetilmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("52 adet A-z'yi farklý ilk konumlardan baþlatýp bitirme:");
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

            Console.WriteLine ("\nVarsayýlý GetEnumerable() ve GetEnumerator() ile döngülü yýl üretimi:");
            IEnumerable<int> taranabilir = GetEnumerable();
            IEnumerator<int> tarayýcý = taranabilir.GetEnumerator();
            while (true) {//break'le çýkýlýr
                bool sonMu = tarayýcý.MoveNext();
                Console.WriteLine (sonMu?"Devam":"Bitti");
                if (!sonMu) break;
                Console.WriteLine (tarayýcý.Current); //yýl üretimi
            }

            Console.WriteLine ("\nÇeþitli tipte dizi ve listenin adý, tarayýcýsý ve deðerleri:");
            int[] tsDizi = {1919, 1920, 1921, 1922, 1923};
            ArrayList diziListe = new ArrayList (tsDizi);
            bool[] ikiliDizi = {true, true, false, false, true};
            BitArray ikiliListe = new BitArray (ikiliDizi);
            Hashtable adrTablo = new Hashtable();
            adrTablo.Add (1920, "TBMM" );
            adrTablo.Add (1922, "Aðustos30" );
            adrTablo.Add (1923, "Cumhuriyet" );
            adrTablo.Add (1921, "Çocukbayramý" );
            adrTablo.Add (1919, "Samsun" );
            KoleksiyonuYaz ("Integer dizi", tsDizi.GetEnumerator());
            KoleksiyonuYaz ("ArrayList", diziListe.GetEnumerator());
            KoleksiyonuYaz ("Bool dizi", ikiliDizi.GetEnumerator());
            KoleksiyonuYaz ("BitArray", ikiliListe.GetEnumerator());
            KoleksiyonuYaz ("Hashtable", adrTablo.GetEnumerator()); //Anahtarla azalan sýrada

            Console.WriteLine ("\nadrTablo'ya anahtar:string/deðer:int ekleyip, movenext-reset'le sunma:");
            string a;
            Hashtable adrsTablo = new Hashtable();
            for(i=0;i<10;i++) {
                a=""; ts1=r.Next(1,6); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); a+=(char)(65+ts2);}
                ts1=r.Next(1881,1939);
                adrsTablo.Add (a, ts1);
            }
            IDictionaryEnumerator ide = adrsTablo.GetEnumerator(); 
            Console.WriteLine ("\tEntry ile Key/anahtar ve Value/deðer:"); 
            while (ide.MoveNext()) Console.WriteLine (ide.Entry.Key + ": " + ide.Entry.Value);
            Console.WriteLine ("\tDoðrudan Key ve Value dökümü:"); 
            ide.Reset();
            while (ide.MoveNext()) Console.WriteLine (ide.Key + ": " + ide.Value);

            Console.WriteLine ("\nadrTablo2'ye anahtar:int/deðer:string ekleyip, while/foreach'le sunma:");
            Hashtable adrsTablo2 = new Hashtable();
            for(i=0;i<100;i++) {
                a=""; ts1=r.Next(1,6); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); a+=(char)(65+ts2);}
                ts1=r.Next(1881,1939);
                try {adrsTablo2.Add (ts1, a);}catch{}
            }
            do {Console.Write ("[1881, 1938] yada [çýk=-1]: ");
                try {ts2 = int.Parse (Console.ReadLine());}catch {ts2=1923;}
                if (adrsTablo2 [ts2] != null) Console.WriteLine (adrsTablo2 [ts2]); else Console.WriteLine ("{0} anahtar namevcut.", ts2);
            } while (ts2 != -1);
            AdrTabloYaz (adrsTablo2);
            adrsTablo2.Remove (1915); adrsTablo2.Remove (1938); //Namevcutsa birþey silmez
            AdrTabloYaz (adrsTablo2);
            adrsTablo2.Clear();
            //AdrTabloYaz (adrsTablo2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
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