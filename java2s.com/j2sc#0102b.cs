// j2sc#0102b.cs: Özel bir öðrenci nesneli XML belgeleme yorum elemanlarý örneði.

using System;
namespace DilTemelleri {
    // <summary>Üye deðiþkenler</summary>
    public class Öðrenci {
        public int no;
        public string ad;
        public string eposta;

        // <summary>Parametreli kurucu metodu</summary>
        // <param name="no">Öðrenci numarasý</param>
        // <param name="ad">Öðrenci adý</param>
        // <param name="eposta">Öðrenci epostasý</param>
        public Öðrenci (int no, string ad, string eposta) {
            this.no = no;
            this.ad = ad;
            this.eposta = eposta;
        }
        
        // <summary>Yýkýcý metodu</summary>
        // <remarks>Program sonlarýrken yaratýlan nesnelerin imhasý
        //      <seealso cref="Öðrenci (int, string, string)">Öðrenci (int, string, string)</seealso>
        // </remarks>
        ~Öðrenci() {Console.WriteLine ("{0} adlý öðrenci nesnesi bellekten siliniyor...", ad);}
    }
    class BelgelemeYorumlarý2 {
        public static void Main (string[] argümanlar) {
            Console.Write ("XML dökümanlama yorum elemanlý Öðrenci nesnesine kurucu metoduyla atanan deðerler okunup sergilenecek ve program sonlanýrken yýkýcý metod, yaratýlan nesneleri hafýzadan temizleyecek.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci1 = new Öðrenci (1001, "M.Nihat Yavaþ", "mnihatyavas@gmail.com");
            var öðrenci2 = new Öðrenci (1002, "M.Nedim Yavaþ", "mnedimyavas@gmail.com");
            var öðrenci3 = new Öðrenci (1003, "Zafer N.Candan", "zaferncandan@gmail.com");
            Console.WriteLine ("{0} öðrenci no'lu {1}'ýn epostasý: {2}", öðrenci1.no, öðrenci1.ad, öðrenci1.eposta);
            Console.WriteLine ("{0} öðrenci no'lu {1}'ýn epostasý: {2}", öðrenci2.no, öðrenci2.ad, öðrenci2.eposta);
            Console.WriteLine ("{0} öðrenci no'lu {1}'ýn epostasý: {2}", öðrenci3.no, öðrenci3.ad, öðrenci3.eposta);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}