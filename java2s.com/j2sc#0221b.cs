// j2sc#0221b.cs: Enum �yelerine varsay�l�dan farkl� de�erler atama �rne�i.

using System;
namespace VeriTipleri {
    public enum �izgiStili {Kat�, Noktal�, Tireli}
    enum Notlar {A=90, B=70, C=50, D=40, E=20, F=0}
    enum Say�lanabilen1 {A = 1, B = 2, C = A + B, D = B * C - 1, E, F = 0}
    enum Aylar {Ocak = 1, �ubat, Mart, Nisan, May�s, Haziran, Temmuz, A�ustos, Eyl�l, Ekim, Kas�m, Aral�k}
    [Flags]
    enum DosyayaEri�im {Oku=1, Yaz=2, OkuYaz=3}
    enum ��g�renTipi : byte {Y�netici = 10, ��ci = 1, M�teahhit = 100, Ba�bakan = 49}
    class Enum2 {
        public static void �izgi�iz (�izgiStili �izgi) {
            switch (�izgi) {
                case �izgiStili.Kat�: Console.WriteLine ("Kesintisiz kat� �izgi �izilecek"); break;
                case �izgiStili.Noktal�: Console.WriteLine ("Kesintili noktal� �izgi �izilecek"); break;
                case �izgiStili.Tireli: Console.WriteLine ("Kesintili tireli �izgi �izilecek"); break;
                default: throw (new ArgumentException ("Ge�ersiz �izgi stili"));
            }
        }
        static void EnumDe�erleme (System.Enum e) {
            Console.WriteLine ("\n=> Enum:{0} hakk�nda bilgiler", e.GetType().Name);
            Console.WriteLine ("Say�lanabilen tamsay� tipi: {0}", Enum.GetUnderlyingType (e.GetType()));
            Array enumVeri = Enum.GetValues (e.GetType());
            Console.WriteLine ("Bu enum'un {0} �yesi vard�r. S�rar�yla:", enumVeri.Length);
            for (int i = 0; i < enumVeri.Length; i++) Console.WriteLine (" Ad�: {0}, De�eri: {0:D}", enumVeri.GetValue(i));
        }
        public static void G�ster1 (int i, Say�lanabilen1 n) {Console.Write (i + "=" + n + " ");}
        static void Main() {
            Console.Write ("De�er atamas�z 0,1,.. tamsay�yla say�lanabilen enum dizgeler listesi, atanan farkl� +tamsay� de�erlerle de�i�tirilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            �izgi�iz (�izgiStili.Kat�);
            try {�izgi�iz ((�izgiStili) 3);}catch (Exception h) {Console.WriteLine ("HATA: " + h.Message);}
            �izgi�iz ((�izgiStili) 2);
            �izgi�iz (�izgiStili.Noktal�);
            try {�izgi�iz ((�izgiStili) 1957);}catch (Exception h) {Console.WriteLine ("HATA: " + h.Message);}

            var nt = (Notlar) 20;
            int ts1 = (int) nt;
            Console.WriteLine ("\n(Notlar) 20 = " + nt);
            Console.WriteLine ("(int) nt = " + ts1);
            Console.WriteLine ("Notlar.E = " + Notlar.E);
            Console.WriteLine ("(Notlar) 0 = " + (Notlar) 0);
            Console.WriteLine ("(Notlar) 1 = " + (Notlar) 1);

            Console.WriteLine ("\nAtanan A=1, B=2, C=A+B=3, D=B*C-1=5, E, F=0 de�erlerle enum listesi:");
            for (int i=0; i < 10; i++) G�ster1 (i, (Say�lanabilen1) i);

            Aylar a; Console.WriteLine ("\n\n12 ay�n no ve ad'lar�:");
            for (a = Aylar.Ocak; a <= Aylar.Aral�k; a++) Console.Write ((int)a + "=" + a + " "); 
 
            var oy1 = DosyayaEri�im.Oku | DosyayaEri�im.Yaz;
            Console.WriteLine ("\n\noy1 == {0}:{1}", oy1, (int)oy1);
            var oy2 = DosyayaEri�im.OkuYaz;
            Console.WriteLine ("oy2 == {0}:{1}", oy2, (int)oy2);
            Console.WriteLine ("oy1 == oy2? {0}", oy1 == oy2);
            if (oy1 == DosyayaEri�im.Oku) Console.WriteLine("oy1: okuma eri�imli"); else Console.WriteLine ("oy1: okuma eri�imsiz");
            if ((oy2 & DosyayaEri�im.Oku) != 0)  Console.WriteLine ("oy2: okuma eri�imli = {0}:{1} ", (int)(oy2 & DosyayaEri�im.Oku), (oy2 & DosyayaEri�im.Oku)); else Console.WriteLine ("oy2: okuma eri�imsiz");

            var i�g = ��g�renTipi.M�teahhit;
            DayOfWeek g�n = DayOfWeek.Friday;
            ConsoleColor renk = ConsoleColor.Black;
            var ay = Aylar.Temmuz;
            EnumDe�erleme (i�g);
            EnumDe�erleme (g�n);
            EnumDe�erleme (renk);
            EnumDe�erleme (ay);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}