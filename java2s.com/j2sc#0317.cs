// j2sc#0317.cs: typeof i�lemci ve GetType() metotla tip tespiti �rne�i.

using System;
using System.IO; //StreamReader, TextReader
using System.Reflection; //FieldInfo
using System.Text; //StringBuilder
namespace ��lemciler {
    class BirS�n�f {}
    class S�n�f�m {
        public int Alan_A;
        public int Alan_B;
        public string Alan_C;
        public void Metod1() {}
        public int  Metod2() {return 20230628;}
    }
    class typeof_��lemci {
        static void Main() {
            Console.Write ("typeof (tip) tan�ml� tipi verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bir somut System.IO s�n�f tipinin sorgulanmas�:");
            Type tip = typeof (StreamReader); 
            Console.WriteLine ("typeof (StreamReader) = {0}\ntypeof (TextReader) = {1}", typeof (StreamReader).FullName, typeof (TextReader));
            if (tip.IsClass) Console.WriteLine ("typeof (StreamReader) bir s�n�ft�r.");
            if (tip.IsAbstract) Console.WriteLine ("typeof (StreamReader) bir soyuttur.");
            else Console.WriteLine ("typeof (StreamReader) bir somuttur.");

            Console.WriteLine ("\nAr�iv tan�ml� StringReader ve �zel tan�ml� BirS�n�f tiplemeleri:");
            Object birNesne = new StringReader ("Bu bir StringReader dizgeokuyucudur.");
            if (typeof (StringReader) == birNesne.GetType()) {Console.WriteLine ("typeof: birNesne, bir StringReader'd�r.");}
            BirS�n�f di�erNesne = new BirS�n�f();
            if (di�erNesne.GetType() == typeof (BirS�n�f)) {Console.WriteLine ("Burada bir BirS�n�f tiplemeli nesne vard�r.");}

            Type tipim = typeof (S�n�f�m); int i=0;
            Console.WriteLine ("\nS�n�f�m ({0}) ve alan �yelerinin tipleri:", tipim);
            FieldInfo[] fi = tipim.GetFields();
            foreach (FieldInfo f in fi) Console.WriteLine ("Alan-{0}: {1}", ++i, f);

            Console.WriteLine ("\ntypeof() tipi, de�i�ken.GetType() tipli de�i�keni ister:");
            var nesne = new StringBuilder();
            Console.WriteLine ("typeof (StringBuilder) = {0}\n\tnesne.GetType() = {1}", typeof (StringBuilder), nesne.GetType());
            Console.WriteLine ("typeof (int) = {0}\n\ti.GetType() = {1}", typeof (int), i.GetType());


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}