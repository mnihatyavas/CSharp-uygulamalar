// j2sc#1204.cs: Dinamik kurgu, kurgu tamadý detaylarý ve kanýtlarý örneði.

using System;
using System.Threading; //Thread için
using System.Reflection; //Assembly için
using System.Text; //Method/StringBuilder için
using System.EnterpriseServices; //ServicedComponent için
using System.Reflection.Emit; //OpCodes ve Assembly/Module/Field/TypeBuilder için
using System.Globalization; //CultureInfo için
using System.Security.Policy; //Evidence için
using System.Collections; //IENumerator için
[assembly: ApplicationName ("j2sc#1204")]
[assembly: Description ("C#")]
[assembly: ApplicationActivation (ActivationOption.Server)]
[assembly: ApplicationAccessControl (true)]
namespace Kurulum {
    public interface Selamlama {string Selam (string ad);}
    [EventTrackingEnabled (true)]
    [Description ("Basit bir hizmet bileþenli örnek")]
    public class Bileþen1 : ServicedComponent, Selamlama {
        public Bileþen1(){} //Kurucu
        public string Selam (string ad) {
            System.Threading.Thread.Sleep (1000); //1 sn'lik iþlem...
            return "Merhaba, " + ad + "!..";
        }
    }
    public class Bileþen2 : Selamlama {
        public Bileþen2(){} //Kurucu
        public string Selam (string ad) {return "Merhaba, " + ad + "!..";}
    }
    class Kurgu4 {
        public static void DllKurguYarat (AppDomain uygSahasý) {
            AssemblyName krgAdý = new AssemblyName();
            krgAdý.Name = "Kurgum";
            krgAdý.Version = new Version ("1.0.0.0");
            AssemblyBuilder krgÝnþacý = uygSahasý.DefineDynamicAssembly (krgAdý, AssemblyBuilderAccess.Save);
            ModuleBuilder dllModülÝnþacý = krgÝnþacý.DefineDynamicModule ("Kurgum", "Kurgum.dll");
            TypeBuilder sýnýfKurucu = dllModülÝnþacý.DefineType ("Kurgum.DünyayaSelam", TypeAttributes.Public);
            FieldBuilder mesajAlaný = sýnýfKurucu.DefineField ("mesaj", Type.GetType ("System.String"), FieldAttributes.Private);
            Type[] kurucuPrm = new Type [1];
            kurucuPrm [0] = typeof (string);
            ConstructorBuilder constructor = sýnýfKurucu.DefineConstructor (MethodAttributes.Public, CallingConventions.Standard, kurucuPrm);
            ILGenerator kurucuYarat = constructor.GetILGenerator();
            kurucuYarat.Emit (OpCodes.Ldarg_0);
            Type sýnýfNesnesi = typeof (object);
            ConstructorInfo superConstructor = sýnýfNesnesi.GetConstructor (new Type [0]);
            kurucuYarat.Emit(OpCodes.Call, superConstructor);
            kurucuYarat.Emit (OpCodes.Ldarg_0);
            kurucuYarat.Emit (OpCodes.Ldarg_1);
            kurucuYarat.Emit (OpCodes.Stfld, mesajAlaný);
            kurucuYarat.Emit (OpCodes.Ret);
            sýnýfKurucu.DefineDefaultConstructor (MethodAttributes.Public);
            MethodBuilder metotÝnþacý = sýnýfKurucu.DefineMethod ("MesajýAl", MethodAttributes.Public, typeof (string), null);
            ILGenerator metotYarat = metotÝnþacý.GetILGenerator();
            metotYarat.Emit (OpCodes.Ldarg_0);
            metotYarat.Emit (OpCodes.Ldfld, mesajAlaný);
            metotYarat.Emit (OpCodes.Ret);
            MethodBuilder selamMetodu = sýnýfKurucu.DefineMethod ("Selamla", MethodAttributes.Public, null, null);
            metotYarat = selamMetodu.GetILGenerator();
            metotYarat.EmitWriteLine ("Dünyaya selam!..");
            metotYarat.Emit (OpCodes.Ret);
            sýnýfKurucu.CreateType();
            krgÝnþacý.Save ("Kurgum.dll");
        }
        private static void KurguKanýtýnýGöster (Assembly krg) {
            Evidence kanýt = krg.Evidence;
            IEnumerator ien = kanýt.GetHostEnumerator();
            while (ien.MoveNext()) Console.WriteLine (ien.Current);
        }
        static void Main() {
            Console.Write ("'[assembly:...]' vasýflarý aduzam öncesinde bulunmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Program sýnýf tipleme bileþenine servis kontrolu:");
            try {using (Bileþen1 slm1 = new Bileþen1()) {for (int i = 0; i < 5; i++) Console.WriteLine (slm1.Selam ("Nihat"));}
            }catch (Exception ht) {Console.WriteLine ("Servis Hata Mesajý: [{0}]", ht.Message);}
            Bileþen2 slm2 = new Bileþen2();
            for (int i = 0; i < 5; i++) Console.WriteLine (slm2.Selam ("Nihat"));

            Console.WriteLine ("\nMesaj ileten dinamik sýnýf metodu yaratma:");
            AppDomain uygSahasý = Thread.GetDomain();
            DllKurguYarat (uygSahasý);
            Assembly kurgu = Assembly.Load ("Kurgum");
            Type dinamikTipleme = kurgu.GetType ("Kurgum.DünyayaSelam");
            string mesaj = "Dinamik tipleme sýnýfýn tek string alan mesajýyým...";
            object[] argDizi = new object [1];
            argDizi [0] = mesaj;
            object argümanlýTipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            MethodInfo selamMetodu = dinamikTipleme.GetMethod ("Selamla");
            selamMetodu.Invoke (argümanlýTipleme, null);
            selamMetodu = dinamikTipleme.GetMethod ("MesajýAl");
            Console.WriteLine (selamMetodu.Invoke (argümanlýTipleme, null));
            mesaj = "2.Mesaj: M.Nihat Yavas, Toroslar - Mersin";
            argDizi [0] = mesaj;
            argümanlýTipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            Console.WriteLine (selamMetodu.Invoke (argümanlýTipleme, null));
            argDizi [0] = "3.Mesaj: Dinamik sýnýf metodu bu mesajla tekrar çaðrýlýyor...";
            argümanlýTipleme = Activator.CreateInstance (dinamikTipleme, argDizi);
            Console.WriteLine (selamMetodu.Invoke (argümanlýTipleme, null));

            Console.WriteLine ("\nAppDomainSetup ile dinamik uygSaha, dizin, dosya, yol tanýmlama:");
            AppDomainSetup uygSahaBilgi = new AppDomainSetup();
            Console.WriteLine (uygSahaBilgi.ApplicationBase = @"C:\Nihat");
            Console.WriteLine (uygSahaBilgi.ConfigurationFile = "mny.config");
            Console.WriteLine (uygSahaBilgi.PrivateBinPath = "bin;plugins;external");
            AppDomain yeniSaha = AppDomain.CreateDomain ("Yeni UygSaham", null, uygSahaBilgi);
            Console.WriteLine ("AppDomain.CurrentDomain.FriendlyName: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine ("AppDomain.FriendlyName: " + yeniSaha.FriendlyName);

            Console.WriteLine ("\nAssemblyName ile tam yada tek-tek kurgu ad ve özelliklerini atama:");
            AssemblyName krgAdý = new AssemblyName ("com.microsoft.crypto, " +
                "Culture=en, PublicKeyToken=a5d015c7d5a0b012, Version=1.0.0.0");
            Console.WriteLine ("Tanýmlanan kurgu adý: [{0}]", krgAdý);
            krgAdý = new AssemblyName();
            krgAdý.Name = "mscorlib";
            krgAdý.Version = new Version (2, 0, 0, 0);
            krgAdý.CultureInfo = CultureInfo.InvariantCulture;
            krgAdý.SetPublicKeyToken (new byte[] {0xb7, 0x7a, 0x5c, 056, 0x19, 0x34, 0xe0, 0x89 });
            krgAdý.ProcessorArchitecture = ProcessorArchitecture.X86;
            Console.WriteLine ("Tanýmlanan yeni kurgu adý: [{0}]", krgAdý);

            Console.WriteLine ("\nKurgu adý, modülü, platform çeþidi ve resim makinesi:");
            kurgu = Assembly.GetExecutingAssembly();
            Module modül = kurgu.ManifestModule;
            PortableExecutableKinds portatifÝþletilebilirÇeþitler;
            ImageFileMachine resimDosyaMakinesi;
            modül.GetPEKind (out portatifÝþletilebilirÇeþitler, out resimDosyaMakinesi);
            Console.WriteLine ("Kurgu'nun tam adý: [{0}]\nPortatif iþletilebilir çeþidi: [{1}]\nResim dosya makinesi: [{2}]", kurgu.FullName, portatifÝþletilebilirÇeþitler, resimDosyaMakinesi);
            if ((portatifÝþletilebilirÇeþitler & PortableExecutableKinds.ILOnly) != 0) {Console.WriteLine ("Platform'dan baðýmsýzdýr.");
            }else {
                Console.Write ("Platform'a baðýmlý olup, resim dosya makinesi: ");
                switch (resimDosyaMakinesi) {
                    case ImageFileMachine.I386: Console.Write ("I386"); break;
                    case ImageFileMachine.IA64: Console.Write ("IA64"); break;
                    case ImageFileMachine.AMD64: Console.Write ("AMD64"); break;
                } Console.WriteLine();
            }

            Console.WriteLine ("\nMevcut program kurgusunun güvenlik kanýtlarý:");
            kurgu = Assembly.LoadFrom ("j2sc#1204.exe");
            KurguKanýtýnýGöster (kurgu);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    } 
}