// j2sc#0604.cs: Yapýlarda özel/arþiv Equals eþitlik ve this kullanýmlarý örneði.

using System;
namespace Yapýlar {
    struct Araba {
        public string Marka;
        public string Model;
        public uint Yýl;
        public Araba (string marka, string model, uint yýl) {Marka = marka; Model = model; Yýl = yýl;}
    }
    struct Araba2 {
        public string Marka;
        public string Model;
        public uint Yýl;
        public Araba2 (string marka, string model, uint yýl) {Marka = marka; Model = model; Yýl = yýl;}
        public bool EþitMi (Araba2 a) {return a.Marka == this.Marka && a.Model == this.Model && a.Yýl == this.Yýl;}
        public bool EþitMi (uint a, uint b) {return a == b;}
    }
    public struct KompleksSayý {
        public double gerçel;
        public double sanal;
        public KompleksSayý (double gerçel, double sanal) {this.gerçel = gerçel; this.sanal = sanal;}
        public KompleksSayý (double gerçel):this (gerçel, 0) {this.gerçel = gerçel;}
        public override string ToString() {return String.Format ("Kompleks sayý = ({0} + j{1})", gerçel, sanal);}
    }

    class Eþitlik {
        static void Main() {
            Console.Write ("Equals ile yapýlarýn yada tek alanýnýn eþitliði test edilebilir. Özel 'bool Eþitmi' metodu da tanýmlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bir yapýsal arabanýn diðeriyle eþitliði:");
            Araba a1 = new Araba ("BMW", "330Ci", 2001);
            Araba a2 = new Araba ("BMW", "330Ci", 2001);
            Araba a3 = new Araba ("Ford", "Taunus Station", 1974);
            Araba a4 = new Araba ("Fiat", "Murat", 1974);
            Console.WriteLine ("Araba1.Equals (Araba2)? {0}", a1.Equals (a2));
            Console.WriteLine ("Araba1.Equals (Araba3)? {0}", a1.Equals (a3));
            Console.WriteLine ("Araba3.Yýl.Equals (Araba4.Yýl)? {0}", a3.Yýl.Equals (a4.Yýl));

            Console.WriteLine ("\nBir yapýsal arabanýn diðeriyle özel-tanýmlý eþitliði:");
            Araba2 a21 = new Araba2 ("BMW", "330Ci", 2001);
            Araba2 a22 = new Araba2 ("BMW", "330Ci", 2001);
            Araba2 a23 = new Araba2 ("Ford", "Taunus Station", 1974);
            Araba2 a24 = new Araba2 ("Fiat", "Murat", 1974);
            Console.WriteLine ("Araba21.EþitMi (Araba22)? {0}", a21.EþitMi (a22));
            Console.WriteLine ("Araba21.EþitMi (Araba23)? {0}", a21.EþitMi (a23));
            Console.WriteLine ("Araba23.Yýl.EþitMi (Araba24.Yýl)? {0}", new Araba2().EþitMi (a23.Yýl, a24.Yýl) );

            Console.WriteLine ("\nFarklý kompleks sayýlarýn eþitliði testi:");
            KompleksSayý ks1 = new KompleksSayý (Math.PI, Math.E); Console.WriteLine (ks1);
            KompleksSayý ks2 = new KompleksSayý (Math.PI, Math.E); Console.WriteLine (ks2);
            KompleksSayý ks3 = new KompleksSayý (Math.PI / Math.E, Math.E); Console.WriteLine (ks3);
            KompleksSayý ks4 = new KompleksSayý (Math.PI * Math.E); Console.WriteLine (ks4);
            Console.WriteLine ("ks1.Equals (ks2)? {0}", ks1.Equals (ks2));
            Console.WriteLine ("ks1.Equals (ks3)? {0}", ks1.Equals (ks3));
            Console.WriteLine ("ks1.sanal.Equals (ks3.sanal)? {0}", ks1.sanal.Equals (ks3.sanal));
            Console.WriteLine ("ks1.Equals (ks4)? {0}", ks1.Equals (ks4));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}