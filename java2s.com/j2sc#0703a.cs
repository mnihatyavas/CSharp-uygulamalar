// j2sc#0703a.cs: Referanssal e�itsiz s�n�f nesnelerini de�ersel e�itli�e �evirme �rne�i.

using System;
using System.Text; //StringBuilder
namespace S�n�flar {
    class Ev {
        public string yap�mc�;
        public string model;
        public string renk;
        public int in�aY�l�;
        public void Ba�lad�() {Console.WriteLine (model + "'in in�aat� ba�lad�...");}
        public void Bitirildi() {Console.WriteLine (model + "'in in�aat� tamamland�.");}
    }
    public class KompleksSay� {
        private double ger�el;
        private double sanal;
        public KompleksSay� (double ger�el, double sanal) {//Parametreli kurucu
            this.ger�el = ger�el;
            this.sanal = sanal;
        }
        public override bool Equals (object nsn) {
            KompleksSay� di�er = nsn as KompleksSay�;
            if (di�er == null) {return false;}
            return (this.ger�el == di�er.ger�el) && (this.sanal == di�er.sanal);
        }
        public override int GetHashCode() {return (int)ger�el ^ (int)sanal;} //^: XOR farkl�ysa true (sadece int k�s�mlar�)
        public static bool operator== (KompleksSay� ben, KompleksSay� di�er) {return Equals (ben, di�er);}
        public static bool operator!= (KompleksSay� ben, KompleksSay� di�er) {return Equals (ben, di�er);}
    }
    class S�n�f1 {
        public int alan1;
        public override bool Equals (object nsn) {
            S�n�f1 di�er = nsn as S�n�f1;
            if (di�er == null) {return false;}
            return (this.alan1 == di�er.alan1) && (di�er != null) && (nsn != null);
        }
        public override int GetHashCode() {return alan1 ^ 2023;}
    }
    class �ah�s {
        private string isim;
        string SGN;
        byte ya�;
        public �ah�s (string isim, string sgn, byte y) {
            this.isim = isim;
            SGN = sgn;
            ya� = y;
        }
        public override bool Equals (object nsn) {
            �ah�s arac� = (�ah�s)nsn;
            if (arac�.isim == this.isim && arac�.SGN == this.SGN && arac�.ya� == this.ya�) return true;
            else return false;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("\t[�sim = {0}", this.isim);
            sb.AppendFormat (", SGN= {0}", this.SGN);
            sb.AppendFormat (", Ya�= {0}]", this.ya�);
            return sb.ToString();
        }
        public override int GetHashCode() {return SGN.GetHashCode();}
    }
    class S�n�fNesnesiReferans�1 {
        public static void Fonksiyon1() {Console.WriteLine ("Statik Fonksiyon1() �a�r�ld�.");}
        static void Main() {
            Console.Write ("'new' ile yarat�lan s�n�f nesnesi, nesnenin bellek adresini d�nd�rerek e�itlenen de�i�kene atan�r. S�n�f nesnesi birba�ka de�i�kene e�itlendi�inde/kopya referans adresi atand���ndan herhangibirindeki de�i�iklik di�erine de aynen yans�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f nesnesi ve kopyas�n�n de�i�ikliklerden aynen etkilenmesi:");
            Ev evim;
            Console.WriteLine ("Bir Ev nesnesi yarat�l�p bellek adresi evim'e atan�yor...");
            evim = new Ev();
            evim.yap�mc� = "Temel �n�aat";
            evim.model = "Apartman";
            evim.renk = "gri";
            evim.in�aY�l� = 1995;
            Console.WriteLine ("Evim'in detaylar�:");
            evim.Ba�lad�();
            Console.WriteLine ("evim.yap�mc� = " + evim.yap�mc�);
            Console.WriteLine ("evim.model = " + evim.model);
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evim.in�aY�l� = " + evim.in�aY�l�);
            evim.Bitirildi();
            Console.WriteLine ("Birba�ka Ev nesnesi yarat�l�p bellek adresi evin'e atan�yor...");
            Ev evin = new Ev();
            evin.yap�mc� = "Schlumberger �n�aat";
            evin.model = "Tripleks";
            evin.renk = "kahve";
            evin.in�aY�l� = 2000;
            Console.WriteLine ("Evin'in modeli: " + evin.model);
            evin.Ba�lad�();
            evin.Bitirildi();
            Console.WriteLine ("evin'in referans adresi evim'e atan�yor...");
            evim = evin;
            Console.WriteLine ("Evim'in yeni detaylar�:");
            Console.WriteLine("evim.yap�mc� = " + evim.yap�mc�);
            Console.WriteLine ("evim.model = " + evim.model);
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evim.in�aY�l� = " + evim.in�aY�l�);
            Console.WriteLine ("Evim mavi'ye boyan�yor...");
            evim.renk = "mavi";
            Console.WriteLine ("evim.renk = " + evim.renk);
            Console.WriteLine ("evin.renk = " + evin.renk);

            Console.WriteLine ("\nAyn� de�ersel i�erik farkl� referanssal 'new' yarat�mla e�itlikler:");
            KompleksSay� referansA = new KompleksSay� (1881.010101, 1938.110905); Console.WriteLine ("referansA.GetHashCode() = {0}", referansA.GetHashCode()); //1881 XOR 1938
            KompleksSay� referansB = new KompleksSay� (1881.010101, 1938.110905); Console.WriteLine ("referansB.GetHashCode() = {0}", referansB.GetHashCode()); //1881 XOR 1938
            Console.WriteLine ("De�ersel E�itlik: {0}", referansA == referansB); //ger�el ile sanal de�erlerinin e�itli�i
            Console.WriteLine ("De�ersel E�itsizlik: {0}", referansA != referansB); //Varsay�l� k�l�nan: == ile != ayn�l���
            Console.WriteLine ("Referanssal E�itlik: {0}", (object)referansA == (object)referansB); //Ayr� new referans adres farkl�l���
            Console.WriteLine ("Referanssal E�itsizlik: {0}", (object)referansA != (object)referansB);
            Console.WriteLine ("ReferenceEquals: {0}", ReferenceEquals (referansA, referansB) ); //Referans adres farkl�l���n� irdeler
            Console.WriteLine ("A��r�y�kleme Equals: {0}", Equals (referansA, referansB) ); //A��r�y�klemeyle ger�el ve sanal e�itli�ini irdeler

            Console.WriteLine ("\nStatik fonksiyon �a��rma; varsay�l� ve �zel tipleme e�itli�i:");
            S�n�fNesnesiReferans�1.Fonksiyon1(); //S�n�f tipli �a��rma
            Fonksiyon1(); // Ayn� s�n�f i�inden do�rudan �a��rma
            //new S�n�fNesnesiReferans�1().Fonksiyon1(); //Statik metot tiplenemez
            S�n�f1 adresA = new S�n�f1();
            S�n�f1 adresB = new S�n�f1();
            adresA.alan1=1955; adresB.alan1=1955;
            Console.WriteLine ("De�ersel: adresA.GetHashCode() = {0},\tadresB.GetHashCode() = {1}", adresA.GetHashCode(), adresB.GetHashCode());
            Console.WriteLine ("Referanssal (adresA == adresB)? {0}", adresA == adresB);
            Console.WriteLine ("ReferenceEquals (adresA, adresB)? {0}", ReferenceEquals (adresA, adresB) );
            Console.WriteLine ("A��r�y�kleme de�ersel Equals: {0}", Equals (adresA, adresB) );

            Console.WriteLine ("\nA��r�y�klemeli �zel Equals e�itli�i isim, ya�, SGN ve k�yma-kodla sa�lama:");
            �ah�s �1 = new �ah�s ("Hamza Candan", "444-44-444", 2023-1945); �ah�s �2 = new �ah�s ("Hamza Candan", "444-44-444", 2023-1945);
            //unsafe {Console.WriteLine ("Referans adresler (�1, �2) = ({0}, {1})", (int)(�ah�s*)&�1, (int)(�ah�s*)&�2);}
            Console.WriteLine (�1); Console.WriteLine (�2);
            Console.WriteLine ("\tK�yma kodlar (�1, �2) = ({0}, {1})", (long)�1.GetHashCode(), (long)�2.GetHashCode());
            if (�1.Equals (�2) && �1.GetHashCode() == �2.GetHashCode()) Console.WriteLine ("�1 ve �2 de�ersel E��TT�R"); else Console.WriteLine ("�1 ve �2 de�ersel FARKLIDIR");
            �2 = new �ah�s ("Nihal Candan", "555-55-555", 2023-1955);
            Console.WriteLine (�2);
            Console.WriteLine ("\tK�yma kodlar (�1, �2) = ({0}, {1})", (long)�1.GetHashCode(), (long)�2.GetHashCode());
            if (�1.Equals (�2) && �1.GetHashCode() == �2.GetHashCode()) Console.WriteLine ("�1 ve �2 de�ersel E��TT�R"); else Console.WriteLine ("�1 ve �2 de�ersel FARKLIDIR");


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
