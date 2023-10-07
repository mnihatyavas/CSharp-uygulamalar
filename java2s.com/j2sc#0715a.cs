// j2sc#0715a.cs: Temel/türedi aynı adlı virtual/override metotların çağrılması örneği.

using System;
namespace Sınıflar {
    class İşgören {
        public string isim, tip;
        public float saatÜcreti, saat, maaş;
        public İşgören (string isim, float saatÜcreti, float saat) {//Çift parametreli kurucu
            this.isim = isim;
            this.saat = saat;
            this.saatÜcreti = saatÜcreti;
        }
        virtual public void maaşıHesapla() {maaş = saat * saatÜcreti;} //Sanal metot
        virtual public void işgörenTipi() {tip = "İşgören";}
    }
    class Yönetici: İşgören {
        public Yönetici (string isim, float saatÜcreti, float saat) : base (isim, saatÜcreti, saat){}//Kurucu
        override public void maaşıHesapla() {//Temel'inki esgeçilecek
            if (base.saat < 10F) base.saat = 10F; //Yöneticinin (çalışmasa da) enaz maaşı
            base.maaş = base.saat * base.saatÜcreti;
        }
        override public void işgörenTipi() {base.tip = "Departman Müdürü";}//Temel'inki esgeçilecek
    }
    class Temel1 {public virtual void Metot1() {Console.WriteLine ("virtual Temel1.Metot1()");}}
    class Türedi1: Temel1 {
        public override void Metot1() {Console.WriteLine ("override Türedi1.Metot1()");}
    }
    class Türedi2: Temel1 {
        public new virtual void Metot1() {Console.WriteLine ("new virtual Türedi2.Metot1()");}
    }
    class Türedi3: Temel1 {
        public virtual void Metot1() {Console.WriteLine ("virtual Türedi3.Metot1()");} //Derleme ikazı: new veya override kullan
    }
    class Türedi4: Temel1 {
        public new void Metot1() {Console.WriteLine ("new Türedi4.Metot1()");}
    }
    class Türedi5: Temel1 {
        public void Metot1() {Console.WriteLine ("Türedi5.Metot1()");} //Derleme ikazı: new veya override kullan
    }
    public class A {public virtual void Göster() {Console.WriteLine ("Sınıf A'nın Göster() metodu");}}
    public class B: A {public override void Göster() {Console.WriteLine ("Sınıf B'nin Göster() metodu");}}
    public class C: B {public override void Göster() {Console.WriteLine ("Sınıf C'nin Göster() metodu");}}
    public class TemelAraba {
        public string marka;
        public string model;
        public TemelAraba (string marka, string model) {this.marka = marka; this.model = model;}
        public virtual void Süratlen() {
            Console.WriteLine ("\tTemelAraba.Süratlen() metodu");
            Console.WriteLine ("{0}-{1} süratleniyor.", marka, model);
        }
    }
    public class TürediAraba : TemelAraba {
        public TürediAraba (string marka, string model) : base (marka, model){}
        public new void Süratlen() {
            Console.WriteLine ("\tTürediAraba.Süratlen() metodu");
            Console.WriteLine ("{0}-{1} süratleniyor.", marka, model);
        }
    }
    public class Arabam1 : TemelAraba {
        public Arabam1 (string make, string model) : base (make, model){}
        public override void Süratlen() {Console.WriteLine ("{0}'nin gaz pedalı kökleniyor", model); base.Süratlen();}
    }
    public class Arabam2 : TemelAraba {
        public Arabam2 (string make, string model) : base (make, model) {}
        public override void Süratlen() {Console.WriteLine ("{0}'nin gaz klapesi açılıyor", model); base.Süratlen();}
    }
    class SanalMetot1 {
        static void Main() {
            Console.Write ("Statik veya soyut olamayan virtual/sanal metot temel sınıfta beyan edilirse, türedi sınıf metotlarında aynı tiple ve override/esgeçmeyle içerik kodlaması değiştirilebilir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'virtual' temel ve 'override' türedi metotla kodlama değişikliği:");
            İşgören[] işgDizi = new İşgören [5]; int i;
            işgDizi [0] = new İşgören ("Hatice Yavaş Kaçar", 160.50F, 100F); işgDizi [0].maaşıHesapla(); işgDizi [0].işgörenTipi();
            işgDizi [1] = new İşgören ("Yücel Küçükbay", 110.50F, 200F); işgDizi [1].maaşıHesapla(); işgDizi [1].işgörenTipi();
            işgDizi [2] = new Yönetici ("Nihat Kaçar", 200.5F, 130F); işgDizi [2].maaşıHesapla(); işgDizi [2].işgörenTipi();
            işgDizi [3] = new İşgören ("Süheyla Yavaş Özbay", 160.50F, 0F); işgDizi [3].maaşıHesapla(); işgDizi [3].işgörenTipi();
            işgDizi [4] = new Yönetici ("Fatih Özbay", 200.5F, 0F); işgDizi [4].maaşıHesapla(); işgDizi [4].işgörenTipi();
            for (i=0; i<5;i++) Console.WriteLine ("(isim, maaş, tip): ({0}, {1:#,0.00}TL, {2})", işgDizi [i].isim, işgDizi [i].maaş, işgDizi [i].tip);

            Console.WriteLine ("\nRef Türedi değil Temel'se override hariç tipleme Temel1.Metot1() çağırır:");
            Temel1 t1=new Temel1(); t1.Metot1();
            t1=new Türedi1(); t1.Metot1(); Türedi1 t11=new Türedi1(); t11.Metot1();
            t1=new Türedi2(); t1.Metot1(); Türedi2 t22=new Türedi2(); t22.Metot1();
            t1=new Türedi3(); t1.Metot1(); Türedi3 t33=new Türedi3(); t33.Metot1();
            t1=new Türedi4(); t1.Metot1(); Türedi4 t44=new Türedi4(); t44.Metot1();
            t1=new Türedi5(); t1.Metot1(); Türedi5 t55=new Türedi5(); t55.Metot1();

            Console.WriteLine ("\nvirtual'ın türedi override'ları ref farketmeden tipleme metoda esgeçer:");
            A ab = new B(); ab.Göster();
            B bb = new B(); bb.Göster();
            A ac = new C(); ac.Göster();
            C cc = new C(); cc.Göster();
            B bc = new C(); bc.Göster();

            Console.WriteLine ("\nTemel ref'li türedinin new metodu override gibi değildir:");
            Console.WriteLine ("==>Bir TürediAraba nesnesi yaratılıyor..."); TürediAraba tra = new TürediAraba ("Toyota", "MR2");
            Console.WriteLine ("ta.Süratlen() metodu çağrılıyor..."); tra.Süratlen();
            Console.WriteLine ("==>Bir TemelAraba nesnesi yaratılıyor..."); TemelAraba tma = new TemelAraba ("Tofaş", "Kartal");
            Console.WriteLine ("tma.Süratlen() metodu çağrılıyor..."); tma.Süratlen();
            Console.WriteLine ("==>Bir TemelAraba ref'li TürediAraba nesnesi yaratılıyor..."); TemelAraba tmtra = new TürediAraba ("BMW", "Koç");
            Console.WriteLine ("tmtra.Süratlen() metodu çağrılıyor..."); tmtra.Süratlen();

            Console.WriteLine ("\noverride'la beraber temel metot da base.Süratlen()'le çağrılabilir:");
            Console.WriteLine ("==>İlk Araba nesnesi yaratılıyor..."); Arabam1 ar1 = new Arabam1 ("Toyota", "MR2"); ar1.Süratlen();
            Console.WriteLine ("==>İkinci Araba nesnesi yaratılıyor..."); Arabam2 ar2 = new Arabam2 ("Harley-Davidson", "V-Rod"); ar2.Süratlen();

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}