// j2sc#0221b.cs: Enum üyelerine varsayýlýdan farklý deðerler atama örneði.

using System;
namespace VeriTipleri {
    public enum ÇizgiStili {Katý, Noktalý, Tireli}
    enum Notlar {A=90, B=70, C=50, D=40, E=20, F=0}
    enum Sayýlanabilen1 {A = 1, B = 2, C = A + B, D = B * C - 1, E, F = 0}
    enum Aylar {Ocak = 1, Þubat, Mart, Nisan, Mayýs, Haziran, Temmuz, Aðustos, Eylül, Ekim, Kasým, Aralýk}
    [Flags]
    enum DosyayaEriþim {Oku=1, Yaz=2, OkuYaz=3}
    enum ÝþgörenTipi : byte {Yönetici = 10, Ýþci = 1, Müteahhit = 100, Baþbakan = 49}
    class Enum2 {
        public static void ÇizgiÇiz (ÇizgiStili çizgi) {
            switch (çizgi) {
                case ÇizgiStili.Katý: Console.WriteLine ("Kesintisiz katý çizgi çizilecek"); break;
                case ÇizgiStili.Noktalý: Console.WriteLine ("Kesintili noktalý çizgi çizilecek"); break;
                case ÇizgiStili.Tireli: Console.WriteLine ("Kesintili tireli çizgi çizilecek"); break;
                default: throw (new ArgumentException ("Geçersiz çizgi stili"));
            }
        }
        static void EnumDeðerleme (System.Enum e) {
            Console.WriteLine ("\n=> Enum:{0} hakkýnda bilgiler", e.GetType().Name);
            Console.WriteLine ("Sayýlanabilen tamsayý tipi: {0}", Enum.GetUnderlyingType (e.GetType()));
            Array enumVeri = Enum.GetValues (e.GetType());
            Console.WriteLine ("Bu enum'un {0} üyesi vardýr. Sýrarýyla:", enumVeri.Length);
            for (int i = 0; i < enumVeri.Length; i++) Console.WriteLine (" Adý: {0}, Deðeri: {0:D}", enumVeri.GetValue(i));
        }
        public static void Göster1 (int i, Sayýlanabilen1 n) {Console.Write (i + "=" + n + " ");}
        static void Main() {
            Console.Write ("Deðer atamasýz 0,1,.. tamsayýyla sayýlanabilen enum dizgeler listesi, atanan farklý +tamsayý deðerlerle deðiþtirilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            ÇizgiÇiz (ÇizgiStili.Katý);
            try {ÇizgiÇiz ((ÇizgiStili) 3);}catch (Exception h) {Console.WriteLine ("HATA: " + h.Message);}
            ÇizgiÇiz ((ÇizgiStili) 2);
            ÇizgiÇiz (ÇizgiStili.Noktalý);
            try {ÇizgiÇiz ((ÇizgiStili) 1957);}catch (Exception h) {Console.WriteLine ("HATA: " + h.Message);}

            var nt = (Notlar) 20;
            int ts1 = (int) nt;
            Console.WriteLine ("\n(Notlar) 20 = " + nt);
            Console.WriteLine ("(int) nt = " + ts1);
            Console.WriteLine ("Notlar.E = " + Notlar.E);
            Console.WriteLine ("(Notlar) 0 = " + (Notlar) 0);
            Console.WriteLine ("(Notlar) 1 = " + (Notlar) 1);

            Console.WriteLine ("\nAtanan A=1, B=2, C=A+B=3, D=B*C-1=5, E, F=0 deðerlerle enum listesi:");
            for (int i=0; i < 10; i++) Göster1 (i, (Sayýlanabilen1) i);

            Aylar a; Console.WriteLine ("\n\n12 ayýn no ve ad'larý:");
            for (a = Aylar.Ocak; a <= Aylar.Aralýk; a++) Console.Write ((int)a + "=" + a + " "); 
 
            var oy1 = DosyayaEriþim.Oku | DosyayaEriþim.Yaz;
            Console.WriteLine ("\n\noy1 == {0}:{1}", oy1, (int)oy1);
            var oy2 = DosyayaEriþim.OkuYaz;
            Console.WriteLine ("oy2 == {0}:{1}", oy2, (int)oy2);
            Console.WriteLine ("oy1 == oy2? {0}", oy1 == oy2);
            if (oy1 == DosyayaEriþim.Oku) Console.WriteLine("oy1: okuma eriþimli"); else Console.WriteLine ("oy1: okuma eriþimsiz");
            if ((oy2 & DosyayaEriþim.Oku) != 0)  Console.WriteLine ("oy2: okuma eriþimli = {0}:{1} ", (int)(oy2 & DosyayaEriþim.Oku), (oy2 & DosyayaEriþim.Oku)); else Console.WriteLine ("oy2: okuma eriþimsiz");

            var iþg = ÝþgörenTipi.Müteahhit;
            DayOfWeek gün = DayOfWeek.Friday;
            ConsoleColor renk = ConsoleColor.Black;
            var ay = Aylar.Temmuz;
            EnumDeðerleme (iþg);
            EnumDeðerleme (gün);
            EnumDeðerleme (renk);
            EnumDeðerleme (ay);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}