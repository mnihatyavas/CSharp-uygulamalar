// jtpc#1305.cs: SystemException ile sistemle ilgili istisnalarýn yönetimi örneði.

using System;
//public class SystemException: Exception{};// Satýr geçerlilenirse HATA-2 yakalar
namespace ÝstisnaYönetimi {
    class Systemexception {
        static void Main() {
            Console.Write ("SystemException yine Exception türevi olup, sistem hatalarýna ValidationException, ArgumentException, ArithmeticException, DataException, StackOverflowException vb istisnalarý yönetir.\nKurucularý: SystemException(), SystemException(SerializationInfo,StreamingContext), SystemException(String), SystemException(String,Exception)\nÖzellikleri: Data, HelpLink, HResult, InnerException, Message, Source, StackTrace, TargetSite\nMetodlarý: Equals(Object), Finalize(), GetBaseException(), GetHashCode(), GetObjectData(SerializationInfo,StreamingContext, GetType(), MemberwiseClone(), ToString()\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int[] dizi = new int [5]; int r;
                checked {Console.WriteLine (r = new Random().Next (-10, 10) + int.MaxValue);}
                dizi [10] = r; //Rasgele tamsayý taþmasý veya endeks kapsam dýþýlýðý hatasý verecektir.
            }catch (SystemException hata) {Console.WriteLine ("HATA-1: [{0}]", hata);
            }catch (Exception hata) {Console.WriteLine ("HATA-2: [{0}]", hata);}

            Console.WriteLine ("\nNormal program akýþýna devam"); 

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}