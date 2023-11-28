// j2sc#0716.cs: Temel soyut s�n�f�n soyut metodunun t�redilerce esge�ilmesi �rne�i.

using System;
namespace S�n�flar {
    abstract class �ekil {//abstract (metotlu) temel s�n�f
        double en, boy; //private 
        string ad; //private 
        public �ekil() {En = Boy = 0.0; Ad = "null";}
        public �ekil (double e, double b, string a) {En = e; Boy = b; Ad = a;}
        public �ekil (double x, string a) {En = Boy = x; Ad = a;}
        public �ekil (�ekil nes) {En = nes.En; Boy = nes.Boy; Ad = nes.Ad;}
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
        public string Ad {get {return ad;} set {ad = value;}}
        public void enboyG�ster() {Console.Write ("{0} (en, boy) = ({1}, {2})", Ad, En, Boy);}
        public abstract double alan(); //abstract g�vdesiz metot
    }
    class ��gen : �ekil {
        string stil; //private 
        public ��gen() {stil = "null";}
        public ��gen (string s, double e, double b) : base (e, b, "��gen") {stil = s;}
        public ��gen (double x) : base (x, "��gen") {stil = "ikizkenar";}
        public ��gen (��gen nes) : base (nes) {stil = nes.stil;}
        public override double alan() {return En * Boy / 2;}
        public void stilG�ster() {Console.WriteLine ("��gen " + stil + "'d�r.");}//Kullan�lm�yor
    }
    class Dikd�rtgen : �ekil {
        public Dikd�rtgen (double e, double b) : base (e, b, "Dikd�rtgen"){}
        public Dikd�rtgen (double x) : base (x, "Kare"){}
        public Dikd�rtgen (Dikd�rtgen nes) : base (nes){}
        public bool kareMi() {if(En == Boy) return true; return false;}
        public override double alan() {return En * Boy;}
    }
    abstract class A {public abstract void G�ster();}//abstract (metotlu) temel s�n�f
    class B: A {public override void G�ster() {Console.WriteLine ("B s�n�f�n�n override G�ster() metodu.");}}
    class C: B {public override void G�ster() {Console.WriteLine ("C s�n�f�n�n override G�ster() metodu.");}}
    class D: C {public override void G�ster() {Console.WriteLine ("D s�n�f�n�n override G�ster() metodu.");}}
    public abstract class I��k {public abstract void Yan�yor();}
    public class K�rm�z�I��k : I��k {public override void Yan�yor() {Console.WriteLine ("K�rm�z�I��k.Yan�yor()");}}
    public class Sar�I��k : I��k {public override void Yan�yor() {Console.WriteLine ("Sar�I��k.Yan�yor()");}}
    public class Ye�ilI��k : I��k {public override void Yan�yor() {Console.WriteLine ("Ye�ilI��k.Yan�yor()");}}
    public abstract class Tatbikatlar {
        public abstract void Tatbikat1();
        public virtual void Tatbikat2() {Console.WriteLine ("Tatbikatlar.Tatbikat2()");}
        public virtual void Tatbikat3() {Console.WriteLine ("Tatbikatlar.Tatbikat3()");}
    }
    public class Tak�m : Tatbikatlar {
        public override void Tatbikat1() {Console.WriteLine ("Tak�m.Tatbikat1()");}
        public override void Tatbikat2() {Console.WriteLine ("Tak�m.Tatbikat2()");}
    }
    abstract class ��g�ren {
        public string isim;
        public float g�nl�k;
        public ��g�ren (string isim, float g�nl�k) {this.isim = isim; this.g�nl�k = g�nl�k;}
        abstract public float maa� (int g�n);
        abstract public string Stat�();
    }
    class Amir: ��g�ren {
        public Amir (string isim, float g�nl�k) : base (isim, g�nl�k){}
        override public float maa� (int g�n) {if (g�n < 8) g�n = 8; return (g�n * g�nl�k);}
        override public string Stat�() {return ("Amir");}
    }
    class Memur: ��g�ren {
        public Memur (string isim, float g�nl�k) : base (isim, g�nl�k){}
        override public float maa� (int g�n) {if (g�n < 4) g�n = 4; return (g�n * g�nl�k);}
        override public string Stat�() {return ("Memur");}}
    class SoyutS�n�f {
        public static void TrafikI���� (I��k ksy) {ksy.Yan�yor();}
        public void HangiTatbikat (Tatbikatlar t) {t.Tatbikat3();}
        static void Main() {
            Console.Write ("Otomatikmen virtual da olan 'abstract' �zellik ve metotlar soyut s�n�fta bulunur ve metot g�vdesi{} bulunmaz, kullan�m� t�redi overide metot g�vdesiyle sa�lan�r. Soyut s�n�f g�vdeli normal, ve g�vdesiz soyut ve statik olmayan metotlar i�erebilir. T�redi s�n�f soyut temelin t�m soyut metotlar�n� kullanmazsa o da abstract olmal�d�r. Soyut s�n�f referanslanabilir ama tiplenemez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("G�vdesiz soyut �ekil.alan()'� esge�en g�vdeli alan()'lar:");
            var r=new Random(); double ds1=r.Next(1, 100)+r.Next(10, 100)/100D, ds2=r.Next(1, 100)+r.Next(10, 100)/100D; int i, ts1;
            �ekil[] �ekiller = new �ekil [5];
            �ekiller[0] = new ��gen ("dik", ds1, ds2);
            �ekiller[1] = new Dikd�rtgen (ds1);
            �ekiller[2] = new Dikd�rtgen (ds1, ds2);
            �ekiller[3] = new ��gen (ds1);
            �ekiller[4] = new Dikd�rtgen (new Dikd�rtgen (ds1, ds2));
            for(i=0; i < �ekiller.Length; i++) {
                �ekiller[i].enboyG�ster();
                Console.Write (",\talan = {0:#,0.00}\n", �ekiller [i].alan());
            }

            Console.WriteLine ("\nSoyut s�n�f ref-tipleme son esge�en metodu �a��r�r:");
            A ab = new B(); ab.G�ster();
            A ac = new C(); ac.G�ster();
            B bd = new D(); bd.G�ster();
            D dd = new D(); dd.G�ster();

            Console.WriteLine ("\nSoyut s�n�f ref-tiplemede daima esge�en tipleme metot �a�r�l�r:");
            I��k ksy;
            ksy = new K�rm�z�I��k(); TrafikI���� (ksy);
            ksy = new Sar�I��k(); SoyutS�n�f.TrafikI���� (ksy);
            ksy = new Ye�ilI��k(); TrafikI���� (ksy);

            Console.WriteLine ("\nT�redi'de olmayan metot, sanal Temel metodu �a��racakt�r:");
            SoyutS�n�f ss = new SoyutS�n�f();
            Tak�m tk1=new Tak�m(); tk1.Tatbikat1(); tk1.Tatbikat2(); tk1.Tatbikat3();
            ss.HangiTatbikat (tk1);

            Console.WriteLine ("\n��g�renlerin isim, stat�, �al���lan g�n ve ayl�k maa� bordosu:");
            ��g�ren[] elemanlar = new ��g�ren [6];
            elemanlar [0] = new Amir ("Hamza Candan", 500.45F);
            elemanlar [1] = new Amir ("Belk�s Candan", 1038.37F);
            elemanlar [2] = new Memur ("Atilla G�kt�rk", 854.95F);
            elemanlar [3] = new Memur ("Hilal G�kt�rk", 832.18F);
            elemanlar [4] = new Memur ("Zafer N.Candan", 1267.73F);
            elemanlar [5] = new Amir ("M.Nihat Yava�", 251.13F);
            for(i=0; i < elemanlar.Length; i++) {
                ts1=r.Next (0, 32);
                Console.WriteLine ("{0},\t{1},\t{2},\t{3:#,0.00} TL", elemanlar [i].isim, elemanlar [i].Stat�(), ts1, elemanlar [i].maa� (ts1));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}