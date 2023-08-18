// j2sc#0602.cs: Çeþitli tekli, çoklu, içiçe yapý tanýmlarý örneði.

using System;
namespace Yapýlar {
    public struct Dikdörtgen {
        public int en; //Alanlarýn tanýmý
        public int boy;
        public Dikdörtgen (int en, int boy) {// Kurucunun tanýmý
            this.en = en;
            this.boy = boy;
        }
        public int alan() {return en * boy;} //Metod tanýmý
    }
    public struct Yapý2 {
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
    enum ÝþgTip: sbyte {Müdür = 20, Araþtýrmacý = -1, Sözleþmeli = 127, Programcý = 9}
    struct ÝÞGÖREN {
        public ÝþgTip ünvan;
        public string isim;
        public short bölümNo;
        public ÝÞGÖREN (ÝþgTip ün, string ism, short bn) {ünvan = ün; isim = ism; bölümNo = bn;}
        public override string ToString() {return (String.Format ("Ýsim: {0}\tBölüm no: {1}\tÜnvaný: {2}\tMaaþý: {3}", isim, bölümNo, ünvan, 1000*(sbyte)ünvan) );}
    }
    struct üyesizYapý{}
    struct üyeliYapý {short s; int i; long l; bool b;}
    struct bileþikYapý {üyesizYapý a; üyeliYapý b; üyesizYapý c;}
    struct Açý {
        private int _Saat;
        private int _Dakika;
        private int _Saniye;
        public Açý (int saat, int dakika, int saniye) {
            _Saat = saat;
            _Dakika = dakika;
            _Saniye = saniye;
        }
        public int Saat {get {return _Saat;} }
        public int Dakika {get {return _Dakika;}}
        public int Saniye {get {return _Saniye;}}
        public void Taþý (int saat, int dakika, int saniye) {_Saat +=saat; _Dakika +=dakika; _Saniye +=saniye;}
    }
    class Kordinat {
        private Açý _boylam;
        private Açý _enlem;
        public Açý boylam {get {return _boylam;} set {_boylam = value;} }
        public Açý enlem {get {return _enlem;} set {_enlem = value;} }

    }
    class YapýTanýmý {
        static void Main() {
            Console.Write ("sizeof() metodu hem 'unsafe{}' blokla hem de '.../unsafe' parametreli derlenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("En boy argümanlý yaratýlan Dikdörtgen tiplemesi ve alaný:");
            Dikdörtgen dd1 = new Dikdörtgen (2, 3);
            Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());
            dd1 = new Dikdörtgen (5, 2); Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());
            dd1 = new Dikdörtgen (8, 3); Console.WriteLine ("dd1.en = {0}\tdd1.boy = {1}\tdd1.alan = {2}", dd1.en, dd1.boy, dd1.alan());

            Console.WriteLine ("\n'new' kurucusuz Yapý2 alanlarýna deðer atamalarý:");
            Yapý2 y2;
            y2.ts = int.MaxValue; y2.ls = long.MaxValue; y2.dzg = "Merhabalar!"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);
            y2.ts = int.MinValue; y2.ls = long.MinValue; y2.dzg = "M.Nihat Yavaþ"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);
            unchecked {y2.ts = (int)float.Epsilon; y2.ls = (long)double.PositiveInfinity;} y2.dzg = "Z.Nihal Yavaþ"; Console.WriteLine ("y2.ts = {0}\ty2.ls = {1}\ty2.dzg = {2}", y2.ts, y2.ls, y2.dzg);

            Console.WriteLine ("\nYapýsal nokta kordinatlarýný tanýmlý dizgesel biçimde gösterme:");
            var r=new Random();
            Nokta nkt = new Nokta ((int)r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("nkt: {0}", nkt);
            nkt = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("nkt: {0}", nkt);
            nkt = new Nokta(); nkt.x=r.Next (-100, 100); nkt.y=r.Next (-100, 100); Console.WriteLine ("nkt: {0}", nkt);

            Console.WriteLine ("\nYapýsal ÝÞGÖREN'i tanýmlý dizgesel biçimde gösterme:");
            ÝÞGÖREN nihat; nihat.bölümNo = 40; nihat.isim = "M.Nihat Yavaþ"; nihat.ünvan = ÝþgTip.Araþtýrmacý; Console.WriteLine (nihat);
            ÝÞGÖREN nihal = new ÝÞGÖREN (ÝþgTip.Sözleþmeli, "Z.Nihal Candan", 10); Console.WriteLine (nihal);
            ÝÞGÖREN canan = new ÝÞGÖREN (ÝþgTip.Müdür, "Canan Candan", 20); Console.WriteLine (canan);

            Console.WriteLine ("\nunsafe sizeof ile boþ, dolu, bileþik yapýlarýn ebatlarý:");
            unsafe {// derleme "/unsafe" ile yapýlmalý
                Console.WriteLine ("üyesizYapý'nýn ebatý = {0} Byte", sizeof (üyesizYapý));
                Console.WriteLine ("üyeliYapý'nýn ebatý = {0} Byte",sizeof (üyeliYapý));
                Console.WriteLine ("bileþikYapý'nýn ebatý = {0} Byte", sizeof (bileþikYapý));
            }

            Console.WriteLine ("\nÝçiçe yapýlarla dünya boylam ve enlemin açýsal konumlarýný koyma/alma:");
            Açý açý = new Açý (35, 59, 25); Console.WriteLine ("Açý (saat, dakika, saniye) = ({0}, {1}, {2})", açý.Saat, açý.Dakika, açý.Saniye);
            açý.Taþý (7, -10, 30); Console.WriteLine ("Açýsal +(7, -10, 30) taþýnan yeni açý = ({0}, {1}, {2})", açý.Saat, açý.Dakika, açý.Saniye); //Ýsterseniz taþýmada <0 veya >60 durumunda öncekini 1 eksiltme veya artýrmayý iþleyin...
            açý.Taþý (-27, 6, -25); Console.WriteLine ("Açýsal +(-27, 6, -25) taþýnan yeni açý = ({0}, {1}, {2})", açý.Saat, açý.Dakika, açý.Saniye);
            Kordinat kor = new Kordinat(); kor.boylam = new Açý (31, 33, 51); kor.enlem = new Açý (15, 51, 35);
            Console.WriteLine ("Kordinat.Boylam (S, d, s) = ({0}, {1}, {2})\tEnlem = ({3}, {4}, {5})", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);
            kor = new Kordinat(); kor.boylam = new Açý (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60)); kor.enlem = new Açý (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60));
            Console.WriteLine ("Kordinat.Boylam (o, ', \") = ({0}o, {1}', {2}\")\tEnlem = ({3}o, {4}', {5}\")", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);
            kor = new Kordinat(); kor.boylam = new Açý (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60)); kor.enlem = new Açý (r.Next (0, 60), r.Next (0, 60), r.Next (0, 60));
            Console.WriteLine ("Kordinat.Boylam (o, ', \") = ({0}o, {1}', {2}\")\tEnlem = ({3}o, {4}', {5}\")", kor.boylam.Saat, kor.boylam.Dakika, kor.boylam.Saniye, kor.enlem.Saat, kor.enlem.Dakika, kor.enlem.Saniye);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}