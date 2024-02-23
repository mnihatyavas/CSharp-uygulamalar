// j2sc#1202.cs: Assembly kurgusuyla mevcut tipleme ve metotlarýn iþletilmesi örneði.

using System;
using System.Reflection; //Assembly için
using System.Globalization; //CultureInfo için
using System.IO; //FileNotFoundException için
using System.Collections.Generic; //Dictionary<T> için
namespace Kurulum {
    class Sýnýf1 {
        int x, y; //Alanlar
        public Sýnýf1(){}
        public Sýnýf1 (int a) {//Kurucu-1
            Console.WriteLine ("\tSýnýf1 (int) kuruluyor.");
            x = y = a;
            göster();
        }
        public Sýnýf1 (int a, int b) {//Kurucu-1
            Console.Write ("\tSýnýf1(int,int) kuruluyor: ");
            x = a;
            y = b;
            göster();
        }
        public int topla() {return x+y;}
        public bool aradaMý (int a) {if ((x < a) && (a < y)) return true; else return false;} 
        public void koy (int a, int b) {
            Console.Write ("koy(int,int) içinde: ");
            x = a;
            y = b;
            göster();
        }
        public void koy2 (double a, double b) {//overload aþýrýyükleme
            Console.Write ("koy(double,double) içinde: ");
            x = (int) a;
            y = (int) b;
            göster();
        }
        public void göster() {Console.WriteLine ("Deðerler (x, y) = ({0}, {1})", x, y);}
    }
    class Sýnýf2 {
        string söylem;
        public Sýnýf2 (string dzg) {söylem = dzg;} //Kurucu
        public void göster() {Console.WriteLine ("Söylenen: " + söylem.ToUpper());}
    }
    enum Günler {Pazartesi, Salý, Çarþamba}
    struct Yapý{}
    public class KurguYükleyici {
        private Assembly YüklenenKurgu;
        public KurguYükleyici (string ad, bool kýsmiMi) {//Kurucu
            Console.WriteLine ("\t"+ad);
            if (kýsmiMi) YüklenenKurgu = Assembly.LoadWithPartialName (ad);
            else YüklenenKurgu = Assembly.Load (ad);
            Console.WriteLine ("Tam adý: {0}", YüklenenKurgu.FullName);
            Console.WriteLine ("Konumu: {0}", YüklenenKurgu.Location);
            Console.WriteLine ("Kod temeli: {0}", YüklenenKurgu.CodeBase);
            Console.WriteLine ("ESC kod temeli: {0}", YüklenenKurgu.EscapedCodeBase);
            Console.WriteLine ("GAC'tan mý yüklendi? {0}", YüklenenKurgu.GlobalAssemblyCache);
        }
    }
    public class Yürütücü {public static void Yürüt() {Console.WriteLine ("\tUygSahasý ve geçerli kurgu bulundu...\nProgram yürümekte...");}}
    class Kurgu2 {
        static Dictionary<string, Assembly> kitaplýklar = new Dictionary<string, Assembly>();
        static Assembly KurguyuBul (object gönderen, ResolveEventArgs olayArgümanlarý) {
            string kýsaAd = new AssemblyName (olayArgümanlarý.Name).Name;
            if (kitaplýklar.ContainsKey (kýsaAd)) return kitaplýklar [kýsaAd];
            using (Stream akýþ = Assembly.GetExecutingAssembly().GetManifestResourceStream ("Kitaplýk." + kýsaAd + ".dll")) {
                byte[] veri = new BinaryReader (akýþ).ReadBytes ((int)akýþ.Length);
                Assembly kurgu = Assembly.Load (veri);
                kitaplýklar [kýsaAd] = kurgu;
                return kurgu;
            }
        }
        static void Main (string[] arg) {
            Console.Write ("Assembly kurgusu Assembly.Load, GetType, Activator.CreateInstance, MethodInfo, prmDizi ve metot.Invoke adýmlarýyla kurulur ve yürütülür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");
            
            Console.WriteLine ("Çalýþan bir programdaki tüm kurgularýn tespiti:");
            Assembly kurgu = Assembly.Load ("j2sc#1202");
            Console.WriteLine ("Assembly.Load: {0}", kurgu.FullName);
            int i, ts1, ts2; var r=new Random();
            Sýnýf1 s1; Sýnýf2 s2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); s1=new Sýnýf1 (ts1,ts2); Console.WriteLine ("Toplam: {0}", s1.topla()); Console.WriteLine ("50 arada mý?: {0}", s1.aradaMý(50));
                ts1=r.Next(-100,100); s1.koy2 (ts1+0.125D, ts2-0.125D); Console.WriteLine ("Toplam: " + s1.topla()); Console.WriteLine ("50 arada mý?: " + s1.aradaMý(50));
            }
            s2=new Sýnýf2 ("Bu bir söylemdir."); s2.göster();
            Console.WriteLine ("\tj2sc#1202.exe'de bulunan kurgular:");
            Assembly kurgu1 = Assembly.LoadFrom ("j2sc#1202.exe"); 
            Type[] tümTipler = kurgu1.GetTypes(); 
            foreach (Type tip in tümTipler) Console.WriteLine ("Bulunan: " + tip.Name);

            Console.WriteLine ("\nBir Assembly kurgusunun tüm öðelerinin atanmasý:");
            AssemblyName krgAdý = new AssemblyName();
            krgAdý.Name = "System.Xml";
            krgAdý.Version = new Version (1, 0, 0, 0); // Bulacaðý son sürüm: 4
            krgAdý.CultureInfo = new CultureInfo (""); // Nötr kültür
            krgAdý.SetPublicKeyToken (new byte[] {0xb7, 0x7a, 0x5c, 0x56, 0x19, 0x34, 0xe0, 0x89});
            Assembly kurgu2 = Assembly.Load (krgAdý);
            Console.WriteLine ("System.Xml adlý kurgu: [{0}]", kurgu2);

            Console.WriteLine ("\n'Sýnýf1.koy(int a, int b) ve topla()'nýn Assembly ile kurulmasý ve yürütülmesi:");
            Assembly kurgu3 = null;
            try {kurgu3 = Assembly.Load ("j2sc#1202");
            }catch (FileNotFoundException ht) {Console.WriteLine ("HATA: " + ht.Message);}
            Type sýnýfTipi = kurgu3.GetType ("Kurulum.Sýnýf1");
            object nesne = Activator.CreateInstance (sýnýfTipi);
            object[] prmDizi = new object [2];    
            prmDizi [0] = 1881;
            prmDizi [1] = 57;
            MethodInfo metot = sýnýfTipi.GetMethod ("koy");
            metot.Invoke (nesne, prmDizi);
            metot = sýnýfTipi.GetMethod ("topla");
            Console.WriteLine ("Toplam = " + metot.Invoke (nesne, null));
            prmDizi [0] = 1938;
            prmDizi [1] = -57;
            metot = sýnýfTipi.GetMethod ("koy");
            metot.Invoke (nesne, prmDizi);
            metot = sýnýfTipi.GetMethod ("topla");
            Console.WriteLine ("Toplam = " + metot.Invoke (nesne, null));

            Console.WriteLine ("\nÇeþitli kurulum tiplerinin birbirleriyle eþitlik testi:");
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

            Console.WriteLine ("\nArgüman olarak girilen 'j2sc#1202.exe'nin içerdiði tüm tiplerin detaylarý:");
            if (arg.Length==0) goto atla;
            Assembly kurgu5 = Assembly.LoadFrom (arg [0]); //Günler, Sýnýf, Yapý...
            Type[] tipler = kurgu5.GetTypes();
            foreach (Type tip in tipler) {
                Console.WriteLine ("\tTipAdý/Name: {0}", tip.FullName);
                Console.WriteLine ("Aduzam/Namespace: {0}", tip.Namespace);
                Console.WriteLine ("TemelSýnýf/Base Class: {0}", tip.BaseType.FullName);
            } //"c#>j2sc#1202 j2sc#1202.exe" olarak çalýþtýr

      atla: Console.WriteLine ("\nSystem.Xml'n Assembly ile farklý parametreli yükleniþinin detaylarý:");
            KurguYükleyici Yükleyici;
            Yükleyici = new KurguYükleyici ("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", false);
            Yükleyici = new KurguYükleyici ("System.Xml", true);
            try {Yükleyici = new KurguYükleyici ("System.Xml", false);}catch (Exception ht) {Console.WriteLine ("==>HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nProgramdaki aktüel UygSahasý ve tüm kurgularý bulma:");
            AppDomain.CurrentDomain.AssemblyResolve += KurguyuBul; //Ýþletilmiyor
            Console.WriteLine ("Aktüel UygSahasý: " + AppDomain.CurrentDomain.FriendlyName);
            Assembly[] tümKurgular = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine ("\tMevcut tüm kurgular:");
            foreach (Assembly krg in tümKurgular) Console.WriteLine (krg.GetName());
            Yürütücü.Yürüt();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}