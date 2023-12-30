// j2sc#1001.cs: Vas�f/Attribute s�n�f� ve vas�fkullan�m/AttributeUsage ar�iv vasf� �rne�i.

using System;
using System.Diagnostics; //Conditional i�in
using System.IO; //Stream ve File i�in
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter i�in
namespace Vas�flar {
    [AttributeUsage (AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property,
                    AllowMultiple = true)]
    public class HataAy�klamaVasf� : System.Attribute {
        public int HataNo;
        public string Tarih, Programc�, Yorum;
        public HataAy�klamaVasf� (int h, string p, string t) {HataNo = h; Programc� = p; Tarih = t;} //Kurucu
    }
    [HataAy�klamaVasf� (1, "M.Nihat Yava�", "12/12/23",Yorum = "Hata ay�klama")]
    public class Math1 {
        public double Fonk1 (double p1) {return p1 + Fonk2 (p1);}
        public double Fonk2 (double p1) {return p1 / 3;}
    }
    public class Arg�manl�Vas�f : Attribute {
        private string _Arma;
        public Arg�manl�Vas�f (string arma) {Arma = arma;}
        public string Arma {get {return _Arma;} set {_Arma = value;}}
    }
    class Arg�manl�Yard�m {
        [Arg�manl�Vas�f ("?")]
        public Arg�manl�Yard�m (bool yard�m) {Yard�m = yard�m;}
        private bool _Yard�m;
        public bool Yard�m {get {return _Yard�m;} set {_Yard�m = value;}}
    }
    [Serializable]
    class D�k�man {
       public string Ba�l�k = null;
       public string Veri = null;
       [NonSerialized]
       public long _PencereY�netimi = 0;
       class Resim {}
       [NonSerialized]
       private Resim resim = new Resim();
    }
    [AttributeUsage (AttributeTargets.All)]
    public class Vasf�m : Attribute {
        string yorum;
        public Vasf�m (string yorum) {this.yorum = yorum;} //Kurucu
        public string Yorum {get {return yorum;}}
    }
    class Vas�f1 {
        [Conditional ("DEBUG")]
        public void Onay(){}
        static void Main (string[] arg) {
            Console.Write ("�zellikle program hata ay�klama bilgi beyan� i�in haz�r vas�flar (AttributeUsage, Conditional, Obsolete) veya System.Attribute mirasl� �zel vas�f s�n�f ve �yeleri tan�mlanabilir. Vas�f bilgisi [Vas�f(kurucu parametrik veriler)] �eklinde kodlanmal�d�r.\nKurucu AttributeUsage (AttributeTargets birim)'daki say�sallanabilen hedef birimleri: All, Assembly, Class, Constructor, Delegate, Enum, Event, Field, Interface, Method, Module, Parameter, Property, ReturnValue, Struct; �oklu OR'lanabilirler. �ki bool parametresi: AllowMultiple ve Inherited'tir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hata ay�klama vas�fl� hesap:");
            HataAy�klamaVasf� hav=new HataAy�klamaVasf� (2, "Zafer N.Candan", "13/12/2023");
            Console.WriteLine ("Hata ay�klama no: {0};\tAy�klayan: {1};\tTarih: {2}", hav.HataNo, hav.Programc�, hav.Tarih);
            int i; double ds1; var r=new Random();
            Math1 m1=new Math1();
            for(i=0;i<5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("Say�: {0};\t(Say�+Say�/3): {1}", ds1, m1.Fonk1 (ds1));
            }

            Console.WriteLine ("\nKomut sat�r� arg�man�yla vas�f beyan� ve yard�m giri�i:");
            //>> j2sc#1001 "M.Nihat Yava�" true
            Arg�manl�Vas�f av; Arg�manl�Yard�m ay;
            try {av=new Arg�manl�Vas�f (arg [0]); ay=new Arg�manl�Yard�m (true);}catch{}
            if (arg.Length == 0) Console.WriteLine ("Arg�manl� arma ve yard�m yok");
            else if (arg.Length == 1) {Console.WriteLine ("Arg�mnl� arma: {0}", arg [0]);}
            else if (arg.Length == 2) {Console.WriteLine ("Arg�mnl� arma: {0};\tYard�m var m�? {1}", arg [0], arg [1]);}

            Console.WriteLine ("\n�kili bi�imli disk d�k�man dosyas� yaratma:");
            Stream ak��;
            D�k�man ilkD�k�man = new D�k�man();
            ilkD�k�man.Ba�l�k ="nihat";
            D�k�man sonD�k�man;
            using (ak�� = File.Open (ilkD�k�man.Ba�l�k + ".bin", FileMode.Create)) {
                BinaryFormatter ikiliBi�imleyici = new BinaryFormatter();
                ikiliBi�imleyici.Serialize (ak��, ilkD�k�man);
            }
            using (ak�� = File.Open (ilkD�k�man.Ba�l�k + ".bin", FileMode.Open)) {
                BinaryFormatter ikiliBi�imleyici = new BinaryFormatter();
                sonD�k�man = (D�k�man)ikiliBi�imleyici.Deserialize (ak��);
            }
            Console.WriteLine ("nihat.bin dosyas�n�n yarat�lmas�, �nce serile�tirilip sonra sersizle�tirilmesi ba�ar�l� m�? {0}", sonD�k�man.Ba�l�k == "nihat");

            Console.WriteLine ("\nVasf�m �zel vas�f kurucuyla girilen yorum:");
            Vasf�m vsf;
            if (arg.Length > 0) vsf=new Vasf�m (arg [0]);
            else vsf=new Vasf�m ("Nihal Zeliha Yava� Candan");
            Console.WriteLine ("Attribute t�revi Vasf�m yorumu: {0}", vsf.Yorum);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}