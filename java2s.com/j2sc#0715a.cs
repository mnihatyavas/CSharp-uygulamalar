// j2sc#0715a.cs: Temel/t�redi ayn� adl� virtual/override metotlar�n �a�r�lmas� �rne�i.

using System;
namespace S�n�flar {
    class ��g�ren {
        public string isim, tip;
        public float saat�creti, saat, maa�;
        public ��g�ren (string isim, float saat�creti, float saat) {//�ift parametreli kurucu
            this.isim = isim;
            this.saat = saat;
            this.saat�creti = saat�creti;
        }
        virtual public void maa��Hesapla() {maa� = saat * saat�creti;} //Sanal metot
        virtual public void i�g�renTipi() {tip = "��g�ren";}
    }
    class Y�netici: ��g�ren {
        public Y�netici (string isim, float saat�creti, float saat) : base (isim, saat�creti, saat){}//Kurucu
        override public void maa��Hesapla() {//Temel'inki esge�ilecek
            if (base.saat < 10F) base.saat = 10F; //Y�neticinin (�al��masa da) enaz maa��
            base.maa� = base.saat * base.saat�creti;
        }
        override public void i�g�renTipi() {base.tip = "Departman M�d�r�";}//Temel'inki esge�ilecek
    }
    class Temel1 {public virtual void Metot1() {Console.WriteLine ("virtual Temel1.Metot1()");}}
    class T�redi1: Temel1 {
        public override void Metot1() {Console.WriteLine ("override T�redi1.Metot1()");}
    }
    class T�redi2: Temel1 {
        public new virtual void Metot1() {Console.WriteLine ("new virtual T�redi2.Metot1()");}
    }
    class T�redi3: Temel1 {
        public virtual void Metot1() {Console.WriteLine ("virtual T�redi3.Metot1()");} //Derleme ikaz�: new veya override kullan
    }
    class T�redi4: Temel1 {
        public new void Metot1() {Console.WriteLine ("new T�redi4.Metot1()");}
    }
    class T�redi5: Temel1 {
        public void Metot1() {Console.WriteLine ("T�redi5.Metot1()");} //Derleme ikaz�: new veya override kullan
    }
    public class A {public virtual void G�ster() {Console.WriteLine ("S�n�f A'n�n G�ster() metodu");}}
    public class B: A {public override void G�ster() {Console.WriteLine ("S�n�f B'nin G�ster() metodu");}}
    public class C: B {public override void G�ster() {Console.WriteLine ("S�n�f C'nin G�ster() metodu");}}
    public class TemelAraba {
        public string marka;
        public string model;
        public TemelAraba (string marka, string model) {this.marka = marka; this.model = model;}
        public virtual void S�ratlen() {
            Console.WriteLine ("\tTemelAraba.S�ratlen() metodu");
            Console.WriteLine ("{0}-{1} s�ratleniyor.", marka, model);
        }
    }
    public class T�rediAraba : TemelAraba {
        public T�rediAraba (string marka, string model) : base (marka, model){}
        public new void S�ratlen() {
            Console.WriteLine ("\tT�rediAraba.S�ratlen() metodu");
            Console.WriteLine ("{0}-{1} s�ratleniyor.", marka, model);
        }
    }
    public class Arabam1 : TemelAraba {
        public Arabam1 (string make, string model) : base (make, model){}
        public override void S�ratlen() {Console.WriteLine ("{0}'nin gaz pedal� k�kleniyor", model); base.S�ratlen();}
    }
    public class Arabam2 : TemelAraba {
        public Arabam2 (string make, string model) : base (make, model) {}
        public override void S�ratlen() {Console.WriteLine ("{0}'nin gaz klapesi a��l�yor", model); base.S�ratlen();}
    }
    class SanalMetot1 {
        static void Main() {
            Console.Write ("Statik veya soyut olamayan virtual/sanal metot temel s�n�fta beyan edilirse, t�redi s�n�f metotlar�nda ayn� tiple ve override/esge�meyle i�erik kodlamas� de�i�tirilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'virtual' temel ve 'override' t�redi metotla kodlama de�i�ikli�i:");
            ��g�ren[] i�gDizi = new ��g�ren [5]; int i;
            i�gDizi [0] = new ��g�ren ("Hatice Yava� Ka�ar", 160.50F, 100F); i�gDizi [0].maa��Hesapla(); i�gDizi [0].i�g�renTipi();
            i�gDizi [1] = new ��g�ren ("Y�cel K���kbay", 110.50F, 200F); i�gDizi [1].maa��Hesapla(); i�gDizi [1].i�g�renTipi();
            i�gDizi [2] = new Y�netici ("Nihat Ka�ar", 200.5F, 130F); i�gDizi [2].maa��Hesapla(); i�gDizi [2].i�g�renTipi();
            i�gDizi [3] = new ��g�ren ("S�heyla Yava� �zbay", 160.50F, 0F); i�gDizi [3].maa��Hesapla(); i�gDizi [3].i�g�renTipi();
            i�gDizi [4] = new Y�netici ("Fatih �zbay", 200.5F, 0F); i�gDizi [4].maa��Hesapla(); i�gDizi [4].i�g�renTipi();
            for (i=0; i<5;i++) Console.WriteLine ("(isim, maa�, tip): ({0}, {1:#,0.00}TL, {2})", i�gDizi [i].isim, i�gDizi [i].maa�, i�gDizi [i].tip);

            Console.WriteLine ("\nRef T�redi de�il Temel'se override hari� tipleme Temel1.Metot1() �a��r�r:");
            Temel1 t1=new Temel1(); t1.Metot1();
            t1=new T�redi1(); t1.Metot1(); T�redi1 t11=new T�redi1(); t11.Metot1();
            t1=new T�redi2(); t1.Metot1(); T�redi2 t22=new T�redi2(); t22.Metot1();
            t1=new T�redi3(); t1.Metot1(); T�redi3 t33=new T�redi3(); t33.Metot1();
            t1=new T�redi4(); t1.Metot1(); T�redi4 t44=new T�redi4(); t44.Metot1();
            t1=new T�redi5(); t1.Metot1(); T�redi5 t55=new T�redi5(); t55.Metot1();

            Console.WriteLine ("\nvirtual'�n t�redi override'lar� ref farketmeden tipleme metoda esge�er:");
            A ab = new B(); ab.G�ster();
            B bb = new B(); bb.G�ster();
            A ac = new C(); ac.G�ster();
            C cc = new C(); cc.G�ster();
            B bc = new C(); bc.G�ster();

            Console.WriteLine ("\nTemel ref'li t�redinin new metodu override gibi de�ildir:");
            Console.WriteLine ("==>Bir T�rediAraba nesnesi yarat�l�yor..."); T�rediAraba tra = new T�rediAraba ("Toyota", "MR2");
            Console.WriteLine ("ta.S�ratlen() metodu �a�r�l�yor..."); tra.S�ratlen();
            Console.WriteLine ("==>Bir TemelAraba nesnesi yarat�l�yor..."); TemelAraba tma = new TemelAraba ("Tofa�", "Kartal");
            Console.WriteLine ("tma.S�ratlen() metodu �a�r�l�yor..."); tma.S�ratlen();
            Console.WriteLine ("==>Bir TemelAraba ref'li T�rediAraba nesnesi yarat�l�yor..."); TemelAraba tmtra = new T�rediAraba ("BMW", "Ko�");
            Console.WriteLine ("tmtra.S�ratlen() metodu �a�r�l�yor..."); tmtra.S�ratlen();

            Console.WriteLine ("\noverride'la beraber temel metot da base.S�ratlen()'le �a�r�labilir:");
            Console.WriteLine ("==>�lk Araba nesnesi yarat�l�yor..."); Arabam1 ar1 = new Arabam1 ("Toyota", "MR2"); ar1.S�ratlen();
            Console.WriteLine ("==>�kinci Araba nesnesi yarat�l�yor..."); Arabam2 ar2 = new Arabam2 ("Harley-Davidson", "V-Rod"); ar2.S�ratlen();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}