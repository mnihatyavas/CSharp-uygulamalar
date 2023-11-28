// j2sc#0716.cs: Temel soyut sýnýfýn soyut metodunun türedilerce esgeçilmesi örneði.

using System;
namespace Sýnýflar {
    abstract class Þekil {//abstract (metotlu) temel sýnýf
        double en, boy; //private 
        string ad; //private 
        public Þekil() {En = Boy = 0.0; Ad = "null";}
        public Þekil (double e, double b, string a) {En = e; Boy = b; Ad = a;}
        public Þekil (double x, string a) {En = Boy = x; Ad = a;}
        public Þekil (Þekil nes) {En = nes.En; Boy = nes.Boy; Ad = nes.Ad;}
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
        public string Ad {get {return ad;} set {ad = value;}}
        public void enboyGöster() {Console.Write ("{0} (en, boy) = ({1}, {2})", Ad, En, Boy);}
        public abstract double alan(); //abstract gövdesiz metot
    }
    class Üçgen : Þekil {
        string stil; //private 
        public Üçgen() {stil = "null";}
        public Üçgen (string s, double e, double b) : base (e, b, "Üçgen") {stil = s;}
        public Üçgen (double x) : base (x, "Üçgen") {stil = "ikizkenar";}
        public Üçgen (Üçgen nes) : base (nes) {stil = nes.stil;}
        public override double alan() {return En * Boy / 2;}
        public void stilGöster() {Console.WriteLine ("Üçgen " + stil + "'dýr.");}//Kullanýlmýyor
    }
    class Dikdörtgen : Þekil {
        public Dikdörtgen (double e, double b) : base (e, b, "Dikdörtgen"){}
        public Dikdörtgen (double x) : base (x, "Kare"){}
        public Dikdörtgen (Dikdörtgen nes) : base (nes){}
        public bool kareMi() {if(En == Boy) return true; return false;}
        public override double alan() {return En * Boy;}
    }
    abstract class A {public abstract void Göster();}//abstract (metotlu) temel sýnýf
    class B: A {public override void Göster() {Console.WriteLine ("B sýnýfýnýn override Göster() metodu.");}}
    class C: B {public override void Göster() {Console.WriteLine ("C sýnýfýnýn override Göster() metodu.");}}
    class D: C {public override void Göster() {Console.WriteLine ("D sýnýfýnýn override Göster() metodu.");}}
    public abstract class Iþýk {public abstract void Yanýyor();}
    public class KýrmýzýIþýk : Iþýk {public override void Yanýyor() {Console.WriteLine ("KýrmýzýIþýk.Yanýyor()");}}
    public class SarýIþýk : Iþýk {public override void Yanýyor() {Console.WriteLine ("SarýIþýk.Yanýyor()");}}
    public class YeþilIþýk : Iþýk {public override void Yanýyor() {Console.WriteLine ("YeþilIþýk.Yanýyor()");}}
    public abstract class Tatbikatlar {
        public abstract void Tatbikat1();
        public virtual void Tatbikat2() {Console.WriteLine ("Tatbikatlar.Tatbikat2()");}
        public virtual void Tatbikat3() {Console.WriteLine ("Tatbikatlar.Tatbikat3()");}
    }
    public class Takým : Tatbikatlar {
        public override void Tatbikat1() {Console.WriteLine ("Takým.Tatbikat1()");}
        public override void Tatbikat2() {Console.WriteLine ("Takým.Tatbikat2()");}
    }
    abstract class Ýþgören {
        public string isim;
        public float günlük;
        public Ýþgören (string isim, float günlük) {this.isim = isim; this.günlük = günlük;}
        abstract public float maaþ (int gün);
        abstract public string Statü();
    }
    class Amir: Ýþgören {
        public Amir (string isim, float günlük) : base (isim, günlük){}
        override public float maaþ (int gün) {if (gün < 8) gün = 8; return (gün * günlük);}
        override public string Statü() {return ("Amir");}
    }
    class Memur: Ýþgören {
        public Memur (string isim, float günlük) : base (isim, günlük){}
        override public float maaþ (int gün) {if (gün < 4) gün = 4; return (gün * günlük);}
        override public string Statü() {return ("Memur");}}
    class SoyutSýnýf {
        public static void TrafikIþýðý (Iþýk ksy) {ksy.Yanýyor();}
        public void HangiTatbikat (Tatbikatlar t) {t.Tatbikat3();}
        static void Main() {
            Console.Write ("Otomatikmen virtual da olan 'abstract' özellik ve metotlar soyut sýnýfta bulunur ve metot gövdesi{} bulunmaz, kullanýmý türedi overide metot gövdesiyle saðlanýr. Soyut sýnýf gövdeli normal, ve gövdesiz soyut ve statik olmayan metotlar içerebilir. Türedi sýnýf soyut temelin tüm soyut metotlarýný kullanmazsa o da abstract olmalýdýr. Soyut sýnýf referanslanabilir ama tiplenemez.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Gövdesiz soyut Þekil.alan()'ý esgeçen gövdeli alan()'lar:");
            var r=new Random(); double ds1=r.Next(1, 100)+r.Next(10, 100)/100D, ds2=r.Next(1, 100)+r.Next(10, 100)/100D; int i, ts1;
            Þekil[] þekiller = new Þekil [5];
            þekiller[0] = new Üçgen ("dik", ds1, ds2);
            þekiller[1] = new Dikdörtgen (ds1);
            þekiller[2] = new Dikdörtgen (ds1, ds2);
            þekiller[3] = new Üçgen (ds1);
            þekiller[4] = new Dikdörtgen (new Dikdörtgen (ds1, ds2));
            for(i=0; i < þekiller.Length; i++) {
                þekiller[i].enboyGöster();
                Console.Write (",\talan = {0:#,0.00}\n", þekiller [i].alan());
            }

            Console.WriteLine ("\nSoyut sýnýf ref-tipleme son esgeçen metodu çaðýrýr:");
            A ab = new B(); ab.Göster();
            A ac = new C(); ac.Göster();
            B bd = new D(); bd.Göster();
            D dd = new D(); dd.Göster();

            Console.WriteLine ("\nSoyut sýnýf ref-tiplemede daima esgeçen tipleme metot çaðrýlýr:");
            Iþýk ksy;
            ksy = new KýrmýzýIþýk(); TrafikIþýðý (ksy);
            ksy = new SarýIþýk(); SoyutSýnýf.TrafikIþýðý (ksy);
            ksy = new YeþilIþýk(); TrafikIþýðý (ksy);

            Console.WriteLine ("\nTüredi'de olmayan metot, sanal Temel metodu çaðýracaktýr:");
            SoyutSýnýf ss = new SoyutSýnýf();
            Takým tk1=new Takým(); tk1.Tatbikat1(); tk1.Tatbikat2(); tk1.Tatbikat3();
            ss.HangiTatbikat (tk1);

            Console.WriteLine ("\nÝþgörenlerin isim, statü, çalýþýlan gün ve aylýk maaþ bordosu:");
            Ýþgören[] elemanlar = new Ýþgören [6];
            elemanlar [0] = new Amir ("Hamza Candan", 500.45F);
            elemanlar [1] = new Amir ("Belkýs Candan", 1038.37F);
            elemanlar [2] = new Memur ("Atilla Göktürk", 854.95F);
            elemanlar [3] = new Memur ("Hilal Göktürk", 832.18F);
            elemanlar [4] = new Memur ("Zafer N.Candan", 1267.73F);
            elemanlar [5] = new Amir ("M.Nihat Yavaþ", 251.13F);
            for(i=0; i < elemanlar.Length; i++) {
                ts1=r.Next (0, 32);
                Console.WriteLine ("{0},\t{1},\t{2},\t{3:#,0.00} TL", elemanlar [i].isim, elemanlar [i].Statü(), ts1, elemanlar [i].maaþ (ts1));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}