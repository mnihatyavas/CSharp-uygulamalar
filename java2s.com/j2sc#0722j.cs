// j2sc#0722j.cs: IEnumerable, IEnumerator'la foreach tarayýcý dökümleme örneði.

using System;
using System.Collections.Generic; //List için
using System.Collections; //IEnumerable, IEnumerator için
using System.Linq; //"from Veri in test select Veri" için
namespace Sýnýflar {
    class Kiþi : IComparable<Kiþi>, IEquatable<Kiþi>, IComparable {
        public string isim;
        public int yaþ;
        public string þirket;
        public int CompareTo (Kiþi diðer) {//Yürütülen: IComparable<Kiþi>.CompareTo()
            if (diðer == null) return -1;
            else return this.isim.CompareTo (diðer.isim);
        }
        public int CompareTo (object nesne) {//Yürütülen: IComparable.CompareTo()
            Kiþi k = nesne as Kiþi;
            return CompareTo (k);
        }
        public bool Equals (Kiþi diðer) {//Yürütülen: IEquatable<Kiþi>.Equals()
            return ((IComparable<Kiþi>)this).CompareTo (diðer) == 0;
        }
        public override bool Equals (object nesne) {//Esgeçilen: Object.Equals()
            Kiþi k = nesne as Kiþi;
            return Equals (k);
        }
        public override int GetHashCode(){return 0;} //Derleme ikazý
    }
    public class Ýþgören {
        string isim;
        int yaþ;
        float maaþ;
        public Ýþgören (string i, int y, float m) {isim = i; yaþ = y; maaþ=m;}
        public override string ToString() {return string.Format ("(ad, yaþ, maaþ): ({0}, {1}, {2,9:#,0.00})", isim, yaþ, maaþ);}
    }
    public class Ekip {
        private List<Ýþgören> üyeler = new List<Ýþgören>();
        public IEnumerator<Ýþgören> GetEnumerator() {foreach (Ýþgören üye in üyeler) {yield return üye;}}
        public IEnumerable<Ýþgören> Ters {get {for (int i = üyeler.Count - 1; i >= 0; i--) {yield return üyeler [i];}}}
        public IEnumerable<Ýþgören> ÝlkÜç {
            get {int i = 0;
                foreach (Ýþgören üye in üyeler) {
                    if (i >= 3) {yield break;
                    }else {i++; yield return üye;}
                }
            }
        }
        public void ÜyeEkle (Ýþgören üye) {üyeler.Add (üye);}
    }
    class Gökkuþaðý : IEnumerable, IEnumerator {
        private short taramaEndeksi = -1;
        public IEnumerator GetEnumerator(){return this;}
        public object Current {
            get {
                switch (taramaEndeksi) {
                    case 0: return (taramaEndeksi+1) + ".renk) Kýrmýzý";
                    case 1: return (taramaEndeksi+1) + ".renk) Turunç";
                    case 2: return (taramaEndeksi+1) + ".renk) Sarý";
                    case 3: return (taramaEndeksi+1) + ".renk) Yeþil";
                    case 4: return (taramaEndeksi+1) + ".renk) Mavi";
                    case 5: return (taramaEndeksi+1) + ".renk) Çivit";
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
    public static class BoþKontrol {
        public static IEnumerable<string> Boþ (this IEnumerable<string> kaynak) {
            if (kaynak.Count<String>() > 0) return kaynak;
            else {
               List<string> varsayýlý = new List<string>();
               varsayýlý.Add ("BOÞ Kayýt");
               return varsayýlý;
            }
        }
    }
    class Kullanýcý {
        string ad;
        public string Ad {get {return ad;}} //Özellik
        public Kullanýcý (string ad) {this.ad = ad;} //Kurucu
    }
    class VTYönetimi : IEnumerable {
        ArrayList çevrimiçiKullanýcýlar = new ArrayList();
        public VTYönetimi() {//Kayýt ekleyen kurucu
            çevrimiçiKullanýcýlar.Add (new Kullanýcý ("Kiraz"));
            çevrimiçiKullanýcýlar.Add (new Kullanýcý ("Tekin"));
            çevrimiçiKullanýcýlar.Add (new Kullanýcý ("Kasýmpatý"));
            çevrimiçiKullanýcýlar.Add (new Kullanýcý ("Erciyes"));
            çevrimiçiKullanýcýlar.Add (new Kullanýcý ("Krizantem"));
        }
        public IEnumerator GetEnumerator() {return new Enumerator (çevrimiçiKullanýcýlar);}
        class Enumerator : IEnumerator {
            ArrayList çevrimiçiKullanýcýlar = new ArrayList();
            const string GEÇERSÝZ_KAYIT = "Current'ý çaðýrmadan önce MoveNext'i kullan";
            public Enumerator (ArrayList çevrimiçiKullanýcýlar) {// Ýçsýnýf Kurucusu
                foreach (Kullanýcý k in çevrimiçiKullanýcýlar) {this.çevrimiçiKullanýcýlar.Add (k);}
                Reset();
            }
            int endeks;
            public bool MoveNext() {return (++endeks < çevrimiçiKullanýcýlar.Count);}
            public object Current {
                get {
                    if (-1 == endeks) throw new InvalidOperationException (GEÇERSÝZ_KAYIT);
                    if (endeks < çevrimiçiKullanýcýlar.Count) return çevrimiçiKullanýcýlar [endeks];
                    else return null;
                }
            }
            public void Reset() {endeks = -1;}
        }
    }
    class Çeþitli10 {
        static void Main() {
            Console.Write ("IComparable<Kiþi>, IEquatable<Kiþi>, IComparable arayüz þablonlarla sýralamada kullanýlan kýyas ve eþitlik metotlarýný özelleþtirir.\nIEnumerator<Ýþgören> GetEnumerator() ve IEnumerable<Ýþgören> ile iþgören liste üyeleri düz, ters ve ilk-üç dökümlenebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kiþi dizi kayýtlarý endeksle ve artan sýralamayla dökümlenir:");
            var r=new Random(); int ts1, i, j; string ad, firma;
            Kiþi[] ajanda = new Kiþi [5];
            for(i=0;i<5;i++) {
                ajanda [i] = new Kiþi();
                ad=""; for(j=0;j<5;j++) ad+=(char)r.Next(65,92); ad+=" "; for(j=0;j<7;j++) ad+=(char)r.Next(65,92); ajanda [i].isim=ad;
                ts1=r.Next(18, 85); ajanda [i].yaþ=ts1;
                firma=""; for(j=0;j<8;j++) firma+=(char)r.Next(65,92); firma+=" A.Þ."; ajanda [i].þirket=firma;
            }
            foreach (Kiþi k in ajanda) Console.WriteLine ("(ad, yaþ, firma): ({0}, {1}, {2})", k.isim, k.yaþ, k.þirket);
            Array.Sort (ajanda);
            foreach (Kiþi k in ajanda) Console.WriteLine ("\t(ad, yaþ, firma): ({0}, {1}, {2})", k.isim, k.yaþ, k.þirket);

            Console.WriteLine ("\n5 iþgören listesi ekleme; düz, ilk-üç ve ters dökümleme:");
            string[] adlar=new string[]{"Hamza Candan", "Zeliha Candan", "Canan Candan", "Zafer N.Candan", "Belkýs Candan"};
            float fs1;
            Ekip tim = new Ekip();
            for(i=0;i<5;i++) {
                ts1=r.Next(18, 85); fs1=r.Next(7852,100000)+r.Next(10,100)/100F;
                tim.ÜyeEkle (new Ýþgören (adlar [i], ts1, fs1));
            }
            foreach (Ýþgören üye in tim) {Console.WriteLine (üye.ToString());}
            foreach (Ýþgören üye in tim.ÝlkÜç) {Console.WriteLine ("\t" + üye.ToString());}
            foreach (Ýþgören üye in tim.Ters) {Console.WriteLine (üye.ToString());}

            Console.WriteLine ("\nGökkuþaðýnýn 7 renginin foreach taramayla dökümlenmesi:");
            Gökkuþaðý gk = new Gökkuþaðý();
            foreach (string renk in gk) Console.WriteLine (renk);

            Console.WriteLine ("\nListede kayýt yoksa statik BoþKontrol.Boþ()'la 'BOÞ' kayýt ekleme:");
            List<String> test = new List<String>();
            var araþtýr = from Veri in test select Veri; //using System.Linq
            foreach (var kayýt in araþtýr.Boþ()) Console.WriteLine (kayýt);
            foreach (var kayýt in araþtýr.Boþ()) Console.WriteLine (kayýt);
            foreach (var kayýt in araþtýr.Boþ()) Console.WriteLine (kayýt);
            test.Add ("Ýlk Kayýt"); test.Add ("Ýkinci Kayýt"); test.Add ("Üçüncü Kayýt");
            foreach (var kayýt in araþtýr.Boþ()) Console.WriteLine (kayýt);

            Console.WriteLine ("\nIEnumerator GetEnumerator(), MoveNext(), Current ve Reset()'li tarayýcý:");
            VTYönetimi vt = new VTYönetimi();
            IEnumerator ie = vt.GetEnumerator();
            while (ie.MoveNext()) {
                Kullanýcý k = (Kullanýcý)ie.Current;
                Console.WriteLine ("Kullanýcý={0}", k.Ad);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}