// j2sc#0221e.cs: Enum üyelerini foreach döngüsüyle olan geliþigüzel deðerleriyle kullanma örneði.

using System;
namespace VeriTipleri {
    enum Renk {Kýrmýzý=12, Portakal=13, Sarý=14, Yeþil=10, Mavi=9, Ýndigo=7, Mor=5}
    enum ÝþgörenTipi: byte {Yönetici = 60, Programcý = 15, Müteahhit = 100, Argeci = 19, Ýþci = 1}
    class Enum5 {
        static void Main() {
            Console.Write ("For döngüsünde enum adlarý kullanýlabilmesi için varsayýlý yada atanan deðerlerinin artan sýralý olmasý gereklidir. ForEach döngüdeyse deðerlerin düzenliliði gerekmez.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("4 ayrý ForEach'le renklerin kodlarý ve adlarý:");
            Renk r = Renk.Sarý;
            foreach (int i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0} ({1})", i, Enum.GetName (r.GetType(), i));
            Console.WriteLine();
            foreach (int i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", Enum.GetName (r.GetType(), i), Enum.Format (typeof (Renk), i, "D"));
            Console.WriteLine();
            foreach (Renk i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", i, (int)i);
            Console.WriteLine();
            foreach (string a in Enum.GetNames (r.GetType())) Console.WriteLine ("Renk: {0}", a);
            Console.WriteLine();
            foreach (Renk i in Enum.GetValues (r.GetType())) Console.WriteLine ("Renk: {0}={1}", (int)i, (Renk) Enum.Parse (typeof (Renk), i.ToString(), true));

            Console.WriteLine ("\n{0} üyeli {1} tipli iþgören ad ve deðerleri:", Enum.GetValues (typeof (ÝþgörenTipi)).Length, Enum.GetUnderlyingType (typeof (ÝþgörenTipi)));
            for (byte i=0; i <= 100; i++) {if (Enum.IsDefined (typeof (ÝþgörenTipi), i)) Console.WriteLine("{0} ÝþgörenTipi'nin tanýmlý bir üyesi midir? {1}", i, Enum.IsDefined (typeof (ÝþgörenTipi), i) );}
            Console.WriteLine();
            foreach (byte i in Enum.GetValues (typeof (ÝþgörenTipi)) ) Console.WriteLine ("{0}={1}", Enum.GetName (typeof (ÝþgörenTipi), i), i);
            Console.WriteLine();
            foreach (ÝþgörenTipi i in Enum.GetValues (typeof (ÝþgörenTipi)) ) Console.WriteLine ("Üye adý: {0} dec({1})=hex({2})", i, Enum.Format (typeof (ÝþgörenTipi), i, "D"), Enum.Format (typeof (ÝþgörenTipi), i, "X") );

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}