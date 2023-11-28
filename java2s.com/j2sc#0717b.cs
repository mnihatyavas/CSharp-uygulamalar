// j2sc#0717b.cs: Miraslanan çoklu arayüzlerin hiyrarþisi örneði.

using System;
namespace Sýnýflar {
    interface ISesHacmi {int Derecesi {get;set;}}
    interface ISesHýzý {int Derecesi {get;set;}}
    interface ISesTizliði {int Derecesi {get;set;}}
    interface ISesKontrastý {int Derecesi {get;set;}}
    public class Radyo : ISesHacmi, ISesHýzý, ISesTizliði, ISesKontrastý {
        int hacim, hýz, tiz, kontrast;
        int ISesHacmi.Derecesi {get {return hacim;} set {hacim = value;}}
        int ISesHýzý.Derecesi {get {return hýz;} set {hýz = value;}}
        int ISesTizliði.Derecesi {get {return tiz;} set {tiz = value;}}
        int ISesKontrastý.Derecesi {get {return kontrast;} set {kontrast = value;}}
    }
    interface IDeðiþtirilebilir {void Yaz(); void Oku (string s);}
    interface IKonuþulabilir {void Konuþ(); void Oku (string s);}
    interface IDinlenebilir {void Dinle(); void Oku (string s);}
    interface IÝzlenebilir {void Ýzle(); void Oku (string s);}
    public class Döküman : IDeðiþtirilebilir, IKonuþulabilir, IDinlenebilir, IÝzlenebilir {
        public Döküman (string s) {Console.WriteLine ("Kuruculu \"{0}\" yaratýlýyor.", s);}
        public virtual void Oku (string s) {Console.WriteLine ("{0}.Yaz() yürütülmekte.", s);} //Çoklu arayüzlerde kullanýlacaðýndan virtual olmalýdýr.
        public void Yaz() {Console.WriteLine ("IDeðiþtirilebilir.Yaz() yürütülmekte.");}
        public void Konuþ() {Console.WriteLine ("IKonuþulabilir.Konuþ() yürütülmekte.");}
        public void Dinle() {Console.WriteLine ("IDinlenebilir.Dinle() yürütülmekte.");}
        public void Ýzle() {Console.WriteLine ("IÝzlenebilir.Ýzle() yürütülmekte.");}
    }
    interface ITest1 {void Yürüt (string s);}
    interface ITest2 : ITest1{}
    class Temel : ITest2 {public void Yürüt (string s) {Console.WriteLine ("Temel.Yürüt() (\"{0}\") referanslý", s);}}
    class Türedi : Temel {public new void Yürüt (string s) {Console.WriteLine ("Türedi.Yürüt (\"{0}\") belirteçli", s);}}
    interface Alýcý {int VeriyiAl();}
    interface Koyucu {void VeriyiKoy (int x);}
    interface AlýcýKoyucu : Alýcý, Koyucu{}
    class Veri : AlýcýKoyucu {
        int veri;
        public int VeriyiAl() {return veri;}
        public void VeriyiKoy (int x) {veri = x;}
    }
    public interface ArayüzA {void Metot1(); void Metot2();}
    public interface ArayüzB : ArayüzA {void Metot3();}
    public interface ArayüzC : ArayüzB  {void Metot4(); void Metot5();}
    class Sýnýf : ArayüzC {
        public void Metot1() {Console.WriteLine ("Sýnýf.Metot1() yürütülüyor.");}
        public void Metot2() {Console.WriteLine ("Sýnýf.Metot2() yürütülüyor.");}
        public void Metot3() {Console.WriteLine ("Sýnýf.Metot3() yürütülüyor.");}
        public void Metot4() {Console.WriteLine ("Sýnýf.Metot4() yürütülüyor.");}
        public void Metot5() {Console.WriteLine ("Sýnýf.Metot5() yürütülüyor.");}
    }
    public interface IÞifreliVeri {void Þifrele();}
    public class ÞifreKontrol {public void Þifrele() {Console.WriteLine ("\tÞifreKontrol.Þifrele() çaðrýldý.");}}
    public class Düzenle : ÞifreKontrol, IÞifreliVeri{}
    class Arayüz2 {
        static void Main() {
            Console.Write ("Çoklu arayüz türedisi tiplendikten sonra ((IArayüz1)türedTipleme).Metot()/Özellik kestirmeyle tüm farklý arayüz þablonlu gövdeli üyelerine eriþilebilmektedir. Arayüzler de diðer arayüzleri çoklu miraslayabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Radyonun tüm aktüel ayarlarýný atama ve alma:");
            var r=new Random(); Radyo ayar = new Radyo();
            int ts1=r.Next(0, 101), i; ((ISesHacmi)ayar).Derecesi = ts1; Console.WriteLine ("Þuanki ses hacmi = % {0}", ((ISesHacmi)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesHýzý)ayar).Derecesi = ts1; Console.WriteLine ("Þuanki ses hýzý = % {0}", ((ISesHýzý)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesTizliði)ayar).Derecesi = ts1; Console.WriteLine ("Þuanki ses tizliði = % {0}", ((ISesTizliði)ayar).Derecesi);
            ts1=r.Next(0, 101); ((ISesKontrastý)ayar).Derecesi = ts1; Console.WriteLine ("Þuanki ses kontrastý = % {0}", ((ISesKontrastý)ayar).Derecesi);

            Console.WriteLine ("\nÇoklu arayüzlü türedinin ayný ve farklý Metotlarý yürütmesi:");
            Döküman dkmn = new Döküman ("Test Dökümaný");
            dkmn.Yaz(); dkmn.Konuþ(); dkmn.Dinle(); dkmn.Ýzle(); 
            ((IDeðiþtirilebilir)dkmn).Oku ("IDeðiþtirilebilir"); ((IKonuþulabilir)dkmn).Oku ("IKonuþulabilir"); ((IDinlenebilir)dkmn).Oku ("IDinlenebilir"); ((IÝzlenebilir)dkmn).Oku ("IÝzlenebilir");

            Console.WriteLine ("\nHiyerarþik arayüz, temel, türedi Metotlarýn referanslý yürütülmesi:");
            Türedi tür = new Türedi();
            tür.Yürüt ("new");
            ((Temel)tür).Yürüt ("Temel");
            ((ITest2)tür).Yürüt ("ITest2");
            ((ITest1)tür).Yürüt ("ITest1");

            Console.WriteLine ("\nÇoklu arayüzler miraslayarak veri konulmasý ve alýnmasý:");
            Veri veri;
            for(i=1;i<=5;i++) {
                ts1=r.Next(-1000, 1000);
                veri = new Veri();
                veri.VeriyiKoy (ts1);
                Console.WriteLine ("{0}.veri = {1}",  i, veri.VeriyiAl());
            }

            Console.WriteLine ("\n3 arayüzün 5 þablon metotlarýnýn miraslanýp yürütülmesi:");
            Sýnýf nesne = new Sýnýf();
            nesne.Metot1(); nesne.Metot2(); nesne.Metot3(); nesne.Metot4(); nesne.Metot5();

            Console.WriteLine ("\nMiraslananlarýn farklý iþlevselliklerinin kontrolu:");
            Düzenle düzelt1 = new Düzenle();
            IÞifreliVeri þifrele1 = düzelt1 as IÞifreliVeri;
            if (þifrele1 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele1.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}
            Düzenle düzelt2 = new Düzenle();
            IÞifreliVeri þifrele2 = (IÞifreliVeri)düzelt2;
            if (þifrele2 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele2.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}
            Düzenle düzelt3 = new Düzenle();
            IÞifreliVeri þifrele3 = düzelt3;
            if (þifrele3 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele3.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}
            IÞifreliVeri þifrele4 = new Düzenle();
            if (þifrele4 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele4.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}
            Düzenle þifrele5 = new Düzenle();
            if (þifrele5 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele5.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}
            ÞifreKontrol þifrele6 = new Düzenle();
            if (þifrele6 != null) {Console.WriteLine ("IÞifreliVeri desteklenmektedir..."); þifrele6.Þifrele();
            } else {Console.WriteLine ("IÞifreliVeri desteklenmeMEktedir...");}


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}