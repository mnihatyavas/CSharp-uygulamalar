// j2sc#0722e.cs: M�h�rl� s�n�f/metot ve birka� haz�r system metotlar�n�n testi �rne�i.

using System;
using System.Text; //StringBuilder i�in
namespace S�n�flar {
    sealed class MiraslanmazS�n�f {public MiraslanmazS�n�f(){Console.WriteLine ("Ben 'sealed MiraslanmazS�n�f'�m.");}}
    public class TemelS�n�f {
        public string isim, meslek;
        public TemelS�n�f (string isim, string meslek) {this.isim = isim; this.meslek = meslek;}
        public virtual void Ko�() {Console.WriteLine ("TemelS�n�f.Ko�() metodunda {0} {1} ko�uyor...", meslek, isim);}
    }
    public class T�rediS�n�f : TemelS�n�f {
        public T�rediS�n�f (string isim, string meslek) : base (isim, meslek){}
        sealed public override void Ko�() {Console.WriteLine ("T�rediS�n�f.Ko�() metodunda {0} {1} ko�uyor...", base.meslek, base.isim);}
    }
    public abstract class Temel{}
    internal class T�redi : Temel{}
    public interface ITemelAray�z1{}
    internal interface ITemelAray�z2{}
    internal interface IT�rediAray�z : ITemelAray�z1, ITemelAray�z2{}
    internal sealed class KarmaS�n�f : T�redi, IT�rediAray�z{public KarmaS�n�f() {Console.WriteLine ("Ben Temel, T�redi, ITemelAray�z1, ITemelAray�z2 ve IT�rediAray�z'� miraslayan 'sealed KarmaS�n�f'�m.");}}
    public class ��g�ren : IDisposable {
        private string isim;
        private  double maa�;
        public ��g�ren (string i, double m) {isim = i; maa� = m;} //Kurucu
        public void Dispose() {GC.SuppressFinalize (this);} //�stemli ��pc�
        public void G�ster() {Console.Write ("{0}'�n maa�� = {1,9:#,0.00} TL'dir.", isim, maa�);}
        public static ��g�ren S��Kopyala (��g�ren ��g�ren) {return (��g�ren)��g�ren.MemberwiseClone();}
        public override bool Equals (object ns) {
            ��g�ren arac� = (��g�ren)ns;
            if (arac�.isim == this.isim && arac�.maa� == this.maa�) {return true;} else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("[�sim = {0},", this.isim);
            sb.AppendFormat ("\tMaa� = {0}]", this.maa�);
            return sb.ToString();
        }
        public override int GetHashCode() {return maa�.GetHashCode();}
    }
    public sealed class KompleksSay� {
        private readonly double ger�el, sanal;
        public KompleksSay� (double g, double s) {ger�el = g; sanal = s;}
        public override int GetHashCode() {return (int)Math.Sqrt (Math.Pow (ger�el, 5) * Math.Pow (sanal, 5));}
    }
    class De�er {
        public int say�;
        public De�er (int n) {this.say� = n;} //Kurucu
    }
    class Nesne {
        public De�er de�er;
        public Nesne (int say�) {this.de�er = new De�er (say�);} //Kurucu
        public Nesne S��Kopya() {return((Nesne)MemberwiseClone());}
    }
    public class Ki�i : ICloneable {
        public string ad;
        public int ya�;
        public Ki�i (string a, int y) {ad = a; ya� = y;}
        public object Clone() {return MemberwiseClone();}
        public override string ToString() {return string.Format ("(ad, ya�): ({0}, {1})", ad, ya�);}
    }
    class �e�itli5 {
        static bool E�itMi (object nes1, object nes2) {if (nes1 == null) {return false;} else return nes1.Equals (nes2);}
        static void Main() {
            Console.Write ("Bir s�n�f yada metodun miraslanmayla kullan�lmas� istenmezse 'sealed'/m�h�rl� beyan edilir.\nBirka� haz�r System metotlar�: Equals, Finalize, GetHashCode, GetType, MemberwiseClone, ReferenceEquals ve ToString.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�rediS�n�f.Ko�() metodu miraslan�p eri�ilemez:");
            MiraslanmazS�n�f ms = new MiraslanmazS�n�f();
            TemelS�n�f tmls = new TemelS�n�f ("Zafer Candan", "Genetik M�hendisi");
            T�rediS�n�f trds = new T�rediS�n�f ("Canan Candan", "Ziraat M�hendisi");
            tmls.Ko�(); trds.Ko�();

            Console.WriteLine ("\n'sealed KarmaS�n�f' miraslan�p kullan�lamaz:");
            KarmaS�n�f nesne = new KarmaS�n�f();
            Console.WriteLine (nesne.ToString());

            Console.WriteLine ("\nSystem'in birka� haz�r metotlar�n�n kullan�lmas�:");
            var r=new Random(); double ds1, ds2;
            Console.WriteLine ("2 ��g�ren nesnesi yarat�l�yor...");
            ds1=r.Next(7852,100000)+r.Next(10,100)/100D; ��g�ren i�g1 = new ��g�ren ("M.Nihat Yava�", ds1);
            ds1=r.Next(7852,100000)+r.Next(10,100)/100D; ��g�ren i�g2 = new ��g�ren ("Sefer G�kyi�it", ds1);
            Console.Write ("i�g1 detaylar�: "); i�g1.G�ster();
            Console.Write ("\ni�g2 detaylar�: "); i�g2.G�ster();
            Console.WriteLine ("\ni�g1.ToString() = " + i�g1.ToString());
            Console.WriteLine ("i�g2.ToString() = " + i�g2.ToString());
            Console.WriteLine ("i�g1.GetType() = " + i�g1.GetType());
            Console.WriteLine ("i�g1.GetHashCode() = " + i�g1.GetHashCode());
            Console.WriteLine ("��g�ren.Equals (i�g1, i�g2) = " + ��g�ren.Equals (i�g1, i�g2));
            Console.WriteLine ("��g�ren.ReferenceEquals (i�g1, i�g2) = " + ��g�ren.ReferenceEquals (i�g1, i�g2));
            ��g�ren i�g3 = ��g�ren.S��Kopyala (i�g1);
            Console.WriteLine ("��g�ren.Equals (i�g1, i�g3) = " + ��g�ren.Equals (i�g1, i�g3));
            Console.WriteLine ("��g�ren.ReferenceEquals (i�g1, i�g3) = " + ��g�ren.ReferenceEquals (i�g1, i�g3));
            Console.WriteLine ("��g�ren.ReferenceEquals (i�g1, i�g1) = " + ��g�ren.ReferenceEquals (i�g1, i�g1));
            i�g1.Dispose(); i�g2.Dispose(); i�g3.Dispose();

            Console.WriteLine ("\nEquals ve �zelle�tirilen E�itmi()'yle object ve class e�itlik testleri:");
            // object e�itlik testi
            object nes1 = new System.Object();
            object nes2 = null;
            Console.WriteLine ("nes1 == nes2? {0}", E�itMi (nes2, nes1));
            nes2=nes1;
            Console.WriteLine ("nes1 == nes2? {0}", E�itMi (nes1, nes2));
            // class e�itlik testi
            �e�itli5 s1 = new �e�itli5();
            �e�itli5 s2 = s1;
            object nes3 = s2;
            if (nes3.Equals (s1) && s2.Equals (nes3)) Console.WriteLine ("Ayn� (s1, s2, nes3) tipleme!");

            Console.WriteLine ("\n(ger�el^5 + sanal^5)^0.5'le esge�tirilen HashCode/K�ymaKodu:");
            KompleksSay� ks; int i;
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D;
                ks=new KompleksSay� (ds1, ds2);
                Console.WriteLine ("({0} {1} i{2}) kompleks say�n�n �zelle�tirilen k�yma-kodu = {3}", ds1, ds2<0?"-":"+", Math.Abs (ds2), ks.GetHashCode());
            }

            Console.WriteLine ("\nNesnenin klonuyla de�ersel e�itli�i testi-1:");
            Nesne nes; Nesne s��Kopya; int ts1;
            for(i=0;i<5;i++) {
                ts1=r.Next();
                nes = new Nesne (ts1); s��Kopya=nes.S��Kopya();
                Console.WriteLine ("(asl�, klonu): ({0}, {1})\tE�it mi? {2}", nes.de�er.say�, s��Kopya.de�er.say�, (nes.de�er.say� == s��Kopya.de�er.say�));
            }

            Console.WriteLine ("\nNesnenin klonuyla de�ersel e�itli�i testi-2:");
            Ki�i ki�i; Ki�i klonu; string ad; int j;
            for(i=0;i<5;i++) {ad="";
                ts1=r.Next(0,85);
                for(j=0;j<4;j++) ad+=(char)(r.Next(0,26)+65);ad+=" "; for(j=0;j<5;j++) ad+=(char)(r.Next(0,26)+65);
                ki�i=new Ki�i (ad, ts1);
                klonu=(Ki�i)ki�i.Clone();
                if(i==1 | i==3)klonu.ad="Sevim Yava�";
                Console.WriteLine ("Ki�i: {0}\tKlonuyla e�it mi? {1}", ki�i, (ki�i.ad==klonu.ad & ki�i.ya�==klonu.ya�));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}