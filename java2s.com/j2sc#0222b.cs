// j2sc#0222b.cs: Ýki sayýnýn AND-&'lenmesi ve bitsel sola-çarp/saða-böl kaydýrma örneði.

using System;
namespace VeriTipleri {
    class Bitler2{
        static void Main() {
            Console.Write ("Ýki sayý bitsel AND=&'lenirse sadece karþýlýklý 1'ler 1, diðerleri (00, 01, 10) sýfýrlanýr. Sola/saða kaydýrmalar, sayýnýn 2^n ile çarpýmýna/bölümüne eþittir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            byte b1 = 0x9a;  // binary 10011010, decimal 154
            byte b2 = 0xdb;  // binary 11011011, decimal 219
            Console.WriteLine ("b1({0}) & b2({1}) = {2}",
                BitConverter.ToString (BitConverter.GetBytes (b1)), BitConverter.ToString (BitConverter.GetBytes (b2)), (byte)(b1 & b2));
            Console.WriteLine ("b1({0:X}) & b2({1:X}) = {2}", b1, b2, (byte)(b1 & b2));
            b1=(byte)r.Next (0, 256); b2=(byte)r.Next (0, 256);
            Console.WriteLine ("b1({0:X}:{0}) & b2({1:X}:{1}) = {2:X}:{2}", b1, b2, (byte)(b1 & b2));

            Console.WriteLine ("\n10-->21 & 0xFFFE:"); //FE=1111 1110
            for (byte i = 10; i <= 21; i++) Console.WriteLine ("{0} & 0xFFFE = {1}:{1:X} ==>{2}", i, (ushort) (i & 0xFFFE), ((i & 1) == 1 ? "Tek sayý" : "Çift sayý"));

            Console.WriteLine ("\n8X8'lik 1,2,4,8,16,32,64,128 bit deðerli matris:");
            int ts1 = 1; string s1="";
            for (int i = 0; i < 8; i++) {
                for (int j=128; j > 0; j /=2) {if ((ts1 & j) != 0) s1 +="1 "; else s1+="0 ";}
                Console.WriteLine (s1);
                s1="";
                ts1=ts1<<1; //Sola 1 kaydýr
            }

            Console.WriteLine ("\n8X8'lik 128,64,32,16,8,4,2,1 bit deðerli matris:");
            ts1 = 128; s1="";
            for (int i = 0; i < 8; i++) {
                for (int j=128; j > 0; j /=2) {if ((ts1 & j) != 0) s1 +="1 "; else s1+="0 ";}
                Console.WriteLine (s1);
                s1="";
                ts1=ts1>>1; //Saða 1 kaydýr
            }

            ts1=10;
            Console.WriteLine ("\nBitsel sola-saða kaydýrmalý çarpma-bölme:");
            Console.WriteLine ("n:{0} * 2 = n=n<<1: {1}", ts1, (ts1=ts1<<1));
            Console.WriteLine ("n:{0} * 4 = n=n<<2: {1}", ts1, (ts1=ts1<<2));
            Console.WriteLine ("n:{0} * 8 = n=n<<3: {1}", ts1, (ts1=ts1<<3));
            Console.WriteLine ("n:{0} / 2 = n=n>>1: {1}", ts1, (ts1=ts1>>1));
            Console.WriteLine ("n:{0} / 4 = n=n>>2: {1}", ts1, (ts1=ts1>>2));
            Console.WriteLine ("n:{0} / 8 = n=n>>3: {1}", ts1, (ts1=ts1>>3));
            Console.WriteLine ("n:{0} * 2^30 = n=n<<30: {1} ==>-Bilgi kaybý", (ts1=10), (ts1=ts1<<30));

            Console.WriteLine ("\nBilgi kayýpsýz, bitsel sola kaydýrmalý azami long çarpma:");
            long ls1=2; ts1=0;
            while (ls1 > 0) {Console.Write ("n:{0}, m:{1}; n<<m = {2}:{2:X} ==>", ls1, ++ts1, (ls1=ls1<<ts1));}

            b1=b2=(byte)r.Next (0, 256);
            Console.WriteLine ("\n\nByte sayý=({0}:{0:X}) saða-8 ve sola-8 kaydýrma:", b1);
            for (int i=1; i<=8; i++) Console.WriteLine ("b1({0}) << i({1}) = {2}:{2:X}", b1, i, (byte)(b1<<i)); Console.WriteLine();
            for (int i=1; i<=8; i++) Console.WriteLine ("b2({0}) >> i({1}) = {2}:{2:X}", b2, i, (byte)(b2>>i));
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}