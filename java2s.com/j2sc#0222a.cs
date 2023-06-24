// j2sc#0222a.cs: Ondalıktan bitsel-hex çevrimleri ve &|^~ işlemler örneği.

using System;
using System.Collections;
namespace VeriTipleri {
    enum KahveKatkıları {Kahve, Kakao, Süt, Şeker, Vanilya, Buz}
    class Kahve {
        public BitArray katkılar = new BitArray (8);
        public void KatkıEkle (KahveKatkıları katkı) {katkılar [(int) katkı] = true;}
        public void KatkılarıListele() {
            for (int i = 0; i < katkılar.Count; i++) {
                if (katkılar [i]) Console.WriteLine ("-" + Enum.GetName (typeof (KahveKatkıları), i) );
            }
        }
        public void İç() {            
            katkılar.Xor (katkılar); //Katkılar sıfırlanır
            KatkılarıListele(); //Katkı olmadığından liste (tekrarı) yok
        }
    }
    class Bitler1 {
        const string Biçimleyici = "{0,2}{1,16}{2,20}";
        public static void GetBytesUInt32 (int n, uint a) {
            byte[] baytDizi = BitConverter.GetBytes (a);
            Console.WriteLine (Biçimleyici, n, a, BitConverter.ToString (baytDizi) );
        }
        static void Main() {
            Console.Write ("İki bitsel değerle &=AND=VE, |=OR=VEYA, ^=XOR=FARKLIYSA, ~=NOT=DEĞİL işlemleri yapılır. Sekizinci bit=1 ise değer-256 sonuç negatif olur. Aynı değişkeni birbiriyle ^/XOR'lama değişken değerini sıfırlar.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bitsel VE, VEYA, FARKLIYSA işlem sonuçları:");
            int b1=0x1, bsonuç=0;
            Console.WriteLine ("0x1 &:VE/AND 0x1 = {0}", (bsonuç=b1 & 0x1));
            Console.WriteLine ("0x1 |:VEYA/OR 0x2 = {0}", (bsonuç=b1 | 0x2));
            Console.WriteLine ("0x1 ^:FARKLIYSA/XOR 0x4 = {0}", (bsonuç=b1 ^ 0x4));
            Console.WriteLine ("DEĞİL/NOT ~0x5 = {0}", (~bsonuç)); //~00000101=11111010: 128+64+32+16+8+0+2+0=250: -256+250=-6

            var r=new Random(); int ts1=r.Next (0, 256);
            Console.WriteLine ("\n{0} tamsayının bitvari karşılığı:", ts1);
            for (int i=128; i > 0; i=i/2) {if ((ts1 & i) != 0) Console.Write ("1 "); else Console.Write ("0 ");}

            var kahvem = new Kahve();
            kahvem.KatkıEkle (KahveKatkıları.Kahve); kahvem.KatkıEkle (KahveKatkıları.Süt); kahvem.KatkıEkle (KahveKatkıları.Şeker);
            Console.WriteLine ("\n\n{0}/{1} adet kahve katkılarını listele ve iç:", 3, Enum.GetValues (typeof (KahveKatkıları)).Length);
            kahvem.KatkılarıListele(); kahvem.İç();
            kahvem.KatkıEkle (KahveKatkıları.Kakao); kahvem.KatkıEkle (KahveKatkıları.Süt); kahvem.KatkıEkle (KahveKatkıları.Şeker); kahvem.KatkıEkle (KahveKatkıları.Vanilya); kahvem.KatkıEkle (KahveKatkıları.Buz);
            Console.WriteLine ("\n{0}/{1} adet kahve katkılarını listele ve iç:", 5, Enum.GetValues (typeof (KahveKatkıları)).Length);
            kahvem.KatkılarıListele(); kahvem.İç();

            Console.WriteLine ("\n10 rasgele uint32 ve bitsel-hex karşılıkları:");
            for (int i=1; i <= 10; i++) GetBytesUInt32 (i, (uint)r.Next (0, int.MaxValue));

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}