// j2sc#0801.cs: Aritmetik (+, -, *, /, ++) ve mantýksal (&, |, &&, ||, true, false) iþlemci aþýrýyükleme örneði.

using System;
namespace Sýnýflar {
    struct KompleksSayý {
        float gerçel;
        float sanal;
        public KompleksSayý (float gerçel, float sanal) {this.gerçel = gerçel; this.sanal = sanal;} //Kurucu
        public float Gerçel {set {gerçel = value;} get {return(gerçel);}} //Özellik
        public float Sanal {set {sanal = value;} get {return(sanal);}}
        public override string ToString() {return (String.Format ("({0:0.00}, {1:0.00}i)", gerçel, sanal));}
        public static bool operator == (KompleksSayý k1, KompleksSayý k2) {if ((k1.gerçel == k2.gerçel) && (k1.sanal == k2.sanal)) return(true); else return(false);}
        public static bool operator != (KompleksSayý k1, KompleksSayý k2) {return(!(k1 == k2));}
        public override bool Equals (object nes) {KompleksSayý k2 = (KompleksSayý) nes; return(this == k2);}
        public override int GetHashCode() {return(gerçel.GetHashCode() ^ sanal.GetHashCode());} //^: XOR = Farklýysa true/1
        public static KompleksSayý operator + (KompleksSayý k1, KompleksSayý k2) {return(new KompleksSayý(k1.gerçel + k2.gerçel, k1.sanal + k2.sanal));}
        public static KompleksSayý operator - (KompleksSayý k1, KompleksSayý k2) {return(new KompleksSayý(k1.gerçel - k2.gerçel, k1.sanal - k2.sanal));}
        public static KompleksSayý operator * (KompleksSayý k1, KompleksSayý k2) {return(new KompleksSayý(k1.gerçel * k2.gerçel - k1.sanal * k2.sanal, k1.gerçel * k2.sanal + k2.gerçel * k1.sanal));}
        public static KompleksSayý operator / (KompleksSayý k1, KompleksSayý k2) {
            if ((k2.gerçel == 0.0f) && (k2.sanal == 0.0f)) throw new DivideByZeroException ("Sýfýr KompleksSayý'yla bölünemez");
            float yeniGerçel = (k1.gerçel * k2.gerçel + k1.sanal * k2.sanal) / (k2.gerçel * k2.gerçel + k2.sanal * k2.sanal);
            float yeniSanal = (k2.gerçel * k1.sanal - k1.gerçel * k2.sanal) / (k2.gerçel * k2.gerçel + k2.sanal * k2.sanal);
            return(new KompleksSayý (yeniGerçel, yeniSanal));
        }
    }
    struct Sayaç {
        int sayý;
        public Sayaç (int s) {sayý = s;} //Kurucu
        public override string ToString() {return(sayý.ToString());}
        public static Sayaç operator - (Sayaç syç) {return(new Sayaç (-syç.sayý));}
        public static Sayaç operator + (Sayaç syç1, Sayaç syç2) {return(new Sayaç (syç1.sayý + syç2.sayý));}
        public static Sayaç operator ++ (Sayaç syç) {return(new Sayaç (syç.sayý + 1));}
    }
    class ÝkiBoyut {
        int x, y;
        public ÝkiBoyut() {x = y = 0;} //Kurucu1
        public ÝkiBoyut (int i, int j) {x = i; y = j;} //Kurucu2
        public static ÝkiBoyut operator | (ÝkiBoyut iþl1, ÝkiBoyut iþl2) {//VEYA
            if (((iþl1.x != 0) || (iþl1.y != 0)) | ((iþl2.x != 0) || (iþl2.y != 0))) return new ÝkiBoyut (1, 1);
            else return new ÝkiBoyut (0, 0);
        }
        public static ÝkiBoyut operator & (ÝkiBoyut iþl1, ÝkiBoyut iþl2) {//VE
            if (((iþl1.x != 0) && (iþl1.y != 0)) & ((iþl2.x != 0) && (iþl2.y != 0))) return new ÝkiBoyut (1, 1);
            else return new ÝkiBoyut (0, 0);
        }   
        public static bool operator ! (ÝkiBoyut iþl) {//DEÐÝL
            if (iþl) return false;
            else return true;
        }
        public static bool operator true (ÝkiBoyut iþl) {//true
            if ((iþl.x != 0) || (iþl.y != 0)) return true; //Enaz bir kordinat sýfýr-deðil
            else return false;
        }
        public static bool operator false (ÝkiBoyut iþl) {//false
            if ((iþl.x == 0) && (iþl.y == 0)) return true; //Tüm kordinatlar sýfýr
            else return false;
        }
        public void göster() {Console.Write ("(x, y) = ({0}, {1})", x, y);}
    }
    class ÝþlemciAþýrýYüklenme {
        static void Main() {
            Console.Write ("Aþýrýyüklenebilen iþlemciler, 1) Tikel iþlemciler: +, -, !, ~, ++, --, true, false; 2) Ýkili iþlemciler: +, -, *, /, %, &, |, ^, <<, >>; 3) Kýyas iþlemcileri: ==, !=, <, >, <=, >=\nAþýrýyüklenemeyenler, 1) [] iþlemci, 2) () iþlemci, 3) Kýsakesek iþlemciler: +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=\n== iþlemcisi aþýrýyüklendiðinde Equals(nesne) ve GetHashCode() esgeçilmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kompleks sayýlarla ==, !=, +, -, * ve / aþýrýyüklü iþlemcileri:");
            var r=new Random(); int i, ts1, ts2; float fs1, fs2;
            KompleksSayý k1; KompleksSayý k2;
            for(i=0;i<5;i++) {
                fs1=r.Next(-100,100)+r.Next(10,100)/100F; fs2=r.Next(-100,100)+r.Next(10,100)/100F; k1= new KompleksSayý (fs1, fs2);
                fs1=r.Next(-100,100)+r.Next(10,100)/100F; fs2=r.Next(-100,100)+r.Next(10,100)/100F; k2= new KompleksSayý (fs1, fs2); if(i==4)k1=k2;
                Console.Write ("{0}) k1{1} == k2{2}: {3},\t", (i+1), k1, k2, k1 == k2);
                Console.Write ("k1 != k2: {0}", k1 != k2);
                Console.Write ("\n\tk1 + k2 = {0},\t", k1 + k2);
                Console.Write ("k1 - k2 = {0}", k1 - k2);
                Console.Write ("\n\tk1 * k2 = {0},\t", k1 * k2);
                Console.Write ("k1 / k2 = {0}\n", k1 / k2);
            }

            Console.WriteLine ("\nSayaç ilkdeðerleriyle +, -, ++ özelleþtirilen aþýrýyüklü iþlemciler:");
            Sayaç syç1; Sayaç syç2;
            for(i=0;i<5;i++) {
                ts1=r.Next(0,100); ts2=r.Next(100,1000);
                syç1=new Sayaç (ts1); syç2=new Sayaç (ts2);
                Console.Write ("{0}) syç1++, syç1++, syç1++: {1}, {2}, {3};\t", (i+1), syç1++, syç1++, syç1++);
                Console.Write("syç1 + syç2: {0},\t", syç1 + syç2);
                Console.Write("-syç2: {0}", -syç2);
                Console.Write ("\n\tsyç1++ + syç2++: {0},\t", syç1++ + syç2++);
                Console.Write ("++syç1 + ++syç2: {0}\n", ++syç1 + ++syç2);
            }

            Console.WriteLine ("\nÇiftboyutlu kordinat deðerleriyle true, false, &, |, &&, || iþlemciler:");
            ts1=r.Next(-100,100); ts2=r.Next(-100,100); ÝkiBoyut a = new ÝkiBoyut (ts1, ts2);
            ts1=r.Next(-100,100); ÝkiBoyut b = new ÝkiBoyut (ts1, ts1);
            ÝkiBoyut c = new ÝkiBoyut (0, 0);
            Console.Write ("a: "); a.göster();
            Console.Write (";\tb: "); b.göster();
            Console.Write (";\tc: "); c.göster();
            Console.WriteLine();
            if (a) {Console.Write ("a = true.");} else {Console.Write ("a = false.");}
            if (b) {Console.Write ("\tb = true.");} else {Console.Write ("\tb = false.");}
            if (c) {Console.Write ("\tc = true.");} else {Console.Write ("\tc = false.");}
            Console.WriteLine(); //&: VE ile |: VEYA
            if (a & b) Console.Write ("a & b = true."); else Console.Write ("a & b = false.");
            if (a & c) Console.Write ("\ta & c = true."); else Console.Write ("\ta & c = false.");
            if (b & c) Console.Write ("\tb & c = true."); else Console.Write ("\tb & c = false.");
            if (a | b) Console.Write ("\na | b = true."); else Console.Write ("\na | b = false.");
            if (a | c) Console.Write ("\ta | c = true."); else Console.Write ("\ta | c = false.");
            if (b | c) Console.Write ("\tb | c = true."); else Console.Write ("\tb | c = false.");
            Console.WriteLine(); //Kýsadevre &&: VE ile ||: VEYA
            if (a && b) Console.Write ("a && b = true."); else Console.Write ("a && b = false.");
            if (a && c) Console.Write ("\ta && c = true."); else Console.Write ("\ta && c = false.");
            if (b && c) Console.Write ("\tb && c = true."); else Console.Write ("\tb && c = false.");
            if (a || b) Console.Write ("\na || b = true."); else Console.Write ("\na || b = false.");
            if (a || c) Console.Write ("\ta || c = true."); else Console.Write ("\ta || c = false.");
            if (b || c) Console.Write ("\tb || c = true."); else Console.Write ("\tb || c = false.");

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}