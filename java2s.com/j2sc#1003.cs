// j2sc#1005.cs: Reflection/Assembly, conditional/þartlý ve obsolete/tedavülsüz vasýflar örneði.

#define DENEME
#define SÜRÜMLÜ
//#define GÝZLÝ
#define debug
using System;
using System.Reflection; //Assembly için
using System.Diagnostics; //Conditional için
namespace Vasýflar {
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class KodGözlemVasfý: Attribute {
        string gözlemci, tarih, yorum;
        public KodGözlemVasfý (string g, string t) {gözlemci = g; tarih = t; yorum="Yok";} //Kurucu
        public string Yorum {get {return(yorum);} set {yorum = value;}} //Özellik
        public string Tarih {get {return(tarih);}}
        public string Gözlemci {get {return(gözlemci);}}
    }
    [KodGözlemVasfý ("M.Nihat Yavaþ", "01-12-2022", Yorum="Yorum haricen girilecek")]
    [KodGözlemVasfý ("M.Nedim Yavaþ", "01-08-2023", Yorum="Kurucuyla girilen tarih için set gerekmez")]
    [KodGözlemVasfý ("Memet Yavaþ", "01-012-2023", Yorum="Kurucuyla girilen gözlemci için set gerekmez")]
    class Sýnýf1{}
    [AttributeUsage (AttributeTargets.Class)]
    public class SýnýfHedef : Attribute {public SýnýfHedef(){}}
    [AttributeUsage (AttributeTargets.Method)]
    public class MetodHedef : Attribute {public MetodHedef(){}}
    public class Sýnýf2 {
        [MetodHedef]
        public int Metot() {return 20231216;}
    }
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class DoðruYanlýþVasfý : Attribute {
        bool ikili;
        public bool Deðer() {return ikili;}
        public DoðruYanlýþVasfý (bool b) {ikili = b;} //Kurucu
    }
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class DizgeVasfý : Attribute {
        string dizge;
        public string Deðer() {return dizge;}
        public DizgeVasfý (string d) {dizge = d;} //Kurucu
    }
    [DoðruYanlýþVasfý (true)]
    [DoðruYanlýþVasfý (false)]
    [DoðruYanlýþVasfý (true)]
    [DizgeVasfý ("Kodlama-1")]
    [DizgeVasfý ("Kodlama-2")]
    [DizgeVasfý ("Kodlama-3")]
    public class Sýnýf3{}
    public class HataAyýkla {
        [Conditional ("debug")]
        public void DebugTanýmlýysaYürüt() {Console.WriteLine ("Kodlama baþýnda '#define debug' tanýmlanmýþtýr");}
    }
    class Vasýf3 {
        [Conditional("DENEME")]  
        void deneme() {Console.WriteLine ("Sadece deneme amaçlý olup daðýtýmý yapýlamaz.");} 
        [Conditional ("SÜRÜMLÜ")]  
        void sürüm() {Console.WriteLine ("Nihai piyasa sürüm uyarlamasýdýr, daðýtýmý serbesttir.");}
        [Conditional ("GÝZLÝ")]  
        void kopya() {Console.WriteLine ("Ücretsiz gizli kopya daðýtýmý yasaktýr.");}
        [Obsolete ("Bunun yerine yeniMetot()'u kullanýn.")]
        static double eskiMetot (double a, double b) {return 0D;}
        [Obsolete ("Bunun yerine yeniMetot()'u kullanýn.", true)]
        static double eskiMetot2 (double a, double b) {return 0D;}
        [Obsolete]
        static double eskiMetot3 (double a, double b) {return 0D;}
        static double yeniMetot (double a, double b) {if (b != 0) return a/b; return 0;} 
        static void Main() {
            Console.Write ("Çoklu deðerler konumsal parametre artan deðeriyle sýralanarak dökümlenir.\nÞartlý/Conditional metot #if benzeri #define'la tanýmlanýr, void'dur, arayüz deðil sýnýftadýr ve esgeçmez.\nTedavülsüz/Obsolete (false) metot derlemede tanýmlý ikazý, (true) ise derleme hatasý verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf1 ile KodGözlemVasfý arasýndaki kodlanmýþ vasýf deðerlerinin dökümü:");
            Type tip1 = typeof (Sýnýf1);
            foreach (KodGözlemVasfý kgv in tip1.GetCustomAttributes (typeof (KodGözlemVasfý), false)) {
                Console.WriteLine ("\tGözlemci: {0}", kgv.Gözlemci);
                Console.WriteLine ("Tarih: {0}", kgv.Tarih);
                Console.WriteLine ("Yorum: {0}", kgv.Yorum);
            }

            Console.WriteLine ("\nReflection.Assembly ile çoklu AttributeUsage yapýsý iþleme:");
            SýnýfHedef sh;
            MetodHedef mh;
            try {
                Assembly ass = Assembly.LoadFrom ("Sýnýf2");
                foreach (Type tip in ass.GetTypes()) {
                    sh = (SýnýfHedef) Attribute.GetCustomAttribute (tip, typeof (SýnýfHedef));
                    if (sh != null) {
                        foreach (MethodInfo mi in tip.GetMethods()) {
                            mh = (MetodHedef) Attribute.GetCustomAttribute (mi, typeof (MetodHedef));
                            if (mh != null) {
                                Object ns = Activator.CreateInstance (tip);
                                Object[] nd = new Object [0];
                                int n = (int) mi.Invoke (ns, nd);
                            }
                        }
                    }
                }
            }catch (Exception hata) {Console.WriteLine ("HATA: {0}", hata.Message);}

            Console.WriteLine ("\nSýnýf3 vasýf ve deðerlerinin 2 farklý yöntemle dökümü:");
            Console.WriteLine ("\tSýnýf3 vasýflarý:");
            object[] s3Vasýflar = Attribute.GetCustomAttributes (typeof (Sýnýf3));
            foreach (object vs in s3Vasýflar) Console.WriteLine ("Vasýf adý: {0}", vs);
            Console.WriteLine ("\tSýnýf3 vasýf ve deðerleri:");
            Type tip3 = typeof (Sýnýf3);
            foreach (DizgeVasfý dv in tip3.GetCustomAttributes (typeof (DizgeVasfý), false))  Console.WriteLine ("Vasýf ve deðer adý: {0}({1})", dv, dv.Deðer());
            //Type tip3 = typeof (Sýnýf3);
            foreach (DoðruYanlýþVasfý dyv in tip3.GetCustomAttributes (typeof (DoðruYanlýþVasfý), false))  Console.WriteLine ("Vasýf ve deðer adý: {0} (\"{1}\")", dyv, dyv.Deðer());

            Console.WriteLine ("\nConditional #define ile ifþasý þartlý metotlar:");
            Vasýf3 þm = new Vasýf3();
            þm.deneme(); // Ancak "#define DENEME" tanýmlýysa çaðrýlabilir
            þm.sürüm(); // Ancak "#define SÜRÜMLü" tanýmlýysa çaðrýlabilir
            þm.kopya(); // Ancak "#define GÝZLÝ" tanýmlýysa çaðrýlabilir
            new HataAyýkla().DebugTanýmlýysaYürüt();

            Console.WriteLine ("\nObsolete/tedavülsüz arþiv vasfýnda yalýn, mesajlý, false/true durumlarý:");
            var r=new Random(); int i; double ds1, ds2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,1000)+r.Next(10,100)/100D; ds2=r.Next(-100,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("EskiMetot: {0} / {1} = {2}", ds1, ds2, eskiMetot (ds1, ds2)); //Mesajlý derleme ikazý
                //Console.WriteLine ("EskiMetot2: {0} / {1} = {2}", ds1, ds2, eskiMetot2 (ds1, ds2)); //Mesajslý derleme hatasý
                //Console.WriteLine ("EskiMetot3: {0} / {1} = {2}", ds1, ds2, eskiMetot3 (ds1, ds2)); //Mesajsýz derleme ikazý
                Console.WriteLine ("YeniiMetot:  {0} / {1} = {2}", ds1, ds2, yeniMetot (ds1, ds2));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}