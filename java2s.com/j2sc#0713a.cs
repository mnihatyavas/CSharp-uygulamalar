// j2sc#0713a.cs: Sýnýf alan eriþim deðiþtireçlerinden public ve private örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        public             string genelAlan;
        private            int özelAlan;
        protected          int korumalýAlan = 20230924;
        internal           string içselAlan;
        protected internal string korumalýÝçselAlan;
        public void özelAlanýKoy (int özelAlan) {this.özelAlan = özelAlan;}
        public int özelAlanýAl() {return özelAlan;}
        public int KorumalýAlanýAl() {return korumalýAlan;}
        public void GenelMetot() {
            Console.WriteLine ("public Sýnýf1.GenelMetot() çaðrýldý...");
            ÖzelMetot();
            Console.WriteLine ("public Sýnýf1.GenelMetot() sonlandýrýldý.");
        }
        private void ÖzelMetot() {Console.WriteLine ("private Sýnýf1.ÖzelMetot() çaðrýldý...");}
    }
    public class SýnýfA {
        public void _public() {Console.WriteLine ("\tSýnýfA._public()");}
        public void _private() {Console.WriteLine ("SýnýfA._private()");}
        public void _protected() {Console.WriteLine ("SýnýfA._protected()");}
        public void _internal() {Console.WriteLine ("SýnýfA._internal()");}
        public void _protectedInternal() {Console.WriteLine ("SýnýfA._protectedInternal()");}
    }
    public class SýnýfB {
        public void _public() {Console.WriteLine ("\tSýnýfB._public()");}
        public void _private() {Console.WriteLine ("SýnýfB._private()");}
        public void _protected() {Console.WriteLine ("SýnýfB._protected()");}
        public void _internal() {Console.WriteLine ("SýnýfB._internal()");}
        public void _protectedInternal() {Console.WriteLine ("SýnýfB._protectedInternal()");}
    }
    public class Sýnýf2 {
        private static Sýnýf2 önbellek = null;
        private static object önbellekKilidi = new object();
        public static string x;
        private Sýnýf2() {/* private kurucu ilkdeðerleme */}
        public static Sýnýf2 AlSýnýf2() {
            lock (önbellekKilidi) {
                if (önbellek == null) önbellek = new Sýnýf2();
                return (önbellek);
            }
        }
    }
    class Daire {
        double yarýçap; //Varsayýlý private
        public double Yarýçap {get{return (yarýçap);} set{yarýçap = value;} }
    }
    public class TV {
        private static int kanal = 2;
        private const int azamiKanal = 200;
        public TV (int k) {kanal=k; if (kanal>azamiKanal) kanal=azamiKanal;}
        public int Kanal {get{return kanal;}}
    }
    public class Araba {
        private static int hýz = 0;
        private const int azamiHýz = 200;
        public bool HýzDeðiþtiMi (int yeniHýz) {
            if (yeniHýz > azamiHýz) return false;
            hýz = yeniHýz; return true;
        }
        public void HýzýOku (int prm) {prm = hýz;}
        public void HýzýOku (ref int prm) {prm = hýz;}
    }
    class EriþimDeðiþtireci1 : SýnýfA{
        new public void _private() {Console.WriteLine ("EriþimDeðiþtireci1._private()");}
        static void Main() {
            Console.Write ("Eriþim deðiþtireçleri (public/genel, private/özel, protected/korumalý, internal/içsel, protected internal/korumalý içsel) sýnýf üyelerine nasýl eriþilebileceðini belirler.\nPublic sýnýrsýz eriþilebilirliði gösterir.\nPrivate üyeye sadece ayný sýnýf içi tiplemeyle eriþilebilir.\nProtected üyeye sadece tanýmlý sýnýf ve altsýnýflarý içinden veya miraslanmayla eriþilebilir.\nInternal üyeye public gibi fakat sadece aktüel uygulama içinden ve tiplemeyle eriþilebilir.\nProtectedInternal üyeye public gibi fakat sadece aktüel uygulama içinden veya harici uygulamadaysa miraslamayla eriþilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("public, private, protected, internal, protected internal eriþimler:");
            Sýnýf1 s1 = new Sýnýf1();
            s1.genelAlan = "Toyoto";
            s1.korumalýÝçselAlan = "MR2";
            s1.içselAlan = "siyah";
            s1.özelAlanýKoy (19381110);
            Console.WriteLine ("s1.genelAlan = " + s1.genelAlan);
            Console.WriteLine ("s1.korumalýÝçselAlan = " + s1.korumalýÝçselAlan);
            Console.WriteLine ("s1.içselAlan = " + s1.içselAlan);
            Console.WriteLine ("s1.KorumalýAlanýAl = " + s1.KorumalýAlanýAl());
            Console.WriteLine ("s1.özelAlanýAl() = " + s1.özelAlanýAl());
            s1.GenelMetot();

            Console.WriteLine ("\n3 sýnýf tiplemesinin kendi ve mirasladýðý metotlara eriþimi:");
            EriþimDeðiþtireci1 ed1 = new EriþimDeðiþtireci1();
            SýnýfA sA = new SýnýfA();
            SýnýfB sB = new SýnýfB();
            ed1._public(); ed1._private(); ed1._protected(); ed1._internal(); ed1._protectedInternal();
            sA._public(); sA._private(); sA._protected(); sA._internal(); sA._protectedInternal();
            sB._public(); sB._private(); sB._protected(); sB._internal(); sB._protectedInternal();

            Console.WriteLine ("\nprivate statik nesnel alan deðerini okuma:");
            Console.WriteLine (Sýnýf2.AlSýnýf2() );
            Sýnýf2.x="20230925-20:47:51"; Console.WriteLine (Sýnýf2.x);
            Console.WriteLine (Sýnýf2.AlSýnýf2() );
            Sýnýf2.x="M.Nihat Yavaþ - Toroslar / MERSÝN"; Console.WriteLine (Sýnýf2.x);

            Console.WriteLine ("\nPrivate sýnýf alanýna public set-get'le eriþilir:");
            var r=new Random(); int ts1, i; double ds1; Daire d;
            for(i=0;i<5;i++) {
                ds1=r.Next (0, 100) + r.Next (1000, 10000) / 1e4D;
                d=new Daire(); d.Yarýçap=ds1;
                Console.WriteLine ("Daire (yarýçap, çevre, alan) = ({0:0.00}, {1:0.00}, {2:#,0.00})", d.Yarýçap, 2*Math.PI*d.Yarýçap, Math.PI*d.Yarýçap*d.Yarýçap);
            }

            Console.WriteLine ("\nAzami kanal dahilinde TV (private) kanal-no seçimi:");
            TV tv;
            for(i=0;i<5;i++) {
                ts1=r.Next (0, 300); tv=new TV (ts1);
                Console.WriteLine ("Týklanan kanal no: {0}", tv.Kanal);
            }

            Console.WriteLine ("\n'ref' parametreyle private alaný okuma:");
            Araba oto = new Araba(); int hýz=0, refHýz=0;
            for(i=0;i<5;i++) {
                ts1=r.Next (0, 300); Console.WriteLine ("Yeni hýz = {0} kmS,\tHýz deðiþti mi? {1}", ts1, oto.HýzDeðiþtiMi (ts1));
                oto.HýzýOku (hýz); oto.HýzýOku (ref refHýz); Console.WriteLine ("\tGüncel hýz (refsiz, refli) = ({0}, {1})", hýz, refHýz);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}