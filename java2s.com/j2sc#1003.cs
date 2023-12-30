// j2sc#1005.cs: Reflection/Assembly, conditional/�artl� ve obsolete/tedav�ls�z vas�flar �rne�i.

#define DENEME
#define S�R�ML�
//#define G�ZL�
#define debug
using System;
using System.Reflection; //Assembly i�in
using System.Diagnostics; //Conditional i�in
namespace Vas�flar {
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class KodG�zlemVasf�: Attribute {
        string g�zlemci, tarih, yorum;
        public KodG�zlemVasf� (string g, string t) {g�zlemci = g; tarih = t; yorum="Yok";} //Kurucu
        public string Yorum {get {return(yorum);} set {yorum = value;}} //�zellik
        public string Tarih {get {return(tarih);}}
        public string G�zlemci {get {return(g�zlemci);}}
    }
    [KodG�zlemVasf� ("M.Nihat Yava�", "01-12-2022", Yorum="Yorum haricen girilecek")]
    [KodG�zlemVasf� ("M.Nedim Yava�", "01-08-2023", Yorum="Kurucuyla girilen tarih i�in set gerekmez")]
    [KodG�zlemVasf� ("Memet Yava�", "01-012-2023", Yorum="Kurucuyla girilen g�zlemci i�in set gerekmez")]
    class S�n�f1{}
    [AttributeUsage (AttributeTargets.Class)]
    public class S�n�fHedef : Attribute {public S�n�fHedef(){}}
    [AttributeUsage (AttributeTargets.Method)]
    public class MetodHedef : Attribute {public MetodHedef(){}}
    public class S�n�f2 {
        [MetodHedef]
        public int Metot() {return 20231216;}
    }
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class Do�ruYanl��Vasf� : Attribute {
        bool ikili;
        public bool De�er() {return ikili;}
        public Do�ruYanl��Vasf� (bool b) {ikili = b;} //Kurucu
    }
    [AttributeUsage (AttributeTargets.Class, AllowMultiple=true)]
    public class DizgeVasf� : Attribute {
        string dizge;
        public string De�er() {return dizge;}
        public DizgeVasf� (string d) {dizge = d;} //Kurucu
    }
    [Do�ruYanl��Vasf� (true)]
    [Do�ruYanl��Vasf� (false)]
    [Do�ruYanl��Vasf� (true)]
    [DizgeVasf� ("Kodlama-1")]
    [DizgeVasf� ("Kodlama-2")]
    [DizgeVasf� ("Kodlama-3")]
    public class S�n�f3{}
    public class HataAy�kla {
        [Conditional ("debug")]
        public void DebugTan�ml�ysaY�r�t() {Console.WriteLine ("Kodlama ba��nda '#define debug' tan�mlanm��t�r");}
    }
    class Vas�f3 {
        [Conditional("DENEME")]  
        void deneme() {Console.WriteLine ("Sadece deneme ama�l� olup da��t�m� yap�lamaz.");} 
        [Conditional ("S�R�ML�")]  
        void s�r�m() {Console.WriteLine ("Nihai piyasa s�r�m uyarlamas�d�r, da��t�m� serbesttir.");}
        [Conditional ("G�ZL�")]  
        void kopya() {Console.WriteLine ("�cretsiz gizli kopya da��t�m� yasakt�r.");}
        [Obsolete ("Bunun yerine yeniMetot()'u kullan�n.")]
        static double eskiMetot (double a, double b) {return 0D;}
        [Obsolete ("Bunun yerine yeniMetot()'u kullan�n.", true)]
        static double eskiMetot2 (double a, double b) {return 0D;}
        [Obsolete]
        static double eskiMetot3 (double a, double b) {return 0D;}
        static double yeniMetot (double a, double b) {if (b != 0) return a/b; return 0;} 
        static void Main() {
            Console.Write ("�oklu de�erler konumsal parametre artan de�eriyle s�ralanarak d�k�mlenir.\n�artl�/Conditional metot #if benzeri #define'la tan�mlan�r, void'dur, aray�z de�il s�n�ftad�r ve esge�mez.\nTedav�ls�z/Obsolete (false) metot derlemede tan�ml� ikaz�, (true) ise derleme hatas� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f1 ile KodG�zlemVasf� aras�ndaki kodlanm�� vas�f de�erlerinin d�k�m�:");
            Type tip1 = typeof (S�n�f1);
            foreach (KodG�zlemVasf� kgv in tip1.GetCustomAttributes (typeof (KodG�zlemVasf�), false)) {
                Console.WriteLine ("\tG�zlemci: {0}", kgv.G�zlemci);
                Console.WriteLine ("Tarih: {0}", kgv.Tarih);
                Console.WriteLine ("Yorum: {0}", kgv.Yorum);
            }

            Console.WriteLine ("\nReflection.Assembly ile �oklu AttributeUsage yap�s� i�leme:");
            S�n�fHedef sh;
            MetodHedef mh;
            try {
                Assembly ass = Assembly.LoadFrom ("S�n�f2");
                foreach (Type tip in ass.GetTypes()) {
                    sh = (S�n�fHedef) Attribute.GetCustomAttribute (tip, typeof (S�n�fHedef));
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

            Console.WriteLine ("\nS�n�f3 vas�f ve de�erlerinin 2 farkl� y�ntemle d�k�m�:");
            Console.WriteLine ("\tS�n�f3 vas�flar�:");
            object[] s3Vas�flar = Attribute.GetCustomAttributes (typeof (S�n�f3));
            foreach (object vs in s3Vas�flar) Console.WriteLine ("Vas�f ad�: {0}", vs);
            Console.WriteLine ("\tS�n�f3 vas�f ve de�erleri:");
            Type tip3 = typeof (S�n�f3);
            foreach (DizgeVasf� dv in tip3.GetCustomAttributes (typeof (DizgeVasf�), false))  Console.WriteLine ("Vas�f ve de�er ad�: {0}({1})", dv, dv.De�er());
            //Type tip3 = typeof (S�n�f3);
            foreach (Do�ruYanl��Vasf� dyv in tip3.GetCustomAttributes (typeof (Do�ruYanl��Vasf�), false))  Console.WriteLine ("Vas�f ve de�er ad�: {0} (\"{1}\")", dyv, dyv.De�er());

            Console.WriteLine ("\nConditional #define ile if�as� �artl� metotlar:");
            Vas�f3 �m = new Vas�f3();
            �m.deneme(); // Ancak "#define DENEME" tan�ml�ysa �a�r�labilir
            �m.s�r�m(); // Ancak "#define S�R�ML�" tan�ml�ysa �a�r�labilir
            �m.kopya(); // Ancak "#define G�ZL�" tan�ml�ysa �a�r�labilir
            new HataAy�kla().DebugTan�ml�ysaY�r�t();

            Console.WriteLine ("\nObsolete/tedav�ls�z ar�iv vasf�nda yal�n, mesajl�, false/true durumlar�:");
            var r=new Random(); int i; double ds1, ds2;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,1000)+r.Next(10,100)/100D; ds2=r.Next(-100,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("EskiMetot: {0} / {1} = {2}", ds1, ds2, eskiMetot (ds1, ds2)); //Mesajl� derleme ikaz�
                //Console.WriteLine ("EskiMetot2: {0} / {1} = {2}", ds1, ds2, eskiMetot2 (ds1, ds2)); //Mesajsl� derleme hatas�
                //Console.WriteLine ("EskiMetot3: {0} / {1} = {2}", ds1, ds2, eskiMetot3 (ds1, ds2)); //Mesajs�z derleme ikaz�
                Console.WriteLine ("YeniiMetot:  {0} / {1} = {2}", ds1, ds2, yeniMetot (ds1, ds2));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}