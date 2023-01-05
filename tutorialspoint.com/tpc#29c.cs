// tpc#29c.cs: �zel vas�f yaratma ve yans�tmayla hata-ay�klama metadata okuma �rne�i.

using System;
using System.Reflection;
namespace Vas�flar {
    [AttributeUsage (
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = true)]
    public class HtAy�kBilgi: System.Attribute {
        private int hataNo;
        private string ay�klay�c�;
        private string g�ncellemeTarihi;
        public string yorum;
        public HtAy�kBilgi (int hn, string ay, string trh) {
            this.hataNo = hn;
            this.ay�klay�c� = ay;
            this.g�ncellemeTarihi = trh;
        }
        [HtAy�kBilgi (35, "Fadime Yava�", "13/09/2022")] // Okunmaz
        public int HataNo {get {return hataNo;}}
        public string Ay�klay�c� {get {return ay�klay�c�;}}
        public string G�ncellemeTarihi {get {return g�ncellemeTarihi;}}
        public string Yorum {get {return yorum;} set {yorum = value;}}
    }

    [HtAy�kBilgi (45, "Nihat Yava�", "27/10/2022", Yorum = "Gerid�n�� tip uyumsuzlu�u")]
    [HtAy�kBilgi (49, "Sevim Yava�", "10/11/2022", Yorum = "Kullan�lmayan fuzuli de�i�ken tan�m�")]
    class Dikd�rtgen {
        [HtAy�kBilgi (50, "Memet Yava�", "12/11/2022")] // Okunmaz
        protected double uzunluk;
        protected double y�kseklik;
        [HtAy�kBilgi (52, "Han�m Yava�", "13/11/2022")] // Okunmaz
        public Dikd�rtgen (double uz, double y�k) {
            uzunluk = uz;
            y�kseklik = y�k;
        }
        [HtAy�kBilgi (53, "Nihat Yava�", "19/11/2022", Yorum = "Eksik zaruri �ye de�i�ken tan�ms�zl���")]
        public double alan�Al() {return uzunluk * y�kseklik;}

        [HtAy�kBilgi (55, "Canan Candan", "15/11/2022", Yorum = "��g�zar metod")]
        public string bo�Metod() {return "";}

        [HtAy�kBilgi (56, "Nedim Yava�", "21/11/2022")]
        public void g�ster() {Console.WriteLine ("Uzunluk: {0}\nY�kseklik: {1}\nAlan: {2} {3}\n", uzunluk, y�kseklik, alan�Al(), bo�Metod());}

    class �zelVas�f {
        static void Main() {
            Console.Write ("�zel vas�f yaratma 4 a�amal�d�r: �zel vasf� beyan et, kur, elemana uygula, yans�mayla vasfa eri�.\nYans�ma �al��ma-zaman�nda metadata'ya (di�er veriyi tasvirde kullan�lan veriler hakk�ndaki veri) eri�imi sa�layan kodlamad�r.\nHtAy�kBilgi �zel vas�f s�n�f�n�n ilk 3 private de�i�keni konumsal, son public yorum ise tercihi-adl� de�i�kendir.\n�zel vas�f s�n�f� System.Attribute'un t�revi yap�lmal�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            new Dikd�rtgen (4.5, 7.5).g�ster();
            new Dikd�rtgen (8.65, 17.25).g�ster();
            new Dikd�rtgen (2.15, 9.38).g�ster();

            try {// Unhandled Exception: System.InvalidCastException: Unable to cast object of type '__DynamicallyInvokableAttribute' to type 'Vas�flar.HtAy�kBilgi' at Vas�flar.Dikd�rtgen.�zelVas�f.Main()
                Type tip = typeof (Dikd�rtgen);
                // Dikd�rtgen s�n�f d��� vas�flar taranacak
                foreach (Object vas�flar in tip.GetCustomAttributes (false)) {
                    HtAy�kBilgi hab = (HtAy�kBilgi) vas�flar;
                    if (hab != null) {
                        Console.WriteLine ("Hata no: {0}", hab.HataNo);
                        Console.WriteLine ("Ay�klay�c�: {0}", hab.Ay�klay�c�);
                        Console.WriteLine ("G�ncelleme tarihi: {0}", hab.G�ncellemeTarihi);
                        Console.WriteLine ("G�r��ler: {0}\n", hab.Yorum);
                    }
                }
                //  Dikd�rtgen s�n�f i�i metod �n� vas�flar taranacak
                foreach (MethodInfo mi in tip.GetMethods()) {
                    foreach (Attribute �z in mi.GetCustomAttributes (true)) {
                        HtAy�kBilgi hab = (HtAy�kBilgi) �z;
                        if (null != hab) {
                            Console.WriteLine ("Hata no: {0}, �nc�l metod: {1}", hab.HataNo, mi.Name);
                            Console.WriteLine ("Ay�klay�c�: {0}", hab.Ay�klay�c�);
                            Console.WriteLine ("G�ncelleme tarihi: {0}", hab.G�ncellemeTarihi);
                            Console.WriteLine ("G�r��ler: {0}\n", hab.Yorum);
                        }
                    }
                }
            }catch{}

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}}