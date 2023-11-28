// j2sc#0719b.cs: Esgeçmeyle aynı sınıfın farklı tipli endeksleyicileri örneği.

using System;
using System.Collections;
namespace Sınıflar {
    class Dizi {
        int[] a;
        public int uzun;
        public bool hataMı;
        public Dizi (int ebat) {a = new int [ebat]; uzun = ebat;} //Kurucu
        public int this [int endeks] {//Endeksleyici
            set {if (endeksKontrol (endeks)) {a [endeks] = value; hataMı = false;
                }else hataMı = true;
            }
            get {if (endeksKontrol (endeks)) {hataMı = false; return a [endeks];
                }else {hataMı = true; return 0;}
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
        public int this [int endeks] {set {a [endeks] = value;} get {return a [endeks];}} //Tamsayı Endeksleyici
        public int this [double endeks] {set {a [(int)endeks] = value;} get {return a [(int)endeks];}}//Dublesayı Endeksleyici
        public int this [string e] {set {a [(int)(e.ToUpper())[0] -'A'] = value;} get {return a [(int)(e.ToUpper())[0] -'A'];}}//Dizge Endeksleyici
    }
    class Sıralayıcı {public long this [int endeks] {get {return  (long)Math.Pow (2023, endeks);}}}
    class TekÇift {
        int tek;
        int çift;
        public int this [int i] {
            set {if (i%2==0) çift=value; else tek=value;}
            get {return (i%2==0) ? çift : tek;}
        }
    }
    public abstract class Şekil {public abstract void Çiz();}
    public class Dikdörtgen : Şekil {public override void Çiz() {Console.WriteLine ("Dikdörtgen.Çiz() yürütülüyor");}}
    public class Daire : Şekil {public override void Çiz() {Console.WriteLine ("Daire.Çiz() yürütülüyor");}}
    public class Üçgen : Şekil {public override void Çiz() {Console.WriteLine ("Üçgen.Çiz() yürütülüyor");}}
    public class Kare : Şekil {public override void Çiz() {Console.WriteLine ("Kare.Çiz() yürütülüyor");}}
    public class Yamuk : Şekil {public override void Çiz() {Console.WriteLine ("Yamuk.Çiz() yürütülüyor");}}
    public class ŞekilListesi {
        private ArrayList şekiller;
        public ŞekilListesi() {şekiller = new ArrayList();} //Kurucu
        public int Ebat {get {return şekiller.Count;}}
        public Şekil this [int endeks] {get {return (Şekil)şekiller [endeks];}}
        public void Ekle (Şekil şekil) {şekiller.Add (şekil);}
    }
    class Günler {
        string[] günler = {"Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar"};
        private int GünAl (string gün) {
            for(int i = 0; i < günler.Length; i++) {if (günler[i].ToLower() == gün.ToLower()) {return i;}}
            throw new System.ArgumentOutOfRangeException (gün, "Gün adını yanlış girdiniz!");
        }
        public int this [string gün] {get {return (GünAl (gün));}}
        public string this [int gün] {get {if(gün>=0 & gün<=6) return (günler [gün]); else throw new System.ArgumentOutOfRangeException (gün.ToString(), "Gün sayısını [0, 6] yanlış girdiniz!");}}
    }
    class Dizi3B {
        public Dizi3B (int x, int y, int z){} 
        public int this [int end1, int end2, int end3] {get {return (int)Math.Pow (end1, end2) * end3;}}
    }
    class Endeksleyici2 {
        static void Main() {
            Console.Write ("Sabit ebatlı endeksleyici -+taşma hataları kodlamayla kontrol edilmelidir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Saptanan ebatı taşan hatalı endekslerin tespiti:");
            var r=new Random(); int x, ts1, ts2, i;
            ts2=10;
            Dizi dizi = new Dizi (ts2);
            Console.WriteLine ("\tSessiz endeks hatası ayıklayıcı:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; if (x != 0) Console.Write ("dizi[{0}]={1} ", i, x);} Console.WriteLine();
            Console.WriteLine ("\t0 geridönüşlü hatalı endeks beyancısı:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; Console.Write ("dizi[{0}]={1} ", i, x);} Console.WriteLine();
            Console.WriteLine ("\tEndeks hatasının aleni beyanı:");
            for (i=-2; i < 12; i++) {ts1=r.Next(100,1000); dizi [i] = ts1;}
            for (i=-2; i < 12; i++) {x=dizi [i]; if (!dizi.hataMı) Console.Write ("dizi[{0}]={1} ", i, x); else Console.Write ("dizi[{0}]={1} ", i, "HATA");} Console.WriteLine();

            Console.WriteLine ("\nAynı endeksleyicinin int-double-string endeksle kullanımı:");
            ts2=5;
            Dizi2 dizi2 = new Dizi2 (ts2);
            Console.WriteLine ("\tTam-sayısal endeksleyici:");
            for (i=0; i < 5; i++) {ts1=r.Next(100,1000); dizi2 [i] = ts1;}
            for (i=0; i < 5; i++) {Console.Write ("dizi[{0}]={1} ", i, dizi2 [i]);} Console.WriteLine();
            Console.WriteLine ("\tDuble-sayısal endeksleyici:");
            for (double j=0.37; j < 5.37; j++) {ts1=r.Next(100,1000); dizi2 [j] = ts1;}
            for (double j=0.75; j < 5.75; j++) {Console.Write ("dizi[{0}]={1} ", j, dizi2 [j]);} Console.WriteLine();
            Console.WriteLine ("\tDizgesel endeksleyici:");
            for (i=0; i < 5; i++) {ts1=r.Next(100,1000); dizi2 [((char)(i+65)).ToString()] = ts1;}
            for (i=0; i < 5; i++) {Console.Write ("dizi[{0}]={1} ", ((char)(i+65)).ToString(), dizi2 [((char)(i+65)).ToString()]);} Console.WriteLine();

            Console.WriteLine ("\nMath.Pow() ile artan endeksleyici geridönüşleri:");
            Sıralayıcı sırala = new Sıralayıcı();
            for(i=0; i <=5; i++) Console.Write ("sırala[{0}]={1} ", i, sırala [i]); Console.WriteLine();

            Console.WriteLine ("\nEndeksleyici set-get'in rasgele tek-çift sayıları kontrollu ayrıştırması:");
            TekÇift tç=new TekÇift();
            for (i=0; i < 10; i++) {ts1=r.Next(-1000,1000); tç [i] = ts1; if (ts1%2==0) Console.WriteLine ("\tÇift [{0}] = {1}", i, tç [i]); else Console.WriteLine ("Tek [{0}] = {1}", i, tç [i]);}

            Console.WriteLine ("\nArrayList endeksleyiciye Add'le eklenen şekil çizimleri listesi:");
            ŞekilListesi şl = new ŞekilListesi();
            şl.Ekle (new Dikdörtgen()); şl.Ekle (new Daire()); şl.Ekle (new Yamuk()); şl.Ekle (new Üçgen()); şl.Ekle (new Kare());
            for(i = 0; i < şl.Ebat; ++i) {((Şekil)şl [i]).Çiz();}

            Console.WriteLine ("\n'int this [string gün]' ve 'string this [int gün]' endeksleyiciler:");
            Günler gün = new Günler();
            Console.WriteLine ("\tHaftanın gün adları:");
            for(i=0;i<7;i++) Console.Write (gün [i] + ", ");
            Console.WriteLine ("\n\tGünadı girişi:");
            Console.WriteLine ("Çarşamba, haftanın {0}.inci günüdür.", gün ["Çarşamba"]+1);
            Console.WriteLine ("Pazartesi, haftanın {0}.inci günüdür.", gün ["PAZARTESİ"]+1);
            Console.WriteLine ("Pazar, haftanın {0}.inci günüdür.", gün ["paZAr"]+1);
            try {Console.WriteLine ("Cuma, haftanın {0}.inci günüdür.", gün ["Cumali"]+1);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            Console.WriteLine ("\tHaftanın gün sayısı girişi:");
            Console.WriteLine ("Haftanın 4.üncü günü: {0}'dir.", gün [4-1]);
            Console.WriteLine ("Haftanın 6.ıncı günü: {0}'dir.", gün [6-1]);
            try {Console.WriteLine ("Haftanın 7.inci günü: {0}'dir.", gün [7]);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            Console.WriteLine ("Haftanın 7.inci günü: {0}'dır.", gün [7-1]);

            Console.WriteLine ("\n3 boyutlu endeksleyicinin endekslerle hesap (e1^e2*e3) geridönüşleri:");
            Dizi3B d3b = new Dizi3B (3, 5, 4);
            for(i=0;i<3;i++) for(int j=0;j<5;j++) for(int k=0;k<4;k++) Console.Write ("d3b({0},{1},{2})={3} ", i, j, k, d3b [i,j,k]); Console.WriteLine();

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}