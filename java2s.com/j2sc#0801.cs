// j2sc#0801.cs: Aritmetik (+, -, *, /, ++) ve mant�ksal (&, |, &&, ||, true, false) i�lemci a��r�y�kleme �rne�i.

using System;
namespace S�n�flar {
    struct KompleksSay� {
        float ger�el;
        float sanal;
        public KompleksSay� (float ger�el, float sanal) {this.ger�el = ger�el; this.sanal = sanal;} //Kurucu
        public float Ger�el {set {ger�el = value;} get {return(ger�el);}} //�zellik
        public float Sanal {set {sanal = value;} get {return(sanal);}}
        public override string ToString() {return (String.Format ("({0:0.00}, {1:0.00}i)", ger�el, sanal));}
        public static bool operator == (KompleksSay� k1, KompleksSay� k2) {if ((k1.ger�el == k2.ger�el) && (k1.sanal == k2.sanal)) return(true); else return(false);}
        public static bool operator != (KompleksSay� k1, KompleksSay� k2) {return(!(k1 == k2));}
        public override bool Equals (object nes) {KompleksSay� k2 = (KompleksSay�) nes; return(this == k2);}
        public override int GetHashCode() {return(ger�el.GetHashCode() ^ sanal.GetHashCode());} //^: XOR = Farkl�ysa true/1
        public static KompleksSay� operator + (KompleksSay� k1, KompleksSay� k2) {return(new KompleksSay�(k1.ger�el + k2.ger�el, k1.sanal + k2.sanal));}
        public static KompleksSay� operator - (KompleksSay� k1, KompleksSay� k2) {return(new KompleksSay�(k1.ger�el - k2.ger�el, k1.sanal - k2.sanal));}
        public static KompleksSay� operator * (KompleksSay� k1, KompleksSay� k2) {return(new KompleksSay�(k1.ger�el * k2.ger�el - k1.sanal * k2.sanal, k1.ger�el * k2.sanal + k2.ger�el * k1.sanal));}
        public static KompleksSay� operator / (KompleksSay� k1, KompleksSay� k2) {
            if ((k2.ger�el == 0.0f) && (k2.sanal == 0.0f)) throw new DivideByZeroException ("S�f�r KompleksSay�'yla b�l�nemez");
            float yeniGer�el = (k1.ger�el * k2.ger�el + k1.sanal * k2.sanal) / (k2.ger�el * k2.ger�el + k2.sanal * k2.sanal);
            float yeniSanal = (k2.ger�el * k1.sanal - k1.ger�el * k2.sanal) / (k2.ger�el * k2.ger�el + k2.sanal * k2.sanal);
            return(new KompleksSay� (yeniGer�el, yeniSanal));
        }
    }
    struct Saya� {
        int say�;
        public Saya� (int s) {say� = s;} //Kurucu
        public override string ToString() {return(say�.ToString());}
        public static Saya� operator - (Saya� sy�) {return(new Saya� (-sy�.say�));}
        public static Saya� operator + (Saya� sy�1, Saya� sy�2) {return(new Saya� (sy�1.say� + sy�2.say�));}
        public static Saya� operator ++ (Saya� sy�) {return(new Saya� (sy�.say� + 1));}
    }
    class �kiBoyut {
        int x, y;
        public �kiBoyut() {x = y = 0;} //Kurucu1
        public �kiBoyut (int i, int j) {x = i; y = j;} //Kurucu2
        public static �kiBoyut operator | (�kiBoyut i�l1, �kiBoyut i�l2) {//VEYA
            if (((i�l1.x != 0) || (i�l1.y != 0)) | ((i�l2.x != 0) || (i�l2.y != 0))) return new �kiBoyut (1, 1);
            else return new �kiBoyut (0, 0);
        }
        public static �kiBoyut operator & (�kiBoyut i�l1, �kiBoyut i�l2) {//VE
            if (((i�l1.x != 0) && (i�l1.y != 0)) & ((i�l2.x != 0) && (i�l2.y != 0))) return new �kiBoyut (1, 1);
            else return new �kiBoyut (0, 0);
        }   
        public static bool operator ! (�kiBoyut i�l) {//DE��L
            if (i�l) return false;
            else return true;
        }
        public static bool operator true (�kiBoyut i�l) {//true
            if ((i�l.x != 0) || (i�l.y != 0)) return true; //Enaz bir kordinat s�f�r-de�il
            else return false;
        }
        public static bool operator false (�kiBoyut i�l) {//false
            if ((i�l.x == 0) && (i�l.y == 0)) return true; //T�m kordinatlar s�f�r
            else return false;
        }
        public void g�ster() {Console.Write ("(x, y) = ({0}, {1})", x, y);}
    }
    class ��lemciA��r�Y�klenme {
        static void Main() {
            Console.Write ("A��r�y�klenebilen i�lemciler, 1) Tikel i�lemciler: +, -, !, ~, ++, --, true, false; 2) �kili i�lemciler: +, -, *, /, %, &, |, ^, <<, >>; 3) K�yas i�lemcileri: ==, !=, <, >, <=, >=\nA��r�y�klenemeyenler, 1) [] i�lemci, 2) () i�lemci, 3) K�sakesek i�lemciler: +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=\n== i�lemcisi a��r�y�klendi�inde Equals(nesne) ve GetHashCode() esge�ilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kompleks say�larla ==, !=, +, -, * ve / a��r�y�kl� i�lemcileri:");
            var r=new Random(); int i, ts1, ts2; float fs1, fs2;
            KompleksSay� k1; KompleksSay� k2;
            for(i=0;i<5;i++) {
                fs1=r.Next(-100,100)+r.Next(10,100)/100F; fs2=r.Next(-100,100)+r.Next(10,100)/100F; k1= new KompleksSay� (fs1, fs2);
                fs1=r.Next(-100,100)+r.Next(10,100)/100F; fs2=r.Next(-100,100)+r.Next(10,100)/100F; k2= new KompleksSay� (fs1, fs2); if(i==4)k1=k2;
                Console.Write ("{0}) k1{1} == k2{2}: {3},\t", (i+1), k1, k2, k1 == k2);
                Console.Write ("k1 != k2: {0}", k1 != k2);
                Console.Write ("\n\tk1 + k2 = {0},\t", k1 + k2);
                Console.Write ("k1 - k2 = {0}", k1 - k2);
                Console.Write ("\n\tk1 * k2 = {0},\t", k1 * k2);
                Console.Write ("k1 / k2 = {0}\n", k1 / k2);
            }

            Console.WriteLine ("\nSaya� ilkde�erleriyle +, -, ++ �zelle�tirilen a��r�y�kl� i�lemciler:");
            Saya� sy�1; Saya� sy�2;
            for(i=0;i<5;i++) {
                ts1=r.Next(0,100); ts2=r.Next(100,1000);
                sy�1=new Saya� (ts1); sy�2=new Saya� (ts2);
                Console.Write ("{0}) sy�1++, sy�1++, sy�1++: {1}, {2}, {3};\t", (i+1), sy�1++, sy�1++, sy�1++);
                Console.Write("sy�1 + sy�2: {0},\t", sy�1 + sy�2);
                Console.Write("-sy�2: {0}", -sy�2);
                Console.Write ("\n\tsy�1++ + sy�2++: {0},\t", sy�1++ + sy�2++);
                Console.Write ("++sy�1 + ++sy�2: {0}\n", ++sy�1 + ++sy�2);
            }

            Console.WriteLine ("\n�iftboyutlu kordinat de�erleriyle true, false, &, |, &&, || i�lemciler:");
            ts1=r.Next(-100,100); ts2=r.Next(-100,100); �kiBoyut a = new �kiBoyut (ts1, ts2);
            ts1=r.Next(-100,100); �kiBoyut b = new �kiBoyut (ts1, ts1);
            �kiBoyut c = new �kiBoyut (0, 0);
            Console.Write ("a: "); a.g�ster();
            Console.Write (";\tb: "); b.g�ster();
            Console.Write (";\tc: "); c.g�ster();
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
            Console.WriteLine(); //K�sadevre &&: VE ile ||: VEYA
            if (a && b) Console.Write ("a && b = true."); else Console.Write ("a && b = false.");
            if (a && c) Console.Write ("\ta && c = true."); else Console.Write ("\ta && c = false.");
            if (b && c) Console.Write ("\tb && c = true."); else Console.Write ("\tb && c = false.");
            if (a || b) Console.Write ("\na || b = true."); else Console.Write ("\na || b = false.");
            if (a || c) Console.Write ("\ta || c = true."); else Console.Write ("\ta || c = false.");
            if (b || c) Console.Write ("\tb || c = true."); else Console.Write ("\tb || c = false.");

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}