// j2sc#1901b.cs: Assembly.GetCustomAttributes()'le mevcut kurgu vasýflarý örneði.

using System;
using System.Reflection; //Assembly için
[assembly: AssemblyDescription ("Bir numüne tasvir")] //assembly, namespace üstünde bulunmalý
namespace TipBilgileri {
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class HataAyýklamaVasfý: System.Attribute {
        public HataAyýklamaVasfý (int hataNo, string programcý, string tarih) {HataNo = hataNo; Programcý = programcý; Tarih = tarih;} //Kurucu
        public int HataNo;
        public string Tarih;
        public string Programcý;
        public string Yorum {get; set;}
    }
    [HataAyýklamaVasfý (1, "Nihat", "24/08/01", Yorum = "1 no'lu set-value hatasý düzeltildi")]
    [HataAyýklamaVasfý (2, "Mahmut", "24/08/02", Yorum = "2 no'lu Tarih hatasý düzeltildi")]
    [HataAyýklamaVasfý (3, "Yavaþ", "24/08/03", Yorum = "3 no'lu Yüzde133 hatasý düzeltildi")]
    public class Yüzde133 {
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
    public class SýnýfA {
        public void SýnýfAMetot (
            [ArgumentID] [ArgumentUsage ("ilk mesaj")] String[] strDizi,
            [ArgumentID] [ArgumentUsage ("ikinci mesaj")] params String[] strListe) {}
    }
    class Vasýf {
        static void Main() {
            Console.Write ("'foreach(object ns in (Assembly.LoadFrom(kurulumAdý)).GetCustomAttributes(true))' ile geçerli kurulumun mevcut vasýflarý sunulur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Geçersiz ve iki vasýflý geçerli kurulum:");
            string kurulumAdý = "Nihat";
            object[] vasýflar;
            Assembly kurgu;
            try {kurgu = Assembly.LoadFrom (kurulumAdý);
                vasýflar = kurgu.GetCustomAttributes (true);
                if (vasýflar.Length > 0) {Console.WriteLine ("'{0}' için Assembly vasýflarý:", kurulumAdý);
                    foreach (object ns in vasýflar) Console.WriteLine ("\t{0}", ns.ToString());
                }else Console.WriteLine ("Assembly '{0}'nun hiç vasfý yok.", kurulumAdý);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            kurulumAdý = "j2sc#1901b.exe";
            try {kurgu = Assembly.LoadFrom (kurulumAdý);
                vasýflar = kurgu.GetCustomAttributes (true);
                if (vasýflar.Length > 0) {Console.WriteLine ("'{0}' için Assembly vasýflarý:", kurulumAdý);
                    foreach (object ns in vasýflar) Console.WriteLine ("\t{0}", ns.ToString());
                }else Console.WriteLine ("Assembly '{0}'nun hiç vasfý yok.", kurulumAdý);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.WriteLine ("\nYüzde133 sýnýf önündeki üçlü HataAyýklamaVasfý deðerlerini sunma:");
            //Yüzde133 y133 = new Yüzde133();
            System.Reflection.MemberInfo mi = typeof (Yüzde133);
            vasýflar = mi.GetCustomAttributes (typeof (HataAyýklamaVasfý), false);
            foreach (Object vsf in vasýflar) {
                HataAyýklamaVasfý hav = (HataAyýklamaVasfý)vsf;
                Console.WriteLine ("HataNo: {0}", hav.HataNo);
                Console.WriteLine ("Programcý: {0}", hav.Programcý);
                Console.WriteLine ("Tarih: {0}", hav.Tarih);
                Console.WriteLine ("Yorum: {0}", hav.Yorum);
            }

            Console.WriteLine ("\nSýnýfA'nýn verili ArgumentUsage(mesaj)'larýnýn içerik ve kýyaslarý:");
            Type tip = typeof (SýnýfA);
            MethodInfo mt = tip.GetMethod ("SýnýfAMetot");
            ParameterInfo[] piDizi = mt.GetParameters();
            if (piDizi != null) {
                ArgumentUsageAttribute akv1 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [0], typeof (ArgumentUsageAttribute));
                ArgumentUsageAttribute akv2 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [0], typeof(ArgumentUsageAttribute));
                ArgumentUsageAttribute akv3 = (ArgumentUsageAttribute)Attribute.GetCustomAttribute (piDizi [1], typeof(ArgumentUsageAttribute));
                Console.WriteLine ("\t\"{0}\" == \n\"{1}\" ? {2}", akv1.ToString(), akv2.ToString(), akv1.Equals (akv2));
                Console.WriteLine ("\t\"{0}\" == \n\"{1}\" ? {2}", akv1.ToString(), akv3.ToString(), akv1.Equals (akv3));
            }

            Console.WriteLine ("\n[assembly:AssemblyDescription(\"açýklama\")] kurgu adý ve açýklamasýnýn sunumu:");
            tip = typeof (Vasýf);
            kurgu = tip.Assembly;
            kurulumAdý = kurgu.GetName().Name;
            bool tanýmlýMý = Attribute.IsDefined (kurgu, typeof (AssemblyDescriptionAttribute));
            if (tanýmlýMý) {
                Console.WriteLine ("Mevcut kurgu adý: {0}", kurulumAdý);
                AssemblyDescriptionAttribute ada = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute (kurgu, typeof (AssemblyDescriptionAttribute));
                if (ada != null) Console.WriteLine ("AssemblyDescription mesajý: \"{0}\".", ada.Description);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}