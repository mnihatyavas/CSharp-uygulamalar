// jtpc#1305.cs: SystemException ile sistemle ilgili istisnalar�n y�netimi �rne�i.

using System;
//public class SystemException: Exception{};// Sat�r ge�erlilenirse HATA-2 yakalar
namespace �stisnaY�netimi {
    class Systemexception {
        static void Main() {
            Console.Write ("SystemException yine Exception t�revi olup, sistem hatalar�na ValidationException, ArgumentException, ArithmeticException, DataException, StackOverflowException vb istisnalar� y�netir.\nKurucular�: SystemException(), SystemException(SerializationInfo,StreamingContext), SystemException(String), SystemException(String,Exception)\n�zellikleri: Data, HelpLink, HResult, InnerException, Message, Source, StackTrace, TargetSite\nMetodlar�: Equals(Object), Finalize(), GetBaseException(), GetHashCode(), GetObjectData(SerializationInfo,StreamingContext, GetType(), MemberwiseClone(), ToString()\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int[] dizi = new int [5]; int r;
                checked {Console.WriteLine (r = new Random().Next (-10, 10) + int.MaxValue);}
                dizi [10] = r; //Rasgele tamsay� ta�mas� veya endeks kapsam d���l��� hatas� verecektir.
            }catch (SystemException hata) {Console.WriteLine ("HATA-1: [{0}]", hata);
            }catch (Exception hata) {Console.WriteLine ("HATA-2: [{0}]", hata);}

            Console.WriteLine ("\nNormal program ak���na devam"); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}