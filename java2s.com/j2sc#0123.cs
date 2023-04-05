// j2sc#0123.cs: Odaklý istisna yönetimiyle sorun çözme örneði.

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace DilTemelleri {
    [assembly: RuntimeCompatibility (WrapNonExceptionThrows = false)]
    class ÖntanýmlýÝstisna {
        static void Main() {
            Console.Write ("Genel 'Exception' yerine ondan türevli odaklanmýþ istisna kontroluyla, oluþabilecek sorunlar, daha makul çözümler kullanýlarak yönetilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string dizge = null;
            try {Console.WriteLine ("Dizge deðeri: [{0}]", dizge.ToString());      
            }catch {Console.WriteLine ("Namalum bir hata yakaladý.");}

            try {Console.WriteLine ("Dizge deðeri: [{0}]", dizge.ToString());      
            }catch (Exception) {Console.WriteLine ("\nGenel bir istisna yakaladý.");}

            try {Console.WriteLine ("Dizge deðeri: [{0}]", dizge.ToString());      
            }catch (Exception hata) {Console.WriteLine ("\nYakalanan genel istisna: [{0}]", hata);}

            try {Console.WriteLine ("Dizge deðeri: [{0}]", dizge.ToString());      
            }catch (NullReferenceException h) {Console.WriteLine ("\nYakalanan odaklý (NullReferenceException) istisna mesajý: [{0}]", h.Message);}

            try {if (dizge == null) {var ist = new ArgumentNullException(); throw ist;}
            }catch (ArgumentNullException h) {Console.WriteLine ("\nFýrlatýlan odaklý (ArgumentNullException) istisna mesajý: [{0}]", h.Message);}

            try {var liste = new ArrayList();
                liste.Add (1881); liste.Add (1938); liste.Add (2023);
                Console.WriteLine ("\nListenin mevcut 3 elemaný = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                Console.WriteLine ("Listenin namevcut 10.ncu elemaný = {0}", liste [9]); //Hata fýrlatýr
            }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("[{0}]", h); Console.WriteLine ("ArgumentOutOfRangeException Yönetimi"); //Özelden genele istisna yakalama
            }catch (Exception h) {Console.WriteLine ("[{0}]", h); Console.WriteLine ("Exception Yönetimi");
            }catch {Console.WriteLine ("Çok istisnai bir istisna..."); Console.WriteLine ("ÝstisnaiÝstisna Yönetimi");
            }finally {Console.WriteLine ("Bellek temizliði...");}

            int ts = 1234567890;
            long tsUzun1=ts, tsUzun2=ts;
            try {tsUzun1 = checked ((long)ts * 7470931417);
                tsUzun2 = (long)ts * 7470931418; //Taþma hatasý
                Console.WriteLine ("\nint ts = {0}\nlong tsUzun1 = {1}\nlong tsUzun2 = {2}", ts, tsUzun1, tsUzun2);
                if (tsUzun2 < 0) throw new OverflowException ("Uzun tamsayý taþma hatasý");
            }catch (OverflowException h) {Console.WriteLine ("HATA: [{0}]", h);}

            int[] tsDizi = {10, 20, 35}; int sýfýr=0;
            try {Console.WriteLine ("\nTry içi hiçbir istisna üretilmeden önce...");
                for (int i=0; i < 10; i++) {
                    try {tsDizi [i] /=sýfýr;
                        Console.WriteLine ("Buraya hiç ulaþýlmaz");
                    }catch (DivideByZeroException) {Console.WriteLine ("(For döngü kesintisiz) Sýfýra bölüm istisnasý üretildi");}
                }
            }catch (IndexOutOfRangeException h) {
                Console.WriteLine ("(For döngü kesintili) Dizi endeks taþma istisnasý üretildi");
                Console.WriteLine ("Mesaj: {0}", h.Message);
                Console.WriteLine ("Kaynak: {0}.cs", h.Source);
                Console.WriteLine ("Yýðýn: {0}", h.StackTrace);
            }
            Console.WriteLine ("Ýçiçe try-catch yönetimi sonrasý...");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}