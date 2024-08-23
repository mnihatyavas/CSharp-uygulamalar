// j2sc#1901c.cs: ConstructorInfo ve ParameterInfo ile parametreli kurucu �rne�i.

using System;
using System.Reflection; //ConstructorInfo, ParameterInfo i�in
using System.Security; //SecurityException i�in
namespace TipBilgileri {
    class S�n�fA { 
        public S�n�fA (int i) {Console.WriteLine ("S�n�fA(int) kuruluyor.");} //Kurucu-1
        public S�n�fA (int i, int j) {Console.WriteLine ("S�n�fA(int,int) kuruluyor.");}  //Kurucu-2
        public S�n�fA (int i, int j, int k) {Console.WriteLine ("S�n�fA(int,int,int) kuruluyor.");}  //Kurucu-3
        /* Di�er kodlamalar */
    }
    class S�n�fB {
        /* private string strAlan;
        public string StrAlan {get {return strAlan;} set {strAlan = value;}}
        DateTime[] tarihler = new DateTime [10];
        public DateTime this [int endeks] {get {return tarihler [endeks];} set {tarihler [endeks] = value;}}
        private DateTime do�umTarihi;
        public DateTime Do�umTarihi {get {return do�umTarihi;} set {do�umTarihi = value;}} */
        public void Metot1() {Console.WriteLine ("S�n�fB-->Metot1() �a�r�ld�");}
        public void Metot2() {Console.WriteLine ("S�n�fB-->Metot2() �a�r�ld�");}
        public void Metot3() {Console.WriteLine ("S�n�fB-->Metot3() �a�r�ld�");}
    }
    abstract public class Soyut {
        protected string Ad, Soyad;
        public Soyut (string a, string s) {Ad = a; Soyad = s;} //Kurucu
        abstract public string Tamad�Al();
    }
    public class Ki�i: Soyut {
        public Ki�i (string Ad, string Soyad): base (Ad, Soyad) {} //Kurucu Soyut'tan
        public override string Tamad�Al() {return Ad+" "+Soyad;}
    }
    class Kurucu {
        public Kurucu (int i, string s, double d, bool b){} //�oklu parametreli Kurucu
        static void Main() {
            Console.Write ("typeof(S�n�fA).GetConstructors(), typeof(S�n�fA).GetConstructor() S�n�fA'n�n tan�ml� kurucu-lar�n�, ConstructorInfo.GetParameters() ise akt�el kurucunun parametrelerini verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�fA'n�n kurucular�n�n ad�, parametre tip ve ad sunumlar�:");
            int i;
            Type tip = typeof (S�n�fA);
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

            Console.WriteLine ("\nDizgeyi char kuruculu �oklu karakterler dizisinden yaratma:");
            ConstructorInfo kb = typeof (string).GetConstructor (new Type[] {typeof (char[])});
            string dizge = (string)kb.Invoke (new object[] {new char[] {'M', '.', 'N', 'i', 'h', 'a', 't', ' ', 'Y', 'a', 'v', 'a', '�', '\'', 't', 'a', 'n', ' ', 'S', 'e', 'l', 'a', 'm', 'l', 'a', 'r', '.'} });
            Console.WriteLine (dizge);

            Console.WriteLine ("\nS�n�fA'n�n mevcut t�m kurucular�n�n �a�r�lmas�:");
            Assembly asm = Assembly.LoadFrom ("j2sc#1901c.exe");
            Type[] tipler = asm.GetTypes();
            tip = tipler [0]; // Bulunan ilk S�n�fA
            Console.WriteLine (tip.Name + " tiplemesi kullan�larak:");
            ci = tip.GetConstructors();
            for(i=0;i<ci.Length;i++) {
                pi = ci [i].GetParameters();
                if (pi.Length > 0) {
                    object[] krcArg = new object [pi.Length];
                    //for(j=0;j<pi.Length;j++) krcArg [j] = i + j * 5; //Arg�manlara ilkde�er atama
                    ci [i].Invoke (krcArg); //Mevcut kurucular �a�r�l�r
                } else ci [i].Invoke (null); //Parametresiz kurucu �a�r�s�
            }

            Console.WriteLine ("\n3 ayr� y�ntemle S�n�fB tiplemesi yarat�p 3 ayr� metodunun �a�r�lmas�:");
            tip = typeof (S�n�fB); //tip = Type.GetType ("S�n�fB");
            object ns = Activator.CreateInstance (tip); //tiplemeli nesne
            tip.InvokeMember ("Metot1", BindingFlags.InvokeMethod, null, ns, new object[]{});
            kb = tip.GetConstructor (new Type[]{});
            ns = kb.Invoke (new object[]{}); //Kuruculu nesne
            tip.InvokeMember ("Metot2", BindingFlags.InvokeMethod, null, ns, new object[]{});
            ns = tip.InvokeMember ("S�n�fB", BindingFlags.CreateInstance, null, null, new object[]{}); //InvokeMember'l� nesne
            tip.InvokeMember ("Metot3", BindingFlags.InvokeMethod, null, ns, new object[]{});

            Console.WriteLine ("\n�ablon Soyut'un kurucusu ve Ki�i'nin Tamad�Al() metoduyla ad+soyad sunumu:");
            Ki�i ki�i = new Ki�i ("M.Nihat", "Yava�"); Console.WriteLine (ki�i.Tamad�Al());
            ki�i = new Ki�i ("H�seyin", "Kurt"); Console.WriteLine (ki�i.Tamad�Al());
            ki�i = new Ki�i ("Fatih", "Kaplan"); Console.WriteLine (ki�i.Tamad�Al());
            ki�i = new Ki�i ("Selim", "Dikel"); Console.WriteLine (ki�i.Tamad�Al());
            ki�i = new Ki�i ("Ali", "Eralp"); Console.WriteLine (ki�i.Tamad�Al());

            Console.WriteLine ("\n�oklu kurucu parametre Main() metodlu esas s�n�f�n kurucu bilgileri:");
            try {tip = typeof (Kurucu);
                tipler = new Type [4];
                tipler [0] = typeof (int); tipler [1] = typeof (string); tipler [2] = typeof (double); tipler [3] = typeof (bool);//(int byte, short) kabul, di�er tipler red
                kb = tip.GetConstructor (BindingFlags.Instance | BindingFlags.Public, null, tipler, null);
                Console.WriteLine (kb);
            }catch (ArgumentNullException ht) {Console.WriteLine ("HATA(ArgumentNullException): [{0}]", ht.Message);
            }catch (ArgumentException ht) {Console.WriteLine ("HATA(ArgumentException): [{0}]", ht.Message);
            }catch (SecurityException ht) {Console.WriteLine ("HATA(SecurityException): [{0}]", ht.Message);
            }catch (Exception ht) {Console.WriteLine ("HATA(Exception): [{0}]", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}