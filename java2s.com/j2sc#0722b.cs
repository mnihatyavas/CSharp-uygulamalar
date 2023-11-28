// j2sc#0722b.cs: K�smi s�n�flar ve temel-t�redi esge�en metotlar �rne�i.

using System;
//using System.ComponentModel;
namespace S�n�flar {
    partial class XYZ {
        int x;
        public int X {get {return x;} set {x = value;}}
    }
    partial class XYZ {
        int y;
        public int Y {get {return y;} set {y = value;}}
    }
    partial class XYZ {
        int z;
        public int Z {get {return z;} set {z = value;}}
    }
    public partial class S�n�fA {public void �lkMetod() {Console.WriteLine ("S�n�fA.�lkMetod()");}}
    public partial class S�n�fA {public void �kinciMetod() {Console.WriteLine ("S�n�fA.�kinciMetod()");}}
    public partial class S�n�fA {public void ���nc�Metod() {Console.WriteLine ("S�n�fA.���nc�Metod()");}}
    partial class S�n�fB<T�lk, T�kinci>: IEquatable<string>where T�lk : class {
        public bool Equals (string di�er) {return false;}
    }
    interface Yaz�labilir {string Yazd�r();}
    class Yaz�lamazSayfa {
        int say�;
        public Yaz�lamazSayfa (int say�) {this.say� = say�;} //Kurucu
        public override string ToString() {return((say�+" tarihli yaz�lamaz sayfa...").ToString());}
    }
    class Yaz�labilirSayfa: Yaz�labilir {
        string isim;
        public Yaz�labilirSayfa (string isim) {this.isim = isim;} //Kurucu
        public override string ToString() {return(isim);}
        string Yaz�labilir.Yazd�r() {return(isim+" yaz�yor...");}
    }
    public class Temel {public virtual void konu�() {Console.WriteLine ("Sanal Temel.konu�() konu�uyor...");}}
    public class T�redi: Temel {public override void konu�() {Console.WriteLine ("Esge�en T�redi.konu�() konu�uyor...");}}
    class �e�itli2 {
        public static void Yazd�rmay�Dene (params object[] dizi) {
            foreach (object nes in dizi) {
                Yaz�labilir yaznes = nes as Yaz�labilir;
                if (yaznes != null) Console.WriteLine ("{0}", yaznes.Yazd�r());
                else Console.WriteLine ("{0}", nes+": null nesne");
            }
        }
        static void Main() {
            Console.Write ("Herbirinde farkl� �yeler bulunan ayn� adl� 'partial' s�n�flar tiplemeyle t�m �yeleri tek s�n�fm��ca kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayn� adl� 3 partial/k�smi s�n�f �yelerine de�er koy/al:");
            var r=new Random(); int ts1, i;
            XYZ xyz = new XYZ(); Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", xyz.X, xyz.Y, xyz.Z);
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); xyz.X=ts1;
                ts1=r.Next(-100,100); xyz.Y=ts1;
                ts1=r.Next(-100,100); xyz.Z=ts1;
                Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", xyz.X, xyz.Y, xyz.Z);
            }

            Console.WriteLine ("\nAyn� adl� 3 k�smi s�n�f�n farkl� adl� metotlar�n�n �a�r�lmas�:");
            S�n�fA nesne = new S�n�fA();
            nesne.�lkMetod();
            nesne.�kinciMetod();
            nesne.���nc�Metod();

            Console.WriteLine ("\nNormal Equals ve k�smi s�n�fl� Equals'la e�itlik kontrolleri:");
            string dizge1 = "Merhaba"; string dizge2 = "Selam";
            Console.WriteLine ("\"Merhaba\" == \"Selam\": {0}", dizge1.Equals (dizge2) );
            Console.WriteLine ("\"Merhaba\" == \"Merhaba\": {0}", dizge1.Equals ("Merhaba") );
            S�n�fB<string,string> b=new S�n�fB<string,string>();
            Console.WriteLine ("S�n�fB<string,string> b=new S�n�fB<string,string>() == \"Merhaba\": {0}", b.Equals (dizge2) );
            Console.WriteLine ("b == b: {0}", b.Equals (b) );
            Console.WriteLine ("b == new S�n�fB<string,string>(): {0}", b.Equals (new S�n�fB<string,string>()) );
            Console.WriteLine ("b == new XYZ(): {0}", b.Equals (new XYZ()) );

            Console.WriteLine ("\nAray�z �ablonlu yaz�lamaz ve yaz�labilir nesnelerin sayfalar�:");
            Yaz�lamazSayfa s1 = new Yaz�lamazSayfa (20231107);
            Yaz�labilirSayfa s2 = new Yaz�labilirSayfa ("M.Nihat Yava�");
            Yaz�lamazSayfa s3 = new Yaz�lamazSayfa (19381110);
            Yaz�labilirSayfa s4 = new Yaz�labilirSayfa ("Zafer N.Candan");
            Yazd�rmay�Dene (s1, s2, s3, s4, null);

            Console.WriteLine ("\nTemel sanal metotun t�redi esge�enle yerine ge�mesi:");
            T�redi trd = new T�redi(); trd.konu�();
            Temel tml = trd; tml.konu�();
            T�redi trd2 = (T�redi) tml; trd2.konu�();
            object nesne2 = trd; T�redi trd3 = (T�redi)nesne2; trd3.konu�();
            ((Temel)trd).konu�();
            new Temel().konu�();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}