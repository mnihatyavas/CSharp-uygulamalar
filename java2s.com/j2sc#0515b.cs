// j2sc#0515b.cs: StringBuilder'in Append, Insert, Remove, Replace, ToString metotlar� �rne�i.

using System;
using System.Text; //StringBuilder
namespace Dizgeler {
    class Dizge�n�ac�2 {
        static void Main() {
            Console.Write ("sb.Insert(knm,dizge,tekrar) metodu sb'nin knm'dan itibaren araya tekrar kez dizge yerle�tirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StringBuilder ile Append ve AppendFormat metotlar�:");
            StringBuilder sb1 = new StringBuilder();
            sb1.Append ("Arkada�lar�m�n say�s�: ");
            sb1.AppendFormat ("{0, 10:f3}", 1234.56789F);
            Console.WriteLine (sb1);
            Console.WriteLine ("sb1 = '{0}'\tuz = {1}", sb1, sb1.Length);

            Console.WriteLine ("\nStringBuilder ile Insert, Remove, Replace ve ToString metotlar�:");
            sb1 = new StringBuilder();
            sb1.Append ("arkada�lar�m");
            sb1.Insert (3, "ARKADA�LARIM, ");
            sb1.Insert (3, "Roman, ", 3);
            Console.WriteLine ("sb1 = '{0}'\tuz = {1}", sb1, sb1.Length);
            sb1.Remove (22, 6);
            Console.WriteLine ("sb1 = '{0}'\tuz = {1}", sb1, sb1.Length);
            sb1.Replace ("Roman", "�ingen");
            Console.WriteLine ("sb1 = '{0}'\tuz = {1}", sb1, sb1.Length);
            sb1.Replace ('�', 'C');
            Console.WriteLine ("sb1='{0}'\tuz={1}\ttip={2}", sb1, sb1.Length, sb1.GetType());
            string dizge1=sb1.ToString();
            Console.WriteLine ("dizge1='{0}'\tuz={1}\ttip={2}", dizge1, dizge1.Length, dizge1.GetType());

            Console.WriteLine ("\nStringBuilder ile g�ncel (dizgesel) tarih-zaman sunumu:");
            sb1 = new StringBuilder ("Tarih ve saat");
            sb1.AppendFormat (": {0}", DateTime.Now);
            dizge1 = sb1.ToString();
            Console.WriteLine ("{0}\tuz={1}\ttip={2}", dizge1, dizge1.Length, dizge1.GetType());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}