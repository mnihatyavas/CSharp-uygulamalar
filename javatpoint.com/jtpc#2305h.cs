// jtpc#2305h.cs: '$' sembolle çoklu deðiþkenli dizgeleþtirme örneði.

using System;
namespace YeniÖzellikler {
    class DolarSembolü {
        static void Main() {
            Console.Write ("'$' sembol sonrasý çift-týrnak içine istediðimiz çoklukta {deðiþken} girerek komple dizgeleþtirme yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var no = 101; var isim = "Nihal Yavaþ"; var eposta = "niyavas@gmail.com";
            Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", no, isim.ToUpper(), eposta);
            //var öðr = $"{no} no'lu öðrenci {isim.ToUpper()}'ýn epostasý: {eposta}"; Console.WriteLine (öðr);
            no = 102; isim = "Nedim Yavaþ"; eposta = "neyavas@gmail.com";
            Console.WriteLine ("\n{0} no'lu öðrenci {1}'ýn epostasý: {2}", no, isim.ToUpper(), eposta);
            //öðr = $"{no} no'lu öðrenci {isim.ToUpper()}'ýn epostasý: {eposta}"; Console.WriteLine (öðr);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}