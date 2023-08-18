// j2sc#0510.cs: Join, Split, ToCharArray ile dizgesel ayrýþtýrma ve birleþtirme örneði.

using System;
namespace Dizgeler {
    class DizgedenDiziye {
        static string Göster (string[] d) {string b=""; foreach (string s in d) b +=s+" "; return "{"+b+"}";}
        static void Main() {
            Console.Write ("Join, ilk argüman=\"\" ile dizgesel dizi elemanlarýný hiç ayraçsýz birleþtirir. Join ayracý dizgesel, Split ayracý ise krk'sel olmalýdýr ('' kabul etmez). Dizgeyi dizgesel krk'lerine dizge[i] ile, karaktersel krk'lerine de ToCharArray ile ayrýþtýrabiliriz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("dDizi1 elemanlarýndan Join'le tek bir dizge birleþtirme:");
            string dizge1 = "M.Nihat Yavaþ";
            string dizge2 = "Zafer N.Candan";
            string dizge3 = new String (new char[]{'C','a','n','a','n',' ','C','a','n','d','a','n'});
            string[] dDizi1 = new string[] {"B","e","l","k","ý","s"," ","C","a","n","d","a","n"};
            string dizge4 = String.Join ("", dDizi1);
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"\ndizge3 = \"{2}\"\ndizge4 = \"{3}\"\n", dizge1, dizge2, dizge3, dizge4);

            Console.WriteLine ("\nDizge'yi ayraç krk'le dizi elemanlarýna ayrýþtýrma:");
            dizge1 = "M,.,N,i,h,a,t, ,Y,a,v,a,þ";
            dizge2 = "Z|a|f|e|r| |N|.|C|a|n|d|a|n";
            dizge4 = "B e l k ý s  C a n d a n";
            Console.WriteLine ("dizge1 = {0}\ndizge2 = {1}\ndizge3 = {2}\ndizge4 = {3}",
                Göster (dizge1.Split (',')), Göster (dizge2.Split ('|')), Göster (dizge3.Split (' ')), Göster (dizge4.Split (' ')));

            Console.WriteLine ("\nDizge'yi çoklu ayraç ( ,.;-/) krk'le dizi elemanlarýna ayrýþtýrma:");
            dizge1 = "M.Nihat Yavaþ; Yeþilyurt-Malatya, 15/04/1955";
            char[] ayraçlar = {' ', '.', ',', '/', '-', ';'};
            Console.WriteLine ("dizge1 = ({0})\nAyrýk dizge1 elemanlarý = {1}", dizge1, Göster (dizge1.Split (ayraçlar)) );
            Console.WriteLine ("\" | \" ile birleþtirilen dizge1 (ayrýk) elemanlarý =\n\t({0})", String.Join (" | ", dizge1.Split (ayraçlar)) );

            Console.WriteLine ("\nDizi elemanlarýný boþluksuz ve ayrý satýrlarda sunma:");
            string[] dDizi2 = {"100 + 19 * 3", "100 - 85 / 5" , "100 + 19 * 3 + 100 - 85 / 5"};
            Console.WriteLine ("dDizi2 = {0}", Göster (dDizi2) );
            for (int i=0; i < dDizi2.Length; i++) {
                string[] dDizi3 = dDizi2 [i].Split (' ');
                Console.Write ((i+1) + ".inci Eleman: (");
                for (int j=0; j < dDizi3.Length; j++) Console.Write (dDizi3 [j]);
                Console.WriteLine (")");
            }

            Console.WriteLine ("\nFarklý dizgeleri ayný ayraçlar'la diziye ayrýþtýrýp sunma:");
            char krk1 = '\\', krk2 = ' ', krk3 = ',';
            ayraçlar = new char[]{krk1, krk2, krk3};
            dizge1 = "C:\\Users\\nihet\\Desktop\\MyFiles\\Dersler\\c#\\iþli";
            dizge2 = "Türkiye, Amerika, Avrupa, Rusya, Arabistan Anonim Þti.";
            dDizi1 = dizge1.Split (ayraçlar);
            dDizi2 = dizge2.Split (ayraçlar);
            Console.WriteLine ("dizge1 = {0}\ndizge2 = {1}", dizge1, dizge2);
            Console.WriteLine ("dDizi1 = {0}\ndDizi2 = {1}", Göster (dDizi1), Göster (dDizi2) );

            Console.WriteLine ("\nDizge ayrýþtýrma ve çeþitli sunu yöntemleri:");
            dizge1 = "01234ÇçÐðÝýÖöÜüÞþ56789";
            char[] kDizi1 = dizge1.ToCharArray (5, 12);
            Console.Write ("dizge1 = {0}\nSadece harfleri = ", dizge1); Console.Write (kDizi1);
            Console.WriteLine ("\ndizge[i] ile boþluklu dizge1 ve sadece harfleri:");
            dizge2="";
            for (int i=0; i<dizge1.Length; i++) dizge2+=dizge1[i]+" ";
            Console.WriteLine ("\t"+dizge2);
            dizge3="";
            foreach (char krk in kDizi1) dizge3+=krk+" ";
            Console.WriteLine ("\t"+dizge3);
            Console.WriteLine ("Split ve Göster ile boþluklu dizge1 ve kDizi1=\n\t{0}\n\t{1}", Göster (dizge2.Split (' ')), Göster (dizge3.Split (' ')) );

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}