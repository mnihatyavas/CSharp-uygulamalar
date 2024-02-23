// j2sc#1202.cs: Assembly kurgusuyla mevcut tipleme ve metotlar�n i�letilmesi �rne�i.

using System;
using System.Reflection; //Assembly i�in
using System.Globalization; //CultureInfo i�in
using System.IO; //FileNotFoundException i�in
using System.Collections.Generic; //Dictionary<T> i�in
namespace Kurulum {
    class S�n�f1 {
        int x, y; //Alanlar
        public S�n�f1(){}
        public S�n�f1 (int a) {//Kurucu-1
            Console.WriteLine ("\tS�n�f1 (int) kuruluyor.");
            x = y = a;
            g�ster();
        }
        public S�n�f1 (int a, int b) {//Kurucu-1
            Console.Write ("\tS�n�f1(int,int) kuruluyor: ");
            x = a;
            y = b;
            g�ster();
        }
        public int topla() {return x+y;}
        public bool aradaM� (int a) {if ((x < a) && (a < y)) return true; else return false;} 
        public void koy (int a, int b) {
            Console.Write ("koy(int,int) i�inde: ");
            x = a;
            y = b;
            g�ster();
        }
        public void koy2 (double a, double b) {//overload a��r�y�kleme
            Console.Write ("koy(double,double) i�inde: ");
            x = (int) a;
            y = (int) b;
            g�ster();
        }
        public void g�ster() {Console.WriteLine ("De�erler (x, y) = ({0}, {1})", x, y);}
    }
    class S�n�f2 {
        string s�ylem;
        public S�n�f2 (string dzg) {s�ylem = dzg;} //Kurucu
        public void g�ster() {Console.WriteLine ("S�ylenen: " + s�ylem.ToUpper());}
    }
    enum G�nler {Pazartesi, Sal�, �ar�amba}
    struct Yap�{}
    public class KurguY�kleyici {
        private Assembly Y�klenenKurgu;
        public KurguY�kleyici (string ad, bool k�smiMi) {//Kurucu
            Console.WriteLine ("\t"+ad);
            if (k�smiMi) Y�klenenKurgu = Assembly.LoadWithPartialName (ad);
            else Y�klenenKurgu = Assembly.Load (ad);
            Console.WriteLine ("Tam ad�: {0}", Y�klenenKurgu.FullName);
            Console.WriteLine ("Konumu: {0}", Y�klenenKurgu.Location);
            Console.WriteLine ("Kod temeli: {0}", Y�klenenKurgu.CodeBase);
            Console.WriteLine ("ESC kod temeli: {0}", Y�klenenKurgu.EscapedCodeBase);
            Console.WriteLine ("GAC'tan m� y�klendi? {0}", Y�klenenKurgu.GlobalAssemblyCache);
        }
    }
    public class Y�r�t�c� {public static void Y�r�t() {Console.WriteLine ("\tUygSahas� ve ge�erli kurgu bulundu...\nProgram y�r�mekte...");}}
    class Kurgu2 {
        static Dictionary<string, Assembly> kitapl�klar = new Dictionary<string, Assembly>();
        static Assembly KurguyuBul (object g�nderen, ResolveEventArgs olayArg�manlar�) {
            string k�saAd = new AssemblyName (olayArg�manlar�.Name).Name;
            if (kitapl�klar.ContainsKey (k�saAd)) return kitapl�klar [k�saAd];
            using (Stream ak�� = Assembly.GetExecutingAssembly().GetManifestResourceStream ("Kitapl�k." + k�saAd + ".dll")) {
                byte[] veri = new BinaryReader (ak��).ReadBytes ((int)ak��.Length);
                Assembly kurgu = Assembly.Load (veri);
                kitapl�klar [k�saAd] = kurgu;
                return kurgu;
            }
        }
        static void Main (string[] arg) {
            Console.Write ("Assembly kurgusu Assembly.Load, GetType, Activator.CreateInstance, MethodInfo, prmDizi ve metot.Invoke ad�mlar�yla kurulur ve y�r�t�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");
            
            Console.WriteLine ("�al��an bir programdaki t�m kurgular�n tespiti:");
            Assembly kurgu = Assembly.Load ("j2sc#1202");
            Console.WriteLine ("Assembly.Load: {0}", kurgu.FullName);
            int i, ts1, ts2; var r=new Random();
            S�n�f1 s1; S�n�f2 s2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); s1=new S�n�f1 (ts1,ts2); Console.WriteLine ("Toplam: {0}", s1.topla()); Console.WriteLine ("50 arada m�?: {0}", s1.aradaM�(50));
                ts1=r.Next(-100,100); s1.koy2 (ts1+0.125D, ts2-0.125D); Console.WriteLine ("Toplam: " + s1.topla()); Console.WriteLine ("50 arada m�?: " + s1.aradaM�(50));
            }
            s2=new S�n�f2 ("Bu bir s�ylemdir."); s2.g�ster();
            Console.WriteLine ("\tj2sc#1202.exe'de bulunan kurgular:");
            Assembly kurgu1 = Assembly.LoadFrom ("j2sc#1202.exe"); 
            Type[] t�mTipler = kurgu1.GetTypes(); 
            foreach (Type tip in t�mTipler) Console.WriteLine ("Bulunan: " + tip.Name);

            Console.WriteLine ("\nBir Assembly kurgusunun t�m ��elerinin atanmas�:");
            AssemblyName krgAd� = new AssemblyName();
            krgAd�.Name = "System.Xml";
            krgAd�.Version = new Version (1, 0, 0, 0); // Bulaca�� son s�r�m: 4
            krgAd�.CultureInfo = new CultureInfo (""); // N�tr k�lt�r
            krgAd�.SetPublicKeyToken (new byte[] {0xb7, 0x7a, 0x5c, 0x56, 0x19, 0x34, 0xe0, 0x89});
            Assembly kurgu2 = Assembly.Load (krgAd�);
            Console.WriteLine ("System.Xml adl� kurgu: [{0}]", kurgu2);

            Console.WriteLine ("\n'S�n�f1.koy(int a, int b) ve topla()'n�n Assembly ile kurulmas� ve y�r�t�lmesi:");
            Assembly kurgu3 = null;
            try {kurgu3 = Assembly.Load ("j2sc#1202");
            }catch (FileNotFoundException ht) {Console.WriteLine ("HATA: " + ht.Message);}
            Type s�n�fTipi = kurgu3.GetType ("Kurulum.S�n�f1");
            object nesne = Activator.CreateInstance (s�n�fTipi);
            object[] prmDizi = new object [2];    
            prmDizi [0] = 1881;
            prmDizi [1] = 57;
            MethodInfo metot = s�n�fTipi.GetMethod ("koy");
            metot.Invoke (nesne, prmDizi);
            metot = s�n�fTipi.GetMethod ("topla");
            Console.WriteLine ("Toplam = " + metot.Invoke (nesne, null));
            prmDizi [0] = 1938;
            prmDizi [1] = -57;
            metot = s�n�fTipi.GetMethod ("koy");
            metot.Invoke (nesne, prmDizi);
            metot = s�n�fTipi.GetMethod ("topla");
            Console.WriteLine ("Toplam = " + metot.Invoke (nesne, null));

            Console.WriteLine ("\n�e�itli kurulum tiplerinin birbirleriyle e�itlik testi:");
            int x=20240223;
            Assembly kurgu4 = Assembly.Load ("mscorlib");
            Type tip1 = kurgu4.GetType ("System.Int32");
            Type tip2 = typeof (int);
            Type tip3 = x.GetType();
            Type tip4 = Type.GetType ("System.Int32");
            Type tip5 = typeof (short);
            Type tip6 = typeof (string);
            Console.WriteLine ("tip1({0}) == tip2({1})? {2}", tip1, tip2, tip1==tip2);
            Console.WriteLine ("tip2 == tip3({0})? {1}", tip3, tip2==tip3);
            Console.WriteLine ("tip3 == tip4({0})? {1}", tip4, tip3==tip4);
            Console.WriteLine ("tip4 == tip5({0})? {1}", tip5, tip4==tip5);
            Console.WriteLine ("tip5 == tip6({0})? {1}", tip6, tip5==tip6);

            Console.WriteLine ("\nArg�man olarak girilen 'j2sc#1202.exe'nin i�erdi�i t�m tiplerin detaylar�:");
            if (arg.Length==0) goto atla;
            Assembly kurgu5 = Assembly.LoadFrom (arg [0]); //G�nler, S�n�f, Yap�...
            Type[] tipler = kurgu5.GetTypes();
            foreach (Type tip in tipler) {
                Console.WriteLine ("\tTipAd�/Name: {0}", tip.FullName);
                Console.WriteLine ("Aduzam/Namespace: {0}", tip.Namespace);
                Console.WriteLine ("TemelS�n�f/Base Class: {0}", tip.BaseType.FullName);
            } //"c#>j2sc#1202 j2sc#1202.exe" olarak �al��t�r

      atla: Console.WriteLine ("\nSystem.Xml'n Assembly ile farkl� parametreli y�kleni�inin detaylar�:");
            KurguY�kleyici Y�kleyici;
            Y�kleyici = new KurguY�kleyici ("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false);
            Y�kleyici = new KurguY�kleyici ("System.Xml", true);
            try {Y�kleyici = new KurguY�kleyici ("System.Xml", false);}catch (Exception ht) {Console.WriteLine ("==>HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nProgramdaki akt�el UygSahas� ve t�m kurgular� bulma:");
            AppDomain.CurrentDomain.AssemblyResolve += KurguyuBul; //��letilmiyor
            Console.WriteLine ("Akt�el UygSahas�: " + AppDomain.CurrentDomain.FriendlyName);
            Assembly[] t�mKurgular = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine ("\tMevcut t�m kurgular:");
            foreach (Assembly krg in t�mKurgular) Console.WriteLine (krg.GetName());
            Y�r�t�c�.Y�r�t();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}