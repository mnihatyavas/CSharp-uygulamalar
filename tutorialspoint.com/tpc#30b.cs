// tpc#30b.cs: Yansýtmayla hataayýklama metadata vasýflarýný okuma örneði.

using System;
using System.Reflection;
namespace Yansýtma {
    [AttributeUsage (AttributeTargets.All, AllowMultiple = true)] // Çoklu vasýf yazýlýmýna izin verir
    public class HtAyýkBilgi: System.Attribute {// Türevleme
        private int hataNo; // Zaruri konumsal üyeler
        private string ayýklayýcý;
        private string güncellemeTarihi;
        public string yorum; // Tercihi-adlý üye
        public HtAyýkBilgi (int hn, string ay, string trh) {
            this.hataNo = hn;
            this.ayýklayýcý = ay;
            this.güncellemeTarihi = trh;
        }
        [HtAyýkBilgi (35, "Fadime Yavaþ", "13/09/2022", Yorum="Müteveffa yorumu")] // Okunmaz
        public int HataNo {get {return hataNo;}}
        public string Ayýklayýcý {get {return ayýklayýcý;}}
        public string GüncellemeTarihi {get {return güncellemeTarihi;}}
        public string Yorum {get {return yorum;} set {yorum = value;}}
    }

    [HtAyýkBilgi (45, "Nihat Yavaþ", "27/10/2022", Yorum = "Geridönüþ tip uyumsuzluðu")]
    [HtAyýkBilgi (49, "Sevim Yavaþ", "10/11/2022", Yorum = "Kullanýlmayan fuzuli deðiþken tanýmý")]
    class Dikdörtgen {// Tipönü vasýflar
        [HtAyýkBilgi (50, "Memet Yavaþ", "12/11/2022", Yorum="Müteveffa yorumu")] // Okunmaz
        protected double uzunluk;
        protected double yükseklik;
        public Dikdörtgen (double uz, double yük) {
            uzunluk = uz;
            yükseklik = yük;
        }
        [HtAyýkBilgi (52, "Haným Yavaþ", "13/11/2022", Yorum="Müteveffa yorumu")]
        [HtAyýkBilgi (53, "Nihat Yavaþ", "19/11/2022", Yorum = "Eksik zaruri üye deðiþken tanýmsýzlýðý")]
        public double alanýAl() {return uzunluk * yükseklik;}// Metod önü vasýflar

        [HtAyýkBilgi (55, "Canan Candan", "15/11/2022", Yorum = "Ýþgüzar metod")]
        public string boþMetod() {return "";}

        [HtAyýkBilgi (56, "Nedim Yavaþ", "21/11/2022")]
        public void göster() {Console.WriteLine ("Uzunluk: {0}\nYükseklik: {1}\nAlan: {2} {3}\n", uzunluk, yükseklik, alanýAl(), boþMetod());}

    class ÖzelVasýf {
        static void Main() {
            Console.Write ("Vasýf tanýmlama içi deðil, sadece tiplenen sýnýfönü ve içerdiði metodlar önü (çoklu) vasýflar okunur.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

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