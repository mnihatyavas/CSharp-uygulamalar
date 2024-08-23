// j2sc#1901e.cs: typeof(Sýnýf), MethodInfo, ParameterInfo ve mi.Invoke(snfTipleme,args) örneði.

using System;
using System.Reflection; //MethodInfo için
using System.Linq.Expressions; //Expression için
using System.Reflection.Emit; //AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder için
using System.Runtime.InteropServices; //CharSet için
namespace TipBilgileri {
    class SýnýfA {
        int ts1 = 1881;
        float fs = 1.0f;
        static int ts2 = 1938;
        SýnýfA (int t1, float f, int t2) {ts1=t1; fs=f; ts2=t2;} //Kurucu
        /*public*/ static void Metot(){}
        public int Fonk (int i, Decimal d, string[] arg) {return(20240808);}
    }
    interface Arayüz1 {void Metot (int i);}
    class SýnýfB: Arayüz1 {public void Metot (int i) {Console.Write ("Kare({0}) = {1}\n",i, i*i);}}
    class SýnýfC {
        int a, b;
        public SýnýfC (int i, int j) {a=i; b=j;} //Kurucu
        public int topla() {Console.WriteLine ("topla({0}, {1}) = {2}", a, b, a+b); return(a+b);}
        public bool aradaMý (int i) {Console.WriteLine ("[{0}, {1}] için aradaMý({2}): {3}", a, b, i, i>=a&i<=b); return(i>=a&i<=b);}
        public int çarp (int a, int b) {Console.WriteLine ("int çarp({0}, {1}) = {2}", a, b, a*b); return(a*b);}
        public double çarp (double a, double b) {Console.WriteLine ("double çarp({0}, {1}) = {2}", a, b, a*b); return(a*b);}
        public string göster() {return String.Format ("göster(a, b): ({0}, {1})", a, b);}
    }
    class Merhaba {public void Selamla (String ad) {Console.WriteLine ("Merhaba "+ad+". Bugün nasýlsýn?");}}
    class Metot {
        static void Main() {
            Console.Write ("Metotlar: 'foreach(MethodInfo mb in typeof(SýnýfA).GetMethods())' ile, mevcut parametreleri: 'foreach(ParameterInfo pb in mb.GetParameters())' ile sunulur. Argümanlý metodun çaðrýlmasý 'mi.Invoke(snfTipleme,args)' ile yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýfA'nýn 'public' metotlarý ve herbir metotun tipli parametreleri:");
            Type tip = typeof (SýnýfA);
            foreach (MethodInfo mb in tip.GetMethods()) {
                Console.WriteLine ("{0}", mb);
                foreach (ParameterInfo pb in mb.GetParameters()) {Console.WriteLine("  Parametre: {0} {1}", pb.ParameterType, pb.Name);}
            }

            Console.WriteLine ("\nProgramdaki tüm sýnýflar ve SýnýfB.Metot() çaðrýsý:");
            var r=new Random(); int i, ts1, ts2;
            string ad = "j2sc#1901e.exe";
            Console.WriteLine ("Koþturulan program: {0}", ad);
            Assembly asm = Assembly.LoadFrom (ad);
            foreach (Type t in asm.GetTypes()) {
                if (t.IsClass) {
                    Console.WriteLine ("  Bulunan sýnýf: {0}", t.FullName);
                    if (t.GetInterface ("Arayüz1") == null) continue;
                    ts1=r.Next(0,10000);
                    Console.Write ("    {0}(Metot()) çaðrýlýyor: ", t.FullName); new SýnýfB().Metot (ts1);
                }
            }

            Console.WriteLine ("\nSýnýfC'nin tüm metotlarý uygun argümanlý'mb.Invoke(snfC,arg)' ile çaðrýlmakta:");
            double ds1, ds2;
            tip = typeof (SýnýfC);
            SýnýfC snfC = new SýnýfC (1881, 1938);
            Console.WriteLine ("\t==>"+tip.Name+" metotlarý çaðrýlýyor..."); 
            MethodInfo[] mi = tip.GetMethods();
            object[] arg;
            foreach (MethodInfo mb in mi) {
                ParameterInfo[] pi = mb.GetParameters();
                if (mb.Name.CompareTo ("çarp")==0 &&  pi [0].ParameterType == typeof (int)) {
                    arg = new object [2];
                    ts1=r.Next(1881, 1938); arg [0] = ts1;
                    ts2=r.Next(1881, 1938); arg [1] = ts2;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("çarp")==0 && pi [0].ParameterType == typeof (double)) {
                    arg = new object [2];
                    ds1=r.Next(1881, 1938)+r.Next(10,100)/100d; arg [0] = ds1;
                    ds2=r.Next(1881, 1938)+r.Next(10,100)/100d; arg [1] = ds2;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("topla")==0) {
                    mb.Invoke (snfC, null);
                }else if (mb.Name.CompareTo ("aradaMý")==0) {
                    arg = new object [1];
                    ts1=r.Next(1299, 2024); arg [0] = ts1;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("göster")==0) {Console.WriteLine (mb.Invoke (snfC, null));}
            }

            Console.WriteLine ("\nobject-->ToString() tip ve metodunun sabit tamsayý andaçlarý:");
            tip = typeof (object);
            MethodInfo blg = tip.GetMethod ("ToString");
            ModuleHandle mh = blg.Module.ModuleHandle;
            ts1 = tip.MetadataToken;
            ts2 = blg.MetadataToken;
            Console.WriteLine ("Andaç(tip, metot): ({0}, {1})", ts1, ts2);
            MethodBody mg = blg.GetMethodBody();
            byte[] ilb = mg.GetILAsByteArray();
            Console.WriteLine ("==>ToString() MetotGövdesi'nin IL kodu, 10'lu ve 16'lý byte:");
            for (i = 0; i < ilb.Length; i++) Console.Write ("{0} ", ilb [i]); Console.WriteLine();
            for (i = 0; i < ilb.Length; i++) Console.Write ("{0:X} ", ilb [i]); Console.WriteLine();

            Console.WriteLine ("\nMath.Cos(45*Math.PI/180) fonksiyonunun sonucunu sunma::");
            tip = Type.GetType ("System.Math");
            Type[] tipler = new Type [1]; //Kullanýlacak Math.Cos(double radyan)'ýn parametre tipi
            tipler [0] = Type.GetType ("System.Double");
            blg = tip.GetMethod ("Cos", tipler);
            arg = new Object [1];
            arg [0] = 45 * (Math.PI / 180);
            Console.WriteLine ("cos (45*pi/180) = {0}", blg.Invoke (tip, arg));

            Console.WriteLine ("\nString.StartsWith(dizge,ibare) metodunun true/false sonucu:");
            MethodInfo metot = typeof (string).GetMethod ("StartsWith", new[] {typeof (string)});
            var prm1 = Expression.Parameter (typeof(string), "x");
            var prm2 = Expression.Parameter (typeof(string), "y");
            Expression[] expDizi = new[] {prm2};
            Expression çaðýr = Expression.Call (prm1, metot, expDizi);
            var lambdaPrm = new[] {prm1, prm2};
            var lambda = Expression.Lambda<Func<string, string, bool>>(çaðýr, lambdaPrm);
            var derlendi = lambda.Compile();
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yavaþ\", \"Ni\")? {0}", derlendi ("M.Nihat Yavaþ", "Ni"));
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yavaþ\", \"M\")? {0}", derlendi ("M.Nihat Yavaþ", "M"));
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yavaþ\", \"M.Ni\")? {0}", derlendi ("M.Nihat Yavaþ", "M.Ni"));

            Console.WriteLine ("\nMerhaba.Selamla(string ad) metodunun çaðrýlmasý:");
            tip = typeof (Merhaba); // veya: tip = Type.GetType (new Merhaba().ToString());
            Object ns = Activator.CreateInstance (tip);
            metot = tip.GetMethod ("Selamla");
            metot.Invoke (ns, new Object[] {"Nihat"});
            metot.Invoke (ns, new Object[] {"Canan"});
            metot.Invoke (ns, new Object[] {"Songül"});
            typeof(Merhaba).GetMethod ("Selamla").Invoke (Activator.CreateInstance(typeof(Merhaba)), new Object[]{"Atilla"});

            Console.WriteLine ("\nWindows-->System32-->Kernel32.dll-->GetTickCount() ile kendi kurgumuzu yaratma:");
            AssemblyName an = new AssemblyName ("MNYavas");           
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (an,AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder modülb = ab.DefineDynamicModule (an.Name, an.Name + ".dll");
            TypeBuilder tb = modülb.DefineType ("Tipim", TypeAttributes.Public | TypeAttributes.UnicodeClass);
            MethodBuilder minþ = tb.DefinePInvokeMethod (
                "GetTickCount",
                "Kernel32.dll",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl,
                CallingConventions.Standard,
                typeof (int),
                Type.EmptyTypes,
                CallingConvention.Winapi,
                CharSet.Ansi);
            minþ.SetImplementationFlags (minþ.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);
            tip = tb.CreateType();
            metot = tip.GetMethod ("GetTickCount");
            Console.WriteLine ("Kernel32.dll-->GetTickCount çaðrýlýyor: {0}", metot.Invoke (null, null));
            Console.WriteLine ("Kurgu adý: " + an.Name + ".dll ==>Diske kaydediliyor...");
            ab.Save (an.Name + ".dll");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}