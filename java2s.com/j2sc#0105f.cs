// j2sc#0105f.cs: ��i�e aduzam s�n�f tiplemeleri �rne�i.

using System;
namespace D��Aduzam {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�1: {0}", --saya�);}
    }
    namespace ��Aduzam {
        class Sayac�m {
            private int saya� = 2023;
            public void Saya�() {Console.WriteLine ("Saya�2: {0}", ++saya�);}
        }
    }
}
namespace DilTemelleri {
    class Aduzam6 {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
        static void Main() {
            Console.Write ("��i�e aduzam s�n�f tiplemesi yap�l�rken aduzamlar aras�ndaki noktalama unutulmamal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new D��Aduzam.Sayac�m();
            var say2 = new D��Aduzam.��Aduzam.Sayac�m();
            var say3 = new DilTemelleri.Aduzam6();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}