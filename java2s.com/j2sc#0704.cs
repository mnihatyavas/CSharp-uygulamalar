// j2sc#0704.cs: S�n�f metot �yelerinin parametreli/parametresiz �a�r�lmas� �rne�i.

using System;
namespace S�n�flar {
    class Hesapc� {public int Topla (int x, int y) {return x + y;} }
    class Nokta3B {
        int x, y, z;
        public Nokta3B (int a) {x = 2*a+45; y = 3*a-5; z = -4*a+82;} //Parametreli kurucu
        public int AlX() {return x;}
        public int AlY() {return y;}
        public int AlZ() {return z;}
    }
    class Bina {
        public int alan, mukimler;
        public int ki�iBa��Alan() {return alan / mukimler;}
    }
    class Daire {
        double y; // yar��ap
        public Daire (double y) {this.y=y;} //Kurucu
        public double Daire�evresi() {return 2 * Math.PI * y;}
        public double DaireAlan�() {return Math.PI * y * y;}
        public double DaireHacmi() {return 4 / 3 * Math.PI * y * y * y;}
        //public double K�reAlan�() {return ;}
        //public double K�reHacmi() {return ;}
    }
    public class Araba {
        string marka, model;
        public Araba (string marka, string model) {this.marka = marka; this.model = model;} //Kurucu
        public void G�ster() {Console.WriteLine ("Marka ve model: {0} - {1}", marka, model);}
        public static Araba Kopyala (Araba a) {return (Araba)a.MemberwiseClone();}
        public override bool Equals (object nsn) {//De�ersel e�itli�e �zeller
            Araba di�er = nsn as Araba;
            if (di�er == null) {return false;}
            return (this.marka == di�er.marka) && (this.model == di�er.model);
        }
        //public override int GetHashCode() {return (int)new Random().Next (0, 100000) ^ (int)new Random().Next (95800, 167830);} //Referanssal e�itli�e �zeller
    }
    class �yeMetod {
        static void MetodA (int p1, int p2) {
            Console.WriteLine ("MetodA'ya girdim: {0}, {1}", p1, p2);
            MetodB (new Random().Next (0, 3500), new Random().Next (-10000, 10000));
            Console.WriteLine ("MetodA'dan ��k�yorum");
        }
        static void MetodB (int p1, int p2) {
            Console.WriteLine ("MetodB'ye girdim: {0}, {1}", p1, p2);
            �yeMetod.MetodC (new Random().Next (0, 9000), new Random().Next (-1000, 1000));
            Console.WriteLine ("MetodB'den ��k�yorum");
        }
        static void MetodC (int p1, int p2) {
            Console.WriteLine ("MetodC'ye girdim: {0}, {1}", p1, p2);
            Console.WriteLine ("MetodC'den ��k�yorum");
        }
        static void Main() {
            Console.Write ("S�n�f�n metot �yesi eri�im/gerid�n��-tip, metot-ad� ve parametre listesinden olu�ur. Ayn� s�n�f i�i duruk/statik metot do�rudan yada tiplemesiz s�n�f-ad�yla �a�r�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f �ye metoduyla iki tamsay� toplam�n�n hesaplanmas�:");
            var r=new Random(); int ts1, ts2, i;
            Hesapc� hsp;
            for (i=0; i<5; i++) {
                ts1=r.Next (-3500, 3500); ts2=r.Next (-1150, 1150);
                hsp = new Hesapc�();
                Console.WriteLine ("ts1({0}) + ts2({1}) = {2}", ts1, ts2, hsp.Topla (ts1, ts2));
            }

            Console.WriteLine ("\nHesaplanarak kurucuyla konulan 3B nokta verilerinin al�nmas�:");
            Nokta3B n3B;
            for (i=0; i<5; i++) {
                ts1=r.Next (-100, 100);
                n3B = new Nokta3B (ts1);
                Console.WriteLine ("Nokta3B (x({0}), y, z) = ({1}, {2}, {3})", ts1, n3B.AlX(), n3B.AlY(), n3B.AlZ());
            }

            Console.WriteLine ("\nDo�rudan ve i�i�e �a�r�lan duruk/statik metotlar:");
            MetodA (new Random().Next (0, 4780), new Random().Next (-1155, 10000));
            �yeMetod.MetodA (new Random().Next (0, 5000), new Random().Next (-6000, 8000));

            Console.WriteLine ("\nEv ve ofiteki ki�iba�� alan�n metot'la hesaplanmas�:");
            Bina ev = new Bina();
            Bina ofis = new Bina();
            int kbAlan; // ki�i ba�� alan
            ev.mukimler = 11; ev.alan = 1200;
            ofis.mukimler = 125; ofis.alan = 4200;
            kbAlan = ev.ki�iBa��Alan();
            Console.WriteLine ("Ev {0} m2 ve {1} hanehalkl�k olup ki�iba�� alan {2} m2'dir.", ev.alan, ev.mukimler, kbAlan);
            kbAlan = ofis.ki�iBa��Alan();
            Console.WriteLine ("Ofis {0} m2 ve {1} elemanl�k olup ki�iba�� alan {2} m2'dir.", ofis.alan, ofis.mukimler, kbAlan);

            Console.WriteLine ("\nYar��ap� verilen dairenin �evre, alan ve hacmini hesaplayan metotlar:");
            Daire d1; double ds1;
            for (i=0; i<5; i++) {
                ds1=r.Next (0, 100)+r.Next (0, 1000)/10000D;
                d1 = new Daire (ds1);
                Console.WriteLine ("Yar��ap� = {0} olan dairenin (�evre, alan, hacim) =\n\t({1:#,#.#0}, {2:#,#.#0}, {3:#,#.#0}) birim2", ds1, d1.Daire�evresi(), d1.DaireAlan�(), d1.DaireHacmi());
            }

            Console.WriteLine ("\nFarkl� 2 araba, ayn�ya atama ve kopyalamayla de�er/referans e�itlik testi:");
            Console.WriteLine ("\tAraba nesneleri yarat�l�yor");
            Araba arabam1 = new Araba ("Toyota", "MR2"); Araba arabam2 = new Araba ("Porsche", "Boxter");
            arabam1.G�ster(); arabam2.G�ster();
            Console.WriteLine ("arabam1.ToString() = " + arabam1.ToString());
            Console.WriteLine ("arabam1.GetType() = " + arabam1.GetType());
            Console.WriteLine ("arabam1.GetHashCode() = " + arabam1.GetHashCode());
            Console.WriteLine ("Araba.Equals (arabam1, arabam2)? = " + Araba.Equals (arabam1, arabam2));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam2)? = " + Araba.ReferenceEquals (arabam1, arabam2));
            Console.WriteLine ("\tarabam1 = arabam2 atan�yor");
            arabam1 = arabam2;
            Console.WriteLine ("Araba.Equals (arabam1, arabam2)? = " + Araba.Equals (arabam1, arabam2));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam2) = " + Araba.ReferenceEquals (arabam1, arabam2));
            Console.WriteLine ("\tarabam3 Kopyala arabam1 kopyalan�yor");
            Araba arabam3 = Araba.Kopyala (arabam1);
            arabam3.G�ster();
            Console.WriteLine ("Araba.Equals (arabam1, arabam3)? = " + Araba.Equals (arabam1, arabam3));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam3) = " + Araba.ReferenceEquals (arabam1, arabam3));


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}