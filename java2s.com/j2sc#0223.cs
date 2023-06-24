// j2sc#0223.cs: Checked ve unchecked bloklar�yla say� ta�malar�na farkl� tutumlar �rne�i.

using System;
namespace VeriTipleri {
    class CheckedUnchecked {
        static int Topla (int x, int y) { return x + y;}
        static void Main() {
            Console.Write ("Varsay�l� checked'siz ve checked blo�u tamsay� �e�idinin enk���k/enb�y�k de�er ta�malar�na hata verirken, unchecked blo�u ise ta�an� % benzeri kalana kipleyerek hatas�z i�lemi s�rd�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            byte b1=127, b2=127, b3; int ts1;
            try {
                Console.WriteLine ("byte b1({0}) * byte b2({1}) = {2}", b1, b2, (b1 * b2));
                Console.WriteLine ("(byte b1({0}) * byte b2({1})) % 256 = {2}", b1, b2, ((b1 * b2) % 256) );
                b3 = unchecked ((byte) (b1 * b2));
                Console.WriteLine ("byte b3 = unchecked (byte b1({0}) * byte b2({1})) = {2}", b1, b2, b3);
                Console.WriteLine ("Ayn� i�lem 'checked()' ile de yap�l�yor...");
                b3 = checked ((byte) (b1 * b2)); //Ta�ma istisnas� f�rlat�r
                Console.WriteLine ("byte b3 = checked (byte b1({0}) * byte b2({1})) = {2}", b1, b2, b3);
            }catch (OverflowException hata) {Console.WriteLine ("HATA: [{0}]", hata);}

            b1=200; b2=201;
            try {
                Console.WriteLine ("\nbyte b1({0}) + byte b2({1}) = {2}", b1, b2, (b1 + b2));
                Console.WriteLine ("(byte b1({0}) + byte b2({1})) % 256 = {2}", b1, b2, ((b1 + b2) % 256) );
                b3 = unchecked ((byte) (b1 + b2));
                Console.WriteLine ("byte b3 = unchecked (byte b1({0}) + byte b2({1})) = {2}", b1, b2, b3);
                Console.WriteLine ("Ayn� i�lem 'checked()' ile de yap�l�yor...");
                b3 = checked ((byte) (b1 + b2)); //Ta�ma istisnas� f�rlat�r
                Console.WriteLine ("byte b3 = checked (byte b1({0}) + byte b2({1})) = {2}", b1, b2, b3);
            }catch (OverflowException hata) {Console.WriteLine ("HATA: [{0}]", hata.Message);}

            unchecked {
                Console.WriteLine ("\nEnk���k/enb�y�k unchecked int = ({0}, {1})", int.MinValue, int.MaxValue);
                ts1=int.MaxValue+1; Console.WriteLine ("int ts1=MaxValue+1 = {0} ?..", ts1);
                ts1=int.MinValue-1; Console.WriteLine ("int ts1=MinValue-1 = {0} ?..", ts1);
            }
            Console.WriteLine ("Ayn� i�lemler 'checked' ve checked'siz try-catch kiplerinde derleme hatas� verirler.");

            var r=new Random();
            short ss1, ss2, ss3;
            Console.WriteLine ("\nEnk���k/enb�y�k short = ({0}, {1})", short.MinValue, short.MaxValue);
            unchecked {
                for (int i=0; i<10; i++) {ss1=(short)r.Next (-30000, 30000); ss2=(short)r.Next (-50000, 50000);
                    ss3 = (short) Topla (ss1, ss2);
                    Console.WriteLine ("short({0}) + short({1}) = short({2})", ss1, ss2, ss3);
                }
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}