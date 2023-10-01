// j2sc#0713a.cs: S�n�f alan eri�im de�i�tire�lerinden public ve private �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        public             string genelAlan;
        private            int �zelAlan;
        protected          int korumal�Alan = 20230924;
        internal           string i�selAlan;
        protected internal string korumal���selAlan;
        public void �zelAlan�Koy (int �zelAlan) {this.�zelAlan = �zelAlan;}
        public int �zelAlan�Al() {return �zelAlan;}
        public int Korumal�Alan�Al() {return korumal�Alan;}
        public void GenelMetot() {
            Console.WriteLine ("public S�n�f1.GenelMetot() �a�r�ld�...");
            �zelMetot();
            Console.WriteLine ("public S�n�f1.GenelMetot() sonland�r�ld�.");
        }
        private void �zelMetot() {Console.WriteLine ("private S�n�f1.�zelMetot() �a�r�ld�...");}
    }
    public class S�n�fA {
        public void _public() {Console.WriteLine ("\tS�n�fA._public()");}
        public void _private() {Console.WriteLine ("S�n�fA._private()");}
        public void _protected() {Console.WriteLine ("S�n�fA._protected()");}
        public void _internal() {Console.WriteLine ("S�n�fA._internal()");}
        public void _protectedInternal() {Console.WriteLine ("S�n�fA._protectedInternal()");}
    }
    public class S�n�fB {
        public void _public() {Console.WriteLine ("\tS�n�fB._public()");}
        public void _private() {Console.WriteLine ("S�n�fB._private()");}
        public void _protected() {Console.WriteLine ("S�n�fB._protected()");}
        public void _internal() {Console.WriteLine ("S�n�fB._internal()");}
        public void _protectedInternal() {Console.WriteLine ("S�n�fB._protectedInternal()");}
    }
    public class S�n�f2 {
        private static S�n�f2 �nbellek = null;
        private static object �nbellekKilidi = new object();
        public static string x;
        private S�n�f2() {/* private kurucu ilkde�erleme */}
        public static S�n�f2 AlS�n�f2() {
            lock (�nbellekKilidi) {
                if (�nbellek == null) �nbellek = new S�n�f2();
                return (�nbellek);
            }
        }
    }
    class Daire {
        double yar��ap; //Varsay�l� private
        public double Yar��ap {get{return (yar��ap);} set{yar��ap = value;} }
    }
    public class TV {
        private static int kanal = 2;
        private const int azamiKanal = 200;
        public TV (int k) {kanal=k; if (kanal>azamiKanal) kanal=azamiKanal;}
        public int Kanal {get{return kanal;}}
    }
    public class Araba {
        private static int h�z = 0;
        private const int azamiH�z = 200;
        public bool H�zDe�i�tiMi (int yeniH�z) {
            if (yeniH�z > azamiH�z) return false;
            h�z = yeniH�z; return true;
        }
        public void H�z�Oku (int prm) {prm = h�z;}
        public void H�z�Oku (ref int prm) {prm = h�z;}
    }
    class Eri�imDe�i�tireci1 : S�n�fA{
        new public void _private() {Console.WriteLine ("Eri�imDe�i�tireci1._private()");}
        static void Main() {
            Console.Write ("Eri�im de�i�tire�leri (public/genel, private/�zel, protected/korumal�, internal/i�sel, protected internal/korumal� i�sel) s�n�f �yelerine nas�l eri�ilebilece�ini belirler.\nPublic s�n�rs�z eri�ilebilirli�i g�sterir.\nPrivate �yeye sadece ayn� s�n�f i�i tiplemeyle eri�ilebilir.\nProtected �yeye sadece tan�ml� s�n�f ve alts�n�flar� i�inden veya miraslanmayla eri�ilebilir.\nInternal �yeye public gibi fakat sadece akt�el uygulama i�inden ve tiplemeyle eri�ilebilir.\nProtectedInternal �yeye public gibi fakat sadece akt�el uygulama i�inden veya harici uygulamadaysa miraslamayla eri�ilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("public, private, protected, internal, protected internal eri�imler:");
            S�n�f1 s1 = new S�n�f1();
            s1.genelAlan = "Toyoto";
            s1.korumal���selAlan = "MR2";
            s1.i�selAlan = "siyah";
            s1.�zelAlan�Koy (19381110);
            Console.WriteLine ("s1.genelAlan = " + s1.genelAlan);
            Console.WriteLine ("s1.korumal���selAlan = " + s1.korumal���selAlan);
            Console.WriteLine ("s1.i�selAlan = " + s1.i�selAlan);
            Console.WriteLine ("s1.Korumal�Alan�Al = " + s1.Korumal�Alan�Al());
            Console.WriteLine ("s1.�zelAlan�Al() = " + s1.�zelAlan�Al());
            s1.GenelMetot();

            Console.WriteLine ("\n3 s�n�f tiplemesinin kendi ve miraslad��� metotlara eri�imi:");
            Eri�imDe�i�tireci1 ed1 = new Eri�imDe�i�tireci1();
            S�n�fA sA = new S�n�fA();
            S�n�fB sB = new S�n�fB();
            ed1._public(); ed1._private(); ed1._protected(); ed1._internal(); ed1._protectedInternal();
            sA._public(); sA._private(); sA._protected(); sA._internal(); sA._protectedInternal();
            sB._public(); sB._private(); sB._protected(); sB._internal(); sB._protectedInternal();

            Console.WriteLine ("\nprivate statik nesnel alan de�erini okuma:");
            Console.WriteLine (S�n�f2.AlS�n�f2() );
            S�n�f2.x="20230925-20:47:51"; Console.WriteLine (S�n�f2.x);
            Console.WriteLine (S�n�f2.AlS�n�f2() );
            S�n�f2.x="M.Nihat Yava� - Toroslar / MERS�N"; Console.WriteLine (S�n�f2.x);

            Console.WriteLine ("\nPrivate s�n�f alan�na public set-get'le eri�ilir:");
            var r=new Random(); int ts1, i; double ds1; Daire d;
            for(i=0;i<5;i++) {
                ds1=r.Next (0, 100) + r.Next (1000, 10000) / 1e4D;
                d=new Daire(); d.Yar��ap=ds1;
                Console.WriteLine ("Daire (yar��ap, �evre, alan) = ({0:0.00}, {1:0.00}, {2:#,0.00})", d.Yar��ap, 2*Math.PI*d.Yar��ap, Math.PI*d.Yar��ap*d.Yar��ap);
            }

            Console.WriteLine ("\nAzami kanal dahilinde TV (private) kanal-no se�imi:");
            TV tv;
            for(i=0;i<5;i++) {
                ts1=r.Next (0, 300); tv=new TV (ts1);
                Console.WriteLine ("T�klanan kanal no: {0}", tv.Kanal);
            }

            Console.WriteLine ("\n'ref' parametreyle private alan� okuma:");
            Araba oto = new Araba(); int h�z=0, refH�z=0;
            for(i=0;i<5;i++) {
                ts1=r.Next (0, 300); Console.WriteLine ("Yeni h�z = {0} kmS,\tH�z de�i�ti mi? {1}", ts1, oto.H�zDe�i�tiMi (ts1));
                oto.H�z�Oku (h�z); oto.H�z�Oku (ref refH�z); Console.WriteLine ("\tG�ncel h�z (refsiz, refli) = ({0}, {1})", h�z, refH�z);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}