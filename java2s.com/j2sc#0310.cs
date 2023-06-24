// j2sc#0310.cs: Bitsel sola (a<<=b) ve sa�a (a>>=b) kayd�rma �rne�i.

using System;
namespace ��lemciler {
    class Kayd�ran��lemci {
        static void Main() {
            Console.Write ("Sola herbir kayd�rma:<< say�y� 2'yle �arpar, sa�aysa:>> 2'ye b�ler (solu i�aretsizde 0'la, i�aretlide i�aret-bit'le doldurur).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            int a=r.Next(1, 1000), b=r.Next(1, 5), i;
            Console.WriteLine ("Sola kayd�rma: {0}:{0:X} << {1} <= {2:#,###}", a, b, int.MaxValue);
            for (i=0;;i++) {if ((a<<=b) < 0) break; Console.WriteLine ("{0}) {1}:{1:X}", i, a);}

            a=r.Next(10000, int.MaxValue); b=r.Next(1, 5);
            Console.WriteLine ("\nSa�a kayd�rma: {0}:{0:X} >> {1} > 0", a, b);
            for (i=0;;i++) {if ((a>>=b) <= 0) break; Console.WriteLine ("{0}) {1}:{1:X}", i, a);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}