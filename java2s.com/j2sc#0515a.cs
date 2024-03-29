// j2sc#0515a.cs: StringBuilder, metotları ve özellikleri örneği.

using System;
using System.Text; //StringBuilder
namespace Dizgeler {
    class Dizgeİnşacı1 {
        public static void ÖzellikleriGöster (string sbAdı, StringBuilder sb) {
            Console.WriteLine (sbAdı + ".Length = " + sb.Length);
            Console.WriteLine (sbAdı + ".Capacity = " + sb.Capacity);
            Console.WriteLine (sbAdı + ".MaxCapacity = " + sb.MaxCapacity);
        }
        static void Main() {
            Console.Write ("new StringBuilder ile yaratılan nesneye Append/Format'la ekleme, Remove/kırpma, Insert'le endekse girme, Replace'le yerdeğiştirme, ToString()'le dizgeselleştirme, Length/uzunluk, Capacity/kapasite, MaxCapacity/azami-kapasite ayarlanabilir. StringBuilder uzunluk/Length haricen değiştirilebilirken, string boyu Length ile değiştirilemez (read-only).\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            StringBuilder sb1 = new StringBuilder();
            Console.WriteLine ("StringBuilder sb1 ({0}={1}):", sb1.GetType(), typeof (StringBuilder));
            int ts1 = 2023, i;
            sb1.AppendFormat ("{0}={1} ", ts1++, "İkibin yirmidört"); Console.WriteLine ("{0}", sb1);
            sb1.Append (" / ").Append ("M.").Append ("Nihat "); sb1.Append ("Yavaş"); Console.WriteLine (sb1);
            string dizge1 = sb1.ToString(); Console.WriteLine ("sb1 ({0}: {1})\ndizge1 ({2}: {3})", sb1.GetType(), sb1, dizge1.GetType(), dizge1);

            Console.WriteLine ("\nStringBuilder ile new, Insert ve Append:");
            StringBuilder sb2 = new StringBuilder ("Selam");
            sb2.Insert (0, "Hey "); sb2.Append (" Herkese!");
            Console.WriteLine ("sb2 = {0}", sb2);

            Console.WriteLine ("\nStringBuilder ile dizgeyi tersleme:");
            dizge1 = "www.java2s.com";
            sb1 = new StringBuilder();
            for (i = dizge1.Length - 1; i > -1; i--) sb1.Append (dizge1 [i]);
            Console.WriteLine ("dizge1 = \"{0}\"\tsb1 = \"{1}\"", dizge1, sb1.ToString());

            Console.WriteLine ("\nStringBuilder nesne uzunluğu haricen değiştirilebilir:");
            sb1 = new StringBuilder ("M.Nihat Yavaş");
            dizge1 = sb1.ToString();
            ts1 = sb1.Length;
            Console.WriteLine ("sb1 = '{0}'\tuzn={1}", sb1, ts1);
            sb1.Length = 7; ts1 = sb1.Length;
            Console.WriteLine ("sb1 = '{0}'\tuzn={1}", sb1, ts1);
            sb1.Length = 20; ts1 = sb1.Length;
            Console.WriteLine ("sb1 = '{0}'\tuzn={1}", sb1, ts1);
            Console.WriteLine ("dizge1 = '{0}'\tuzn={1}", dizge1, dizge1.Length);
            dizge1=dizge1.Replace ("Yavaş", ""); Console.WriteLine ("dizge1 = '{0}'\tuzn={1}", dizge1, dizge1.Length);

            Console.WriteLine ("\nStringBuilder nesne özellikleri:");
            sb1 = new StringBuilder();
            int kapasite = 50;
            sb2 = new StringBuilder (kapasite);
            int azamiKapasite = 100;
            var sb3 = new StringBuilder (kapasite, azamiKapasite);
            dizge1="Ölmek yada ölmemek, işte enbüyük sorun!";
            var sb4 = new StringBuilder (dizge1);
            i=0;
            ts1=dizge1.Length;
            var sb5 = new StringBuilder (dizge1, i, ts1, kapasite);
            ÖzellikleriGöster ("sb1", sb1); //0, varsayılı=16, varsayılı=2147483647
            ÖzellikleriGöster ("sb2", sb2); //0, atanan=50, varsayılı=2147483647
            ÖzellikleriGöster ("sb3", sb3); //0, atanan=50, atanan=100
            ÖzellikleriGöster ("sb4", sb4); //39, hesaplanan=39, varsayılı=2147483647
            ÖzellikleriGöster ("sb5", sb5); //39, atanan=50, varsayılı=2147483647
            Console.WriteLine();
            dizge1="M.Nihat Yavaş"; ts1=dizge1.Length; sb4 = new StringBuilder (dizge1); sb5 = new StringBuilder (dizge1, i, ts1, kapasite);
            ÖzellikleriGöster ("sb1", sb1); //0, varsayılı=16, varsayılı=2147483647
            ÖzellikleriGöster ("sb2", sb2); //0, atanan=50, varsayılı=2147483647
            ÖzellikleriGöster ("sb3", sb3); //0, atanan=50, atanan=100
            ÖzellikleriGöster ("sb4", sb4); //13, varsayılı=16, varsayılı=2147483647
            ÖzellikleriGöster ("sb5", sb5); //13, atanan=50, varsayılı=2147483647

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}