// j2sc#2204f.cs: SelectMany<char> ve 'select new{}' örneði.

using System;
using System.Linq; // join için
using System.Collections.Generic; //Cast<> için
using System.Collections; //ArrayList için
namespace Query_Sorgu {
    public class Temas {
        public int No;
        public string Ýsim;
        public string Ýletiþim;
        public static void EriþimListesi (Temas[] temaslar) {
            Console.WriteLine ("Toplam {0} adet üye no, ad-soyad ve eposta-gsm listesi:", temaslar.Length);
            foreach (Temas t in temaslar) Console.WriteLine ("Temas No: {0}, {1}, {2}", t.No, t.Ýsim, t.Ýletiþim);
        }
    }
    public class Üye {
        public int no;
        public string ad;
        public string soyad;
        public string eposta;
        public string gsm;
        public static ArrayList ÜyeleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new Üye {no = 1881, ad = "Hüseyin", soyad = "Kurt", eposta = "huseyinkurt@gmail.com", gsm = "0555-551-6575"});
            liste.Add (new Üye {no = 1919, ad = "Fatih", soyad = "Kaplan", eposta = "fatihkaplan@gmail.com", gsm = "0555-551-6576"});
            liste.Add (new Üye {no = 1920, ad = "Hülya", soyad = "Piray", eposta = "hulyapiray@gmail.com", gsm = "0555-551-6577"});
            liste.Add (new Üye {no = 1923, ad = "Selim", soyad = "Dikel", eposta = "selimdikel@gmail.com", gsm = "0555-551-6578"});
            liste.Add (new Üye {no = 1914, ad = "Ali", soyad = "Eralp", eposta = "alieralp@gmail.com", gsm = "0555-551-6579"});
            liste.Add (new Üye {no = 1938, ad = "Özgür", soyad = "Özel", eposta = "ozgurozel@gmail.com", gsm = "0555-551-6580"});
            liste.Add (new Üye {no = 1932, ad = "Hüseyin", soyad = "Budak", eposta = "huseyinbudak@gmail.com", gsm = "0555-551-6581"});
            return (liste);
        }
    }
    class SelectMany_new {
        static void Main() {
            Console.Write ("Dizgenin krk tipli tek-tek seçiminde SelectMany kullanýlýr. 'select new {}' ile çoklu bilgi alan seçimi yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin new{} seçimleri:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Zerdüþt", "Buda", "Brahman", "Konfiçyus"};
            String[] endeksler = {"A", "B", "C", "Ç", "D", "E", "F", "G", "Ð", "H", "I", "Ý", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "Þ", "T", "U", "Ü", "V", "W", "X", "Y", "Z"};
            var sorgu1a = from p in peygamberler
                join e in endeksler
                on p.Substring (0, 1) equals e
                select new {p, e};
            Console.WriteLine ("-->Tüm {0} adet endeksli peygamberler listesi:", sorgu1a.Count());
            foreach(var p in sorgu1a) Console.WriteLine (p);
            var sorgu1b = from p in peygamberler
                group p by p [0] into gr
                select new {Ýlkharf = gr.Key, Peygamberler = gr};
            Console.WriteLine ("-->Tüm {0} adet endeksli peygamber gruplarý:", sorgu1b.Count());
            foreach (var g in sorgu1b) {
                Console.Write ("{0} ilkharfli peygamberler: ", g.Ýlkharf);
                foreach (var p in g.Peygamberler) Console.Write (p+" "); Console.WriteLine();
            }
            IEnumerable<char> sorgu1c = peygamberler.SelectMany (p => (p+" ").ToArray());
            Console.Write ("-->Tüm {0} adet <char> peygamber adlarý: ", sorgu1c.Count());
            foreach (char k in sorgu1c) Console.Write (k); Console.WriteLine();
            IEnumerable<char> sorgu1d = peygamberler
                .SelectMany ((p, e) => e < 5 ? (p+" ").ToArray() : p.ToArray());
            Console.Write ("-->Tüm {0} adet <char> peygamber adlarý: ", sorgu1d.Count());
            foreach (char k in sorgu1d) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nArþiv int ve string metot gruplarýnýn sorgulanmasý:");
            var sorgu2a = from m in typeof(int).GetMethods()
                orderby m.Name
                group m by m.Name into g
                select new {Ad = g.Key, Metotlar = g};
            Console.WriteLine ("-->Tüm {0} adet int metot gruplarý:", sorgu2a.Count());
            foreach (var g in sorgu2a) {
                Console.WriteLine ("[{0}] anahtarlý metotlar:", g.Ad);
                foreach (var m in g.Metotlar) Console.WriteLine ("\t{0}", m);
            }
            var sorgu2b = from m in typeof(string).GetMethods()
                orderby m.Name
                group m by m.Name into g
                select new {Ad = g.Key};
            Console.Write ("-->Tüm {0} adet string metot grup adlarý: ", sorgu2b.Count());
            foreach (var g in sorgu2b) Console.Write (g.Ad+" "); Console.WriteLine();

            Console.WriteLine ("\nTemas ve Üye sýnýf bilgilerinin birleþik 'new Temas{}' seçimi:");
            ArrayList üyeler = Üye.ÜyeleriAl();
            Temas[] temaslar = üyeler
                .Cast<Üye>() //ArrayList-->List<Üye>
                .Select (ü => new Temas {
                    No = ü.no,
                    Ýsim = string.Format ("{0} {1}", ü.ad, ü.soyad),
                    Ýletiþim = string.Format ("{0} / {1}", ü.eposta, ü.gsm)})
                .ToArray<Temas>();
            Temas.EriþimListesi (temaslar);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}