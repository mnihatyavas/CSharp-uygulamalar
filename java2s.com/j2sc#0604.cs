// j2sc#0604.cs: Yap�larda �zel/ar�iv Equals e�itlik ve this kullan�mlar� �rne�i.

using System;
namespace Yap�lar {
    struct Araba {
        public string Marka;
        public string Model;
        public uint Y�l;
        public Araba (string marka, string model, uint y�l) {Marka = marka; Model = model; Y�l = y�l;}
    }
    struct Araba2 {
        public string Marka;
        public string Model;
        public uint Y�l;
        public Araba2 (string marka, string model, uint y�l) {Marka = marka; Model = model; Y�l = y�l;}
        public bool E�itMi (Araba2 a) {return a.Marka == this.Marka && a.Model == this.Model && a.Y�l == this.Y�l;}
        public bool E�itMi (uint a, uint b) {return a == b;}
    }
    public struct KompleksSay� {
        public double ger�el;
        public double sanal;
        public KompleksSay� (double ger�el, double sanal) {this.ger�el = ger�el; this.sanal = sanal;}
        public KompleksSay� (double ger�el):this (ger�el, 0) {this.ger�el = ger�el;}
        public override string ToString() {return String.Format ("Kompleks say� = ({0} + j{1})", ger�el, sanal);}
    }

    class E�itlik {
        static void Main() {
            Console.Write ("Equals ile yap�lar�n yada tek alan�n�n e�itli�i test edilebilir. �zel 'bool E�itmi' metodu da tan�mlanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bir yap�sal araban�n di�eriyle e�itli�i:");
            Araba a1 = new Araba ("BMW", "330Ci", 2001);
            Araba a2 = new Araba ("BMW", "330Ci", 2001);
            Araba a3 = new Araba ("Ford", "Taunus Station", 1974);
            Araba a4 = new Araba ("Fiat", "Murat", 1974);
            Console.WriteLine ("Araba1.Equals (Araba2)? {0}", a1.Equals (a2));
            Console.WriteLine ("Araba1.Equals (Araba3)? {0}", a1.Equals (a3));
            Console.WriteLine ("Araba3.Y�l.Equals (Araba4.Y�l)? {0}", a3.Y�l.Equals (a4.Y�l));

            Console.WriteLine ("\nBir yap�sal araban�n di�eriyle �zel-tan�ml� e�itli�i:");
            Araba2 a21 = new Araba2 ("BMW", "330Ci", 2001);
            Araba2 a22 = new Araba2 ("BMW", "330Ci", 2001);
            Araba2 a23 = new Araba2 ("Ford", "Taunus Station", 1974);
            Araba2 a24 = new Araba2 ("Fiat", "Murat", 1974);
            Console.WriteLine ("Araba21.E�itMi (Araba22)? {0}", a21.E�itMi (a22));
            Console.WriteLine ("Araba21.E�itMi (Araba23)? {0}", a21.E�itMi (a23));
            Console.WriteLine ("Araba23.Y�l.E�itMi (Araba24.Y�l)? {0}", new Araba2().E�itMi (a23.Y�l, a24.Y�l) );

            Console.WriteLine ("\nFarkl� kompleks say�lar�n e�itli�i testi:");
            KompleksSay� ks1 = new KompleksSay� (Math.PI, Math.E); Console.WriteLine (ks1);
            KompleksSay� ks2 = new KompleksSay� (Math.PI, Math.E); Console.WriteLine (ks2);
            KompleksSay� ks3 = new KompleksSay� (Math.PI / Math.E, Math.E); Console.WriteLine (ks3);
            KompleksSay� ks4 = new KompleksSay� (Math.PI * Math.E); Console.WriteLine (ks4);
            Console.WriteLine ("ks1.Equals (ks2)? {0}", ks1.Equals (ks2));
            Console.WriteLine ("ks1.Equals (ks3)? {0}", ks1.Equals (ks3));
            Console.WriteLine ("ks1.sanal.Equals (ks3.sanal)? {0}", ks1.sanal.Equals (ks3.sanal));
            Console.WriteLine ("ks1.Equals (ks4)? {0}", ks1.Equals (ks4));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}