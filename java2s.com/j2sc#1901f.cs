// j2sc#1901f.cs: Kurucu ve desteklenen tüm metotlarýn parametreleri örneði.

using System;
using System.Reflection; //ConstructorInfo ve ParameterInfo için
using System.Collections.Generic; // Soysal List<> için
namespace TipBilgileri {
    class SýnýfA {
        public SýnýfA (int i) {Console.WriteLine ("Tek parametreli 'SýnýfA (int)' kuruluyor.");} //Kurucu-1
        public SýnýfA (int i, int j) {Console.WriteLine ("Ýki parametreli 'SýnýfA (int, int)' kuruluyor.");} //Kurucu-2
        public SýnýfA (int i, int j, string dzg) {Console.WriteLine ("Üç parametreli 'SýnýfA (int, int, string)' kuruluyor.");} //Kurucu-3
    }
    class SýnýfB {
        int a=0, b=0;
        public SýnýfB (int i, int j) {a=i; b=j;} //Kurucu
        public int topla() {return(a+b);}
        public bool arasýMý (int x) {if(x>=a & x<=b) return true; return false;}
        public void çarp (int a, int b) {Console.WriteLine ("{0} * {1} = {2}", a, b, a*b);}
        public void çarp (double a, double b) {Console.WriteLine ("{0} * {1} = {2}", a, b, a*b);}
        public void göster() {Console.WriteLine ("(a, b) = ({0}, {1})", a, b);}
    }
    class Parametre {
        private static void TipParametreleriniYaz (Type t) {
            Console.WriteLine ("==>Tiplemenin tam adý: "+t.FullName);
            foreach (Type tp in t.GetGenericArguments()) {
                Console.WriteLine ("Argümanýn tam adý: "+tp.FullName);
                Console.WriteLine ("Soysal parametre mi? "+tp.IsGenericParameter);
                if (tp.IsGenericParameter) {
                    Type[] sýnýrlar = tp.GetGenericParameterConstraints();
                    Console.WriteLine ("\t-->Soysal parametre sýnýrlamalarý:");
                    foreach (Type sýnýr in sýnýrlar) Console.WriteLine ("\t"+sýnýr.FullName);
                }
            }
        }
        static void Main() {
            Console.Write ("Sýnýf kurucularý 'ConstructorInfo[] ci = tip.GetConstructors()' ile, kurucu parametreleri de 'ParameterInfo[] pi =  ci [i].GetParameters()' ile tespit edilir. Nesne tipli diziye uyumlu tip argümanlar atayýp, istenen kurucu 'ci[i].Invoke(krcArgDizi)' ile çaðrýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýfA'nýn Üç parametreli kurucusu bulunup çaðrýlýyor:");
            Type tip = typeof (SýnýfA);
            int i;
            ConstructorInfo[] ci = tip.GetConstructors();
            ParameterInfo[] pi;
            for(i=0;i<ci.Length;i++) {
                pi =  ci [i].GetParameters();
                if (pi.Length == 3) break;
            }
            if (i == ci.Length) {Console.WriteLine ("Üç parametli kurucu bulunamadý.");
            }else  {Console.WriteLine ("Üç parametli kurucu bulundu."); 
                object[] krcArg = new object [3];
                krcArg [0] = 1881;
                krcArg [1] = 1938;
                krcArg [2] = "M.Kemal Atatürk";
                ci [i].Invoke (krcArg);
            }

            Console.WriteLine ("\nTiplemelerin adý, tamadý, soysal mý, true'ysa sýnýrlamalarý:");
            TipParametreleriniYaz (typeof (List<>));
            TipParametreleriniYaz (typeof (List<int>));
            TipParametreleriniYaz (typeof (Nullable<>));

            Console.WriteLine ("\nSýnýfB'nin tipli parametreli tüm metotlarýnýn sunulmasý ve çaðrýlmasý:");
            tip = typeof (SýnýfB);     
            MethodInfo[] mi = tip.GetMethods();
            foreach (MethodInfo mb in mi) {
                Console.Write (mb.ReturnType.Name + " " + mb.Name + "("); 
                pi = mb.GetParameters();
                for(i=0;i<pi.Length;i++) {
                    Console.Write (pi [i].ParameterType.Name + " " + pi [i].Name);
                    if (i+1 < pi.Length) Console.Write (", "); //Parametreler arasý
                } Console.WriteLine (")"); //Parametreler sonu, satýrbaþý
            }
            int ts1=1881, ts2=1938; double ds1, ds2;
            SýnýfB snfB=new SýnýfB (ts1, ts2);
            Console.WriteLine ("{0} + {1} = {2}", ts1, ts2, snfB.topla());
            Console.WriteLine ("{0} arasýMý({1}, {2})? {3}", 1923, ts1, ts2, snfB.arasýMý (1923));
            Console.WriteLine ("{0} arasýMý({1}, {2})? {3}", 2024, ts1, ts2, snfB.arasýMý (2024));
            snfB.göster();
            ts1=1299; ts2=1453; snfB.çarp (ts1, ts2);
            ds1=1453.0845; ds2=2024.1755; snfB.çarp (ds1, ds2);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}