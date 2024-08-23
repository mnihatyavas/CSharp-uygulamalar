// j2sc#1902b.cs: Arayüz metotlarý ve soysal delege fonksiyon geridönüþleri örneði.

using System;
using System.Reflection; //MethodInfo için
namespace TipliÝþlemler {
    public interface Arayüz1 {void MetodA1(); void MetodA2();}
    public interface Arayüz2 {void MetodB();}
    public interface Arayüz3 {void MetodC1(); void MetodC2();}
    public class SýnýfA: Arayüz1, Arayüz2, Arayüz3 {
        //public enum enumAlan{}
        int intAlan;
        string strAlan;
        public int IntAlan {get {return intAlan;} set {intAlan = value;}}
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        public void Metod (int p1, string p2){}
        void Arayüz1.MetodA1(){} void Arayüz1.MetodA2(){}
        void Arayüz2.MetodB(){}
        void Arayüz3.MetodC1(){} void Arayüz3.MetodC2(){}
    }
    delegate T FonkA<T>();
    class Arayüz {
        static void DelegeliYaz<T> (FonkA<T> fnkA) {Console.WriteLine (fnkA());}
        static void Main() {
            Console.Write ("Arayüz þablon metotlarý ebeveyn sýnýflarda Arayüz.Metod(){} olarak içi boþ/dolu tanýmlanmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýfA'nýn arayüz ebeveynleri, metotlarý, alan-int/str özellikleri:");
            int i, j;
            SýnýfA snfA = new SýnýfA();
            Type tip = snfA.GetType();
            Type[] arayüzler = tip.GetInterfaces();
            MethodInfo[] snfMtd; MethodInfo[] ayzMtd;
            for(i = 0;i<arayüzler.Length;i++) {
                Console.WriteLine ("{0}", arayüzler [i]);
                snfMtd = tip.GetInterfaceMap (arayüzler [i]).TargetMethods;
                foreach (MethodInfo mi in snfMtd) Console.WriteLine ("\t{0}", mi);
                ayzMtd = tip.GetInterfaceMap (arayüzler [i]).InterfaceMethods;
                foreach (MethodInfo mi in ayzMtd) Console.WriteLine ("\t\t{0}", mi);
            }
            snfA.IntAlan = 1881; snfA.StrAlan = "Selanik"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1919; snfA.StrAlan = "Samsun"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1923; snfA.StrAlan = "Ankara"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            snfA.IntAlan = 1938; snfA.StrAlan = "Ýstanbul"; Console.WriteLine ("{0}-{1}", snfA.IntAlan, snfA.StrAlan);
            for(i = 0;i < arayüzler.Length; i ++) {
                Console.WriteLine ("Arayüz adý: {0}", arayüzler [i]);
                snfMtd = tip.GetInterfaceMap (arayüzler [i]).TargetMethods;
                ayzMtd = tip.GetInterfaceMap (arayüzler [i]).InterfaceMethods;
                for(j = 0; j < snfMtd.Length; j++) {
                    Console.WriteLine ("\tArayüz metodu: {0}",  ayzMtd [j].Name);
                    Console.WriteLine ("\tSýnýf arayüz metodu: {0}", snfMtd [j].Name);
                }
            }
            Console.WriteLine ("Tiplenen sýnýf adý: {0}", tip.Name);
            Console.WriteLine ("Tiplenen ÝçiçeÖzelMi? {0}", tip.IsNestedPrivate);
            Console.WriteLine ("Tiplenen GenelMi? {0}", tip.IsPublic);

            Console.WriteLine ("\nFarklý soysal tipli deðerlerin delegeli fonksiyonla yazdýrýlmasý:");
            DelegeliYaz (delegate {return 20240815;});
            DelegeliYaz (delegate {return 20240815.1753d;});
            DelegeliYaz (delegate {return "Atatürk: 1923";});
            DelegeliYaz (delegate {return long.MaxValue;});
            DelegeliYaz (delegate {return true;});


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}