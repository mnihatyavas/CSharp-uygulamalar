// j2sc#1106d.cs: SortedList anahtar-deðer çiftiyle otomatik sýralý liste örneði.

using System;
using System.Collections; //SortedList için
using System.Globalization; //CultureInfo için
namespace VeriYapýlarý {
    class VeriYapýsý6D {
        public static void Göster (SortedList sLst) {
            Console.WriteLine ("ANAHTAR...: DEÐER");
            for (int i = 0; i < sLst.Count; i++) Console.WriteLine ("{0,-10}: {1}", sLst.GetKey (i), sLst.GetByIndex (i));
        }
        static void Main() {
            Console.Write ("SortedList/SýralýListe'ye girilen anahtar-deðer çifti varsayýlý, yerel alfabedeki küçük/büyük-harfe duyarsýz artan sýralanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýralýListe ascii düzende artan sýralanýr:");
            SortedList sLst1 = new SortedList (3); //Ýlk tanýmlý kapasite, Add'lerle aþýlabilir.
            Console.WriteLine ("\tSýralý listenin ilk kapasite ve sayýsý: ({0}, {1})", sLst1.Capacity, sLst1.Count); //Count, tanýmlananý deðil girilen eleman sayýsýný verir
            sLst1.Add ("ÝLK", "Merhaba");
            sLst1.Add ("ÝKÝNCÝ", "dünya");
            sLst1.Add ("ÜÇÜNCÜ", "nasýlsýn");
            sLst1.Add ("DÖRDÜNCÜ", "?");
            sLst1.Add ("ilk", "Hurra!");
            Göster (sLst1);
            Console.WriteLine ("\tSýralý listenin son kapasite ve sayýsý: ({0}, {1})", sLst1.Capacity, sLst1.Count);
            SortedList sLst1a = new SortedList (new CaseInsensitiveComparer(), 3);
            sLst1a=sLst1;
            Console.WriteLine ("\tVarsayýlý küçük/büyük-duyarsýz kýyascý:");
            Göster (sLst1a);
            CultureInfo trKültür = new CultureInfo ("tr-TR");
            SortedList sLst1b = new SortedList (new CaseInsensitiveComparer (trKültür), 3);
            sLst1b=sLst1;
            Console.WriteLine ("\t'tr-TR' küçük/büyük-duyarsýz kýyascý:");
            Göster (sLst1b);
            SortedList sLst1c = new SortedList (StringComparer.InvariantCultureIgnoreCase, 3);
            sLst1c=sLst1;
            Console.WriteLine ("\tKültürsüz küçük/büyük-duyarsýz kýyascý:");
            Göster (sLst1c);

            Console.WriteLine ("\nForeach ve for'la endeks, anahtar ve deðer çýktýlama:");
            SortedList sLst2 = new SortedList();
            sLst2.Add ("e", "14"); sLst2.Add ("a", "10"); sLst2.Add ("c", "12"); sLst2.Add ("b", "11"); sLst2.Add ("d", "13");
            Console.WriteLine ("\tDizge foreach-anahtarla çýktýlama:");
            foreach (string dzg in sLst2.Keys) Console.WriteLine ("(anahtar, deðer, endeks) = ({0}, {1}, {2})", dzg, sLst2 [dzg], sLst2.IndexOfKey (dzg));
            Console.WriteLine ("\tTamsayý for-endeksle çýktýlama:");
            int i; for(i=0;i<sLst2.Count;i++) Console.WriteLine ("(endeks, anahtar, deðer) = ({0}, {1}, {2})", i, sLst2.GetKey (i), sLst2.GetByIndex (i));

            Console.WriteLine ("\n5 ABD eyaletli SýralýListe'yle iþlemler:");
            SortedList sLst3 = new SortedList();
            sLst3.Add ("NY", "New York"); sLst3.Add ("FL", "Florida"); sLst3.Add ("AL", "Alabama"); sLst3.Add ("WY", "Wyoming"); sLst3.Add ("CA", "California");
            Console.WriteLine ("\tForeach'le ayrý ayrý anahtar ve deðerleri çýktýlama:");
            foreach (string anahtar in sLst3.Keys) Console.WriteLine ("anahtar = " + anahtar);
            foreach (string deðer in sLst3.Values) Console.WriteLine ("deðer = " + deðer);
            Console.WriteLine ("==>'NY' anahtar endeksli eyaletim = " + sLst3 ["NY"]);
            Console.WriteLine ("==>'Florida' eyaleti mevcut mu? {0}", sLst3.ContainsValue ("Florida")?"Evet":"Hayýr");
            Console.WriteLine ("==>'Boston' eyaleti mevcut mu? {0}", sLst3.ContainsValue ("Boston")?"Evet":"Hayýr");
            Console.WriteLine ("==>0.endeksinin anahtarý = {0}", sLst3.GetKey (0));
            Console.WriteLine ("==>0.endeksinin deðeri = {0}", sLst3.GetByIndex (0));
            Console.WriteLine ("==>'WY' anahtarýnýn endeksi = {0}", sLst3.IndexOfKey ("WY"));
            Console.WriteLine ("==>'Wyoming' deðerinin endeksi = {0}", sLst3.IndexOfValue ("Wyoming"));
            Console.Write ("Anahtarlar listesi: "); foreach (string a in sLst3.GetKeyList()) Console.Write (a+" "); Console.WriteLine();
            Console.Write ("Deðerler listesi: "); foreach (string d in sLst3.GetValueList()) Console.Write (d+" "); Console.WriteLine();
            Console.Write ("Sil 'AL': "); sLst3.Remove ("AL"); for(i=0;i<sLst3.Count;i++)  Console.Write ("{0}={1} ", sLst3.GetKey (i), sLst3.GetByIndex (i)); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
/*
using System;
using System.Collections;
using System.Globalization;

public class SamplesSortedList
{
    public static void Main()
    {

        SortedList mySL1 = new SortedList( 3 );
        Console.WriteLine("mySL1 (default):");
        mySL1.Add("FIRST", "Hello");
        mySL1.Add("SECOND", "World");
        mySL1.Add("THIRD", "!");
        try
        {
            mySL1.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL1);

    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("        -KEY-   -VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine("{0,-6}: {1}",myList.GetKey(i), myList.GetByIndex(i));
        }
    }
}
-----------------------------------
using System;
using System.Collections;
using System.Globalization;

public class SamplesSortedList
{
    public static void Main()
    {
        SortedList mySL2 = new SortedList(new CaseInsensitiveComparer(), 3);
        Console.WriteLine("mySL2 (case-insensitive comparer):");
        mySL2.Add("FIRST", "Hello");
        mySL2.Add("SECOND", "World");
        mySL2.Add("THIRD", "!");
        try
        {
            mySL2.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL2);

    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("        -KEY-   -VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine("{0,-6}: {1}",myList.GetKey(i), myList.GetByIndex(i));
        }
    }
}
-----------------------------------
using System;
using System.Collections;
using System.Globalization;

public class SamplesSortedList
{
    public static void Main()
    {
        CultureInfo myCul = new CultureInfo("tr-TR");
        SortedList mySL3 = new SortedList(new CaseInsensitiveComparer(myCul), 3);

        Console.WriteLine("mySL3 (case-insensitive comparer, Turkish culture):");

        mySL3.Add("FIRST", "Hello");
        mySL3.Add("SECOND", "World");
        mySL3.Add("THIRD", "!");
        try{
            mySL3.Add("first", "Ola!");
        }catch (ArgumentException e){
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL3);

    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("        -KEY-   -VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine("{0,-6}: {1}",myList.GetKey(i), myList.GetByIndex(i));
        }
    }
}
----------------------------------
using System;
using System.Collections;
using System.Globalization;

public class SamplesSortedList
{
    public static void Main()
    {
        SortedList mySL4 = new SortedList(StringComparer.InvariantCultureIgnoreCase, 3);

        Console.WriteLine("mySL4 (InvariantCultureIgnoreCase):");
        mySL4.Add("FIRST", "Hello");
        mySL4.Add("SECOND", "World");
        mySL4.Add("THIRD", "!");
        try
        {
            mySL4.Add("first", "Ola!");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        PrintKeysAndValues(mySL4);

    }

    public static void PrintKeysAndValues(SortedList myList)
    {
        Console.WriteLine("        -KEY-   -VALUE-");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine("{0,-6}: {1}",myList.GetKey(i), myList.GetByIndex(i));
        }
    }
}
--------------------------------
using System; 
using System.Collections; 
 
class MainClass { 
  public static void Main() { 
    SortedList sl = new SortedList(); 
     
    sl.Add("a", "A"); 
    sl.Add("b", "B"); 
    sl.Add("c", "C"); 
    sl.Add("d", "D"); 
 
    // Get a collection of the keys. 
    ICollection c = sl.Keys; 
 
    // Display list using integer indexes. 
    Console.WriteLine("Contents by integer indexes."); 
    for(int i=0; i<sl.Count; i++) 
      Console.WriteLine(sl.GetByIndex(i)); 
      
  }
}
Contents by integer indexes.
A
B
C
D
-------------------------------
using System; 
using System.Collections; 
 
class MainClass { 
  public static void Main() { 
    SortedList sl = new SortedList(); 
     
    sl.Add("a", "A"); 
    sl.Add("b", "B"); 
    sl.Add("c", "C"); 
    sl.Add("d", "D"); 

    // add by using the indexer. 
    sl["e"] = "E"; 
 
    // Get a collection of the keys. 
    ICollection c = sl.Keys; 
 
    // Display list using integer indexes. 
    Console.WriteLine("Contents by integer indexes."); 
    for(int i=0; i<sl.Count; i++) 
      Console.WriteLine(sl.GetByIndex(i)); 
      
  }
}
Contents by integer indexes.
A
B
C
D
E
-----------------------------
using System; 
using System.Collections; 
 
class MainClass { 
  public static void Main() { 
    SortedList sl = new SortedList(); 
     
    sl.Add("a", "1"); 
    sl.Add("b", "2"); 
    sl.Add("c", "3"); 
    sl.Add("d", "4"); 
 
    Console.WriteLine(); 
 
    // Show integer indexes of entries. 
    Console.WriteLine("Integer indexes of entries."); 
    foreach(string str in sl.Keys) 
      Console.WriteLine(str + ": " + sl.IndexOfKey(str)); 
  } 
}
Integer indexes of entries.
a: 0
b: 1
c: 2
d: 3
------------------------------
using System;
using System.Collections;

class MainClass
{
  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    string myState = (string) mySortedList["CA"];
    Console.WriteLine("myState = " + myState);

    // display the keys for mySortedList using the Keys property
    foreach (string myKey in mySortedList.Keys) {
      Console.WriteLine("myKey = " + myKey);
    }

    // display the values for mySortedList using the Values property
    foreach(string myValue in mySortedList.Values) {
      Console.WriteLine("myValue = " + myValue);
    }
  }
}
myState = California
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
-------------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    
    if (mySortedList.ContainsValue("Florida"))
    {
      Console.WriteLine("mySortedList contains the value Florida");
    }
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
mySortedList contains the value Florida
---------------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    
    Console.WriteLine("Removing FL from mySortedList");
    mySortedList.Remove("FL");
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
Removing FL from mySortedList
-------------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    
    string keyAtIndex3 = (string) mySortedList.GetKey(3);
    Console.WriteLine("The key at index 3 is " + keyAtIndex3);
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
The key at index 3 is NY
--------------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    
    int myIndex = mySortedList.IndexOfKey("NY");
    Console.WriteLine("The index of NY is " + myIndex);
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
The index of NY is 3
---------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    int myIndex = mySortedList.IndexOfValue("New York");
    Console.WriteLine("The index of New York is " + myIndex);
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
The index of New York is 3
------------------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    Console.WriteLine("Getting the key list");
    IList myKeyList = mySortedList.GetKeyList();
    foreach(string myKey in myKeyList)
    {
      Console.WriteLine("myKey = " + myKey);
    }
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
Getting the key list
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
-----------------------
using System;
using System.Collections;

class MainClass
{

  public static void Main()
  {
    SortedList mySortedList = new SortedList();

    mySortedList.Add("NY", "New York");
    mySortedList.Add("FL", "Florida");
    mySortedList.Add("AL", "Alabama");
    mySortedList.Add("WY", "Wyoming");
    mySortedList.Add("CA", "California");

    foreach (string myKey in mySortedList.Keys)
    {
      Console.WriteLine("myKey = " + myKey);
    }

    foreach(string myValue in mySortedList.Values)
    {
      Console.WriteLine("myValue = " + myValue);
    }
    Console.WriteLine("Getting the value list");
    IList myValueList = mySortedList.GetValueList();
    foreach(string myValue in myValueList)
    {
      Console.WriteLine("myValue = " + myValue);
    }
  }
}
myKey = AL
myKey = CA
myKey = FL
myKey = NY
myKey = WY
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
Getting the value list
myValue = Alabama
myValue = California
myValue = Florida
myValue = New York
myValue = Wyoming
*/