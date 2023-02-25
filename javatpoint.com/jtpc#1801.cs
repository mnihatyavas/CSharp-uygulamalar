// jtpc#1801.cs: Yansýtma Type sýnýfýyla çeþitli nesne tip bilgilerine ulaþma örneði.

using System;
using System.Reflection;
namespace Yansýma {
    class Yansý {
        static void Main() {
            Console.Write ("System.Reflection yansýma aduzamý kullanýlarak çalýþmazamanlý þu sýnýflý metaverileri alýr: Type, MemberInfo, ConstructorInfo, MethodInfo, FieldInfo, PropertyInfo, TypeInfo, EventInfo, Module, AssemblyName, Pointer vb.\nType sýnýfýyla sýnýf, arayüz, sayýsallanabilen, dizi, deðer vb özellik ve metodlarý elde edilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tamsayý = 2023;
            Type tip1 = tamsayý.GetType();
            Console.WriteLine ("[int tamsayý = 2023] tipi: " + tip1);

            Type tip2 = typeof (System.String);
            Console.WriteLine ("System.String.Assembly: " + tip2.Assembly);
            Console.WriteLine ("System.String.FullName" + tip2.FullName);
            Console.WriteLine ("System.String.BaseType" + tip2.BaseType);
            Console.WriteLine ("System.String.IsClass" + tip2.IsClass);
            Console.WriteLine ("System.String.IsEnum" + tip2.IsEnum);
            Console.WriteLine ("System.String.IsInterface" + tip2.IsInterface);

            Console.WriteLine ("\n{0} tip kurucularý þunlardýr:", tip2);
            ConstructorInfo[] kb = tip2.GetConstructors (BindingFlags.Public | BindingFlags.Instance);
            foreach (ConstructorInfo k in kb) {Console.WriteLine (k);}

            Console.WriteLine ("\n{0} tip metodlarý þunlardýr:", tip2);
            MethodInfo[] mb = tip2.GetMethods (BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo m in mb) {Console.WriteLine (m);}

            Console.WriteLine ("\n{0} tip alanlarý þunlardýr:", tip2);
            FieldInfo[] ab = tip2.GetFields (BindingFlags.Public |  BindingFlags.Static | BindingFlags.NonPublic);
            foreach (FieldInfo a in ab) {Console.WriteLine (a);}


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}