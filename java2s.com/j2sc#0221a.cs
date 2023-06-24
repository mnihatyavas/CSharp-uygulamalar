// j2sc#0221a.cs: Sayýlanabilen sabit enum birimlerine adla veya sayýyla eriþim örneði.

using System;
namespace VeriTipleri {
    enum günAdlarý {Pazartesi, Salý, Çarþamba, Perþembe, Cuma, Cumartesi, Pazar}
    class ÜçGün {
        public const günAdlarý gün0 = günAdlarý.Pazartesi;
        public const günAdlarý gün3 = günAdlarý.Perþembe;
        public const günAdlarý gün6 = (günAdlarý) 6;
    }
    public enum EnumRenk {Kýrmýzý, Yeþil, Mavi}
    class Renk {
        int kýrmýzý, yeþil, mavi;
        public Renk (int r1, int r2, int r3) {//Kurucu
            this.kýrmýzý = r1;
            this.yeþil = r2;
            mavi = r3;
        }
        public Renk RengiAl (EnumRenk r) {
            switch (r) {
                case EnumRenk.Kýrmýzý: return (new Renk (255, 0, 0));
                case EnumRenk.Yeþil: return (new Renk (0, 255, 0));
                case EnumRenk.Mavi: return (new Renk (0, 0, 255));
                case (EnumRenk) 3: return (new Renk (255, 255, 0));
                case (EnumRenk) 4: return (new Renk (150, 150, 150));
                default: return (new Renk (0, 0, 0)); //Siyah
            }
        }
        public string RenkleriAl() {return "rgb = (" + kýrmýzý + ", " + yeþil + ", " + mavi + ")";}
    }
    enum ÝþgörenTipi {Ýþci, Yönetici}
    class Ýþci {
        public string isim;
        protected float saatÜcreti;
        protected ÝþgörenTipi tip;
        public Ýþci (string isim, float saatÜcreti) {
            this.isim = isim;
            this.saatÜcreti = saatÜcreti;
            tip = ÝþgörenTipi.Ýþci;
        }
        public float ÜcretiHesapla (float saat) {
            if (tip == ÝþgörenTipi.Yönetici) {
                Yönetici y = (Yönetici) this;
                return (y.ÜcretiHesapla (saat));
            }else if (tip == ÝþgörenTipi.Ýþci) return (saat * saatÜcreti);
            return (0F);
        }
        public string TipAdý() {
            if (tip == ÝþgörenTipi.Yönetici) {
                Yönetici y = (Yönetici) this;
                return (y.TipAdý());
            }else if (tip == ÝþgörenTipi.Ýþci) return ("Kalifiye Ýþgören");
            return ("Uyumsuz Tip");
        }
    }
    class Yönetici: Ýþci {
        public Yönetici (string isim, float saatÜcreti): base (isim, saatÜcreti) {tip = ÝþgörenTipi.Yönetici;}
        public new float ÜcretiHesapla (float saat) {
            if (saat < 1.0F) saat = 1.0F; // Enaz yönetici saatý 1s alýnacak.
            return (saat * saatÜcreti);
        }
        public new string TipAdý() {return ("Kariyerli Ýþgören");}
    }
    class Enum1 {
        static void Main() {
            Console.Write ("0,1,.. tamsayýyla sayýlanabilen enum, dizgesel birimler listesidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var gün = günAdlarý.Pazartesi;
            Console.WriteLine ("Haftanýn ilk, orta ve son günleri: ({0}, {1}, {2})", gün, günAdlarý.Perþembe, (günAdlarý) 6);

            Console.Write ("\nHaftanýn tüm günleri: ");
            for (int i=0; i < 7; i++) Console.Write ((günAdlarý) i + " ");

            Console.WriteLine ("\n\nHaftanýn ilk, orta ve son günleri: ({0}, {1}, {2})", ÜçGün.gün0, ÜçGün.gün3, ÜçGün.gün6);

            var renk = new Renk (0,0,0).RengiAl (EnumRenk.Yeþil); Console.WriteLine ("\nYeþil: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl (EnumRenk.Mavi); Console.WriteLine ("Mavi: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl (EnumRenk.Kýrmýzý); Console.WriteLine ("Kýrmýzý: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)5); Console.WriteLine ("Varsayýlý (siyah): {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)3); Console.WriteLine ("Sarý: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)4); Console.WriteLine ("Gri: {0}", renk.RenkleriAl());

            var iþgörDizi = new Ýþci [11];
            iþgörDizi [0] = new Ýþci ("Hatice Yavaþ", 62.50F);
            iþgörDizi [1] = new Ýþci ("Süheyla Yavaþ", 60.50F);
            iþgörDizi [2] = new Ýþci ("Zeliha Yavaþ", 58.50F);
            iþgörDizi [3] = new Ýþci ("M.Nihat Yavaþ", 56.50F);
            iþgörDizi [4] = new Ýþci ("Songül Yavaþ", 54.50F);
            iþgörDizi [5] = new Ýþci ("M.Nedim Yavaþ", 52.50F);
            iþgörDizi [6] = new Ýþci ("Sevim Yavaþ", 50.50F);
            iþgörDizi [7] = new Yönetici ("Bekir Yavaþ", 90F);
            iþgörDizi [8] = new Yönetici ("Fatma Yavaþ", 85F);
            iþgörDizi [9] = new Yönetici ("Memet Yavaþ", 80F);
            iþgörDizi [10] = new Yönetici ("Haným Yavaþ", 75F);
            Console.WriteLine ("\n{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [0].TipAdý(), iþgörDizi [0].isim, 160F, iþgörDizi [0].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [1].TipAdý(), iþgörDizi [1].isim, 160F, iþgörDizi [1].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [2].TipAdý(), iþgörDizi [2].isim, 160F, iþgörDizi [2].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [3].TipAdý(), iþgörDizi [3].isim, 160F, iþgörDizi [3].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [4].TipAdý(), iþgörDizi [4].isim, 160F, iþgörDizi [4].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [5].TipAdý(), iþgörDizi [5].isim, 160F, iþgörDizi [5].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,000.00}TL", iþgörDizi [6].TipAdý(), iþgörDizi [6].isim, 160F, iþgörDizi [6].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,#00.00}TL", iþgörDizi [7].TipAdý(), iþgörDizi [7].isim, 0.75F, iþgörDizi [7].ÜcretiHesapla (0.75F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,#00.00}TL", iþgörDizi [8].TipAdý(), iþgörDizi [8].isim, 1.75F, iþgörDizi [8].ÜcretiHesapla (1.75F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,#00.00}TL", iþgörDizi [9].TipAdý(), iþgörDizi [9].isim, 160F, iþgörDizi [9].ÜcretiHesapla (160F));
            Console.WriteLine ("{0} {1}'ýn toplam {2} saatlýk ücreti = {3:#,#00.00}TL", iþgörDizi [10].TipAdý(), iþgörDizi [10].isim, 160F, iþgörDizi [10].ÜcretiHesapla (160F));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}