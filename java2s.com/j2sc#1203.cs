// j2sc#1203.cs: Assembly kurulumlar�n�n �zelliklerinin sunulmas� �rne�i.

using System;
using System.Reflection; //AssemblyVersionAttribute i�in
using System.Threading; //Thread ve ThreadPool i�in
using System.Security.Policy; //Evidence i�in
using System.Collections; //IEnumerator i�in
[assembly:AssemblyVersionAttribute ("1.2.3.4")]
[assembly:AssemblyTitleAttribute ("j2sc#1203")]
namespace Kurulum {
   class Kurgu3 {
        static void Main (string[] arg) {
            Console.Write ("[assembly] beyan� aduzam alt�na konursa g�zard� edilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nOlu�turulan kurulumlar�n t�m �zelliklerinin d�k�mleri:");
            Version s�r�m = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine ("Kurulum s�r�m no = [{0}]", s�r�m.ToString());
            Console.WriteLine ("S�r�m [Major.Minor.Build.Revision] = [{0}.{1}.{2}.{3}]", s�r�m.Major, s�r�m.Minor, s�r�m.Build, s�r�m.Revision);
            AssemblyName krgAd� = AssemblyName.GetAssemblyName ("C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll");
            Console.WriteLine ("mscorlib.dll kurgusunun s�r�m� = {0}", krgAd�.Version.ToString());
            Assembly kurgu = Assembly.GetEntryAssembly();
            Console.WriteLine ("GetEntryAssembly() kurulumunun tam ad� = " + kurgu.FullName);
            Console.WriteLine ("GetCallingAssembly() kurulumunun tam ad� = " + Assembly.GetCallingAssembly().FullName);
            ThreadPool.QueueUserWorkItem (delegate {Console.WriteLine ("ThreadPool'lu GetCallingAssembly() kurulumunun tam ad� = " + Assembly.GetCallingAssembly().FullName);}); Thread.Sleep (100);
            Assembly[] krgDizi = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine ("\tProgamdaki mevcut t�m kurgular�n listesi:");
            foreach (Assembly krg in krgDizi) Console.WriteLine (krg.GetName());
            string kurgu2 = "System.Data,Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Console.WriteLine (kurgu = Assembly.Load (kurgu2));
            //"c\c#> j2sc#1203 j2sc#1203.exe" arg�man�yla �al��t�r�lmal�
            if (arg.Length > 0) kurgu = Assembly.LoadFrom (arg [0]);
            Evidence kan�t = kurgu.Evidence;
            IEnumerator ien = kan�t.GetHostEnumerator();
            Console.WriteLine ("\tHostEidence/SunucuKan�t koleksiyonu:");
            while (ien.MoveNext()) Console.WriteLine (ien.Current.ToString());
            Assembly XMLKurgu;
            Type[] XMLTipler;
            XMLKurgu = Assembly.Load ("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            XMLTipler = XMLKurgu.GetExportedTypes();
            Console.WriteLine ("\tProgramda mevcut XMLTipler'in uzun-uzun d�k�m�:");
            Console.Write ("Tu�..."); Console.ReadKey();
            object nesne;
            foreach (Type XMLTip in XMLTipler) {
                Console.Write ("==>"+XMLTip.ToString());
                try {nesne = XMLKurgu.CreateInstance (XMLTip.ToString());
                    if (nesne != null) Console.WriteLine (" - XML tip yarat�m� BA�ARILI");
                    else Console.WriteLine (" - XML tip yarat�m HATASI");
                }catch (Exception ht) {Console.WriteLine ("HATA:N[{0}]", ht.Message);}
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
/*
using System;
using System.Reflection;

[assembly:AssemblyVersionAttribute("1.2.3.4")]
[assembly:AssemblyTitleAttribute("Example")]

class MainClass
{
  public static void Main() 
  {
    
    Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
    Console.WriteLine(v.ToString());
    Console.WriteLine(v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision);
    
  }

}
1.2.3.4
1.2.3.4
------------------------------
using System;
using System.Reflection;

class MainClass
{
  public static void Main() 
  {
    AssemblyName anm = AssemblyName.GetAssemblyName("c:\\winnt\\microsoft.net\\framework\\v1.0.3705\\mscorlib.dll");
    Console.WriteLine(anm.Version.ToString());
  }
}
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
        Assembly a2 = Assembly.GetEntryAssembly();
        Console.WriteLine(a2.FullName);
        
    }
}
main, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
-----------------------------------
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
        Assembly a3 = Assembly.GetCallingAssembly();
        Console.WriteLine(a3.FullName);
        
    }
}
main, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
----------------------------------
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
        ThreadPool.QueueUserWorkItem(delegate {
            Console.WriteLine(Assembly.GetCallingAssembly().FullName);
        });
        Thread.Sleep(100);
    }
}
mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
------------------------------
using System;
using System.Reflection;
using System.Globalization;

class MainClass
{
   public static void Main(){
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (Assembly a in assemblies)
        {
            Console.WriteLine(a.GetName());
        }
   }
}
mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
main, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
---------------------------------
using System;
using System.Reflection;
using System.Globalization;

class MainClass
{
    public static void Main()
    {
        string name1 = "System.Data,Version=2.0.0.0," + 
            "Culture=neutral,PublicKeyToken=b77a5c561934e089";
        Assembly a1 = Assembly.Load(name1);

    }
}
-----------------------------
using System;
using System.Reflection;
using System.Collections;
using System.Security.Policy;

public class MainClass {
    public static void Main(string[] args) {
        Assembly a = Assembly.LoadFrom(args[0]);
        Evidence e = a.Evidence;

        IEnumerator x = e.GetHostEnumerator();
        Console.WriteLine("HOST EVIDENCE COLLECTION:");
        while (x.MoveNext()) {
            Console.WriteLine(x.Current.ToString());
        }
    }
}
--------------------------------
using System;
using System.Reflection;
using System;
using System.Reflection;

public class MainClass
{
  static void Main(string[] args)
  {
    Assembly EntryAssembly;

    EntryAssembly = Assembly.GetEntryAssembly();
    if(EntryAssembly.EntryPoint == null)
      Console.WriteLine("The assembly has no entry point.");
    else
      Console.WriteLine(EntryAssembly.EntryPoint.ToString());
  }
}
-----------------------------------
using System;
using System.Reflection;

public class MainClass
{
  static void Main(string[] args)
  {
    Assembly XMLAssembly;
    Type[] XMLTypes;

    XMLAssembly = Assembly.Load("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
    XMLTypes = XMLAssembly.GetExportedTypes();
    foreach(Type XMLType in XMLTypes)
    {
      object NewObject;

      Console.Write(XMLType.ToString());
      NewObject = XMLAssembly.CreateInstance(XMLType.ToString());
      if(NewObject != null)
        Console.WriteLine(" - Creation successful");
      else
        Console.WriteLine(" - CREATION ERROR");
    }
  }
}
*/