// j2sc#1901b.cs: Assembly.GetCustomAttributes()'le mevcut kurgu vas�flar� �rne�i.

using System;
using System.Reflection; //Assembly i�in
[assembly: AssemblyDescription ("Bir num�ne tasvir")] //assembly, namespace �st�nde bulunmal�
namespace TipBilgileri {
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class HataAy�klamaVasf�: System.Attribute {
        public HataAy�klamaVasf� (int hataNo, string programc�, string tarih) {HataNo = hataNo; Programc� = programc�; Tarih = tarih;} //Kurucu
        public int HataNo;
        public string Tarih;
        public string Programc�;
        public string Yorum {get; set;}
    }
    [HataAy�klamaVasf� (1, "Nihat", "24/08/01", Yorum = "1 no'lu set-value hatas� d�zeltildi")]
    [HataAy�klamaVasf� (2, "Mahmut", "24/08/02", Yorum = "2 no'lu Tarih hatas� d�zeltildi")]
    [HataAy�klamaVasf� (3, "Yava�", "24/08/03", Yorum = "3 no'lu Y�zde133 hatas� d�zeltildi")]
    public class Y�zde133 {
        public double Fonk1 (double prm1) {return prm1 + Fonk2 (prm1);}
        public double Fonk2 (double prm1) {return prm1 / 3;}
    }
    [AttributeUsage (AttributeTargets.Parameter)]
    public class ArgumentUsageAttribute: Attribute {
        protected string mesaj;
        public ArgumentUsageAttribute (string m) {mesaj = m;} //Kurucu
        public override string ToString() {return base.ToString( ) + ":" + mesaj;}
    }
    [AttributeUsage (AttributeTargets.Parameter)]
    public class ArgumentIDAttribute: Attribute {
        protected Guid gd;
        public ArgumentIDAttribute() {gd = Guid.NewGuid();} //Kurucu
        public override string ToString() {return base.ToString() + "." + gd.ToString();}
    }
    public class S�n�fA {
        public void S�n�fAMetot (
            [ArgumentID] [ArgumentUsage ("ilk mesaj")] String[] strDizi,
            [ArgumentID] [ArgumentUsage ("ikinci mesaj")] params String[] strListe) {}
    }
    class Vas�f {
        static void Main() {
            Console.Write ("'foreach(object ns in (Assembly.LoadFrom(kurulumAd�)).GetCustomAttributes(true))' ile ge�erli kurulumun mevcut vas�flar� sunulur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ge�ersiz ve iki vas�fl� ge�erli kurulum:");
            string kurulumAd� = "Nihat";
            object[] vas�flar;
            Assembly kurgu;
            try {kurgu = Assembly.LoadFrom (kurulumAd�);
                vas�flar = kurgu.GetCustomAttributes (true);
                if (vas�flar.Length > 0) {Console.WriteLine ("'{0}' i�in Assembly vas�flar�:", kurulumAd�);
                    foreach (object ns in vas�flar) Console.WriteLine ("\t{0}", ns.ToString());
                }else Console.WriteLine ("Assembly '{0}'nun hi� vasf� yok.", kurulumAd�);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            kurulumAd� = "j2sc#1901b.exe";
            try {kurgu = Assembly.LoadFrom (kurulumAd�);
                vas�flar = kurgu.GetCustomAttributes (true);
                if (vas�flar.Length > 0) {Console.WriteLine ("'{0}' i�in Assembly vas�flar�:", kurulumAd�);
                    foreach (object ns in vas�flar) Console.WriteLine ("\t{0}", ns.ToString());
                }else Console.WriteLine ("Assembly '{0}'nun hi� vasf� yok.", kurulumAd�);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nY�zde133 s�n�f �n�ndeki ��l� HataAy�klamaVasf� de�erlerini sunma:");
            //Y�zde133 y133 = new Y�zde133();
            System.Reflection.MemberInfo mi = typeof (Y�zde133);
            vas�flar = mi.GetCustomAttributes (typeof (HataAy�klamaVasf�), false);
            foreach (Object vsf in vas�flar) {
                HataAy�klamaVasf� hav = (HataAy�klamaVasf�)vsf;
                Console.WriteLine ("HataNo: {0}", hav.HataNo);
                Console.WriteLine ("Programc�: {0}", hav.Programc�);
                Console.WriteLine ("Tarih: {0}", hav.Tarih);
                Console.WriteLine ("Yorum: {0}", hav.Yorum);
            }

            Console.WriteLine ("\nS�n�fA'n�n verili ArgumentUsage(mesaj)'lar�n�n i�erik ve k�yaslar�:");
            Type tip = typeof (S�n�fA);
            MethodInfo mt = tip.GetMethod ("S�n�fAMetot");
            ParameterInfo[] piDizi = mt.GetParameters();
            if (piDizi != null) {
                ArgumentUsageAttribute akv1 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [0], typeof (ArgumentUsageAttribute));
                ArgumentUsageAttribute akv2 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [0], typeof(ArgumentUsageAttribute));
                ArgumentUsageAttribute akv3 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [1], typeof(ArgumentUsageAttribute));
                Console.WriteLine ("\t\"{0}\" == \n\"{1}\" ? {2}", akv1.ToString(), akv2.ToString(), akv1.Equals (akv2));
                Console.WriteLine ("\t\"{0}\" == \n\"{1}\" ? {2}", akv1.ToString(), akv3.ToString(), akv1.Equals (akv3));
            }

            Console.WriteLine ("\n[assembly:AssemblyDescription(\"a��klama\")] kurgu ad� ve a��klamas�n�n sunumu:");
            tip = typeof (Vas�f);
            kurgu = tip.Assembly;
            kurulumAd� = kurgu.GetName().Name;
            bool tan�ml�M� = Attribute.IsDefined (kurgu, typeof (AssemblyDescriptionAttribute));
            if (tan�ml�M�) {
                Console.WriteLine ("Mevcut kurgu ad�: {0}", kurulumAd�);
                AssemblyDescriptionAttribute ada = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute (kurgu, typeof (AssemblyDescriptionAttribute));
                if (ada != null) Console.WriteLine ("AssemblyDescription mesaj�: \"{0}\".", ada.Description);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}