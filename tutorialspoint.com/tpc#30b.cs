// tpc#30b.cs: Yans�tmayla hataay�klama metadata vas�flar�n� okuma �rne�i.

using System;
using System.Reflection;
namespace Yans�tma {
    [AttributeUsage (AttributeTargets.All, AllowMultiple = true)] // �oklu vas�f yaz�l�m�na izin verir
    public class HtAy�kBilgi: System.Attribute {// T�revleme
        private int hataNo; // Zaruri konumsal �yeler
        private string ay�klay�c�;
        private string g�ncellemeTarihi;
        public string yorum; // Tercihi-adl� �ye
        public HtAy�kBilgi (int hn, string ay, string trh) {
            this.hataNo = hn;
            this.ay�klay�c� = ay;
            this.g�ncellemeTarihi = trh;
        }
        [HtAy�kBilgi (35, "Fadime Yava�", "13/09/2022", Yorum="M�teveffa yorumu")] // Okunmaz
        public int HataNo {get {return hataNo;}}
        public string Ay�klay�c� {get {return ay�klay�c�;}}
        public string G�ncellemeTarihi {get {return g�ncellemeTarihi;}}
        public string Yorum {get {return yorum;} set {yorum = value;}}
    }

    [HtAy�kBilgi (45, "Nihat Yava�", "27/10/2022", Yorum = "Gerid�n�� tip uyumsuzlu�u")]
    [HtAy�kBilgi (49, "Sevim Yava�", "10/11/2022", Yorum = "Kullan�lmayan fuzuli de�i�ken tan�m�")]
    class Dikd�rtgen {// Tip�n� vas�flar
        [HtAy�kBilgi (50, "Memet Yava�", "12/11/2022", Yorum="M�teveffa yorumu")] // Okunmaz
        protected double uzunluk;
        protected double y�kseklik;
        public Dikd�rtgen (double uz, double y�k) {
            uzunluk = uz;
            y�kseklik = y�k;
        }
        [HtAy�kBilgi (52, "Han�m Yava�", "13/11/2022", Yorum="M�teveffa yorumu")]
        [HtAy�kBilgi (53, "Nihat Yava�", "19/11/2022", Yorum = "Eksik zaruri �ye de�i�ken tan�ms�zl���")]
        public double alan�Al() {return uzunluk * y�kseklik;}// Metod �n� vas�flar

        [HtAy�kBilgi (55, "Canan Candan", "15/11/2022", Yorum = "��g�zar metod")]
        public string bo�Metod() {return "";}

        [HtAy�kBilgi (56, "Nedim Yava�", "21/11/2022")]
        public void g�ster() {Console.WriteLine ("Uzunluk: {0}\nY�kseklik: {1}\nAlan: {2} {3}\n", uzunluk, y�kseklik, alan�Al(), bo�Metod());}

    class �zelVas�f {
        static void Main() {
            Console.Write ("Vas�f tan�mlama i�i de�il, sadece tiplenen s�n�f�n� ve i�erdi�i metodlar �n� (�oklu) vas�flar okunur.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

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