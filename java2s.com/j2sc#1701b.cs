// j2sc#1701b.cs: Regex.Match'le tümce, kalýp, düzif ve uyan örneði.

using System;
using System.Text.RegularExpressions; //Regex için
namespace DüzenliÝfade {
    class RegexB {
        private static void UyanlarýGöster (string cümle, string kalýp) {
            MatchCollection uyanlar = Regex.Matches (cümle, kalýp);
            int i = 0;
            foreach (Match uyan in uyanlar) Console.WriteLine ("{0}.uyan kelime: {1}", ++i, uyan);
        }
        static void Main() {
            Console.Write ("Uyumlu mu? düzif.IsMatch(tümce) veya Regex.IsMatch(tümce1,tümce2)'yle, uyan endeks ve deðeri de: uyan=düzif.Match(tümce), uyan.Index, uyan.Value ile bulunur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili tümcede bazý krk'leri içeren kelimelerin sunumu:");
            string tümce = "20220619'nolu Nihaat nasýlsýn, neylemektesin? Neredeen gellip nereyee giddersin?";
            string kalýp = @"\bn\S*|\bN\S*";
            Console.WriteLine ("==>'{0}' kalýpla [{1}] tümcesindeki 'n/N' ile baþlayan kelimeler:", kalýp, tümce);
            UyanlarýGöster (tümce, kalýp);
            Console.WriteLine ("==>'n/N'le baþlayýp 'n'le biten kelimeler:");
            UyanlarýGöster (tümce, @"\bn\S*n|\bN\S*n");
            Console.WriteLine ("==>Ýçinde 2 ardýþýk ayný krk bulunan kelimeler:");
            UyanlarýGöster (tümce, @"\S*(.)\1\S*");
            Console.WriteLine ("==>Ýçinde 'i' harfi bulunan kelimeler:");
            UyanlarýGöster (tümce, @"\S*i+\S*");
            Console.WriteLine ("==>Ýçinde 're' harfleri bulunan kelimeler:");
            UyanlarýGöster (tümce, @"\S*(re)\S*");
            Console.WriteLine ("==>Ýçinde 'sý', 'ne' veya 'Ne' harfleri bulunan kelimeler:");
            UyanlarýGöster (tümce, @"\S*(sý|ne|Ne)\S*");
            Console.WriteLine ("==>Ýçinde 'g', 't' veya 'ý' harfleri bulunan kelimeler:");
            UyanlarýGöster (tümce, @"\S*[gtý]\S*");
            Console.WriteLine ("==>Ýçinde 'g'den 'ý'ye deðin harflerden biri bulunan kelimeler:"); //Türkçe ý'yý z'den sonraya sýralamakta, ý->i deðil
            UyanlarýGöster (tümce, @"\S*[g-ý]\S*");

            Console.WriteLine ("\nÝki ayrý/ayný tümcelerin uyumluluðu testi:");
            tümce = "M.Nihat Yavaþ"; 
            string tümce2 = "M.Nedim Yavaþ";
            Regex düzif = new Regex (tümce);
            Console.WriteLine ("{0}.Uyumlumu({1})? {2}", düzif, tümce2, düzif.IsMatch (tümce2));
            Console.WriteLine ("Regex.Uyumlumu({0},{1})? {2}", tümce, tümce2, Regex.IsMatch (tümce, tümce2));
            Console.WriteLine ("{0}.Uyumlumu({1})? {2}", düzif, tümce, düzif.IsMatch (tümce));
            Console.WriteLine ("Regex.Uyumlumu({0},{1})? {2}", tümce2, tümce2, Regex.IsMatch (tümce2, tümce2));

            Console.WriteLine ("\nÝki ayrý IP adresinin verilen ve kalpla ayýklanan uyum testleri:");
            tümce = "192.168.169.1";
            kalýp = @"(?<parça1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça2>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça3>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça4>[01]?\d\d?|2[0-4]\d|25[0-5])";
            düzif = new Regex (kalýp);
            Match uyan = düzif.Match (tümce);
            while (uyan.Success) {
                Console.WriteLine ("==>Bulunan IP adres uyum endeksi: {0} ve deðeri: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("'{0}' için gruplar:",  tümce);
                Console.WriteLine ("\t1.grup: {0}", uyan.Groups ["parça1"]);
                Console.WriteLine ("\t2.grup: {0}", uyan.Groups ["parça2"]);
                Console.WriteLine ("\t3.grup: {0}", uyan.Groups ["parça3"]);
                Console.WriteLine ("\t4.grup: {0}", uyan.Groups ["parça4"]);
                uyan = uyan.NextMatch();
            }
            tümce = "2024.06.19.1842";
            uyan = düzif.Match (tümce);
            while (uyan.Success) {
                Console.WriteLine ("==>Bulunan IP adres uyum endeksi: {0} ve deðeri: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("'{0}' için gruplar:",  tümce);
                Console.WriteLine ("\t1.grup: {0}", uyan.Groups ["parça1"]);
                Console.WriteLine ("\t2.grup: {0}", uyan.Groups ["parça2"]);
                Console.WriteLine ("\t3.grup: {0}", uyan.Groups ["parça3"]);
                Console.WriteLine ("\t4.grup: {0}", uyan.Groups ["parça4"]);
                uyan = uyan.NextMatch();
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
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