// j2sc#1203.cs: Assembly kurulumlarýnýn özelliklerinin sunulmasý örneði.

using System;
using System.Reflection; //AssemblyVersionAttribute için
using System.Threading; //Thread ve ThreadPool için
using System.Security.Policy; //Evidence için
using System.Collections; //IEnumerator için
[assembly:AssemblyVersionAttribute ("1.2.3.4")]
[assembly:AssemblyTitleAttribute ("j2sc#1203")]
namespace Kurulum {
   class Kurgu3 {
        static void Main (string[] arg) {
            Console.Write ("[assembly] beyaný aduzam altýna konursa gözardý edilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nOluþturulan kurulumlarýn tüm özelliklerinin dökümleri:");
            Version sürüm = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Console.WriteLine ("Kurulum sürüm no = [{0}]", sürüm.ToString());
            Console.WriteLine ("Sürüm [Major.Minor.Build.Revision] = [{0}.{1}.{2}.{3}]", sürüm.Major, sürüm.Minor, sürüm.Build, sürüm.Revision);
            AssemblyName krgAdý = AssemblyName.GetAssemblyName ("C:/Windows/Microsoft.NET/Framework64/v4.0.30319/mscorlib.dll");
            Console.WriteLine ("mscorlib.dll kurgusunun sürümü = {0}", krgAdý.Version.ToString());
            Assembly kurgu = Assembly.GetEntryAssembly();
            Console.WriteLine ("GetEntryAssembly() kurulumunun tam adý = " + kurgu.FullName);
            Console.WriteLine ("GetCallingAssembly() kurulumunun tam adý = " + Assembly.GetCallingAssembly().FullName);
            ThreadPool.QueueUserWorkItem (delegate {Console.WriteLine ("ThreadPool'lu GetCallingAssembly() kurulumunun tam adý = " + Assembly.GetCallingAssembly().FullName);}); Thread.Sleep (100);
            Assembly[] krgDizi = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine ("\tProgamdaki mevcut tüm kurgularýn listesi:");
            foreach (Assembly krg in krgDizi) Console.WriteLine (krg.GetName());
            string kurgu2 = "System.Data,Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Console.WriteLine (kurgu = Assembly.Load (kurgu2));
            //"c\c#> j2sc#1203 j2sc#1203.exe" argümanýyla çalýþtýrýlmalý
            if (arg.Length > 0) kurgu = Assembly.LoadFrom (arg [0]);
            Evidence kanýt = kurgu.Evidence;
            IEnumerator ien = kanýt.GetHostEnumerator();
            Console.WriteLine ("\tHostEidence/SunucuKanýt koleksiyonu:");
            while (ien.MoveNext()) Console.WriteLine (ien.Current.ToString());
            Assembly XMLKurgu;
            Type[] XMLTipler;
            XMLKurgu = Assembly.Load ("System.Xml, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            XMLTipler = XMLKurgu.GetExportedTypes();
            Console.WriteLine ("\tProgramda mevcut XMLTipler'in uzun-uzun dökümü:");
            Console.Write ("Tuþ..."); Console.ReadKey();
            object nesne;
            foreach (Type XMLTip in XMLTipler) {
                Console.Write ("==>"+XMLTip.ToString());
                try {nesne = XMLKurgu.CreateInstance (XMLTip.ToString());
                    if (nesne != null) Console.WriteLine (" - XML tip yaratýmý BAÞARILI");
                    else Console.WriteLine (" - XML tip yaratým HATASI");
                }catch (Exception ht) {Console.WriteLine ("HATA:N[{0}]", ht.Message);}
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
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