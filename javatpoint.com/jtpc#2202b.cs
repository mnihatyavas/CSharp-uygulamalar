// jtpc#2202b.cs: DüzenliTabir kalýpla eþleþen eposta geçerliliði örneði.

using System;
using System.Text.RegularExpressions;
namespace Çeþitli {
    class DüzenliTabirB {
        static void Main() {
            Console.Write ("RegExp ile verilen eposta'nýn tanýmlanan kalýpla geçerliliði kontrol edilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kalýp = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            string eposta = "support@javatpoint.com"; Console.WriteLine ("[{0}] eposta adresi geçerli mi? [{1}]", eposta, Regex.IsMatch (eposta, kalýp) );
            eposta = "mnihatyavas@gmail.com"; Console.WriteLine ("[{0}] eposta adresi geçerli mi? [{1}]", eposta, Regex.IsMatch (eposta, kalýp) );
            eposta = "@gmail.com"; Console.WriteLine ("[{0}] eposta adresi geçerli mi? [{1}]", eposta, Regex.IsMatch (eposta, kalýp));
            eposta = "mnihatyavas@gmail.m"; Console.WriteLine ("[{0}] eposta adresi geçerli mi? [{1}]", eposta, Regex.IsMatch (eposta, kalýp));
            eposta = "mnihatyavas&gmail.com"; Console.WriteLine ("[{0}] eposta adresi geçerli mi? [{1}]", eposta, Regex.IsMatch (eposta, kalýp));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}