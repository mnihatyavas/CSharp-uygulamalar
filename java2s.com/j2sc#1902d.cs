// j2sc#1902d.cs: MakeGenericType, IsGenericType, GetGenericArguments, Activator-InvokeMember-Builder �rne�i.

using System;
using System.Collections.Generic; //IList<> ve List<> i�in
using System.Reflection; //BindingFlags i�in
using System.Reflection.Emit; //AssemblyBuilder, AssemblyBuilderAccess, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator ve OpCodes i�in
namespace Tipli��lemler {
    class S�n�fA {
        private string strAlan;
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        private DateTime do�umTarihi;
        public DateTime Do�umTarihi {get {return do�umTarihi;} set {do�umTarihi = value;}}
        DateTime[] tarihler = new DateTime [10];
        public DateTime this [int i] {get {return tarihler [i];} set {tarihler [i] = value;}}
        public void MetotA() {Console.WriteLine ("S�n�fA.MetotA() �a�r�ld�");}
    }
    class SoysalTip {
        static object SoysalTipYarat<T> (Type soysalTip) {
            Type[] tipler = {typeof (T)};
            Type kapal�Tip = soysalTip.MakeGenericType (tipler);
            return Activator.CreateInstance (kapal�Tip);
        }
        static void Main() {
            Console.Write ("AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator, OpCodes, Activator ve MethodInfo.Invoke(object,null) ile tamamen bellekte dinamik tiplemeli bir metot yarat�l�p �a�r�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal IList<> ve List<> ile �e�itli tipli listeler yaratma:");
            IList<int> intListe = (IList<int>)SoysalTipYarat<int> (typeof (List<>));
            IList<double> dblListe = (IList<double>)SoysalTipYarat<double> (typeof (List<>));
            IList<string> strListe = (IList<string>)SoysalTipYarat<string> (typeof (List<>));
            IList<bool> boolListe = (IList<bool>)SoysalTipYarat<bool> (typeof (List<>));
            Console.WriteLine ("intListe: {0}", intListe);
            Console.WriteLine ("dblListe: {0}", dblListe);
            Console.WriteLine ("strListe: {0}", strListe);
            Console.WriteLine ("boolListe: {0}", boolListe);

            Console.WriteLine ("\nNullable<T> SoysalParametreliMi ve SoysalTipMi?");
            Type tip = typeof (System.Nullable<>);
            Console.WriteLine ("Nullable<> soysal parametreli mi? {0}", tip.ContainsGenericParameters);
            Console.WriteLine ("Nullable<> soysal tip mi? {0}", tip.IsGenericType);
            tip = typeof (System.Nullable<DateTime>); //string olmaz
            Console.WriteLine ("Nullable<DateTime> soysal parametreli mi? {0}", tip.ContainsGenericParameters);
            Console.WriteLine ("Nullable<DateTime> soysal tip mi? {0}", tip.IsGenericType);
            tip = typeof (System.Nullable<int>);
            Console.WriteLine ("Nullable<int> soysal parametreli mi? {0}", tip.ContainsGenericParameters);
            Console.WriteLine ("Nullable<int> soysal tip mi? {0}", tip.IsGenericType);
            tip = typeof (System.Nullable<bool>);
            Console.WriteLine ("Nullable<bool> soysal parametreli mi? {0}", tip.ContainsGenericParameters);
            Console.WriteLine ("Nullable<bool> soysal tip mi? {0}", tip.IsGenericType);

            Console.WriteLine ("\nFarkl� koleksiyonlar�n soysal tip arg�manlar�:");
            Stack<int> y���n = new Stack<int>(); tip = y���n.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.WriteLine (t.FullName);
            Dictionary <string, SoysalTip> s�zl�k1 = new Dictionary <string, SoysalTip>(); tip = s�zl�k1.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.Write (t.FullName+"\t"); Console.WriteLine();
            SortedDictionary <string, decimal> s�zl�k2 = new SortedDictionary <string, decimal>(); tip = s�zl�k2.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.Write (t.FullName+"\t"); Console.WriteLine();

            Console.WriteLine ("\n�� y�ntemle 'tip.InvokeMember('S�n�fA.MetotA())'n�n �a�r�lmas�:");
            tip = typeof (S�n�fA); //Type.GetType (new S�n�fA().ToString());
            object ns = Activator.CreateInstance (tip);
            Console.Write ("tip.InvokeMember('MetotA'...) y�ntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ConstructorInfo ci = tip.GetConstructor (new Type[]{});
            ns = ci.Invoke (new object[]{});
            Console.Write ("ci.Invoke(new object[]{}) y�ntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ns = tip.InvokeMember ("S�n�fA", BindingFlags.CreateInstance, null, null, new object[]{});
            Console.Write ("tip.InvokeMember('S�n�fA'...) y�ntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});

            Console.WriteLine ("\nDinamik 'AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator, OpCodes, Activator, MethodInfo' kurulumlarla selam.Invoke(ns,null) metodunun �a�r�lmas�:");
            AppDomain uygSaha = AppDomain.CurrentDomain;
            AssemblyName krgAd = new AssemblyName(); krgAd.Name = "Kurgum";
            AssemblyBuilder ab = uygSaha.DefineDynamicAssembly (krgAd, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule ("Mod�l�m");
            TypeBuilder tb = mb.DefineType ("S�n�f�m", TypeAttributes.Public);
            MethodBuilder mtb = tb.DefineMethod ("Selam", MethodAttributes.Public, null, null);
            ILGenerator ig = mtb.GetILGenerator(); ig.EmitWriteLine ("Dinamik 'Kurgum.Mod�l�m.S�n�f�m.Selam()' metodumdan herkese merhabalar!.."); ig.Emit (OpCodes.Ret);
            tip = tb.CreateType();
            if (tip != null) {
                ns = Activator.CreateInstance (tip);
                MethodInfo selam = tip.GetMethod ("Selam");
                if (selam != null) selam.Invoke (ns, null);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}