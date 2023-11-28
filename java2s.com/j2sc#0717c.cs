// j2sc#0717c.cs: Aray�z metotlar�n�n do�rudan ve referansl� �a�r�lmas� �rne�i.

using System;
namespace S�n�flar {
    public interface Aray�zA {void MetotA();}
    public interface Aray�zB : Aray�zA {new void MetotA();}//Aray�zA'n�n MetotA()'n�n� gizler
    public class S�n�f : Aray�zB {
        void Aray�zB.MetotA() {Console.WriteLine ("Aray�zB.(new)MetotA() y�r�t�l�yor...");}
        public void MetotA() {Console.WriteLine ("Aray�zA.MetotA() y�r�t�l�yor...");}
    }
    interface Aray�zBir {void Ko�tur();}
    interface Aray�z�ki {void Ko�tur();}
    interface Aray�z�� {void Ko�tur();}
    interface Aray�zD�rt {void Ko�tur();}
    class S�n�f1: Aray�zBir, Aray�z�ki, Aray�z��, Aray�zD�rt {
        void Aray�zBir.Ko�tur() {Console.WriteLine ("Aray�zBir.Ko�tur y�r�t���yor.");}
        void Aray�z�ki.Ko�tur() {Console.WriteLine ("Aray�z�ki.Ko�tur y�r�t���yor.");}
        void Aray�z��.Ko�tur() {Console.WriteLine ("Aray�z��.Ko�tur y�r�t���yor.");}
        void Aray�zD�rt.Ko�tur() {Console.WriteLine ("Aray�zD�rt.Ko�tur y�r�t���yor.");}
        public void Ko�tur() {((Aray�zD�rt)this).Ko�tur();}
    }
    interface IAray�z {
        bool MetotA (int x);
        bool MetotB (int x);
    }
    class Tekmi�iftmi : IAray�z {//Do�rudan tek/�ift kontrolu
        bool IAray�z.MetotA (int x) { 
            if((x%2) != 0) return true;
            else return false;
        }
        public bool MetotB (int x) {//Dolayl� MetotA'yla tek/�ift kontrolu
            IAray�z nes = this;
            return !nes.MetotA (x);
        }
    }
    interface IAray�zA {int Metot (int x);}
    interface IAray�zB {double Metot (double x);}
    class K�kKare : IAray�zA, IAray�zB {
        int IAray�zA.Metot (int x) {return x * x;} //Do�rudan �a��rmal�
        double IAray�zB.Metot (double x) {return Math.Sqrt (x);}
        public int MetotA (int x) {return ((IAray�zA)this).Metot (x);} //Referansl� �a��rmal�
        public double MetotB (double x) {return ((IAray�zB)this).Metot (x);}
    }
    class Aray�z3 {
        static void Main() {
            Console.Write ("Ayn� adl� 'new' belirte�li metot miraslanan� egale eder. �oklu aray�z miraslayan t�redi tiplemesinin herbir aray�z metotlar� '((IAray�z1(t�rediTipleme).Metot()' y�ntemiyle ko�turulabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Miraslanan metotun 'new'le ge�ersizlenmesi:");
            S�n�f snf = new S�n�f();
            Console.WriteLine ("\tsnf.MetotA() �a�r�l�yor:");
            snf.MetotA();
            Aray�zB ay�zB = snf as Aray�zB;
            Console.WriteLine ("\tay�zB.MetotA() �a�r�l�yor:");
            ay�zB.MetotA();
            Aray�zA ay�zA = snf as Aray�zA;
            Console.WriteLine ("\tay�zA.MetotA() �a�r�l�yor:");
            ay�zA.MetotA();

            Console.WriteLine ("\nMiraslanan ayn�-adl� t�m aray�z metotlar�n�n �a�r�lmas�:");
            S�n�f1 s1 = new S�n�f1();
            s1.Ko�tur(); //((Aray�zD�rt)s1).Ko�tur();
            ((Aray�zBir)s1).Ko�tur(); ((Aray�z�ki)s1).Ko�tur(); ((Aray�z��)s1).Ko�tur();

            Console.WriteLine ("\nBirdi�erini y�r�ten �ift aray�z metotlar�n�n do�rudan ve dolayl� �a�r�lmas�:");
            var r=new Random(); int ts1, ts2, i;
            Tekmi�iftmi t�;
            for(i=0;i<5;i++) {
                ts1=r.Next(1000, 10000); ts2=r.Next(1000, 10000);
                t� = new Tekmi�iftmi();
                if (t�.MetotB (ts1)) Console.WriteLine ("\t{0} bir ��FT say�d�r.", ts1);
                else Console.WriteLine ("\t{0} bir TEK say�d�r.", ts1);
                if (!((IAray�z)t�).MetotA (ts2)) Console.WriteLine ("{0} bir ��FT say�d�r.", ts2);
                else Console.WriteLine ("{0} bir TEK say�d�r.", ts2);
            }

            Console.WriteLine ("\nDo�rudan ve referansl� aray�z metot �a��rmal� kare ve karek�k:");
            K�kKare kk;
            for(i=0;i<5;i++) {
                ts1=r.Next(1000, 10000); ts2=r.Next(1000, 10000);
                kk = new K�kKare();
                Console.WriteLine ("\t{0} say�s�n�n karesi = {1:#,0}", ts1, kk.MetotA (ts1));
                Console.WriteLine ("{0} say�s�n�n karek�k� = {1:0.0000}", ts2, kk.MetotB (ts2));
            }
 
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}