// j2sc#1901d.cs: FieldInfo ve MemberInfo'yla tiplemelerin alan bilgileri �rne�i.

using System;
using System.Reflection; //FieldInfo i�in
namespace TipBilgileri {
    class S�n�fA {
      public int Alan1=0, Alan2=0;
      public void Metot1() {}
      public int  Metot2() {return 20240806;}
    }
    public interface Aray�z1 {void MetotA();}
    public interface Aray�z2 {void MetotB();}
    public class S�n�fB: Aray�z1, Aray�z2 {
        public enum Say�labilir{}
        public int intAlan;
        public string strAlan;
        public int IntAlan {get {return intAlan;} set {intAlan = value;}}
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        public void metot (int p1, string p2){}
        void Aray�z1.MetotA(){}
        void Aray�z2.MetotB(){}
    }
    class S�n�fC {
        public int ts1 = 0;
        public float kn = 1.0f;
        public static int ts2 = 1881;
        S�n�fC() {}
        static void Fonk1(){}
        public int Fonk2 (int i, Decimal d, string[] strDizi) {return (20240807);}
    }
    public class S�n�fD {
        //public event EventHandler De�i�ti;
        private string metin;
        public string Metin {get {return metin;} set {metin = value; De�i�ti�inde();}}
        private void De�i�ti�inde() {/*if (De�i�ti != null) De�i�ti (this, System.EventArgs.Empty);*/}
    }
    class Alan {
        //private static void De�i�ti�inde (object bilgi, System.EventArgs olay) {Console.WriteLine ("De�i�ti: " + ((S�n�fD)bilgi).Metin);}
        static void Main() {
            Console.Write ("'foreach(FieldInfo f in typeof(S�n�f).GetFields())' ile S�n�f'�n mevcut alanlar� sunulur. FieldInfo sadece alan adlar�n� verirken MemberInfo hem alan tiplerini hem de adlar�n� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fA'n�n mevcut alanlar�n�n typeof'la listelenmesi:");
            Type tip = typeof (S�n�fA);
            FieldInfo[] fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);

            Console.WriteLine ("\nS�n�fA'n�n mevcut alanlar�n�n GetType'la listelenmesi:");
            S�n�fB snfB = new S�n�fB();
            tip = snfB.GetType();
            fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);

            Console.WriteLine ("\nMemberInfo ile S�n�fC'nin alan tipleri ve adlar�n�n sunulmas�:");
            tip = typeof (S�n�fC);
            foreach (MemberInfo m in tip.GetFields()) Console.WriteLine ("{0}", m);

            Console.WriteLine ("\nS�n�fD metin alan�na OlayY�netimli? De�i�ti-�inde() dizge atama ve sunma:");
            tip = typeof (S�n�fD);
            object ns = Activator.CreateInstance (tip); //new S�n�fD()
            FieldInfo ab = tip.GetField ("metin", BindingFlags.NonPublic | BindingFlags.Instance);
            ab.SetValue (ns, "www.github.com/mnihatyavas"); string dzg = (string)ab.GetValue (ns); Console.WriteLine (dzg);
            ab.SetValue (ns, "www.facebook.com/mnihatyavas"); dzg = (string)ab.GetValue (ns); Console.WriteLine (dzg);

            Console.WriteLine ("\nType.GetType(str) tiplemenin alan ad ve tipli �ye bilgileri:");
            tip = Type.GetType ("System.Reflection.Assembly");
            Console.WriteLine ("System.Reflection.Assembly'nin tipi: {0}", tip);
            MemberInfo[] mi = tip.GetMembers();
            foreach (MemberInfo �b in mi) Console.WriteLine ( "-->�yeBilgisi({0})'nin tipi: {1}", �b, �b.MemberType);
            tip = Type.GetType (new S�n�fD().ToString()); 
            Console.WriteLine (tip.FullName+": "+tip.BaseType);
            mi = tip.GetMembers();
            foreach (MemberInfo �b in mi) Console.WriteLine (�b+": "+�b.MemberType);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}