// j2sc#0221d.cs: Enum �yelerini for d�ng�s�yle artan s�ral� kullanma �rne�i.

using System;
namespace VeriTipleri {
    public enum G�nler {Pazartesi=1, Sal�, �ar�amba, Per�embe, Cuma, Cumartesi, Pazar}
    public enum G�nDilimleri {Sabah, ��len, Ak�am, Gece=5}
    public enum Renk {K�rm�z�, Portakal, Sar�, Ye�il, Mavi, �ndigo, Mor}
    public enum Kap�n�nDurumu {TamA��k=8, Yar�Aral�k, TamKapal�}
    class Ajanda { 
        public void ajandam (G�nler g�n) {
            switch (g�n) {
                case G�nler.Pazartesi: Console.WriteLine ("{0}:{1}) 8:30'da Uluda� Restaurant'ta kahvalt�.", (int)g�n, g�n); break;
                case G�nler.Sal�: Console.WriteLine ("{0}:{1}) 12:30'da Toroslar Lokanta'da ��len yeme�i.", (int)g�n, g�n); break;
                case G�nler.�ar�amba: Console.WriteLine ("{0}:{1}) 17:30'da Ku�adas� Kafe'de ikindi �ay�.", (int)g�n, g�n); break;
                case G�nler.Per�embe: Console.WriteLine ("{0}:{1}) 20:15'de Pamukkale McDonalds'ta ak�am yeme�i.", (int)g�n, g�n); break;
                case G�nler.Cuma: Console.WriteLine ("{0}:{1}) 21:00'da Alanya Disco'da dans.", (int)g�n, g�n); break;
                case G�nler.Cumartesi: Console.WriteLine ("{0}:{1}) 23:45'de Mersin Hilton-SA'da gece yat�s�.", (int)g�n, g�n); break;
                case G�nler.Pazar: Console.WriteLine ("{0}:{1}) 03:45'de odaya viski-kokteyl servisi.", (int)g�n, g�n); break;
            }
        }
    }
    class Kap�Kontrol {
        private Kap�n�nDurumu elan;
        public Kap�n�nDurumu Durum {
            get {return elan;}
            set {elan = value;}
        }
    }
    class Enum4 {
        static void selamla�ma (G�nDilimleri d) {
            switch (d) {
                case G�nDilimleri.Sabah: Console.WriteLine ("G�nayd�n!"); break;
                case G�nDilimleri.��len: Console.WriteLine ("T�nayd�n!"); break;
                case G�nDilimleri.Ak�am: Console.WriteLine ("�yi Ak�amlar!"); break;
                case G�nDilimleri.Gece: Console.WriteLine ("�yi Geceler!"); break;
                default: Console.WriteLine ("�yi G�nler!"); break;
            }
        }
        static void Main() {
            Console.Write ("For d�ng�s�nde enum adlar� kullan�labilmesi i�in varsay�l� yada atanan de�erlerinin artan s�ral� olmas� gereklidir. S�ralama birer artan de�ilse aray� enum olmayan artan tamsay�larla doldurur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var a = new Ajanda();
            Console.WriteLine ("Haftal�k ajanda:");
            for (G�nler i=G�nler.Pazartesi; i <= G�nler.Pazar; i++) a.ajandam (i);

            Console.WriteLine ("\nG�ni�i selamla�ma farklar�:");
            for (G�nDilimleri i=G�nDilimleri.Sabah; i <= G�nDilimleri.Gece; i++) selamla�ma (i);

            Console.WriteLine ("\nRenklerin kar��la�t�r�lmas� (-1=k���k, 0=e�it, 1=b�y�k):");
            Renk rengim = Renk.Ye�il;
            for (Renk i=Renk.K�rm�z�; i <= Renk.Mor; i++) Console.WriteLine ("{0}:{1} K�yas {2}:{3} = {4}", (int)rengim, rengim, (int)i, i, rengim.CompareTo (i));

            var kap� = new Kap�Kontrol();
            Console.WriteLine ("\nKap�n�n a��k/kapal� durumlar�:");
            for (Kap�n�nDurumu i=Kap�n�nDurumu.TamA��k; i <= Kap�n�nDurumu.TamKapal�; i++) Console.WriteLine ("Kap�n�n �uanki durumu = {0}:{1}--{2}", (kap�.Durum = i), (int)kap�.Durum, typeof (Kap�n�nDurumu).ToString());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}