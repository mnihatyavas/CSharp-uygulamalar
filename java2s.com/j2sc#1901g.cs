// j2sc#1901g.cs: PropertyInfo, pi.Name ve pi.PropertyType �rne�i.

using System;
using System.Reflection; //PropertyInfo i�in
namespace TipBilgileri {
    public interface Aray�z1 {void MetotA();}
    public interface Aray�z2 {void MetotB();}
    public class S�n�fA: Aray�z1, Aray�z2 {
        enum Say�labilir{}
        int alan1, alan2;
        string alan3;
        public int Alan1 {get {return alan1;} set {alan1 = value;}}
        public int Alan2 {get {return alan2;} set {alan2 = value;}}
        public string Alan3 {get {return alan3;} set {alan3 = value;}}
        //public S�n�fA (int y1, int y2, string ad) {alan1=y1; alan2=y2; alan3=ad;}
        public void Metodum() {Console.WriteLine ("(do�um, vefat, isim): ({0}, {1}, {2})", alan1, alan2, alan3);}
        void Aray�z1.MetotA(){}
        void Aray�z2.MetotB(){}
    }
    public class S�n�fB {
        private string metin;
        public string Metin {get {return metin;} set {metin = value; De�i�irse();}}
        //private void De�i�irse() {if (De�i�ti != null) De�i�ti (this, System.EventArgs.Empty);}
        //public event EventHandler De�i�ti;
        public void De�i�irse() {Console.WriteLine (Metin);}
    }
    public class S�n�fC {
       private int [,] intDizi = new int [10,10];
       public int this [int i, int j] {get {return intDizi [i, j];} set {intDizi [i,j] = value;}}
    }
    public class S�n�fD {
        private string dizge = "M.Nihat Yava�";
        public string Dizge {get {return dizge;} set {if (dizge!=value) {dizge = value;}}} //�nceki de�er tekrar atanmaz, kal�r
    }
    class S�n�fE {
        int y�l1=1881, y�l2=1938; string ad="Mustafa Kemal Atat�rk"; bool ya��yorMu=true;
        public int Y�l1 {get {return y�l1;} set {y�l1=value;}}
        public int Y�l2 {get {return y�l2;} set {y�l2=value;}}
        public string Ad {get {return ad;} set {ad=value;}}
        public bool Ya��yorMu {get {return ya��yorMu;} set {ya��yorMu=value;}}
    }
    class �zellik {
        //private static void De�i�irse (object kaynak , System.EventArgs olay) {Console.WriteLine (((S�n�fB)kaynak).Metin);}
        static void Main() {
            Console.Write ("�zellik dizisi/teki PropertyInfo (snfA.GetType().GetProperties())'yla elde edilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�A'n�n 3 alan�na de�er koyup/alan �zellikler:");
            S�n�fA snfA = new S�n�fA();
            Type tip = snfA.GetType();
            PropertyInfo[] pi = tip.GetProperties();
            foreach (PropertyInfo �b in pi) Console.WriteLine ("�zellik: {0} {1}",  �b.PropertyType, �b.Name);
            snfA.Alan1=1881; snfA.Alan2=1938; snfA.Alan3="M.Kemal Atat�rk"; snfA.Metodum();
            snfA.Alan1=1932; snfA.Alan2=2014; snfA.Alan3="Han�m Emanet Yava�"; snfA.Metodum();
            snfA.Alan1=1933; snfA.Alan2=2018; snfA.Alan3="Memet Yava�"; snfA.Metodum();

            Console.WriteLine ("\nS�n�fB'nin Metin �zelli�i de�i�ti�inde yeni de�erin an�nda sunulmas�:");
            tip = typeof (S�n�fB);
            object ns = Activator.CreateInstance (tip);
            PropertyInfo �z = tip.GetProperty ("Metin");
            �z.SetValue (ns, "www.java2s.com", null);
            �z.SetValue (ns, "M.Nihat Yava�", null);
            �z.SetValue (ns, "Z.Nihal Candan", null);
            //string metin = (string)�z.GetValue (ns, null); Console.WriteLine (metin);
            //EventInfo ei = tip.GetEvent ("De�i�ti"); ei.AddEventHandler (ns, new EventHandler (�zellik.De�i�irse)); ((S�n�fB)ns).Metin = "Yeni metin de�eri";

            Console.WriteLine ("\nDateTime'�n mevcut t�m �zellik listesi:");
            DateTime tarih = new DateTime();
            tip = tarih.GetType();
            Console.WriteLine ("Yerel zaman: [{0}]", DateTime.Now);
            Console.WriteLine ("S�f�r boylam zaman: [{0}]", DateTime.UtcNow);
            foreach (PropertyInfo �b in tip.GetProperties()) Console.WriteLine (�b.PropertyType+" "+�b.Name);

            Console.WriteLine ("\n'int S�n�fC[int m,int n]' tipli �zellikli 5x5 diziyi doldurma ve sunma:");
            tip=typeof (S�n�fC);
            Type[] tipDizi = new Type [2];
            tipDizi.SetValue (typeof (int), 0);
            tipDizi.SetValue (typeof (int), 1);
            �z = tip.GetProperty ("Item", typeof (int), tipDizi, null);
            Console.WriteLine ("Tipleme ad�: "+tip.FullName);
            Console.WriteLine ("�zellik ad�: this."+�z.Name);
            Console.WriteLine ("�zellik tipi: "+�z.PropertyType);
            S�n�fC snfC=new S�n�fC();
            var r=new Random(); int i, j, ts;
            for(i=0;i<5;i++) {for(j=0;j<5;j++) {ts=r.Next(1299,2024); snfC [i, j]=ts;}}
            for(i=0;i<5;i++) {for(j=0;j<5;j++) {Console.Write (snfC [i, j] + " ");} Console.WriteLine();}

            Console.WriteLine ("\nS�n�fD tan�ml� Dizge ve ar�iv mi MemberType �zellikleri:");
            Type tipa = Type.GetType (new S�n�fD().ToString());
            PropertyInfo �za = tipa.GetProperty ("Dizge");
            Type tipb = Type.GetType ("System.Reflection.MethodInfo");
            PropertyInfo �zb = tipb.GetProperty ("MemberType");
            MethodInfo mia = �za.GetGetMethod();
            MethodInfo mia2 = �za.GetSetMethod();
            Console.WriteLine ("S�n�fD'nin �zellik ad�: "+�za.Name);
            Console.WriteLine ("\t�zellik gerid�n�� tipi: "+mia.ReturnType);
            MethodInfo mib = �zb.GetGetMethod();
            Console.WriteLine ("MethodInfo'nun �zellik ad�: "+�zb.Name);
            Console.WriteLine ("\t�zellik gerid�n�� tipi: "+mib.ReturnType);
            Console.WriteLine ("Dizge'nin get&set'i: {0}.{1}:\n\t{2}\n\t{3}", tipa.FullName, �za.Name, �za.GetGetMethod(), �za.GetSetMethod());
            Console.WriteLine ("MemberType'�n get'i: {0}.{1}:\n\t{2}", tipb.FullName, �zb.Name, �zb.GetGetMethod());

            Console.WriteLine ("\nS�n�fE'nin gerid�n�� tipli �zellikleri:");
            tip = typeof (S�n�fE);
            pi = tip.GetProperties();
            foreach (PropertyInfo �b in pi) Console.WriteLine ("�zellik: {0} {1}",  �b.PropertyType, �b.Name);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}