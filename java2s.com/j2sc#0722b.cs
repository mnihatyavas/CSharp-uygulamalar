// j2sc#0722b.cs: Kýsmi sýnýflar ve temel-türedi esgeçen metotlar örneði.

using System;
//using System.ComponentModel;
namespace Sýnýflar {
    partial class XYZ {
        int x;
        public int X {get {return x;} set {x = value;}}
    }
    partial class XYZ {
        int y;
        public int Y {get {return y;} set {y = value;}}
    }
    partial class XYZ {
        int z;
        public int Z {get {return z;} set {z = value;}}
    }
    public partial class SýnýfA {public void ÝlkMetod() {Console.WriteLine ("SýnýfA.ÝlkMetod()");}}
    public partial class SýnýfA {public void ÝkinciMetod() {Console.WriteLine ("SýnýfA.ÝkinciMetod()");}}
    public partial class SýnýfA {public void ÜçüncüMetod() {Console.WriteLine ("SýnýfA.ÜçüncüMetod()");}}
    partial class SýnýfB<TÝlk, TÝkinci>: IEquatable<string>where TÝlk : class {
        public bool Equals (string diðer) {return false;}
    }
    interface Yazýlabilir {string Yazdýr();}
    class YazýlamazSayfa {
        int sayý;
        public YazýlamazSayfa (int sayý) {this.sayý = sayý;} //Kurucu
        public override string ToString() {return((sayý+" tarihli yazýlamaz sayfa...").ToString());}
    }
    class YazýlabilirSayfa: Yazýlabilir {
        string isim;
        public YazýlabilirSayfa (string isim) {this.isim = isim;} //Kurucu
        public override string ToString() {return(isim);}
        string Yazýlabilir.Yazdýr() {return(isim+" yazýyor...");}
    }
    public class Temel {public virtual void konuþ() {Console.WriteLine ("Sanal Temel.konuþ() konuþuyor...");}}
    public class Türedi: Temel {public override void konuþ() {Console.WriteLine ("Esgeçen Türedi.konuþ() konuþuyor...");}}
    class Çeþitli2 {
        public static void YazdýrmayýDene (params object[] dizi) {
            foreach (object nes in dizi) {
                Yazýlabilir yaznes = nes as Yazýlabilir;
                if (yaznes != null) Console.WriteLine ("{0}", yaznes.Yazdýr());
                else Console.WriteLine ("{0}", nes+": null nesne");
            }
        }
        static void Main() {
            Console.Write ("Herbirinde farklý üyeler bulunan ayný adlý 'partial' sýnýflar tiplemeyle tüm üyeleri tek sýnýfmýþca kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayný adlý 3 partial/kýsmi sýnýf üyelerine deðer koy/al:");
            var r=new Random(); int ts1, i;
            XYZ xyz = new XYZ(); Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", xyz.X, xyz.Y, xyz.Z);
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); xyz.X=ts1;
                ts1=r.Next(-100,100); xyz.Y=ts1;
                ts1=r.Next(-100,100); xyz.Z=ts1;
                Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", xyz.X, xyz.Y, xyz.Z);
            }

            Console.WriteLine ("\nAyný adlý 3 kýsmi sýnýfýn farklý adlý metotlarýnýn çaðrýlmasý:");
            SýnýfA nesne = new SýnýfA();
            nesne.ÝlkMetod();
            nesne.ÝkinciMetod();
            nesne.ÜçüncüMetod();

            Console.WriteLine ("\nNormal Equals ve kýsmi sýnýflý Equals'la eþitlik kontrolleri:");
            string dizge1 = "Merhaba"; string dizge2 = "Selam";
            Console.WriteLine ("\"Merhaba\" == \"Selam\": {0}", dizge1.Equals (dizge2) );
            Console.WriteLine ("\"Merhaba\" == \"Merhaba\": {0}", dizge1.Equals ("Merhaba") );
            SýnýfB<string,string> b=new SýnýfB<string,string>();
            Console.WriteLine ("SýnýfB<string,string> b=new SýnýfB<string,string>() == \"Merhaba\": {0}", b.Equals (dizge2) );
            Console.WriteLine ("b == b: {0}", b.Equals (b) );
            Console.WriteLine ("b == new SýnýfB<string,string>(): {0}", b.Equals (new SýnýfB<string,string>()) );
            Console.WriteLine ("b == new XYZ(): {0}", b.Equals (new XYZ()) );

            Console.WriteLine ("\nArayüz þablonlu yazýlamaz ve yazýlabilir nesnelerin sayfalarý:");
            YazýlamazSayfa s1 = new YazýlamazSayfa (20231107);
            YazýlabilirSayfa s2 = new YazýlabilirSayfa ("M.Nihat Yavaþ");
            YazýlamazSayfa s3 = new YazýlamazSayfa (19381110);
            YazýlabilirSayfa s4 = new YazýlabilirSayfa ("Zafer N.Candan");
            YazdýrmayýDene (s1, s2, s3, s4, null);

            Console.WriteLine ("\nTemel sanal metotun türedi esgeçenle yerine geçmesi:");
            Türedi trd = new Türedi(); trd.konuþ();
            Temel tml = trd; tml.konuþ();
            Türedi trd2 = (Türedi) tml; trd2.konuþ();
            object nesne2 = trd; Türedi trd3 = (Türedi)nesne2; trd3.konuþ();
            ((Temel)trd).konuþ();
            new Temel().konuþ();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}