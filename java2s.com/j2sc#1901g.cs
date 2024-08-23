// j2sc#1901g.cs: PropertyInfo, pi.Name ve pi.PropertyType örneði.

using System;
using System.Reflection; //PropertyInfo için
namespace TipBilgileri {
    public interface Arayüz1 {void MetotA();}
    public interface Arayüz2 {void MetotB();}
    public class SýnýfA: Arayüz1, Arayüz2 {
        enum Sayýlabilir{}
        int alan1, alan2;
        string alan3;
        public int Alan1 {get {return alan1;} set {alan1 = value;}}
        public int Alan2 {get {return alan2;} set {alan2 = value;}}
        public string Alan3 {get {return alan3;} set {alan3 = value;}}
        //public SýnýfA (int y1, int y2, string ad) {alan1=y1; alan2=y2; alan3=ad;}
        public void Metodum() {Console.WriteLine ("(doðum, vefat, isim): ({0}, {1}, {2})", alan1, alan2, alan3);}
        void Arayüz1.MetotA(){}
        void Arayüz2.MetotB(){}
    }
    public class SýnýfB {
        private string metin;
        public string Metin {get {return metin;} set {metin = value; Deðiþirse();}}
        //private void Deðiþirse() {if (Deðiþti != null) Deðiþti (this, System.EventArgs.Empty);}
        //public event EventHandler Deðiþti;
        public void Deðiþirse() {Console.WriteLine (Metin);}
    }
    public class SýnýfC {
       private int [,] intDizi = new int [10,10];
       public int this [int i, int j] {get {return intDizi [i, j];} set {intDizi [i,j] = value;}}
    }
    public class SýnýfD {
        private string dizge = "M.Nihat Yavaþ";
        public string Dizge {get {return dizge;} set {if (dizge!=value) {dizge = value;}}} //Önceki deðer tekrar atanmaz, kalýr
    }
    class SýnýfE {
        int yýl1=1881, yýl2=1938; string ad="Mustafa Kemal Atatürk"; bool yaþýyorMu=true;
        public int Yýl1 {get {return yýl1;} set {yýl1=value;}}
        public int Yýl2 {get {return yýl2;} set {yýl2=value;}}
        public string Ad {get {return ad;} set {ad=value;}}
        public bool YaþýyorMu {get {return yaþýyorMu;} set {yaþýyorMu=value;}}
    }
    class Özellik {
        //private static void Deðiþirse (object kaynak , System.EventArgs olay) {Console.WriteLine (((SýnýfB)kaynak).Metin);}
        static void Main() {
            Console.Write ("Özellik dizisi/teki PropertyInfo (snfA.GetType().GetProperties())'yla elde edilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýA'nýn 3 alanýna deðer koyup/alan özellikler:");
            SýnýfA snfA = new SýnýfA();
            Type tip = snfA.GetType();
            PropertyInfo[] pi = tip.GetProperties();
            foreach (PropertyInfo öb in pi) Console.WriteLine ("Özellik: {0} {1}",  öb.PropertyType, öb.Name);
            snfA.Alan1=1881; snfA.Alan2=1938; snfA.Alan3="M.Kemal Atatürk"; snfA.Metodum();
            snfA.Alan1=1932; snfA.Alan2=2014; snfA.Alan3="Haným Emanet Yavaþ"; snfA.Metodum();
            snfA.Alan1=1933; snfA.Alan2=2018; snfA.Alan3="Memet Yavaþ"; snfA.Metodum();

            Console.WriteLine ("\nSýnýfB'nin Metin özelliði deðiþtiðinde yeni deðerin anýnda sunulmasý:");
            tip = typeof (SýnýfB);
            object ns = Activator.CreateInstance (tip);
            PropertyInfo öz = tip.GetProperty ("Metin");
            öz.SetValue (ns, "www.java2s.com", null);
            öz.SetValue (ns, "M.Nihat Yavaþ", null);
            öz.SetValue (ns, "Z.Nihal Candan", null);
            //string metin = (string)öz.GetValue (ns, null); Console.WriteLine (metin);
            //EventInfo ei = tip.GetEvent ("Deðiþti"); ei.AddEventHandler (ns, new EventHandler (Özellik.Deðiþirse)); ((SýnýfB)ns).Metin = "Yeni metin deðeri";

            Console.WriteLine ("\nDateTime'ýn mevcut tüm özellik listesi:");
            DateTime tarih = new DateTime();
            tip = tarih.GetType();
            Console.WriteLine ("Yerel zaman: [{0}]", DateTime.Now);
            Console.WriteLine ("Sýfýr boylam zaman: [{0}]", DateTime.UtcNow);
            foreach (PropertyInfo öb in tip.GetProperties()) Console.WriteLine (öb.PropertyType+" "+öb.Name);

            Console.WriteLine ("\n'int SýnýfC[int m,int n]' tipli özellikli 5x5 diziyi doldurma ve sunma:");
            tip=typeof (SýnýfC);
            Type[] tipDizi = new Type [2];
            tipDizi.SetValue (typeof (int), 0);
            tipDizi.SetValue (typeof (int), 1);
            öz = tip.GetProperty ("Item", typeof (int), tipDizi, null);
            Console.WriteLine ("Tipleme adý: "+tip.FullName);
            Console.WriteLine ("Özellik adý: this."+öz.Name);
            Console.WriteLine ("Özellik tipi: "+öz.PropertyType);
            SýnýfC snfC=new SýnýfC();
            var r=new Random(); int i, j, ts;
            for(i=0;i<5;i++) {for(j=0;j<5;j++) {ts=r.Next(1299,2024); snfC [i, j]=ts;}}
            for(i=0;i<5;i++) {for(j=0;j<5;j++) {Console.Write (snfC [i, j] + " ");} Console.WriteLine();}

            Console.WriteLine ("\nSýnýfD tanýmlý Dizge ve arþiv mi MemberType özellikleri:");
            Type tipa = Type.GetType (new SýnýfD().ToString());
            PropertyInfo öza = tipa.GetProperty ("Dizge");
            Type tipb = Type.GetType ("System.Reflection.MethodInfo");
            PropertyInfo özb = tipb.GetProperty ("MemberType");
            MethodInfo mia = öza.GetGetMethod();
            MethodInfo mia2 = öza.GetSetMethod();
            Console.WriteLine ("SýnýfD'nin Özellik adý: "+öza.Name);
            Console.WriteLine ("\tÖzellik geridönüþ tipi: "+mia.ReturnType);
            MethodInfo mib = özb.GetGetMethod();
            Console.WriteLine ("MethodInfo'nun özellik adý: "+özb.Name);
            Console.WriteLine ("\tÖzellik geridönüþ tipi: "+mib.ReturnType);
            Console.WriteLine ("Dizge'nin get&set'i: {0}.{1}:\n\t{2}\n\t{3}", tipa.FullName, öza.Name, öza.GetGetMethod(), öza.GetSetMethod());
            Console.WriteLine ("MemberType'ýn get'i: {0}.{1}:\n\t{2}", tipb.FullName, özb.Name, özb.GetGetMethod());

            Console.WriteLine ("\nSýnýfE'nin geridönüþ tipli özellikleri:");
            tip = typeof (SýnýfE);
            pi = tip.GetProperties();
            foreach (PropertyInfo öb in pi) Console.WriteLine ("Özellik: {0} {1}",  öb.PropertyType, öb.Name);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}