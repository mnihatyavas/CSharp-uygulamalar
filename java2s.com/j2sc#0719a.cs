// j2sc#0719a.cs: Tek/çift boyutlu, yalýn ve ArrayList/ListDictionary'li endeksleyici örneði.

using System;
using System.Collections; //ArrayList için
using System.Collections.Specialized; //ListDictionary için
namespace Sýnýflar {
    class ÇiftAlanlý {
        string ad; //private alan
        object veri;
        public ÇiftAlanlý (string ad, object veri) {this.ad = ad; this.veri = veri;} //Çift parametreli kurucu
        public string Ad {set {ad = value;} get {return(ad);}} //Koy-al public özellik
        public object Veri {set {veri = value;} get {return(veri);}}
    }
    class ÇiftAlanlýListe {
        ArrayList ikili;
        public ÇiftAlanlýListe() {ikili = new ArrayList();} //Parametresiz kurucu
        public void DiziyeEkle() {
            ikili.Add (new ÇiftAlanlý ("M.Nihat Yavaþ", 43879353585));
            ikili.Add (new ÇiftAlanlý ("Yücel Küçükbay", "Çarþamba - BURSA"));
            ikili.Add (new ÇiftAlanlý ("Atilla Gökyiðit", 33519.23m+" TL"));
            ikili.Add (new ÇiftAlanlý ("Belkýs Candan", "Yurtdýþý Hostes"));
            ikili.Add (new ÇiftAlanlý ("Fatih Özbay", "Karþýyaka - ÝZMÝR"));
        }
        public ÇiftAlanlý this [int endeks] {set {ikili [endeks] = value;} get {return ((ÇiftAlanlý) ikili [endeks]);}}
    }
    class ÇiftAlanlý2 {
        string ad; //private alan
        object veri;
        public ÇiftAlanlý2 (string ad, object veri) {this.ad = ad; this.veri = veri;} //Çift parametreli kurucu
        public string Ad {set {ad = value;} get {return(ad);}} //Koy-al public özellik
        public object Veri {set {veri = value;} get {return(veri);}}
    }
    class ÇiftAlanlýListe2 {
        ArrayList ikili;
        public ÇiftAlanlýListe2() {ikili = new ArrayList();} //Parametresiz kurucu
        public void DiziyeEkle() {
            ikili.Add (new ÇiftAlanlý2 ("M.Nihat Yavaþ", 43879353585));
            ikili.Add (new ÇiftAlanlý2 ("Yücel Küçükbay", "Çarþamba - BURSA"));
            ikili.Add (new ÇiftAlanlý2 ("Atilla Gökyiðit", 33519.23m+" TL"));
            ikili.Add (new ÇiftAlanlý2 ("Belkýs Candan", "Yurtdýþý Hostesi"));
            ikili.Add (new ÇiftAlanlý2 ("Fatih Özbay", "Karþýyaka - ÝZMÝR"));
        }
        public ÇiftAlanlý2 this [int endeks] {set {ikili [endeks] = value;} get {return ((ÇiftAlanlý2) ikili [endeks]);}}
        int AdBul (string ad) {
            for (int endeks = 0; endeks < ikili.Count; endeks++) {
                ÇiftAlanlý2 ça = (ÇiftAlanlý2) ikili [endeks];
                if (ça.Ad == ad) return(endeks);
            } return(-1);
        }
        public ÇiftAlanlý2 this [string ad] {set {this [AdBul (ad)] = value;} get {return((ÇiftAlanlý2)this [AdBul (ad)]);}}
    }
    public class Hücre {
        string ad;
        public Hücre (string ad) {this.ad = ad;}
        public override string ToString() {return(ad);}
    }
    public class Tablo {
        Hücre [,] tablo = new Hücre [26, 10]; //[A-->Z, 0-->9]
        int SatýrEndeksi (string satýr) {return((int) satýr [0]);}
        int SütunEndeksi (string sütun) {return (sütun [0]);}
        public Hücre this [string satýr, int sütun] {
            set {tablo [SatýrEndeksi (satýr), sütun] = value;}
            get {return (tablo [SatýrEndeksi (satýr), sütun]);}
        } 
    }
    public class Ýþgören {
        public string isim = "";
        public double maaþ = 0D;
        public Ýþgören (string i, double m) {isim = i; maaþ=m;} //Çift parametreli kurucu
    }
    public class ÝþgörenListesi : IEnumerable {
        private ArrayList diziListesi;
        public ÝþgörenListesi() {diziListesi = new ArrayList();} //Parametresiz kurucu
        public Ýþgören this [int endeks] {//Endeksleyici
            set {diziListesi.Insert (endeks, value);}
            get {if (endeks < 0) throw new IndexOutOfRangeException ("Hey! Negatif endeks olmaz"); else return (Ýþgören)diziListesi [endeks];}
        }
        public int ListeEbatýnýAl() {return diziListesi.Count;}
        public IEnumerator GetEnumerator() {return diziListesi.GetEnumerator();}
    }
    public class Ýþgören2 {
        public string isim = "";
        public double maaþ = 0D;
        public Ýþgören2 (string i, double m) {isim = i; maaþ=m;} //Çift parametreli kurucu
    }
    public class ÝþgörenListesi2 {
        private ListDictionary listeSözlüðü;
        public ÝþgörenListesi2() {listeSözlüðü = new ListDictionary();}
        public Ýþgören2 this [string ad] {//Dizgesel endeksleyici
            set {listeSözlüðü.Add (ad, value);}
            get {return (Ýþgören2)listeSözlüðü [ad];}
        }
        public Ýþgören2 this [int no] {//(Tam)sayýsal endeksleyici
            set {listeSözlüðü.Add (no, value);}
            get {return (Ýþgören2)listeSözlüðü [no];}
        }
    }
    public class Ýþgören3 {
        public string isim;
        public double maaþ;
        public int yaþ;
        public Ýþgören3 (string i, double m, int y) {isim = i; maaþ=m; yaþ=y;} //3 parametreli kurucu
        Ýþgören3[] iþgörenler = new Ýþgören3 [7];
        public Ýþgören3 this [int endeks] {set {iþgörenler [endeks] = value;} get {return iþgörenler [endeks];}}
    }
    class Endeksleyici1 {
        static void Main() {
            Console.Write ("Endeksleyiciyle bir sýnýf nesnesi dizileþtirilebilir. Dizi 'ArrayList al=new ArrayList()'le yaratýlýp 'public VeriliSýnýf this[int endeks]{set...get...}'le endekslenir. Kayýt giriþi, dizi ebatý tanýmlanmamýþsa Add'le (yada Insert), tanýmlanmýþsa ebat kapsamýndaki endeks'lerle yapýlýr. Ebat 'al.Count'la alýnýr. IEnumerator miraslanýrsa GetEnumerator() metodu gövdelenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Alan-özellik ve endeksleyici diziyle ad-veri çifti koy-al:");
            var r=new Random(); int ts1, i, j;
            ÇiftAlanlý ça;
            Console.WriteLine ("\tSýnýfýn ad-veri alan çiftine özellik'le bilgi koy-al:");
            for(i=0;i<5;i++) {
                ts1=r.Next(1000,10000);
                ça=new ÇiftAlanlý (((char)(65+i)).ToString(), "551-555-"+ts1);
                Console.WriteLine ("(ad, veri) = ({0}, {1})", ça.Ad, ça.Veri);
            }
            ÇiftAlanlýListe ikili = new ÇiftAlanlýListe();
            ikili.DiziyeEkle();
            Console.WriteLine ("\tSýnýfýn ad-veri alan çiftine endeksleyici'le bilgi koy-al:");
            for(i=0;i<5;i++) Console.WriteLine ("(ad, veri) = ({0}, {1})", ikili [i].Ad, ikili [i].Veri);

            Console.WriteLine ("\nDoðrudan endeks-no yerine aranan ad endeksinin kullanýlmasý:");
            ÇiftAlanlýListe2 ikili2 = new ÇiftAlanlýListe2();
            ikili2.DiziyeEkle();
            ÇiftAlanlý2 ça2 = ikili2 ["Belkýs Candan"];
            Console.WriteLine ("Aranan: Belkýs Candan = {0}", ça2.Veri);
            Console.WriteLine ("Aranan: Fatih Özbay = {0}", ikili2 ["Fatih Özbay"].Veri);
            ikili2 ["Atilla Gökyiðit"].Veri = 53519.23m+" TL";
            Console.WriteLine ("Aranan: Atilla Gökyiðit = {0}", ikili2 ["Atilla Gökyiðit"].Veri);
            ça2 = ikili2 ["Yücel Küçükbay"];
            Console.WriteLine ("Aranan:Yücel Küçükbay = {0}", ça2.Veri);
            try {ça2 = ikili2 ["M.Nedim Yavaþ"]; Console.WriteLine ("Aranan: M.Nedim Yavaþ = {0}", ça2.Veri);
            }catch (Exception h) {Console.WriteLine ("HATA: Aranan bulunamadý = [{0}]", h.Message);}
            ça2 = ikili2 ["M.Nihat Yavaþ"];
            Console.WriteLine ("Aranan: M.Nihat Yavaþ = {0}", ça2.Veri);

            Console.WriteLine ("\nÇift boyutlu Tablo konumlarýna tek boyutlu Hücre verisi koy/al:");
            Tablo tablo = new Tablo();
            for(i=0;i<26;i++) {for(j=0;j<10;j++) {tablo [((char)(i)).ToString(), j] = new Hücre (((char)(i+65)).ToString() + j + "-MNYavaþ");}}
            for(i=0;i<26;i++) {for(j=0;j<10;j++) {if(j==0) Console.Write ("\t"); Console.Write ("Tablo({0},{1})={2} ", i, j, tablo [((char)(i)).ToString(), j]);} Console.WriteLine();}

            Console.WriteLine ("\nEndeksleyciyle iþgören listesi girmek ve okumak:");
            ÝþgörenListesi iþgListe = new ÝþgörenListesi();
            string[] adlar=new string[]{"Hatice Yavaþ Kaçar", "Süheyla Yavaþ Özbay", "Zeliha Yavaþ Candan", "M.Nihat Yavaþ", "Songül Yavaþ Gökyiðit", "M.Nedim Yavaþ", "Sevim Yavaþ"};
            double ds1;
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; iþgListe [i] = new Ýþgören (adlar [i], ds1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}.inci iþgörenin (adý, maaþý) = ({1}, {2:#,0.00} TL)", (i+1), iþgListe [i].isim, iþgListe [i].maaþ);
            try {iþgListe [-5] = new Ýþgören ("Negatif endeks denemesi", 0D);} catch (Exception h) {Console.WriteLine ("HATA: Negatif endeks = [{0}]", h.Message);}
            Console.WriteLine ("Girilen toplam iþgören sayýsý = {0}", iþgListe.ListeEbatýnýAl());
            Console.WriteLine ("\tÝþgören listesinin sondan-baþa okunmasý:");
            for(i=iþgListe.ListeEbatýnýAl()-1; i>=0; i--) Console.WriteLine ("{0}.inci iþgörenin (adý, maaþý) = ({1}, {2:#,0.00} TL)", (i+1), iþgListe [i].isim, iþgListe [i].maaþ);
            Console.WriteLine ("\tÝþgören listesinin foreach'le okunmasý:");
            foreach (Ýþgören iþg in iþgListe) Console.WriteLine ("Ýþgörenin (adý, maaþý) = ({0}, {1:#,0.00} TL)", iþg.isim, iþg.maaþ);

            Console.WriteLine ("\nListDictionary ile sayýsal ve dizgesel çifte endeksleme:");
            ÝþgörenListesi2 iþListe = new ÝþgörenListesi2();
            string[] ad;
            Console.WriteLine ("\tTamsayýsal endeksleyici:");
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; iþListe [i] = new Ýþgören2 (adlar [i], ds1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}.inci iþgörenin (adý, maaþý) = ({1}, {2:#,0.00} TL)", (i+1), iþListe [i].isim, iþListe [i].maaþ);
            Console.WriteLine ("\tDizgesel endeksleyici:");
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; ad=adlar[i].Split(' '); iþListe [ad[0]] = new Ýþgören2 (adlar [i], ds1);}
            for(i=0;i<7;i++) {ad=adlar[i].Split(' '); Console.WriteLine ("\"{0}\" adlý iþgörenin (ismi, maaþý) = ({1}, {2:#,0.00} TL)", ad[0], iþListe [ad[0]].isim, iþListe [ad[0]].maaþ);}

            Console.WriteLine ("\nKendini sabit ebatla endeksleyen 3 verili sýnýf:");
            Ýþgören3 iþg3=new Ýþgören3("",0,0);
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; ts1=r.Next(18,85); iþg3 [i] = new Ýþgören3 (adlar [i], ds1, ts1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}) (ad, maaþ, yaþ) = ({1}, {2:#,0.00}TL, {3})", (i+1), iþg3 [i].isim, iþg3 [i].maaþ, iþg3 [i].yaþ);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}