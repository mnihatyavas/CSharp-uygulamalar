// jtpc#2305h.cs: '$' sembolle �oklu de�i�kenli dizgele�tirme �rne�i.

using System;
namespace Yeni�zellikler {
    class DolarSembol� {
        static void Main() {
            Console.Write ("'$' sembol sonras� �ift-t�rnak i�ine istedi�imiz �oklukta {de�i�ken} girerek komple dizgele�tirme yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var no = 101; var isim = "Nihal Yava�"; var eposta = "niyavas@gmail.com";
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", no, isim.ToUpper(), eposta);
            //var ��r = $"{no} no'lu ��renci {isim.ToUpper()}'�n epostas�: {eposta}"; Console.WriteLine (��r);
            no = 102; isim = "Nedim Yava�"; eposta = "neyavas@gmail.com";
            Console.WriteLine ("\n{0} no'lu ��renci {1}'�n epostas�: {2}", no, isim.ToUpper(), eposta);
            //��r = $"{no} no'lu ��renci {isim.ToUpper()}'�n epostas�: {eposta}"; Console.WriteLine (��r);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}