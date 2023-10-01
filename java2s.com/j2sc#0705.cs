// j2sc#0705.cs: Sýnýf üye deðiþkenlerine deðer atama ve eriþim örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        private static long gsm; public long AlGsm() {return gsm;} public void KoyGsm (long tel) {gsm = tel;}
        protected long tcno; public long AlTcno() {return tcno;} public void KoyTcno (long no) {tcno = no;}
        public string isim; //{get {return isim;} set {isim=value;}}
        internal string eposta; public string AlEposta() {return eposta;} public void KoyEposta (string ep) {eposta = ep;}
        protected internal int yaþ; public int AlYaþ() {return yaþ;} public void KoyYaþ (int yaþ) {this.yaþ = yaþ;}
        private DateTime tarih = DateTime.Now; public DateTime AlTarih() {return tarih;}
    }
    class PC {
        public string marka = "Compaq";
        public string model = "Presario CQ56";
        public string renk;
        public int imalYýlý = 2018;
        public void Baþlat() {Console.WriteLine ("Ben {0} yýlýnda imal edildim.", imalYýlý);}
    }
    class Ýþgören {
        private string isim; public string AlÝsim() {return isim;}
        protected float saatÜcreti;
        public Ýþgören (string isim, float saatÜcreti) {this.isim = isim; this.saatÜcreti = saatÜcreti;} //Kurucu
        public float AylýkMaaþ (float saat) {return saat * saatÜcreti;}
        public string Statü() {return "Ýþgören";}
    
    }
    class Daire {
        private float pi = (float)Math.PI;
        float y;
        public Daire(): this ((float)Math.PI){}
        public Daire (float y) {this.y = y;}
        public double DaireÇevresi() {return 2 * pi * y;}
        public double DaireAlaný() {return pi * y * y;}
        public double DaireHacmi() {return 4 / 3 * pi * y * y * y;}
    }
    public class A {
        protected internal int x;
        public A (int x) {this.x = x;} //Parametreli kurucu
        public A() : this (2023){} //Üye x'e kurucuyla ilk deðer atama
        public int AlX(){return x;}
    }
    public class B: A {public B() : base (new Random().Next(1000,10000)){} }
    class Temel {
        public int x = 2023; //Ýlkdeðerli üye alan
        public Temel() {//Parametresiz kurucu
            Console.WriteLine ("Ýlkdeðer: Temel.Temel(int x) = {0}", x);
        }
        public Temel (int x) {//Parametreli kurucu
            Console.WriteLine ("\tTemel.Temel(int x) = {0}", x);
            this.x = x;
        }
    }
    class Türedi : Temel {//Ýlk kurucu parametresi temel'e (x=a)
        public int a = 1938;
        public int b = 1881;
        public Türedi (int a): base (a) {//Tek parametreli kurucu
            Console.WriteLine ("Türedi.Türedi(int a) = {0}", a);
            this.a = a;
        }
        public Türedi (int a, int b): this (a) {//Çift parametreli kurucu
            Console.WriteLine ("Türedi.Türedi (int a, int b) = ({0}, {1})", a, b);
            this.a = a;
            this.b = b;
        }
    }
    public class Motor {
        public int silindir;
        public int beygirgücü;
        public void Çalýþtýr() {Console.WriteLine ("Motor çalýþtý");}
    }
    public class Araba {
        public string marka;
        public Motor motor;  //Araba'nýn motoru var
        public void Çalýþtýr() {motor.Çalýþtýr();}
    }
    class ÜyeDeðiþken {
        static void Main() {
            Console.Write ("Public sýnýf-alanýna direk set/get'le veri konulup alýnabilir. Diðer sýnýrlý eriþimlere public Al/Koy metotlarla veri alýnýp/konulabilir. Miraslayan yavru ebeveyn üye alanýna base(a), this(a) ile deðer aktarabilir. Bir nesne miraslamadan baþka bir nesne yaratýp üye deðiþken ve metotlarýný kullanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf (public/private) üye alanlarýna veri koyma/alma yöntemleri:");
            Sýnýf1 kiþi1 = new Sýnýf1(); Sýnýf1 kiþi2 = new Sýnýf1();
            kiþi1.KoyGsm (905515559565L); kiþi1.KoyTcno (43879313287L); kiþi1.isim="M.Nihat Yavaþ"; kiþi1.KoyEposta ("mnihat@gmail.com"); kiþi1.KoyYaþ (2023 - 1951);
            kiþi2.KoyGsm (905055559562L); kiþi2.KoyTcno (43877313287L); kiþi2.isim="Zafer N.Candan"; kiþi2.KoyEposta ("zcandant@gmail.com"); kiþi2.KoyYaþ (2023 - 1978);
            Console.WriteLine ("Ýsim = {0},\tTCNo = {1},\tGSM = {2},\tEposta = {3},\tYaþ = {4},\tTarih = [{5}]", kiþi1.isim, kiþi1.AlTcno(), kiþi1.AlGsm(), kiþi1.AlEposta(), kiþi1.AlYaþ(), kiþi1.AlTarih());
            Console.WriteLine ("Ýsim = {0},\tTCNo = {1},\tGSM = {2},\tEposta = {3},\tYaþ = {4},\tTarih = [{5}]", kiþi2.isim, kiþi2.AlTcno(), kiþi2.AlGsm(), kiþi2.AlEposta(), kiþi2.AlYaþ(), kiþi2.AlTarih());

            Console.WriteLine ("\nÝlkdeðerli sýnýf deðiþkenleri ve metoduna public eriþim:");
            PC dizüstüPC = new PC();
            Console.WriteLine ("dizüstüPC.marka = " + dizüstüPC.marka);
            Console.WriteLine ("dizüstüPC.model = " + dizüstüPC.model);
            if (dizüstüPC.renk == null) Console.WriteLine ("Henüz dizüstüPC.renk deðerim yok/null");
            dizüstüPC.renk = "Siyah";
            Console.WriteLine ("dizüstüPC.renk = " + dizüstüPC.renk);
            //Console.WriteLine ("dizüstüPC.imalYýlý = " + dizüstüPC.imalYýlý);
            dizüstüPC.Baþlat();

            Console.WriteLine ("\nKuruculu ve eriþimsiz sýnýf üyeli iþgören bordrosu:");
            Ýþgören iþg1 = new Ýþgören ("M.Nedim Yavaþ", 225.68F);
            Ýþgören iþg2 = new Ýþgören ("Yücel Küçükbay", 312.65F);
            Ýþgören iþg3 = new Ýþgören ("Süheyla Özbay", 186.17F);
            Console.WriteLine ("Ýsim: {0},\tMaaþ: {1:#,0.00}TL,\tStatü: {2}", iþg1.AlÝsim(), iþg1.AylýkMaaþ (40), iþg1.Statü());
            Console.WriteLine ("Ýsim: {0},\tMaaþ: {1:#,0.00}TL,\tStatü: {2}", iþg2.AlÝsim(), iþg2.AylýkMaaþ (48), iþg2.Statü());
            Console.WriteLine ("Ýsim: {0},\tMaaþ: {1:#,0.00}TL,\tStatü: {2}", iþg3.AlÝsim(), iþg3.AylýkMaaþ (28), iþg3.Statü());

            Console.WriteLine ("\nÇift kurucuyla sabit pi ve deðiþken yarýçaplý daire hesaplarý:");
            var r=new Random(); int i, j;
            Daire d1; float y;
            for (i=0; i<5; i++) {
                y=r.Next (0, 100)+r.Next (0, 1000)/10000F;
                d1 = new Daire (y);
                Console.WriteLine ("Yarýçapý = {0} olan dairenin (çevre, alan, hacim) =\n\t({1:#,#.#0}, {2:#,#.#0}, {3:#,#.#0}) birim2", y, d1.DaireÇevresi(), d1.DaireAlaný(), d1.DaireHacmi());
            }

            Console.WriteLine ("\nA sýnýfý miraslayan B'nin A.x üyesine rasgele ilkdeðer atama:");
            Console.WriteLine ("Ýlk A.x = {0}", new A().AlX());
            B b1 = new B();
            Console.WriteLine ("Rasgele A.x = {0}", b1.x);

            Console.WriteLine ("\nYalýn ebeveyn ve miraslayan yavrunun çeþitli parametreli tiplenmesi:");
            Temel tm = new Temel();
            i=r.Next (1000, 10000);
            tm = new Temel (i);
            i=r.Next (1000, 10000);
            Türedi tr = new Türedi (i);
            i=r.Next (1000, 10000); j=r.Next (1000, 10000);
            tr = new Türedi (i, j);

            Console.WriteLine ("\nAraba'nýn motor nesnesi üyelerini (miraslamadan) tipleyerek kullanabilmesi:");
            Console.WriteLine ("Bir Araba nesnesi yaratýlýyor...");
            Araba arabam = new Araba();
            arabam.marka = "Toyoto";
            Console.WriteLine ("Araba nesnesi bir motor nesnesi yaratýyor...");
            arabam.motor = new Motor();
            arabam.motor.silindir = 4;
            arabam.motor.beygirgücü = 180;
            Console.WriteLine ("arabam.marka = " + arabam.marka);
            Console.WriteLine ("arabam.motor.silindir = " + arabam.motor.silindir);
            Console.WriteLine ("arabam.motor.beygirgücü = " + arabam.motor.beygirgücü);
            arabam.Çalýþtýr();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}