// j2sc#1106d.cs: SortedList anahtar-de�er �iftiyle otomatik s�ral� liste �rne�i.

using System;
using System.Collections; //SortedList i�in
using System.Globalization; //CultureInfo i�in
namespace VeriYap�lar� {
    class VeriYap�s�6D {
        public static void G�ster (SortedList sLst) {
            Console.WriteLine ("ANAHTAR...: DE�ER");
            for (int i = 0; i < sLst.Count; i++) Console.WriteLine ("{0,-10}: {1}", sLst.GetKey (i), sLst.GetByIndex (i));
        }
        static void Main() {
            Console.Write ("SortedList/S�ral�Liste'ye girilen anahtar-de�er �ifti varsay�l�, yerel alfabedeki k���k/b�y�k-harfe duyars�z artan s�ralan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�ral�Liste ascii d�zende artan s�ralan�r:");
            SortedList sLst1 = new SortedList (3); //�lk tan�ml� kapasite, Add'lerle a��labilir.
            Console.WriteLine ("\tS�ral� listenin ilk kapasite ve say�s�: ({0}, {1})", sLst1.Capacity, sLst1.Count); //Count, tan�mlanan� de�il girilen eleman say�s�n� verir
            sLst1.Add ("�LK", "Merhaba");
            sLst1.Add ("�K�NC�", "d�nya");
            sLst1.Add ("���NC�", "nas�ls�n");
            sLst1.Add ("D�RD�NC�", "?");
            sLst1.Add ("ilk", "Hurra!");
            G�ster (sLst1);
            Console.WriteLine ("\tS�ral� listenin son kapasite ve say�s�: ({0}, {1})", sLst1.Capacity, sLst1.Count);
            SortedList sLst1a = new SortedList (new CaseInsensitiveComparer(), 3);
            sLst1a=sLst1;
            Console.WriteLine ("\tVarsay�l� k���k/b�y�k-duyars�z k�yasc�:");
            G�ster (sLst1a);
            CultureInfo trK�lt�r = new CultureInfo ("tr-TR");
            SortedList sLst1b = new SortedList (new CaseInsensitiveComparer (trK�lt�r), 3);
            sLst1b=sLst1;
            Console.WriteLine ("\t'tr-TR' k���k/b�y�k-duyars�z k�yasc�:");
            G�ster (sLst1b);
            SortedList sLst1c = new SortedList (StringComparer.InvariantCultureIgnoreCase, 3);
            sLst1c=sLst1;
            Console.WriteLine ("\tK�lt�rs�z k���k/b�y�k-duyars�z k�yasc�:");
            G�ster (sLst1c);

            Console.WriteLine ("\nForeach ve for'la endeks, anahtar ve de�er ��kt�lama:");
            SortedList sLst2 = new SortedList();
            sLst2.Add ("e", "14"); sLst2.Add ("a", "10"); sLst2.Add ("c", "12"); sLst2.Add ("b", "11"); sLst2.Add ("d", "13");
            Console.WriteLine ("\tDizge foreach-anahtarla ��kt�lama:");
            foreach (string dzg in sLst2.Keys) Console.WriteLine ("(anahtar, de�er, endeks) = ({0}, {1}, {2})", dzg, sLst2 [dzg], sLst2.IndexOfKey (dzg));
            Console.WriteLine ("\tTamsay� for-endeksle ��kt�lama:");
            int i; for(i=0;i<sLst2.Count;i++) Console.WriteLine ("(endeks, anahtar, de�er) = ({0}, {1}, {2})", i, sLst2.GetKey (i), sLst2.GetByIndex (i));

            Console.WriteLine ("\n5 ABD eyaletli S�ral�Liste'yle i�lemler:");
            SortedList sLst3 = new SortedList();
            sLst3.Add ("NY", "New York"); sLst3.Add ("FL", "Florida"); sLst3.Add ("AL", "Alabama"); sLst3.Add ("WY", "Wyoming"); sLst3.Add ("CA", "California");
            Console.WriteLine ("\tForeach'le ayr� ayr� anahtar ve de�erleri ��kt�lama:");
            foreach (string anahtar in sLst3.Keys) Console.WriteLine ("anahtar = " + anahtar);
            foreach (string de�er in sLst3.Values) Console.WriteLine ("de�er = " + de�er);
            Console.WriteLine ("==>'NY' anahtar endeksli eyaletim = " + sLst3 ["NY"]);
            Console.WriteLine ("==>'Florida' eyaleti mevcut mu? {0}", sLst3.ContainsValue ("Florida")?"Evet":"Hay�r");
            Console.WriteLine ("==>'Boston' eyaleti mevcut mu? {0}", sLst3.ContainsValue ("Boston")?"Evet":"Hay�r");
            Console.WriteLine ("==>0.endeksinin anahtar� = {0}", sLst3.GetKey (0));
            Console.WriteLine ("==>0.endeksinin de�eri = {0}", sLst3.GetByIndex (0));
            Console.WriteLine ("==>'WY' anahtar�n�n endeksi = {0}", sLst3.IndexOfKey ("WY"));
            Console.WriteLine ("==>'Wyoming' de�erinin endeksi = {0}", sLst3.IndexOfValue ("Wyoming"));
            Console.Write ("Anahtarlar listesi: "); foreach (string a in sLst3.GetKeyList()) Console.Write (a+" "); Console.WriteLine();
            Console.Write ("De�erler listesi: "); foreach (string d in sLst3.GetValueList()) Console.Write (d+" "); Console.WriteLine();
            Console.Write ("Sil 'AL': "); sLst3.Remove ("AL"); for(i=0;i<sLst3.Count;i++)  Console.Write ("{0}={1} ", sLst3.GetKey (i), sLst3.GetByIndex (i)); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
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