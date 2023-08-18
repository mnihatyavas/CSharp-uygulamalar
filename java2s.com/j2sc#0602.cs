// j2sc#0602.cs: �e�itli tekli, �oklu, i�i�e yap� tan�mlar� �rne�i.

using System;
namespace Yap�lar {
    public struct Dikd�rtgen {
        public int en; //Alanlar�n tan�m�
        public int boy;
        public Dikd�rtgen (int en, int boy) {// Kurucunun tan�m�
            this.en = en;
            this.boy = boy;
        }
        public int alan() {return en * boy;} //Metod tan�m�
    }
    public struct Yap�2 {
        public int ts;
        public long ls;
        public string dzg;
    }
    struct Nokta {
        public int x;
        public int y;
        public Nokta (int x, int y) {this.x = x; this.y = y;}
        public override string ToString() {return (String.Format ("({0}, {1})", x, y));}
    }
    enum ��gTip: sbyte {M�d�r = 20, Ara�t�rmac� = -1, S�zle�meli = 127, Programc� = 9}
    struct ��G�REN {
        public ��gTip �nvan;
        public string isim;
        public short b�l�mNo;
        public ��G�REN (��gTip �n, string ism, short bn) {�nvan = �n; isim = ism; b�l�mNo = bn;}
        public override string ToString() {return (String.Format ("�sim: {0}\tB�l�m no: {1}\t�nvan�: {2}\tMaa��: {3}", isim, b�l�mNo, �nvan, 1000*(sbyte)�nvan) );}
    }
    struct �yesizYap�{}
    struct �yeliYap� {short s; int i; long l; bool b;}
    struct bile�ikYap� {�yesizYap� a; �yeliYap� b; �yesizYap� c;}
    struct A�� {
        private int _Saat;
        private int _Dakika;
        private int _Saniye;
        public A�� (int saat, int dakika, int saniye) {
            _Saat = saat;
            _Dakika = dakika;
            _Saniye = saniye;
        }
        public int Saat {get {return _Saat;} }
        public int Dakika {get {return _Dakika;}}
        public int Saniye {get {return _Saniye;}}
        public void Ta�� (int saat, int dakika, int saniye) {_Saat +=saat; _Dakika +=dakika; _Saniye +=saniye;}
    }
    class Kordinat {
        private A�� _boylam;
        private A�� _enlem;
        public A�� boylam {get {return _boylam;} set {_boylam = value;} }
        public A�� enlem {get {return _enlem;} set {_enlem = value;} }

    }
    class Yap�Tan�m� {
        static void Main() {
            Console.Write ("sizeof() metodu hem 'unsafe{}' blokla hem de '.../unsafe' parametreli derlenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("En boy arg�manl� yarat�lan Dikd�rtgen tiplemesi ve alan�:");
            Dikd�rtgen dd1 = new Dikd�rtgen (2, 3);
            Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());
            dd1 = new Dikd�rtgen (5, 2); Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());
            dd1 = new Dikd�rtgen (8, 3); Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());

            Console.WriteLine ("\n'new' kurucusuz Yap�2 alanlar�na de�er atamalar�:");
            Yap�2 y2;
            y2.ts = int.MaxValue; y2.ls = long.MaxValue; y2.dzg = "Merhabalar!"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);
            y2.ts = int.MinValue; y2.ls = long.MinValue; y2.dzg = "M.Nihat Yava�"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);
            unchecked {y2.ts = (int)float.Epsilon; y2.ls = (long)double.PositiveInfinity;} y2.dzg = "Z.Nihal Yava�"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);

            Console.WriteLine ("\nYap�sal nokta kordinatlar�n� tan�ml� dizgesel bi�imde g�sterme:");
            var r=new Random();
            Nokta nkt = new Nokta ((int)r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("nkt: {0}", nkt);
            nkt = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("nkt: {0}", nkt);
            nkt = new Nokta(); nkt.x=r.Next (-100, 100); nkt.y=r.Next (-100, 100); Console.WriteLine ("nkt: {0}", nkt);

            Console.WriteLine ("\nYap�sal ��G�REN'i tan�ml� dizgesel bi�imde g�sterme:");
            ��G�REN nihat; nihat.b�l�mNo = 40; nihat.isim = "M.Nihat Yava�"; nihat.�nvan = ��gTip.Ara�t�rmac�; Console.WriteLine (nihat);
            ��G�REN nihal = new ��G�REN (��gTip.S�zle�meli, "Z.Nihal Candan", 10); Console.WriteLine (nihal);
            ��G�REN canan = new ��G�REN (��gTip.M�d�r, "Canan Candan", 20); Console.WriteLine (canan);

            Console.WriteLine ("\nunsafe sizeof ile bo�, dolu, bile�ik yap�lar�n ebatlar�:");
            unsafe {// derleme "/unsafe" ile yap�lmal�
                Console.WriteLine ("�yesizYap�'n�n ebat� = {0} Byte", sizeof (�yesizYap�));
                Console.WriteLine ("�yeliYap�'n�n ebat� = {0} Byte",sizeof (�yeliYap�));
                Console.WriteLine ("bile�ikYap�'n�n ebat� = {0} Byte", sizeof (bile�ikYap�));
            }

            Console.WriteLine ("\n��i�e yap�larla d�nya boylam ve enlemin a��sal konumlar�n� koyma/alma:");
            A�� a�� = new A�� (35, 59, 25); Console.WriteLine ("A�� (saat, dakika, saniye) = ({0}, {1}, {2})", a��.Saat, a��.Dakika, a��.Saniye);
            a��.Ta�� (7, -10, 30); Console.WriteLine ("A��sal +(7, -10, 30) ta��nan yeni a�� = ({0}, {1}, {2})", a��.Saat, a��.Dakika, a��.Saniye); //�sterseniz ta��mada <0 veya >60 durumunda �ncekini 1 eksiltme veya art�rmay� i�leyin...
            a��.Ta�� (-27, 6, -25); Console.WriteLine ("A��sal +(-27, 6, -25) ta��nan yeni a�� = ({0}, {1}, {2})", a��.Saat, a��.Dakika, a��.Saniye);
            Kordinat kor = new Kordinat(); kor.boylam = new A�� (31, 33, 51); kor.enlem = new A�� (15, 51, 35);
            Console.WriteLine ("Kordinat.Boylam (S, d, s) = ({0}, {1}, {2})\tEnlem = ({3}, {4}, {5})", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);
            kor = new Kordinat(); kor.boylam = new A�� (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60)); kor.enlem = new A�� (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60));
            Console.WriteLine ("Kordinat.Boylam (o, ', \") = ({0}o, {1}', {2}\")\tEnlem = ({3}o, {4}', {5}\")", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);
            kor = new Kordinat(); kor.boylam = new A�� (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60)); kor.enlem = new A�� (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60));
            Console.WriteLine ("Kordinat.Boylam (o, ', \") = ({0}o, {1}', {2}\")\tEnlem = ({3}o, {4}', {5}\")", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}