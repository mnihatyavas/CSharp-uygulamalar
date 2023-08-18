// j2sc#0317.cs: typeof iþlemci ve GetType() metotla tip tespiti örneði.

using System;
using System.IO; //StreamReader, TextReader
using System.Reflection; //FieldInfo
using System.Text; //StringBuilder
namespace Ýþlemciler {
    class BirSýnýf {}
    class Sýnýfým {
        public int Alan_A;
        public int Alan_B;
        public string Alan_C;
        public void Metod1() {}
        public int  Metod2() {return 20230628;}
    }
    class typeof_Ýþlemci {
        static void Main() {
            Console.Write ("typeof (tip) tanýmlý tipi verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bir somut System.IO sýnýf tipinin sorgulanmasý:");
            Type tip = typeof (StreamReader); 
            Console.WriteLine ("typeof (StreamReader) = {0}\ntypeof (TextReader) = {1}", typeof (StreamReader).FullName, typeof (TextReader));
            if (tip.IsClass) Console.WriteLine ("typeof (StreamReader) bir sýnýftýr.");
            if (tip.IsAbstract) Console.WriteLine ("typeof (StreamReader) bir soyuttur.");
            else Console.WriteLine ("typeof (StreamReader) bir somuttur.");

            Console.WriteLine ("\nArþiv tanýmlý StringReader ve özel tanýmlý BirSýnýf tiplemeleri:");
            Object birNesne = new StringReader ("Bu bir StringReader dizgeokuyucudur.");
            if (typeof (StringReader) == birNesne.GetType()) {Console.WriteLine ("typeof: birNesne, bir StringReader'dýr.");}
            BirSýnýf diðerNesne = new BirSýnýf();
            if (diðerNesne.GetType() == typeof (BirSýnýf)) {Console.WriteLine ("Burada bir BirSýnýf tiplemeli nesne vardýr.");}

            Type tipim = typeof (Sýnýfým); int i=0;
            Console.WriteLine ("\nSýnýfým ({0}) ve alan üyelerinin tipleri:", tipim);
            FieldInfo[] fi = tipim.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan-{0}: {1}", ++i, f);

            Console.WriteLine ("\ntypeof() tipi, deðiþken.GetType() tipli deðiþkeni ister:");
            var nesne = new StringBuilder();
            Console.WriteLine ("typeof (StringBuilder) = {0}\n\tnesne.GetType() = {1}", typeof (StringBuilder), nesne.GetType());
            Console.WriteLine ("typeof (int) = {0}\n\ti.GetType() = {1}", typeof (int), i.GetType());


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}