// j2sc#1002.cs: Özel vasıf sınıflarının alan değerlerinin yazılması/okunması örneği.

using System;
namespace Vasıflar {
    [AttributeUsage (AttributeTargets.All)]
    public class VasıfA : Attribute {
        public string fikir, ilaveFikir;
        public VasıfA (string yorum) {fikir = yorum; ilaveFikir = "";} //Kurucu
    }
    [AttributeUsage (AttributeTargets.All)]
    public class VasıfB : Attribute {
        private string fikir;
        public string ilaveFikir;
        public VasıfB (string yorum) {fikir = yorum; ilaveFikir = "";} //Kurucu
        public string Fikir {get {return fikir;}}
    }
    [VasıfB ("Bu açıklama, bir konumsal parametre olan 'fikir' içindir.", ilaveFikir = "Bu ilave yorum, bir adlı parametredir.")]
    class VasıfBKullan {}
    [AttributeUsage (AttributeTargets.All)]
    public class VasıfC : Attribute {
        private string fikir;
        public string ilaveFikir;
        public int öncelik;
        public VasıfC (string yorum) {fikir = yorum; ilaveFikir = ""; öncelik=0;} //Kurucu
        public string Fikir {get {return fikir;}}
        public int Öncelik {get {return öncelik;} set {öncelik = value;}}
    }
    [VasıfC ("Bu açıklama, bir konumsal parametre olan 'fikir' içindir.", ilaveFikir = "Bu ilave yorum, bir adlı parametredir.", Öncelik = 10)]
    class VasıfCKullan {}
    //[assembly:System.CLSCompliantAttribute (true)]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class BeyanVasfı : Attribute {
        private string beyan;
        public string beyan2, beyan3;
        public string Beyan {get {return beyan;} set {beyan = value;}} //Özellik
        public BeyanVasfı() {} //Kurucu-1
        public BeyanVasfı (string b) {beyan = b;} //Kurucu-1
    }
    [BeyanVasfı ("Konumsal beyan bilgisi-1", beyan2="İlk adlı beyan-1", beyan3="İkinci adlı beyan-1")] //Konumsal ve 2 adlı parametreli özel vasıf
    [BeyanVasfı ("Konumsal beyan bilgisi-2", beyan2="İlk adlı beyan-2", beyan3="İkinci adlı beyan-2")] //AllowMultiple=true ile çoklu satır mümkün
    [BeyanVasfı ("Konumsal beyan bilgisi-3", beyan2="İlk adlı beyan-3", beyan3="İkinci adlı beyan-3")]
    public class BeyanVasfıKullan {
        public BeyanVasfıKullan(){} //Kurucu
    }
    public class DoğruYanlışVasfı : Attribute {
        bool boolDeğer;
        public bool Bool() {return boolDeğer;}
        public DoğruYanlışVasfı (bool b) {boolDeğer = b;}
    }
    [DoğruYanlışVasfı (true)]
    public class Sınıf1{}
    [DoğruYanlışVasfı (false)]
    public class Sınıf2{}

    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class ProgramcıVasfı : System.Attribute {
        public string İsim, Meslek, İkamet;
        public ProgramcıVasfı (string ad) {İsim = ad; Meslek = İkamet = "";} //Kurucu
    }
    [ProgramcıVasfı ("M.Nihat Yavaş")]
    [ProgramcıVasfı ("Zafer N.Candan", Meslek = "Genetik Mühendisi")]
    [ProgramcıVasfı ("Fatih Özbay", Meslek = "Assubay", İkamet = "İzmir")]
    [ProgramcıVasfı ("Hilal Göktürk", Meslek = "Doktor", İkamet = "Malatya")]

    class Vasıf2 {
        static void Main() {
            Console.Write ("Özel vasıf sınıfının alan verileri kodlamayla [...] içinde, yada vasıf tiplemesine veriler girilerek atanabilir. Özel vasıf sınıfının ilk alanı 'konumsal parametre', sonrakiler ise 'adlı parametre'dir. Vasıf kodlaması ya '[AttributeUsage(...)]' yada Sistem.Attribute miraslı '[ÖzelVasıfSınıfı(...)]' olarak yapılabilir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Vasıf tipleme alanlarına değer girişleri:");
            VasıfA va;
            va=new VasıfA ("İlk yorum"); Console.WriteLine ("Yorum: {0};\tİlave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new VasıfA ("İkinci yorum"); va.ilaveFikir="Var"; Console.WriteLine ("Yorum: {0};\tİlave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new VasıfA ("Üçüncü yorum"); va.ilaveFikir="Yok"; Console.WriteLine ("Yorum: {0};\tİlave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new VasıfA ("Dördüncü yorum"); va.ilaveFikir="Çok"; Console.WriteLine ("Yorum: {0};\tİlave yorum: {1}", va.fikir, va.ilaveFikir);

            Console.WriteLine ("\nProgram içindeki mevcut [...] içi özel vasıf değerleri okunabilir:");
            Type tip = typeof (Vasıf2);
            object[] vasıflar = tip.GetCustomAttributes (typeof (ProgramcıVasfı), true);
            foreach (ProgramcıVasfı vasıf in vasıflar) {Console.WriteLine (vasıf.İsim + ", " + vasıf.Meslek + ", " + vasıf.İkamet);}

            Console.WriteLine ("\nÖzel VasıfB alanlarının [...] verilerine erişim:");
            Type tip2 = typeof (VasıfBKullan);
            Console.Write (tip2.Name + " içindeki vasıflar: ");
            object[] vasıflar2 = tip2.GetCustomAttributes (false);
            foreach (object ns in vasıflar2) {Console.WriteLine (ns);}
            // VasıfB verileri
            Type tipB = typeof (VasıfB);
            VasıfB vb = (VasıfB) Attribute.GetCustomAttribute (tip2, tipB);
            Console.Write ("Fikir: "); Console.WriteLine (vb.Fikir);
            Console.Write ("ilaveFikir: "); Console.WriteLine (vb.ilaveFikir);

            Console.WriteLine ("\nÖzel VasıfC alanlarının [...] verilerine erişim:");
            Type tip3 = typeof (VasıfCKullan);
            Console.Write (tip3.Name + " içindeki vasıflar: ");
            object[] vasıflar3 = tip3.GetCustomAttributes (false);
            foreach (object ns in vasıflar3) {Console.WriteLine (ns);}
            // VasıfC verileri
            Type tipC = typeof (VasıfC);
            VasıfC vc = (VasıfC) Attribute.GetCustomAttribute (tip3, tipC);
            Console.Write ("Fikir: "); Console.WriteLine (vc.Fikir);
            Console.Write ("ilaveFikir: "); Console.WriteLine (vc.ilaveFikir);
            Console.Write ("Öncelik: "); Console.WriteLine (vc.Öncelik);

            Console.WriteLine ("\nBeyanVasfı'nın kodlanmış çoklu değerlerinin dökümlenmesi:");
            Type tip4 = typeof (BeyanVasfıKullan);
            object[] vasıflar4 = tip4.GetCustomAttributes (false); //Hemen üstündeki vasfın mevcut değerlerini okur
            Console.WriteLine ("BeyanVasfı'nın değerlerii:");
            foreach (BeyanVasfı bv in vasıflar4) Console.WriteLine ("==>(\"{0}\", \"{1}\", \"{2})\"", bv.Beyan, bv.beyan2, bv.beyan3);

            Console.WriteLine ("\nİkili DoğruYanlışVasfı'nın tikel true ve false değer okunması:");
            DoğruYanlışVasfı dyv;
            Console.Write ("Sınıf1 DoğruYanlışVasfı vasfı: ");
            dyv = (DoğruYanlışVasfı) Attribute.GetCustomAttribute (typeof (Sınıf1), typeof (DoğruYanlışVasfı));
            Console.WriteLine (dyv.Bool());
            Console.Write ("Sınıf2 DoğruYanlışVasfı vasfı: ");
            dyv = (DoğruYanlışVasfı) Attribute.GetCustomAttribute (typeof (Sınıf2), typeof (DoğruYanlışVasfı));
            Console.WriteLine (dyv.Bool());

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}