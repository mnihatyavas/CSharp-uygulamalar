// j2sc#0316.cs: Ar�iv yada �zel tan�ml� tipin byte ebat� sizeof �rne�i.
// unsafe kodlamalar: ">>csc /unsafe �rnek.cs" se�enekli derlenir. Kodlamada ya metod sat�r�nda, yada metod i�i �zel blok'ta "unsafe" beyan� gerekir.

using System;
namespace ��lemciler {
    struct Yap� {
        public short s;
        public int i;
        public long l;
    }
    class S�n�f {private int no; public string ad;}
    class sizeof_��lemci {
        static unsafe void Main() {
            Console.Write ("sizeof(tip) i�lemcisi ar�iv yada �zel tipin byte ebat�n� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("sizeof i�lemcili tip ebatlar�:");
            Console.WriteLine ("(bool, short, char, int, long, float, double, decimal) ebatlar� = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) BYTE", sizeof (bool), sizeof (short), sizeof (char), sizeof (int), sizeof (long), sizeof (float), sizeof (double), sizeof (decimal));
            Console.WriteLine ("sizeof (Yap�) = {0} BYTE", sizeof (Yap�));
            //Console.WriteLine ("sizeof (S�n�f) = {0} BYTE", sizeof (S�n�f));//sizeof(class) hata...

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}