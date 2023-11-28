// j2sc#0717a.cs: Arayüz þablon metot esaslý gövdeli türedi metotlar örneði.

using System;
namespace Sýnýflar {
    public interface IDosya {
        int DosyaAç (string dosyaAdý);
        int DosyaKapa (string dosyaAdý);
        void DosyaKaydet (string dosyaKaydý);
    }
    public class Dosyam : IDosya {
        public int DosyaAç (string dosyaAdý) {Console.WriteLine ("\"{0}\" adlý dosya açýlýyor.", dosyaAdý); return 0;}
        public int DosyaKapa (string dosyaAdý) {Console.WriteLine ("\"{0}\" adlý kayýt dosyasý kapanýyor.", dosyaAdý); return 0;}
        public void DosyaKaydet (string dosyaKaydý) {Console.WriteLine ("Dosya kaydý: \"{0}\"", dosyaKaydý);}
    }
    public interface ISeri {
        void baþlat(int x);
        int birartýr();
    }
    class Sýrala : ISeri {
        int n;
        public Sýrala() {n = 0;}
        public void baþlat (int x) {n = x;}
        public int birartýr() {return n++;}
    }
    interface Arayüz {void ArayüzMetodu();}
    public class Temel: Arayüz {public void ArayüzMetodu() {Console.WriteLine ("Temel.ArayüzMetodu()");}}
    public class Türedi: Temel {public new void ArayüzMetodu() {Console.WriteLine ("Türedi.ArayüzMetodu()");}}
    public class Bileþen {public Bileþen(){}}
    interface SayfaÖlçekleme {
        void sayfaBaþlýðý (float ölçek);
        void sayfaAyaklýðý (float ölçek);
        void sayfaSolmarjý (float ölçek);
        void sayfaSaðmarjý (float ölçek);
        void yaz();
    }
    public class MetinYazýlýmý: Bileþen, SayfaÖlçekleme {
        protected string metin;
        protected float baþlýk, ayaklýk, solmarj, saðmarj;
        public MetinYazýlýmý (string metin) {this.metin = metin;}
        public void sayfaBaþlýðý (float ölçek) {baþlýk = ölçek;}
        public void sayfaAyaklýðý (float ölçek) {ayaklýk = ölçek;}
        public void sayfaSolmarjý (float ölçek) {solmarj = ölçek;}
        public void sayfaSaðmarjý (float ölçek) {saðmarj = ölçek;}
        public void yaz () {
            Console.WriteLine ("\t\tSayfa baþlýk marjý: {0}", baþlýk);
            Console.WriteLine ("Sayfa sol marj: {0}\t[Metin: \"{1}\"]\tSayfa sað marj: {2}", solmarj, metin, saðmarj);
            Console.WriteLine ("\t\tSayfa ayaklýk marjý: {0}", ayaklýk);
        }
    }
    public interface Kanal {void Sonraki(); void Önceki();}
    public interface Kitap {void Sonraki(); void Bölüm();}
    public interface Müzik {void Sonraki(); void Önceki();}
    public class TürediSýnýf : Kanal, Kitap, Müzik {
        void Kanal.Sonraki() {Console.WriteLine ("Kanal.Sonraki()");}
        void Kitap.Sonraki() {Console.WriteLine ("Kitap.Sonraki()");}
        void Müzik.Sonraki() {Console.WriteLine ("Müzik.Sonraki()");}
        void Kanal.Önceki() {Console.WriteLine ("Kanal.Önceki()");}
        void Müzik.Önceki() {Console.WriteLine ("Müzik.Önceki()");}
        public void Bölüm() {Console.WriteLine ("Bölüm()");}
    }
    public interface IKýyas {
        int DeðeriAl();
        int Kýyasla (IKýyas ik);
    }
    abstract public class TemelSýnýf : IKýyas {
        int n;
        public TemelSýnýf (int n0) {n = n0;}
        public int N {get {return DeðeriAl();}}
        public int DeðeriAl() {return n;}
        abstract public int Kýyasla (IKýyas tk);
    }
    public class AltSýnýf : TemelSýnýf {
        public AltSýnýf (int n0) : base (n0){}
        override public int Kýyasla (IKýyas ik) {return DeðeriAl().CompareTo (ik.DeðeriAl());}
    }
    class Arayüz1 {
    public static void Karþýlaþtýr (IKýyas ik1, IKýyas ik2) {Console.WriteLine ("tmlk1 [{0}].Kýyasla (tmlk2 [{1}]): Sonuç = {2}", ik1.DeðeriAl(), ik2.DeðeriAl(), ik1.Kýyasla (ik2));}
        static void Main() {
            Console.Write ("Soyut sýnýfýn soyut metotlarý gibi arayüz metotlarý da tamamen gövdesiz þablonlardýr; referans yada tiplemeleri olmaz, miraslayan, þablon metotlarý public eriþimle esgeçmesiz gövdelendirir. Türedi sýnýfýn tek temeli ve virgüllerle ayrýk çoklu arayüzleri olabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Arayüz metotlarýnýn miraslanarak iþlevselleþtirilmesi:");
            Dosyam dos = new Dosyam();
            dos.DosyaAç ("mny.log");
            dos.DosyaKaydet ("Ýlk kayýt: Merhaba dünya!");
            dos.DosyaKaydet ("Ýkinci kayýt: Nasýlsýnýz?..");
            dos.DosyaKaydet ("Son kayýt: Hoþçakalýn.");
            dos.DosyaKapa ("mny.log");

            Console.WriteLine ("\nArayüz metotlarý iþlenerek artan sayaçlarýn sýralanmasý:");
            var r=new Random(); int ts1=r.Next (1, 100), ts2=r.Next (5, 50), i; 
            Sýrala sr = new Sýrala();
            Console.WriteLine ("\tBaþlatma sayýsý = {0}", 0);
            for(i=0; i < ts2; i++) Console.Write (sr.birartýr() + " "); Console.WriteLine();
            Console.WriteLine ("\tBaþlatma sayýsý = {0}", ts1); sr.baþlat (ts1);
            for(i=0; i < ts2; i++) Console.Write (sr.birartýr() + " "); Console.WriteLine();

            Console.WriteLine ("\nReferans (Arayüz, Temel, Türedi) ile tipleme (Türedi)'nin geçerlilediði metot:");
            Türedi tür = new Türedi(); tür.ArayüzMetodu();
            Arayüz ay = (Arayüz) tür; ay.ArayüzMetodu();
            Arayüz atür = new Türedi(); atür.ArayüzMetodu();
            Temel ttür = new Türedi(); ttür.ArayüzMetodu();

            Console.WriteLine ("\nMetni sayfa bileþenine üst-alt-sol-sað marj/sm ayarlý yazdýrma:");
            float fs1=r.Next(0, 10)+r.Next(10, 100)/100F, fs2=r.Next(0, 10)+r.Next(10, 100)/100F, fs3=r.Next(0, 10)+r.Next(10, 100)/100F, fs4=r.Next(0, 10)+r.Next(10, 100)/100F;
            MetinYazýlýmý metin = new MetinYazýlýmý ("Merhaba dünya!");
            SayfaÖlçekleme ölç = (SayfaÖlçekleme) metin;
            ölç.sayfaBaþlýðý (fs1); ölç.sayfaAyaklýðý (fs2); ölç.sayfaSolmarjý (fs3); ölç.sayfaSaðmarjý (fs4);
            ölç.yaz();

            Console.WriteLine ("\nÇoklu arayüzün ayný/farklý metotlarýnýn tiplenmesi:");
            TürediSýnýf ts = new TürediSýnýf();
            ((Kanal)ts).Sonraki(); ((Kitap)ts).Sonraki(); ((Müzik)ts).Sonraki();
            ((Kanal)ts).Önceki(); ((Müzik)ts).Önceki();
            ts.Bölüm();

            Console.WriteLine ("\nArayüz, temel, türedi, CompareTo() ve Karþýlaþtýr()'la 2 tamsayýnýn kýyasý:");
            AltSýnýf as1; AltSýnýf as2;
            as1 = new AltSýnýf (20231510);  as2 = new AltSýnýf (20231510);
            Karþýlaþtýr (as1, as2);
            for(i=0; i < 5; i++) {
                ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000);
                as1 = new AltSýnýf (ts1);  as2 = new AltSýnýf (ts2);
                Karþýlaþtýr (as1, as2);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}