// j2sc#0221d.cs: Enum üyelerini for döngüsüyle artan sýralý kullanma örneði.

using System;
namespace VeriTipleri {
    public enum Günler {Pazartesi=1, Salý, Çarþamba, Perþembe, Cuma, Cumartesi, Pazar}
    public enum GünDilimleri {Sabah, Öðlen, Akþam, Gece=5}
    public enum Renk {Kýrmýzý, Portakal, Sarý, Yeþil, Mavi, Ýndigo, Mor}
    public enum KapýnýnDurumu {TamAçýk=8, YarýAralýk, TamKapalý}
    class Ajanda { 
        public void ajandam (Günler gün) {
            switch (gün) {
                case Günler.Pazartesi: Console.WriteLine ("{0}:{1}) 8:30'da Uludað Restaurant'ta kahvaltý.", (int)gün, gün); break;
                case Günler.Salý: Console.WriteLine ("{0}:{1}) 12:30'da Toroslar Lokanta'da öðlen yemeði.", (int)gün, gün); break;
                case Günler.Çarþamba: Console.WriteLine ("{0}:{1}) 17:30'da Kuþadasý Kafe'de ikindi çayý.", (int)gün, gün); break;
                case Günler.Perþembe: Console.WriteLine ("{0}:{1}) 20:15'de Pamukkale McDonalds'ta akþam yemeði.", (int)gün, gün); break;
                case Günler.Cuma: Console.WriteLine ("{0}:{1}) 21:00'da Alanya Disco'da dans.", (int)gün, gün); break;
                case Günler.Cumartesi: Console.WriteLine ("{0}:{1}) 23:45'de Mersin Hilton-SA'da gece yatýsý.", (int)gün, gün); break;
                case Günler.Pazar: Console.WriteLine ("{0}:{1}) 03:45'de odaya viski-kokteyl servisi.", (int)gün, gün); break;
            }
        }
    }
    class KapýKontrol {
        private KapýnýnDurumu elan;
        public KapýnýnDurumu Durum {
            get {return elan;}
            set {elan = value;}
        }
    }
    class Enum4 {
        static void selamlaþma (GünDilimleri d) {
            switch (d) {
                case GünDilimleri.Sabah: Console.WriteLine ("Günaydýn!"); break;
                case GünDilimleri.Öðlen: Console.WriteLine ("Tünaydýn!"); break;
                case GünDilimleri.Akþam: Console.WriteLine ("Ýyi Akþamlar!"); break;
                case GünDilimleri.Gece: Console.WriteLine ("Ýyi Geceler!"); break;
                default: Console.WriteLine ("Ýyi Günler!"); break;
            }
        }
        static void Main() {
            Console.Write ("For döngüsünde enum adlarý kullanýlabilmesi için varsayýlý yada atanan deðerlerinin artan sýralý olmasý gereklidir. Sýralama birer artan deðilse arayý enum olmayan artan tamsayýlarla doldurur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var a = new Ajanda();
            Console.WriteLine ("Haftalýk ajanda:");
            for (Günler i=Günler.Pazartesi; i <= Günler.Pazar; i++) a.ajandam (i);

            Console.WriteLine ("\nGüniçi selamlaþma farklarý:");
            for (GünDilimleri i=GünDilimleri.Sabah; i <= GünDilimleri.Gece; i++) selamlaþma (i);

            Console.WriteLine ("\nRenklerin karþýlaþtýrýlmasý (-1=küçük, 0=eþit, 1=büyük):");
            Renk rengim = Renk.Yeþil;
            for (Renk i=Renk.Kýrmýzý; i <= Renk.Mor; i++) Console.WriteLine ("{0}:{1} Kýyas {2}:{3} = {4}", (int)rengim, rengim, (int)i, i, rengim.CompareTo (i));

            var kapý = new KapýKontrol();
            Console.WriteLine ("\nKapýnýn açýk/kapalý durumlarý:");
            for (KapýnýnDurumu i=KapýnýnDurumu.TamAçýk; i <= KapýnýnDurumu.TamKapalý; i++) Console.WriteLine ("Kapýnýn þuanki durumu = {0}:{1}--{2}", (kapý.Durum = i), (int)kapý.Durum, typeof (KapýnýnDurumu).ToString());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}