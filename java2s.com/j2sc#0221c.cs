// j2sc#0221c.cs: Enum �yelerini |, & tercihli kullanabilme �rne�i.

using System;
namespace VeriTipleri {
    enum GezegenY�llar� {Merk�r = 8, Ven�s = 2, D�nya = 3, Mars = 6}
    enum Gezegenler {Merk�r = 1, Ven�s, D�nya, Mars, J�piter, Sat�rn, �ran�s, Nept�n, Pl�to}
    enum Y�nler: byte {Kuzey = 1, G�ney = 2, Do�u = 3, Bat� = 4}
    enum Stat�ler {Haz�r=0x1, �evrimd���=0x2, Bekliyor=0x4, G�nderiTamam=0x8, Al�nd�Tamam=0x10, �evrimi�i=0x20}
    enum Renk: uint {K�rm�z� = 0x01, Mavi = 0x02, Sar� = 0x04,  Ye�il = 0x08}
    [Flags] enum Bitler: uint {Bitsiz = 0, Bit1 = 0x00000001, Bit2 = 0x00000002, Bit3 = 0x00000004, Bit4 = 0x00000008, Bit5 = 0x00000010, TamBitli = 0xFFFFFFFF}
    class Enum3 {
        public static void �ye (Bitler e) {Console.WriteLine (e);}
        static void Main() {
            Console.Write ("For d�ng�s�nde enum adlar� kullan�labilmesi i�in varsay�l� yada atanan de�erlerinin artan s�ral� olmas� uygundur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("4 gezegenin herbirinin g�ne� �evresindeki bir tam tur s�resi:");
            Console.WriteLine (" Merk�r gezegeni = {0} g�n.", ((int)GezegenY�llar�.Merk�r * 365.000684463D / 3.0));
            Console.WriteLine (" Ven�s gezegeni = {0} g�n.", ((int)GezegenY�llar�.Ven�s * 365.000684463D / 3.0));
            Console.WriteLine (" D�nya gezegeni = {0} g�n.", ((int)GezegenY�llar�.D�nya * 365.000684463D / 3.0));
            Console.WriteLine (" Mars gezegeni = {0} g�n.", ((int)GezegenY�llar�.Mars * 365.000684463D / 3.0));

            Console.WriteLine ("\nT�m gezegenlerin g�ne�ten uzakl�k s�ralamas�:");
            for (Gezegenler g=Gezegenler.Merk�r; g <= Gezegenler.Pl�to; g++) Console.WriteLine ("{0}.inci gezegen = {1}", (int)g, g);

            Y�nler y�n�m; byte y�nByte; string y�nString;
            y�n�m = Y�nler.Kuzey; y�nByte = (byte) y�n�m; y�nString = Convert.ToString (y�n�m);
            Console.WriteLine ("\nY�nler y�n�m = {0}, {1}\nbyte y�nByte = {2}, {3}\nstring y�nString = {4}, {5}", y�n�m, y�n�m.GetType(), y�nByte, y�nByte.GetType(), y�nString, y�nString.GetType());

            Renk tercihler = Renk.K�rm�z� | Renk.Sar� | Renk.Ye�il;
            bool K�rm�z�M� = false, MaviMi = false, Sar�M� = false, Ye�ilMi = false;
            K�rm�z�M� = (tercihler & Renk.K�rm�z�) == Renk.K�rm�z�;
            MaviMi = (tercihler & Renk.Mavi) == Renk.Mavi;
            Sar�M� = (tercihler & Renk.Sar�) == Renk.Sar�;
            Ye�ilMi = (tercihler & Renk.Ye�il) == Renk.Ye�il;
            Console.WriteLine ("\nRenkler = (K�rm�z�, Mavi, Sar�, Ye�il) = ({0}, {1}, {2}, {3})", (int) Renk.K�rm�z�, (int) Renk.Mavi, (int) Renk.Sar�, (int) Renk.Ye�il);
            Console.WriteLine ("Kullan�labilecek renk tercihleri = {0}", (int) tercihler);
            Console.WriteLine ("(K�rm�z�, Mavi, Sar�, Ye�il) kullan�ls�n m�? = ({0}, {1}, {2}, {3})", K�rm�z�M�, MaviMi, Sar�M�, Ye�ilMi);

            Console.WriteLine ("\nT�m enum bitler, s�ra ve de�erleri:");
            Console.WriteLine ("{0}.inci bit: {1} = {2}\n{3}.inci bit: {4} = {5}\n{6}.inci bit: {7} = {8}\n{9}.inci bit: {10} = {11}\n{12}.inci bit: {13} = {14}\n{15}.inci bit: {16} = {17}\n{18}.inci bit: {19} = {20}",
                0, Bitler.Bitsiz, (int)Bitler.Bitsiz, 1, Bitler.Bit1, (int)Bitler.Bit1, 2, Bitler.Bit2, (int)Bitler.Bit2, 3, Bitler.Bit3, (int)Bitler.Bit3, 4, Bitler.Bit4, (int)Bitler.Bit4, 5, Bitler.Bit5, (int)Bitler.Bit5, 6, Bitler.TamBitli, (long)Bitler.TamBitli);
            �ye (Bitler.Bit1);
            �ye (Bitler.Bit1 | Bitler.Bit2);
            �ye (Bitler.Bitsiz | Bitler.Bit3 | Bitler.Bit5 | Bitler.TamBitli);
            �ye (Bitler.Bit5 & Bitler.TamBitli);

            Y�nler y�n = Y�nler.Bat�;
            Console.WriteLine ("\nBat�=4 y�n�n�n G, F, D, X bi�imlenmesi:");
            Console.WriteLine ("{0:G}\n{0:F}\n{0:D}\n{0:X}", y�n);

            Stat�ler st = Stat�ler.Haz�r | Stat�ler.G�nderiTamam | Stat�ler.�evrimi�i;
            Console.WriteLine ("\nHaz�r=1 | G�nderiTamam=8 | �evrimi�i=32 stat�lerin G, F, D, X bi�imlenmesi:");
            Console.WriteLine ("{0:G}\n{0:F}\n{0:D}\n{0:X}", st);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}