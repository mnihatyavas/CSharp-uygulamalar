// j2sc#0705.cs: S�n�f �ye de�i�kenlerine de�er atama ve eri�im �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        private static long gsm; public long AlGsm() {return gsm;} public void KoyGsm (long tel) {gsm = tel;}
        protected long tcno; public long AlTcno() {return tcno;} public void KoyTcno (long no) {tcno = no;}
        public string isim; //{get {return isim;} set {isim=value;}}
        internal string eposta; public string AlEposta() {return eposta;} public void KoyEposta (string ep) {eposta = ep;}
        protected internal int ya�; public int AlYa�() {return ya�;} public void KoyYa� (int ya�) {this.ya� = ya�;}
        private DateTime tarih = DateTime.Now; public DateTime AlTarih() {return tarih;}
    }
    class PC {
        public string marka = "Compaq";
        public string model = "Presario CQ56";
        public string renk;
        public int imalY�l� = 2018;
        public void Ba�lat() {Console.WriteLine ("Ben {0} y�l�nda imal edildim.", imalY�l�);}
    }
    class ��g�ren {
        private string isim; public string Al�sim() {return isim;}
        protected float saat�creti;
        public ��g�ren (string isim, float saat�creti) {this.isim = isim; this.saat�creti = saat�creti;} //Kurucu
        public float Ayl�kMaa� (float saat) {return saat * saat�creti;}
        public string Stat�() {return "��g�ren";}
    
    }
    class Daire {
        private float pi = (float)Math.PI;
        float y;
        public Daire(): this ((float)Math.PI){}
        public Daire (float y) {this.y = y;}
        public double Daire�evresi() {return 2 * pi * y;}
        public double DaireAlan�() {return pi * y * y;}
        public double DaireHacmi() {return 4 / 3 * pi * y * y * y;}
    }
    public class A {
        protected internal int x;
        public A (int x) {this.x = x;} //Parametreli kurucu
        public A() : this (2023){} //�ye x'e kurucuyla ilk de�er atama
        public int AlX(){return x;}
    }
    public class B: A {public B() : base (new Random().Next(1000,10000)){} }
    class Temel {
        public int x = 2023; //�lkde�erli �ye alan
        public Temel() {//Parametresiz kurucu
            Console.WriteLine ("�lkde�er: Temel.Temel(int x) = {0}", x);
        }
        public Temel (int x) {//Parametreli kurucu
            Console.WriteLine ("\tTemel.Temel(int x) = {0}", x);
            this.x = x;
        }
    }
    class T�redi : Temel {//�lk kurucu parametresi temel'e (x=a)
        public int a = 1938;
        public int b = 1881;
        public T�redi (int a): base (a) {//Tek parametreli kurucu
            Console.WriteLine ("T�redi.T�redi(int a) = {0}", a);
            this.a = a;
        }
        public T�redi (int a, int b): this (a) {//�ift parametreli kurucu
            Console.WriteLine ("T�redi.T�redi (int a, int b) = ({0}, {1})", a, b);
            this.a = a;
            this.b = b;
        }
    }
    public class Motor {
        public int silindir;
        public int beygirg�c�;
        public void �al��t�r() {Console.WriteLine ("Motor �al��t�");}
    }
    public class Araba {
        public string marka;
        public Motor motor;  //Araba'n�n motoru var
        public void �al��t�r() {motor.�al��t�r();}
    }
    class �yeDe�i�ken {
        static void Main() {
            Console.Write ("Public s�n�f-alan�na direk set/get'le veri konulup al�nabilir. Di�er s�n�rl� eri�imlere public Al/Koy metotlarla veri al�n�p/konulabilir. Miraslayan yavru ebeveyn �ye alan�na base(a), this(a) ile de�er aktarabilir. Bir nesne miraslamadan ba�ka bir nesne yarat�p �ye de�i�ken ve metotlar�n� kullanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f (public/private) �ye alanlar�na veri koyma/alma y�ntemleri:");
            S�n�f1 ki�i1 = new S�n�f1(); S�n�f1 ki�i2 = new S�n�f1();
            ki�i1.KoyGsm (905515559565L); ki�i1.KoyTcno (43879313287L); ki�i1.isim="M.Nihat Yava�"; ki�i1.KoyEposta ("mnihat@gmail.com"); ki�i1.KoyYa� (2023 - 1951);
            ki�i2.KoyGsm (905055559562L); ki�i2.KoyTcno (43877313287L); ki�i2.isim="Zafer N.Candan"; ki�i2.KoyEposta ("zcandant@gmail.com"); ki�i2.KoyYa� (2023 - 1978);
            Console.WriteLine ("�sim = {0},\tTCNo = {1},\tGSM = {2},\tEposta = {3},\tYa� = {4},\tTarih = [{5}]", ki�i1.isim, ki�i1.AlTcno(), ki�i1.AlGsm(), ki�i1.AlEposta(), ki�i1.AlYa�(), ki�i1.AlTarih());
            Console.WriteLine ("�sim = {0},\tTCNo = {1},\tGSM = {2},\tEposta = {3},\tYa� = {4},\tTarih = [{5}]", ki�i2.isim, ki�i2.AlTcno(), ki�i2.AlGsm(), ki�i2.AlEposta(), ki�i2.AlYa�(), ki�i2.AlTarih());

            Console.WriteLine ("\n�lkde�erli s�n�f de�i�kenleri ve metoduna public eri�im:");
            PC diz�st�PC = new PC();
            Console.WriteLine ("diz�st�PC.marka = " + diz�st�PC.marka);
            Console.WriteLine ("diz�st�PC.model = " + diz�st�PC.model);
            if (diz�st�PC.renk == null) Console.WriteLine ("Hen�z diz�st�PC.renk de�erim yok/null");
            diz�st�PC.renk = "Siyah";
            Console.WriteLine ("diz�st�PC.renk = " + diz�st�PC.renk);
            //Console.WriteLine ("diz�st�PC.imalY�l� = " + diz�st�PC.imalY�l�);
            diz�st�PC.Ba�lat();

            Console.WriteLine ("\nKuruculu ve eri�imsiz s�n�f �yeli i�g�ren bordrosu:");
            ��g�ren i�g1 = new ��g�ren ("M.Nedim Yava�", 225.68F);
            ��g�ren i�g2 = new ��g�ren ("Y�cel K���kbay", 312.65F);
            ��g�ren i�g3 = new ��g�ren ("S�heyla �zbay", 186.17F);
            Console.WriteLine ("�sim: {0},\tMaa�: {1:#,0.00}TL,\tStat�: {2}", i�g1.Al�sim(), i�g1.Ayl�kMaa� (40), i�g1.Stat�());
            Console.WriteLine ("�sim: {0},\tMaa�: {1:#,0.00}TL,\tStat�: {2}", i�g2.Al�sim(), i�g2.Ayl�kMaa� (48), i�g2.Stat�());
            Console.WriteLine ("�sim: {0},\tMaa�: {1:#,0.00}TL,\tStat�: {2}", i�g3.Al�sim(), i�g3.Ayl�kMaa� (28), i�g3.Stat�());

            Console.WriteLine ("\n�ift kurucuyla sabit pi ve de�i�ken yar��apl� daire hesaplar�:");
            var r=new Random(); int i, j;
            Daire d1; float y;
            for (i=0; i<5; i++) {
                y=r.Next (0, 100)+r.Next (0, 1000)/10000F;
                d1 = new Daire (y);
                Console.WriteLine ("Yar��ap� = {0} olan dairenin (�evre, alan, hacim) =\n\t({1:#,#.#0}, {2:#,#.#0}, {3:#,#.#0}) birim2", y, d1.Daire�evresi(), d1.DaireAlan�(), d1.DaireHacmi());
            }

            Console.WriteLine ("\nA s�n�f� miraslayan B'nin A.x �yesine rasgele ilkde�er atama:");
            Console.WriteLine ("�lk A.x = {0}", new A().AlX());
            B b1 = new B();
            Console.WriteLine ("Rasgele A.x = {0}", b1.x);

            Console.WriteLine ("\nYal�n ebeveyn ve miraslayan yavrunun �e�itli parametreli tiplenmesi:");
            Temel tm = new Temel();
            i=r.Next (1000, 10000);
            tm = new Temel (i);
            i=r.Next (1000, 10000);
            T�redi tr = new T�redi (i);
            i=r.Next (1000, 10000); j=r.Next (1000, 10000);
            tr = new T�redi (i, j);

            Console.WriteLine ("\nAraba'n�n motor nesnesi �yelerini (miraslamadan) tipleyerek kullanabilmesi:");
            Console.WriteLine ("Bir Araba nesnesi yarat�l�yor...");
            Araba arabam = new Araba();
            arabam.marka = "Toyoto";
            Console.WriteLine ("Araba nesnesi bir motor nesnesi yarat�yor...");
            arabam.motor = new Motor();
            arabam.motor.silindir = 4;
            arabam.motor.beygirg�c� = 180;
            Console.WriteLine ("arabam.marka = " + arabam.marka);
            Console.WriteLine ("arabam.motor.silindir = " + arabam.motor.silindir);
            Console.WriteLine ("arabam.motor.beygirg�c� = " + arabam.motor.beygirg�c�);
            arabam.�al��t�r();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}