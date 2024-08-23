// j2sc#1902b.cs: Aray�z metotlar� ve soysal delege fonksiyon gerid�n��leri �rne�i.

using System;
using System.Reflection; //MethodInfo i�in
namespace Tipli��lemler {
    public interface Aray�z1 {void MetodA1(); void MetodA2();}
    public interface Aray�z2 {void MetodB();}
    public interface Aray�z3 {void MetodC1(); void MetodC2();}
    public class S�n�fA: Aray�z1, Aray�z2, Aray�z3 {
        //public enum enumAlan{}
        int intAlan;
        string strAlan;
        public int IntAlan {get {return intAlan;} set {intAlan = value;}}
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        public void Metod (int p1, string p2){}
        void Aray�z1.MetodA1(){} void Aray�z1.MetodA2(){}
        void Aray�z2.MetodB(){}
        void Aray�z3.MetodC1(){} void Aray�z3.MetodC2(){}
    }
    delegate T FonkA<T>();
    class Aray�z {
        static void DelegeliYaz<T> (FonkA<T> fnkA) {Console.WriteLine (fnkA());}
        static void Main() {
            Console.Write ("Aray�z �ablon metotlar� ebeveyn s�n�flarda Aray�z.Metod(){} olarak i�i bo�/dolu tan�mlanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fA'n�n aray�z ebeveynleri, metotlar�, alan-int/str �zellikleri:");
            int i, j;
            S�n�fA snfA = new S�n�fA();
            Type tip = snfA.GetType();
            Type[] aray�zler = tip.GetInterfaces();
            MethodInfo[] snfMtd; MethodInfo[] ayzMtd;
            for(i = 0;i<aray�zler.Length;i++) {
                Console.WriteLine ("{0}", aray�zler [i]);
                snfMtd = tip.GetInterfaceMap (aray�zler [i]).TargetMethods;
                foreach (MethodInfo mi in snfMtd) Console.WriteLine ("\t{0}", mi);
                ayzMtd = tip.GetInterfaceMap (aray�zler [i]).InterfaceMethods;
                foreach (MethodInfo mi in ayzMtd) Console.WriteLine ("\t\t{0}", mi);
            }
            snfA.IntAlan = 1881; snfA.StrAlan = "Selanik"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1919; snfA.StrAlan = "Samsun"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1923; snfA.StrAlan = "Ankara"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1938; snfA.StrAlan = "�stanbul"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            for(i = 0;i < aray�zler.Length; i ++) {
                Console.WriteLine ("Aray�z ad�: {0}", aray�zler [i]);
                snfMtd = tip.GetInterfaceMap (aray�zler [i]).TargetMethods;
                ayzMtd = tip.GetInterfaceMap (aray�zler [i]).InterfaceMethods;
                for(j = 0; j < snfMtd.Length; j++) {
                    Console.WriteLine ("\tAray�z metodu: {0}",  ayzMtd [j].Name);
                    Console.WriteLine ("\tS�n�f aray�z metodu: {0}", snfMtd [j].Name);
                }
            }
            Console.WriteLine ("Tiplenen s�n�f ad�: {0}", tip.Name);
            Console.WriteLine ("Tiplenen ��i�e�zelMi? {0}", tip.IsNestedPrivate);
            Console.WriteLine ("Tiplenen GenelMi? {0}", tip.IsPublic);

            Console.WriteLine ("\nFarkl� soysal tipli de�erlerin delegeli fonksiyonla yazd�r�lmas�:");
            DelegeliYaz (delegate {return 20240815;});
            DelegeliYaz (delegate {return 20240815.1753d;});
            DelegeliYaz (delegate {return "Atat�rk: 1923";});
            DelegeliYaz (delegate {return long.MaxValue;});
            DelegeliYaz (delegate {return true;});


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}