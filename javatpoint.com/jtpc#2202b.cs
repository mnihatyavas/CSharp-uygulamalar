// jtpc#2202b.cs: D�zenliTabir kal�pla e�le�en eposta ge�erlili�i �rne�i.

using System;
using System.Text.RegularExpressions;
namespace �e�itli {
    class D�zenliTabirB {
        static void Main() {
            Console.Write ("RegExp ile verilen eposta'n�n tan�mlanan kal�pla ge�erlili�i kontrol edilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kal�p = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            string eposta = "support@javatpoint.com"; Console.WriteLine ("[{0}] eposta adresi ge�erli mi? [{1}]", eposta, Regex.IsMatch (eposta, kal�p) );
            eposta = "mnihatyavas@gmail.com"; Console.WriteLine ("[{0}] eposta adresi ge�erli mi? [{1}]", eposta, Regex.IsMatch (eposta, kal�p) );
            eposta = "@gmail.com"; Console.WriteLine ("[{0}] eposta adresi ge�erli mi? [{1}]", eposta, Regex.IsMatch (eposta, kal�p));
            eposta = "mnihatyavas@gmail.m"; Console.WriteLine ("[{0}] eposta adresi ge�erli mi? [{1}]", eposta, Regex.IsMatch (eposta, kal�p));
            eposta = "mnihatyavas&gmail.com"; Console.WriteLine ("[{0}] eposta adresi ge�erli mi? [{1}]", eposta, Regex.IsMatch (eposta, kal�p));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}