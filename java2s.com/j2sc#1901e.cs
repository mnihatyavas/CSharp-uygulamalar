// j2sc#1901e.cs: typeof(S�n�f), MethodInfo, ParameterInfo ve mi.Invoke(snfTipleme,args) �rne�i.

using System;
using System.Reflection; //MethodInfo i�in
using System.Linq.Expressions; //Expression i�in
using System.Reflection.Emit; //AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder i�in
using System.Runtime.InteropServices; //CharSet i�in
namespace TipBilgileri {
    class S�n�fA {
        int ts1 = 1881;
        float fs = 1.0f;
        static int ts2 = 1938;
        S�n�fA (int t1, float f, int t2) {ts1=t1; fs=f; ts2=t2;} //Kurucu
        /*public*/ static void Metot(){}
        public int Fonk (int i, Decimal d, string[] arg) {return(20240808);}
    }
    interface Aray�z1 {void Metot (int i);}
    class S�n�fB: Aray�z1 {public void Metot (int i) {Console.Write ("Kare({0}) = {1}\n",i, i*i);}}
    class S�n�fC {
        int a, b;
        public S�n�fC (int i, int j) {a=i; b=j;} //Kurucu
        public int topla() {Console.WriteLine ("topla({0}, {1}) = {2}", a, b, a+b); return(a+b);}
        public bool aradaM� (int i) {Console.WriteLine ("[{0}, {1}] i�in aradaM�({2}): {3}", a, b, i, i>=a&i<=b); return(i>=a&i<=b);}
        public int �arp (int a, int b) {Console.WriteLine ("int �arp({0}, {1}) = {2}", a, b, a*b); return(a*b);}
        public double �arp (double a, double b) {Console.WriteLine ("double �arp({0}, {1}) = {2}", a, b, a*b); return(a*b);}
        public string g�ster() {return String.Format ("g�ster(a, b): ({0}, {1})", a, b);}
    }
    class Merhaba {public void Selamla (String ad) {Console.WriteLine ("Merhaba "+ad+". Bug�n nas�ls�n?");}}
    class Metot {
        static void Main() {
            Console.Write ("Metotlar: 'foreach(MethodInfo mb in typeof(S�n�fA).GetMethods())' ile, mevcut parametreleri: 'foreach(ParameterInfo pb in mb.GetParameters())' ile sunulur. Arg�manl� metodun �a�r�lmas� 'mi.Invoke(snfTipleme,args)' ile yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fA'n�n 'public' metotlar� ve herbir metotun tipli parametreleri:");
            Type tip = typeof (S�n�fA);
            foreach (MethodInfo mb in tip.GetMethods()) {
                Console.WriteLine ("{0}", mb);
                foreach (ParameterInfo pb in mb.GetParameters()) {Console.WriteLine("  Parametre: {0} {1}", pb.ParameterType, pb.Name);}
            }

            Console.WriteLine ("\nProgramdaki t�m s�n�flar ve S�n�fB.Metot() �a�r�s�:");
            var r=new Random(); int i, ts1, ts2;
            string ad = "j2sc#1901e.exe";
            Console.WriteLine ("Ko�turulan program: {0}", ad);
            Assembly asm = Assembly.LoadFrom (ad);
            foreach (Type t in asm.GetTypes()) {
                if (t.IsClass) {
                    Console.WriteLine ("  Bulunan s�n�f: {0}", t.FullName);
                    if (t.GetInterface ("Aray�z1") == null) continue;
                    ts1=r.Next(0,10000);
                    Console.Write ("    {0}(Metot()) �a�r�l�yor: ", t.FullName); new S�n�fB().Metot (ts1);
                }
            }

            Console.WriteLine ("\nS�n�fC'nin t�m metotlar� uygun arg�manl�'mb.Invoke(snfC,arg)' ile �a�r�lmakta:");
            double ds1, ds2;
            tip = typeof (S�n�fC);
            S�n�fC snfC = new S�n�fC (1881, 1938);
            Console.WriteLine ("\t==>"+tip.Name+" metotlar� �a�r�l�yor..."); 
            MethodInfo[] mi = tip.GetMethods();
            object[] arg;
            foreach (MethodInfo mb in mi) {
                ParameterInfo[] pi = mb.GetParameters();
                if (mb.Name.CompareTo ("�arp")==0 &&  pi [0].ParameterType == typeof (int)) {
                    arg = new object [2];
                    ts1=r.Next(1881, 1938); arg [0] = ts1;
                    ts2=r.Next(1881, 1938); arg [1] = ts2;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("�arp")==0 && pi [0].ParameterType == typeof (double)) {
                    arg = new object [2];
                    ds1=r.Next(1881, 1938)+r.Next(10,100)/100d; arg [0] = ds1;
                    ds2=r.Next(1881, 1938)+r.Next(10,100)/100d; arg [1] = ds2;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("topla")==0) {
                    mb.Invoke (snfC, null);
                }else if (mb.Name.CompareTo ("aradaM�")==0) {
                    arg = new object [1];
                    ts1=r.Next(1299, 2024); arg [0] = ts1;
                    mb.Invoke (snfC, arg);
                }else if (mb.Name.CompareTo ("g�ster")==0) {Console.WriteLine (mb.Invoke (snfC, null));}
            }

            Console.WriteLine ("\nobject-->ToString() tip ve metodunun sabit tamsay� anda�lar�:");
            tip = typeof (object);
            MethodInfo blg = tip.GetMethod ("ToString");
            ModuleHandle mh = blg.Module.ModuleHandle;
            ts1 = tip.MetadataToken;
            ts2 = blg.MetadataToken;
            Console.WriteLine ("Anda�(tip, metot): ({0}, {1})", ts1, ts2);
            MethodBody mg = blg.GetMethodBody();
            byte[] ilb = mg.GetILAsByteArray();
            Console.WriteLine ("==>ToString() MetotG�vdesi'nin IL kodu, 10'lu ve 16'l� byte:");
            for (i = 0; i < ilb.Length; i++) Console.Write ("{0} ", ilb [i]); Console.WriteLine();
            for (i = 0; i < ilb.Length; i++) Console.Write ("{0:X} ", ilb [i]); Console.WriteLine();

            Console.WriteLine ("\nMath.Cos(45*Math.PI/180) fonksiyonunun sonucunu sunma::");
            tip = Type.GetType ("System.Math");
            Type[] tipler = new Type [1]; //Kullan�lacak Math.Cos(double radyan)'�n parametre tipi
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
            Expression �a��r = Expression.Call (prm1, metot, expDizi);
            var lambdaPrm = new[] {prm1, prm2};
            var lambda = Expression.Lambda<Func<string, string, bool>>(�a��r, lambdaPrm);
            var derlendi = lambda.Compile();
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yava�\", \"Ni\")? {0}", derlendi ("M.Nihat Yava�", "Ni"));
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yava�\", \"M\")? {0}", derlendi ("M.Nihat Yava�", "M"));
            Console.WriteLine ("String.StartsWith (\"M.Nihat Yava�\", \"M.Ni\")? {0}", derlendi ("M.Nihat Yava�", "M.Ni"));

            Console.WriteLine ("\nMerhaba.Selamla(string ad) metodunun �a�r�lmas�:");
            tip = typeof (Merhaba); // veya: tip = Type.GetType (new Merhaba().ToString());
            Object ns = Activator.CreateInstance (tip);
            metot = tip.GetMethod ("Selamla");
            metot.Invoke (ns, new Object[] {"Nihat"});
            metot.Invoke (ns, new Object[] {"Canan"});
            metot.Invoke (ns, new Object[] {"Song�l"});
            typeof(Merhaba).GetMethod ("Selamla").Invoke (Activator.CreateInstance(typeof(Merhaba)), new Object[]{"Atilla"});

            Console.WriteLine ("\nWindows-->System32-->Kernel32.dll-->GetTickCount() ile kendi kurgumuzu yaratma:");
            AssemblyName an = new AssemblyName ("MNYavas");           
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly (an,AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mod�lb = ab.DefineDynamicModule (an.Name, an.Name + ".dll");
            TypeBuilder tb = mod�lb.DefineType ("Tipim", TypeAttributes.Public | TypeAttributes.UnicodeClass);
            MethodBuilder min� = tb.DefinePInvokeMethod (
                "GetTickCount",
                "Kernel32.dll",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl,
                CallingConventions.Standard,
                typeof (int),
                Type.EmptyTypes,
                CallingConvention.Winapi,
                CharSet.Ansi);
            min�.SetImplementationFlags (min�.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);
            tip = tb.CreateType();
            metot = tip.GetMethod ("GetTickCount");
            Console.WriteLine ("Kernel32.dll-->GetTickCount �a�r�l�yor: {0}", metot.Invoke (null, null));
            Console.WriteLine ("Kurgu ad�: " + an.Name + ".dll ==>Diske kaydediliyor...");
            ab.Save (an.Name + ".dll");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}