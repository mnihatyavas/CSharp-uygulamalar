// j2sc#0719b.cs: Esge�meyle ayn� s�n�f�n farkl� tipli endeksleyicileri �rne�i.

using System;
using System.Collections;
namespace S�n�flar {
    class Dizi {
        int[] a;
        public int uzun;
        public bool hataM�;
        public Dizi (int ebat) {a = new int [ebat]; uzun = ebat;} //Kurucu
        public int this [int endeks] {//Endeksleyici
            set {if (endeksKontrol (endeks)) {a [endeks] = value; hataM� = false;
                }else hataM� = true;
            }
            get {if (endeksKontrol (endeks)) {hataM� = false; return a [endeks];
                }else {hataM� = true; return 0;}
            }
        }
        private bool endeksKontrol (int endeks) {
            if (endeks >= 0 & endeks < uzun) return true;
            return false;
        }
    }
    class Dizi2 {
        int[] a;
        public Dizi2 (int ebat) {a = new int [ebat];} //Kurucu
        public int this [int endeks] {set {a [endeks] = value;} get {return a [endeks];}} //Tamsay� Endeksleyici
        public int this [double endeks] {set {a [(int)endeks] = value;} get {return a [(int)endeks];}}//Dublesay� Endeksleyici
        public int this [string e] {set {a [(int)(e.ToUpper())[0] -'A'] = value;} get {return a [(int)(e.ToUpper())[0] -'A'];}}//Dizge Endeksleyici
    }
    class S�ralay�c� {public long this [int endeks] {get {return  (long)Math.Pow (2023, endeks);}}}
    class Tek�ift {
        int tek;
        int �ift;
        public int this [int i] {
            set {if (i%2==0) �ift=value; else tek=value;}
            get {return (i%2==0) ? �ift : tek;}
        }
    }
    public abstract class �ekil {public abstract void �iz();}
    public class Dikd�rtgen : �ekil {public override void �iz() {Console.WriteLine ("Dikd�rtgen.�iz() y�r�t�l�yor");}}
    public class Daire : �ekil {public override void �iz() {Console.WriteLine ("Daire.�iz() y�r�t�l�yor");}}
    public class ��gen : �ekil {public override void �iz() {Console.WriteLine ("��gen.�iz() y�r�t�l�yor");}}
    public class Kare : �ekil {public override void �iz() {Console.WriteLine ("Kare.�iz() y�r�t�l�yor");}}
    public class Yamuk : �ekil {public override void �iz() {Console.WriteLine ("Yamuk.�iz() y�r�t�l�yor");}}
    public class �ekilListesi {
        private ArrayList �ekiller;
        public �ekilListesi() {�ekiller = new ArrayList();} //Kurucu
        public int Ebat {get {return �ekiller.Count;}}
        public �ekil this [int endeks] {get {return (�ekil)�ekiller [endeks];}}
        public void Ekle (�ekil �ekil) {�ekiller.Add (�ekil);}
    }
    class G�nler {
        string[] g�nler = {"Pazartesi", "Sal�", "�ar�amba", "Per�embe", "Cuma", "Cumartesi", "Pazar"};
        private int G�nAl (string g�n) {
            for(int i = 0; i < g�nler.Length; i++) {if (g�nler[i].ToLower() == g�n.ToLower()) {return i;}}
            throw new System.ArgumentOutOfRangeException (g�n, "G�n ad�n� yanl�� girdiniz!");
        }
        public int this [string g�n] {get {return (G�nAl (g�n));}}
        public string this [int g�n] {get {if(g�n>=0 & g�n<=6) return (g�nler [g�n]); else throw new System.ArgumentOutOfRangeException (g�n.ToString(), "G�n say�s�n� [0, 6] yanl�� girdiniz!");}}
    }
    class Dizi3B {
        public Dizi3B (int x, int y, int z){} 
        public int this [int end1, int end2, int end3] {get {return (int)Math.Pow (end1, end2) * end3;}}
    }
    class Endeksleyici2 {
        static void Main() {
            Console.Write ("Sabit ebatl� endeksleyici -+ta�ma hatalar� kodlamayla kontrol edilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Saptanan ebat� ta�an hatal� endekslerin tespiti:");
            var r=new Random(); int x, ts1, ts2, i;
            ts2=10;
            Dizi dizi = new Dizi (ts2);
            Console.WriteLine ("\tSessiz endeks hatas� ay�klay�c�:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; if (x != 0) Console.Write ("dizi[{0}]={1} ", i, x);} Console.WriteLine();
            Console.WriteLine ("\t0 gerid�n��l� hatal� endeks beyanc�s�:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; Console.Write ("dizi[{0}]={1} ", i, x);} Console.WriteLine();
            Console.WriteLine ("\tEndeks hatas�n�n aleni beyan�:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; if (!dizi.hataM�) Console.Write ("dizi[{0}]={1} ", i, x); else Console.Write ("dizi[{0}]={1} ", i, "HATA");} Console.WriteLine();

            Console.WriteLine ("\nAyn� endeksleyicinin int-double-string endeksle kullan�m�:");
            ts2=5;
            Dizi2 dizi2 = new Dizi2 (ts2);
            Console.WriteLine ("\tTam-say�sal endeksleyici:");
            for (i=0; i < 5; i++) {ts1=r.Next(100,1000); dizi2 [i] = ts1;}
            for (i=0; i < 5; i++) {Console.Write ("dizi[{0}]={1} ", i, dizi2 [i]);} Console.WriteLine();
            Console.WriteLine ("\tDuble-say�sal endeksleyici:");
            for (double j=0.37; j < 5.37; j++) {ts1=r.Next(100,1000); dizi2 [j] = ts1;}
            for (double j=0.75; j < 5.75; j++) {Console.Write ("dizi[{0}]={1} ", j, dizi2 [j]);} Console.WriteLine();
            Console.WriteLine ("\tDizgesel endeksleyici:");
            for (i=0; i < 5; i++) {ts1=r.Next(100,1000); dizi2 [((char)(i+65)).ToString()] = ts1;}
            for (i=0; i < 5; i++) {Console.Write ("dizi[{0}]={1} ", ((char)(i+65)).ToString(), dizi2 [((char)(i+65)).ToString()]);} Console.WriteLine();

            Console.WriteLine ("\nMath.Pow() ile artan endeksleyici gerid�n��leri:");
            S�ralay�c� s�rala = new S�ralay�c�();
            for(i=0; i <=5; i++) Console.Write ("s�rala[{0}]={1} ", i, s�rala [i]); Console.WriteLine();

            Console.WriteLine ("\nEndeksleyici set-get'in rasgele tek-�ift say�lar� kontrollu ayr��t�rmas�:");
            Tek�ift t�=new Tek�ift();
            for (i=0; i < 10; i++) {ts1=r.Next(-1000,1000); t� [i] = ts1; if (ts1%2==0) Console.WriteLine ("\t�ift [{0}] = {1}", i, t� [i]); else Console.WriteLine ("Tek [{0}] = {1}", i, t� [i]);}

            Console.WriteLine ("\nArrayList endeksleyiciye Add'le eklenen �ekil �izimleri listesi:");
            �ekilListesi �l = new �ekilListesi();
            �l.Ekle (new Dikd�rtgen()); �l.Ekle (new Daire()); �l.Ekle (new Yamuk()); �l.Ekle (new ��gen()); �l.Ekle (new Kare());
            for(i = 0; i < �l.Ebat; ++i) {((�ekil)�l [i]).�iz();}

            Console.WriteLine ("\n'int this [string g�n]' ve 'string this [int g�n]' endeksleyiciler:");
            G�nler g�n = new G�nler();
            Console.WriteLine ("\tHaftan�n g�n adlar�:");
            for(i=0;i<7;i++) Console.Write (g�n [i] + ", ");
            Console.WriteLine ("\n\tG�nad� giri�i:");
            Console.WriteLine ("�ar�amba, haftan�n {0}.inci g�n�d�r.", g�n ["�ar�amba"]+1);
            Console.WriteLine ("Pazartesi, haftan�n {0}.inci g�n�d�r.", g�n ["PAZARTES�"]+1);
            Console.WriteLine ("Pazar, haftan�n {0}.inci g�n�d�r.", g�n ["paZAr"]+1);
            try {Console.WriteLine ("Cuma, haftan�n {0}.inci g�n�d�r.", g�n ["Cumali"]+1);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            Console.WriteLine ("\tHaftan�n g�n say�s� giri�i:");
            Console.WriteLine ("Haftan�n 4.�nc� g�n�: {0}'dir.", g�n [4-1]);
            Console.WriteLine ("Haftan�n 6.�nc� g�n�: {0}'dir.", g�n [6-1]);
            try {Console.WriteLine ("Haftan�n 7.inci g�n�: {0}'dir.", g�n [7]);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            Console.WriteLine ("Haftan�n 7.inci g�n�: {0}'d�r.", g�n [7-1]);

            Console.WriteLine ("\n3 boyutlu endeksleyicinin endekslerle hesap (e1^e2*e3) gerid�n��leri:");
            Dizi3B d3b = new Dizi3B (3, 5, 4);
            for(i=0;i<3;i++) for(int j=0;j<5;j++) for(int k=0;k<4;k++) Console.Write ("d3b({0},{1},{2})={3} ", i, j, k, d3b [i,j,k]); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}