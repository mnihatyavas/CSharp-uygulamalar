// j2sc#0903.cs: Anonim delegeli metotla �slenilen g�revlerin icras� �rne�i.

using System;
namespace YetkiAktarma {
    delegate string DelegeA (string dzg);
    delegate int DelegeB (int i);
    delegate void DelegeC();
    delegate void DelegeD (int i);
    delegate int DelegeE (int i, int j);
    delegate int DelegeF (int i, int j);
    delegate double DelegeG (int i);
    delegate void DelegeH (string msj);
    class Delege3 {
        static DelegeF toplam() {
            DelegeF nesne = delegate (int n, int m) {Console.Write ("[1, {0}] ard���k say�lar�n toplam�: ", n); return m;};
            return nesne;
        }
        static void Alt�stKare (DelegeG dG, int alt, int �st) {for (int i = alt; i <= �st; i++) Console.Write ("{0:0.##} ", dG (i));}
        static void UzunS�renMetot (DelegeH dH) {for (int i = 0; i <101; i++) {if (i % 25 == 0) dH (string.Format ("Tamamlanan i�lem: {0}%", i));}}
        static void Main() {
            Console.Write ("Delegeyi 'new Delege()' veya (metot) atama yada anonim 'delegate(){}' ifadesiyle yaratabiliriz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Delegeye kurucuyla ve parametrik += ile 3 t�mce ekleme:");
            string dzg1 = ", 1881'de Selanik'te do�du,";
            DelegeA dA = delegate (string t�mce) {
                t�mce += dzg1;
                t�mce += " ve 1938'de �stanbul'da vefat etti.";
                return t�mce;
            };
            Console.WriteLine (dA ("Gazi Mustafa Kemal Pa�a: Atat�rk"));

            Console.WriteLine ("\nAnonim delegate(){} tiplemeli d�ng�yle 57'lik saya� art�r�m�:");
            DelegeB dB = delegate (int x) {return 1881+x;};
            int i, j, ts1, ts2;
            for(i=0;i<=57;i++) {Console.Write("{0} ", dB (i));}

            Console.WriteLine ("\n\nAnonim metotla delegeye for-sayac� atama:");
            DelegeC dC = delegate {for(i=1881;i<=1938;i++) Console.Write (i+" ");}; //Delegeye anonim metot atama 
            dC(); //Anonim metotlu delege tiplemesi

            Console.WriteLine ("\n\nDelegeye 3 farkl� anonim metot atama:");
            DelegeD dD = delegate (int n) {Console.Write ("Do�um: "+n);};
            dD (1881);
            dD = delegate (int n) {Console.Write (", "+n);};
            for(i=1882;i<=1937;i++) {dD (i);}
            dD = delegate (int n) {Console.Write (", Vefat: "+n);};
            dD (1938);

            Console.WriteLine ("\n\nAnonim delegeyle rasgele [0,1000] say� toplam�:");
            var r=new Random(); DelegeE dE;
            for(i=0;i<5;i++) {
                ts1=0; ts2=r.Next(0,1000);
                for(j=0;j<=ts2;j++) {ts1+=j;}
                dE=delegate (int n, int m) {Console.Write ("[1, {0}] ard���k say�lar�n toplam�: ", n); return m;};
                j=dE(ts2, ts1); Console.WriteLine (j);
            }

            Console.WriteLine ("\nAnonim delegeyi statik toplam() metota ba�lama:");
            DelegeF dF;
            for(i=0;i<5;i++) {
                ts1=0; ts2=r.Next(0,1000);
                for(j=0;j<=ts2;j++) {ts1+=j;}
                dF=toplam();
                j=dF (ts2, ts1); Console.WriteLine (j);
            }

            ts1=r.Next(0,400); ts2=r.Next(ts1,500);
            Console.WriteLine ("\n\tAnonim delegeli metotla [{0}, {1}] aras� say�lar�n kareleri:", ts1, ts2);
            Alt�stKare (delegate (int x) {return x * x; }, ts1, ts2);
            Console.WriteLine ("\n\tAnonim delegeli metotla [{0}, {1}] aras� say�lar�n karek�kleri:", ts1, ts2);
            Alt�stKare (delegate (int x) {return Math.Sqrt (x); }, ts1, ts2);

            Console.WriteLine ("\n\nAnonim delegeyle i�lenen metot y�zdelerinin g�sterilmesi:");
            DelegeH dH = delegate (string msj) {Console.WriteLine ("[Anonim] {0}", msj);};
            UzunS�renMetot (dH);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
/*

C# / CSharp TutorialdelegateAnonymous delegate
using System;
using System.Collections.Generic;
using System.Text;
class Program {
    delegate string delegateTest(string val);

    static void Main(string[] args) {
        string mid = ", middle part,";

        delegateTest d = delegate(string param) {
            param += mid;
            param += " and this was added to the string.";
            return param;
        };
    }
}
---------------------------------
using System;

class MainClass
{
   delegate int FunctionToCall(int InParam);

   static void Main()
   {
      FunctionToCall del = delegate(int x){
                        return x + 20;
                     };
      Console.WriteLine("{0}", del(5));
      Console.WriteLine("{0}", del(6));
   }
}
25
26
------------------------------
using System;  
  
delegate void Do();  
  
class AnonMethDemo {  
 
  public static void Main() {   
     Do count = delegate {  
      for(int i=0; i <= 5; i++)  
        Console.WriteLine(i); 
    }; 
 
    count();  
  } 
}
0
1
2
3
4
5
------------------------------
using System;  
  
delegate void CountIt(int end);  
  
class MainClass {  
 
  public static void Main() {   
    CountIt count = delegate (int end) { 
        Console.WriteLine("end:"+end); 
    }; 
 
    count(3); 
    count(5);  
  } 
}
end:3
end:5
-----------------------------
using System;  
  
delegate int CountIt(int end);  
  
class MainClass {  
 
  public static void Main() {   
    CountIt count = delegate (int end) { 
      Console.WriteLine("end:"+end);
      return end;
    }; 
 
    int result = count(3); 
    Console.WriteLine("Summation of 3 is " + result); 
 
    result = count(5);  
    Console.WriteLine("Summation of 5 is " + result); 
  } 
}
end:3
Summation of 3 is 3
end:5
Summation of 5 is 5
---------------------------
using System;  
  
delegate int CountIt(int end);
  
class MainClass {  
 
  static CountIt counter() { 
    CountIt ctObj = delegate (int end) { 
      Console.WriteLine("end:"+end);
      return end; 
    }; 
    return ctObj; 
  } 
 
  public static void Main() {   
    CountIt count = counter(); 
 
    int result = count(3); 
    result = count(5);  
  } 
}
end:3
end:5
------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

delegate int IntDelegate(int x);

public class MainClass
{
    static void TransformUpTo(IntDelegate d, int max)
    {
        for (int i = 0; i <= max; i++)
            Console.WriteLine(d(i));
    }

   public static void Main(){
        TransformUpTo(delegate(int x) { return x * x; }, 10);
   }

}
0
1
4
9
16
25
36
49
64
81
100
----------------------------
using System;
using System.Threading;


public delegate void DelegateClass();

public class Starter {
    public static void Main() {
        DelegateClass del = delegate {
            Console.WriteLine("Running anonymous method");
        };
        del();
    }
}
------------------------------
using System;
using System.Collections.Generic;
using System.Text;

    class Program
    {
        delegate void MessagePrintDelegate(string msg);

        static void Main(string[] args)
        {


            MessagePrintDelegate mpd2 = delegate(string msg)
            {
                Console.WriteLine("[Anonymous] {0}", msg);
            };
            LongRunningMethod(mpd2);

        }

        static void LongRunningMethod(MessagePrintDelegate mpd)
        {
            for (int i = 0; i < 99; i++)
            {
                if (i % 25 == 0)
                {
                    mpd(string.Format("Progress Made. {0}% complete.", i));
                }
            }
        }

        static void PrintMessage(string msg)
        {
            Console.WriteLine("[PrintMessage] {0}", msg);
        }
    }
*/