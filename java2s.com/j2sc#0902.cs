// j2sc#0902.cs: Çoklu metotlarý delegeye +-toplama/çýkarma örneði.

using System;
namespace YetkiAktarma {
    public delegate void DelegeD (double x, double y);
    public class SýnýfD {
        public SýnýfD(){} //Kurucu
        public void Topla (double x, double y) {Console.Write ("x+y: {0:0.00}", x+y);}
        public void Çýkar (double x, double y) {Console.Write (";   x-y: {0:0.00}", x-y);}
        public static void Çarp (double x, double y) {Console.Write (";   x*y: {0:0.00}", x*y);}
        public static void Böl (double x, double y) {Console.Write (";   x/y: {0:0.00##}", x/y);}
    }
    class Delege2 {
        delegate void DelegeA (ref string dzg);
        delegate int DelegeB (string dzg);
        public delegate void DelegateC (int n, ref int refN);
        static void boþluklarýTirele (ref string a) {Console.WriteLine ("boþluklarýTirele(): " + a);}
        static void boþluklarýSil (ref string a) {Console.WriteLine ("boþluklarýSil(): " + a);}
        static void dizgeyiTersle (ref string a) {Console.WriteLine ("dizgeyiTersle(): " + a); a="Metot yürütüldü";}
        static int Selam1 (string a) {Console.WriteLine ("Selam1(): "+a); return 1881;}
        static int Selam2 (string a) {Console.WriteLine ("Selam2(): "+a); return 1923;}
        static int Selam3 (string a) {Console.WriteLine ("Selam3(): "+a); return 1938;}
        public static void Artýr1 (int n, ref int refN) {++n; ++refN;}
        public static void Artýr2 (int n, ref int refN) {n+=2; refN+=2;}
        public static void Azalt3 (int n, ref int refN) {n-=3; refN-=3;}
        static void Main() {
            Console.Write ("Delegeye ilk atama sonrasý +- ile çoklu metotlar eklenip çýkarýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yaratýlan metotlu delege tiplemelerini çoklu ekleyip/silme:");
            DelegeA dlg1;
            DelegeA bt = new DelegeA (boþluklarýTirele); 
            DelegeA bs = new DelegeA (boþluklarýSil); 
            DelegeA dt = new DelegeA (dizgeyiTersle); 
            string dizge1 = "Metot çaðrýlýyor"; Console.WriteLine ("dizge1 (önce): " + dizge1);
            dlg1 = boþluklarýTirele; dlg1 += dizgeyiTersle; dlg1 += boþluklarýSil; dlg1 += boþluklarýSil; dlg1 -= dizgeyiTersle; dlg1 -= boþluklarýSil; dlg1 +=boþluklarýTirele; dlg1 += dizgeyiTersle; dlg1 += dizgeyiTersle; 
            dlg1 (ref dizge1);
            Console.WriteLine ("dizge1 (sonra): " + dizge1);

            Console.WriteLine ("\nÇoklu metotlu delegeleri yaratýrken ilk tiplenmesine ekleme/çýkarma:");
            dizge1 = "Tüm delegelere selam!";
            DelegeB dlg2 = null; dlg2 += new DelegeB (Selam1); dlg2 += new DelegeB (Selam2); dlg2 += new DelegeB (Selam3); dlg2 +=Selam3; dlg2 +=Selam2; dlg2 +=Selam1; dlg2 -=Selam3;
            int ts1=dlg2 (dizge1); Console.WriteLine ("DelegeB'ye son geridönüþ = " + ts1);

            Console.WriteLine ("\nTek ifadeyle çoklu metotlarý delegeye ekleme/çýkarma:");
            DelegateC dlg3 = (DelegateC)Artýr1 + Artýr2 + Artýr2 + Artýr2 + Artýr2 + Azalt3 - Artýr2;
            ts1 = 0; int ts2=0; Console.WriteLine ("(Ýlk deðerler) ts1={0}, ts2={1}", ts1, ts2);
            dlg3 (ts1, ref ts2);
            Console.WriteLine ("(Son deðerler) ts1={0}, ref ts2={1}", ts1, ts2);
            dlg3 (ts1, ref ts2); dlg3 (ts1, ref ts2); dlg3 (ts1, ref ts2);
            Console.WriteLine ("(Son deðerler) ts1={0}, ref ts2={1}", ts1, ts2);

            Console.WriteLine ("\nZincirleme delegeyle tiplemeli toplama, çýkarma  ve statik çarpma, bölme:");
            var r=new Random(); double ds1, ds2; int i;
            SýnýfD s4 = new SýnýfD(); //Tipleme
            DelegeD[] dlgDizi = new DelegeD[] {new DelegeD (s4.Topla), new DelegeD (s4.Çýkar), new DelegeD (SýnýfD.Çarp), new DelegeD (SýnýfD.Böl)};
            DelegeD dlg4 = (DelegeD) Delegate.Combine (dlgDizi); //Dizi birimlerini ardýþýk +ekler
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                Console.WriteLine ("\t{0}) x={1}  ve   y={2} ise:", i+1, ds1, ds2);
                dlg4 (ds1, ds2); Console.WriteLine();
            }

            Console.WriteLine ("\nÖnceki örneði GetInvocationList() ve foreach'le tekrarlama:");
            DelegeD[] dlgDizi2 = {s4.Topla, s4.Çýkar, SýnýfD.Çarp, SýnýfD.Böl};
            DelegeD dlg42 = (DelegeD) DelegeD.Combine (dlgDizi2); i=0;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                Console.WriteLine ("\t{0}) x={1}  ve   y={2} ise:", i+1, ds1, ds2);
                foreach (DelegeD dD in dlg42.GetInvocationList()) {dD (ds1, ds2);}
                Console.WriteLine();
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}