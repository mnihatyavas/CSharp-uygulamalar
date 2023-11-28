// j2sc#0718b.cs: Sýnýf alan deðerinin set-get'li özellikle konulmasý-alýnmasý örneði.

using System;
using System.Reflection;
namespace Sýnýflar {
    public sealed class Deðer {public int ts = 20231022;}
    public sealed class Kontrol {
        private readonly Deðer nesne;
        public Kontrol (Deðer nesne) {this.nesne = nesne;} //Kurucu
        public int TS {get {return nesne.ts;}}
    }
    class Kiþi {
        private string _soyadý;
        private string _adý;
        public void AdlarýKoy (string adý, string soyadý) {_soyadý = soyadý; _adý = adý;}
        public string TamAdKoyAl {
            get {return _adý + " " + _soyadý;}
            set {
                string[] adlar = value.Split (' '); //' ' ==> new string[] {" "}, StringSplitOptions.RemoveEmptyEntries
                _adý = adlar [0];
                _soyadý = adlar [adlar.Length - 1];
            }
        }
    }
    public class Sýnýf {
        private int ts;
        public Sýnýf (int i) {ts = i;} //Kurucuyla deðer atama
        public int TS {set {ts = value;} get {return ts;}} //Özellik'le deðer koyma alma
    }
    public class AdYaþ {
        public readonly string isim;
        private int yaþ;
        public int Yaþ {
            set {if (value >= 0 && value <= 100) yaþ = value; else throw (new ArgumentOutOfRangeException ("[0 <= Yaþ <= 120] arasýnda olmalýdýr!"));}
            get {return yaþ;}
        }
        public override string ToString() {return (isim + "'ýn yaþý: " + yaþ);}
        private AdYaþ() : this ("Varsayýlý isim"){}
        public AdYaþ (string isim) {this.isim = isim; yaþ = 0;}
    }
    class Tarih {
        DateTime[] tarihler = new DateTime [5];
        private DateTime doðumTarihi;
        private string alan;
        public DateTime this [int endeks] {set {tarihler [endeks] = value;} get {return tarihler [endeks];}}
        public DateTime DoðumTarihi {set {doðumTarihi = value;} get {return doðumTarihi;}}
        public string Alan {set {alan = value;} get {return alan;}}
        public void Test() {Console.WriteLine ("Test metodu çaðrýldý.");}
    }
    public interface IAd {string AdAl();}
    public interface IAdres {string AdresiAl();}
    public class Þahýs : IAd, IAdres {
        private string ad, adres;
        public Þahýs(){}
        public string Ad {set {ad = value;}}
        public string Adres {set {adres = value;}}
        public string AdAl() {return ad;}
        public string AdresiAl() {return adres;}
    }
    public abstract class Ýþgören {public abstract string Ad {set;get;}}
    class Meslek: Ýþgören {
        string ad, vasýf;
        public override string Ad {set {ad=value;} get {return (ad);}}
        public string Vasýf {set {vasýf=value;} get {return (vasýf);}}
    }
    class Özellik2 {
        static void Main() {
            Console.Write ("Þartlý set-get kodlanabilir. Deðer koyma set'li özellik'le, alma ise return metotla yapýlabilir. Sýnýf endeksli dizileþtirilebilir (Tarih). Abstract/virtual miraslý sýnýf özelliði override yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Deðer sýnýf tamsayýsýnýn Kontrol sýnýfdaki get'li özellikle alýnmasý:");
            var r=new Random(); int i, ts1;
            Deðer deðer = new Deðer();
            Kontrol k=new Kontrol (deðer);
            Console.WriteLine ("Kuruluþtaki ilk tamsayý = {0}", k.TS);
            for(i=1;i<=5;i++) {
                deðer.ts=r.Next(10000000,100000000);
                Console.WriteLine ("{0}.inci konulup alýnan tamsayý = {1}", i, k.TS);
            }

            Console.WriteLine ("\nKurucuyla veya özellik'le ad-soyad koyup alma:");
            string[] adlar=new string[]{"Zafer Nihat Candan", "Nihal Zeliha Yavaþ Candan", "Hatice Yavaþ Kaçar", "Sevim Yavaþ", "Ali Rýza Derviþ Binboða"};
            Kiþi kiþi = new Kiþi();
            kiþi.AdlarýKoy ("Nihat", "Yavaþ"); //Kurucuyla ikili ad-soyadý koyma
            Console.WriteLine ("kiþi'nin adý ve soyadý: {0}", kiþi.TamAdKoyAl);
            for(i=0;i<5;i++) {
                kiþi.TamAdKoyAl = adlar [i]; //Özellik'le iki ve dahaçoklu addan ilk ve son adý ayýrma
                Console.WriteLine ("kiþi'nin ilkadý ve soyadý: {0}", kiþi.TamAdKoyAl);
            }

            Console.WriteLine ("\nKurucuyla veya özellik'le rasgele tamsayý koyup alma:");
            ts1=r.Next(-10000,10000);
            Sýnýf snf = new Sýnýf (ts1); Console.WriteLine ("Kurucuyla konulan sayý: {0}", snf.TS);
            for(i=1;i<=5;i++) {
                snf.TS=r.Next(-10000,10000);
                Console.WriteLine ("Özellik'le konup alýnan {0}.sayý: {1}", i, snf.TS);
            }

            Console.WriteLine ("\nKiþi yaþ hadleri hatasý fýrlatan Yaþ özelliði:");
            AdYaþ ay = new AdYaþ(""); Console.WriteLine ("AdYaþ nesnesi yaratýldý.");
            for(i=0;i<5;i++) {
                ay = new AdYaþ (adlar [i]);
                try {ts1=r.Next(-20,200);
                    ay.Yaþ=ts1;
                    Console.WriteLine ("\t"+ay.ToString());
                }catch  (Exception h) {Console.WriteLine ("Hatalý yaþ ({0}): [{1}]\nMesajý: [{2}]", ts1, h.GetType().FullName, h.Message);}
            }

            Console.WriteLine ("\nTarih dizisel nesnenin alan, özellik ve metot çaðrýlmasý:");
            Type tip = typeof (Tarih); Console.WriteLine ("Sýnýf tipi: " + tip.FullName);
            object nes = Activator.CreateInstance (tip);
            tip.InvokeMember ("", 
                BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public,
                null, nes, new object[] {0, new DateTime (2023, 10, 23, 5, 22, 54)});
            Console.WriteLine ("Tarih [0] = " + ((Tarih)nes) [0].ToString());
            Tarih t=new Tarih(); t.DoðumTarihi=new DateTime (1955, 8, 7, 14, 45, 12); Console.WriteLine ("Doðum tarihi: " + t.DoðumTarihi);
            t [0]= DateTime.Now; Console.WriteLine ("Tarih [0] = " + t [0]);
            t [1]= new DateTime (1957, 4, 7, 11, 35, 52); Console.WriteLine ("Tarih [1] = " + t [1]);
            t.Alan= "M.Nihat Yavaþ"; Console.WriteLine ("t.Alan: " + t.Alan);
            t.Test();

            Console.WriteLine ("\nSýnýf alanlarýnýn özellikle deðer koyup metotla almasý:");
            string[] adresler=new string[]{"Ýstanbul", "Malatya", "Bursa", "Ankara", "Ýzmir"};
            Þahýs þhs;
            for(i=0;i<5;i++) {
                þhs = new Þahýs();
                þhs.Ad = adlar [i]; þhs.Adres = adresler [i];
                Console.WriteLine ("{0}'ýn ikamet þehri: {1}", þhs.AdAl(), þhs.AdresiAl());
            }

            Console.WriteLine ("\nSoyut/sanal alan özelliði esgeçmeli/override olmalýdýr:");
            Meslek iþg = new Meslek(); //Referans Ýþgören olunca Vasýf þablonu da isteniyor
            iþg.Ad="Belkýs Candan"; iþg.Vasýf="Hostes"; Console.WriteLine ("{0}'ýn mesleði: {1}", iþg.Ad, iþg.Vasýf);
            iþg.Ad="Canan Candan"; iþg.Vasýf="Ziraat Mühendisi"; Console.WriteLine ("{0}'ýn mesleði: {1}", iþg.Ad, iþg.Vasýf);
            iþg.Ad="Zafer N.Candan"; iþg.Vasýf="Genetik Mühendis"; Console.WriteLine ("{0}'ýn mesleði: {1}", iþg.Ad, iþg.Vasýf);
            iþg.Ad="Atilla Göktürk"; iþg.Vasýf="Doktor"; Console.WriteLine ("{0}'ýn mesleði: {1}", iþg.Ad, iþg.Vasýf);
            iþg.Ad="Sema Özbay"; iþg.Vasýf="Öðretmen"; Console.WriteLine ("{0}'ýn mesleði: {1}", iþg.Ad, iþg.Vasýf);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}