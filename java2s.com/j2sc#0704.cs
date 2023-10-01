// j2sc#0704.cs: Sýnýf metot üyelerinin parametreli/parametresiz çaðrýlmasý örneði.

using System;
namespace Sýnýflar {
    class Hesapcý {public int Topla (int x, int y) {return x + y;} }
    class Nokta3B {
        int x, y, z;
        public Nokta3B (int a) {x = 2*a+45; y = 3*a-5; z = -4*a+82;} //Parametreli kurucu
        public int AlX() {return x;}
        public int AlY() {return y;}
        public int AlZ() {return z;}
    }
    class Bina {
        public int alan, mukimler;
        public int kiþiBaþýAlan() {return alan / mukimler;}
    }
    class Daire {
        double y; // yarýçap
        public Daire (double y) {this.y=y;} //Kurucu
        public double DaireÇevresi() {return 2 * Math.PI * y;}
        public double DaireAlaný() {return Math.PI * y * y;}
        public double DaireHacmi() {return 4 / 3 * Math.PI * y * y * y;}
        //public double KüreAlaný() {return ;}
        //public double KüreHacmi() {return ;}
    }
    public class Araba {
        string marka, model;
        public Araba (string marka, string model) {this.marka = marka; this.model = model;} //Kurucu
        public void Göster() {Console.WriteLine ("Marka ve model: {0} - {1}", marka, model);}
        public static Araba Kopyala (Araba a) {return (Araba)a.MemberwiseClone();}
        public override bool Equals (object nsn) {//Deðersel eþitliðe özeller
            Araba diðer = nsn as Araba;
            if (diðer == null) {return false;}
            return (this.marka == diðer.marka) && (this.model == diðer.model);
        }
        //public override int GetHashCode() {return (int)new Random().Next (0, 100000) ^ (int)new Random().Next (95800, 167830);} //Referanssal eþitliðe özeller
    }
    class ÜyeMetod {
        static void MetodA (int p1, int p2) {
            Console.WriteLine ("MetodA'ya girdim: {0}, {1}", p1, p2);
            MetodB (new Random().Next (0, 3500), new Random().Next (-10000, 10000));
            Console.WriteLine ("MetodA'dan çýkýyorum");
        }
        static void MetodB (int p1, int p2) {
            Console.WriteLine ("MetodB'ye girdim: {0}, {1}", p1, p2);
            ÜyeMetod.MetodC (new Random().Next (0, 9000), new Random().Next (-1000, 1000));
            Console.WriteLine ("MetodB'den çýkýyorum");
        }
        static void MetodC (int p1, int p2) {
            Console.WriteLine ("MetodC'ye girdim: {0}, {1}", p1, p2);
            Console.WriteLine ("MetodC'den çýkýyorum");
        }
        static void Main() {
            Console.Write ("Sýnýfýn metot üyesi eriþim/geridönüþ-tip, metot-adý ve parametre listesinden oluþur. Ayný sýnýf içi duruk/statik metot doðrudan yada tiplemesiz sýnýf-adýyla çaðrýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf üye metoduyla iki tamsayý toplamýnýn hesaplanmasý:");
            var r=new Random(); int ts1, ts2, i;
            Hesapcý hsp;
            for (i=0; i<5; i++) {
                ts1=r.Next (-3500, 3500); ts2=r.Next (-1150, 1150);
                hsp = new Hesapcý();
                Console.WriteLine ("ts1({0}) + ts2({1}) = {2}", ts1, ts2, hsp.Topla (ts1, ts2));
            }

            Console.WriteLine ("\nHesaplanarak kurucuyla konulan 3B nokta verilerinin alýnmasý:");
            Nokta3B n3B;
            for (i=0; i<5; i++) {
                ts1=r.Next (-100, 100);
                n3B = new Nokta3B (ts1);
                Console.WriteLine ("Nokta3B (x({0}), y, z) = ({1}, {2}, {3})", ts1, n3B.AlX(), n3B.AlY(), n3B.AlZ());
            }

            Console.WriteLine ("\nDoðrudan ve içiçe çaðrýlan duruk/statik metotlar:");
            MetodA (new Random().Next (0, 4780), new Random().Next (-1155, 10000));
            ÜyeMetod.MetodA (new Random().Next (0, 5000), new Random().Next (-6000, 8000));

            Console.WriteLine ("\nEv ve ofiteki kiþibaþý alanýn metot'la hesaplanmasý:");
            Bina ev = new Bina();
            Bina ofis = new Bina();
            int kbAlan; // kiþi baþý alan
            ev.mukimler = 11; ev.alan = 1200;
            ofis.mukimler = 125; ofis.alan = 4200;
            kbAlan = ev.kiþiBaþýAlan();
            Console.WriteLine ("Ev {0} m2 ve {1} hanehalklýk olup kiþibaþý alan {2} m2'dir.", ev.alan, ev.mukimler, kbAlan);
            kbAlan = ofis.kiþiBaþýAlan();
            Console.WriteLine ("Ofis {0} m2 ve {1} elemanlýk olup kiþibaþý alan {2} m2'dir.", ofis.alan, ofis.mukimler, kbAlan);

            Console.WriteLine ("\nYarýçapý verilen dairenin çevre, alan ve hacmini hesaplayan metotlar:");
            Daire d1; double ds1;
            for (i=0; i<5; i++) {
                ds1=r.Next (0, 100)+r.Next (0, 1000)/10000D;
                d1 = new Daire (ds1);
                Console.WriteLine ("Yarýçapý = {0} olan dairenin (çevre, alan, hacim) =\n\t({1:#,#.#0}, {2:#,#.#0}, {3:#,#.#0}) birim2", ds1, d1.DaireÇevresi(), d1.DaireAlaný(), d1.DaireHacmi());
            }

            Console.WriteLine ("\nFarklý 2 araba, aynýya atama ve kopyalamayla deðer/referans eþitlik testi:");
            Console.WriteLine ("\tAraba nesneleri yaratýlýyor");
            Araba arabam1 = new Araba ("Toyota", "MR2"); Araba arabam2 = new Araba ("Porsche", "Boxter");
            arabam1.Göster(); arabam2.Göster();
            Console.WriteLine ("arabam1.ToString() = " + arabam1.ToString());
            Console.WriteLine ("arabam1.GetType() = " + arabam1.GetType());
            Console.WriteLine ("arabam1.GetHashCode() = " + arabam1.GetHashCode());
            Console.WriteLine ("Araba.Equals (arabam1, arabam2)? = " + Araba.Equals (arabam1, arabam2));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam2)? = " + Araba.ReferenceEquals (arabam1, arabam2));
            Console.WriteLine ("\tarabam1 = arabam2 atanýyor");
            arabam1 = arabam2;
            Console.WriteLine ("Araba.Equals (arabam1, arabam2)? = " + Araba.Equals (arabam1, arabam2));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam2) = " + Araba.ReferenceEquals (arabam1, arabam2));
            Console.WriteLine ("\tarabam3 Kopyala arabam1 kopyalanýyor");
            Araba arabam3 = Araba.Kopyala (arabam1);
            arabam3.Göster();
            Console.WriteLine ("Araba.Equals (arabam1, arabam3)? = " + Araba.Equals (arabam1, arabam3));
            Console.WriteLine ("Araba.ReferenceEquals (arabam1, arabam3) = " + Araba.ReferenceEquals (arabam1, arabam3));


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}