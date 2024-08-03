// j2sc#1901a.cs: typeof(Sýnýf) ve new Sýnýf().GetType() tip bilgi detaylarý örneði.

using System;
using System.Reflection; //BindingFlags için
using System.Text; //StringBuilder için
using System.IO; //StringReader için
using System.Collections.Generic; //List<T> için
using System.Collections; //ArrayList için
using System.Linq; //OfType için
namespace TipBilgileri {
    class SýnýfA {
        public int alan1=0;
        public int alan2=0;
        public void Metot1() {}
        public int Metot2() {return 20240801;}
    }
    public interface IArayüz1 {void MetotA();}
    public interface IArayüz2 {void MetotB();}
    public class SýnýfB: IArayüz1, IArayüz2 {
        public enum sayýlabilir{}
        public int intAlan;
        public string strAlan;
        public int IntAlan {get {return intAlan;} set {intAlan = value;}}
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        void IArayüz1.MetotA(){}
        void IArayüz2.MetotB(){}
        public void metotA (int p1, string p2) {}
    }
    public class SýnýfC {
        public event EventHandler Deðiþti;
        private string dizge;
        public string Dizge {get {return dizge;} set {dizge = value; Deðiþirse();}}
        private void Deðiþirse() {if (Deðiþti != null) Deðiþti (this, System.EventArgs.Empty);}
    }
    public class SýnýfD {
        public class ÝçSýnýf1 {public static int ts=20240802;}
        public class ÝçSýnýf2 {public static double ds=20240802.0603;}
        public struct ÝçYapý {public static int ts=20240802;}
    }
    class Tip {
        public static bool tipMi (object ns, string tip) {
            Type t = Type.GetType (tip, true, true);
            return t == ns.GetType() || ns.GetType().IsSubclassOf (t);
        }
        private static void Deðiþirse (object gönderen, System.EventArgs olay) {Console.WriteLine (((SýnýfC)gönderen).Dizge);}
        static void Main() {
            Console.Write ("Type kökeni System.Reflection.MemberInfo'dur. Metotlarý: DeclaringType(), ReflectedType(), MemberType.Constructor/Method/Field/Event/Property sayýsallama, string.Name. Get'li dizi metotlarý: ConstructorInfo[ ] GetConstructors(), EventInfo[ ] GetEvents(), FieldInfo[ ] GetFields(), MemberInfo[] GetMembers(), MethodInfo[] GetMethods(), PropertyInfo[] GetProperties(). Sadece-okunabilir özellikler: Assembly Assembly, TypeAttributes Attributes, Type BaseType, string FullName, bool IsAbstract, bool isArray, bool IsClass, bool IsEnum, string Namespace\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Type tip=typeof(Sýnýf) veya=new Sýnýf().GetType() detaylarý:");
            int i;
            string ad = "M.Nihat Yavaþ";
            Type tip = ad.GetType();
            Console.WriteLine ("ad.GetType().Name: {0}", tip.Name);
            Console.WriteLine ("tip'in aduzamý: {0}", tip.Namespace);
            Console.WriteLine ("tip genel mi? {0}", tip.IsPublic);
            Console.WriteLine ("tip == typeof(string)? {0}", tip == typeof (string));
            MethodInfo[] mi = tip.GetMethods (BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            Console.WriteLine ("\t==>tip(string)'e dair tüm arþiv metotlar:");
            for(i=0;i<mi.Length;i++) Console.WriteLine ("{0}) {1}", i+1, mi [i]);
            tip = Type.GetType ("System.String"); Console.WriteLine ("Type.GetType(\"System.String\").Name: {0}", tip.Name);
            tip = Type.GetType ("System.String", true); Console.WriteLine ("Type.GetType(\"System.String\",true).Name: {0}", tip.Name);
            tip = Type.GetType ("System.String", true, true); Console.WriteLine ("Type.GetType(\"System.String\",true,true).Name: {0}", tip.Name);
            StringBuilder sb = new StringBuilder(); tip = sb.GetType(); Console.WriteLine ("sb.GetType().Name: {0}", tip.Name);
            Object ns = new StringReader ("Bu bir StringReader/DizgeOkuyucu'dur.");
            if (tipMi (ns, "System.IO.TextReader")) Console.WriteLine ("TipAl: ns bir TextReader'dýr.");
            Object ns1 = new Object();
            System.String dzg1 = "M.Nihat Yavaþ";
            Type tip1 = ns1.GetType();
            Type tip2 = dzg1.GetType();
            Console.WriteLine ("ns1 tipin TemelTip: ({0}), Ad: ({1}), TamAd: ({2}), Aduzam: ({3})", tip1.BaseType, tip1.Name, tip1.FullName, tip1.Namespace);
            Console.WriteLine ("dzg1 tipin TemelTip: ({0}), Ad: ({1}), TamAd: ({2}), Aduzam: ({3})", tip2.BaseType, tip2.Name, tip2.FullName, tip2.Namespace);
            tip = typeof (object);
            MethodInfo mi2 = tip.GetMethod ("ToString");
            Console.WriteLine ("MethodInfo(typeof(object).GetMethod(\"ToString\")): {0}", mi2);
            RuntimeTypeHandle rth = tip.TypeHandle;
            RuntimeMethodHandle rmh = mi2.MethodHandle;
            Console.WriteLine ("Tip yönetimi: {0}\nMetot yönetimi: {1}", rth, rmh);
            tip = typeof (SýnýfA);
            mi = tip.GetMethods();
            foreach (MethodInfo m in mi) Console.WriteLine ("Metot: {0}", m.Name);
            FieldInfo[] fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);
            SýnýfB snfB = new SýnýfB();
            tip = snfB.GetType();
            Console.WriteLine ("TamAdý: {0}\nTemelTipi: {1}\nSoyutMu: {2}\nCOMNesneMi: {3}\nMühürlüMü: {4}\nSýnýfMý: {5}", tip.FullName, tip.BaseType, tip.IsAbstract, tip.IsCOMObject, tip.IsSealed, tip.IsClass);
            mi = tip.GetMethods();
            foreach (MethodInfo m in mi) Console.WriteLine ("Metot: {0}", m.Name);
            fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);
            tip = typeof (List<>);
            Console.WriteLine ("List<>(GenelTipMi, SoysalParametreÝçeriyorMu): ({0}, {1})", tip.IsGenericType, tip.ContainsGenericParameters);
            tip = typeof (List<int>);
            Console.WriteLine ("List<int>(GenelTipMi, SoysalParametreÝçeriyorMu): ({0}, {1})", tip.IsGenericType, tip.ContainsGenericParameters);
            Console.WriteLine ("typeof(List<>).Equals(typeof(List<int>): {0}", typeof (List<>).Equals (typeof(List<int>).GetGenericTypeDefinition()));
            tip = typeof (List<>).MakeGenericType (typeof (int));
            Console.WriteLine ("typeof(List<>).MakeGenericType(typeof(int)).TamAdý: {0}", tip.FullName);
            tip = typeof (StringBuilder);
            Type[] tipDizi = new Type[] {typeof (System.String), typeof (System.Int32)};
            ConstructorInfo ci = tip.GetConstructor (tipDizi);
            object[] nsDizi = new object[] {"M.Nihat Yavaþ", 20240108};
            sb = (StringBuilder)ci.Invoke (nsDizi);
            Console.WriteLine (sb);
            tip = typeof (SýnýfA); Console.WriteLine (tip.FullName+", "+tip.Namespace);
            tip = Type.GetType ("System.Boolean"); Console.WriteLine (tip.FullName+", "+tip.Namespace);
            try {tip = Type.GetType ("SýnýfA"); Console.WriteLine (tip.FullName+", "+tip.Namespace);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            try {tip = Type.GetType (new SýnýfA().ToString()); Console.WriteLine (tip.FullName+", "+tip.Namespace);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            try {tip = Type.GetType ("new SýnýfA()"); Console.WriteLine (tip.FullName+", "+tip.Namespace);} catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            ArrayList liste = new ArrayList {"Nihat", "Mahmut", 2024, "Memet", false};
            var strDizi = liste.OfType <string>();
            foreach (string dzg in strDizi) Console.WriteLine (dzg);
            liste = new ArrayList {1881, 1919, "Samsun", 1938, true};
            var intDizi = liste.OfType<int>();
            foreach (int ts in intDizi) Console.WriteLine (ts);
            tip = typeof (SýnýfC);
            ns = Activator.CreateInstance (tip);
            tip.InvokeMember ("Dizge", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public, null, ns, new object[] {"Ürünlerimiz için Windows&Google AVM'yi ziyaret edin" });
            ad = (string)tip.InvokeMember ("Dizge", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, null, ns, new object[] {});
            Console.WriteLine (ad);
            tip=typeof (SýnýfD);
            tipDizi=tip.GetNestedTypes();
            Console.WriteLine ("Ýç tiplerin sayýsý: {0}", tipDizi.Length);
            foreach(Type t in tipDizi) Console.WriteLine ("Ýçtip adý: {0}", t.ToString());
            Guid gd = new Guid ("1DCD0710-0B41-11D3-A565-00C04F8EF6E3");
            tip=Type.GetTypeFromCLSID (gd, true);
            Console.WriteLine ("Tiplemesi yapýlan GUID: [{0}]", tip.GUID);
            Console.WriteLine ("GUID'in tipi: [{0}]", tip.ToString());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
/*
System.Type is derived from an abstract class called System.Reflection.MemberInfo.

MemberInfo defines the following abstract, read-only properties:

Return Type	Method Name	Meanings
Type	DeclaringType	The type of the class or interface in which the member is declared.
MemberTypes	MemberType	The type of the member.
string	Name	The name of the type.
Type	ReflectedType	The type of the object being reflected.


MemberTypes is an enumeration:

MemberTypes.Constructor
MemberTypes.Method
MemberTypes.Field
MemberTypes.Event
MemberTypes.Property
--------------------------------
Runtime type ID is the mechanism that lets you identify a type during the execution of a program.

Reflection enables you to obtain information about a type.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


public class MainClass
{
    public static void Main()
    {
        string s = "A string";
        Type t = s.GetType();
        Console.WriteLine(t.Name);              
        Console.WriteLine(t.Namespace);         
        Console.WriteLine(t.IsPublic);          
        Console.WriteLine(t == typeof(string)); 
    }

}
String
System
True
True
--------------------------------
Method	Purpose
ConstructorInfo[ ] GetConstructors()	Obtains a list of the constructors.
EventInfo[ ] GetEvents()	Obtains a list of events.
FieldInfo[ ] GetFields()	Obtains a list of the fields.
MemberInfo[ ] GetMembers()	Obtains a list of the members.
MethodInfo[ ] GetMethods()	Obtains a list of methods.
PropertyInfo[ ] GetProperties()	Obtains a list of properties.


Here are several commonly used, read-only properties defined by Type:

Property	Purpose
Assembly Assembly	Obtains the assembly.
TypeAttributes Attributes	Obtains the attributes.
Type BaseType	Obtains the immediate base type.
string FullName	Obtains the complete name.
bool IsAbstract	Is abstract.
bool isArray	Is an array.
bool IsClass	Is a class.
bool IsEnum	Is an enumeration.
string Namespace	Obtains the namespace.
-------------------------------------
It has this general form:

MethodInfo[ ] GetMethods(BindingFlags criteria)
This version obtains only those methods that match the criteria.

BindingFlags is an enumeration.

Its most commonly used values are shown here:

Value	Meaning
DeclaredOnly	Retrieves only those methods defined by the specified class. Inherited methods are not included.
Instance	Retrieves instance methods.
NonPublic	Retrieves nonpublic methods.
Public	Retrieves public methods.
Static	Retrieves static methods.


You can OR together two or more flags.
Minimally you must include either Instance or Static with Public or NonPublic.
Failure to do so will result in no methods being retrieved.
One of the main uses of the BindingFlags form of GetMethods() is to obtain a list of the methods defined by a class without also retrieving the inherited methods.

For example, try substituting this call to GetMethods() into the preceding program:

MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly |
                               BindingFlags.Instance |
                               BindingFlags.Public) ;
---------------------------------------
using System;
using System.Text;

class MainClass
{
    public static void Main()
    {
        Type t2 = Type.GetType("System.String");
    }
}
---------------------------------
using System;
using System.Text;

class MainClass
{
    public static void Main()
    {
        Type t3 = Type.GetType("System.String", true);
    }
}
---------------------------------
using System;
using System.Text;

class MainClass
{
    public static void Main()
    {
        Type t4 = Type.GetType("system.string", true, true);
    }
}
--------------------------------------
using System;
using System.Text;

class MainClass
{
    public static void Main()
    {
 
        StringBuilder sb = new StringBuilder();
        Type t6 = sb.GetType();
    }
}
----------------------------------
using System;
using System.IO;

class MainClass
{
    public static void Main() 
    {
        Object someObject = new StringReader("This is a StringReader");

        
        if (IsType(someObject, "System.IO.TextReader")) 
        {
            Console.WriteLine("GetType: someObject is a TextReader");
        }
    }
    public static bool IsType(object obj, string type) 
    {
        Type t = Type.GetType(type, true, true);

        return t == obj.GetType() || obj.GetType().IsSubclassOf(t);
    }
    
}
GetType: someObject is a TextReader
----------------------------------
using System;

class MainClass
{
  static void Main(string[] args)
  {
    Object cls1 = new Object();
    System.String cls2 = "Test String" ;

    Type type1 = cls1.GetType();
    Type type2 = cls2.GetType();

    // Object class output
    Console.WriteLine(type1.BaseType);
    Console.WriteLine(type1.Name);
    Console.WriteLine(type1.FullName);
    Console.WriteLine(type1.Namespace);

    // string output
    Console.WriteLine(type2.BaseType);
    Console.WriteLine(type2.Name);
    Console.WriteLine(type2.FullName);
    Console.WriteLine(type2.Namespace);
  } 
}
Object
System.Object
System
System.Object
String
System.String
System
--------------------------------------
using System;
using System.Reflection;

public interface IFaceOne
{
  void MethodA();
}

public interface IFaceTwo
{
  void MethodB();
}

public class MyClass: IFaceOne, IFaceTwo
{
  public enum MyNestedEnum{}
  
  public int myIntField;
  public string myStringField;

  public void myMethod(int p1, string p2)
  {
  }

  public int MyProp
  {
    get { return myIntField; }
    set { myIntField = value; }
  }

  void IFaceOne.MethodA(){}
  void IFaceTwo.MethodB(){}
}

public class MainClass
{
  public static void Main(string[] args)
  {
    MyClass f = new MyClass();

    Type t = f.GetType();

    Console.WriteLine("Full name is: {0}", t.FullName);
    Console.WriteLine("Base is: {0}", t.BaseType);
    Console.WriteLine("Is it abstract? {0}", t.IsAbstract);
    Console.WriteLine("Is it a COM object? {0}", t.IsCOMObject);
    Console.WriteLine("Is it sealed? {0}", t.IsSealed);
    Console.WriteLine("Is it a class? {0}", t.IsClass);
    
  }
}
Full name is: MyClass
Base is: System.Object
Is it abstract? False
Is it a COM object? False
Is it sealed? False
Is it a class? True
------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        Type typeInfo = typeof(object);
        MethodInfo methInfo = typeInfo.GetMethod("ToString");
        Console.WriteLine("Info: {0}", methInfo);

    }
}
Info: System.String ToString()
-----------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        Type typeInfo = typeof(object);
        MethodInfo methInfo = typeInfo.GetMethod("ToString");
        RuntimeTypeHandle typeHandle = typeInfo.TypeHandle;
        RuntimeMethodHandle methHandle = methInfo.MethodHandle;
        Console.WriteLine("Handle: {0}", methHandle);
    }
}
Handle: System.RuntimeMethodHandle
----------------------------------
using System;
using System.Reflection;

class MyClass
{
   public int Field1;
   public int Field2;
   public void Method1() { }
   public int  Method2() { return 1; }
}

class MainClass
{
   static void Main()
   {
      Type t = typeof(MyClass);
      MethodInfo[] mi = t.GetMethods();

      foreach (MethodInfo m in mi)
         Console.WriteLine("Method: {0}", m.Name);

   }
}
Method: Method1
Method: Method2
Method: GetType
Method: ToString
Method: Equals
Method: GetHashCode
--------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        Type listType = typeof(List<>);
        Console.WriteLine("List<>: {0}, {1}",listType.IsGenericType, listType.ContainsGenericParameters);
        Type listIntType = typeof(List<int>);
        Console.WriteLine("List<int>: {0}, {1}",listIntType.IsGenericType, listIntType.ContainsGenericParameters);
    }
}
List<>: True, True
List: True, False
-------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        Console.WriteLine(typeof(List<>).Equals(typeof(List<int>).GetGenericTypeDefinition()));
    }
}
True
-----------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

public class MainClass
{
    public static void Main()
    {
        Type listType = typeof(List<>);
        Type listOfIntType = listType.MakeGenericType(typeof(int));
        Console.WriteLine(listOfIntType.FullName);
    }
}
System.Collections.Generic.List`1[[System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicK
eyToken=b77a5c561934e089]]
----------------------------------
using System;
using System.Text;
using System.Reflection;

class MainClass
{
    public static void Main ()
    {
        Type type = typeof(StringBuilder);

        Type[] argTypes = new Type[] { typeof(System.String), typeof(System.Int32) };

        ConstructorInfo cInfo = type.GetConstructor(argTypes);

        object[] argVals = new object[] { "Some string", 30 };

        // Create the object and cast it to StringBuilder.
        StringBuilder sb = (StringBuilder)cInfo.Invoke(argVals);

        Console.WriteLine(sb);
    }
}
Some string
------------------------------
using System;
using System.Reflection;
using System.Globalization;
  class Class1
  {
    DateTime[] dateTimes = new DateTime[10];
    public DateTime this[int index]
    {
      get{ return dateTimes[index]; }
      set{ dateTimes[index] = value;}
    }
    
    
    private DateTime dateOfBirth;
    public DateTime DateOfBirth
    {
        get{ return dateOfBirth; }
        set{ dateOfBirth = value; }
    }
      
    public void Test()
    {
      Console.WriteLine("Test method called");
    }
    
    
    private string field;
    
    public string Property
    { 
      get{ return field; }
      set{ field = value; }
    }
    
  }


    class MainClass{
    
    static void Main(string[] args)
    {
      Type type = typeof(Class1);
      Console.WriteLine(type.FullName);
      
      type = Type.GetType("Class1");
      Console.WriteLine(type.Namespace);



    }
    }
-----------------------------
using System;
using System.Collections;
using System.Linq;
using System.ComponentModel;

    class MainClass
    {
        static void Main()
        {
            ArrayList list = new ArrayList { "First", "Second", "Third"};
            var strings = list.Cast<string>();
            foreach (string item in strings)
            {
                Console.WriteLine(item);
            }
            list = new ArrayList { 1, "not an int", 2, 3};
            var ints = list.OfType<int>();
            foreach (int item in ints)
            {
                Console.WriteLine(item);
            }
        }
    }
-----------------------------
using System;
using System.Reflection;
using System.Windows.Forms;

public class Class1
{
    static void Main(string[] args)
    {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);

        type.InvokeMember("Text", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public, null, o, new object[] { "Windows Developer Magazine" });
        string text = (string)type.InvokeMember("Text", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, null, o, new object[] { });
        Console.WriteLine(text);

    }
    private static void OnChanged(object sender, System.EventArgs e)
    {
        Console.WriteLine(((MyClass)sender).Text);
    }
}
public class MyClass
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            OnChanged();
        }
    }

    private void OnChanged()
    {
        if (Changed != null)
            Changed(this, System.EventArgs.Empty);
    }

    public event EventHandler Changed;
}
-----------------------------
using System;
class MainApp 
{
    public static void Main()
    {
        try
        {
            string myString1 ="DIRECT.ddPalette.3"; 
            string myString2 ="WrongProgramID"; 
            Type myType1 =Type.GetTypeFromProgID(myString1,true);
            Console.WriteLine("GUID for ProgramID DirControl.DirList.1 is {0}.", myType1.GUID);
            Type myType2 =Type.GetTypeFromProgID(myString2,true);
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Source: {0}", e.Source);
            Console.WriteLine("Message: {0}", e.Message);
        }
    }
}
-------------------------------
using System;
using System.Reflection;
public class MyClass 
{
    public class NestClass 
    {
        public static int myPublicInt=0;
    }
    public struct NestStruct
    {
        public static int myPublicInt=0;
    }
}

public class MyMainClass 
{
    public static void Main() 
    {
        Type myType=typeof(MyClass);
        Type[] nestType=myType.GetNestedTypes();
        Console.WriteLine("The number of nested types is {0}.", nestType.Length);
        foreach(Type t in nestType)
            Console.WriteLine("Nested type is {0}.", t.ToString());
    }
}
--------------------------------
using System;
class MainClass
{
    public static void Main()
    {
            Guid myGuid1 = new Guid("1DCD0710-0B41-11D3-A565-00C04F8EF6E3");
            Type myType1 =Type.GetTypeFromCLSID(myGuid1, true);
            Console.WriteLine("The GUID associated with myType1 is {0}.", myType1.GUID);
            Console.WriteLine("The type of the GUID is {0}.", myType1.ToString());
    }
}
*/