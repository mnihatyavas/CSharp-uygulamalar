// j2sc#0902.cs: �oklu metotlar� delegeye +-toplama/��karma �rne�i.

using System;
namespace YetkiAktarma {
    public delegate void DelegeD (double x, double y);
    public class S�n�fD {
        public S�n�fD(){} //Kurucu
        public void Topla (double x, double y) {Console.Write ("x+y: {0:0.00}", x+y);}
        public void ��kar (double x, double y) {Console.Write (";   x-y: {0:0.00}", x-y);}
        public static void �arp (double x, double y) {Console.Write (";   x*y: {0:0.00}", x*y);}
        public static void B�l (double x, double y) {Console.Write (";   x/y: {0:0.00##}", x/y);}
    }
    class Delege2 {
        delegate void DelegeA (ref string dzg);
        delegate int DelegeB (string dzg);
        public delegate void DelegateC (int n, ref int refN);
        static void bo�luklar�Tirele (ref string a) {Console.WriteLine ("bo�luklar�Tirele(): " + a);}
        static void bo�luklar�Sil (ref string a) {Console.WriteLine ("bo�luklar�Sil(): " + a);}
        static void dizgeyiTersle (ref string a) {Console.WriteLine ("dizgeyiTersle(): " + a); a="Metot y�r�t�ld�";}
        static int Selam1 (string a) {Console.WriteLine ("Selam1(): "+a); return 1881;}
        static int Selam2 (string a) {Console.WriteLine ("Selam2(): "+a); return 1923;}
        static int Selam3 (string a) {Console.WriteLine ("Selam3(): "+a); return 1938;}
        public static void Art�r1 (int n, ref int refN) {++n; ++refN;}
        public static void Art�r2 (int n, ref int refN) {n+=2; refN+=2;}
        public static void Azalt3 (int n, ref int refN) {n-=3; refN-=3;}
        static void Main() {
            Console.Write ("Delegeye ilk atama sonras� +- ile �oklu metotlar eklenip ��kar�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yarat�lan metotlu delege tiplemelerini �oklu ekleyip/silme:");
            DelegeA dlg1;
            DelegeA bt = new DelegeA (bo�luklar�Tirele); 
            DelegeA bs = new DelegeA (bo�luklar�Sil); 
            DelegeA dt = new DelegeA (dizgeyiTersle); 
            string dizge1 = "Metot �a�r�l�yor"; Console.WriteLine ("dizge1 (�nce): " + dizge1);
            dlg1 = bo�luklar�Tirele; dlg1 += dizgeyiTersle; dlg1 += bo�luklar�Sil; dlg1 += bo�luklar�Sil; dlg1 -= dizgeyiTersle; dlg1 -= bo�luklar�Sil; dlg1 +=bo�luklar�Tirele; dlg1 += dizgeyiTersle; dlg1 += dizgeyiTersle; 
            dlg1 (ref dizge1);
            Console.WriteLine ("dizge1 (sonra): " + dizge1);

            Console.WriteLine ("\n�oklu metotlu delegeleri yarat�rken ilk tiplenmesine ekleme/��karma:");
            dizge1 = "T�m delegelere selam!";
            DelegeB dlg2 = null; dlg2 += new DelegeB (Selam1); dlg2 += new DelegeB (Selam2); dlg2 += new DelegeB (Selam3); dlg2 +=Selam3; dlg2 +=Selam2; dlg2 +=Selam1; dlg2 -=Selam3;
            int ts1=dlg2 (dizge1); Console.WriteLine ("DelegeB'ye son gerid�n�� = " + ts1);

            Console.WriteLine ("\nTek ifadeyle �oklu metotlar� delegeye ekleme/��karma:");
            DelegateC dlg3 = (DelegateC)Art�r1 + Art�r2 + Art�r2 + Art�r2 + Art�r2 + Azalt3 - Art�r2;
            ts1 = 0; int ts2=0; Console.WriteLine ("(�lk de�erler) ts1={0}, ts2={1}", ts1, ts2);
            dlg3 (ts1, ref ts2);
            Console.WriteLine ("(Son de�erler) ts1={0}, ref ts2={1}", ts1, ts2);
            dlg3 (ts1, ref ts2); dlg3 (ts1, ref ts2); dlg3 (ts1, ref ts2);
            Console.WriteLine ("(Son de�erler) ts1={0}, ref ts2={1}", ts1, ts2);

            Console.WriteLine ("\nZincirleme delegeyle tiplemeli toplama, ��karma  ve statik �arpma, b�lme:");
            var r=new Random(); double ds1, ds2; int i;
            S�n�fD s4 = new S�n�fD(); //Tipleme
            DelegeD[] dlgDizi = new DelegeD[] {new DelegeD (s4.Topla), new DelegeD (s4.��kar), new DelegeD (S�n�fD.�arp), new DelegeD (S�n�fD.B�l)};
            DelegeD dlg4 = (DelegeD) Delegate.Combine (dlgDizi); //Dizi birimlerini ard���k +ekler
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                Console.WriteLine ("\t{0}) x={1}  ve   y={2} ise:", i+1, ds1, ds2);
                dlg4 (ds1, ds2); Console.WriteLine();
            }

            Console.WriteLine ("\n�nceki �rne�i GetInvocationList() ve foreach'le tekrarlama:");
            DelegeD[] dlgDizi2 = {s4.Topla, s4.��kar, S�n�fD.�arp, S�n�fD.B�l};
            DelegeD dlg42 = (DelegeD) DelegeD.Combine (dlgDizi2); i=0;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                Console.WriteLine ("\t{0}) x={1}  ve   y={2} ise:", i+1, ds1, ds2);
                foreach (DelegeD dD in dlg42.GetInvocationList()) {dD (ds1, ds2);}
                Console.WriteLine();
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}