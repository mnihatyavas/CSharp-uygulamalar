// j2sc#0715b.cs: Çoklu hiyerarþide virtual-override-new iliþkileri örneði.

using System;
namespace Sýnýflar {
    class Temel1 {public virtual void metot() {Console.WriteLine ("Temel1.metot()");}}
    class Türedi1 : Temel1 {public override void metot() {Console.WriteLine ("override Türedi1.metot()");}}
    class Türedi2 : Temel1 {public override void metot() {Console.WriteLine ("override Türedi2.metot()");}}
    class Türedi3 : Temel1 {} //override metot yok
    class Türedi4 : Temel1 {public new void metot() {Console.WriteLine ("new Türedi4.metot()");}}
    class Þekil {
        double en, boy; //private
        string ad; // private
        public Þekil() {En = Boy = 0.0; Ad = "null";} //Parametresiz kurucu ilkdeðerlemesi
        public Þekil (double e, double b, string a) {En = e; Boy = b; Ad = a;}  //3 parametreli kurucu
        public Þekil (double x, string a) {En = Boy = x; Ad = a;} //2 (eþitkenar) parametreli kurucu
        public Þekil (Þekil nes) {En = nes.En; Boy = nes.Boy; Ad = nes.Ad;} //1 (nesne) parametreli kurucu
        public double En {get {return en;} set {en = value;}} //Eriþilmez alan-lara eriþebilen get-set'li özellik-ler
        public double Boy {get {return boy;} set {boy = value;}}
        public string Ad {get {return ad;} set {ad = value;}}
        public void enboyGöster() {Console.Write (" (en, boy) = ({0}, {1})", En, Boy);}
        public virtual double alan() {Console.Write (", Genel alan() esgeçilmelidir"); return 0.0;}
    }
    class Üçgen : Þekil {
        string þeklinAdý; //private
        public Üçgen() {þeklinAdý = "null";} //Kurucular
        public Üçgen (string a, double e, double b) : base (e, b, "Üçgen") {þeklinAdý = a;}
        public Üçgen (double x) : base (x, "üçgen") {þeklinAdý = "Ýkizkenar";}
        public Üçgen (Üçgen nes) : base (nes) {þeklinAdý = nes.þeklinAdý;}
        public override double alan() {return En * Boy / 2;} // temel'deki virtual'a override metot
        public void þeklinAdýnýGöster() {Console.WriteLine ("Üçgenin tipi: " + þeklinAdý);}
    }
    class Dikdörtgen : Þekil {
        public Dikdörtgen (double e, double b) : base (e, b, "Dikdörtgen"){}
        public Dikdörtgen (double x) : base (x, "Kare"){}
        public Dikdörtgen (Dikdörtgen nes) : base (nes){}
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
        public void ÝlkD (decimal DY) {DYuro = DY;}
        public override decimal TlYuro {get{return Yuro * DYuro;} set{Yuro = value / DYuro;}}
    }
    class Sýnýf1 {public virtual void Selam() {Console.Write ("Sýnýf1'den herkese merhabalar!");}}
    class Sýnýf2 : Sýnýf1 {public override void Selam() {base.Selam(); Console.Write (" ve Sýnýf2'den de herkese merhabalar!");}}
    class Sýnýf3 : Sýnýf2 {public override void Selam() {base.Selam(); Console.Write (" ve Sýnýf3'den de herkese merhabalar!");}}
    class A {virtual public void Yaz() {Console.WriteLine ("Temel A sýnýfýnýn virtual Yaz() metodu.");}}
    class B : A {override public void Yaz() {Console.WriteLine ("Türedi-1 B sýnýfýnýn override Yaz() metodu.");}}
    class C : B {new public void Yaz() {Console.WriteLine ("Türedi-2 C sýnýfýnýn new Yaz() metodu.");}}
    class D : B {override public void Yaz() {Console.WriteLine ("Türedi-3 D sýnýfýnýn override Yaz() metodu.");}}
    class SanalMetot2 {
        static void Main() {
            Console.Write ("Türediler ebeveyn virtual'ýn kendi override metodunu kullanýr; new metot kendi tiplemesiyse kullanýlýr, ancak ref-tiplemeyse new deðil hiyerarþik override metot aranýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'virtual' temel ve 'override' türedi metotla kodlama deðiþikliði:");
            Temel1 tem1 = new Temel1();
            Türedi1 tür1 = new Türedi1();
            Türedi2 tür2 = new Türedi2();
            Türedi3 tür3 = new Türedi3();
            Türedi4 tür4 = new Türedi4();
            Temel1 tem1Ref; //Temel1'li referans
            Console.WriteLine ("\tTemel1 referanslý Temel1 tipleme."); tem1Ref = tem1; tem1Ref.metot();
            Console.WriteLine ("\tTemel1 ve Türedi1 referanslý override'lý Türedi1 tipleme."); tem1Ref = tür1; tem1Ref.metot(); tür1.metot();
            Console.WriteLine ("\tTemel1 ve Türedi2 referanslý override'lý Türedi2 tipleme."); tem1Ref = tür2; tem1Ref.metot(); tür2.metot();
            Console.WriteLine ("\tTemel1 ve Türedi3 referanslý override'sýz Türedi3 tipleme."); tem1Ref = tür3; tem1Ref.metot(); tür3.metot();
            Console.WriteLine ("\tTemel1 ve Türedi4 referanslý new'lý Türedi4 tipleme."); tem1Ref = tür4; tem1Ref.metot(); tür4.metot();

            Console.WriteLine ("\nÞekil temelli üçgen ve dikdörtgen'de 'virtual-->override' alan():");
            var r=new Random(); double ds1, ds2; int i;
            ds1=r.Next (0, 100) + r.Next (0, 100) / 100D; ds2=r.Next (0, 100) + r.Next (0, 100) / 100D;
            Þekil[] þekiller = new Þekil [5];
            þekiller [0] = new Üçgen ("Dik", ds1, ds2);
            þekiller [1] = new Dikdörtgen (ds1);
            þekiller [2] = new Dikdörtgen (ds1, ds2);
            þekiller [3] = new Üçgen (ds1);
            þekiller [4] = new Þekil (ds1, ds2, "Genel");
            for (i=0; i < þekiller.Length; i++) {
              Console.Write (þekiller[i].Ad); þekiller[i].enboyGöster();
              Console.Write (", alan = {0: #,0.00}\n", þekiller[i].alan());
            }

            Console.WriteLine ("\nParaBirimi.TlYuro()'yu esgeçen TL ve Dolar metotlarý;");
            TL lira = new TL();
            lira.TlYuro = 1/30M;
            Console.WriteLine ("1 TL-->? Yuro çevrimi: {0} EU", lira.TlYuro);
            Console.WriteLine ("1 Yuro-->? TL çevrimi: {0} TL", 1/ lira.TlYuro);
            Dolar dolar = new Dolar();
            dolar.ÝlkD (0.91M);
            dolar.Yuro = lira.Yuro;
            Console.WriteLine ("1 Dolar-->? Yuro çevrimi: {0} EU", dolar.TlYuro);
            Console.WriteLine ("1 Yuro-->? Dolar çevrimi: {0} $", 1/dolar.TlYuro);
            dolar.TlYuro = 1/0.91M * dolar.TlYuro;
            lira.Yuro = dolar.Yuro;
            Console.WriteLine ("1 TL-->? Dolar çevrimi: {0} $", lira.TlYuro);
            Console.WriteLine ("1 Dolar-->? TL çevrimi: {0} TL", 1/lira.TlYuro);

            Console.WriteLine ("\nSýnýf hiyerarþisinde virtual-override-base metotlar iliþkisi:");
            Sýnýf1 s1 = new Sýnýf1(); s1.Selam(); Console.WriteLine();
            Sýnýf2 s2 = new Sýnýf2(); s2.Selam(); Console.WriteLine();
            Sýnýf3 s3 = new Sýnýf3(); s3.Selam(); Console.WriteLine();

            Console.WriteLine ("\nnew Yaz() ref'liyse ilk ebeveyn override Yaz()'ý arar:");
            C trc = new C(); trc.Yaz(); //Kendi new Yaz()
            D trd = new D(); trd.Yaz(); //Kendi override Yaz()
            A aref = (A)trc; aref.Yaz(); //Bir üst override Yaz()
            aref = (A)trd; aref.Yaz(); //Kendi override Yaz()

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}