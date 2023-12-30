// j2sc#1002.cs: �zel vas�f s�n�flar�n�n alan de�erlerinin yaz�lmas�/okunmas� �rne�i.

using System;
namespace Vas�flar {
    [AttributeUsage (AttributeTargets.All)]
    public class Vas�fA : Attribute {
        public string fikir, ilaveFikir;
        public Vas�fA (string yorum) {fikir = yorum; ilaveFikir = "";} //Kurucu
    }
    [AttributeUsage (AttributeTargets.All)]
    public class Vas�fB : Attribute {
        private string fikir;
        public string ilaveFikir;
        public Vas�fB (string yorum) {fikir = yorum; ilaveFikir = "";} //Kurucu
        public string Fikir {get {return fikir;}}
    }
    [Vas�fB ("Bu a��klama, bir konumsal parametre olan 'fikir' i�indir.", ilaveFikir = "Bu ilave yorum, bir adl� parametredir.")]
    class Vas�fBKullan {}
    [AttributeUsage (AttributeTargets.All)]
    public class Vas�fC : Attribute {
        private string fikir;
        public string ilaveFikir;
        public int �ncelik;
        public Vas�fC (string yorum) {fikir = yorum; ilaveFikir = ""; �ncelik=0;} //Kurucu
        public string Fikir {get {return fikir;}}
        public int �ncelik {get {return �ncelik;} set {�ncelik = value;}}
    }
    [Vas�fC ("Bu a��klama, bir konumsal parametre olan 'fikir' i�indir.", ilaveFikir = "Bu ilave yorum, bir adl� parametredir.", �ncelik = 10)]
    class Vas�fCKullan {}
    //[assembly:System.CLSCompliantAttribute (true)]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class BeyanVasf� : Attribute {
        private string beyan;
        public string beyan2, beyan3;
        public string Beyan {get {return beyan;} set {beyan = value;}} //�zellik
        public BeyanVasf�() {} //Kurucu-1
        public BeyanVasf� (string b) {beyan = b;} //Kurucu-1
    }
    [BeyanVasf� ("Konumsal beyan bilgisi-1", beyan2="�lk adl� beyan-1", beyan3="�kinci adl� beyan-1")] //Konumsal ve 2 adl� parametreli �zel vas�f
    [BeyanVasf� ("Konumsal beyan bilgisi-2", beyan2="�lk adl� beyan-2", beyan3="�kinci adl� beyan-2")] //AllowMultiple=true ile �oklu sat�r m�mk�n
    [BeyanVasf� ("Konumsal beyan bilgisi-3", beyan2="�lk adl� beyan-3", beyan3="�kinci adl� beyan-3")]
    public class BeyanVasf�Kullan {
        public BeyanVasf�Kullan(){} //Kurucu
    }
    public class Do�ruYanl��Vasf� : Attribute {
        bool boolDe�er;
        public bool Bool() {return boolDe�er;}
        public Do�ruYanl��Vasf� (bool b) {boolDe�er = b;}
    }
    [Do�ruYanl��Vasf� (true)]
    public class S�n�f1{}
    [Do�ruYanl��Vasf� (false)]
    public class S�n�f2{}

    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class Programc�Vasf� : System.Attribute {
        public string �sim, Meslek, �kamet;
        public Programc�Vasf� (string ad) {�sim = ad; Meslek = �kamet = "";} //Kurucu
    }
    [Programc�Vasf� ("M.Nihat Yava�")]
    [Programc�Vasf� ("Zafer N.Candan", Meslek = "Genetik M�hendisi")]
    [Programc�Vasf� ("Fatih �zbay", Meslek = "Assubay", �kamet = "�zmir")]
    [Programc�Vasf� ("Hilal G�kt�rk", Meslek = "Doktor", �kamet = "Malatya")]

    class Vas�f2 {
        static void Main() {
            Console.Write ("�zel vas�f s�n�f�n�n alan verileri kodlamayla [...] i�inde, yada vas�f tiplemesine veriler girilerek atanabilir. �zel vas�f s�n�f�n�n ilk alan� 'konumsal parametre', sonrakiler ise 'adl� parametre'dir. Vas�f kodlamas� ya '[AttributeUsage(...)]' yada Sistem.Attribute mirasl� '[�zelVas�fS�n�f�(...)]' olarak yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Vas�f tipleme alanlar�na de�er giri�leri:");
            Vas�fA va;
            va=new Vas�fA ("�lk yorum"); Console.WriteLine ("Yorum: {0};\t�lave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new Vas�fA ("�kinci yorum"); va.ilaveFikir="Var"; Console.WriteLine ("Yorum: {0};\t�lave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new Vas�fA ("���nc� yorum"); va.ilaveFikir="Yok"; Console.WriteLine ("Yorum: {0};\t�lave yorum: {1}", va.fikir, va.ilaveFikir);
            va=new Vas�fA ("D�rd�nc� yorum"); va.ilaveFikir="�ok"; Console.WriteLine ("Yorum: {0};\t�lave yorum: {1}", va.fikir, va.ilaveFikir);

            Console.WriteLine ("\nProgram i�indeki mevcut [...] i�i �zel vas�f de�erleri okunabilir:");
            Type tip = typeof (Vas�f2);
            object[] vas�flar = tip.GetCustomAttributes (typeof (Programc�Vasf�), true);
            foreach (Programc�Vasf� vas�f in vas�flar) {Console.WriteLine (vas�f.�sim + ", " + vas�f.Meslek + ", " + vas�f.�kamet);}

            Console.WriteLine ("\n�zel Vas�fB alanlar�n�n [...] verilerine eri�im:");
            Type tip2 = typeof (Vas�fBKullan);
            Console.Write (tip2.Name + " i�indeki vas�flar: ");
            object[] vas�flar2 = tip2.GetCustomAttributes (false);
            foreach (object ns in vas�flar2) {Console.WriteLine (ns);}
            // Vas�fB verileri
            Type tipB = typeof (Vas�fB);
            Vas�fB vb = (Vas�fB) Attribute.GetCustomAttribute (tip2, tipB);
            Console.Write ("Fikir: "); Console.WriteLine (vb.Fikir);
            Console.Write ("ilaveFikir: "); Console.WriteLine (vb.ilaveFikir);

            Console.WriteLine ("\n�zel Vas�fC alanlar�n�n [...] verilerine eri�im:");
            Type tip3 = typeof (Vas�fCKullan);
            Console.Write (tip3.Name + " i�indeki vas�flar: ");
            object[] vas�flar3 = tip3.GetCustomAttributes (false);
            foreach (object ns in vas�flar3) {Console.WriteLine (ns);}
            // Vas�fC verileri
            Type tipC = typeof (Vas�fC);
            Vas�fC vc = (Vas�fC) Attribute.GetCustomAttribute (tip3, tipC);
            Console.Write ("Fikir: "); Console.WriteLine (vc.Fikir);
            Console.Write ("ilaveFikir: "); Console.WriteLine (vc.ilaveFikir);
            Console.Write ("�ncelik: "); Console.WriteLine (vc.�ncelik);

            Console.WriteLine ("\nBeyanVasf�'n�n kodlanm�� �oklu de�erlerinin d�k�mlenmesi:");
            Type tip4 = typeof (BeyanVasf�Kullan);
            object[] vas�flar4 = tip4.GetCustomAttributes (false); //Hemen �st�ndeki vasf�n mevcut de�erlerini okur
            Console.WriteLine ("BeyanVasf�'n�n de�erlerii:");
            foreach (BeyanVasf� bv in vas�flar4) Console.WriteLine ("==>(\"{0}\", \"{1}\", \"{2})\"", bv.Beyan, bv.beyan2, bv.beyan3);

            Console.WriteLine ("\n�kili Do�ruYanl��Vasf�'n�n tikel true ve false de�er okunmas�:");
            Do�ruYanl��Vasf� dyv;
            Console.Write ("S�n�f1 Do�ruYanl��Vasf� vasf�: ");
            dyv = (Do�ruYanl��Vasf�) Attribute.GetCustomAttribute (typeof (S�n�f1), typeof (Do�ruYanl��Vasf�));
            Console.WriteLine (dyv.Bool());
            Console.Write ("S�n�f2 Do�ruYanl��Vasf� vasf�: ");
            dyv = (Do�ruYanl��Vasf�) Attribute.GetCustomAttribute (typeof (S�n�f2), typeof (Do�ruYanl��Vasf�));
            Console.WriteLine (dyv.Bool());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}