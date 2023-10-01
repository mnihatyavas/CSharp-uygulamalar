// j2sc#0701b.cs: Ebeveyn s�n�f/aray�zler, yap�yla/s�n�fla al/koy'lu selsiy�s/F/K �evrimleri �rne�i.

using System;
namespace S�n�flar {
    interface Al�c� {int VeriAl();}
    interface Koyucu {void VeriKoy (int x);}
    class S�n�f1 : Al�c�, Koyucu {
        int veri;
        public int VeriAl() {return veri;}
        public void VeriKoy (int x) {veri = x;}
    }
    interface Konu�abilir {string Konu�();}
    class Hayvan {}
    class Kedi: Hayvan, Konu�abilir {string Konu�abilir.Konu�() {return "Miyaav!";} }
    class K�pek: Hayvan, Konu�abilir {string Konu�abilir.Konu�() {return "Hav hav!";} }
    class Fil: Hayvan {}
    class Papa�an: Hayvan, Konu�abilir {string Konu�abilir.Konu�() {return "Herkese merhabalar!";} }
    struct Yap�1 {
        public double C;
        public double F {get {return ((9d/5d)*C)+32;} set {C = (5d/9d)*(value-32);} }
        public double K {get {return C+273.15;} set {C = value-273.12;} }
    }
    class S�n�f2 {
        public double C;
        public double F {get {return ((9d/5d)*C)+32;} set {C = (5d/9d)*(value-32);} }
        public double K {get {return C+273.15;} set {C = value-273.12;} }
    }
    class S�n�fTan�m�2 {
        static void Main() {
            Console.Write ("Yavru tek ebeveynle, fakat �oklu aray�zle miraslanabilir. Eri�im �e�itleri: public (genel; herkes eri�ebilir), private (�zel; sadece s�n�f ve alts�n�flar�ndan; varsay�l�), protected (korumal�; ayn� s�n�f/alts�n�flar ve miraslayarak), internal (i�sel; ayn� uygulamada yada tiplemeyle d��ardan), protected internal (korumal� i�sel; ayn� uygulamada yada miraslayarak d��ardan). De�i�tire�ler: new (yeni nesne; yarat�lan nesnetle sakl�), static (duruk; tek s�n�f tiplesiyle s�n�rl� de�il), virtual (sanal; t�retilen s�n�fla ta��r�labilir), abstract (soyut; aray�z gibi y�r�t�lemez �yeler �ablonudur), override (ta�ma; miraslanan metotlara ta�ma yapabilir), sealed (m�h�rl�; miraslad���na ta�ma yapan, ancak kendisini miraslayanlarca ta�malanamayan s�n�f), extern (harici; harici programramlama dillerince y�r�t�lebilir).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�oklu ebeveyn �ablon metodlar�n�n detayland�r�l�p kullan�lmas�:");
            var r=new Random();
            S�n�f1 s1 = new S�n�f1();
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Al�nan veri = {0}", s1.VeriAl());
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Al�nan veri = {0}", s1.VeriAl());
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Al�nan veri = {0}", s1.VeriAl());

            Console.WriteLine ("\nEbeveyn (tek) s�n�f ve (�oklu) aray�z miraslayan hayvan konu�malar�:");
            Hayvan[] hDizi = new Hayvan [10];
            hDizi [0] = new Kedi();
            hDizi [1] = new Fil();
            hDizi [2] = new K�pek();
            hDizi [3] = null;
            hDizi [4] = new Papa�an();
            foreach (Hayvan h in hDizi) {
                Konu�abilir k = h as Konu�abilir;
                if (k != null) Console.WriteLine ("Konu�an hayvan: {0}", k.Konu�());
            }

            Console.WriteLine ("\nSelsiy�s'ten Fahrenhayt ve Kelvin dereceye �evrim:");
            // yap� Yap�1 ile class S�n�f2 ayn�d�r...
            Yap�1 derece = new Yap�1(); S�n�f2 ds = new S�n�f2(); string selsiy�s;
            gir: Console.Write ("Selsiy�s dereceyi gir [��k: son]: "); selsiy�s = Console.ReadLine(); //K�s�rat virg�ll� (,) girilmelidir.
            if (selsiy�s.ToLower() == "son") goto son;
            try {derece.C = Convert.ToDouble (selsiy�s); ds.C = Convert.ToDouble (selsiy�s);}catch {goto gir;}
            if (derece.C < -273.12) goto gir;
            Console.WriteLine ("{0} C = {1} F\t ve {2} K", derece.C, derece.F, ds.K);
            goto gir;

            son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}