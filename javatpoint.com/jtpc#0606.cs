// jtpc#0606.cs: 'static' sýnýfýn sadece statik üyeleri ve tiplemesiz iþletilebilmesi örneði.

using System;
namespace NesneSýnýfý {
    public static class ÖzelMath {
        //public int ts = 2023; //Derleme hatasý
        public static double PI=3.141592653589793d;
        public static double E=2.718281828459045d;
        public static int küp (int n) {return n*n*n;}
        public static double karekök (double n) {return Math.Sqrt (n);}
    }
    class StatikSýnýf {
        static void Main() {
            Console.Write ("'static' sýnýf içinde sadece statik üye tanýmlanabilir ve tiplenemez (derleme hatasý).\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            //Console.WriteLine (new ÖzelMath().küp (3)); //Derleme hatasý
            Console.WriteLine ("Çember çevresi/çapý: Pi = [{0}]", ÖzelMath.PI);
            Console.WriteLine ("Doðal logaritmik taban E = [{0}]", ÖzelMath.E);
            Console.WriteLine ("2'nin küpü= [{0}]", ÖzelMath.küp (2));
            Console.WriteLine ("2'nin karekökü= [{0}]", ÖzelMath.karekök (2d));

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}