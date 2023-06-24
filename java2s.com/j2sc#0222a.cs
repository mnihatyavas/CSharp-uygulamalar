// j2sc#0222a.cs: Ondal�ktan bitsel-hex �evrimleri ve &|^~ i�lemler �rne�i.

using System;
using System.Collections;
namespace VeriTipleri {
    enum KahveKatk�lar� {Kahve, Kakao, S�t, �eker, Vanilya, Buz}
    class Kahve {
        public BitArray katk�lar = new BitArray (8);
        public void Katk�Ekle (KahveKatk�lar� katk�) {katk�lar [(int) katk�] = true;}
        public void Katk�lar�Listele() {
            for (int i = 0; i < katk�lar.Count; i++) {
                if (katk�lar [i]) Console.WriteLine ("-" + Enum.GetName (typeof (KahveKatk�lar�), i) );
            }
        }
        public void ��() {            
            katk�lar.Xor (katk�lar); //Katk�lar s�f�rlan�r
            Katk�lar�Listele(); //Katk� olmad���ndan liste (tekrar�) yok
        }
    }
    class Bitler1 {
        const string Bi�imleyici = "{0,2}{1,16}{2,20}";
        public static void GetBytesUInt32 (int n, uint a) {
            byte[] baytDizi = BitConverter.GetBytes (a);
            Console.WriteLine (Bi�imleyici, n, a, BitConverter.ToString (baytDizi) );
        }
        static void Main() {
            Console.Write ("�ki bitsel de�erle &=AND=VE, |=OR=VEYA, ^=XOR=FARKLIYSA, ~=NOT=DE��L i�lemleri yap�l�r. Sekizinci bit=1 ise de�er-256 sonu� negatif olur. Ayn� de�i�keni birbiriyle ^/XOR'lama de�i�ken de�erini s�f�rlar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bitsel VE, VEYA, FARKLIYSA i�lem sonu�lar�:");
            int b1=0x1, bsonu�=0;
            Console.WriteLine ("0x1 &:VE/AND 0x1 = {0}", (bsonu�=b1 & 0x1));
            Console.WriteLine ("0x1 |:VEYA/OR 0x2 = {0}", (bsonu�=b1 | 0x2));
            Console.WriteLine ("0x1 ^:FARKLIYSA/XOR 0x4 = {0}", (bsonu�=b1 ^ 0x4));
            Console.WriteLine ("DE��L/NOT ~0x5 = {0}", (~bsonu�)); //~00000101=11111010: 128+64+32+16+8+0+2+0=250: -256+250=-6

            var r=new Random(); int ts1=r.Next (0, 256);
            Console.WriteLine ("\n{0} tamsay�n�n bitvari kar��l���:", ts1);
            for (int i=128; i > 0; i=i/2) {if ((ts1 & i) != 0) Console.Write ("1 "); else Console.Write ("0 ");}

            var kahvem = new Kahve();
            kahvem.Katk�Ekle (KahveKatk�lar�.Kahve); kahvem.Katk�Ekle (KahveKatk�lar�.S�t); kahvem.Katk�Ekle (KahveKatk�lar�.�eker);
            Console.WriteLine ("\n\n{0}/{1} adet kahve katk�lar�n� listele ve i�:", 3, Enum.GetValues (typeof (KahveKatk�lar�)).Length);
            kahvem.Katk�lar�Listele(); kahvem.��();
            kahvem.Katk�Ekle (KahveKatk�lar�.Kakao); kahvem.Katk�Ekle (KahveKatk�lar�.S�t); kahvem.Katk�Ekle (KahveKatk�lar�.�eker); kahvem.Katk�Ekle (KahveKatk�lar�.Vanilya); kahvem.Katk�Ekle (KahveKatk�lar�.Buz);
            Console.WriteLine ("\n{0}/{1} adet kahve katk�lar�n� listele ve i�:", 5, Enum.GetValues (typeof (KahveKatk�lar�)).Length);
            kahvem.Katk�lar�Listele(); kahvem.��();

            Console.WriteLine ("\n10 rasgele uint32 ve bitsel-hex kar��l�klar�:");
            for (int i=1; i <= 10; i++) GetBytesUInt32 (i, (uint)r.Next (0, int.MaxValue));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}