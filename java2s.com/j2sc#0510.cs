// j2sc#0510.cs: Join, Split, ToCharArray ile dizgesel ayr��t�rma ve birle�tirme �rne�i.

using System;
namespace Dizgeler {
    class DizgedenDiziye {
        static string G�ster (string[] d) {string b=""; foreach (string s in d) b +=s+" "; return "{"+b+"}";}
        static void Main() {
            Console.Write ("Join, ilk arg�man=\"\" ile dizgesel dizi elemanlar�n� hi� ayra�s�z birle�tirir. Join ayrac� dizgesel, Split ayrac� ise krk'sel olmal�d�r ('' kabul etmez). Dizgeyi dizgesel krk'lerine dizge[i] ile, karaktersel krk'lerine de ToCharArray ile ayr��t�rabiliriz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("dDizi1 elemanlar�ndan Join'le tek bir dizge birle�tirme:");
            string dizge1 = "M.Nihat Yava�";
            string dizge2 = "Zafer N.Candan";
            string dizge3 = new String (new char[]{'C','a','n','a','n',' ','C','a','n','d','a','n'});
            string[] dDizi1 = new string[] {"B","e","l","k","�","s"," ","C","a","n","d","a","n"};
            string dizge4 = String.Join ("", dDizi1);
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"\ndizge3 = \"{2}\"\ndizge4 = \"{3}\"\n", dizge1, dizge2, dizge3, dizge4);

            Console.WriteLine ("\nDizge'yi ayra� krk'le dizi elemanlar�na ayr��t�rma:");
            dizge1 = "M,.,N,i,h,a,t, ,Y,a,v,a,�";
            dizge2 = "Z|a|f|e|r| |N|.|C|a|n|d|a|n";
            dizge4 = "B e l k � s  C a n d a n";
            Console.WriteLine ("dizge1 = {0}\ndizge2 = {1}\ndizge3 = {2}\ndizge4 = {3}",
                G�ster (dizge1.Split (',')), G�ster (dizge2.Split ('|')), G�ster (dizge3.Split (' ')), G�ster (dizge4.Split (' ')));

            Console.WriteLine ("\nDizge'yi �oklu ayra� ( ,.;-/) krk'le dizi elemanlar�na ayr��t�rma:");
            dizge1 = "M.Nihat Yava�; Ye�ilyurt-Malatya, 15/04/1955";
            char[] ayra�lar = {' ', '.', ',', '/', '-', ';'};
            Console.WriteLine ("dizge1 = ({0})\nAyr�k dizge1 elemanlar� = {1}", dizge1, G�ster (dizge1.Split (ayra�lar)) );
            Console.WriteLine ("\" | \" ile birle�tirilen dizge1 (ayr�k) elemanlar� =\n\t({0})", String.Join (" | ", dizge1.Split (ayra�lar)) );

            Console.WriteLine ("\nDizi elemanlar�n� bo�luksuz ve ayr� sat�rlarda sunma:");
            string[] dDizi2 = {"100 + 19 * 3", "100 - 85 / 5" , "100 + 19 * 3 + 100 - 85 / 5"};
            Console.WriteLine ("dDizi2 = {0}", G�ster (dDizi2) );
            for (int i=0; i < dDizi2.Length; i++) {
                string[] dDizi3 = dDizi2 [i].Split (' ');
                Console.Write ((i+1) + ".inci Eleman: (");
                for (int j=0; j < dDizi3.Length; j++) Console.Write (dDizi3 [j]);
                Console.WriteLine (")");
            }

            Console.WriteLine ("\nFarkl� dizgeleri ayn� ayra�lar'la diziye ayr��t�r�p sunma:");
            char krk1 = '\\', krk2 = ' ', krk3 = ',';
            ayra�lar = new char[]{krk1, krk2, krk3};
            dizge1 = "C:\\Users\\nihet\\Desktop\\MyFiles\\Dersler\\c#\\i�li";
            dizge2 = "T�rkiye, Amerika, Avrupa, Rusya, Arabistan Anonim �ti.";
            dDizi1 = dizge1.Split (ayra�lar);
            dDizi2 = dizge2.Split (ayra�lar);
            Console.WriteLine ("dizge1 = {0}\ndizge2 = {1}", dizge1, dizge2);
            Console.WriteLine ("dDizi1 = {0}\ndDizi2 = {1}", G�ster (dDizi1), G�ster (dDizi2) );

            Console.WriteLine ("\nDizge ayr��t�rma ve �e�itli sunu y�ntemleri:");
            dizge1 = "01234������������56789";
            char[] kDizi1 = dizge1.ToCharArray (5, 12);
            Console.Write ("dizge1 = {0}\nSadece harfleri = ", dizge1); Console.Write (kDizi1);
            Console.WriteLine ("\ndizge[i] ile bo�luklu dizge1 ve sadece harfleri:");
            dizge2="";
            for (int i=0; i<dizge1.Length; i++) dizge2+=dizge1[i]+" ";
            Console.WriteLine ("\t"+dizge2);
            dizge3="";
            foreach (char krk in kDizi1) dizge3+=krk+" ";
            Console.WriteLine ("\t"+dizge3);
            Console.WriteLine ("Split ve G�ster ile bo�luklu dizge1 ve kDizi1=\n\t{0}\n\t{1}", G�ster (dizge2.Split (' ')), G�ster (dizge3.Split (' ')) );

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}