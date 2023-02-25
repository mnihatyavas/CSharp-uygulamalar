// jtpc#1701.cs: Statik metodlarý delegeleyen hesaplayýcý tiplemesi örneði.

using System;
//using System.Delegate; //Taným gereksiz
namespace Delegeler {
    delegate int Hesaplayýcý (int n); //Delege beyaný
    class Delege {
        static int sayý = 100;
        public static int topla (int n) {sayý +=n; return sayý;}
        public static int çarp (int n) {sayý *=n; return sayý;}
        public static int böl (int n) {sayý /=n; return sayý;}
        public static int sayýAl() {return sayý;}
        static void Main() {
            Console.Write ("Delege, C ve C++'daki fonksiyon göstergeçine benzeyen fonksiyona referanstýr. Fakat ondan farký nesneye-yönelik, güvenli ve tipten ari olmasýdýr. Ýçsel System.Delegate tanýmlýdýr. En pratiði olay olarak kullanýmýdýr. Statik metodda, delege sadece metodu kapsüllerken, tiplemede hem metodu hem de delege beyanýný kapsüller.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplayýcý h1 = new Hesaplayýcý (topla); //Tiplemeli tekli delegeler
            Hesaplayýcý h2 = new Hesaplayýcý (çarp);
            var h3 = new Hesaplayýcý (böl);
            h1 (20); Console.WriteLine ("Toplama delegesi: [100 + 20 = {0}]", sayýAl());
            h2 (6); Console.WriteLine ("Çarpma delegesi: [120 * 6 = {0}]", sayýAl());
            h3 (2); Console.WriteLine ("Bölme delegesi: [720 / 2 = {0}]", sayýAl());
            Hesaplayýcý çoklu; /*Tiplemesiz çoklu delege*/ çoklu = h1 + h2 + h3; çoklu (10); Console.WriteLine ("Çoklu topla->çarp->böl delegesi: [(360 + 10) * 10 / 10 = {0}]", sayýAl());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}