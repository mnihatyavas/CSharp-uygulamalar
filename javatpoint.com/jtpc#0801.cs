// jtpc#0801.cs: Ebeveyn-yavru-lar mirasýyla atalarýn tüm üyelerini kullanabilme örneði.

using System;
namespace Kalýtsallýk {
    public class Ýþgören {
        public float asgariÜcret = 4000;
        public float bayramÝkramiyesi = 1000;
    }
    public class Programcý: Ýþgören {// Ebeveyn alanlarýný miraslar
        public float teþvikPrimi = 500;
        public float baþarýBonusu = 1500;
        public float kariyerEki = 2500;
    }
    public class Hayvanlar {public void ye() {Console.WriteLine ("\nYiyor...");} }
    public class AnaKöpek: Hayvanlar {public void havla() {Console.WriteLine ("Havlýyor...");} }
    public class ÇocukKöpek: AnaKöpek {public void gül() {Console.WriteLine ("Gülüyor...");} }
    public class TorunKöpek: ÇocukKöpek {public void aðla() {Console.WriteLine ("Aðlýyor...");} } //Ebeveyn metodlarýný miraslar
    class Miras {
        static void Main() {
            Console.Write ("Türev sýnýf, miraslanan temel sýnýfýn tüm üyelerinin (alan, metod vb) davranýþ ve özelliklerini, yeniden kodlamadan aynen kullanabilir, deðiþtirebilir veya alt-yavrulara esnetebilir. Tek temel-türev iliþkisi tek-seviyeli, çok ebeveyn-yavrular ise çok-seviyeli mirastýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Programcý p = new Programcý(); float toplamMaaþ = p.asgariÜcret+p.bayramÝkramiyesi+p.teþvikPrimi+p.baþarýBonusu+p.kariyerEki;
            Console.WriteLine ("Maaþ: [Ücret+Ýkramiye+Prim+Bonus+Ek] = [{0}+{1}+{2}+{3}+{4} = {5}]TL", p.asgariÜcret, p.bayramÝkramiyesi, p.teþvikPrimi, p.baþarýBonusu, p.kariyerEki, toplamMaaþ);

            AnaKöpek ak = new AnaKöpek(); ak.ye(); ak.havla(); //Tek-seviyeli (1) miras

            TorunKöpek tk = new TorunKöpek(); tk.ye(); tk.havla(); tk.gül(); tk.aðla(); //Çok-seviyeli (3) miras

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}