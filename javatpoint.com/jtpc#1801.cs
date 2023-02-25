// jtpc#1801.cs: Yans�tma Type s�n�f�yla �e�itli nesne tip bilgilerine ula�ma �rne�i.

using System;
using System.Reflection;
namespace Yans�ma {
    class Yans� {
        static void Main() {
            Console.Write ("System.Reflection yans�ma aduzam� kullan�larak �al��mazamanl� �u s�n�fl� metaverileri al�r: Type, MemberInfo, ConstructorInfo, MethodInfo, FieldInfo, PropertyInfo, TypeInfo, EventInfo, Module, AssemblyName, Pointer vb.\nType s�n�f�yla s�n�f, aray�z, say�sallanabilen, dizi, de�er vb �zellik ve metodlar� elde edilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tamsay� = 2023;
            Type tip1 = tamsay�.GetType();
            Console.WriteLine ("[int tamsay� = 2023] tipi: " + tip1);

            Type tip2 = typeof (System.String);
            Console.WriteLine ("System.String.Assembly: " + tip2.Assembly);
            Console.WriteLine ("System.String.FullName" + tip2.FullName);
            Console.WriteLine ("System.String.BaseType" + tip2.BaseType);
            Console.WriteLine ("System.String.IsClass" + tip2.IsClass);
            Console.WriteLine ("System.String.IsEnum" + tip2.IsEnum);
            Console.WriteLine ("System.String.IsInterface" + tip2.IsInterface);

            Console.WriteLine ("\n{0} tip kurucular� �unlard�r:", tip2);
            ConstructorInfo[] kb = tip2.GetConstructors (BindingFlags.Public | BindingFlags.Instance);
            foreach (ConstructorInfo k in kb) {Console.WriteLine (k);}

            Console.WriteLine ("\n{0} tip metodlar� �unlard�r:", tip2);
            MethodInfo[] mb = tip2.GetMethods (BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo m in mb) {Console.WriteLine (m);}

            Console.WriteLine ("\n{0} tip alanlar� �unlard�r:", tip2);
            FieldInfo[] ab = tip2.GetFields (BindingFlags.Public |  BindingFlags.Static | BindingFlags.NonPublic);
            foreach (FieldInfo a in ab) {Console.WriteLine (a);}


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}