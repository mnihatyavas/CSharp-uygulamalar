// j2sc#2204a.cs: Linq sorgu from-join-where-group-orderby-thenby-select örneði.

using System;
using System.Linq; //Where için
using System.Collections.Generic; //IEnumerable<> için
using System.Collections; //IEnumerator için
using System.Reflection; //Assembly için
namespace Query_Sorgu {
    public class Aðaç<AðaçYumrusu>: IEnumerable<AðaçYumrusu> where AðaçYumrusu: IComparable<AðaçYumrusu> {
        public AðaçYumrusu YumruVeri {get; set;}
        public Aðaç<AðaçYumrusu> SolAðaç {get; set;}
        public Aðaç<AðaçYumrusu> SaðAðaç {get; set;}
        public Aðaç (AðaçYumrusu yumruDeðer) {//Kurucu
            this.YumruVeri = yumruDeðer;
            this.SolAðaç = null;
            this.SaðAðaç = null;
        }
        public void Sok (AðaçYumrusu yeniBirim) {
            AðaçYumrusu aktüelYumruDeðer = this.YumruVeri;
            if (aktüelYumruDeðer.CompareTo (yeniBirim) > 0) {
                if (this.SolAðaç == null) this.SolAðaç = new Aðaç<AðaçYumrusu>(yeniBirim);
                else this.SolAðaç.Sok(yeniBirim);
            } else {
                if (this.SaðAðaç == null) this.SaðAðaç = new Aðaç<AðaçYumrusu>(yeniBirim);
                else this.SaðAðaç.Sok(yeniBirim);
            }
        }
        public void YürüAðaç() {
            if (this.SolAðaç != null) this.SolAðaç.YürüAðaç();
            Console.WriteLine (this.YumruVeri.ToString());
            if (this.SaðAðaç != null) this.SaðAðaç.YürüAðaç();
        }
        IEnumerator<AðaçYumrusu> IEnumerable<AðaçYumrusu>.GetEnumerator() {
            if (this.SolAðaç != null) foreach (AðaçYumrusu birim in this.SolAðaç) yield return birim;
            yield return this.YumruVeri;
            if (this.SaðAðaç != null) foreach (AðaçYumrusu birim in this.SaðAðaç) yield return birim;
        }
        IEnumerator IEnumerable.GetEnumerator() {throw new NotImplementedException();}
    }
    class Ýþçi: IComparable<Ýþçi> {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public int No {get; set;}
        public string Departman {get; set;}
        public override string ToString() {return String.Format ("Ýsim: {1} {2}, No: {0}, Bölüm: {3}", this.No, this.Ad, this.Soyad, this.Departman);}
        int IComparable<Ýþçi>.CompareTo (Ýþçi þu) {
            if (þu == null) return 1;
            if (this.No > þu.No) return 1;
            if (this.No < þu.No) return -1;
            return 0;
        }
    }
    public class Kýrtasiye {
        string ad;
        public string Ad {get {return ad;}}
        decimal fiyat;
        public decimal Fiyat {get {return fiyat;}}
        public Kýrtasiye (string a, decimal f) {ad = a; fiyat = f;} //Kurucu
        public static ArrayList KýrtasiyeleriAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new Kýrtasiye ("Defter", 168m));
            liste.Add (new Kýrtasiye ("Kalem", 56.75m));
            liste.Add (new Kýrtasiye ("Silgi", 25.35m));
            liste.Add (new Kýrtasiye ("Kalemtraþ", 75.3m));
            liste.Add (new Kýrtasiye ("Suluboya", 254.62m));
            liste.Add (new Kýrtasiye ("Fýrça", 46.87m));
            liste.Add (new Kýrtasiye ("Çanta", 758.45m));
            liste.Add (new Kýrtasiye ("Forma", 1874.5m));
            return liste;
        }
        public override string ToString() {return string.Format ("{0}: {1:#,0.00} TL", ad, fiyat);}
    }
    public class Üye {
        public string Ad {get; set;}
        public string Eposta {get; set;}
        public string GSM {get; set;}
        public override string ToString() {return string.Format ("Ýsim: {0}\tEposta: {1}\tGSM: {2}", Ad, Eposta, GSM);}
    }
    public class Adres {
        public string Ad {get; set;}
        public string Adres1 {get; set;}
        public string Adres2 {get; set;}
        public override string ToString() {return string.Format ("{0}; {1}", Adres1, Adres2);}
    }
    class Bayii {
        public string No {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro;
        public override string ToString() {return "No: " + No + " Þehir: " + Þehir + " Ülke: " + Ülke + " Kýta: " + Kýta + " Ciro: " + Ciro;}
    }
    class Sipariþ {
        public string No {get; set;}
        public decimal Tutar {get; set;}
    }
    class Sorgu {
        static void Main() {
            Console.Write ("from-select sorgularý taranabilir IEnumerable veri tipleri üzerinde uygulanabilir; deðilse taranabilire dönüþtürülmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberler dizisini çeþitli IEnumerable<> sorgularla seçme:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            var sorgu1a = from pey in peygamberler
                where pey.Length > 5
                select pey;
            Console.Write ("-->{0} adet (pey.Length > 5) peygamberler: ", sorgu1a.Count());
            foreach (var p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1b = peygamberler
                .Where (p => p.Contains ("u"))
                .OrderBy (p => p.Length)
                .Select (p => p.ToUpper());
            Console.Write ("-->{0} adet (u-harfli, kýsadan uzuna, büyükharfe) peygamberler: ", sorgu1b.Count());
            foreach (var p in sorgu1b) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1c = peygamberler.Where (p => p.Contains ("a"));
            IEnumerable<string> sorgu1d = sorgu1c.OrderByDescending (p => p.Length);
            IEnumerable<string> sorgu1e = sorgu1d.Select (p => p.ToUpper());
            Console.Write ("==>{0} adet (a-harfli) peygamberler: ", sorgu1c.Count());
            foreach (var p in sorgu1c) Console.Write (p+" "); Console.WriteLine();
            Console.Write ("-->{0} adet (a-harfli, uzundan kýsaya) peygamberler: ", sorgu1d.Count());
            foreach (var p in sorgu1d) Console.Write (p+" "); Console.WriteLine();
            Console.Write ("-->{0} adet (a-harfli, uzundan kýsaya, büyükharfe) peygamberler: ", sorgu1e.Count());
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            var sorgu1f = from pey in peygamberler
                group pey by pey.Substring (0, 1) into grup
                orderby grup.Key
                select grup;
            Console.WriteLine ("==>{0} adet (ilkharf grup sýralý) peygamberler: ", sorgu1f.Count());
            foreach (var pharf in sorgu1f) {
                Console.WriteLine ("-->Anahtar harf: " + pharf.Key);
                foreach (String p in pharf) Console.Write (p+" "); Console.WriteLine();
            }
            String[] harfler = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "Ý", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            var sorgu1g = 
                from harf in harfler
                join pey in peygamberler on harf equals pey.Substring (0, 1)
                select new {harf, pey};
            Console.WriteLine ("==>{0} adet (harfendeksli) peygamberler: ", sorgu1g.Count());
            foreach (var p in sorgu1g)
            Console.Write (p.harf + ":" + p.pey + " "); Console.WriteLine();

            Console.WriteLine ("\nAðaç<Ýþçi> sýnýf tipli iþçileri artan No'lu sok'ma ve sorgulu seçimler:");
            Aðaç<Ýþçi> iþçiAðacý = new Aðaç<Ýþçi>(new Ýþçi {No = 1953, Ad = "Süheyla", Soyad = "Özbay", Departman = "Ýmalat"});
            iþçiAðacý.Sok (new Ýþçi {No = 1963, Ad = "Sevim", Soyad = "Yavaþ", Departman = "Pazarlama"});
            iþçiAðacý.Sok (new Ýþçi {No = 1957, Ad = "M.Nihat", Soyad = "Yavaþ", Departman = "Satýþ"});
            iþçiAðacý.Sok (new Ýþçi {No = 1961, Ad = "M.Nedim", Soyad = "Yavaþ", Departman = "Pazarlama"});
            iþçiAðacý.Sok (new Ýþçi {No = 1951, Ad = "Hatice", Soyad = "Kaçar", Departman = "Muhasebe"});
            iþçiAðacý.Sok (new Ýþçi {No = 1955, Ad = "Zeliha", Soyad = "Candan", Departman = "Satýþ"});
            iþçiAðacý.Sok (new Ýþçi {No = 1959, Ad = "Songül", Soyad = "Göktürk", Departman = "Muhasebe"});
            var sorgu2a = from iþ in iþçiAðacý.ToList<Ýþçi>() select iþ;
            Console.WriteLine ("-->Tüm {0} iþçiler:", sorgu2a.Count());
            foreach (var iþ in sorgu2a) Console.WriteLine (iþ);
            var sorgu2b = iþçiAðacý.Select (d => d.Departman).Distinct();
            Console.Write ("-->{0} adet farklý departmanlar: ", sorgu2b.Count());
            foreach (var d in sorgu2b) Console.Write (d+" "); Console.WriteLine();
            var sorgu2c = iþçiAðacý.Where (iþ => String.Equals (iþ.Departman, "Satýþ")).Select (iþ => iþ);
            Console.WriteLine ("-->{0} adet 'Satýþ' elemanlarý:", sorgu2c.Count());
            foreach (var iþ in sorgu2c) Console.WriteLine (iþ);
            var sorgu2d = iþçiAðacý.GroupBy (iþ => iþ.Departman);
            Console.WriteLine ("-->{0} adet iþçili departman:", sorgu2d.Count());
            foreach (var d in sorgu2d) {
                Console.WriteLine ("Departman: {0}", d.Key);
                foreach (var iþ in d) Console.WriteLine ("\t{0}: {1} {2}", iþ.No, iþ.Ad, iþ.Soyad);
            }

            Console.WriteLine ("\nOkul öðrenci masraflarýný planlamaya dair:");
            ArrayList mekteplik = Kýrtasiye.KýrtasiyeleriAl();
            Console.WriteLine ("-->{0} adet mektep kýrtasiyeleri listesi:", mekteplik.Count);
            foreach (Kýrtasiye k in mekteplik) Console.WriteLine (k);
            Console.WriteLine ("-->Fiyat < 500 kýrtasiyeler:");
            foreach (Kýrtasiye k in mekteplik) if(k.Fiyat < 500m)  Console.WriteLine (k);
            var sorgu3 = ((Kýrtasiye[])mekteplik.ToArray (typeof (Kýrtasiye))).OrderByDescending (k => k.Fiyat);
            Console.WriteLine ("-->Azalan fiyatla kýrtasiyeler:");
            foreach (var k in sorgu3) Console.WriteLine (k);

            Console.WriteLine ("\nÝki listeyi ad'la birleþtirip, çoklu kayýtlarý ad&þehir'le sýralama:");
            List<Üye> üyeler = new List<Üye> {
                new Üye {Ad = "Hüseyin Kurt", Eposta = "huseyinkurt@gmail.com", GSM = "0555-551-6575"},
                new Üye {Ad = "Fatih Kaplan", Eposta = "fatihkaplan@gmail.com", GSM = "0555-551-6576"},
                new Üye {Ad = "Hülya Piray", Eposta = "hulyapiray@gmail.com", GSM = "0555-551-6577"},
                new Üye {Ad = "Selim Dikel", Eposta = "selimdikel@gmail.com", GSM = "0555-551-6578"},
                new Üye {Ad = "Ali Eralp", Eposta = "alieralp@gmail.com", GSM = "0555-551-6579"},
                new Üye {Ad = "Özgür Özel", Eposta = "ozgurozel@gmail.com", GSM = "0555-551-6580"}
            };
            List<Adres> adresler = new List<Adres> {
                new Adres {Ad = "Fatih Kaplan", Adres1 = "Beykoz Cd. N0: 45215/8A", Adres2 = "Ýstanbul-Çengelköy"},
                new Adres {Ad = "M.Nihat Yavaþ", Adres1 = "Kuvayi Milliye Cd. N0: 95/3B", Adres2 = "Mersin-Toroslar"},
                new Adres {Ad = "Hüseyin Kurt", Adres1 = "Cumhuriyet Cd. N0: 85/2A", Adres2 = "Mersin-Akdeniz"},
                new Adres {Ad = "Fatih Kaplan", Adres1 = "GMK Cd. N0: 105/12D", Adres2 = "Mersin-Mezitler"},
                new Adres {Ad = "Özgür Özel", Adres1 = "Tandoðan Cd. N0: 382/9C", Adres2 = "Ankara-Maltepe"},
                new Adres {Ad = "Fatih Kaplan", Adres1 = "Maksem Cd. N0: 15/18A", Adres2 = "Bursa-Temenyeri"},
                new Adres {Ad = "Selim Dikel", Adres1 = "Fahri Korutürk Cd. N0: 15/7A", Adres2 = "Ýstanbul-Maltepe"}
            };
            var sorgu4a = üyeler.Join (adresler,
                ü => ü.Ad,
                a => a.Ad,
                (ü, a) => new {Üye = ü, Adres = a})
                .OrderBy (üa => üa.Üye.Ad)
                .ThenByDescending (üa => üa.Adres.Adres2);
            Console.WriteLine ("-->{0} adet birleþik üye-adres artan ad azalan þehir:", sorgu4a.Count());
            foreach (var üa in sorgu4a) Console.WriteLine ("{0}\n\tAdres: {1}", üa.Üye, üa.Adres);
            IEnumerable<Adres> sorgu4b = adresler.Where (a => a.Ad == "Fatih Kaplan").OrderBy (a => a.Adres2);
            Console.WriteLine ("-->{0} adet artan þehir'li '{1}':", sorgu4b.Count(), "Fatih Kaplan");
            foreach (var a in sorgu4b) Console.WriteLine (a);

            Console.WriteLine ("\nBayilerin kýtasal ciro toplamlarýnýn sorgulanmasý:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m},
                new Bayii {No="2024P", Þehir="Kahire", Ülke="Mýsýr", Kýta="Afrika", Ciro=7285.76m}
            };
            var sorgu5a =
                from b in bayiler
                group b by b.Kýta into g
                select new {Satýþlar = g.Sum (b => b.Ciro), Kýta = g.Key};
            var sorgu5b =
                from g in sorgu5a
                orderby g.Satýþlar
                select g;
            var sorgu5c = from g in sorgu5a orderby g.Kýta select g;
            Console.WriteLine ("-->{0} adet bayi kýtasý ve kýtasal ciro toplamlarý:", sorgu5a.Count());
            foreach (var gr in sorgu5a) Console.WriteLine (gr);
            Console.WriteLine ("-->Bayi kýtasal ciro artan toplamlarý:");
            foreach (var gr in sorgu5b) Console.WriteLine ("{0,-6}: ${1}", gr.Kýta, gr.Satýþlar);
            Console.WriteLine ("-->Bayi artan kýtasal ciro toplamlarý:");
            foreach (var gr in sorgu5c) Console.WriteLine ("{0,-6}: ${1}", gr.Kýta, gr.Satýþlar);
            List<Sipariþ> sipariþler = new List<Sipariþ> {
                new Sipariþ {No="2024T", Tutar=954.12m},
                new Sipariþ {No="2024Q", Tutar=1265.87m},
                new Sipariþ {No="2024P", Tutar=2168.13m}
            };
            var sorgu5d =
                from b in bayiler
                join s in sipariþler on b.No equals s.No
                select new {b.No, b.Þehir, b.Ciro, Sipariþ = s.Tutar, SonCiro = b.Ciro+s.Tutar};
            Console.WriteLine ("-->{0} adet sipariþli bayilerin son ciro toplamlarý:", sorgu5d.Count());
            foreach (var b in sorgu5d) Console.WriteLine (b);

            string formAdlarý = "System.Windows.Forms,Version=2.0.0.0,PublicKeyToken=b77a5c561934e089,Culture=\"\"";
            Assembly kurgu = Assembly.Load (formAdlarý);
            Type[] tipler = kurgu.GetTypes();
            var sorgu6 = from form in tipler where form.IsEnum && form.IsPublic select form;
            Console.WriteLine ("\n{0} adet genel&taranabilir System.Windows.Forms:", sorgu6.Count());
            foreach (var f in sorgu6) Console.WriteLine (f);

            Console.WriteLine ("\nEnum Linq Metotlarýnýn sorgulanmasý:");
            var sorgu7 = from m in typeof (Enumerable).GetMethods()
                orderby m.Name
                where m.DeclaringType == typeof (Enumerable)                        
                group m by m.Name into g
                orderby g.Count()
                select new {EnumMetot = g.Key, GrupSayýsý = g.Count()};
            Console.WriteLine ("-->{0} adet Enum-Metot artan grup sayýlý listesi:", sorgu7.Count());
            foreach (var gm in sorgu7) Console.WriteLine (gm);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}