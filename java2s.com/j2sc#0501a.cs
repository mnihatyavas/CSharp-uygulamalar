// j2sc#0501a.cs: Dizgelerde temel iþlemler ve dizgesel metotlar örneði.

using System;
namespace Dizgeler {
    class String1 {
        static void DizgeyiDeðiþtir (string dzg) {
            dzg = "Deðiþen Dizge";
            Console.WriteLine ("Metot içi dizge1 parametresi = {0}", dzg);
        }
        static void Main() {
            Console.Write ("Dizgeler çift týrnak içindeki karakterler verili, referans tipli nesnelerdir (ancak =atamayla yada Copy kopyalamadan sonra aslýndaki deðiþiklik sureti etkilemez). Birkaç dizgesel arþiv metotlarý: Copy, CompareTo, IndexOf, LastIndexOf, ToLower, ToUpper.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çift-týrnak içi verili dizge tanýmlarý:");
            string dizgem = "Merhaba Dünya!", yol1  = @"c:\Program Files", yol2 = "c:\\Program Files", isim = "M.Nihat Yavaþ";
            Console.WriteLine ("string dizgem = \"{0}\"\nstring yol1 = \"{1}\"\nstring yol2 = \"{2}\"\nstring isim = \"{3}\"", dizgem, yol1, yol2, isim);

            Console.WriteLine ("\nÇaðrýlan metottaki parametre deðiþikliði aslýný etkilemez:");
            string dizge1 = "Orijinal Dizge";
            Console.WriteLine ("Metot çaðrý öncesi dizge1 = {0}", dizge1);
            DizgeyiDeðiþtir (dizge1);
            Console.WriteLine ("Metot çaðrý sonrasý dizge1 = {0}", dizge1);

            Console.WriteLine ("\nDizgeye uygulanan dizgesel metot aslýný etkilemez:");
            dizge1 = "Bu benim yeni içeriðimdir.";
            Console.WriteLine ("dizge1 = {0}", dizge1);
            string dizge2 = dizge1.ToUpper();
            Console.WriteLine ("Büyükharfli dizge2 = {0}", dizge2);
            Console.WriteLine ("Deðiþmeyen dizge1 = {0}", dizge1);

            Console.WriteLine ("\nString.Empty == \"\":");
            dizge1 = String.Empty; dizge2 = "";
            Console.WriteLine ("dizge1({0}) == dizge2({1})?: {2}", dizge1, dizge2, (dizge1 == dizge2));

            Console.WriteLine ("\nOrijinal, birer boþluklu ve tersten dizge:");
            dizge1 = "Olmak yada olmamak!..";
            string sonuç1="", sonuç2="";
            int i;
            for (i = 0; i < dizge1.Length; i++) {
                sonuç1 +=dizge1 [i] + " ";
                sonuç2 +=dizge1 [dizge1.Length - i -1];
            } Console.WriteLine ("Orijinal dizge1 = {0}\nAralýklý: {1}\nTersten: {2}", dizge1, sonuç1, sonuç2);

            Console.WriteLine ("\nString.Compare ile eþit(0), büyük(1) ve küçük(-1) sonuçlar:");
            Console.WriteLine ("String.Compare (\"bbc\", \"abc\") = " + String.Compare ("bbc", "abc"));
            Console.WriteLine ("String.Compare (\"abc\", \"bbc\") = " + String.Compare ("abc", "bbc"));
            Console.WriteLine ("String.Compare (\"bbc\", \"bbc\") = " + String.Compare ("bbc", "bbc"));
            Console.WriteLine("String.Compare (\"bbc\", \"BBC\", true) = " + String.Compare ("bbc", "BBC", true)); //Büyük/küçük-harf farketmez
            Console.WriteLine ("String.Compare (\"bbc\", \"BBC\", false) = " + String.Compare ("bbc", "BBC", false)); //Büyük/küçük-harf farkeder
            Console.WriteLine ("String.Compare (\"Selam Dünya\", 6, " + "\"Gülegüle Dünyamýza\", 9, 5) = " + String.Compare ("Selam Dünya", 6, "Gülegüle Dünyamýza", 9, 5));

            Console.WriteLine ("\nString.Concat ile ardýþýk dizgelerin eklenmesi:");
            dizge1 = String.Concat ("Mahmut ", "Nihat ", "Yavaþ");
            Console.WriteLine ("String.Concat (\"Mahmut \", \"Nihat \", \"Yavaþ\") = "+ dizge1);
            dizge1 +=String.Concat (" - ", "Toroslar", " / ", "Mersin");
            Console.WriteLine ("dizge1+=String.Concat (\" - \", \"Toroslar\", \" / \", \"Mersin\") = \n\t" + dizge1);

            Console.WriteLine ("\nString.Copy ile bir dizgeyi diðerine kopyalama:");
            sonuç1 = dizge1;
            Console.WriteLine ("dizge1 = {0}\n\tsonuç1 = dizge1: {1}", dizge1, sonuç1);
            dizge1 = "M.Nihat Yavaþ";
            Console.WriteLine ("Deðiþen dizge1 = {0}\n\tsonuç1 = {1}", dizge1, sonuç1);
            sonuç2 = String.Copy (sonuç1);
            Console.WriteLine ("sonuç1 = {0}\n\tsonuç2 = Copy (sonuç1): {1}", sonuç1, sonuç2);
            sonuç1 = "Zeliha Yavaþ Candan";
            Console.WriteLine ("Deðiþen sonuç1 = {0}\n\tsonuç2 = {1}", sonuç1, sonuç2);


            Console.WriteLine ("\nString.Equals ile iki dizgenin eþitliðini doðrulama:");
            bool eþitMi;
            eþitMi = String.Equals ("bbc", "BbC".ToLower());
            Console.WriteLine ("String.Equals(\"bbc\", \"BbC\".ToLower()) = " + eþitMi);
            eþitMi = sonuç1.Equals (sonuç2);
            Console.WriteLine ("sonuç1.Equals (sonuç2) = " + eþitMi);
            eþitMi = dizge1 == "M.Nihat Yavaþ";
            Console.WriteLine ("dizge1 == \"M.Nihat Yavaþ\" = " + eþitMi);

            Console.WriteLine ("\nString.Format ile sayýlarýn tamsayý ve küsürat hanelerini sýnýrlama:");
            float fs1 = 1234.56789f;
            double ds1 = Math.E;
            dizge1 = String.Format ("fs1 = {0, 10:f3}\nds1 = {1, 22:f15}", fs1, ds1);
            Console.WriteLine ("String.Format (\"fs1 = {0, 10:f3}; ds1 = {1, 22:f15}\", fs1, ds1)\n" + dizge1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}