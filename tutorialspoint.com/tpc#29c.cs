// tpc#29c.cs: Özel vasýf yaratma ve yansýtmayla hata-ayýklama metadata okuma örneði.

using System;
using System.Reflection;
namespace Vasýflar {
    [AttributeUsage (
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
        AllowMultiple = true)]
    public class HtAyýkBilgi: System.Attribute {
        private int hataNo;
        private string ayýklayýcý;
        private string güncellemeTarihi;
        public string yorum;
        public HtAyýkBilgi (int hn, string ay, string trh) {
            this.hataNo = hn;
            this.ayýklayýcý = ay;
            this.güncellemeTarihi = trh;
        }
        [HtAyýkBilgi (35, "Fadime Yavaþ", "13/09/2022")] // Okunmaz
        public int HataNo {get {return hataNo;}}
        public string Ayýklayýcý {get {return ayýklayýcý;}}
        public string GüncellemeTarihi {get {return güncellemeTarihi;}}
        public string Yorum {get {return yorum;} set {yorum = value;}}
    }

    [HtAyýkBilgi (45, "Nihat Yavaþ", "27/10/2022", Yorum = "Geridönüþ tip uyumsuzluðu")]
    [HtAyýkBilgi (49, "Sevim Yavaþ", "10/11/2022", Yorum = "Kullanýlmayan fuzuli deðiþken tanýmý")]
    class Dikdörtgen {
        [HtAyýkBilgi (50, "Memet Yavaþ", "12/11/2022")] // Okunmaz
        protected double uzunluk;
        protected double yükseklik;
        [HtAyýkBilgi (52, "Haným Yavaþ", "13/11/2022")] // Okunmaz
        public Dikdörtgen (double uz, double yük) {
            uzunluk = uz;
            yükseklik = yük;
        }
        [HtAyýkBilgi (53, "Nihat Yavaþ", "19/11/2022", Yorum = "Eksik zaruri üye deðiþken tanýmsýzlýðý")]
        public double alanýAl() {return uzunluk * yükseklik;}

        [HtAyýkBilgi (55, "Canan Candan", "15/11/2022", Yorum = "Ýþgüzar metod")]
        public string boþMetod() {return "";}

        [HtAyýkBilgi (56, "Nedim Yavaþ", "21/11/2022")]
        public void göster() {Console.WriteLine ("Uzunluk: {0}\nYükseklik: {1}\nAlan: {2} {3}\n", uzunluk, yükseklik, alanýAl(), boþMetod());}

    class ÖzelVasýf {
        static void Main() {
            Console.Write ("Özel vasýf yaratma 4 aþamalýdýr: Özel vasfý beyan et, kur, elemana uygula, yansýmayla vasfa eriþ.\nYansýma çalýþma-zamanýnda metadata'ya (diðer veriyi tasvirde kullanýlan veriler hakkýndaki veri) eriþimi saðlayan kodlamadýr.\nHtAyýkBilgi özel vasýf sýnýfýnýn ilk 3 private deðiþkeni konumsal, son public yorum ise tercihi-adlý deðiþkendir.\nÖzel vasýf sýnýfý System.Attribute'un türevi yapýlmalýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            new Dikdörtgen (4.5, 7.5).göster();
            new Dikdörtgen (8.65, 17.25).göster();
            new Dikdörtgen (2.15, 9.38).göster();

            try {// Unhandled Exception: System.InvalidCastException: Unable to cast object of type '__DynamicallyInvokableAttribute' to type 'Vasýflar.HtAyýkBilgi' at Vasýflar.Dikdörtgen.ÖzelVasýf.Main()
                Type tip = typeof (Dikdörtgen);
                // Dikdörtgen sýnýf dýþý vasýflar taranacak
                foreach (Object vasýflar in tip.GetCustomAttributes (false)) {
                    HtAyýkBilgi hab = (HtAyýkBilgi) vasýflar;
                    if (hab != null) {
                        Console.WriteLine ("Hata no: {0}", hab.HataNo);
                        Console.WriteLine ("Ayýklayýcý: {0}", hab.Ayýklayýcý);
                        Console.WriteLine ("Güncelleme tarihi: {0}", hab.GüncellemeTarihi);
                        Console.WriteLine ("Görüþler: {0}\n", hab.Yorum);
                    }
                }
                //  Dikdörtgen sýnýf içi metod önü vasýflar taranacak
                foreach (MethodInfo mi in tip.GetMethods()) {
                    foreach (Attribute öz in mi.GetCustomAttributes (true)) {
                        HtAyýkBilgi hab = (HtAyýkBilgi) öz;
                        if (null != hab) {
                            Console.WriteLine ("Hata no: {0}, Öncül metod: {1}", hab.HataNo, mi.Name);
                            Console.WriteLine ("Ayýklayýcý: {0}", hab.Ayýklayýcý);
                            Console.WriteLine ("Güncelleme tarihi: {0}", hab.GüncellemeTarihi);
                            Console.WriteLine ("Görüþler: {0}\n", hab.Yorum);
                        }
                    }
                }
            }catch{}

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}}