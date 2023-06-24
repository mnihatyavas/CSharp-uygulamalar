// j2sc#0223.cs: Checked ve unchecked bloklarýyla sayý taþmalarýna farklý tutumlar örneði.

using System;
namespace VeriTipleri {
    class CheckedUnchecked {
        static int Topla (int x, int y) { return x + y;}
        static void Main() {
            Console.Write ("Varsayýlý checked'siz ve checked bloðu tamsayý çeþidinin enküçük/enbüyük deðer taþmalarýna hata verirken, unchecked bloðu ise taþaný % benzeri kalana kipleyerek hatasýz iþlemi sürdürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            byte b1=127, b2=127, b3; int ts1;
            try {
                Console.WriteLine ("byte b1({0}) * byte b2({1}) = {2}", b1, b2, (b1 * b2));
                Console.WriteLine ("(byte b1({0}) * byte b2({1})) % 256 = {2}", b1, b2, ((b1 * b2) % 256) );
                b3 = unchecked ((byte) (b1 * b2));
                Console.WriteLine ("byte b3 = unchecked (byte b1({0}) * byte b2({1})) = {2}", b1, b2, b3);
                Console.WriteLine ("Ayný iþlem 'checked()' ile de yapýlýyor...");
                b3 = checked ((byte) (b1 * b2)); //Taþma istisnasý fýrlatýr
                Console.WriteLine ("byte b3 = checked (byte b1({0}) * byte b2({1})) = {2}", b1, b2, b3);
            }catch (OverflowException hata) {Console.WriteLine ("HATA: [{0}]", hata);}

            b1=200; b2=201;
            try {
                Console.WriteLine ("\nbyte b1({0}) + byte b2({1}) = {2}", b1, b2, (b1 + b2));
                Console.WriteLine ("(byte b1({0}) + byte b2({1})) % 256 = {2}", b1, b2, ((b1 + b2) % 256) );
                b3 = unchecked ((byte) (b1 + b2));
                Console.WriteLine ("byte b3 = unchecked (byte b1({0}) + byte b2({1})) = {2}", b1, b2, b3);
                Console.WriteLine ("Ayný iþlem 'checked()' ile de yapýlýyor...");
                b3 = checked ((byte) (b1 + b2)); //Taþma istisnasý fýrlatýr
                Console.WriteLine ("byte b3 = checked (byte b1({0}) + byte b2({1})) = {2}", b1, b2, b3);
            }catch (OverflowException hata) {Console.WriteLine ("HATA: [{0}]", hata.Message);}

            unchecked {
                Console.WriteLine ("\nEnküçük/enbüyük unchecked int = ({0}, {1})", int.MinValue, int.MaxValue);
                ts1=int.MaxValue+1; Console.WriteLine ("int ts1=MaxValue+1 = {0} ?..", ts1);
                ts1=int.MinValue-1; Console.WriteLine ("int ts1=MinValue-1 = {0} ?..", ts1);
            }
            Console.WriteLine ("Ayný iþlemler 'checked' ve checked'siz try-catch kiplerinde derleme hatasý verirler.");

            var r=new Random();
            short ss1, ss2, ss3;
            Console.WriteLine ("\nEnküçük/enbüyük short = ({0}, {1})", short.MinValue, short.MaxValue);
            unchecked {
                for (int i=0; i<10; i++) {ss1=(short)r.Next (-30000, 30000); ss2=(short)r.Next (-50000, 50000);
                    ss3 = (short) Topla (ss1, ss2);
                    Console.WriteLine ("short({0}) + short({1}) = short({2})", ss1, ss2, ss3);
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}