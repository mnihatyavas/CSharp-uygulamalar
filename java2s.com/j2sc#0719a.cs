// j2sc#0719a.cs: Tek/�ift boyutlu, yal�n ve ArrayList/ListDictionary'li endeksleyici �rne�i.

using System;
using System.Collections; //ArrayList i�in
using System.Collections.Specialized; //ListDictionary i�in
namespace S�n�flar {
    class �iftAlanl� {
        string ad; //private alan
        object veri;
        public �iftAlanl� (string ad, object veri) {this.ad = ad; this.veri = veri;} //�ift parametreli kurucu
        public string Ad {set {ad = value;} get {return(ad);}} //Koy-al public �zellik
        public object Veri {set {veri = value;} get {return(veri);}}
    }
    class �iftAlanl�Liste {
        ArrayList ikili;
        public �iftAlanl�Liste() {ikili = new ArrayList();} //Parametresiz kurucu
        public void DiziyeEkle() {
            ikili.Add (new �iftAlanl� ("M.Nihat Yava�", 43879353585));
            ikili.Add (new �iftAlanl� ("Y�cel K���kbay", "�ar�amba - BURSA"));
            ikili.Add (new �iftAlanl� ("Atilla G�kyi�it", 33519.23m+" TL"));
            ikili.Add (new �iftAlanl� ("Belk�s Candan", "Yurtd��� Hostes"));
            ikili.Add (new �iftAlanl� ("Fatih �zbay", "Kar��yaka - �ZM�R"));
        }
        public �iftAlanl� this [int endeks] {set {ikili [endeks] = value;} get {return ((�iftAlanl�) ikili [endeks]);}}
    }
    class �iftAlanl�2 {
        string ad; //private alan
        object veri;
        public �iftAlanl�2 (string ad, object veri) {this.ad = ad; this.veri = veri;} //�ift parametreli kurucu
        public string Ad {set {ad = value;} get {return(ad);}} //Koy-al public �zellik
        public object Veri {set {veri = value;} get {return(veri);}}
    }
    class �iftAlanl�Liste2 {
        ArrayList ikili;
        public �iftAlanl�Liste2() {ikili = new ArrayList();} //Parametresiz kurucu
        public void DiziyeEkle() {
            ikili.Add (new �iftAlanl�2 ("M.Nihat Yava�", 43879353585));
            ikili.Add (new �iftAlanl�2 ("Y�cel K���kbay", "�ar�amba - BURSA"));
            ikili.Add (new �iftAlanl�2 ("Atilla G�kyi�it", 33519.23m+" TL"));
            ikili.Add (new �iftAlanl�2 ("Belk�s Candan", "Yurtd��� Hostesi"));
            ikili.Add (new �iftAlanl�2 ("Fatih �zbay", "Kar��yaka - �ZM�R"));
        }
        public �iftAlanl�2 this [int endeks] {set {ikili [endeks] = value;} get {return ((�iftAlanl�2) ikili [endeks]);}}
        int AdBul (string ad) {
            for (int endeks = 0; endeks < ikili.Count; endeks++) {
                �iftAlanl�2 �a = (�iftAlanl�2) ikili [endeks];
                if (�a.Ad == ad) return(endeks);
            } return(-1);
        }
        public �iftAlanl�2 this [string ad] {set {this [AdBul (ad)] = value;} get {return((�iftAlanl�2)this [AdBul (ad)]);}}
    }
    public class H�cre {
        string ad;
        public H�cre (string ad) {this.ad = ad;}
        public override string ToString() {return(ad);}
    }
    public class Tablo {
        H�cre [,] tablo = new H�cre [26, 10]; //[A-->Z, 0-->9]
        int Sat�rEndeksi (string sat�r) {return((int) sat�r [0]);}
        int S�tunEndeksi (string s�tun) {return (s�tun [0]);}
        public H�cre this [string sat�r, int s�tun] {
            set {tablo [Sat�rEndeksi (sat�r), s�tun] = value;}
            get {return (tablo [Sat�rEndeksi (sat�r), s�tun]);}
        } 
    }
    public class ��g�ren {
        public string isim = "";
        public double maa� = 0D;
        public ��g�ren (string i, double m) {isim = i; maa�=m;} //�ift parametreli kurucu
    }
    public class ��g�renListesi : IEnumerable {
        private ArrayList diziListesi;
        public ��g�renListesi() {diziListesi = new ArrayList();} //Parametresiz kurucu
        public ��g�ren this [int endeks] {//Endeksleyici
            set {diziListesi.Insert (endeks, value);}
            get {if (endeks < 0) throw new IndexOutOfRangeException ("Hey! Negatif endeks olmaz"); else return (��g�ren)diziListesi [endeks];}
        }
        public int ListeEbat�n�Al() {return diziListesi.Count;}
        public IEnumerator GetEnumerator() {return diziListesi.GetEnumerator();}
    }
    public class ��g�ren2 {
        public string isim = "";
        public double maa� = 0D;
        public ��g�ren2 (string i, double m) {isim = i; maa�=m;} //�ift parametreli kurucu
    }
    public class ��g�renListesi2 {
        private ListDictionary listeS�zl���;
        public ��g�renListesi2() {listeS�zl��� = new ListDictionary();}
        public ��g�ren2 this [string ad] {//Dizgesel endeksleyici
            set {listeS�zl���.Add (ad, value);}
            get {return (��g�ren2)listeS�zl��� [ad];}
        }
        public ��g�ren2 this [int no] {//(Tam)say�sal endeksleyici
            set {listeS�zl���.Add (no, value);}
            get {return (��g�ren2)listeS�zl��� [no];}
        }
    }
    public class ��g�ren3 {
        public string isim;
        public double maa�;
        public int ya�;
        public ��g�ren3 (string i, double m, int y) {isim = i; maa�=m; ya�=y;} //3 parametreli kurucu
        ��g�ren3[] i�g�renler = new ��g�ren3 [7];
        public ��g�ren3 this [int endeks] {set {i�g�renler [endeks] = value;} get {return i�g�renler [endeks];}}
    }
    class Endeksleyici1 {
        static void Main() {
            Console.Write ("Endeksleyiciyle bir s�n�f nesnesi dizile�tirilebilir. Dizi 'ArrayList al=new ArrayList()'le yarat�l�p 'public VeriliS�n�f this[int endeks]{set...get...}'le endekslenir. Kay�t giri�i, dizi ebat� tan�mlanmam��sa Add'le (yada Insert), tan�mlanm��sa ebat kapsam�ndaki endeks'lerle yap�l�r. Ebat 'al.Count'la al�n�r. IEnumerator miraslan�rsa GetEnumerator() metodu g�vdelenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Alan-�zellik ve endeksleyici diziyle ad-veri �ifti koy-al:");
            var r=new Random(); int ts1, i, j;
            �iftAlanl� �a;
            Console.WriteLine ("\tS�n�f�n ad-veri alan �iftine �zellik'le bilgi koy-al:");
            for(i=0;i<5;i++) {
                ts1=r.Next(1000,10000);
                �a=new �iftAlanl� (((char)(65+i)).ToString(), "551-555-"+ts1);
                Console.WriteLine ("(ad, veri) = ({0}, {1})", �a.Ad, �a.Veri);
            }
            �iftAlanl�Liste ikili = new �iftAlanl�Liste();
            ikili.DiziyeEkle();
            Console.WriteLine ("\tS�n�f�n ad-veri alan �iftine endeksleyici'le bilgi koy-al:");
            for(i=0;i<5;i++) Console.WriteLine ("(ad, veri) = ({0}, {1})", ikili [i].Ad, ikili [i].Veri);

            Console.WriteLine ("\nDo�rudan endeks-no yerine aranan ad endeksinin kullan�lmas�:");
            �iftAlanl�Liste2 ikili2 = new �iftAlanl�Liste2();
            ikili2.DiziyeEkle();
            �iftAlanl�2 �a2 = ikili2 ["Belk�s Candan"];
            Console.WriteLine ("Aranan: Belk�s Candan = {0}", �a2.Veri);
            Console.WriteLine ("Aranan: Fatih �zbay = {0}", ikili2 ["Fatih �zbay"].Veri);
            ikili2 ["Atilla G�kyi�it"].Veri = 53519.23m+" TL";
            Console.WriteLine ("Aranan: Atilla G�kyi�it = {0}", ikili2 ["Atilla G�kyi�it"].Veri);
            �a2 = ikili2 ["Y�cel K���kbay"];
            Console.WriteLine ("Aranan:Y�cel K���kbay = {0}", �a2.Veri);
            try {�a2 = ikili2 ["M.Nedim Yava�"]; Console.WriteLine ("Aranan: M.Nedim Yava� = {0}", �a2.Veri);
            }catch (Exception h) {Console.WriteLine ("HATA: Aranan bulunamad� = [{0}]", h.Message);}
            �a2 = ikili2 ["M.Nihat Yava�"];
            Console.WriteLine ("Aranan: M.Nihat Yava� = {0}", �a2.Veri);

            Console.WriteLine ("\n�ift boyutlu Tablo konumlar�na tek boyutlu H�cre verisi koy/al:");
            Tablo tablo = new Tablo();
            for(i=0;i<26;i++) {for(j=0;j<10;j++) {tablo [((char)(i)).ToString(), j] = new H�cre (((char)(i+65)).ToString() + j + "-MNYava�");}}
            for(i=0;i<26;i++) {for(j=0;j<10;j++) {if(j==0) Console.Write ("\t"); Console.Write ("Tablo({0},{1})={2} ", i, j, tablo [((char)(i)).ToString(), j]);} Console.WriteLine();}

            Console.WriteLine ("\nEndeksleyciyle i�g�ren listesi girmek ve okumak:");
            ��g�renListesi i�gListe = new ��g�renListesi();
            string[] adlar=new string[]{"Hatice Yava� Ka�ar", "S�heyla Yava� �zbay", "Zeliha Yava� Candan", "M.Nihat Yava�", "Song�l Yava� G�kyi�it", "M.Nedim Yava�", "Sevim Yava�"};
            double ds1;
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; i�gListe [i] = new ��g�ren (adlar [i], ds1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}.inci i�g�renin (ad�, maa��) = ({1}, {2:#,0.00} TL)", (i+1), i�gListe [i].isim, i�gListe [i].maa�);
            try {i�gListe [-5] = new ��g�ren ("Negatif endeks denemesi", 0D);} catch (Exception h) {Console.WriteLine ("HATA: Negatif endeks = [{0}]", h.Message);}
            Console.WriteLine ("Girilen toplam i�g�ren say�s� = {0}", i�gListe.ListeEbat�n�Al());
            Console.WriteLine ("\t��g�ren listesinin sondan-ba�a okunmas�:");
            for(i=i�gListe.ListeEbat�n�Al()-1; i>=0; i--) Console.WriteLine ("{0}.inci i�g�renin (ad�, maa��) = ({1}, {2:#,0.00} TL)", (i+1), i�gListe [i].isim, i�gListe [i].maa�);
            Console.WriteLine ("\t��g�ren listesinin foreach'le okunmas�:");
            foreach (��g�ren i�g in i�gListe) Console.WriteLine ("��g�renin (ad�, maa��) = ({0}, {1:#,0.00} TL)", i�g.isim, i�g.maa�);

            Console.WriteLine ("\nListDictionary ile say�sal ve dizgesel �ifte endeksleme:");
            ��g�renListesi2 i�Liste = new ��g�renListesi2();
            string[] ad;
            Console.WriteLine ("\tTamsay�sal endeksleyici:");
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; i�Liste [i] = new ��g�ren2 (adlar [i], ds1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}.inci i�g�renin (ad�, maa��) = ({1}, {2:#,0.00} TL)", (i+1), i�Liste [i].isim, i�Liste [i].maa�);
            Console.WriteLine ("\tDizgesel endeksleyici:");
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; ad=adlar[i].Split(' '); i�Liste [ad[0]] = new ��g�ren2 (adlar [i], ds1);}
            for(i=0;i<7;i++) {ad=adlar[i].Split(' '); Console.WriteLine ("\"{0}\" adl� i�g�renin (ismi, maa��) = ({1}, {2:#,0.00} TL)", ad[0], i�Liste [ad[0]].isim, i�Liste [ad[0]].maa�);}

            Console.WriteLine ("\nKendini sabit ebatla endeksleyen 3 verili s�n�f:");
            ��g�ren3 i�g3=new ��g�ren3("",0,0);
            for(i=0;i<7;i++) {if(i==3)ds1=7852; else ds1=r.Next(7853,100000)+r.Next(10,100)/100D; ts1=r.Next(18,85); i�g3 [i] = new ��g�ren3 (adlar [i], ds1, ts1);}
            for(i=0;i<7;i++) Console.WriteLine ("{0}) (ad, maa�, ya�) = ({1}, {2:#,0.00}TL, {3})", (i+1), i�g3 [i].isim, i�g3 [i].maa�, i�g3 [i].ya�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}