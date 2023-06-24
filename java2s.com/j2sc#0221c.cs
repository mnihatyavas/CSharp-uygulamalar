// j2sc#0221c.cs: Enum üyelerini |, & tercihli kullanabilme örneði.

using System;
namespace VeriTipleri {
    enum GezegenYýllarý {Merkür = 8, Venüs = 2, Dünya = 3, Mars = 6}
    enum Gezegenler {Merkür = 1, Venüs, Dünya, Mars, Jüpiter, Satürn, Üranüs, Neptün, Plüto}
    enum Yönler: byte {Kuzey = 1, Güney = 2, Doðu = 3, Batý = 4}
    enum Statüler {Hazýr=0x1, Çevrimdýþý=0x2, Bekliyor=0x4, GönderiTamam=0x8, AlýndýTamam=0x10, Çevrimiçi=0x20}
    enum Renk: uint {Kýrmýzý = 0x01, Mavi = 0x02, Sarý = 0x04,  Yeþil = 0x08}
    [Flags] enum Bitler: uint {Bitsiz = 0, Bit1 = 0x00000001, Bit2 = 0x00000002, Bit3 = 0x00000004, Bit4 = 0x00000008, Bit5 = 0x00000010, TamBitli = 0xFFFFFFFF}
    class Enum3 {
        public static void Üye (Bitler e) {Console.WriteLine (e);}
        static void Main() {
            Console.Write ("For döngüsünde enum adlarý kullanýlabilmesi için varsayýlý yada atanan deðerlerinin artan sýralý olmasý uygundur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("4 gezegenin herbirinin güneþ çevresindeki bir tam tur süresi:");
            Console.WriteLine (" Merkür gezegeni = {0} gün.", ((int)GezegenYýllarý.Merkür * 365.000684463D / 3.0));
            Console.WriteLine (" Venüs gezegeni = {0} gün.", ((int)GezegenYýllarý.Venüs * 365.000684463D / 3.0));
            Console.WriteLine (" Dünya gezegeni = {0} gün.", ((int)GezegenYýllarý.Dünya * 365.000684463D / 3.0));
            Console.WriteLine (" Mars gezegeni = {0} gün.", ((int)GezegenYýllarý.Mars * 365.000684463D / 3.0));

            Console.WriteLine ("\nTüm gezegenlerin güneþten uzaklýk sýralamasý:");
            for (Gezegenler g=Gezegenler.Merkür; g <= Gezegenler.Plüto; g++) Console.WriteLine ("{0}.inci gezegen = {1}", (int)g, g);

            Yönler yönüm; byte yönByte; string yönString;
            yönüm = Yönler.Kuzey; yönByte = (byte) yönüm; yönString = Convert.ToString (yönüm);
            Console.WriteLine ("\nYönler yönüm = {0}, {1}\nbyte yönByte = {2}, {3}\nstring yönString = {4}, {5}", yönüm, yönüm.GetType(), yönByte, yönByte.GetType(), yönString, yönString.GetType());

            Renk tercihler = Renk.Kýrmýzý | Renk.Sarý | Renk.Yeþil;
            bool KýrmýzýMý = false, MaviMi = false, SarýMý = false, YeþilMi = false;
            KýrmýzýMý = (tercihler & Renk.Kýrmýzý) == Renk.Kýrmýzý;
            MaviMi = (tercihler & Renk.Mavi) == Renk.Mavi;
            SarýMý = (tercihler & Renk.Sarý) == Renk.Sarý;
            YeþilMi = (tercihler & Renk.Yeþil) == Renk.Yeþil;
            Console.WriteLine ("\nRenkler = (Kýrmýzý, Mavi, Sarý, Yeþil) = ({0}, {1}, {2}, {3})", (int) Renk.Kýrmýzý, (int) Renk.Mavi, (int) Renk.Sarý, (int) Renk.Yeþil);
            Console.WriteLine ("Kullanýlabilecek renk tercihleri = {0}", (int) tercihler);
            Console.WriteLine ("(Kýrmýzý, Mavi, Sarý, Yeþil) kullanýlsýn mý? = ({0}, {1}, {2}, {3})", KýrmýzýMý, MaviMi, SarýMý, YeþilMi);

            Console.WriteLine ("\nTüm enum bitler, sýra ve deðerleri:");
            Console.WriteLine ("{0}.inci bit: {1} = {2}\n{3}.inci bit: {4} = {5}\n{6}.inci bit: {7} = {8}\n{9}.inci bit: {10} = {11}\n{12}.inci bit: {13} = {14}\n{15}.inci bit: {16} = {17}\n{18}.inci bit: {19} = {20}",
                0, Bitler.Bitsiz, (int)Bitler.Bitsiz, 1, Bitler.Bit1, (int)Bitler.Bit1, 2, Bitler.Bit2, (int)Bitler.Bit2, 3, Bitler.Bit3, (int)Bitler.Bit3, 4, Bitler.Bit4, (int)Bitler.Bit4, 5, Bitler.Bit5, (int)Bitler.Bit5, 6, Bitler.TamBitli, (long)Bitler.TamBitli);
            Üye (Bitler.Bit1);
            Üye (Bitler.Bit1 | Bitler.Bit2);
            Üye (Bitler.Bitsiz | Bitler.Bit3 | Bitler.Bit5 | Bitler.TamBitli);
            Üye (Bitler.Bit5 & Bitler.TamBitli);

            Yönler yön = Yönler.Batý;
            Console.WriteLine ("\nBatý=4 yönünün G, F, D, X biçimlenmesi:");
            Console.WriteLine ("{0:G}\n{0:F}\n{0:D}\n{0:X}", yön);

            Statüler st = Statüler.Hazýr | Statüler.GönderiTamam | Statüler.Çevrimiçi;
            Console.WriteLine ("\nHazýr=1 | GönderiTamam=8 | Çevrimiçi=32 statülerin G, F, D, X biçimlenmesi:");
            Console.WriteLine ("{0:G}\n{0:F}\n{0:D}\n{0:X}", st);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}