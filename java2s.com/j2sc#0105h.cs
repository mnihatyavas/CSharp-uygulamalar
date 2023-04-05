// j2sc#0105h.cs: ��i�e armal� aduzamlar� tiplemesi �rne�i.

using System;
using S1 = Saya�1;
using S2 = Saya�1.Saya�2;
using S3 = Saya�1.Saya�2.Saya�3;
namespace Saya�1 {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�1: {0}", --saya�);}
    }
    namespace Saya�2 {
        class Sayac�m {
            private int saya� = 2023;
            public void Saya�() {Console.WriteLine ("Saya�2: {0}", ++saya�);}
        }
        namespace Saya�3 {
            class Sayac�m {
                private int saya� = 1957;
                public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
            }
        }

    }
}
namespace DilTemelleri {
    class Aduzam8 {
        static void Main() {
            Console.Write ("��i�e armal� aduzam tipmemesinde hiyerar�i dikkatle takip edilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new S1::Sayac�m();
            var say2 = new S2::Sayac�m();
            var say3 = new S3::Sayac�m();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}