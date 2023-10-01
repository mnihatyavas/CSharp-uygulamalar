// j2sc#0709.cs: Özyinelemeli ve taramalý metotlarla ayný sonuçlarýn kýyasý örneði.

using System;
namespace Sýnýflar {
    class Faktöryel {  
        public long faktÖY (int n) {
            long sonuç;
            if (n==1) return 1;
            sonuç = faktÖY (n-1) * n; //Özyinelemeli kendini-çaðýrma
            return sonuç;
        }  
        public long faktTR (int n) {
            long sonuç=1;
            for (int i=2; i <= n; i++) sonuç *=i; //Taramalý ardýþýk çarpan döngüsü
            return sonuç;
        }
    }
    class TersDizge {
        public void terstenGösterÖY (string dizge) {
            if (dizge.Length > 0) terstenGösterÖY (dizge.Substring (1, dizge.Length-1)); //Her kerre uzunluðu 1 kýsalt, sondan tek krk al
            else return;
            Console.Write (dizge [0]);
        }
        public void terstenGösterTR (string dizge) {
            string sonuç="";
            for (int i=dizge.Length-1; i >= 0; i--) sonuç +=dizge [i]; //Taramalý ardýþýk tersten ekleyen döngü
            Console.Write (sonuç);
        }
    }
    class MetotÖzyineleme {
        static int Fibonaki (int x) {
            if (x <= 1) return 1;
            return Fibonaki (x - 1) + Fibonaki (x - 2);
        }
        public static void Sayaç (int x) {
            if (x == 0) return; else Sayaç (x - 1);
            Console.Write (x + " ");
        }
        static void Main() {
            Console.Write ("Özyineleme, nihai þart gerçekleþinceye deðin kendini çaðýran metottur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Özyinelemeli ve tarama döngülü rasgele 5'er faktöryel çarpým:");
            Console.WriteLine ("\tlong.MaxValue = {0:#,#}", long.MaxValue);
            Faktöryel fakt = new Faktöryel();
            var r=new Random(); int i, ts1;
            for (i=0; i<5; i++) {ts1=r.Next (0, 21); Console.WriteLine ("Özyinelemeli {0}! = {1:#,###}", ts1, fakt.faktÖY (ts1));}
            for (i=0; i<5; i++) {ts1=r.Next (0, 21); Console.WriteLine ("Taramalý {0}! = {1:#,#}", ts1, fakt.faktTR (ts1));}

            Console.WriteLine ("\nDizgeyi özyinelemeli ve taramalý tersleyen metotlar:");
            string dizge1 = "Mahmut Nihat Yavaþ"; Console.WriteLine ("Orijinal dizge: [{0}]", dizge1);
            TersDizge td = new TersDizge(); Console.Write ("\tTers dizge ÖY: ["); td.terstenGösterÖY (dizge1); Console.Write ("]\n");
            Console.Write ("\tTers dizge TR: ["); td.terstenGösterTR (dizge1); Console.Write ("]\n");
            dizge1 = "217.Cd, Toroslar - MERSÝN"; Console.WriteLine ("Orijinal dizge: [{0}]", dizge1);
            td = new TersDizge(); Console.Write ("\tTers dizge ÖY: ["); td.terstenGösterÖY (dizge1); Console.Write ("]\n");
            Console.Write ("\tTers dizge TR: ["); td.terstenGösterTR (dizge1); Console.Write ("]\n");

            Console.WriteLine ("\nRasgele 5 tamsayýnýn özyinelemeli Fiboneki dizisinin sonuç deðeri:");
            for (i=0; i<5; i++) {ts1=r.Next (0, 30); Console.WriteLine ("Fibonaki ({0}): [{1}]", ts1, Fibonaki (ts1));}

            Console.WriteLine ("\nRasgele 5 tamsayýnýn özyinelemeli artan sayacý:");
            for (i=0; i<5; i++) {ts1=r.Next (0, 100); Console.WriteLine ("Sayaç ({0}): ", ts1); Sayaç (ts1); Console.WriteLine();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}