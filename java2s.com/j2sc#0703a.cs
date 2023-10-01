// j2sc#0703a.cs: Referanssal eþitsiz sýnýf nesnelerini deðersel eþitliðe çevirme örneði.

using System;
using System.Text; //StringBuilder
namespace Sýnýflar {
    class Ev {
        public string yapýmcý;
        public string model;
        public string renk;
        public int inþaYýlý;
        public void Baþladý() {Console.WriteLine (model + "'in inþaatý baþladý...");}
        public void Bitirildi() {Console.WriteLine (model + "'in inþaatý tamamlandý.");}
    }
    public class KompleksSayý {
        private double gerçel;
        private double sanal;
        public KompleksSayý (double gerçel, double sanal) {//Parametreli kurucu
            this.gerçel = gerçel;
            this.sanal = sanal;
        }
        public override bool Equals (object nsn) {
            KompleksSayý diðer = nsn as KompleksSayý;
            if (diðer == null) {return false;}
            return (this.gerçel == diðer.gerçel) && (this.sanal == diðer.sanal);
        }
        public override int GetHashCode() {return (int)gerçel ^ (int)sanal;} //^: XOR farklýysa true (sadece int kýsýmlarý)
        public static bool operator== (KompleksSayý ben, KompleksSayý diðer) {return Equals (ben, diðer);}
        public static bool operator!= (KompleksSayý ben, KompleksSayý diðer) {return Equals (ben, diðer);}
    }
    class Sýnýf1 {
        public int alan1;
        public override bool Equals (object nsn) {
            Sýnýf1 diðer = nsn as Sýnýf1;
            if (diðer == null) {return false;}
            return (this.alan1 == diðer.alan1) && (diðer != null) && (nsn != null);
        }
        public override int GetHashCode() {return alan1 ^ 2023;}
    }
    class Þahýs {
        private string isim;
        string SGN;
        byte yaþ;
        public Þahýs (string isim, string sgn, byte y) {
            this.isim = isim;
            SGN = sgn;
            yaþ = y;
        }
        public override bool Equals (object nsn) {
            Þahýs aracý = (Þahýs)nsn;
            if (aracý.isim == this.isim && aracý.SGN == this.SGN && aracý.yaþ == this.yaþ) return true;
            else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("\t[Ýsim = {0}", this.isim);
            sb.AppendFormat (", SGN= {0}", this.SGN);
            sb.AppendFormat (", Yaþ= {0}]", this.yaþ);
            return sb.ToString();
        }
        public override int GetHashCode() {return SGN.GetHashCode();}
    }
    class SýnýfNesnesiReferansý1 {
        public static void Fonksiyon1() {Console.WriteLine ("Statik Fonksiyon1() çaðrýldý.");}
        static void Main() {
            Console.Write ("'new' ile yaratýlan sýnýf nesnesi, nesnenin bellek adresini döndürerek eþitlenen deðiþkene atanýr. Sýnýf nesnesi birbaþka deðiþkene eþitlendiðinde/kopya referans adresi atandýðýndan herhangibirindeki deðiþiklik diðerine de aynen yansýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf nesnesi ve kopyasýnýn deðiþikliklerden aynen etkilenmesi:");
            Ev evim;
            Console.WriteLine ("Bir Ev nesnesi yaratýlýp bellek adresi evim'e atanýyor...");
            evim = new Ev();
            evim.yapýmcý = "Temel Ýnþaat";
            evim.model = "Apartman";
            evim.renk = "gri";
            evim.inþaYýlý = 1995;
            Console.WriteLine ("Evim'in detaylarý:");
            evim.Baþladý();
            Console.WriteLine ("evim.yapýmcý = " + evim.yapýmcý);
            Console.WriteLine ("evim.model = " + evim.model);
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evim.inþaYýlý = " + evim.inþaYýlý);
            evim.Bitirildi();
            Console.WriteLine ("Birbaþka Ev nesnesi yaratýlýp bellek adresi evin'e atanýyor...");
            Ev evin = new Ev();
            evin.yapýmcý = "Schlumberger Ýnþaat";
            evin.model = "Tripleks";
            evin.renk = "kahve";
            evin.inþaYýlý = 2000;
            Console.WriteLine ("Evin'in modeli: " + evin.model);
            evin.Baþladý();
            evin.Bitirildi();
            Console.WriteLine ("evin'in referans adresi evim'e atanýyor...");
            evim = evin;
            Console.WriteLine ("Evim'in yeni detaylarý:");
            Console.WriteLine("evim.yapýmcý = " + evim.yapýmcý);
            Console.WriteLine ("evim.model = " + evim.model);
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evim.inþaYýlý = " + evim.inþaYýlý);
            Console.WriteLine ("Evim mavi'ye boyanýyor...");
            evim.renk = "mavi";
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evin.renk = " + evin.renk);

            Console.WriteLine ("\nAyný deðersel içerik farklý referanssal 'new' yaratýmla eþitlikler:");
            KompleksSayý referansA = new KompleksSayý (1881.010101, 1938.110905); Console.WriteLine ("referansA.GetHashCode() = {0}", referansA.GetHashCode()); //1881 XOR 1938
            KompleksSayý referansB = new KompleksSayý (1881.010101, 1938.110905); Console.WriteLine ("referansB.GetHashCode() = {0}", referansB.GetHashCode()); //1881 XOR 1938
            Console.WriteLine ("Deðersel Eþitlik: {0}", referansA == referansB); //gerçel ile sanal deðerlerinin eþitliði
            Console.WriteLine ("Deðersel Eþitsizlik: {0}", referansA != referansB); //Varsayýlý kýlýnan: == ile != aynýlýðý
            Console.WriteLine ("Referanssal Eþitlik: {0}", (object)referansA == (object)referansB); //Ayrý new referans adres farklýlýðý
            Console.WriteLine ("Referanssal Eþitsizlik: {0}", (object)referansA != (object)referansB);
            Console.WriteLine ("ReferenceEquals: {0}", ReferenceEquals (referansA, referansB) ); //Referans adres farklýlýðýný irdeler
            Console.WriteLine ("Aþýrýyükleme Equals: {0}", Equals (referansA, referansB) ); //Aþýrýyüklemeyle gerçel ve sanal eþitliðini irdeler

            Console.WriteLine ("\nStatik fonksiyon çaðýrma; varsayýlý ve özel tipleme eþitliði:");
            SýnýfNesnesiReferansý1.Fonksiyon1(); //Sýnýf tipli çaðýrma
            Fonksiyon1(); // Ayný sýnýf içinden doðrudan çaðýrma
            //new SýnýfNesnesiReferansý1().Fonksiyon1(); //Statik metot tiplenemez
            Sýnýf1 adresA = new Sýnýf1();
            Sýnýf1 adresB = new Sýnýf1();
            adresA.alan1=1955; adresB.alan1=1955;
            Console.WriteLine ("Deðersel: adresA.GetHashCode() = {0},\tadresB.GetHashCode() = {1}", adresA.GetHashCode(), adresB.GetHashCode());
            Console.WriteLine ("Referanssal (adresA == adresB)? {0}", adresA == adresB);
            Console.WriteLine ("ReferenceEquals (adresA, adresB)? {0}", ReferenceEquals (adresA, adresB) );
            Console.WriteLine ("Aþýrýyükleme deðersel Equals: {0}", Equals (adresA, adresB) );

            Console.WriteLine ("\nAþýrýyüklemeli özel Equals eþitliði isim, yaþ, SGN ve kýyma-kodla saðlama:");
            Þahýs þ1 = new Þahýs ("Hamza Candan", "444-44-444", 2023-1945); Þahýs þ2 = new Þahýs ("Hamza Candan", "444-44-444", 2023-1945);
            //unsafe {Console.WriteLine ("Referans adresler (þ1, þ2) = ({0}, {1})", (int)(Þahýs*)&þ1, (int)(Þahýs*)&þ2);}
            Console.WriteLine (þ1); Console.WriteLine (þ2);
            Console.WriteLine ("\tKýyma kodlar (þ1, þ2) = ({0}, {1})", (long)þ1.GetHashCode(), (long)þ2.GetHashCode());
            if (þ1.Equals (þ2) && þ1.GetHashCode() == þ2.GetHashCode()) Console.WriteLine ("þ1 ve þ2 deðersel EÞÝTTÝR"); else Console.WriteLine ("þ1 ve þ2 deðersel FARKLIDIR");
            þ2 = new Þahýs ("Nihal Candan", "555-55-555", 2023-1955);
            Console.WriteLine (þ2);
            Console.WriteLine ("\tKýyma kodlar (þ1, þ2) = ({0}, {1})", (long)þ1.GetHashCode(), (long)þ2.GetHashCode());
            if (þ1.Equals (þ2) && þ1.GetHashCode() == þ2.GetHashCode()) Console.WriteLine ("þ1 ve þ2 deðersel EÞÝTTÝR"); else Console.WriteLine ("þ1 ve þ2 deðersel FARKLIDIR");


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
