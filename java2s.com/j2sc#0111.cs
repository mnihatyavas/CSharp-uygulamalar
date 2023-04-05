// j2sc#0111.cs: Metod ref parametreleriyle karþýlýklý çoklu deðer aktarýmý örneði.

using System;
namespace DilTemelleri {
    class RefDeneme1 {
        public void RefsizTakas (int x, int y) {
            Console.WriteLine ("'RefsizTakas()' metodu içinde ilk durum: x = " + x + ", y = " + y);
            int aracý = x;
            x = y;
            y = aracý;
            Console.WriteLine ("'RefsizTakas()' metodu içinde son durum: x = " + x + ", y = " + y);
        }
        public void Karekök (ref double n) {n = Math.Sqrt (n);}
        public void Takas (ref int a, ref int b) {
            int aracý;
            aracý = a;
            a = b;
            b = aracý;
        }
        public static void BüyükHarf (ref string d) {d = d.ToUpper();}
        public void DaireKüre1 (double y, out double çevre, out double alan, out double küreAlan, out double küreHacim) {
            double pi = Math.PI;
            çevre = 2 * pi * y;
            alan = pi * y * y;
            küreAlan = 4 * pi *  y * y;
            küreHacim = 4 / 3 * pi * y * y * y;
        }
        public void DaireKüre2 (double y, ref double çevre, ref double alan, ref double küreAlan, ref double küreHacim) {
            double pi = Math.PI;
            çevre = 2 * pi * y;
            alan = pi * y * y;
            küreAlan = 4 * pi *  y * y;
            küreHacim = 4 / 3 * pi * y * y * y;
        }
    }
    class RefDeneme2 {
        public int a, b;
        public RefDeneme2 (int i, int j) {a = i; b = j;}
        public void Takas (ref RefDeneme2 ns1, ref RefDeneme2 ns2) {
            RefDeneme2 aracý;
            aracý = ns1;
            ns1 = ns2;
            ns2 = aracý;
        }
    }
    class Ref {
        static void Main() {
            Console.Write ("Çaðýran metodun argüman ve çaðrýlan metodun parametre-leri önündeki 'ref' anahtarkelimesi tekyönlü deðeraktarma yerine ayný hafýza adresini referanslayarak karþýlýklý ve (return'süz) çoklu (her tip) deðer aktarýmlarýný mümkün kýlmaktadýr. 'out'lu argümanlar ilkdeðersiz kullanýlýrken (ve ileriye deðil sadece geriye deðer aktarýrken), 'ref'liler mutlaka ilkdeðer olmasa derleme hatasý verir (ve heriki yönlü deðer aktarabilirler); baþka farklarý yoktur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int x = 23, y = 57;
            Console.WriteLine ("'Main()' metodu içinde ilk durum: x = " + x + ", y = " + y);
            var nesne = new RefDeneme1();
            nesne.RefsizTakas (x, y);
            Console.WriteLine ("'Main()' metodu içinde son durum: x = " + x + ", y = " + y);

            double pi = Math.PI;
            Console.WriteLine ("\n'Karekök()' metodu çaðrýlmadan önce pi = " + pi);
            nesne = new RefDeneme1();
            nesne.Karekök (ref pi);
            Console.WriteLine ("'Karekök()' metodu çaðrýldýktan sonra pi = " + pi);

            string ad = "M.Nihat Yavaþ";
            Console.WriteLine ("\n'BüyükHarf()' metodu çaðrýlmadan önce ad: {0}", ad);
            RefDeneme1.BüyükHarf (ref ad);
            Console.WriteLine ("'BüyükHarf()' metodu çaðrýldýktan sonra ad: {0}", ad);

            x = 2023; y = 1957;
            Console.WriteLine ("\n'Takas1()' metodu çaðrýlmadan önce int x ve y: " + x + ", " + y);
            nesne.Takas (ref x, ref y);
            Console.WriteLine ("'Takas1()' metodu çaðrýldýktan sonra int x ve y: " + x + ", " + y);

            RefDeneme2 n1 = new RefDeneme2 (2023, 1957), n2 = new RefDeneme2 (1957, 2023);
            Console.WriteLine ("\n'Takas2()' metodu çaðrýlmadan önce nesne n1: n1.a=" + n1.a + ", n1.b=" + n1.b);
            Console.WriteLine ("'Takas2()' metodu çaðrýlmadan önce nesne n2: n2.a=" + n2.a + ", n2.b=" + n2.b);
            n1.Takas (ref n1, ref n2);
            Console.WriteLine ("'Takas2()' metodu çaðrýldýktan sonra nesne n1: n1.a=" + n1.a + ", n1.b=" + n1.b);
            Console.WriteLine ("'Takas2()' metodu çaðrýldýktan sonra nesne n2: n2.a=" + n2.a + ", n2.b=" + n2.b);

            var r = new Random();
            double yç, çevre, alan, küreAlan=10 /* Etkisiz */, küreHacim;
            yç = r.Next (0, 1000000) / 100000d;
            nesne.DaireKüre1 (yç, out çevre, out alan, out küreAlan, out küreHacim);
            Console.WriteLine ("\nYarýçapý {0:0.00##} birim olan dairenin:\n==>Çevresi = {1:0.00##} birim\n==>Alaný = {2:0.00##} birim kare\n==>Küre alaný = {3:0.00##} birim kare\n==>Küre hacmi = {4:0.00##} birim küp'tür.", yç, çevre, alan, küreAlan, küreHacim);

            //double ç, a, ka, kh; //(Ýlkdeðer atanmama) derleme hatasý: [error CS0165: Use of unassigned local variable]
            double ç=0, a=0, ka=0, kh=0;
            yç = r.Next (0, 1000000) / 100000d;
            nesne.DaireKüre2 (yç, ref ç, ref a, ref ka, ref kh);
            Console.WriteLine ("\nYarýçapý {0:0.00##} birim olan dairenin:\n==>Çevresi = {1:0.00##} birim\n==>Alaný = {2:0.00##} birim kare\n==>Küre alaný = {3:0.00##} birim kare\n==>Küre hacmi = {4:0.00##} birim küp'tür.", yç, ç, a, ka, kh);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}