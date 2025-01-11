// j2sc#2204f.cs: SelectMany<char> ve 'select new{}' �rne�i.

using System;
using System.Linq; // join i�in
using System.Collections.Generic; //Cast<> i�in
using System.Collections; //ArrayList i�in
namespace Query_Sorgu {
    public class Temas {
        public int No;
        public string �sim;
        public string �leti�im;
        public static void Eri�imListesi (Temas[] temaslar) {
            Console.WriteLine ("Toplam {0} adet �ye no, ad-soyad ve eposta-gsm listesi:", temaslar.Length);
            foreach (Temas t in temaslar) Console.WriteLine ("Temas No: {0}, {1}, {2}", t.No, t.�sim, t.�leti�im);
        }
    }
    public class �ye {
        public int no;
        public string ad;
        public string soyad;
        public string eposta;
        public string gsm;
        public static ArrayList �yeleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new �ye {no = 1881, ad = "H�seyin", soyad = "Kurt", eposta = "huseyinkurt@gmail.com", gsm = "0555-551-6575"});
            liste.Add (new �ye {no = 1919, ad = "Fatih", soyad = "Kaplan", eposta = "fatihkaplan@gmail.com", gsm = "0555-551-6576"});
            liste.Add (new �ye {no = 1920, ad = "H�lya", soyad = "Piray", eposta = "hulyapiray@gmail.com", gsm = "0555-551-6577"});
            liste.Add (new �ye {no = 1923, ad = "Selim", soyad = "Dikel", eposta = "selimdikel@gmail.com", gsm = "0555-551-6578"});
            liste.Add (new �ye {no = 1914, ad = "Ali", soyad = "Eralp", eposta = "alieralp@gmail.com", gsm = "0555-551-6579"});
            liste.Add (new �ye {no = 1938, ad = "�zg�r", soyad = "�zel", eposta = "ozgurozel@gmail.com", gsm = "0555-551-6580"});
            liste.Add (new �ye {no = 1932, ad = "H�seyin", soyad = "Budak", eposta = "huseyinbudak@gmail.com", gsm = "0555-551-6581"});
            return (liste);
        }
    }
    class SelectMany_new {
        static void Main() {
            Console.Write ("Dizgenin krk tipli tek-tek se�iminde SelectMany kullan�l�r. 'select new {}' ile �oklu bilgi alan se�imi yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberlerin new{} se�imleri:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Zerd��t", "Buda", "Brahman", "Konfi�yus"};
            String[] endeksler = {"A", "B", "C", "�", "D", "E", "F", "G", "�", "H", "I", "�", "J", "K", "L", "M", "N", "O", "�", "P", "Q", "R", "S", "�", "T", "U", "�", "V", "W", "X", "Y", "Z"};
            var sorgu1a = from p in peygamberler
                join e in endeksler
                on p.Substring (0, 1) equals e
                select new {p, e};
            Console.WriteLine ("-->T�m {0} adet endeksli peygamberler listesi:", sorgu1a.Count());
            foreach(var p in sorgu1a) Console.WriteLine (p);
            var sorgu1b = from p in peygamberler
                group p by p [0] into gr
                select new {�lkharf = gr.Key, Peygamberler = gr};
            Console.WriteLine ("-->T�m {0} adet endeksli peygamber gruplar�:", sorgu1b.Count());
            foreach (var g in sorgu1b) {
                Console.Write ("{0} ilkharfli peygamberler: ", g.�lkharf);
                foreach (var p in g.Peygamberler) Console.Write (p+" "); Console.WriteLine();
            }
            IEnumerable<char> sorgu1c = peygamberler.SelectMany (p => (p+" ").ToArray());
            Console.Write ("-->T�m {0} adet <char> peygamber adlar�: ", sorgu1c.Count());
            foreach (char k in sorgu1c) Console.Write (k); Console.WriteLine();
            IEnumerable<char> sorgu1d = peygamberler
                .SelectMany ((p, e) => e < 5 ? (p+" ").ToArray() : p.ToArray());
            Console.Write ("-->T�m {0} adet <char> peygamber adlar�: ", sorgu1d.Count());
            foreach (char k in sorgu1d) Console.Write (k); Console.WriteLine();

            Console.WriteLine ("\nAr�iv int ve string metot gruplar�n�n sorgulanmas�:");
            var sorgu2a = from m in typeof(int).GetMethods()
                orderby m.Name
                group m by m.Name into g
                select new {Ad = g.Key, Metotlar = g};
            Console.WriteLine ("-->T�m {0} adet int metot gruplar�:", sorgu2a.Count());
            foreach (var g in sorgu2a) {
                Console.WriteLine ("[{0}] anahtarl� metotlar:", g.Ad);
                foreach (var m in g.Metotlar) Console.WriteLine ("\t{0}", m);
            }
            var sorgu2b = from m in typeof(string).GetMethods()
                orderby m.Name
                group m by m.Name into g
                select new {Ad = g.Key};
            Console.Write ("-->T�m {0} adet string metot grup adlar�: ", sorgu2b.Count());
            foreach (var g in sorgu2b) Console.Write (g.Ad+" "); Console.WriteLine();

            Console.WriteLine ("\nTemas ve �ye s�n�f bilgilerinin birle�ik 'new Temas{}' se�imi:");
            ArrayList �yeler = �ye.�yeleriAl();
            Temas[] temaslar = �yeler
                .Cast<�ye>() //ArrayList-->List<�ye>
                .Select (� => new Temas {
                    No = �.no,
                    �sim = string.Format ("{0} {1}", �.ad, �.soyad),
                    �leti�im = string.Format ("{0} / {1}", �.eposta, �.gsm)})
                .ToArray<Temas>();
            Temas.Eri�imListesi (temaslar);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}