// j2sc#1701a.cs: Regex'le Split, Replace, IsMatch ve Match �rne�i.

using System;
using System.Text.RegularExpressions; //Regex i�in
using System.Text; //StringBuilder i�in
namespace D�zenli�fade {
    class RegexA {
        static string IPTersi (Match e�le�tir) {
            StringBuilder sb = new StringBuilder();
            sb.Append (e�le�tir.Groups ["par�a4"] + ".");
            sb.Append (e�le�tir.Groups ["par�a3"] + ".");
            sb.Append (e�le�tir.Groups ["par�a2"] + ".");
            sb.Append (e�le�tir.Groups ["par�a1"]);
            return sb.ToString();
        }
        static void Main() {
            Console.Write ("T�mceyi ayr��t�ran Regex d�zenli ifade new Regex(@\"kal�p\")'la tan�mlan�r. Ara�t�rma �e�itleri: d�zif.Split(t�mce), d�zif.Replace(t�mce1,t�mce2), d�zif.IsMatch(kelime), d�zif.Match(kelime).Value.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�mce'deki herbir kelimeyi ayr��t�ran Regex:");
            string t�mce = "M. Nihat Yava� Toroslar - Mersin / TR";
            int i=0;
            Regex d�zif = new Regex (@" | ");
            foreach (string kelime in d�zif.Split (t�mce)) Console.WriteLine ("{0}.kelime: {1}", ++i, kelime);
            t�mce = "Bir,�ki,��, Ltd.�ti., A.�."; string kal�p = " |, |,"; d�zif = new Regex (kal�p);
            StringBuilder sb = new StringBuilder();
            i = 1;
            foreach (string ibare in d�zif.Split (t�mce)) sb.AppendFormat ("{0}: {1}\n", i++, ibare);
            Console.WriteLine ("{0}", sb);

            Console.WriteLine ("IP adres kal�b�n� sorgulayan Regex:");
            t�mce = "192.168.199.1";
            kal�p = @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])";
            d�zif = new Regex (kal�p);
            Console.WriteLine ("Verilen IP --> {0}", d�zif.Replace (t�mce, "xxx.xxx.xxx.xxx"));

            Console.WriteLine ("\nIP adres kal�b�n� tersleyen Regex:");
            kal�p = @"(?<par�a1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a2>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a3>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a4>[01]?\d\d?|2[0-4]\d|25[0-5])";
            d�zif = new Regex (kal�p);
            string t�mce1 = @"${par�a4}.${par�a3}.${par�a2}.${par�a1}";
            Console.WriteLine ("Verilen IP={0}\tTersi={1}", t�mce, d�zif.Replace (t�mce, t�mce1));
            //Di�er bir y�ntem
            MatchEvaluator t�mce2 = new MatchEvaluator (IPTersi);
            Console.WriteLine ("Verilen IP={0}\tTersi={1}", t�mce, d�zif.Replace (t�mce, t�mce2));

            Console.WriteLine ("\n�lk krk say�, sonrakiler farketmezle e�le�en Regex:");
            d�zif = new Regex ("^\\d+"); //�lk krk say�, sonrakiler farketmez
            string[] kelimeler = new string[] {"123abc", "abc123", "123", "abc", "a123bc"};
            i=0;
            foreach (string kelime in kelimeler) Console.WriteLine ("{0}.kelime ({1}) e�le�iyor mu? {2}", ++i, kelime, d�zif.IsMatch (kelime));
            //Di�er bir y�ntem
            d�zif = new Regex (@"\d+$"); //Sonu say�yla bitmeli
            i=0;
            Console.WriteLine ("\t==>Sonu say�yla bitmeli");
            foreach (string kelime in kelimeler) Console.WriteLine ("\t{0}.kelime ({1}) e�le�iyor mu? {2}", ++i, kelime, d�zif.IsMatch (kelime));
            //Di�er bir y�ntem
            d�zif = new Regex ("^\\d+$"); //Sonu say�yla bitmeli
            i=0;
            Console.WriteLine ("==>�lki ve sonu say�yla bitmeli");
            foreach (string kelime in kelimeler) Console.WriteLine ("{0}.kelime ({1}) e�le�iyor mu? {2}", ++i, kelime, d�zif.IsMatch (kelime));

            Console.WriteLine ("\nBa��nda abc veya xyz ��l�'den biri bulunanla e�le�en Regex:");
            d�zif = new Regex ("(abc)|(xyz)*");
            t�mce = "M.Nihat Yava�"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce));
            t�mce = "xyzM.Nihat Yava�"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce));
            t�mce = "M.Nihat Yava�xyzabc"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce));
            t�mce = "xyzabcM.Nihat Yava�"; Console.WriteLine ("'{0}' e�le�iyor mu? {1}", t�mce, d�zif.IsMatch (t�mce)); //Match do�ru fakat IsMatch her t�mce'ye True demekte
            t�mce = ""; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce));
            t�mce = "abcM.Nihat Yava�xyz"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce).Value);
            t�mce = "xyzabcxyz"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce).Value);
            t�mce = "M.Nihat Yava�xyz"; Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce).Value);
            d�zif = new Regex ("((?:abc)|(?:xyz))*"); t�mce = "abcabcMNYxyzabc";
            Console.WriteLine ("'{0}' e�le�iyor mu? {1}", t�mce, d�zif.IsMatch (t�mce));
            Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce).Value);
            t�mce = "abcabcxyzabc"; Console.WriteLine ("'{0}' e�le�iyor mu? {1}", t�mce, d�zif.IsMatch (t�mce));
            Console.WriteLine ("'{0}' ile e�le�en: [{1}]", t�mce, d�zif.Match (t�mce).Value);

            Console.WriteLine ("\n�e�itli kal�p, d�zif, t�mce'li IsMatch ve Match sonu�lar�:");
            kal�p = "((?:abc)|(?:xyz))*"; d�zif = new Regex (kal�p); t�mce = "abcabcxyzabc";
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce, kal�p, d�zif.IsMatch (t�mce));
            kal�p = @"(?(^\d)^\d+$|^\D+$)"; d�zif = new Regex (kal�p); t�mce = "kedi de";
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce, kal�p, d�zif.IsMatch (t�mce));
            t�mce = "5 kedi de";
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce, kal�p, d�zif.IsMatch (t�mce));
            kal�p = @"<[^>]+>[^<]*</[^>]+>"; d�zif = new Regex (kal�p); t�mce = "<M>S</M>";
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce, kal�p, d�zif.IsMatch (t�mce));
            t�mce1 = "<M>S</I>"; Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce1, kal�p, d�zif.IsMatch (t�mce1));
            kal�p = @"<([^>]+)>[^<]*</(\1)>";
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce, kal�p, d�zif.IsMatch (t�mce));
            Console.WriteLine ("'{0}' t�mce, '{1}' kal�pl� Regex'le e�le�iyor mu? {2}", t�mce1, kal�p, d�zif.IsMatch (t�mce1)); //Hatal�, False olmal�yd�
            kal�p = @"((abc)*)x(\1)"; d�zif = new Regex (kal�p); t�mce = "abcabcabcxabc";
            Console.WriteLine ("'{0}' t�mcede, '{1}' kal�pl� Regex'le e�le�en d�r: {2}", t�mce, kal�p, d�zif.Match (t�mce).Value);
            kal�p = @"(^\d+$\n)+"; d�zif = new Regex (kal�p, RegexOptions.Multiline); t�mce = "987987\n129821\n20241806";
            Console.WriteLine ("'{0}' �oklusat�r t�mcede, '{1}' kal�pl� Regex'le e�le�en ilk de�er: {2}", t�mce, kal�p, d�zif.Match (t�mce).Value);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    } 
}