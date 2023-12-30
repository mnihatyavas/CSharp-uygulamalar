// j2sc#1001.cs: Vasýf/Attribute sýnýfý ve vasýfkullaným/AttributeUsage arþiv vasfý örneði.

using System;
using System.Diagnostics; //Conditional için
using System.IO; //Stream ve File için
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter için
namespace Vasýflar {
    [AttributeUsage (AttributeTargets.Class |
                    AttributeTargets.Constructor |
                    AttributeTargets.Field |
                    AttributeTargets.Method |
                    AttributeTargets.Property,
                    AllowMultiple = true)]
    public class HataAyýklamaVasfý : System.Attribute {
        public int HataNo;
        public string Tarih, Programcý, Yorum;
        public HataAyýklamaVasfý (int h, string p, string t) {HataNo = h; Programcý = p; Tarih = t;} //Kurucu
    }
    [HataAyýklamaVasfý (1, "M.Nihat Yavaþ", "12/12/23",Yorum = "Hata ayýklama")]
    public class Math1 {
        public double Fonk1 (double p1) {return p1 + Fonk2 (p1);}
        public double Fonk2 (double p1) {return p1 / 3;}
    }
    public class ArgümanlýVasýf : Attribute {
        private string _Arma;
        public ArgümanlýVasýf (string arma) {Arma = arma;}
        public string Arma {get {return _Arma;} set {_Arma = value;}}
    }
    class ArgümanlýYardým {
        [ArgümanlýVasýf ("?")]
        public ArgümanlýYardým (bool yardým) {Yardým = yardým;}
        private bool _Yardým;
        public bool Yardým {get {return _Yardým;} set {_Yardým = value;}}
    }
    [Serializable]
    class Döküman {
       public string Baþlýk = null;
       public string Veri = null;
       [NonSerialized]
       public long _PencereYönetimi = 0;
       class Resim {}
       [NonSerialized]
       private Resim resim = new Resim();
    }
    [AttributeUsage (AttributeTargets.All)]
    public class Vasfým : Attribute {
        string yorum;
        public Vasfým (string yorum) {this.yorum = yorum;} //Kurucu
        public string Yorum {get {return yorum;}}
    }
    class Vasýf1 {
        [Conditional ("DEBUG")]
        public void Onay(){}
        static void Main (string[] arg) {
            Console.Write ("Özellikle program hata ayýklama bilgi beyaný için hazýr vasýflar (AttributeUsage, Conditional, Obsolete) veya System.Attribute miraslý özel vasýf sýnýf ve üyeleri tanýmlanabilir. Vasýf bilgisi [Vasýf(kurucu parametrik veriler)] þeklinde kodlanmalýdýr.\nKurucu AttributeUsage (AttributeTargets birim)'daki sayýsallanabilen hedef birimleri: All, Assembly, Class, Constructor, Delegate, Enum, Event, Field, Interface, Method, Module, Parameter, Property, ReturnValue, Struct; çoklu OR'lanabilirler. Ýki bool parametresi: AllowMultiple ve Inherited'tir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hata ayýklama vasýflý hesap:");
            HataAyýklamaVasfý hav=new HataAyýklamaVasfý (2, "Zafer N.Candan", "13/12/2023");
            Console.WriteLine ("Hata ayýklama no: {0};\tAyýklayan: {1};\tTarih: {2}", hav.HataNo, hav.Programcý, hav.Tarih);
            int i; double ds1; var r=new Random();
            Math1 m1=new Math1();
            for(i=0;i<5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("Sayý: {0};\t(Sayý+Sayý/3): {1}", ds1, m1.Fonk1 (ds1));
            }

            Console.WriteLine ("\nKomut satýrý argümanýyla vasýf beyaný ve yardým giriþi:");
            //>> j2sc#1001 "M.Nihat Yavaþ" true
            ArgümanlýVasýf av; ArgümanlýYardým ay;
            try {av=new ArgümanlýVasýf (arg [0]); ay=new ArgümanlýYardým (true);}catch{}
            if (arg.Length == 0) Console.WriteLine ("Argümanlý arma ve yardým yok");
            else if (arg.Length == 1) {Console.WriteLine ("Argümnlý arma: {0}", arg [0]);}
            else if (arg.Length == 2) {Console.WriteLine ("Argümnlý arma: {0};\tYardým var mý? {1}", arg [0], arg [1]);}

            Console.WriteLine ("\nÝkili biçimli disk döküman dosyasý yaratma:");
            Stream akýþ;
            Döküman ilkDöküman = new Döküman();
            ilkDöküman.Baþlýk ="nihat";
            Döküman sonDöküman;
            using (akýþ = File.Open (ilkDöküman.Baþlýk + ".bin", FileMode.Create)) {
                BinaryFormatter ikiliBiçimleyici = new BinaryFormatter();
                ikiliBiçimleyici.Serialize (akýþ, ilkDöküman);
            }
            using (akýþ = File.Open (ilkDöküman.Baþlýk + ".bin", FileMode.Open)) {
                BinaryFormatter ikiliBiçimleyici = new BinaryFormatter();
                sonDöküman = (Döküman)ikiliBiçimleyici.Deserialize (akýþ);
            }
            Console.WriteLine ("nihat.bin dosyasýnýn yaratýlmasý, önce serileþtirilip sonra sersizleþtirilmesi baþarýlý mý? {0}", sonDöküman.Baþlýk == "nihat");

            Console.WriteLine ("\nVasfým özel vasýf kurucuyla girilen yorum:");
            Vasfým vsf;
            if (arg.Length > 0) vsf=new Vasfým (arg [0]);
            else vsf=new Vasfým ("Nihal Zeliha Yavaþ Candan");
            Console.WriteLine ("Attribute türevi Vasfým yorumu: {0}", vsf.Yorum);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}