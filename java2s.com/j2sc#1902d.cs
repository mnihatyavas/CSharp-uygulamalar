// j2sc#1902d.cs: MakeGenericType, IsGenericType, GetGenericArguments, Activator-InvokeMember-Builder örneði.

using System;
using System.Collections.Generic; //IList<> ve List<> için
using System.Reflection; //BindingFlags için
using System.Reflection.Emit; //AssemblyBuilder, AssemblyBuilderAccess, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator ve OpCodes için
namespace TipliÝþlemler {
    class SýnýfA {
        private string strAlan;
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        private DateTime doðumTarihi;
        public DateTime DoðumTarihi {get {return doðumTarihi;} set {doðumTarihi = value;}}
        DateTime[] tarihler = new DateTime [10];
        public DateTime this [int i] {get {return tarihler [i];} set {tarihler [i] = value;}}
        public void MetotA() {Console.WriteLine ("SýnýfA.MetotA() çaðrýldý");}
    }
    class SoysalTip {
        static object SoysalTipYarat<T> (Type soysalTip) {
            Type[] tipler = {typeof (T)};
            Type kapalýTip = soysalTip.MakeGenericType (tipler);
            return Activator.CreateInstance (kapalýTip);
        }
        static void Main() {
            Console.Write ("AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator, OpCodes, Activator ve MethodInfo.Invoke(object,null) ile tamamen bellekte dinamik tiplemeli bir metot yaratýlýp çaðrýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal IList<> ve List<> ile çeþitli tipli listeler yaratma:");
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

            Console.WriteLine ("\nFarklý koleksiyonlarýn soysal tip argümanlarý:");
            Stack<int> yýðýn = new Stack<int>(); tip = yýðýn.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.WriteLine (t.FullName);
            Dictionary <string, SoysalTip> sözlük1 = new Dictionary <string, SoysalTip>(); tip = sözlük1.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.Write (t.FullName+"\t"); Console.WriteLine();
            SortedDictionary <string, decimal> sözlük2 = new SortedDictionary <string, decimal>(); tip = sözlük2.GetType(); foreach (Type t in tip.GetGenericArguments()) Console.Write (t.FullName+"\t"); Console.WriteLine();

            Console.WriteLine ("\nÜç yöntemle 'tip.InvokeMember('SýnýfA.MetotA())'nýn çaðrýlmasý:");
            tip = typeof (SýnýfA); //Type.GetType (new SýnýfA().ToString());
            object ns = Activator.CreateInstance (tip);
            Console.Write ("tip.InvokeMember('MetotA'...) yöntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ConstructorInfo ci = tip.GetConstructor (new Type[]{});
            ns = ci.Invoke (new object[]{});
            Console.Write ("ci.Invoke(new object[]{}) yöntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ns = tip.InvokeMember ("SýnýfA", BindingFlags.CreateInstance, null, null, new object[]{});
            Console.Write ("tip.InvokeMember('SýnýfA'...) yöntemle: "); tip.InvokeMember ("MetotA", BindingFlags.InvokeMethod, null, ns, new object[]{});

            Console.WriteLine ("\nDinamik 'AssemblyBuilder, ModuleBuilder, TypeBuilder, MethodBuilder, ILGenerator, OpCodes, Activator, MethodInfo' kurulumlarla selam.Invoke(ns,null) metodunun çaðrýlmasý:");
            AppDomain uygSaha = AppDomain.CurrentDomain;
            AssemblyName krgAd = new AssemblyName(); krgAd.Name = "Kurgum";
            AssemblyBuilder ab = uygSaha.DefineDynamicAssembly (krgAd, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule ("Modülüm");
            TypeBuilder tb = mb.DefineType ("Sýnýfým", TypeAttributes.Public);
            MethodBuilder mtb = tb.DefineMethod ("Selam", MethodAttributes.Public, null, null);
            ILGenerator ig = mtb.GetILGenerator(); ig.EmitWriteLine ("Dinamik 'Kurgum.Modülüm.Sýnýfým.Selam()' metodumdan herkese merhabalar!.."); ig.Emit (OpCodes.Ret);
            tip = tb.CreateType();
            if (tip != null) {
                ns = Activator.CreateInstance (tip);
                MethodInfo selam = tip.GetMethod ("Selam");
                if (selam != null) selam.Invoke (ns, null);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}