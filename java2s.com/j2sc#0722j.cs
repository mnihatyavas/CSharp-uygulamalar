// j2sc#0722j.cs: IEnumerable, IEnumerator'la foreach taray�c� d�k�mleme �rne�i.

using System;
using System.Collections.Generic; //List i�in
using System.Collections; //IEnumerable, IEnumerator i�in
using System.Linq; //"from Veri in test select Veri" i�in
namespace S�n�flar {
    class Ki�i : IComparable<Ki�i>, IEquatable<Ki�i>, IComparable {
        public string isim;
        public int ya�;
        public string �irket;
        public int CompareTo (Ki�i di�er) {//Y�r�t�len: IComparable<Ki�i>.CompareTo()
            if (di�er == null) return -1;
            else return this.isim.CompareTo (di�er.isim);
        }
        public int CompareTo (object nesne) {//Y�r�t�len: IComparable.CompareTo()
            Ki�i k = nesne as Ki�i;
            return CompareTo (k);
        }
        public bool Equals (Ki�i di�er) {//Y�r�t�len: IEquatable<Ki�i>.Equals()
            return ((IComparable<Ki�i>)this).CompareTo (di�er) == 0;
        }
        public override bool Equals (object nesne) {//Esge�ilen: Object.Equals()
            Ki�i k = nesne as Ki�i;
            return Equals (k);
        }
        public override int GetHashCode(){return 0;} //Derleme ikaz�
    }
    public class ��g�ren {
        string isim;
        int ya�;
        float maa�;
        public ��g�ren (string i, int y, float m) {isim = i; ya� = y; maa�=m;}
        public override string ToString() {return string.Format ("(ad, ya�, maa�): ({0}, {1}, {2,9:#,0.00})", isim, ya�, maa�);}
    }
    public class Ekip {
        private List<��g�ren> �yeler = new List<��g�ren>();
        public IEnumerator<��g�ren> GetEnumerator() {foreach (��g�ren �ye in �yeler) {yield return �ye;}}
        public IEnumerable<��g�ren> Ters {get {for (int i = �yeler.Count - 1; i >= 0; i--) {yield return �yeler [i];}}}
        public IEnumerable<��g�ren> �lk�� {
            get {int i = 0;
                foreach (��g�ren �ye in �yeler) {
                    if (i >= 3) {yield break;
                    }else {i++; yield return �ye;}
                }
            }
        }
        public void �yeEkle (��g�ren �ye) {�yeler.Add (�ye);}
    }
    class G�kku�a�� : IEnumerable, IEnumerator {
        private short taramaEndeksi = -1;
        public IEnumerator GetEnumerator(){return this;}
        public object Current {
            get {
                switch (taramaEndeksi) {
                    case 0: return (taramaEndeksi+1) + ".renk) K�rm�z�";
                    case 1: return (taramaEndeksi+1) + ".renk) Turun�";
                    case 2: return (taramaEndeksi+1) + ".renk) Sar�";
                    case 3: return (taramaEndeksi+1) + ".renk) Ye�il";
                    case 4: return (taramaEndeksi+1) + ".renk) Mavi";
                    case 5: return (taramaEndeksi+1) + ".renk) �ivit";
                    case 6: return (taramaEndeksi+1) + ".renk) Mor";
                    default: return "*** HATA ***";
                }
            }
        }
        public bool MoveNext() {
            taramaEndeksi++;
            if (taramaEndeksi == 7) return false;
            else return true;
        }
        public void Reset() {taramaEndeksi = -1;}
    }
    public static class Bo�Kontrol {
        public static IEnumerable<string> Bo� (this IEnumerable<string> kaynak) {
            if (kaynak.Count<String>() > 0) return kaynak;
            else {
               List<string> varsay�l� = new List<string>();
               varsay�l�.Add ("BO� Kay�t");
               return varsay�l�;
            }
        }
    }
    class Kullan�c� {
        string ad;
        public string Ad {get {return ad;}} //�zellik
        public Kullan�c� (string ad) {this.ad = ad;} //Kurucu
    }
    class VTY�netimi : IEnumerable {
        ArrayList �evrimi�iKullan�c�lar = new ArrayList();
        public VTY�netimi() {//Kay�t ekleyen kurucu
            �evrimi�iKullan�c�lar.Add (new Kullan�c� ("Kiraz"));
            �evrimi�iKullan�c�lar.Add (new Kullan�c� ("Tekin"));
            �evrimi�iKullan�c�lar.Add (new Kullan�c� ("Kas�mpat�"));
            �evrimi�iKullan�c�lar.Add (new Kullan�c� ("Erciyes"));
            �evrimi�iKullan�c�lar.Add (new Kullan�c� ("Krizantem"));
        }
        public IEnumerator GetEnumerator() {return new Enumerator (�evrimi�iKullan�c�lar);}
        class Enumerator : IEnumerator {
            ArrayList �evrimi�iKullan�c�lar = new ArrayList();
            const string GE�ERS�Z_KAYIT = "Current'� �a��rmadan �nce MoveNext'i kullan";
            public Enumerator (ArrayList �evrimi�iKullan�c�lar) {// ��s�n�f Kurucusu
                foreach (Kullan�c� k in �evrimi�iKullan�c�lar) {this.�evrimi�iKullan�c�lar.Add (k);}
                Reset();
            }
            int endeks;
            public bool MoveNext() {return (++endeks < �evrimi�iKullan�c�lar.Count);}
            public object Current {
                get {
                    if (-1 == endeks) throw new InvalidOperationException (GE�ERS�Z_KAYIT);
                    if (endeks < �evrimi�iKullan�c�lar.Count) return �evrimi�iKullan�c�lar [endeks];
                    else return null;
                }
            }
            public void Reset() {endeks = -1;}
        }
    }
    class �e�itli10 {
        static void Main() {
            Console.Write ("IComparable<Ki�i>, IEquatable<Ki�i>, IComparable aray�z �ablonlarla s�ralamada kullan�lan k�yas ve e�itlik metotlar�n� �zelle�tirir.\nIEnumerator<��g�ren> GetEnumerator() ve IEnumerable<��g�ren> ile i�g�ren liste �yeleri d�z, ters ve ilk-�� d�k�mlenebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ki�i dizi kay�tlar� endeksle ve artan s�ralamayla d�k�mlenir:");
            var r=new Random(); int ts1, i, j; string ad, firma;
            Ki�i[] ajanda = new Ki�i [5];
            for(i=0;i<5;i++) {
                ajanda [i] = new Ki�i();
                ad=""; for(j=0;j<5;j++) ad+=(char)r.Next(65,92); ad+=" "; for(j=0;j<7;j++) ad+=(char)r.Next(65,92); ajanda [i].isim=ad;
                ts1=r.Next(18, 85); ajanda [i].ya�=ts1;
                firma=""; for(j=0;j<8;j++) firma+=(char)r.Next(65,92); firma+=" A.�."; ajanda [i].�irket=firma;
            }
            foreach (Ki�i k in ajanda) Console.WriteLine ("(ad, ya�, firma): ({0}, {1}, {2})", k.isim, k.ya�, k.�irket);
            Array.Sort (ajanda);
            foreach (Ki�i k in ajanda) Console.WriteLine ("\t(ad, ya�, firma): ({0}, {1}, {2})", k.isim, k.ya�, k.�irket);

            Console.WriteLine ("\n5 i�g�ren listesi ekleme; d�z, ilk-�� ve ters d�k�mleme:");
            string[] adlar=new string[]{"Hamza Candan", "Zeliha Candan", "Canan Candan", "Zafer N.Candan", "Belk�s Candan"};
            float fs1;
            Ekip tim = new Ekip();
            for(i=0;i<5;i++) {
                ts1=r.Next(18, 85); fs1=r.Next(7852,100000)+r.Next(10,100)/100F;
                tim.�yeEkle (new ��g�ren (adlar [i], ts1, fs1));
            }
            foreach (��g�ren �ye in tim) {Console.WriteLine (�ye.ToString());}
            foreach (��g�ren �ye in tim.�lk��) {Console.WriteLine ("\t" + �ye.ToString());}
            foreach (��g�ren �ye in tim.Ters) {Console.WriteLine (�ye.ToString());}

            Console.WriteLine ("\nG�kku�a��n�n 7 renginin foreach taramayla d�k�mlenmesi:");
            G�kku�a�� gk = new G�kku�a��();
            foreach (string renk in gk) Console.WriteLine (renk);

            Console.WriteLine ("\nListede kay�t yoksa statik Bo�Kontrol.Bo�()'la 'BO�' kay�t ekleme:");
            List<String> test = new List<String>();
            var ara�t�r = from Veri in test select Veri; //using System.Linq
            foreach (var kay�t in ara�t�r.Bo�()) Console.WriteLine (kay�t);
            foreach (var kay�t in ara�t�r.Bo�()) Console.WriteLine (kay�t);
            foreach (var kay�t in ara�t�r.Bo�()) Console.WriteLine (kay�t);
            test.Add ("�lk Kay�t"); test.Add ("�kinci Kay�t"); test.Add ("���nc� Kay�t");
            foreach (var kay�t in ara�t�r.Bo�()) Console.WriteLine (kay�t);

            Console.WriteLine ("\nIEnumerator GetEnumerator(), MoveNext(), Current ve Reset()'li taray�c�:");
            VTY�netimi vt = new VTY�netimi();
            IEnumerator ie = vt.GetEnumerator();
            while (ie.MoveNext()) {
                Kullan�c� k = (Kullan�c�)ie.Current;
                Console.WriteLine ("Kullan�c�={0}", k.Ad);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}