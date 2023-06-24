// j2sc#0221a.cs: Say�lanabilen sabit enum birimlerine adla veya say�yla eri�im �rne�i.

using System;
namespace VeriTipleri {
    enum g�nAdlar� {Pazartesi, Sal�, �ar�amba, Per�embe, Cuma, Cumartesi, Pazar}
    class ��G�n {
        public const g�nAdlar� g�n0 = g�nAdlar�.Pazartesi;
        public const g�nAdlar� g�n3 = g�nAdlar�.Per�embe;
        public const g�nAdlar� g�n6 = (g�nAdlar�) 6;
    }
    public enum EnumRenk {K�rm�z�, Ye�il, Mavi}
    class Renk {
        int k�rm�z�, ye�il, mavi;
        public Renk (int r1, int r2, int r3) {//Kurucu
            this.k�rm�z� = r1;
            this.ye�il = r2;
            mavi = r3;
        }
        public Renk RengiAl (EnumRenk r) {
            switch (r) {
                case EnumRenk.K�rm�z�: return (new Renk (255, 0, 0));
                case EnumRenk.Ye�il: return (new Renk (0, 255, 0));
                case EnumRenk.Mavi: return (new Renk (0, 0, 255));
                case (EnumRenk) 3: return (new Renk (255, 255, 0));
                case (EnumRenk) 4: return (new Renk (150, 150, 150));
                default: return (new Renk (0, 0, 0)); //Siyah
            }
        }
        public string RenkleriAl() {return "rgb = (" + k�rm�z� + ", " + ye�il + ", " + mavi + ")";}
    }
    enum ��g�renTipi {��ci, Y�netici}
    class ��ci {
        public string isim;
        protected float saat�creti;
        protected ��g�renTipi tip;
        public ��ci (string isim, float saat�creti) {
            this.isim = isim;
            this.saat�creti = saat�creti;
            tip = ��g�renTipi.��ci;
        }
        public float �cretiHesapla (float saat) {
            if (tip == ��g�renTipi.Y�netici) {
                Y�netici y = (Y�netici) this;
                return (y.�cretiHesapla (saat));
            }else if (tip == ��g�renTipi.��ci) return (saat * saat�creti);
            return (0F);
        }
        public string TipAd�() {
            if (tip == ��g�renTipi.Y�netici) {
                Y�netici y = (Y�netici) this;
                return (y.TipAd�());
            }else if (tip == ��g�renTipi.��ci) return ("Kalifiye ��g�ren");
            return ("Uyumsuz Tip");
        }
    }
    class Y�netici: ��ci {
        public Y�netici (string isim, float saat�creti): base (isim, saat�creti) {tip = ��g�renTipi.Y�netici;}
        public new float �cretiHesapla (float saat) {
            if (saat < 1.0F) saat = 1.0F; // Enaz y�netici saat� 1s al�nacak.
            return (saat * saat�creti);
        }
        public new string TipAd�() {return ("Kariyerli ��g�ren");}
    }
    class Enum1 {
        static void Main() {
            Console.Write ("0,1,.. tamsay�yla say�lanabilen enum, dizgesel birimler listesidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var g�n = g�nAdlar�.Pazartesi;
            Console.WriteLine ("Haftan�n ilk, orta ve son g�nleri: ({0}, {1}, {2})", g�n, g�nAdlar�.Per�embe, (g�nAdlar�) 6);

            Console.Write ("\nHaftan�n t�m g�nleri: ");
            for (int i=0; i < 7; i++) Console.Write ((g�nAdlar�) i + " ");

            Console.WriteLine ("\n\nHaftan�n ilk, orta ve son g�nleri: ({0}, {1}, {2})", ��G�n.g�n0, ��G�n.g�n3, ��G�n.g�n6);

            var renk = new Renk (0,0,0).RengiAl (EnumRenk.Ye�il); Console.WriteLine ("\nYe�il: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl (EnumRenk.Mavi); Console.WriteLine ("Mavi: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl (EnumRenk.K�rm�z�); Console.WriteLine ("K�rm�z�: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)5); Console.WriteLine ("Varsay�l� (siyah): {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)3); Console.WriteLine ("Sar�: {0}", renk.RenkleriAl());
            renk = new Renk (0,0,0).RengiAl ((EnumRenk)4); Console.WriteLine ("Gri: {0}", renk.RenkleriAl());

            var i�g�rDizi = new ��ci [11];
            i�g�rDizi [0] = new ��ci ("Hatice Yava�", 62.50F);
            i�g�rDizi [1] = new ��ci ("S�heyla Yava�", 60.50F);
            i�g�rDizi [2] = new ��ci ("Zeliha Yava�", 58.50F);
            i�g�rDizi [3] = new ��ci ("M.Nihat Yava�", 56.50F);
            i�g�rDizi [4] = new ��ci ("Song�l Yava�", 54.50F);
            i�g�rDizi [5] = new ��ci ("M.Nedim Yava�", 52.50F);
            i�g�rDizi [6] = new ��ci ("Sevim Yava�", 50.50F);
            i�g�rDizi [7] = new Y�netici ("Bekir Yava�", 90F);
            i�g�rDizi [8] = new Y�netici ("Fatma Yava�", 85F);
            i�g�rDizi [9] = new Y�netici ("Memet Yava�", 80F);
            i�g�rDizi [10] = new Y�netici ("Han�m Yava�", 75F);
            Console.WriteLine ("\n{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [0].TipAd�(), i�g�rDizi [0].isim, 160F, i�g�rDizi [0].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [1].TipAd�(), i�g�rDizi [1].isim, 160F, i�g�rDizi [1].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [2].TipAd�(), i�g�rDizi [2].isim, 160F, i�g�rDizi [2].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [3].TipAd�(), i�g�rDizi [3].isim, 160F, i�g�rDizi [3].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [4].TipAd�(), i�g�rDizi [4].isim, 160F, i�g�rDizi [4].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [5].TipAd�(), i�g�rDizi [5].isim, 160F, i�g�rDizi [5].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,000.00}TL", i�g�rDizi [6].TipAd�(), i�g�rDizi [6].isim, 160F, i�g�rDizi [6].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,#00.00}TL", i�g�rDizi [7].TipAd�(), i�g�rDizi [7].isim, 0.75F, i�g�rDizi [7].�cretiHesapla (0.75F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,#00.00}TL", i�g�rDizi [8].TipAd�(), i�g�rDizi [8].isim, 1.75F, i�g�rDizi [8].�cretiHesapla (1.75F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,#00.00}TL", i�g�rDizi [9].TipAd�(), i�g�rDizi [9].isim, 160F, i�g�rDizi [9].�cretiHesapla (160F));
            Console.WriteLine ("{0} {1}'�n toplam {2} saatl�k �creti = {3:#,#00.00}TL", i�g�rDizi [10].TipAd�(), i�g�rDizi [10].isim, 160F, i�g�rDizi [10].�cretiHesapla (160F));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}