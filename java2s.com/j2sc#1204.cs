// j2sc#1204.cs: Dinamik kurgu, kurgu tamad� detaylar� ve kan�tlar� �rne�i.

using System;
using System.Threading; //Thread i�in
using System.Reflection; //Assembly i�in
using System.Text; //Method/StringBuilder i�in
using System.EnterpriseServices; //ServicedComponent i�in
using System.Reflection.Emit; //OpCodes ve Assembly/Module/Field/TypeBuilder i�in
using System.Globalization; //CultureInfo i�in
using System.Security.Policy; //Evidence i�in
using System.Collections; //IENumerator i�in
[assembly: ApplicationName ("j2sc#1204")]
[assembly: Description ("C#")]
[assembly: ApplicationActivation (ActivationOption.Server)]
[assembly: ApplicationAccessControl (true)]
namespace Kurulum {
    public interface Selamlama {string Selam (string ad);}
    [EventTrackingEnabled (true)]
    [Description ("Basit bir hizmet bile�enli �rnek")]
    public class Bile�en1 : ServicedComponent, Selamlama {
        public Bile�en1(){} //Kurucu
        public string Selam (string ad) {
            System.Threading.Thread.Sleep (1000); //1 sn'lik i�lem...
            return "Merhaba, " + ad + "!..";
        }
    }
    public class Bile�en2 : Selamlama {
        public Bile�en2(){} //Kurucu
        public string Selam (string ad) {return "Merhaba, " + ad + "!..";}
    }
    class Kurgu4 {
        public static void DllKurguYarat (AppDomain uygSahas�) {
            AssemblyName krgAd� = new AssemblyName();
            krgAd�.Name = "Kurgum";
            krgAd�.Version = new Version ("1.0.0.0");
            AssemblyBuilder krg�n�ac� = uygSahas�.DefineDynamicAssembly (krgAd�, AssemblyBuilderAccess.Save);
            ModuleBuilder dllMod�l�n�ac� = krg�n�ac�.DefineDynamicModule ("Kurgum", "Kurgum.dll");
            TypeBuilder s�n�fKurucu = dllMod�l�n�ac�.DefineType ("Kurgum.D�nyayaSelam", TypeAttributes.Public);
            FieldBuilder mesajAlan� = s�n�fKurucu.DefineField ("mesaj", Type.GetType ("System.String"), FieldAttributes.Private);
            Type[] kurucuPrm = new Type [1];
            kurucuPrm [0] = typeof (string);
            ConstructorBuilder constructor = s�n�fKurucu.DefineConstructor (MethodAttributes.Public, CallingConventions.Standard, kurucuPrm);
            ILGenerator kurucuYarat = constructor.GetILGenerator();
            kurucuYarat.Emit (OpCodes.Ldarg_0);
            Type s�n�fNesnesi = typeof (object);
            ConstructorInfo superConstructor = s�n�fNesnesi.GetConstructor (new Type [0]);
            kurucuYarat.Emit(OpCodes.Call, superConstructor);
            kurucuYarat.Emit (OpCodes.Ldarg_0);
            kurucuYarat.Emit (OpCodes.Ldarg_1);
            kurucuYarat.Emit (OpCodes.Stfld, mesajAlan�);
            kurucuYarat.Emit (OpCodes.Ret);
            s�n�fKurucu.DefineDefaultConstructor (MethodAttributes.Public);
            MethodBuilder metot�n�ac� = s�n�fKurucu.DefineMethod ("Mesaj�Al", MethodAttributes.Public, typeof (string), null);
            ILGenerator metotYarat = metot�n�ac�.GetILGenerator();
            metotYarat.Emit (OpCodes.Ldarg_0);
            metotYarat.Emit (OpCodes.Ldfld, mesajAlan�);
            metotYarat.Emit (OpCodes.Ret);
            MethodBuilder selamMetodu = s�n�fKurucu.DefineMethod ("Selamla", MethodAttributes.Public, null, null);
            metotYarat = selamMetodu.GetILGenerator();
            metotYarat.EmitWriteLine ("D�nyaya selam!..");
            metotYarat.Emit (OpCodes.Ret);
            s�n�fKurucu.CreateType();
            krg�n�ac�.Save ("Kurgum.dll");
        }
        private static void KurguKan�t�n�G�ster (Assembly krg) {
            Evidence kan�t = krg.Evidence;
            IEnumerator ien = kan�t.GetHostEnumerator();
            while (ien.MoveNext()) Console.WriteLine (ien.Current);
        }
        static void Main() {
            Console.Write ("'[assembly:...]' vas�flar� aduzam �ncesinde bulunmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Program s�n�f tipleme bile�enine servis kontrolu:");
            try {using (Bile�en1 slm1 = new Bile�en1()) {for (int i = 0; i < 5; i++) Console.WriteLine (slm1.Selam ("Nihat"));}
            }catch (Exception ht) {Console.WriteLine ("Servis Hata Mesaj�: [{0}]", ht.Message);}
            Bile�en2 slm2 = new Bile�en2();
            for (int i = 0; i < 5; i++) Console.WriteLine (slm2.Selam ("Nihat"));

            Console.WriteLine ("\nMesaj ileten dinamik s�n�f metodu yaratma:");
            AppDomain uygSahas� = Thread.GetDomain();
            DllKurguYarat (uygSahas�);
            Assembly kurgu = Assembly.Load ("Kurgum");
            Type dinamikTipleme = kurgu.GetType ("Kurgum.D�nyayaSelam");
            string mesaj = "Dinamik tipleme s�n�f�n tek string alan mesaj�y�m...";
            object[] argDizi = new object [1];
            argDizi [0] = mesaj;
            object arg�manl�Tipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            MethodInfo selamMetodu = dinamikTipleme.GetMethod ("Selamla");
            selamMetodu.Invoke (arg�manl�Tipleme, null);
            selamMetodu = dinamikTipleme.GetMethod ("Mesaj�Al");
            Console.WriteLine (selamMetodu.Invoke (arg�manl�Tipleme, null));
            mesaj = "2.Mesaj: M.Nihat Yavas, Toroslar - Mersin";
            argDizi [0] = mesaj;
            arg�manl�Tipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            Console.WriteLine (selamMetodu.Invoke (arg�manl�Tipleme, null));
            argDizi [0] = "3.Mesaj: Dinamik s�n�f metodu bu mesajla tekrar �a�r�l�yor...";
            arg�manl�Tipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            Console.WriteLine (selamMetodu.Invoke (arg�manl�Tipleme, null));

            Console.WriteLine ("\nAppDomainSetup ile dinamik uygSaha, dizin, dosya, yol tan�mlama:");
            AppDomainSetup uygSahaBilgi = new AppDomainSetup();
            Console.WriteLine (uygSahaBilgi.ApplicationBase = @"C:\Nihat");
            Console.WriteLine (uygSahaBilgi.ConfigurationFile = "mny.config");
            Console.WriteLine (uygSahaBilgi.PrivateBinPath = "bin;plugins;external");
            AppDomain yeniSaha = AppDomain.CreateDomain ("Yeni UygSaham", null, uygSahaBilgi);
            Console.WriteLine ("AppDomain.CurrentDomain.FriendlyName: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine ("AppDomain.FriendlyName: " + yeniSaha.FriendlyName);

            Console.WriteLine ("\nAssemblyName ile tam yada tek-tek kurgu ad ve �zelliklerini atama:");
            AssemblyName krgAd� = new AssemblyName ("com.microsoft.crypto, " +
                "Culture=en, PublicKeyToken=a5d015c7d5a0b012, Version=1.0.0.0");
            Console.WriteLine ("Tan�mlanan kurgu ad�: [{0}]", krgAd�);
            krgAd� = new AssemblyName();
            krgAd�.Name = "mscorlib";
            krgAd�.Version = new Version (2, 0, 0, 0);
            krgAd�.CultureInfo = CultureInfo.InvariantCulture;
            krgAd�.SetPublicKeyToken (new byte[] {0xb7, 0x7a, 0x5c, 056, 0x19, 0x34, 0xe0, 0x89 });
            krgAd�.ProcessorArchitecture = ProcessorArchitecture.X86;
            Console.WriteLine ("Tan�mlanan yeni kurgu ad�: [{0}]", krgAd�);

            Console.WriteLine ("\nKurgu ad�, mod�l�, platform �e�idi ve resim makinesi:");
            kurgu = Assembly.GetExecutingAssembly();
            Module mod�l = kurgu.ManifestModule;
            PortableExecutableKinds portatif��letilebilir�e�itler;
            ImageFileMachine resimDosyaMakinesi;
            mod�l.GetPEKind (out portatif��letilebilir�e�itler, out resimDosyaMakinesi);
            Console.WriteLine ("Kurgu'nun tam ad�: [{0}]\nPortatif i�letilebilir �e�idi: [{1}]\nResim dosya makinesi: [{2}]", kurgu.FullName, portatif��letilebilir�e�itler, resimDosyaMakinesi);
            if ((portatif��letilebilir�e�itler & PortableExecutableKinds.ILOnly) != 0) {Console.WriteLine ("Platform'dan ba��ms�zd�r.");
            }else {
                Console.Write ("Platform'a ba��ml� olup, resim dosya makinesi: ");
                switch (resimDosyaMakinesi) {
                    case ImageFileMachine.I386: Console.Write ("I386"); break;
                    case ImageFileMachine.IA64: Console.Write ("IA64"); break;
                    case ImageFileMachine.AMD64: Console.Write ("AMD64"); break;
                } Console.WriteLine();
            }

            Console.WriteLine ("\nMevcut program kurgusunun g�venlik kan�tlar�:");
            kurgu = Assembly.LoadFrom ("j2sc#1204.exe");
            KurguKan�t�n�G�ster (kurgu);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    } 
}