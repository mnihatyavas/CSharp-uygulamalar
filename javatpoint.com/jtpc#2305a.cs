// jtpc#2305a.cs: 'using static TamS�n�fAdl�Tip' direktifiyle ilgili �yelerinin do�rudan kullan�lmas� �rne�i.

using System;
//using static System.Math; //Statik direktifli tipler 
//using static System.String; //"csc 6" s�r�m gerektirmekte
namespace Yeni�zellikler {
    class StatikDirektif {
        static void Main() {
            Console.Write ("'using System' benzeri statik s�n�f �yelerini (de�i�ken ve metod) de s�n�f ads�z do�rudan �a��rmak istersek ait olduklar� s�n�f�l� tip 'using static TamS�n�fAdl�Tip' direktiflemeliyiz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            double krk1 = Math.Sqrt (Math.PI);
            string dzg1 = String.Concat ("mnihatyavas", "@", "gmail.com");
            Console.WriteLine ("Karek�k({0}) = {1}", Math.PI, krk1);
            Console.WriteLine ("Ekle(\"{0}\", \"{1}\", \"{2}\") = \"{3}\"", "mnihatyavas", "@", "gmail.com", dzg1);
/*
            double krk2 = Math.Sqrt (E); //Do�rudan E, Concat
            string dzg2 = Concat ("mnyavas", "@", "hotmail.com");
            Console.WriteLine ("Karek�k({0}) = {1}", E, krk2);
            Console.WriteLine ("Ekle(\"{0}\", \"{1}\", \"{2}\") = \"{3}\"", "mnyavas", "@", "hotmail.com", dzg2);
*/
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}