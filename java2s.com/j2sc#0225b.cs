// j2sc#0225b.cs: Parse(), TryParse(), Convert.To/From, BitConverter() sayýsala çeviriciler örneði.

using System;
namespace VeriTipleri {
    class DizgeselÇevrimler2 {
        const string biçimleyici = "\t{0,14}{1,14}";
        public static void GetBytesUInt32 (uint a) {
            byte[] bd = BitConverter.GetBytes (a);
            Console.WriteLine (biçimleyici, a, BitConverter.ToString (bd) );
        }
        static void Main() {
            Console.Write ("Parse(), TryParse(), Convert.To/From, BitConverter() metotlarý sayýsala çevrim yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=0;
            try {ts1=int.Parse ("2023");
            }catch {Console.WriteLine ("Hatalý tamsayý giriþi");}
            Console.WriteLine ("Dizgeden tamsayýya Parse çevrim = {0}", ts1);

            GÝR1: Console.Write ("\nBir tamsayý gir: ");
            if (int.TryParse (Console.ReadLine(), out ts1)) Console.WriteLine ("Girdiðiniz tamsayý = {0}", ts1);
            else {Console.WriteLine ("Hatalý giriþ, tekrar dene"); goto GÝR1;}

            string dzg1 = "2023.0524"; //Nokta ayraçlý
            double ds1 = Convert.ToDouble (dzg1);
            bool bl1 = Convert.ToBoolean (ds1);
            Console.WriteLine ("\nDizgeden ({0}) double sayýya çevrim = {1}", dzg1, ds1);
            Console.WriteLine ("Double sayýdan ({0}) bool'a çevrim = {1}", ds1, bl1);

            dzg1 = "2023,0524"; //Virgül ayraçlý
            ds1 = Convert.ToDouble (dzg1);
            bl1 = Convert.ToBoolean (ds1);
            Console.WriteLine ("\nDizgeden ({0}) double sayýya çevrim = {1}", dzg1, ds1);
            Console.WriteLine ("Double sayýdan ({0}) bool'a çevrim = {1}", ds1, bl1);

            bl1 = bool.Parse ("False"); Console.WriteLine ("\nbool.Parse(\"False\"): {0}", bl1);
            ds1 = double.Parse ("1955,0807"); Console.WriteLine ("double.Parse(\"1955,0807\"): {0}", ds1);
            ts1 = int.Parse ("1881"); Console.WriteLine ("int.Parse(\"1881\"): {0}", ts1);
            char krk1 = char.Parse ("W"); Console.WriteLine ("char.Parse(\"W\"): {0}", krk1);

            byte[] bd1 = new byte [256];
            byte[] bd2 = new byte [256];
            char[] kd  = new char [352];
            Console.WriteLine ("\nUzunluk: (byteDizi1, byteDizi2, charDixi) = ({0}, {1}, {2})", bd1.Length, bd2.Length, kd.Length);
            Console.WriteLine ("{0} adet byteDizi1 elemanlarý:", bd1.Length);
            for (int x = 0; x < bd1.Length; x++) {
                bd1 [x] = (byte)x;
                Console.Write ("{0:X2}={1} ", bd1 [x], (char)bd1 [x]);
            }
            int kdUzn = Convert.ToBase64CharArray (bd1, 0, bd1.Length, kd, 0, Base64FormattingOptions.InsertLineBreaks);
            Console.WriteLine ("\n{0} uzunluktaki charDizi'ye kopyalananan {1} adet byteDizi1 elemanlarý:", kdUzn, bd1.Length);
            Console.WriteLine ("{0}", new String (kd));
            bd2 = Convert.FromBase64CharArray (kd, 0, kd.Length);
            Console.WriteLine ("charDizi'den kopyalanan {0} adet byteDizi2 elemanlarý:", bd2.Length);
            for (int x = 0; x < bd2.Length; x++) {Console.Write ("{0:X2}={1} ", bd2 [x], (char)bd2 [x]);}

            var r=new Random();
            Console.WriteLine ("\n\n10 adet tamsayý ve BitConverter.GetBytes(ts)'nýn FF-FF-FF-FF biçimi:");
            for (int i=1; i <= 10; i++) GetBytesUInt32 ((uint)r.Next (0, int.MaxValue));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}