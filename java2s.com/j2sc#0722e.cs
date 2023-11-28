// j2sc#0722e.cs: Mühürlü sýnýf/metot ve birkaç hazýr system metotlarýnýn testi örneði.

using System;
using System.Text; //StringBuilder için
namespace Sýnýflar {
    sealed class MiraslanmazSýnýf {public MiraslanmazSýnýf(){Console.WriteLine ("Ben 'sealed MiraslanmazSýnýf'ým.");}}
    public class TemelSýnýf {
        public string isim, meslek;
        public TemelSýnýf (string isim, string meslek) {this.isim = isim; this.meslek = meslek;}
        public virtual void Koþ() {Console.WriteLine ("TemelSýnýf.Koþ() metodunda {0} {1} koþuyor...", meslek, isim);}
    }
    public class TürediSýnýf : TemelSýnýf {
        public TürediSýnýf (string isim, string meslek) : base (isim, meslek){}
        sealed public override void Koþ() {Console.WriteLine ("TürediSýnýf.Koþ() metodunda {0} {1} koþuyor...", base.meslek, base.isim);}
    }
    public abstract class Temel{}
    internal class Türedi : Temel{}
    public interface ITemelArayüz1{}
    internal interface ITemelArayüz2{}
    internal interface ITürediArayüz : ITemelArayüz1, ITemelArayüz2{}
    internal sealed class KarmaSýnýf : Türedi, ITürediArayüz{public KarmaSýnýf() {Console.WriteLine ("Ben Temel, Türedi, ITemelArayüz1, ITemelArayüz2 ve ITürediArayüz'ü miraslayan 'sealed KarmaSýnýf'ým.");}}
    public class Ýþgören : IDisposable {
        private string isim;
        private  double maaþ;
        public Ýþgören (string i, double m) {isim = i; maaþ = m;} //Kurucu
        public void Dispose() {GC.SuppressFinalize (this);} //Ýstemli çöpcü
        public void Göster() {Console.Write ("{0}'ýn maaþý = {1,9:#,0.00} TL'dir.", isim, maaþ);}
        public static Ýþgören SýðKopyala (Ýþgören Ýþgören) {return (Ýþgören)Ýþgören.MemberwiseClone();}
        public override bool Equals (object ns) {
            Ýþgören aracý = (Ýþgören)ns;
            if (aracý.isim == this.isim && aracý.maaþ == this.maaþ) {return true;} else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("[Ýsim = {0},", this.isim);
            sb.AppendFormat ("\tMaaþ = {0}]", this.maaþ);
            return sb.ToString();
        }
        public override int GetHashCode() {return maaþ.GetHashCode();}
    }
    public sealed class KompleksSayý {
        private readonly double gerçel, sanal;
        public KompleksSayý (double g, double s) {gerçel = g; sanal = s;}
        public override int GetHashCode() {return (int)Math.Sqrt (Math.Pow (gerçel, 5) * Math.Pow (sanal, 5));}
    }
    class Deðer {
        public int sayý;
        public Deðer (int n) {this.sayý = n;} //Kurucu
    }
    class Nesne {
        public Deðer deðer;
        public Nesne (int sayý) {this.deðer = new Deðer (sayý);} //Kurucu
        public Nesne SýðKopya() {return((Nesne)MemberwiseClone());}
    }
    public class Kiþi : ICloneable {
        public string ad;
        public int yaþ;
        public Kiþi (string a, int y) {ad = a; yaþ = y;}
        public object Clone() {return MemberwiseClone();}
        public override string ToString() {return string.Format ("(ad, yaþ): ({0}, {1})", ad, yaþ);}
    }
    class Çeþitli5 {
        static bool EþitMi (object nes1, object nes2) {if (nes1 == null) {return false;} else return nes1.Equals (nes2);}
        static void Main() {
            Console.Write ("Bir sýnýf yada metodun miraslanmayla kullanýlmasý istenmezse 'sealed'/mühürlü beyan edilir.\nBirkaç hazýr System metotlarý: Equals, Finalize, GetHashCode, GetType, MemberwiseClone, ReferenceEquals ve ToString.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("TürediSýnýf.Koþ() metodu miraslanýp eriþilemez:");
            MiraslanmazSýnýf ms = new MiraslanmazSýnýf();
            TemelSýnýf tmls = new TemelSýnýf ("Zafer Candan", "Genetik Mühendisi");
            TürediSýnýf trds = new TürediSýnýf ("Canan Candan", "Ziraat Mühendisi");
            tmls.Koþ(); trds.Koþ();

            Console.WriteLine ("\n'sealed KarmaSýnýf' miraslanýp kullanýlamaz:");
            KarmaSýnýf nesne = new KarmaSýnýf();
            Console.WriteLine (nesne.ToString());

            Console.WriteLine ("\nSystem'in birkaç hazýr metotlarýnýn kullanýlmasý:");
            var r=new Random(); double ds1, ds2;
            Console.WriteLine ("2 Ýþgören nesnesi yaratýlýyor...");
            ds1=r.Next(7852,100000)+r.Next(10,100)/100D; Ýþgören iþg1 = new Ýþgören ("M.Nihat Yavaþ", ds1);
            ds1=r.Next(7852,100000)+r.Next(10,100)/100D; Ýþgören iþg2 = new Ýþgören ("Sefer Gökyiðit", ds1);
            Console.Write ("iþg1 detaylarý: "); iþg1.Göster();
            Console.Write ("\niþg2 detaylarý: "); iþg2.Göster();
            Console.WriteLine ("\niþg1.ToString() = " + iþg1.ToString());
            Console.WriteLine ("iþg2.ToString() = " + iþg2.ToString());
            Console.WriteLine ("iþg1.GetType() = " + iþg1.GetType());
            Console.WriteLine ("iþg1.GetHashCode() = " + iþg1.GetHashCode());
            Console.WriteLine ("Ýþgören.Equals (iþg1, iþg2) = " + Ýþgören.Equals (iþg1, iþg2));
            Console.WriteLine ("Ýþgören.ReferenceEquals (iþg1, iþg2) = " + Ýþgören.ReferenceEquals (iþg1, iþg2));
            Ýþgören iþg3 = Ýþgören.SýðKopyala (iþg1);
            Console.WriteLine ("Ýþgören.Equals (iþg1, iþg3) = " + Ýþgören.Equals (iþg1, iþg3));
            Console.WriteLine ("Ýþgören.ReferenceEquals (iþg1, iþg3) = " + Ýþgören.ReferenceEquals (iþg1, iþg3));
            Console.WriteLine ("Ýþgören.ReferenceEquals (iþg1, iþg1) = " + Ýþgören.ReferenceEquals (iþg1, iþg1));
            iþg1.Dispose(); iþg2.Dispose(); iþg3.Dispose();

            Console.WriteLine ("\nEquals ve özelleþtirilen Eþitmi()'yle object ve class eþitlik testleri:");
            // object eþitlik testi
            object nes1 = new System.Object();
            object nes2 = null;
            Console.WriteLine ("nes1 == nes2? {0}", EþitMi (nes2, nes1));
            nes2=nes1;
            Console.WriteLine ("nes1 == nes2? {0}", EþitMi (nes1, nes2));
            // class eþitlik testi
            Çeþitli5 s1 = new Çeþitli5();
            Çeþitli5 s2 = s1;
            object nes3 = s2;
            if (nes3.Equals (s1) && s2.Equals (nes3)) Console.WriteLine ("Ayný (s1, s2, nes3) tipleme!");

            Console.WriteLine ("\n(gerçel^5 + sanal^5)^0.5'le esgeçtirilen HashCode/KýymaKodu:");
            KompleksSayý ks; int i;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                ks=new KompleksSayý (ds1, ds2);
                Console.WriteLine ("({0} {1} i{2}) kompleks sayýnýn özelleþtirilen kýyma-kodu = {3}", ds1, ds2<0?"-":"+", Math.Abs (ds2), ks.GetHashCode());
            }

            Console.WriteLine ("\nNesnenin klonuyla deðersel eþitliði testi-1:");
            Nesne nes; Nesne sýðKopya; int ts1;
            for(i=0;i<5;i++) {
                ts1=r.Next();
                nes = new Nesne (ts1); sýðKopya=nes.SýðKopya();
                Console.WriteLine ("(aslý, klonu): ({0}, {1})\tEþit mi? {2}", nes.deðer.sayý, sýðKopya.deðer.sayý, (nes.deðer.sayý == sýðKopya.deðer.sayý));
            }

            Console.WriteLine ("\nNesnenin klonuyla deðersel eþitliði testi-2:");
            Kiþi kiþi; Kiþi klonu; string ad; int j;
            for(i=0;i<5;i++) {ad="";
                ts1=r.Next(0,85);
                for(j=0;j<4;j++) ad+=(char)(r.Next(0,26)+65);ad+=" "; for(j=0;j<5;j++) ad+=(char)(r.Next(0,26)+65);
                kiþi=new Kiþi (ad, ts1);
                klonu=(Kiþi)kiþi.Clone();
                if(i==1 | i==3)klonu.ad="Sevim Yavaþ";
                Console.WriteLine ("Kiþi: {0}\tKlonuyla eþit mi? {1}", kiþi, (kiþi.ad==klonu.ad & kiþi.yaþ==klonu.yaþ));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}