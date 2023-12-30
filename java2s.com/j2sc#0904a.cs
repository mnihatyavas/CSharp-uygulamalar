// j2sc#0904a.cs: Delegeli olay y�netimleri eklemeli s�n�f tiplemeleri �rne�i.

using System;
namespace YetkiAktarma {
    public delegate void OlayY�netimi2 (int i);
    public delegate void OlayY�netimi3();
    delegate void OlayY�netimi4();
    delegate void OlayY�netimi5();
    public delegate void OlayY�netimi6 (int ya�, object nesne, ref bool de�i�tirme);
    public class Olay1 {
        private int n;
        public Olay1 (int i) {De�erKoy (i);} //Kurucu
        public delegate void OlayY�netimi1();
        public event OlayY�netimi1 De�i�ti;
        public void De�i�tiyse() {
            if (De�i�ti != null) {Console.WriteLine ("De�er de�i�ti: "+n);}
            else Console.WriteLine ("Y�netilmeyen olay f�rlat�ld�!");
        }
        public void De�erKoy (int m) {if (n != m) {n = m; De�i�tiyse();} else Console.WriteLine ("De�er de�i�medi...");}
    }
    public class Olay2 {
        public event OlayY�netimi2 Olay�m2;
        public double Metot2 (int i) {Olay�m2 (i); return(i >= 0? Math.Sqrt (i): -1);}
    }
    class Olay3a {
        public event OlayY�netimi3 Olay�m3;
        public void Olay�m3se() {if (Olay�m3 != null) Olay�m3();}
    }
    class Olay3b {
        public void Olay3bY�netimi() {Console.WriteLine ("Olay3bY�netimi fare olay� alg�lad�");}
    }
    class Olay3c {
        public void Olay3cY�netimi() {Console.WriteLine ("Olay3cY�netimi klavye olay� alg�lad�");}
    }
    class Olay4a {
        public event OlayY�netimi4 Olay�m4;
        public void Olay�m4se() {if (Olay�m4 != null) Olay�m4();}
    }
    class Olay4b {
        int no;
        public Olay4b (int x) {no = x;} //Kurucu
        public void Olay4bY�netimi() {Console.WriteLine ("Olay no: " + no);}
    }
    class Olay5a {
        public event OlayY�netimi5 Olay�m5;
        public void Olay�m5se() {if (Olay�m5 != null) Olay�m5();}
    }
    class Olay5b {
        public static void Olay5bY�netimi() {Console.WriteLine ("Olay5b s�n�f�nca alg�lanan olay...");}
    }
    class Olay6 {
        public event OlayY�netimi6 Ya��De�i�tir;
        int ya�;
        public Olay6() {ya� = 0;} //Kurucu
        public int Ya� {
            set {Boolean de�i�tirme = false;
                Ya��De�i�tir (value, this, ref de�i�tirme);
                if (!de�i�tirme) ya� = value;
            }
            get {return ya�;}
        }
    }
    class Delege4a {
        static void Olay3aY�netimi() {Console.WriteLine ("\tnull olmayan Olay�m3() ekran olay� alg�lad�");}
        private static void Olay6Y�netimi (int y, object n, ref bool d) {
            Console.WriteLine ("Olay6Y�netimi [Yeni ya�: {0} ve Eski ya� = {1}] i�in �a�r�ld�.", y, ((Olay6)n).Ya�);
            if (y < 18 || y > 65) d = true;
        }
        static void Main() {
            Console.Write ("Delege olayla adland�r�l�p s�n�f tiplemeli olay y�neten metota ba�lanarak eklenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("OlayY�netimi1 delegeli 'event De�i�ti' De�i�tiyse() metodunu �a��r�r:");
            var r=new Random(); int i, ts1;
            Olay1 oy1 = new Olay1 (3); oy1 = new Olay1 (3); oy1 = new Olay1 (5);
            oy1.De�i�ti += new Olay1.OlayY�netimi1 (oy1.De�i�tiyse);
            for(i=0;i<10;i++) {ts1=r.Next(0,5); oy1.De�erKoy (ts1);}

            Console.WriteLine ("\nKarek�k i�in -say�y� yakalayan anonim delegeli olay:");
            Olay2 o2 = new Olay2();
            OlayY�netimi2 oy2 = delegate (int x) {if (x<0) Console.Write ("Negatif say�n�n karek�k� olmaz!\t");};
            o2.Olay�m2 += oy2;
            double ds1;
            for(i=0;i<10;i++) {ts1=r.Next(-1000,1000); ds1=o2.Metot2 (ts1); Console.WriteLine ("{0}) Say�={1}, Karek�k�=[{2}]", i+1, ts1, ds1);}

            Console.WriteLine ("\nOlay y�netimine ba�lanan 3 olay, sonra 2'ye ve 1'e d���r�l�r:");
            Olay3a o3a = new Olay3a(); Olay3b o3b = new Olay3b(); Olay3c o3c = new Olay3c();
            o3a.Olay�m3 += Olay3aY�netimi; o3a.Olay�m3 += o3b.Olay3bY�netimi; o3a.Olay�m3 += o3c.Olay3cY�netimi;
            o3a.Olay�m3se(); //Her 3 y�netimi de y�r�t�r
            o3a.Olay�m3 -= o3c.Olay3cY�netimi;
            o3a.Olay�m3se(); //�lk 2 y�netim y�r�t�l�r
            o3a.Olay�m3 -= o3b.Olay3bY�netimi;
            o3a.Olay�m3se(); //�lk y�netim y�r�t�l�r

            Console.WriteLine ("\nOlay4a'ya eklenen Olay4b'nin 3 y�netimi:");
            Olay4a o4a = new Olay4a();
            Olay4b o4b1 = new Olay4b (1); Olay4b o4b2 = new Olay4b (2); Olay4b o4b3 = new Olay4b (3);
            o4a.Olay�m4 += o4b1.Olay4bY�netimi; o4a.Olay�m4 += o4b2.Olay4bY�netimi; o4a.Olay�m4 += o4b3.Olay4bY�netimi;
            o4a.Olay�m4se(); //�lk o4a y�netimi eklenmedi�inden, ekli 3 adet o4b y�netimleri y�r�t�l�r

            Console.WriteLine ("\nDelegeli Oly5a'ya ba�l� 5 adet Olay5b alg�s�:");
            Olay5a o5a = new Olay5a();
            o5a.Olay�m5+=Olay5b.Olay5bY�netimi; o5a.Olay�m5+=Olay5b.Olay5bY�netimi; o5a.Olay�m5+=Olay5b.Olay5bY�netimi; o5a.Olay�m5+=Olay5b.Olay5bY�netimi; o5a.Olay�m5+=Olay5b.Olay5bY�netimi;
            o5a.Olay�m5se();

            Console.WriteLine ("\n[18,65] aras� de�i�en yeni ya�lar� g�ncelleyen delegeli olay y�netimi:");
            Olay6 o6 = new Olay6();
            o6.Ya��De�i�tir += new OlayY�netimi6 (Olay6Y�netimi);
            for(i=0;i<10;i++) {
                ts1=r.Next(0,120);
                o6.Ya� = ts1;
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}