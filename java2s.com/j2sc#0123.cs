// j2sc#0123.cs: Odakl� istisna y�netimiyle sorun ��zme �rne�i.

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace DilTemelleri {
    [assembly: RuntimeCompatibility (WrapNonExceptionThrows = false)]
    class �ntan�ml��stisna {
        static void Main() {
            Console.Write ("Genel 'Exception' yerine ondan t�revli odaklanm�� istisna kontroluyla, olu�abilecek sorunlar, daha makul ��z�mler kullan�larak y�netilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string dizge = null;
            try {Console.WriteLine ("Dizge de�eri: [{0}]", dizge.ToString());      
            }catch {Console.WriteLine ("Namalum bir hata yakalad�.");}

            try {Console.WriteLine ("Dizge de�eri: [{0}]", dizge.ToString());      
            }catch (Exception) {Console.WriteLine ("\nGenel bir istisna yakalad�.");}

            try {Console.WriteLine ("Dizge de�eri: [{0}]", dizge.ToString());      
            }catch (Exception hata) {Console.WriteLine ("\nYakalanan genel istisna: [{0}]", hata);}

            try {Console.WriteLine ("Dizge de�eri: [{0}]", dizge.ToString());      
            }catch (NullReferenceException h) {Console.WriteLine ("\nYakalanan odakl� (NullReferenceException) istisna mesaj�: [{0}]", h.Message);}

            try {if (dizge == null) {var ist = new ArgumentNullException(); throw ist;}
            }catch (ArgumentNullException h) {Console.WriteLine ("\nF�rlat�lan odakl� (ArgumentNullException) istisna mesaj�: [{0}]", h.Message);}

            try {var liste = new ArrayList();
                liste.Add (1881); liste.Add (1938); liste.Add (2023);
                Console.WriteLine ("\nListenin mevcut 3 eleman� = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                Console.WriteLine ("Listenin namevcut 10.ncu eleman� = {0}", liste [9]); //Hata f�rlat�r
            }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("[{0}]", h); Console.WriteLine ("ArgumentOutOfRangeException Y�netimi"); //�zelden genele istisna yakalama
            }catch (Exception h) {Console.WriteLine ("[{0}]", h); Console.WriteLine ("Exception Y�netimi");
            }catch {Console.WriteLine ("�ok istisnai bir istisna..."); Console.WriteLine ("�stisnai�stisna Y�netimi");
            }finally {Console.WriteLine ("Bellek temizli�i...");}

            int ts = 1234567890;
            long tsUzun1=ts, tsUzun2=ts;
            try {tsUzun1 = checked ((long)ts * 7470931417);
                tsUzun2 = (long)ts * 7470931418; //Ta�ma hatas�
                Console.WriteLine ("\nint ts = {0}\nlong tsUzun1 = {1}\nlong tsUzun2 = {2}", ts, tsUzun1, tsUzun2);
                if (tsUzun2 < 0) throw new OverflowException ("Uzun tamsay� ta�ma hatas�");
            }catch (OverflowException h) {Console.WriteLine ("HATA: [{0}]", h);}

            int[] tsDizi = {10, 20, 35}; int s�f�r=0;
            try {Console.WriteLine ("\nTry i�i hi�bir istisna �retilmeden �nce...");
                for (int i=0; i < 10; i++) {
                    try {tsDizi [i] /=s�f�r;
                        Console.WriteLine ("Buraya hi� ula��lmaz");
                    }catch (DivideByZeroException) {Console.WriteLine ("(For d�ng� kesintisiz) S�f�ra b�l�m istisnas� �retildi");}
                }
            }catch (IndexOutOfRangeException h) {
                Console.WriteLine ("(For d�ng� kesintili) Dizi endeks ta�ma istisnas� �retildi");
                Console.WriteLine ("Mesaj: {0}", h.Message);
                Console.WriteLine ("Kaynak: {0}.cs", h.Source);
                Console.WriteLine ("Y���n: {0}", h.StackTrace);
            }
            Console.WriteLine ("��i�e try-catch y�netimi sonras�...");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}