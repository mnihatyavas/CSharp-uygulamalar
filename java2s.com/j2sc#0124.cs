// j2sc#0124.cs: Ebeveyn 'Application&Exception' temelli �zel istisnalar yaratma �rne�i.

using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections;
namespace DilTemelleri {
    public class S�f�raB�l�m�stisnas�: ApplicationException {
        //public S�f�raB�l�m�stisnas�(){}
        public S�f�raB�l�m�stisnas� (string mesaj) : base (mesaj){} //Tek arg�manl� tan�m yeterli
        //public S�f�raB�l�m�stisnas� (string mesaj, Exception hata) : base (mesaj, hata){}
    }
    class EndeksTa�ma�stisnas�: ApplicationException {
        //public EndeksTa�ma�stisnas�(): base() {}
        public EndeksTa�ma�stisnas� (string msj) : base (msj) {}
        //public override string ToString() {return Message;} //T�m ��kt�lar sadece 'hata.Message'a d�n���r
    }
    class �stisnam: ApplicationException {
        //public �stisnam(): base() {}
        public �stisnam (string m): base (m) {}
        //public override string ToString() {return Message;}
    }
    class �stisnamdanT�retilen�stisna: �stisnam {
        //public �stisnamdanT�retilen�stisna(): base(){} 
        public �stisnamdanT�retilen�stisna (string d): base(d){}
        //public override string ToString() {return Message;}
    }
    public class �zel�stisnam: ApplicationException {
        public �zel�stisnam (string m): base (m) {
            this.HelpLink = "'__���NDEK�LER.txt' yard�m dosyas�na bak�n�z";
            this.Source = "j2sc#0124.cs kaynak dosyas�na bak�n�z";
        }
    }
    [Serializable]
    public sealed class Benim�stisnam: Exception {
        private string dizgeBilgi;
        private bool ikiliBilgi;
        public Benim�stisnam(): base(){}
        public Benim�stisnam (string m): base (m) {}
        public Benim�stisnam (string m, Exception h): base (m, h) {}
        private Benim�stisnam (SerializationInfo bilgi, StreamingContext i�erik): base (bilgi, i�erik) {
            dizgeBilgi = bilgi.GetString ("DizgeBilgi");
            ikiliBilgi = bilgi.GetBoolean ("�kiliBilgi");
        }
        public Benim�stisnam (string m, string dizgeBilgi, bool ikiliBilgi): this (m) {
            this.dizgeBilgi = dizgeBilgi;
            this.ikiliBilgi = ikiliBilgi;
        }
        public Benim�stisnam (string m, Exception h, string dizgeBilgi, bool ikiliBilgi): this (m, h) {
            this.dizgeBilgi = dizgeBilgi;
            this.ikiliBilgi = ikiliBilgi;
        }
        public string DizgeBilgi {get {return dizgeBilgi;} }
        public bool �kiliBilgi {get {return ikiliBilgi;} }
        public override void GetObjectData (SerializationInfo bilgi, StreamingContext i�erik) {
            bilgi.AddValue ("DizgeBilgi", dizgeBilgi);
            bilgi.AddValue ("�kiliBilgi", ikiliBilgi);
            base.GetObjectData (bilgi, i�erik);
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
    public class Tarihli�stisna: Exception {
        public Tarihli�stisna (string m): base (m) {tarihZaman = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();}
        //protected Tarihli�stisna (SerializationInfo bilgi, StreamingContext i�erik): base (bilgi, i�erik) {tarihZaman = bilgi.GetString ("Zaman");}
        /*public override void GetObjectData (SerializationInfo bilgi, StreamingContext i�erik) {
            bilgi.AddValue ("Zaman", tarihZaman, typeof (string));
            base.GetObjectData (bilgi, i�erik);
        }*/
        protected string tarihZaman = null;
        public string Zaman {get {return tarihZaman;} }
    }
    class �zel�stisna {
        public static void S�f�raB�l() {throw (new S�f�raB�l�m�stisnas� ("S�f�ra b�l�m hatas� olu�tu"));}
        static void Main() {
            Console.Write ("�zel s�n�f adl� istisnalar� t�retilecek 'ApplicationException' veya 'Exception' temelli, sergilenecek hata, mesaj ve �zelliklerle �ekillendirerek yaratabilirsiniz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            try {S�f�raB�l();}catch (S�f�raB�l�m�stisnas�) {Console.WriteLine ("S�f�raB�l�m�stisnas� yakaland�");}
            try {S�f�raB�l();}catch (S�f�raB�l�m�stisnas� hata) {Console.WriteLine ("S�f�raB�l�m�stisnas� yakaland�: [{0}]", hata.Message);}
            try {S�f�raB�l();}catch (S�f�raB�l�m�stisnas� h) {Console.WriteLine ("S�f�raB�l�m�stisnas� yakaland�: [{0}]", h);}

            try {throw new EndeksTa�ma�stisnas� ("Tan�ml� dizi endeksinin ta��lma hatas�");}catch (EndeksTa�ma�stisnas�) {Console.WriteLine ("\nDizi endeksi ta�ma hatas� yakaland�");}
            try {throw new EndeksTa�ma�stisnas� ("Dizi endeksi ta�ma hatas�");}catch (EndeksTa�ma�stisnas� h) {Console.WriteLine ("HATA: [{0}]", h.Message);}
            try {throw new EndeksTa�ma�stisnas� ("Dizi endeksi ta�ma istisnas�");}catch (EndeksTa�ma�stisnas� h) {Console.WriteLine ("HATA: [{0}]", h);}

            for (int i = 0; i < 1000; i++) {
                try {if (i==0) throw new �stisnam ("ApplicationException'dan t�retilen [�stisnam] f�rlat�ld�");
                    else if (i==1) throw new �stisnamdanT�retilen�stisna ("�stisnam'dan t�retilen [�stisnamdanT�retilen�stisna] f�rlat�ld�");
                    else if (i==2) throw new Exception ("Genel [Exception] istisnas� f�rlat�ld�");
                    else break;
                }catch (�stisnamdanT�retilen�stisna h) {Console.WriteLine ("==>[{0}]", h);
                }catch (�stisnam h) {Console.WriteLine ("\n==>[{0}]", h);
                }catch (Exception h) {Console.WriteLine ("==>[{0}]", h);}
            }//for sonu

            try {Console.WriteLine ("\n'new �zel�stisnam' istisna nesnesi f�rlat�l�yor...");
                throw new �zel�stisnam ("Benim �zel�stisnam mesajl� istisnam f�rlat�ld�");
            }catch (�zel�stisnam h) {
                Console.WriteLine ("F�rlat�lan '�zel�stisnam' yakaland�");
                Console.WriteLine ("Mesaj� = [{0}]", h.Message);
                Console.WriteLine ("Yard�m ba�lant�s� = [{0}]", h.HelpLink);
                Console.WriteLine ("Kayna�� = [{0}]", h.Source);
                Console.WriteLine ("Y���n takibi = [{0}]", h.StackTrace);
                Console.WriteLine ("Hedef sitesi = [{0}]", h.TargetSite);
            }//catch sonu

            try {throw new Benim�stisnam ("Bir hata", "Bir�zelMesaj", true);
            }catch (Benim�stisnam h) {
                Console.WriteLine ("\nF�rlat�lan 'Benim�stisnam' yakaland�.");
                Console.WriteLine ("Hata mesaj�: {0}", h.Message);
                Console.WriteLine ("True/False bilgi: {0}", h.�kiliBilgi);
                Console.WriteLine ("Dizgesel bilgi: {0}", h.DizgeBilgi);
                Console.WriteLine ("HATA: [{0}]", h);
            }//catch sonu

            try {
                try {var liste = new ArrayList();
                    liste.Add (1881); liste.Add (1938); liste.Add (2023);
                    Console.WriteLine ("\nListede mevcut 3 eleman = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                    Console.WriteLine ("Listede namevcut 10.ncueleman = {0}", liste [9]);
                }catch (ArgumentOutOfRangeException h) {throw new Benim�stisnam ("ArgumentOutOfRangeException'� yakalay�p bu istisnay� f�rlatmay� ye�ledim", h);
                }finally {Console.WriteLine ("Final temizli�i..."); }
            }catch (Exception h) {
                Console.WriteLine ("�� try-catch-finally'dan throw'la f�rlat�lan istisna yakaland�.");
                Console.WriteLine ("HATA: [{0}]", h);
            }//D�� try-cath sonu

            try {throw new Tarihli�stisna ("Tarih ve zamanl� �zel istisna");
            }catch (Tarihli�stisna h) {
                Console.WriteLine ("\nF�rlat�lan 'Tarihli�stisna' yakaland�.");
                Console.WriteLine ("Tarih: [{0}]", h.Zaman);
                Console.WriteLine ("Hata mesaj�: [{0}]", h.Message);
                Console.WriteLine ("Y���n takibi: [{0}]", h.StackTrace);
            }//catch sonu

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}