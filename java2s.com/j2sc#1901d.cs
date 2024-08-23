// j2sc#1901d.cs: FieldInfo ve MemberInfo'yla tiplemelerin alan bilgileri örneði.

using System;
using System.Reflection; //FieldInfo için
namespace TipBilgileri {
    class SýnýfA {
      public int Alan1=0, Alan2=0;
      public void Metot1() {}
      public int  Metot2() {return 20240806;}
    }
    public interface Arayüz1 {void MetotA();}
    public interface Arayüz2 {void MetotB();}
    public class SýnýfB: Arayüz1, Arayüz2 {
        public enum Sayýlabilir{}
        public int intAlan;
        public string strAlan;
        public int IntAlan {get {return intAlan;} set {intAlan = value;}}
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        public void metot (int p1, string p2){}
        void Arayüz1.MetotA(){}
        void Arayüz2.MetotB(){}
    }
    class SýnýfC {
        public int ts1 = 0;
        public float kn = 1.0f;
        public static int ts2 = 1881;
        SýnýfC() {}
        static void Fonk1(){}
        public int Fonk2 (int i, Decimal d, string[] strDizi) {return (20240807);}
    }
    public class SýnýfD {
        //public event EventHandler Deðiþti;
        private string metin;
        public string Metin {get {return metin;} set {metin = value; Deðiþtiðinde();}}
        private void Deðiþtiðinde() {/*if (Deðiþti != null) Deðiþti (this, System.EventArgs.Empty);*/}
    }
    class Alan {
        //private static void Deðiþtiðinde (object bilgi, System.EventArgs olay) {Console.WriteLine ("Deðiþti: " + ((SýnýfD)bilgi).Metin);}
        static void Main() {
            Console.Write ("'foreach(FieldInfo f in typeof(Sýnýf).GetFields())' ile Sýnýf'ýn mevcut alanlarý sunulur. FieldInfo sadece alan adlarýný verirken MemberInfo hem alan tiplerini hem de adlarýný verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýfA'nýn mevcut alanlarýnýn typeof'la listelenmesi:");
            Type tip = typeof (SýnýfA);
            FieldInfo[] fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);

            Console.WriteLine ("\nSýnýfA'nýn mevcut alanlarýnýn GetType'la listelenmesi:");
            SýnýfB snfB = new SýnýfB();
            tip = snfB.GetType();
            fi = tip.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan: {0}", f.Name);

            Console.WriteLine ("\nMemberInfo ile SýnýfC'nin alan tipleri ve adlarýnýn sunulmasý:");
            tip = typeof (SýnýfC);
            foreach (MemberInfo m in tip.GetFields()) Console.WriteLine ("{0}", m);

            Console.WriteLine ("\nSýnýfD metin alanýna OlayYönetimli? Deðiþti-ðinde() dizge atama ve sunma:");
            tip = typeof (SýnýfD);
            object ns = Activator.CreateInstance (tip); //new SýnýfD()
            FieldInfo ab = tip.GetField ("metin", BindingFlags.NonPublic | BindingFlags.Instance);
            ab.SetValue (ns, "www.github.com/mnihatyavas"); string dzg = (string)ab.GetValue (ns); Console.WriteLine (dzg);
            ab.SetValue (ns, "www.facebook.com/mnihatyavas"); dzg = (string)ab.GetValue (ns); Console.WriteLine (dzg);

            Console.WriteLine ("\nType.GetType(str) tiplemenin alan ad ve tipli üye bilgileri:");
            tip = Type.GetType ("System.Reflection.Assembly");
            Console.WriteLine ("System.Reflection.Assembly'nin tipi: {0}", tip);
            MemberInfo[] mi = tip.GetMembers();
            foreach (MemberInfo üb in mi) Console.WriteLine ( "-->ÜyeBilgisi({0})'nin tipi: {1}", üb, üb.MemberType);
            tip = Type.GetType (new SýnýfD().ToString()); 
            Console.WriteLine (tip.FullName+": "+tip.BaseType);
            mi = tip.GetMembers();
            foreach (MemberInfo üb in mi) Console.WriteLine (üb+": "+üb.MemberType);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}