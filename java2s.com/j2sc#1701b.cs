// j2sc#1701b.cs: Regex.Match'le t�mce, kal�p, d�zif ve uyan �rne�i.

using System;
using System.Text.RegularExpressions; //Regex i�in
namespace D�zenli�fade {
    class RegexB {
        private static void Uyanlar�G�ster (string c�mle, string kal�p) {
            MatchCollection uyanlar = Regex.Matches (c�mle, kal�p);
            int i = 0;
            foreach (Match uyan in uyanlar) Console.WriteLine ("{0}.uyan kelime: {1}", ++i, uyan);
        }
        static void Main() {
            Console.Write ("Uyumlu mu? d�zif.IsMatch(t�mce) veya Regex.IsMatch(t�mce1,t�mce2)'yle, uyan endeks ve de�eri de: uyan=d�zif.Match(t�mce), uyan.Index, uyan.Value ile bulunur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili t�mcede baz� krk'leri i�eren kelimelerin sunumu:");
            string t�mce = "20220619'nolu Nihaat nas�ls�n, neylemektesin? Neredeen gellip nereyee giddersin?";
            string kal�p = @"\bn\S*|\bN\S*";
            Console.WriteLine ("==>'{0}' kal�pla [{1}] t�mcesindeki 'n/N' ile ba�layan kelimeler:", kal�p, t�mce);
            Uyanlar�G�ster (t�mce, kal�p);
            Console.WriteLine ("==>'n/N'le ba�lay�p 'n'le biten kelimeler:");
            Uyanlar�G�ster (t�mce, @"\bn\S*n|\bN\S*n");
            Console.WriteLine ("==>��inde 2 ard���k ayn� krk bulunan kelimeler:");
            Uyanlar�G�ster (t�mce, @"\S*(.)\1\S*");
            Console.WriteLine ("==>��inde 'i' harfi bulunan kelimeler:");
            Uyanlar�G�ster (t�mce, @"\S*i+\S*");
            Console.WriteLine ("==>��inde 're' harfleri bulunan kelimeler:");
            Uyanlar�G�ster (t�mce, @"\S*(re)\S*");
            Console.WriteLine ("==>��inde 's�', 'ne' veya 'Ne' harfleri bulunan kelimeler:");
            Uyanlar�G�ster (t�mce, @"\S*(s�|ne|Ne)\S*");
            Console.WriteLine ("==>��inde 'g', 't' veya '�' harfleri bulunan kelimeler:");
            Uyanlar�G�ster (t�mce, @"\S*[gt�]\S*");
            Console.WriteLine ("==>��inde 'g'den '�'ye de�in harflerden biri bulunan kelimeler:"); //T�rk�e �'y� z'den sonraya s�ralamakta, �->i de�il
            Uyanlar�G�ster (t�mce, @"\S*[g-�]\S*");

            Console.WriteLine ("\n�ki ayr�/ayn� t�mcelerin uyumlulu�u testi:");
            t�mce = "M.Nihat Yava�"; 
            string t�mce2 = "M.Nedim Yava�";
            Regex d�zif = new Regex (t�mce);
            Console.WriteLine ("{0}.Uyumlumu({1})? {2}", d�zif, t�mce2, d�zif.IsMatch (t�mce2));
            Console.WriteLine ("Regex.Uyumlumu({0},{1})? {2}", t�mce, t�mce2, Regex.IsMatch (t�mce, t�mce2));
            Console.WriteLine ("{0}.Uyumlumu({1})? {2}", d�zif, t�mce, d�zif.IsMatch (t�mce));
            Console.WriteLine ("Regex.Uyumlumu({0},{1})? {2}", t�mce2, t�mce2, Regex.IsMatch (t�mce2, t�mce2));

            Console.WriteLine ("\n�ki ayr� IP adresinin verilen ve kalpla ay�klanan uyum testleri:");
            t�mce = "192.168.169.1";
            kal�p = @"(?<par�a1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a2>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a3>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<par�a4>[01]?\d\d?|2[0-4]\d|25[0-5])";
            d�zif = new Regex (kal�p);
            Match uyan = d�zif.Match (t�mce);
            while (uyan.Success) {
                Console.WriteLine ("==>Bulunan IP adres uyum endeksi: {0} ve de�eri: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("'{0}' i�in gruplar:",  t�mce);
                Console.WriteLine ("\t1.grup: {0}", uyan.Groups ["par�a1"]);
                Console.WriteLine ("\t2.grup: {0}", uyan.Groups ["par�a2"]);
                Console.WriteLine ("\t3.grup: {0}", uyan.Groups ["par�a3"]);
                Console.WriteLine ("\t4.grup: {0}", uyan.Groups ["par�a4"]);
                uyan = uyan.NextMatch();
            }
            t�mce = "2024.06.19.1842";
            uyan = d�zif.Match (t�mce);
            while (uyan.Success) {
                Console.WriteLine ("==>Bulunan IP adres uyum endeksi: {0} ve de�eri: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("'{0}' i�in gruplar:",  t�mce);
                Console.WriteLine ("\t1.grup: {0}", uyan.Groups ["par�a1"]);
                Console.WriteLine ("\t2.grup: {0}", uyan.Groups ["par�a2"]);
                Console.WriteLine ("\t3.grup: {0}", uyan.Groups ["par�a3"]);
                Console.WriteLine ("\t4.grup: {0}", uyan.Groups ["par�a4"]);
                uyan = uyan.NextMatch();
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
/*
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="end main void static start she";
    
    Console.WriteLine("Matching words that start with 's'");
    DisplayMatches(text, @"\bs\S*");
  }
}
Matching words that start with 's'
using the following regular expression: \bs\S*
static
start
she
----------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="end main void static start she";
    
    Console.WriteLine("Matching words that start with 's' and end with 'e'");
    DisplayMatches(text, @"\bs\S*e\b");
  }
}
Matching words that start with 's' and end with 'e'
using the following regular expression: \bs\S*e\b
she
----------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="Missisipli Kerrisdale she";
    
    Console.WriteLine("Matching words that that contain two consecutive identical characters");
    DisplayMatches(text, @"\S*(.)\1\S*");
  }
}
Matching words that that contain two consecutive identical characters
using the following regular expression: \S*(.)\1\S*
Missisipli
Kerrisdale
---------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="put public private she";
    
    Console.WriteLine("Matching words that contain 'u'");
    DisplayMatches(text, @"\S*u+\S*");
  }
}
Matching words that contain 'u'
using the following regular expression: \S*u+\S*
put
public
---------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="put curtain pertain perday";
    
    Console.WriteLine("Matching words that contain the pattern 'ai'");
    DisplayMatches(text, @"\S*(ai)\S*");
  }
}
Matching words that contain the pattern 'ai'
using the following regular expression: \S*(ai)\S*
curtain
pertain
-----------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="put curtain pertain peiu";
    
    Console.WriteLine("Matching words that contain the pattern 'ai' or 'ie'");
    DisplayMatches(text, @"\S*(ai|ie)\S*");
  }
}
Matching words that contain the pattern 'ai' or 'ie'
using the following regular expression: \S*(ai|ie)\S*
curtain
pertain
----------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="knife knock five";
    
    Console.WriteLine("Matching words that contain 'k' or 'f'");
    DisplayMatches(text, @"\S*[kf]\S*");
  }
}
Matching words that contain 'k' or 'f'
using the following regular expression: \S*[kf]\S*
knife
knock
five
------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass {

  private static void DisplayMatches(string text,string regularExpressionString) {
    Console.WriteLine("using the following regular expression: " +regularExpressionString);
    MatchCollection myMatchCollection = Regex.Matches(text, regularExpressionString);
    foreach (Match myMatch in myMatchCollection) {
      Console.WriteLine(myMatch);
    }
  }

  public static void Main() {
    string text ="knife knock five";
    
    Console.WriteLine("Matching words that contain any letters in the range 'b' through 'd'");
    DisplayMatches(text, @"\S*[b-d]\S*");
  }
}
Matching words that contain any letters in the range 'b' through 'd'
using the following regular expression: \S*[b-d]\S*
knock
-------------------------------------
using System;
using System.Text.RegularExpressions;

class MainClass
{
    public static void Main(string[] args)
    {

        string regex = "your regex"; 
        string input = "your input";
        
        Regex r = new Regex(regex);
        Console.WriteLine(r.IsMatch(input));
        
        //or Regex.IsMatch(input, regex);
    }
}
False
----------------------------------
using System;
using System.Text.RegularExpressions;

public class EntryPoint
{
    static void Main( string[] args ) {
        // Create regex to search for IP address pattern.
        string pattern = @"(?<part1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                         @"(?<part2>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                         @"(?<part3>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                         @"(?<part4>[01]?\d\d?|2[0-4]\d|25[0-5])";
        Regex regex = new Regex( pattern );
        Match match = regex.Match( "192.168.169.1" );
        while( match.Success ) {
            Console.WriteLine( "IP Address found at {0} with " +
                               "value of {1}",
                               match.Index,
                               match.Value );
            Console.WriteLine( "Groups are:" );
            Console.WriteLine( "\tPart 1: {0}",
                               match.Groups["part1"] );
            Console.WriteLine( "\tPart 2: {0}",
                               match.Groups["part2"] );
            Console.WriteLine( "\tPart 3: {0}",
                               match.Groups["part3"] );
            Console.WriteLine( "\tPart 4: {0}",
                               match.Groups["part4"] );

            match = match.NextMatch();
        }
        
    }
}
IP Address found at 0 with value of 192.168.169.1
Groups are:
        Part 1: 192
        Part 2: 168
        Part 3: 169
        Part 4: 1
----------------------------------------
using System;
using System.Text.RegularExpressions;

public class MainClass
{
    static void Main( string[] args ) {
        // Create regex to search for IP address pattern.
        string pattern = @"(?<part1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                         @"\k<part1>\." +
                         @"\k<part1>\." +
                         @"\k<part1>";
        Regex regex = new Regex( pattern );
        Match match = regex.Match( "192.168.169.1" );
        while( match.Success ) {
            Console.WriteLine( "IP Address found at {0} with " +
                               "value of {1}",
                               match.Index,
                               match.Value );

            match = match.NextMatch();
        }
    }
}
-----------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

public class MainClass{

   public static void Main(){
        Regex r = new Regex(@"^\G\d+$\n?", RegexOptions.Multiline);
        Match m = r.Match("13\n38\n18\n5");
        do {
            Console.WriteLine("Match: " + m.Value);
        } while ((m = m.NextMatch()).Success);
   }
}
Match: 13

Match: 38

Match: 18

Match: 5
-----------------------------------
using System;
using System.Text.RegularExpressions;

    class Test
    {
        public static void Main()
        {
            string string1 = "This is a test string";
            Regex theReg = new Regex(@"(\S+)\s");
            MatchCollection theMatches = theReg.Matches(string1);
            foreach (Match theMatch in theMatches)
            {
                Console.WriteLine(theMatch.Length);
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}",
                                  theMatch.ToString());
                }
            }
        }
    }
-----------------------------------
using System;
using System.Text.RegularExpressions;

    class Test
    {
        public static void Main()
        {
            string string1 = "04:03:27 abc 0.0.0.127 def";
            Regex theReg = new Regex(@"(?<time>(\d|\:)+)\s" +
                            @"(?<company>\S+)\s" +
                            @"(?<ip>(\d|\.)+)\s" +
                            @"(?<company>\S+)\s");
            MatchCollection theMatches = theReg.Matches(string1);
            foreach (Match theMatch in theMatches)
            {
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("theMatch: {0}",theMatch.ToString());
                    Console.WriteLine("time: {0}",theMatch.Groups["time"]);
                    Console.WriteLine("ip: {0}",theMatch.Groups["ip"]);
                    Console.WriteLine("Company: {0}",theMatch.Groups["company"]);
                    foreach (Capture cap in theMatch.Groups["company"].Captures)
                    {
                        Console.WriteLine("cap: {0}", cap.ToString());
                    }
                }
            }
        }
    }
-------------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"gr[ae]y\s\S+?[\s|\p{P}]";
      string input = "this is a test.";
      MatchCollection matches = Regex.Matches(input, pattern);
      foreach (Match match in matches)
         Console.WriteLine(match.Value);
   }
}
----------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[A-Z]\w*\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
---------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[A-Z]\w*\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
-------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\b[A-Z]\w*\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
---------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bth[^o]\w+\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
------------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bth[^o]\w+\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
---------------------------------------
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\bth[^o]\w+\b";
      string input = "this is a test";
      foreach (Match match in Regex.Matches(input, pattern))
         Console.WriteLine(match.Value);
   }
}
---------------------------------------

*/