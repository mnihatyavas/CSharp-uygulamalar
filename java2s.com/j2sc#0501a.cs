// j2sc#0501a.cs: Dizgelerde temel i�lemler ve dizgesel metotlar �rne�i.

using System;
namespace Dizgeler {
    class String1 {
        static void DizgeyiDe�i�tir (string dzg) {
            dzg = "De�i�en Dizge";
            Console.WriteLine ("Metot i�i dizge1 parametresi = {0}", dzg);
        }
        static void Main() {
            Console.Write ("Dizgeler �ift t�rnak i�indeki karakterler verili, referans tipli nesnelerdir (ancak =atamayla yada Copy kopyalamadan sonra asl�ndaki de�i�iklik sureti etkilemez). Birka� dizgesel ar�iv metotlar�: Copy, CompareTo, IndexOf, LastIndexOf, ToLower, ToUpper.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�ift-t�rnak i�i verili dizge tan�mlar�:");
            string dizgem = "Merhaba D�nya!", yol1  = @"c:\Program Files", yol2 = "c:\\Program Files", isim = "M.Nihat Yava�";
            Console.WriteLine ("string dizgem = \"{0}\"\nstring yol1 = \"{1}\"\nstring yol2 = \"{2}\"\nstring isim = \"{3}\"", dizgem, yol1, yol2, isim);

            Console.WriteLine ("\n�a�r�lan metottaki parametre de�i�ikli�i asl�n� etkilemez:");
            string dizge1 = "Orijinal Dizge";
            Console.WriteLine ("Metot �a�r� �ncesi dizge1 = {0}", dizge1);
            DizgeyiDe�i�tir (dizge1);
            Console.WriteLine ("Metot �a�r� sonras� dizge1 = {0}", dizge1);

            Console.WriteLine ("\nDizgeye uygulanan dizgesel metot asl�n� etkilemez:");
            dizge1 = "Bu benim yeni i�eri�imdir.";
            Console.WriteLine ("dizge1 = {0}", dizge1);
            string dizge2 = dizge1.ToUpper();
            Console.WriteLine ("B�y�kharfli dizge2 = {0}", dizge2);
            Console.WriteLine ("De�i�meyen dizge1 = {0}", dizge1);

            Console.WriteLine ("\nString.Empty == \"\":");
            dizge1 = String.Empty; dizge2 = "";
            Console.WriteLine ("dizge1({0}) == dizge2({1})?: {2}", dizge1, dizge2, (dizge1 == dizge2));

            Console.WriteLine ("\nOrijinal, birer bo�luklu ve tersten dizge:");
            dizge1 = "Olmak yada olmamak!..";
            string sonu�1="", sonu�2="";
            int i;
            for (i = 0; i < dizge1.Length; i++) {
                sonu�1 +=dizge1 [i] + " ";
                sonu�2 +=dizge1 [dizge1.Length - i -1];
            } Console.WriteLine ("Orijinal dizge1 = {0}\nAral�kl�: {1}\nTersten: {2}", dizge1, sonu�1, sonu�2);

            Console.WriteLine ("\nString.Compare ile e�it(0), b�y�k(1) ve k���k(-1) sonu�lar:");
            Console.WriteLine ("String.Compare (\"bbc\", \"abc\") = " + String.Compare ("bbc", "abc"));
            Console.WriteLine ("String.Compare (\"abc\", \"bbc\") = " + String.Compare ("abc", "bbc"));
            Console.WriteLine ("String.Compare (\"bbc\", \"bbc\") = " + String.Compare ("bbc", "bbc"));
            Console.WriteLine("String.Compare (\"bbc\", \"BBC\", true) = " + String.Compare ("bbc", "BBC", true)); //B�y�k/k���k-harf farketmez
            Console.WriteLine ("String.Compare (\"bbc\", \"BBC\", false) = " + String.Compare ("bbc", "BBC", false)); //B�y�k/k���k-harf farkeder
            Console.WriteLine ("String.Compare (\"Selam D�nya\", 6, " + "\"G�leg�le D�nyam�za\", 9, 5) = " + String.Compare ("Selam D�nya", 6, "G�leg�le D�nyam�za", 9, 5));

            Console.WriteLine ("\nString.Concat ile ard���k dizgelerin eklenmesi:");
            dizge1 = String.Concat ("Mahmut ", "Nihat ", "Yava�");
            Console.WriteLine ("String.Concat (\"Mahmut \", \"Nihat \", \"Yava�\") = "+ dizge1);
            dizge1 +=String.Concat (" - ", "Toroslar", " / ", "Mersin");
            Console.WriteLine ("dizge1+=String.Concat (\" - \", \"Toroslar\", \" / \", \"Mersin\") = \n\t" + dizge1);

            Console.WriteLine ("\nString.Copy ile bir dizgeyi di�erine kopyalama:");
            sonu�1 = dizge1;
            Console.WriteLine ("dizge1 = {0}\n\tsonu�1 = dizge1: {1}", dizge1, sonu�1);
            dizge1 = "M.Nihat Yava�";
            Console.WriteLine ("De�i�en dizge1 = {0}\n\tsonu�1 = {1}", dizge1, sonu�1);
            sonu�2 = String.Copy (sonu�1);
            Console.WriteLine ("sonu�1 = {0}\n\tsonu�2 = Copy (sonu�1): {1}", sonu�1, sonu�2);
            sonu�1 = "Zeliha Yava� Candan";
            Console.WriteLine ("De�i�en sonu�1 = {0}\n\tsonu�2 = {1}", sonu�1, sonu�2);


            Console.WriteLine ("\nString.Equals ile iki dizgenin e�itli�ini do�rulama:");
            bool e�itMi;
            e�itMi = String.Equals ("bbc", "BbC".ToLower());
            Console.WriteLine ("String.Equals(\"bbc\", \"BbC\".ToLower()) = " + e�itMi);
            e�itMi = sonu�1.Equals (sonu�2);
            Console.WriteLine ("sonu�1.Equals (sonu�2) = " + e�itMi);
            e�itMi = dizge1 == "M.Nihat Yava�";
            Console.WriteLine ("dizge1 == \"M.Nihat Yava�\" = " + e�itMi);

            Console.WriteLine ("\nString.Format ile say�lar�n tamsay� ve k�s�rat hanelerini s�n�rlama:");
            float fs1 = 1234.56789f;
            double ds1 = Math.E;
            dizge1 = String.Format ("fs1 = {0, 10:f3}\nds1 = {1, 22:f15}", fs1, ds1);
            Console.WriteLine ("String.Format (\"fs1 = {0, 10:f3}; ds1 = {1, 22:f15}\", fs1, ds1)\n" + dizge1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}