// j2sc#0717b.cs: Miraslanan �oklu aray�zlerin hiyrar�isi �rne�i.

using System;
namespace S�n�flar {
    interface ISesHacmi {int Derecesi {get;set;}}
    interface ISesH�z� {int Derecesi {get;set;}}
    interface ISesTizli�i {int Derecesi {get;set;}}
    interface ISesKontrast� {int Derecesi {get;set;}}
    public class Radyo : ISesHacmi, ISesH�z�, ISesTizli�i, ISesKontrast� {
        int hacim, h�z, tiz, kontrast;
        int ISesHacmi.Derecesi {get {return hacim;} set {hacim = value;}}
        int ISesH�z�.Derecesi {get {return h�z;} set {h�z = value;}}
        int ISesTizli�i.Derecesi {get {return tiz;} set {tiz = value;}}
        int ISesKontrast�.Derecesi {get {return kontrast;} set {kontrast = value;}}
    }
    interface IDe�i�tirilebilir {void Yaz(); void Oku (string s);}
    interface IKonu�ulabilir {void Konu�(); void Oku (string s);}
    interface IDinlenebilir {void Dinle(); void Oku (string s);}
    interface I�zlenebilir {void �zle(); void Oku (string s);}
    public class D�k�man : IDe�i�tirilebilir, IKonu�ulabilir, IDinlenebilir, I�zlenebilir {
        public D�k�man (string s) {Console.WriteLine ("Kuruculu \"{0}\" yarat�l�yor.", s);}
        public virtual void Oku (string s) {Console.WriteLine ("{0}.Yaz() y�r�t�lmekte.", s);} //�oklu aray�zlerde kullan�laca��ndan virtual olmal�d�r.
        public void Yaz() {Console.WriteLine ("IDe�i�tirilebilir.Yaz() y�r�t�lmekte.");}
        public void Konu�() {Console.WriteLine ("IKonu�ulabilir.Konu�() y�r�t�lmekte.");}
        public void Dinle() {Console.WriteLine ("IDinlenebilir.Dinle() y�r�t�lmekte.");}
        public void �zle() {Console.WriteLine ("I�zlenebilir.�zle() y�r�t�lmekte.");}
    }
    interface ITest1 {void Y�r�t (string s);}
    interface ITest2 : ITest1{}
    class Temel : ITest2 {public void Y�r�t (string s) {Console.WriteLine ("Temel.Y�r�t() (\"{0}\") referansl�", s);}}
    class T�redi : Temel {public new void Y�r�t (string s) {Console.WriteLine ("T�redi.Y�r�t (\"{0}\") belirte�li", s);}}
    interface Al�c� {int VeriyiAl();}
    interface Koyucu {void VeriyiKoy (int x);}
    interface Al�c�Koyucu : Al�c�, Koyucu{}
    class Veri : Al�c�Koyucu {
        int veri;
        public int VeriyiAl() {return veri;}
        public void VeriyiKoy (int x) {veri = x;}
    }
    public interface Aray�zA {void Metot1(); void Metot2();}
    public interface Aray�zB : Aray�zA {void Metot3();}
    public interface Aray�zC : Aray�zB  {void Metot4(); void Metot5();}
    class S�n�f : Aray�zC {
        public void Metot1() {Console.WriteLine ("S�n�f.Metot1() y�r�t�l�yor.");}
        public void Metot2() {Console.WriteLine ("S�n�f.Metot2() y�r�t�l�yor.");}
        public void Metot3() {Console.WriteLine ("S�n�f.Metot3() y�r�t�l�yor.");}
        public void Metot4() {Console.WriteLine ("S�n�f.Metot4() y�r�t�l�yor.");}
        public void Metot5() {Console.WriteLine ("S�n�f.Metot5() y�r�t�l�yor.");}
    }
    public interface I�ifreliVeri {void �ifrele();}
    public class �ifreKontrol {public void �ifrele() {Console.WriteLine ("\t�ifreKontrol.�ifrele() �a�r�ld�.");}}
    public class D�zenle : �ifreKontrol, I�ifreliVeri{}
    class Aray�z2 {
        static void Main() {
            Console.Write ("�oklu aray�z t�redisi tiplendikten sonra ((IAray�z1)t�redTipleme).Metot()/�zellik kestirmeyle t�m farkl� aray�z �ablonlu g�vdeli �yelerine eri�ilebilmektedir. Aray�zler de di�er aray�zleri �oklu miraslayabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Radyonun t�m akt�el ayarlar�n� atama ve alma:");
            var r=new Random(); Radyo ayar = new Radyo();
            int ts1=r.Next(0, 101), i; ((ISesHacmi)ayar).Derecesi = ts1; Console.WriteLine ("�uanki ses hacmi = % {0}", ((ISesHacmi)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesH�z�)ayar).Derecesi = ts1; Console.WriteLine ("�uanki ses h�z� = % {0}", ((ISesH�z�)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesTizli�i)ayar).Derecesi = ts1; Console.WriteLine ("�uanki ses tizli�i = % {0}", ((ISesTizli�i)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesKontrast�)ayar).Derecesi = ts1; Console.WriteLine ("�uanki ses kontrast� = % {0}", ((ISesKontrast�)ayar).Derecesi);

            Console.WriteLine ("\n�oklu aray�zl� t�redinin ayn� ve farkl� Metotlar� y�r�tmesi:");
            D�k�man dkmn = new D�k�man ("Test D�k�man�");
            dkmn.Yaz(); dkmn.Konu�(); dkmn.Dinle(); dkmn.�zle(); 
            ((IDe�i�tirilebilir)dkmn).Oku ("IDe�i�tirilebilir"); ((IKonu�ulabilir)dkmn).Oku ("IKonu�ulabilir"); ((IDinlenebilir)dkmn).Oku ("IDinlenebilir"); ((I�zlenebilir)dkmn).Oku ("I�zlenebilir");

            Console.WriteLine ("\nHiyerar�ik aray�z, temel, t�redi Metotlar�n referansl� y�r�t�lmesi:");
            T�redi t�r = new T�redi();
            t�r.Y�r�t ("new");
            ((Temel)t�r).Y�r�t ("Temel");
            ((ITest2)t�r).Y�r�t ("ITest2");
            ((ITest1)t�r).Y�r�t ("ITest1");

            Console.WriteLine ("\n�oklu aray�zler miraslayarak veri konulmas� ve al�nmas�:");
            Veri veri;
            for(i=1;i<=5;i++) {
                ts1=r.Next(-1000, 1000);
                veri = new Veri();
                veri.VeriyiKoy (ts1);
                Console.WriteLine ("{0}.veri = {1}",  i, veri.VeriyiAl());
            }

            Console.WriteLine ("\n3 aray�z�n 5 �ablon metotlar�n�n miraslan�p y�r�t�lmesi:");
            S�n�f nesne = new S�n�f();
            nesne.Metot1(); nesne.Metot2(); nesne.Metot3(); nesne.Metot4(); nesne.Metot5();

            Console.WriteLine ("\nMiraslananlar�n farkl� i�levselliklerinin kontrolu:");
            D�zenle d�zelt1 = new D�zenle();
            I�ifreliVeri �ifrele1 = d�zelt1 as I�ifreliVeri;
            if (�ifrele1 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele1.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}
            D�zenle d�zelt2 = new D�zenle();
            I�ifreliVeri �ifrele2 = (I�ifreliVeri)d�zelt2;
            if (�ifrele2 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele2.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}
            D�zenle d�zelt3 = new D�zenle();
            I�ifreliVeri �ifrele3 = d�zelt3;
            if (�ifrele3 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele3.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}
            I�ifreliVeri �ifrele4 = new D�zenle();
            if (�ifrele4 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele4.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}
            D�zenle �ifrele5 = new D�zenle();
            if (�ifrele5 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele5.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}
            �ifreKontrol �ifrele6 = new D�zenle();
            if (�ifrele6 != null) {Console.WriteLine ("I�ifreliVeri desteklenmektedir..."); �ifrele6.�ifrele();
            } else {Console.WriteLine ("I�ifreliVeri desteklenmeMEktedir...");}


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}