// j2sc#0709.cs: �zyinelemeli ve taramal� metotlarla ayn� sonu�lar�n k�yas� �rne�i.

using System;
namespace S�n�flar {
    class Fakt�ryel {  
        public long fakt�Y (int n) {
            long sonu�;
            if (n==1) return 1;
            sonu� = fakt�Y (n-1) * n; //�zyinelemeli kendini-�a��rma
            return sonu�;
        }  
        public long faktTR (int n) {
            long sonu�=1;
            for (int i=2; i <= n; i++) sonu� *=i; //Taramal� ard���k �arpan d�ng�s�
            return sonu�;
        }
    }
    class TersDizge {
        public void terstenG�ster�Y (string dizge) {
            if (dizge.Length > 0) terstenG�ster�Y (dizge.Substring (1, dizge.Length-1)); //Her kerre uzunlu�u 1 k�salt, sondan tek krk al
            else return;
            Console.Write (dizge [0]);
        }
        public void terstenG�sterTR (string dizge) {
            string sonu�="";
            for (int i=dizge.Length-1; i >= 0; i--) sonu� +=dizge [i]; //Taramal� ard���k tersten ekleyen d�ng�
            Console.Write (sonu�);
        }
    }
    class Metot�zyineleme {
        static int Fibonaki (int x) {
            if (x <= 1) return 1;
            return Fibonaki (x - 1) + Fibonaki (x - 2);
        }
        public static void Saya� (int x) {
            if (x == 0) return; else Saya� (x - 1);
            Console.Write (x + " ");
        }
        static void Main() {
            Console.Write ("�zyineleme, nihai �art ger�ekle�inceye de�in kendini �a��ran metottur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�zyinelemeli ve tarama d�ng�l� rasgele 5'er fakt�ryel �arp�m:");
            Console.WriteLine ("\tlong.MaxValue = {0:#,#}", long.MaxValue);
            Fakt�ryel fakt = new Fakt�ryel();
            var r=new Random(); int i, ts1;
            for (i=0; i<5; i++) {ts1=r.Next (0, 21); Console.WriteLine ("�zyinelemeli {0}! = {1:#,###}", ts1, fakt.fakt�Y (ts1));}
            for (i=0; i<5; i++) {ts1=r.Next (0, 21); Console.WriteLine ("Taramal� {0}! = {1:#,#}", ts1, fakt.faktTR (ts1));}

            Console.WriteLine ("\nDizgeyi �zyinelemeli ve taramal� tersleyen metotlar:");
            string dizge1 = "Mahmut Nihat Yava�"; Console.WriteLine ("Orijinal dizge: [{0}]", dizge1);
            TersDizge td = new TersDizge(); Console.Write ("\tTers dizge �Y: ["); td.terstenG�ster�Y (dizge1); Console.Write ("]\n");
            Console.Write ("\tTers dizge TR: ["); td.terstenG�sterTR (dizge1); Console.Write ("]\n");
            dizge1 = "217.Cd, Toroslar - MERS�N"; Console.WriteLine ("Orijinal dizge: [{0}]", dizge1);
            td = new TersDizge(); Console.Write ("\tTers dizge �Y: ["); td.terstenG�ster�Y (dizge1); Console.Write ("]\n");
            Console.Write ("\tTers dizge TR: ["); td.terstenG�sterTR (dizge1); Console.Write ("]\n");

            Console.WriteLine ("\nRasgele 5 tamsay�n�n �zyinelemeli Fiboneki dizisinin sonu� de�eri:");
            for (i=0; i<5; i++) {ts1=r.Next (0, 30); Console.WriteLine ("Fibonaki ({0}): [{1}]", ts1, Fibonaki (ts1));}

            Console.WriteLine ("\nRasgele 5 tamsay�n�n �zyinelemeli artan sayac�:");
            for (i=0; i<5; i++) {ts1=r.Next (0, 100); Console.WriteLine ("Saya� ({0}): ", ts1); Saya� (ts1); Console.WriteLine();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}