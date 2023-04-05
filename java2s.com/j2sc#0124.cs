// j2sc#0124.cs: Ebeveyn 'Application&Exception' temelli özel istisnalar yaratma örneði.

using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections;
namespace DilTemelleri {
    public class SýfýraBölümÝstisnasý: ApplicationException {
        //public SýfýraBölümÝstisnasý(){}
        public SýfýraBölümÝstisnasý (string mesaj) : base (mesaj){} //Tek argümanlý taným yeterli
        //public SýfýraBölümÝstisnasý (string mesaj, Exception hata) : base (mesaj, hata){}
    }
    class EndeksTaþmaÝstisnasý: ApplicationException {
        //public EndeksTaþmaÝstisnasý(): base() {}
        public EndeksTaþmaÝstisnasý (string msj) : base (msj) {}
        //public override string ToString() {return Message;} //Tüm çýktýlar sadece 'hata.Message'a dönüþür
    }
    class Ýstisnam: ApplicationException {
        //public Ýstisnam(): base() {}
        public Ýstisnam (string m): base (m) {}
        //public override string ToString() {return Message;}
    }
    class ÝstisnamdanTüretilenÝstisna: Ýstisnam {
        //public ÝstisnamdanTüretilenÝstisna(): base(){} 
        public ÝstisnamdanTüretilenÝstisna (string d): base(d){}
        //public override string ToString() {return Message;}
    }
    public class ÖzelÝstisnam: ApplicationException {
        public ÖzelÝstisnam (string m): base (m) {
            this.HelpLink = "'__ÝÇÝNDEKÝLER.txt' yardým dosyasýna bakýnýz";
            this.Source = "j2sc#0124.cs kaynak dosyasýna bakýnýz";
        }
    }
    [Serializable]
    public sealed class BenimÝstisnam: Exception {
        private string dizgeBilgi;
        private bool ikiliBilgi;
        public BenimÝstisnam(): base(){}
        public BenimÝstisnam (string m): base (m) {}
        public BenimÝstisnam (string m, Exception h): base (m, h) {}
        private BenimÝstisnam (SerializationInfo bilgi, StreamingContext içerik): base (bilgi, içerik) {
            dizgeBilgi = bilgi.GetString ("DizgeBilgi");
            ikiliBilgi = bilgi.GetBoolean ("ÝkiliBilgi");
        }
        public BenimÝstisnam (string m, string dizgeBilgi, bool ikiliBilgi): this (m) {
            this.dizgeBilgi = dizgeBilgi;
            this.ikiliBilgi = ikiliBilgi;
        }
        public BenimÝstisnam (string m, Exception h, string dizgeBilgi, bool ikiliBilgi): this (m, h) {
            this.dizgeBilgi = dizgeBilgi;
            this.ikiliBilgi = ikiliBilgi;
        }
        public string DizgeBilgi {get {return dizgeBilgi;} }
        public bool ÝkiliBilgi {get {return ikiliBilgi;} }
        public override void GetObjectData (SerializationInfo bilgi, StreamingContext içerik) {
            bilgi.AddValue ("DizgeBilgi", dizgeBilgi);
            bilgi.AddValue ("ÝkiliBilgi", ikiliBilgi);
            base.GetObjectData (bilgi, içerik);
        }
        public override string Message {
            get {
                string m = base.Message;
                if (dizgeBilgi != null) {m += Environment.NewLine + dizgeBilgi + " = " + ikiliBilgi;}
                return m;
            }
        }
    }
    [assembly: AssemblyVersion ("1.1.0.0")]
    [assembly: AssemblyCultureAttribute ("")]
    [Serializable]
    public class TarihliÝstisna: Exception {
        public TarihliÝstisna (string m): base (m) {tarihZaman = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();}
        //protected TarihliÝstisna (SerializationInfo bilgi, StreamingContext içerik): base (bilgi, içerik) {tarihZaman = bilgi.GetString ("Zaman");}
        /*public override void GetObjectData (SerializationInfo bilgi, StreamingContext içerik) {
            bilgi.AddValue ("Zaman", tarihZaman, typeof (string));
            base.GetObjectData (bilgi, içerik);
        }*/
        protected string tarihZaman = null;
        public string Zaman {get {return tarihZaman;} }
    }
    class ÖzelÝstisna {
        public static void SýfýraBöl() {throw (new SýfýraBölümÝstisnasý ("Sýfýra bölüm hatasý oluþtu"));}
        static void Main() {
            Console.Write ("Özel sýnýf adlý istisnalarý türetilecek 'ApplicationException' veya 'Exception' temelli, sergilenecek hata, mesaj ve özelliklerle þekillendirerek yaratabilirsiniz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            try {SýfýraBöl();}catch (SýfýraBölümÝstisnasý) {Console.WriteLine ("SýfýraBölümÝstisnasý yakalandý");}
            try {SýfýraBöl();}catch (SýfýraBölümÝstisnasý hata) {Console.WriteLine ("SýfýraBölümÝstisnasý yakalandý: [{0}]", hata.Message);}
            try {SýfýraBöl();}catch (SýfýraBölümÝstisnasý h) {Console.WriteLine ("SýfýraBölümÝstisnasý yakalandý: [{0}]", h);}

            try {throw new EndeksTaþmaÝstisnasý ("Tanýmlý dizi endeksinin taþýlma hatasý");}catch (EndeksTaþmaÝstisnasý) {Console.WriteLine ("\nDizi endeksi taþma hatasý yakalandý");}
            try {throw new EndeksTaþmaÝstisnasý ("Dizi endeksi taþma hatasý");}catch (EndeksTaþmaÝstisnasý h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            try {throw new EndeksTaþmaÝstisnasý ("Dizi endeksi taþma istisnasý");}catch (EndeksTaþmaÝstisnasý h) {Console.WriteLine ("HATA: [{0}]", h);}

            for (int i = 0; i < 1000; i++) {
                try {if (i==0) throw new Ýstisnam ("ApplicationException'dan türetilen [Ýstisnam] fýrlatýldý");
                    else if (i==1) throw new ÝstisnamdanTüretilenÝstisna ("Ýstisnam'dan türetilen [ÝstisnamdanTüretilenÝstisna] fýrlatýldý");
                    else if (i==2) throw new Exception ("Genel [Exception] istisnasý fýrlatýldý");
                    else break;
                }catch (ÝstisnamdanTüretilenÝstisna h) {Console.WriteLine ("==>[{0}]", h);
                }catch (Ýstisnam h) {Console.WriteLine ("\n==>[{0}]", h);
                }catch (Exception h) {Console.WriteLine ("==>[{0}]", h);}
            }//for sonu

            try {Console.WriteLine ("\n'new ÖzelÝstisnam' istisna nesnesi fýrlatýlýyor...");
                throw new ÖzelÝstisnam ("Benim ÖzelÝstisnam mesajlý istisnam fýrlatýldý");
            }catch (ÖzelÝstisnam h) {
                Console.WriteLine ("Fýrlatýlan 'ÖzelÝstisnam' yakalandý");
                Console.WriteLine ("Mesajý = [{0}]", h.Message);
                Console.WriteLine ("Yardým baðlantýsý = [{0}]", h.HelpLink);
                Console.WriteLine ("Kaynaðý = [{0}]", h.Source);
                Console.WriteLine ("Yýðýn takibi = [{0}]", h.StackTrace);
                Console.WriteLine ("Hedef sitesi = [{0}]", h.TargetSite);
            }//catch sonu

            try {throw new BenimÝstisnam ("Bir hata", "BirÖzelMesaj", true);
            }catch (BenimÝstisnam h) {
                Console.WriteLine ("\nFýrlatýlan 'BenimÝstisnam' yakalandý.");
                Console.WriteLine ("Hata mesajý: {0}", h.Message);
                Console.WriteLine ("True/False bilgi: {0}", h.ÝkiliBilgi);
                Console.WriteLine ("Dizgesel bilgi: {0}", h.DizgeBilgi);
                Console.WriteLine ("HATA: [{0}]", h);
            }//catch sonu

            try {
                try {var liste = new ArrayList();
                    liste.Add (1881); liste.Add (1938); liste.Add (2023);
                    Console.WriteLine ("\nListede mevcut 3 eleman = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                    Console.WriteLine ("Listede namevcut 10.ncueleman = {0}", liste [9]);
                }catch (ArgumentOutOfRangeException h) {throw new BenimÝstisnam ("ArgumentOutOfRangeException'ý yakalayýp bu istisnayý fýrlatmayý yeðledim", h);
                }finally {Console.WriteLine ("Final temizliði..."); }
            }catch (Exception h) {
                Console.WriteLine ("Ýç try-catch-finally'dan throw'la fýrlatýlan istisna yakalandý.");
                Console.WriteLine ("HATA: [{0}]", h);
            }//Dýþ try-cath sonu

            try {throw new TarihliÝstisna ("Tarih ve zamanlý özel istisna");
            }catch (TarihliÝstisna h) {
                Console.WriteLine ("\nFýrlatýlan 'TarihliÝstisna' yakalandý.");
                Console.WriteLine ("Tarih: [{0}]", h.Zaman);
                Console.WriteLine ("Hata mesajý: [{0}]", h.Message);
                Console.WriteLine ("Yýðýn takibi: [{0}]", h.StackTrace);
            }//catch sonu

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}