// j2sc#0701b.cs: Ebeveyn sýnýf/arayüzler, yapýyla/sýnýfla al/koy'lu selsiyüs/F/K çevrimleri örneði.

using System;
namespace Sýnýflar {
    interface Alýcý {int VeriAl();}
    interface Koyucu {void VeriKoy (int x);}
    class Sýnýf1 : Alýcý, Koyucu {
        int veri;
        public int VeriAl() {return veri;}
        public void VeriKoy (int x) {veri = x;}
    }
    interface Konuþabilir {string Konuþ();}
    class Hayvan {}
    class Kedi: Hayvan, Konuþabilir {string Konuþabilir.Konuþ() {return "Miyaav!";} }
    class Köpek: Hayvan, Konuþabilir {string Konuþabilir.Konuþ() {return "Hav hav!";} }
    class Fil: Hayvan {}
    class Papaðan: Hayvan, Konuþabilir {string Konuþabilir.Konuþ() {return "Herkese merhabalar!";} }
    struct Yapý1 {
        public double C;
        public double F {get {return ((9d/5d)*C)+32;} set {C = (5d/9d)*(value-32);} }
        public double K {get {return C+273.15;} set {C = value-273.12;} }
    }
    class Sýnýf2 {
        public double C;
        public double F {get {return ((9d/5d)*C)+32;} set {C = (5d/9d)*(value-32);} }
        public double K {get {return C+273.15;} set {C = value-273.12;} }
    }
    class SýnýfTanýmý2 {
        static void Main() {
            Console.Write ("Yavru tek ebeveynle, fakat çoklu arayüzle miraslanabilir. Eriþim çeþitleri: public (genel; herkes eriþebilir), private (özel; sadece sýnýf ve altsýnýflarýndan; varsayýlý), protected (korumalý; ayný sýnýf/altsýnýflar ve miraslayarak), internal (içsel; ayný uygulamada yada tiplemeyle dýþardan), protected internal (korumalý içsel; ayný uygulamada yada miraslayarak dýþardan). Deðiþtireçler: new (yeni nesne; yaratýlan nesnetle saklý), static (duruk; tek sýnýf tiplesiyle sýnýrlý deðil), virtual (sanal; türetilen sýnýfla taþýrýlabilir), abstract (soyut; arayüz gibi yürütülemez üyeler þablonudur), override (taþma; miraslanan metotlara taþma yapabilir), sealed (mühürlü; mirasladýðýna taþma yapan, ancak kendisini miraslayanlarca taþmalanamayan sýnýf), extern (harici; harici programramlama dillerince yürütülebilir).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çoklu ebeveyn þablon metodlarýnýn detaylandýrýlýp kullanýlmasý:");
            var r=new Random();
            Sýnýf1 s1 = new Sýnýf1();
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Alýnan veri = {0}", s1.VeriAl());
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Alýnan veri = {0}", s1.VeriAl());
            s1.VeriKoy (r.Next (-10000, 10000)); Console.WriteLine ("Alýnan veri = {0}", s1.VeriAl());

            Console.WriteLine ("\nEbeveyn (tek) sýnýf ve (çoklu) arayüz miraslayan hayvan konuþmalarý:");
            Hayvan[] hDizi = new Hayvan [10];
            hDizi [0] = new Kedi();
            hDizi [1] = new Fil();
            hDizi [2] = new Köpek();
            hDizi [3] = null;
            hDizi [4] = new Papaðan();
            foreach (Hayvan h in hDizi) {
                Konuþabilir k = h as Konuþabilir;
                if (k != null) Console.WriteLine ("Konuþan hayvan: {0}", k.Konuþ());
            }

            Console.WriteLine ("\nSelsiyüs'ten Fahrenhayt ve Kelvin dereceye çevrim:");
            // yapý Yapý1 ile class Sýnýf2 aynýdýr...
            Yapý1 derece = new Yapý1(); Sýnýf2 ds = new Sýnýf2(); string selsiyüs;
            gir: Console.Write ("Selsiyüs dereceyi gir [Çýk: son]: "); selsiyüs = Console.ReadLine(); //Küsürat virgüllü (,) girilmelidir.
            if (selsiyüs.ToLower() == "son") goto son;
            try {derece.C = Convert.ToDouble (selsiyüs); ds.C = Convert.ToDouble (selsiyüs);}catch {goto gir;}
            if (derece.C < -273.12) goto gir;
            Console.WriteLine ("{0} C = {1} F\t ve {2} K", derece.C, derece.F, ds.K);
            goto gir;

            son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}