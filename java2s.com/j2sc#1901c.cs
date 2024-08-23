// j2sc#1901c.cs: ConstructorInfo ve ParameterInfo ile parametreli kurucu örneði.

using System;
using System.Reflection; //ConstructorInfo, ParameterInfo için
using System.Security; //SecurityException için
namespace TipBilgileri {
    class SýnýfA { 
        public SýnýfA (int i) {Console.WriteLine ("SýnýfA(int) kuruluyor.");} //Kurucu-1
        public SýnýfA (int i, int j) {Console.WriteLine ("SýnýfA(int,int) kuruluyor.");}  //Kurucu-2
        public SýnýfA (int i, int j, int k) {Console.WriteLine ("SýnýfA(int,int,int) kuruluyor.");}  //Kurucu-3
        /* Diðer kodlamalar */
    }
    class SýnýfB {
        /* private string strAlan;
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        DateTime[] tarihler = new DateTime [10];
        public DateTime this [int endeks] {get {return tarihler [endeks];} set {tarihler [endeks] = value;}}
        private DateTime doðumTarihi;
        public DateTime DoðumTarihi {get {return doðumTarihi;} set {doðumTarihi = value;}} */
        public void Metot1() {Console.WriteLine ("SýnýfB-->Metot1() çaðrýldý");}
        public void Metot2() {Console.WriteLine ("SýnýfB-->Metot2() çaðrýldý");}
        public void Metot3() {Console.WriteLine ("SýnýfB-->Metot3() çaðrýldý");}
    }
    abstract public class Soyut {
        protected string Ad, Soyad;
        public Soyut (string a, string s) {Ad = a; Soyad = s;} //Kurucu
        abstract public string TamadýAl();
    }
    public class Kiþi: Soyut {
        public Kiþi (string Ad, string Soyad): base (Ad, Soyad) {} //Kurucu Soyut'tan
        public override string TamadýAl() {return Ad+" "+Soyad;}
    }
    class Kurucu {
        public Kurucu (int i, string s, double d, bool b){} //Çoklu parametreli Kurucu
        static void Main() {
            Console.Write ("typeof(SýnýfA).GetConstructors(), typeof(SýnýfA).GetConstructor() SýnýfA'nýn tanýmlý kurucu-larýný, ConstructorInfo.GetParameters() ise aktüel kurucunun parametrelerini verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("SýnýfA'nýn kurucularýnýn adý, parametre tip ve ad sunumlarý:");
            int i;
            Type tip = typeof (SýnýfA);
            ConstructorInfo[] ci = tip.GetConstructors();
            ParameterInfo[] pi;
            foreach (ConstructorInfo k in ci) {
                Console.Write (tip.Name + " (");
                pi = k.GetParameters();
                for(i=0; i < pi.Length; i++) {
                    Console.Write (pi [i].ParameterType.Name + " " + pi [i].Name);
                    if (i+1 < pi.Length) Console.Write (", ");
                } Console.WriteLine (")");
            } Console.WriteLine();

            Console.WriteLine ("\nDizgeyi char kuruculu çoklu karakterler dizisinden yaratma:");
            ConstructorInfo kb = typeof (string).GetConstructor (new Type[] {typeof (char[])});
            string dizge = (string)kb.Invoke (new object[] {new char[] {'M', '.', 'N', 'i', 'h', 'a', 't', ' ', 'Y', 'a', 'v', 'a', 'þ', '\'', 't', 'a', 'n', ' ', 'S', 'e', 'l', 'a', 'm', 'l', 'a', 'r', '.'} });
            Console.WriteLine (dizge);

            Console.WriteLine ("\nSýnýfA'nýn mevcut tüm kurucularýnýn çaðrýlmasý:");
            Assembly asm = Assembly.LoadFrom ("j2sc#1901c.exe");
            Type[] tipler = asm.GetTypes();
            tip = tipler [0]; // Bulunan ilk SýnýfA
            Console.WriteLine (tip.Name + " tiplemesi kullanýlarak:");
            ci = tip.GetConstructors();
            for(i=0;i<ci.Length;i++) {
                pi = ci [i].GetParameters();
                if (pi.Length > 0) {
                    object[] krcArg = new object [pi.Length];
                    //for(j=0;j<pi.Length;j++) krcArg [j] = i + j * 5; //Argümanlara ilkdeðer atama
                    ci [i].Invoke (krcArg); //Mevcut kurucular çaðrýlýr
                } else ci [i].Invoke (null); //Parametresiz kurucu çaðrýsý
            }

            Console.WriteLine ("\n3 ayrý yöntemle SýnýfB tiplemesi yaratýp 3 ayrý metodunun çaðrýlmasý:");
            tip = typeof (SýnýfB); //tip = Type.GetType ("SýnýfB");
            object ns = Activator.CreateInstance (tip); //tiplemeli nesne
            tip.InvokeMember ("Metot1", BindingFlags.InvokeMethod, null, ns, new object[]{});
            kb = tip.GetConstructor (new Type[]{});
            ns = kb.Invoke (new object[]{}); //Kuruculu nesne
            tip.InvokeMember ("Metot2", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ns = tip.InvokeMember ("SýnýfB", BindingFlags.CreateInstance, null, null, new object[]{}); //InvokeMember'lý nesne
            tip.InvokeMember ("Metot3", BindingFlags.InvokeMethod, null, ns, new object[]{});

            Console.WriteLine ("\nÞablon Soyut'un kurucusu ve Kiþi'nin TamadýAl() metoduyla ad+soyad sunumu:");
            Kiþi kiþi = new Kiþi ("M.Nihat", "Yavaþ"); Console.WriteLine (kiþi.TamadýAl());
            kiþi = new Kiþi ("Hüseyin", "Kurt"); Console.WriteLine (kiþi.TamadýAl());
            kiþi = new Kiþi ("Fatih", "Kaplan"); Console.WriteLine (kiþi.TamadýAl());
            kiþi = new Kiþi ("Selim", "Dikel"); Console.WriteLine (kiþi.TamadýAl());
            kiþi = new Kiþi ("Ali", "Eralp"); Console.WriteLine (kiþi.TamadýAl());

            Console.WriteLine ("\nÇoklu kurucu parametre Main() metodlu esas sýnýfýn kurucu bilgileri:");
            try {tip = typeof (Kurucu);
                tipler = new Type [4];
                tipler [0] = typeof (int); tipler [1] = typeof (string); tipler [2] = typeof (double); tipler [3] = typeof (bool);//(int byte, short) kabul, diðer tipler red
                kb = tip.GetConstructor (BindingFlags.Instance | BindingFlags.Public, null, tipler, null);
                Console.WriteLine (kb);
            }catch (ArgumentNullException ht) {Console.WriteLine ("HATA(ArgumentNullException): [{0}]", ht.Message);
            }catch (ArgumentException ht) {Console.WriteLine ("HATA(ArgumentException): [{0}]", ht.Message);
            }catch (SecurityException ht) {Console.WriteLine ("HATA(SecurityException): [{0}]", ht.Message);
            }catch (Exception ht) {Console.WriteLine ("HATA(Exception): [{0}]", ht.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}