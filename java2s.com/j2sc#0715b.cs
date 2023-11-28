// j2sc#0715b.cs: �oklu hiyerar�ide virtual-override-new ili�kileri �rne�i.

using System;
namespace S�n�flar {
    class Temel1 {public virtual void metot() {Console.WriteLine ("Temel1.metot()");}}
    class T�redi1 : Temel1 {public override void metot() {Console.WriteLine ("override T�redi1.metot()");}}
    class T�redi2 : Temel1 {public override void metot() {Console.WriteLine ("override T�redi2.metot()");}}
    class T�redi3 : Temel1 {} //override metot yok
    class T�redi4 : Temel1 {public new void metot() {Console.WriteLine ("new T�redi4.metot()");}}
    class �ekil {
        double en, boy; //private
        string ad; // private
        public �ekil() {En = Boy = 0.0; Ad = "null";} //Parametresiz kurucu ilkde�erlemesi
        public �ekil (double e, double b, string a) {En = e; Boy = b; Ad = a;}  //3 parametreli kurucu
        public �ekil (double x, string a) {En = Boy = x; Ad = a;} //2 (e�itkenar) parametreli kurucu
        public �ekil (�ekil nes) {En = nes.En; Boy = nes.Boy; Ad = nes.Ad;} //1 (nesne) parametreli kurucu
        public double En {get {return en;} set {en = value;}} //Eri�ilmez alan-lara eri�ebilen get-set'li �zellik-ler
        public double Boy {get {return boy;} set {boy = value;}}
        public string Ad {get {return ad;} set {ad = value;}}
        public void enboyG�ster() {Console.Write (" (en, boy) = ({0}, {1})", En, Boy);}
        public virtual double alan() {Console.Write (", Genel alan() esge�ilmelidir"); return 0.0;}
    }
    class ��gen : �ekil {
        string �eklinAd�; //private
        public ��gen() {�eklinAd� = "null";} //Kurucular
        public ��gen (string a, double e, double b) : base (e, b, "��gen") {�eklinAd� = a;}
        public ��gen (double x) : base (x, "��gen") {�eklinAd� = "�kizkenar";}
        public ��gen (��gen nes) : base (nes) {�eklinAd� = nes.�eklinAd�;}
        public override double alan() {return En * Boy / 2;} // temel'deki virtual'a override metot
        public void �eklinAd�n�G�ster() {Console.WriteLine ("��genin tipi: " + �eklinAd�);}
    }
    class Dikd�rtgen : �ekil {
        public Dikd�rtgen (double e, double b) : base (e, b, "Dikd�rtgen"){}
        public Dikd�rtgen (double x) : base (x, "Kare"){}
        public Dikd�rtgen (Dikd�rtgen nes) : base (nes){}
        public bool kareMi() {if (En == Boy) return true; return false;}
        public override double alan() {return En * Boy;}
    }
    abstract public class ParaBirimi {
        private decimal yuro = 0M; //[Euro]
        public abstract decimal TlYuro {get; set;}
        public decimal Yuro {get{return yuro;} set{yuro = value;}}
    }
    public class TL : ParaBirimi {
        private static decimal tlYuro = 1/30M;
        public override decimal TlYuro {get{return Yuro * tlYuro;} set{Yuro = value / tlYuro;}}
    }
    public class Dolar : ParaBirimi {
        public decimal DYuro;
        public void �lkD (decimal DY) {DYuro = DY;}
        public override decimal TlYuro {get{return Yuro * DYuro;} set{Yuro = value / DYuro;}}
    }
    class S�n�f1 {public virtual void Selam() {Console.Write ("S�n�f1'den herkese merhabalar!");}}
    class S�n�f2 : S�n�f1 {public override void Selam() {base.Selam(); Console.Write (" ve S�n�f2'den de herkese merhabalar!");}}
    class S�n�f3 : S�n�f2 {public override void Selam() {base.Selam(); Console.Write (" ve S�n�f3'den de herkese merhabalar!");}}
    class A {virtual public void Yaz() {Console.WriteLine ("Temel A s�n�f�n�n virtual Yaz() metodu.");}}
    class B : A {override public void Yaz() {Console.WriteLine ("T�redi-1 B s�n�f�n�n override Yaz() metodu.");}}
    class C : B {new public void Yaz() {Console.WriteLine ("T�redi-2 C s�n�f�n�n new Yaz() metodu.");}}
    class D : B {override public void Yaz() {Console.WriteLine ("T�redi-3 D s�n�f�n�n override Yaz() metodu.");}}
    class SanalMetot2 {
        static void Main() {
            Console.Write ("T�rediler ebeveyn virtual'�n kendi override metodunu kullan�r; new metot kendi tiplemesiyse kullan�l�r, ancak ref-tiplemeyse new de�il hiyerar�ik override metot aran�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'virtual' temel ve 'override' t�redi metotla kodlama de�i�ikli�i:");
            Temel1 tem1 = new Temel1();
            T�redi1 t�r1 = new T�redi1();
            T�redi2 t�r2 = new T�redi2();
            T�redi3 t�r3 = new T�redi3();
            T�redi4 t�r4 = new T�redi4();
            Temel1 tem1Ref; //Temel1'li referans
            Console.WriteLine ("\tTemel1 referansl� Temel1 tipleme."); tem1Ref = tem1; tem1Ref.metot();
            Console.WriteLine ("\tTemel1 ve T�redi1 referansl� override'l� T�redi1 tipleme."); tem1Ref = t�r1; tem1Ref.metot(); t�r1.metot();
            Console.WriteLine ("\tTemel1 ve T�redi2 referansl� override'l� T�redi2 tipleme."); tem1Ref = t�r2; tem1Ref.metot(); t�r2.metot();
            Console.WriteLine ("\tTemel1 ve T�redi3 referansl� override's�z T�redi3 tipleme."); tem1Ref = t�r3; tem1Ref.metot(); t�r3.metot();
            Console.WriteLine ("\tTemel1 ve T�redi4 referansl� new'l� T�redi4 tipleme."); tem1Ref = t�r4; tem1Ref.metot(); t�r4.metot();

            Console.WriteLine ("\n�ekil temelli ��gen ve dikd�rtgen'de 'virtual-->override' alan():");
            var r=new Random(); double ds1, ds2; int i;
            ds1=r.Next (0, 100) + r.Next (0, 100) / 100D; ds2=r.Next (0, 100) + r.Next (0, 100) / 100D;
            �ekil[] �ekiller = new �ekil [5];
            �ekiller [0] = new ��gen ("Dik", ds1, ds2);
            �ekiller [1] = new Dikd�rtgen (ds1);
            �ekiller [2] = new Dikd�rtgen (ds1, ds2);
            �ekiller [3] = new ��gen (ds1);
            �ekiller [4] = new �ekil (ds1, ds2, "Genel");
            for (i=0; i < �ekiller.Length; i++) {
              Console.Write (�ekiller[i].Ad); �ekiller[i].enboyG�ster();
              Console.Write (", alan = {0: #,0.00}\n", �ekiller[i].alan());
            }

            Console.WriteLine ("\nParaBirimi.TlYuro()'yu esge�en TL ve Dolar metotlar�;");
            TL lira = new TL();
            lira.TlYuro = 1/30M;
            Console.WriteLine ("1 TL-->? Yuro �evrimi: {0} EU", lira.TlYuro);
            Console.WriteLine ("1 Yuro-->? TL �evrimi: {0} TL", 1/ lira.TlYuro);
            Dolar dolar = new Dolar();
            dolar.�lkD (0.91M);
            dolar.Yuro = lira.Yuro;
            Console.WriteLine ("1 Dolar-->? Yuro �evrimi: {0} EU", dolar.TlYuro);
            Console.WriteLine ("1 Yuro-->? Dolar �evrimi: {0} $", 1/dolar.TlYuro);
            dolar.TlYuro = 1/0.91M * dolar.TlYuro;
            lira.Yuro = dolar.Yuro;
            Console.WriteLine ("1 TL-->? Dolar �evrimi: {0} $", lira.TlYuro);
            Console.WriteLine ("1 Dolar-->? TL �evrimi: {0} TL", 1/lira.TlYuro);

            Console.WriteLine ("\nS�n�f hiyerar�isinde virtual-override-base metotlar ili�kisi:");
            S�n�f1 s1 = new S�n�f1(); s1.Selam(); Console.WriteLine();
            S�n�f2 s2 = new S�n�f2(); s2.Selam(); Console.WriteLine();
            S�n�f3 s3 = new S�n�f3(); s3.Selam(); Console.WriteLine();

            Console.WriteLine ("\nnew Yaz() ref'liyse ilk ebeveyn override Yaz()'� arar:");
            C trc = new C(); trc.Yaz(); //Kendi new Yaz()
            D trd = new D(); trd.Yaz(); //Kendi override Yaz()
            A aref = (A)trc; aref.Yaz(); //Bir �st override Yaz()
            aref = (A)trd; aref.Yaz(); //Kendi override Yaz()

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}