// jtpc#2305a.cs: 'using static TamSýnýfAdlýTip' direktifiyle ilgili üyelerinin doðrudan kullanýlmasý örneði.

using System;
//using static System.Math; //Statik direktifli tipler 
//using static System.String; //"csc 6" sürüm gerektirmekte
namespace YeniÖzellikler {
    class StatikDirektif {
        static void Main() {
            Console.Write ("'using System' benzeri statik sýnýf üyelerini (deðiþken ve metod) de sýnýf adsýz doðrudan çaðýrmak istersek ait olduklarý sýnýfýlý tip 'using static TamSýnýfAdlýTip' direktiflemeliyiz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            double krk1 = Math.Sqrt (Math.PI);
            string dzg1 = String.Concat ("mnihatyavas", "@", "gmail.com");
            Console.WriteLine ("Karekök({0}) = {1}", Math.PI, krk1);
            Console.WriteLine ("Ekle(\"{0}\", \"{1}\", \"{2}\") = \"{3}\"", "mnihatyavas", "@", "gmail.com", dzg1);
/*
            double krk2 = Math.Sqrt (E); //Doðrudan E, Concat
            string dzg2 = Concat ("mnyavas", "@", "hotmail.com");
            Console.WriteLine ("Karekök({0}) = {1}", E, krk2);
            Console.WriteLine ("Ekle(\"{0}\", \"{1}\", \"{2}\") = \"{3}\"", "mnyavas", "@", "hotmail.com", dzg2);
*/
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}