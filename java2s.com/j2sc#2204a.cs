// j2sc#2204a.cs: Linq sorgu from-join-where-group-orderby-thenby-select �rne�i.

using System;
using System.Linq; //Where i�in
using System.Collections.Generic; //IEnumerable<> i�in
using System.Collections; //IEnumerator i�in
using System.Reflection; //Assembly i�in
namespace Query_Sorgu {
    public class A�a�<A�a�Yumrusu>: IEnumerable<A�a�Yumrusu> where A�a�Yumrusu: IComparable<A�a�Yumrusu> {
        public A�a�Yumrusu YumruVeri {get; set;}
        public A�a�<A�a�Yumrusu> SolA�a� {get; set;}
        public A�a�<A�a�Yumrusu> Sa�A�a� {get; set;}
        public A�a� (A�a�Yumrusu yumruDe�er) {//Kurucu
            this.YumruVeri = yumruDe�er;
            this.SolA�a� = null;
            this.Sa�A�a� = null;
        }
        public void Sok (A�a�Yumrusu yeniBirim) {
            A�a�Yumrusu akt�elYumruDe�er = this.YumruVeri;
            if (akt�elYumruDe�er.CompareTo (yeniBirim) > 0) {
                if (this.SolA�a� == null) this.SolA�a� = new A�a�<A�a�Yumrusu>(yeniBirim);
                else this.SolA�a�.Sok(yeniBirim);
            } else {
                if (this.Sa�A�a� == null) this.Sa�A�a� = new A�a�<A�a�Yumrusu>(yeniBirim);
                else this.Sa�A�a�.Sok(yeniBirim);
            }
        }
        public void Y�r�A�a�() {
            if (this.SolA�a� != null) this.SolA�a�.Y�r�A�a�();
            Console.WriteLine (this.YumruVeri.ToString());
            if (this.Sa�A�a� != null) this.Sa�A�a�.Y�r�A�a�();
        }
        IEnumerator<A�a�Yumrusu> IEnumerable<A�a�Yumrusu>.GetEnumerator() {
            if (this.SolA�a� != null) foreach (A�a�Yumrusu birim in this.SolA�a�) yield return birim;
            yield return this.YumruVeri;
            if (this.Sa�A�a� != null) foreach (A�a�Yumrusu birim in this.Sa�A�a�) yield return birim;
        }
        IEnumerator IEnumerable.GetEnumerator() {throw new NotImplementedException();}
    }
    class ���i: IComparable<���i> {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public int No {get; set;}
        public string Departman {get; set;}
        public override string ToString() {return String.Format ("�sim: {1} {2}, No: {0}, B�l�m: {3}", this.No, this.Ad, this.Soyad, this.Departman);}
        int IComparable<���i>.CompareTo (���i �u) {
            if (�u == null) return 1;
            if (this.No > �u.No) return 1;
            if (this.No < �u.No) return -1;
            return 0;
        }
    }
    public class K�rtasiye {
        string ad;
        public string Ad {get {return ad;}}
        decimal fiyat;
        public decimal Fiyat {get {return fiyat;}}
        public K�rtasiye (string a, decimal f) {ad = a; fiyat = f;} //Kurucu
        public static ArrayList K�rtasiyeleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new K�rtasiye ("Defter", 168m));
            liste.Add (new K�rtasiye ("Kalem", 56.75m));
            liste.Add (new K�rtasiye ("Silgi", 25.35m));
            liste.Add (new K�rtasiye ("Kalemtra�", 75.3m));
            liste.Add (new K�rtasiye ("Suluboya", 254.62m));
            liste.Add (new K�rtasiye ("F�r�a", 46.87m));
            liste.Add (new K�rtasiye ("�anta", 758.45m));
            liste.Add (new K�rtasiye ("Forma", 1874.5m));
            return liste;
        }
        public override string ToString() {return string.Format ("{0}: {1:#,0.00} TL", ad, fiyat);}
    }
    public class �ye {
        public string Ad {get; set;}
        public string Eposta {get; set;}
        public string GSM {get; set;}
        public override string ToString() {return string.Format ("�sim: {0}\tEposta: {1}\tGSM: {2}", Ad, Eposta, GSM);}
    }
    public class Adres {
        public string Ad {get; set;}
        public string Adres1 {get; set;}
        public string Adres2 {get; set;}
        public override string ToString() {return string.Format ("{0}; {1}", Adres1, Adres2);}
    }
    class Bayii {
        public string No {get; set;}
        public string �ehir {get; set;}
        public string �lke {get; set;}
        public string K�ta {get; set;}
        public decimal Ciro;
        public override string ToString() {return "No: " + No + " �ehir: " + �ehir + " �lke: " + �lke + " K�ta: " + K�ta + " Ciro: " + Ciro;}
    }
    class Sipari� {
        public string No {get; set;}
        public decimal Tutar {get; set;}
    }
    class Sorgu {
        static void Main() {
            Console.Write ("from-select sorgular� taranabilir IEnumerable veri tipleri �zerinde uygulanabilir; de�ilse taranabilire d�n��t�r�lmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberler dizisini �e�itli IEnumerable<> sorgularla se�me:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            var sorgu1a = from pey in peygamberler
                where pey.Length > 5
                select pey;
            Console.Write ("-->{0} adet (pey.Length > 5) peygamberler: ", sorgu1a.Count());
            foreach (var p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1b = peygamberler
                .Where (p => p.Contains ("u"))
                .OrderBy (p => p.Length)
                .Select (p => p.ToUpper());
            Console.Write ("-->{0} adet (u-harfli, k�sadan uzuna, b�y�kharfe) peygamberler: ", sorgu1b.Count());
            foreach (var p in sorgu1b) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1c = peygamberler.Where (p => p.Contains ("a"));
            IEnumerable<string> sorgu1d = sorgu1c.OrderByDescending (p => p.Length);
            IEnumerable<string> sorgu1e = sorgu1d.Select (p => p.ToUpper());
            Console.Write ("==>{0} adet (a-harfli) peygamberler: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.Write (p+" "); Console.WriteLine();
            Console.Write ("-->{0} adet (a-harfli, uzundan k�saya) peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            Console.Write ("-->{0} adet (a-harfli, uzundan k�saya, b�y�kharfe) peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            var sorgu1f = from pey in peygamberler
                group pey by pey.Substring (0, 1) into grup
                orderby grup.Key
                select grup;
            Console.WriteLine ("==>{0} adet (ilkharf grup s�ral�) peygamberler: ", sorgu1f.Count());
            foreach (var pharf in sorgu1f) {
                Console.WriteLine ("-->Anahtar harf: " + pharf.Key);
                foreach (String p in pharf) Console.Write (p+" "); Console.WriteLine();
            }
            String[] harfler = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "�", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            var sorgu1g = 
                from harf in harfler
                join pey in peygamberler on harf equals pey.Substring (0, 1)
                select new {harf, pey};
            Console.WriteLine ("==>{0} adet (harfendeksli) peygamberler: ", sorgu1g.Count());
            foreach (var p in sorgu1g)
            Console.Write (p.harf + ":" + p.pey + " "); Console.WriteLine();

            Console.WriteLine ("\nA�a�<���i> s�n�f tipli i��ileri artan No'lu sok'ma ve sorgulu se�imler:");
            A�a�<���i> i��iA�ac� = new A�a�<���i>(new ���i {No = 1953, Ad = "S�heyla", Soyad = "�zbay", Departman = "�malat"});
            i��iA�ac�.Sok (new ���i {No = 1963, Ad = "Sevim", Soyad = "Yava�", Departman = "Pazarlama"});
            i��iA�ac�.Sok (new ���i {No = 1957, Ad = "M.Nihat", Soyad = "Yava�", Departman = "Sat��"});
            i��iA�ac�.Sok (new ���i {No = 1961, Ad = "M.Nedim", Soyad = "Yava�", Departman = "Pazarlama"});
            i��iA�ac�.Sok (new ���i {No = 1951, Ad = "Hatice", Soyad = "Ka�ar", Departman = "Muhasebe"});
            i��iA�ac�.Sok (new ���i {No = 1955, Ad = "Zeliha", Soyad = "Candan", Departman = "Sat��"});
            i��iA�ac�.Sok (new ���i {No = 1959, Ad = "Song�l", Soyad = "G�kt�rk", Departman = "Muhasebe"});
            var sorgu2a = from i� in i��iA�ac�.ToList<���i>() select i�;
            Console.WriteLine ("-->T�m {0} i��iler:", sorgu2a.Count());
            foreach (var i� in sorgu2a) Console.WriteLine (i�);
            var sorgu2b = i��iA�ac�.Select (d => d.Departman).Distinct();
            Console.Write ("-->{0} adet farkl� departmanlar: ", sorgu2b.Count());
            foreach (var d in sorgu2b) Console.Write (d+" "); Console.WriteLine();
            var sorgu2c = i��iA�ac�.Where (i� => String.Equals (i�.Departman, "Sat��")).Select (i� => i�);
            Console.WriteLine ("-->{0} adet 'Sat��' elemanlar�:", sorgu2c.Count());
            foreach (var i� in sorgu2c) Console.WriteLine (i�);
            var sorgu2d = i��iA�ac�.GroupBy (i� => i�.Departman);
            Console.WriteLine ("-->{0} adet i��ili departman:", sorgu2d.Count());
            foreach (var d in sorgu2d) {
                Console.WriteLine ("Departman: {0}", d.Key);
                foreach (var i� in d) Console.WriteLine ("\t{0}: {1} {2}", i�.No, i�.Ad, i�.Soyad);
            }

            Console.WriteLine ("\nOkul ��renci masraflar�n� planlamaya dair:");
            ArrayList mekteplik = K�rtasiye.K�rtasiyeleriAl();
            Console.WriteLine ("-->{0} adet mektep k�rtasiyeleri listesi:", mekteplik.Count);
            foreach (K�rtasiye k in mekteplik) Console.WriteLine (k);
            Console.WriteLine ("-->Fiyat < 500 k�rtasiyeler:");
            foreach (K�rtasiye k in mekteplik) if(k.Fiyat < 500m)  Console.WriteLine (k);
            var sorgu3 = ((K�rtasiye[])mekteplik.ToArray (typeof (K�rtasiye))).OrderByDescending (k => k.Fiyat);
            Console.WriteLine ("-->Azalan fiyatla k�rtasiyeler:");
            foreach (var k in sorgu3) Console.WriteLine (k);

            Console.WriteLine ("\n�ki listeyi ad'la birle�tirip, �oklu kay�tlar� ad&�ehir'le s�ralama:");
            List<�ye> �yeler = new List<�ye> {
                new �ye {Ad = "H�seyin Kurt", Eposta = "huseyinkurt@gmail.com", GSM = "0555-551-6575"},
                new �ye {Ad = "Fatih Kaplan", Eposta = "fatihkaplan@gmail.com", GSM = "0555-551-6576"},
                new �ye {Ad = "H�lya Piray", Eposta = "hulyapiray@gmail.com", GSM = "0555-551-6577"},
                new �ye {Ad = "Selim Dikel", Eposta = "selimdikel@gmail.com", GSM = "0555-551-6578"},
                new �ye {Ad = "Ali Eralp", Eposta = "alieralp@gmail.com", GSM = "0555-551-6579"},
                new �ye {Ad = "�zg�r �zel", Eposta = "ozgurozel@gmail.com", GSM = "0555-551-6580"}
            };
            List<Adres> adresler = new List<Adres> {
                new Adres {Ad = "Fatih Kaplan", Adres1 = "Beykoz Cd. N0: 45215/8A", Adres2 = "�stanbul-�engelk�y"},
                new Adres {Ad = "M.Nihat Yava�", Adres1 = "Kuvayi Milliye Cd. N0: 95/3B", Adres2 = "Mersin-Toroslar"},
                new Adres {Ad = "H�seyin Kurt", Adres1 = "Cumhuriyet Cd. N0: 85/2A", Adres2 = "Mersin-Akdeniz"},
                new Adres {Ad = "Fatih Kaplan", Adres1 = "GMK Cd. N0: 105/12D", Adres2 = "Mersin-Mezitler"},
                new Adres {Ad = "�zg�r �zel", Adres1 = "Tando�an Cd. N0: 382/9C", Adres2 = "Ankara-Maltepe"},
                new Adres {Ad = "Fatih Kaplan", Adres1 = "Maksem Cd. N0: 15/18A", Adres2 = "Bursa-Temenyeri"},
                new Adres {Ad = "Selim Dikel", Adres1 = "Fahri Korut�rk Cd. N0: 15/7A", Adres2 = "�stanbul-Maltepe"}
            };
            var sorgu4a = �yeler.Join (adresler,
                � => �.Ad,
                a => a.Ad,
                (�, a) => new {�ye = �, Adres = a})
                .OrderBy (�a => �a.�ye.Ad)
                .ThenByDescending (�a => �a.Adres.Adres2);
            Console.WriteLine ("-->{0} adet birle�ik �ye-adres artan ad azalan �ehir:", sorgu4a.Count());
            foreach (var �a in sorgu4a) Console.WriteLine ("{0}\n\tAdres: {1}", �a.�ye, �a.Adres);
            IEnumerable<Adres> sorgu4b = adresler.Where (a => a.Ad == "Fatih Kaplan").OrderBy (a => a.Adres2);
            Console.WriteLine ("-->{0} adet artan �ehir'li '{1}':", sorgu4b.Count(), "Fatih Kaplan");
            foreach (var a in sorgu4b) Console.WriteLine (a);

            Console.WriteLine ("\nBayilerin k�tasal ciro toplamlar�n�n sorgulanmas�:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024Q", �ehir="Londra", �lke="BK", K�ta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", �ehir="Beijing", �lke="�in", K�ta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", �ehir="�stanbul", �lke="T�rkiye", K�ta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", �ehir="Ankara", �lke="T�rkiye", K�ta="Asya", Ciro=5742.34m},
                new Bayii {No="2024P", �ehir="Kahire", �lke="M�s�r", K�ta="Afrika", Ciro=7285.76m}
            };
            var sorgu5a =
                from b in bayiler
                group b by b.K�ta into g
                select new {Sat��lar = g.Sum (b => b.Ciro), K�ta = g.Key};
            var sorgu5b =
                from g in sorgu5a
                orderby g.Sat��lar
                select g;
            var sorgu5c = from g in sorgu5a orderby g.K�ta select g;
            Console.WriteLine ("-->{0} adet bayi k�tas� ve k�tasal ciro toplamlar�:", sorgu5a.Count());
            foreach (var gr in sorgu5a) Console.WriteLine (gr);
            Console.WriteLine ("-->Bayi k�tasal ciro artan toplamlar�:");
            foreach (var gr in sorgu5b) Console.WriteLine ("{0,-6}: ${1}", gr.K�ta, gr.Sat��lar);
            Console.WriteLine ("-->Bayi artan k�tasal ciro toplamlar�:");
            foreach (var gr in sorgu5c) Console.WriteLine ("{0,-6}: ${1}", gr.K�ta, gr.Sat��lar);
            List<Sipari�> sipari�ler = new List<Sipari�> {
                new Sipari� {No="2024T", Tutar=954.12m},
                new Sipari� {No="2024Q", Tutar=1265.87m},
                new Sipari� {No="2024P", Tutar=2168.13m}
            };
            var sorgu5d =
                from b in bayiler
                join s in sipari�ler on b.No equals s.No
                select new {b.No, b.�ehir, b.Ciro, Sipari� = s.Tutar, SonCiro = b.Ciro+s.Tutar};
            Console.WriteLine ("-->{0} adet sipari�li bayilerin son ciro toplamlar�:", sorgu5d.Count());
            foreach (var b in sorgu5d) Console.WriteLine (b);

            string formAdlar� = "System.Windows.Forms,Version=2.0.0.0,PublicKeyToken=b77a5c561934e089,Culture=\"\"";
            Assembly kurgu = Assembly.Load (formAdlar�);
            Type[] tipler = kurgu.GetTypes();
            var sorgu6 = from form in tipler where form.IsEnum && form.IsPublic select form;
            Console.WriteLine ("\n{0} adet genel&taranabilir System.Windows.Forms:", sorgu6.Count());
            foreach (var f in sorgu6) Console.WriteLine (f);

            Console.WriteLine ("\nEnum Linq Metotlar�n�n sorgulanmas�:");
            var sorgu7 = from m in typeof (Enumerable).GetMethods()
                orderby m.Name
                where m.DeclaringType == typeof (Enumerable)                        
                group m by m.Name into g
                orderby g.Count()
                select new {EnumMetot = g.Key, GrupSay�s� = g.Count()};
            Console.WriteLine ("-->{0} adet Enum-Metot artan grup say�l� listesi:", sorgu7.Count());
            foreach (var gm in sorgu7) Console.WriteLine (gm);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}