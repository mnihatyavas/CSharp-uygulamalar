// j2sc#1901f.cs: Kurucu ve desteklenen t�m metotlar�n parametreleri �rne�i.

using System;
using System.Reflection; //ConstructorInfo ve ParameterInfo i�in
using System.Collections.Generic; // Soysal List<> i�in
namespace TipBilgileri {
    class S�n�fA {
        public S�n�fA (int i) {Console.WriteLine ("Tek parametreli 'S�n�fA (int)' kuruluyor.");} //Kurucu-1
        public S�n�fA (int i, int j) {Console.WriteLine ("�ki parametreli 'S�n�fA (int, int)' kuruluyor.");} //Kurucu-2
        public S�n�fA (int i, int j, string dzg) {Console.WriteLine ("�� parametreli 'S�n�fA (int, int, string)' kuruluyor.");} //Kurucu-3
    }
    class S�n�fB {
        int a=0, b=0;
        public S�n�fB (int i, int j) {a=i; b=j;} //Kurucu
        public int topla() {return(a+b);}
        public bool aras�M� (int x) {if(x>=a & x<=b) return true; return false;}
        public void �arp (int a, int b) {Console.WriteLine ("{0} * {1} = {2}", a, b, a*b);}
        public void �arp (double a, double b) {Console.WriteLine ("{0} * {1} = {2}", a, b, a*b);}
        public void g�ster() {Console.WriteLine ("(a, b) = ({0}, {1})", a, b);}
    }
    class Parametre {
        private static void TipParametreleriniYaz (Type t) {
            Console.WriteLine ("==>Tiplemenin tam ad�: "+t.FullName);
            foreach (Type tp in t.GetGenericArguments()) {
                Console.WriteLine ("Arg�man�n tam ad�: "+tp.FullName);
                Console.WriteLine ("Soysal parametre mi? "+tp.IsGenericParameter);
                if (tp.IsGenericParameter) {
                    Type[] s�n�rlar = tp.GetGenericParameterConstraints();
                    Console.WriteLine ("\t-->Soysal parametre s�n�rlamalar�:");
                    foreach (Type s�n�r in s�n�rlar) Console.WriteLine ("\t"+s�n�r.FullName);
                }
            }
        }
        static void Main() {
            Console.Write ("S�n�f kurucular� 'ConstructorInfo[] ci = tip.GetConstructors()' ile, kurucu parametreleri de 'ParameterInfo[] pi =  ci [i].GetParameters()' ile tespit edilir. Nesne tipli diziye uyumlu tip arg�manlar atay�p, istenen kurucu 'ci[i].Invoke(krcArgDizi)' ile �a�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fA'n�n �� parametreli kurucusu bulunup �a�r�l�yor:");
            Type tip = typeof (S�n�fA);
            int i;
            ConstructorInfo[] ci = tip.GetConstructors();
            ParameterInfo[] pi;
            for(i=0;i<ci.Length;i++) {
                pi =  ci [i].GetParameters();
                if (pi.Length == 3) break;
            }
            if (i == ci.Length) {Console.WriteLine ("�� parametli kurucu bulunamad�.");
            }else  {Console.WriteLine ("�� parametli kurucu bulundu."); 
                object[] krcArg = new object [3];
                krcArg [0] = 1881;
                krcArg [1] = 1938;
                krcArg [2] = "M.Kemal Atat�rk";
                ci [i].Invoke (krcArg);
            }

            Console.WriteLine ("\nTiplemelerin ad�, tamad�, soysal m�, true'ysa s�n�rlamalar�:");
            TipParametreleriniYaz (typeof (List<>));
            TipParametreleriniYaz (typeof (List<int>));
            TipParametreleriniYaz (typeof (Nullable<>));

            Console.WriteLine ("\nS�n�fB'nin tipli parametreli t�m metotlar�n�n sunulmas� ve �a�r�lmas�:");
            tip = typeof (S�n�fB);     
            MethodInfo[] mi = tip.GetMethods();
            foreach (MethodInfo mb in mi) {
                Console.Write (mb.ReturnType.Name + " " + mb.Name + "("); 
                pi = mb.GetParameters();
                for(i=0;i<pi.Length;i++) {
                    Console.Write (pi [i].ParameterType.Name + " " + pi [i].Name);
                    if (i+1 < pi.Length) Console.Write (", "); //Parametreler aras�
                } Console.WriteLine (")"); //Parametreler sonu, sat�rba��
            }
            int ts1=1881, ts2=1938; double ds1, ds2;
            S�n�fB snfB=new S�n�fB (ts1, ts2);
            Console.WriteLine ("{0} + {1} = {2}", ts1, ts2, snfB.topla());
            Console.WriteLine ("{0} aras�M�({1}, {2})? {3}", 1923, ts1, ts2, snfB.aras�M� (1923));
            Console.WriteLine ("{0} aras�M�({1}, {2})? {3}", 2024, ts1, ts2, snfB.aras�M� (2024));
            snfB.g�ster();
            ts1=1299; ts2=1453; snfB.�arp (ts1, ts2);
            ds1=1453.0845; ds2=2024.1755; snfB.�arp (ds1, ds2);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}