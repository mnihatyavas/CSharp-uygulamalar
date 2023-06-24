// j2sc#0221e.cs: Enum �yelerini foreach d�ng�s�yle olan geli�ig�zel de�erleriyle kullanma �rne�i.

using System;
namespace VeriTipleri {
    enum Renk {K�rm�z�=12, Portakal=13, Sar�=14, Ye�il=10, Mavi=9, �ndigo=7, Mor=5}
    enum ��g�renTipi: byte {Y�netici = 60, Programc� = 15, M�teahhit = 100, Argeci = 19, ��ci = 1}
    class Enum5 {
        static void Main() {
            Console.Write ("For d�ng�s�nde enum adlar� kullan�labilmesi i�in varsay�l� yada atanan de�erlerinin artan s�ral� olmas� gereklidir. ForEach d�ng�deyse de�erlerin d�zenlili�i gerekmez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("4 ayr� ForEach'le renklerin kodlar� ve adlar�:");
            Renk r = Renk.Sar�;
            foreach (int i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0} ({1})", i, Enum.GetName (r.GetType(), i));
            Console.WriteLine();
            foreach (int i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", Enum.GetName (r.GetType(), i), Enum.Format (typeof (Renk), i, "D"));
            Console.WriteLine();
            foreach (Renk i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", i, (int)i);
            Console.WriteLine();
            foreach (string a in Enum.GetNames (r.GetType())) Console.WriteLine ("Renk: {0}", a);
            Console.WriteLine();
            foreach (Renk i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", (int)i, (Renk) Enum.Parse (typeof (Renk), i.ToString(), true));

            Console.WriteLine ("\n{0} �yeli {1} tipli i�g�ren ad ve de�erleri:", Enum.GetValues (typeof (��g�renTipi)).Length, Enum.GetUnderlyingType (typeof (��g�renTipi)));
            for (byte i=0; i <= 100; i++) {if (Enum.IsDefined (typeof (��g�renTipi), i)) Console.WriteLine("{0} ��g�renTipi'nin tan�ml� bir �yesi midir? {1}", i, Enum.IsDefined (typeof (��g�renTipi), i) );}
            Console.WriteLine();
            foreach (byte i in Enum.GetValues (typeof (��g�renTipi)) ) Console.WriteLine ("{0}={1}", Enum.GetName (typeof (��g�renTipi), i), i);
            Console.WriteLine();
            foreach (��g�renTipi i in Enum.GetValues (typeof (��g�renTipi)) ) Console.WriteLine ("�ye ad�: {0} dec({1})=hex({2})", i, Enum.Format (typeof (��g�renTipi), i, "D"), Enum.Format (typeof (��g�renTipi), i, "X") );

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}