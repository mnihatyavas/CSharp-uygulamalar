// jtpc#1701.cs: Statik metodlar� delegeleyen hesaplay�c� tiplemesi �rne�i.

using System;
//using System.Delegate; //Tan�m gereksiz
namespace Delegeler {
    delegate int Hesaplay�c� (int n); //Delege beyan�
    class Delege {
        static int say� = 100;
        public static int topla (int n) {say� +=n; return say�;}
        public static int �arp (int n) {say� *=n; return say�;}
        public static int b�l (int n) {say� /=n; return say�;}
        public static int say�Al() {return say�;}
        static void Main() {
            Console.Write ("Delege, C ve C++'daki fonksiyon g�sterge�ine benzeyen fonksiyona referanst�r. Fakat ondan fark� nesneye-y�nelik, g�venli ve tipten ari olmas�d�r. ��sel System.Delegate tan�ml�d�r. En prati�i olay olarak kullan�m�d�r. Statik metodda, delege sadece metodu kaps�llerken, tiplemede hem metodu hem de delege beyan�n� kaps�ller.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplay�c� h1 = new Hesaplay�c� (topla); //Tiplemeli tekli delegeler
            Hesaplay�c� h2 = new Hesaplay�c� (�arp);
            var h3 = new Hesaplay�c� (b�l);
            h1 (20); Console.WriteLine ("Toplama delegesi: [100 + 20 = {0}]", say�Al());
            h2 (6); Console.WriteLine ("�arpma delegesi: [120 * 6 = {0}]", say�Al());
            h3 (2); Console.WriteLine ("B�lme delegesi: [720 / 2 = {0}]", say�Al());
            Hesaplay�c� �oklu; /*Tiplemesiz �oklu delege*/ �oklu = h1 + h2 + h3; �oklu (10); Console.WriteLine ("�oklu topla->�arp->b�l delegesi: [(360 + 10) * 10 / 10 = {0}]", say�Al());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}