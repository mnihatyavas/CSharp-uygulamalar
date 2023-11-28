// j2sc#0717c.cs: Arayüz metotlarýnýn doðrudan ve referanslý çaðrýlmasý örneði.

using System;
namespace Sýnýflar {
    public interface ArayüzA {void MetotA();}
    public interface ArayüzB : ArayüzA {new void MetotA();}//ArayüzA'nýn MetotA()'nýný gizler
    public class Sýnýf : ArayüzB {
        void ArayüzB.MetotA() {Console.WriteLine ("ArayüzB.(new)MetotA() yürütülüyor...");}
        public void MetotA() {Console.WriteLine ("ArayüzA.MetotA() yürütülüyor...");}
    }
    interface ArayüzBir {void Koþtur();}
    interface ArayüzÝki {void Koþtur();}
    interface ArayüzÜç {void Koþtur();}
    interface ArayüzDört {void Koþtur();}
    class Sýnýf1: ArayüzBir, ArayüzÝki, ArayüzÜç, ArayüzDört {
        void ArayüzBir.Koþtur() {Console.WriteLine ("ArayüzBir.Koþtur yürütüýüyor.");}
        void ArayüzÝki.Koþtur() {Console.WriteLine ("ArayüzÝki.Koþtur yürütüýüyor.");}
        void ArayüzÜç.Koþtur() {Console.WriteLine ("ArayüzÜç.Koþtur yürütüýüyor.");}
        void ArayüzDört.Koþtur() {Console.WriteLine ("ArayüzDört.Koþtur yürütüýüyor.");}
        public void Koþtur() {((ArayüzDört)this).Koþtur();}
    }
    interface IArayüz {
        bool MetotA (int x);
        bool MetotB (int x);
    }
    class TekmiÇiftmi : IArayüz {//Doðrudan tek/çift kontrolu
        bool IArayüz.MetotA (int x) { 
            if((x%2) != 0) return true;
            else return false;
        }
        public bool MetotB (int x) {//Dolaylý MetotA'yla tek/çift kontrolu
            IArayüz nes = this;
            return !nes.MetotA (x);
        }
    }
    interface IArayüzA {int Metot (int x);}
    interface IArayüzB {double Metot (double x);}
    class KökKare : IArayüzA, IArayüzB {
        int IArayüzA.Metot (int x) {return x * x;} //Doðrudan çaðýrmalý
        double IArayüzB.Metot (double x) {return Math.Sqrt (x);}
        public int MetotA (int x) {return ((IArayüzA)this).Metot (x);} //Referanslý çaðýrmalý
        public double MetotB (double x) {return ((IArayüzB)this).Metot (x);}
    }
    class Arayüz3 {
        static void Main() {
            Console.Write ("Ayný adlý 'new' belirteçli metot miraslananý egale eder. Çoklu arayüz miraslayan türedi tiplemesinin herbir arayüz metotlarý '((IArayüz1(türediTipleme).Metot()' yöntemiyle koþturulabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Miraslanan metotun 'new'le geçersizlenmesi:");
            Sýnýf snf = new Sýnýf();
            Console.WriteLine ("\tsnf.MetotA() çaðrýlýyor:");
            snf.MetotA();
            ArayüzB ayüzB = snf as ArayüzB;
            Console.WriteLine ("\tayüzB.MetotA() çaðrýlýyor:");
            ayüzB.MetotA();
            ArayüzA ayüzA = snf as ArayüzA;
            Console.WriteLine ("\tayüzA.MetotA() çaðrýlýyor:");
            ayüzA.MetotA();

            Console.WriteLine ("\nMiraslanan ayný-adlý tüm arayüz metotlarýnýn çaðrýlmasý:");
            Sýnýf1 s1 = new Sýnýf1();
            s1.Koþtur(); //((ArayüzDört)s1).Koþtur();
            ((ArayüzBir)s1).Koþtur(); ((ArayüzÝki)s1).Koþtur(); ((ArayüzÜç)s1).Koþtur();

            Console.WriteLine ("\nBirdiðerini yürüten çift arayüz metotlarýnýn doðrudan ve dolaylý çaðrýlmasý:");
            var r=new Random(); int ts1, ts2, i;
            TekmiÇiftmi tç;
            for(i=0;i<5;i++) {
                ts1=r.Next(1000, 10000); ts2=r.Next(1000, 10000);
                tç = new TekmiÇiftmi();
                if (tç.MetotB (ts1)) Console.WriteLine ("\t{0} bir ÇÝFT sayýdýr.", ts1);
                else Console.WriteLine ("\t{0} bir TEK sayýdýr.", ts1);
                if (!((IArayüz)tç).MetotA (ts2)) Console.WriteLine ("{0} bir ÇÝFT sayýdýr.", ts2);
                else Console.WriteLine ("{0} bir TEK sayýdýr.", ts2);
            }

            Console.WriteLine ("\nDoðrudan ve referanslý arayüz metot çaðýrmalý kare ve karekök:");
            KökKare kk;
            for(i=0;i<5;i++) {
                ts1=r.Next(1000, 10000); ts2=r.Next(1000, 10000);
                kk = new KökKare();
                Console.WriteLine ("\t{0} sayýsýnýn karesi = {1:#,0}", ts1, kk.MetotA (ts1));
                Console.WriteLine ("{0} sayýsýnýn karekökü = {1:0.0000}", ts2, kk.MetotB (ts2));
            }
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}