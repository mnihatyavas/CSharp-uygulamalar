// j2sc#0102b.cs: �zel bir ��renci nesneli XML belgeleme yorum elemanlar� �rne�i.

using System;
namespace DilTemelleri {
    // <summary>�ye de�i�kenler</summary>
    public class ��renci {
        public int no;
        public string ad;
        public string eposta;

        // <summary>Parametreli kurucu metodu</summary>
        // <param name="no">��renci numaras�</param>
        // <param name="ad">��renci ad�</param>
        // <param name="eposta">��renci epostas�</param>
        public ��renci (int no, string ad, string eposta) {
            this.no = no;
            this.ad = ad;
            this.eposta = eposta;
        }
        
        // <summary>Y�k�c� metodu</summary>
        // <remarks>Program sonlar�rken yarat�lan nesnelerin imhas�
        //      <seealso cref="��renci (int, string, string)">��renci (int, string, string)</seealso>
        // </remarks>
        ~��renci() {Console.WriteLine ("{0} adl� ��renci nesnesi bellekten siliniyor...", ad);}
    }
    class BelgelemeYorumlar�2 {
        public static void Main (string[] arg�manlar) {
            Console.Write ("XML d�k�manlama yorum elemanl� ��renci nesnesine kurucu metoduyla atanan de�erler okunup sergilenecek ve program sonlan�rken y�k�c� metod, yarat�lan nesneleri haf�zadan temizleyecek.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new ��renci (1001, "M.Nihat Yava�", "mnihatyavas@gmail.com");
            var ��renci2 = new ��renci (1002, "M.Nedim Yava�", "mnedimyavas@gmail.com");
            var ��renci3 = new ��renci (1003, "Zafer N.Candan", "zaferncandan@gmail.com");
            Console.WriteLine ("{0} ��renci no'lu {1}'�n epostas�: {2}", ��renci1.no, ��renci1.ad, ��renci1.eposta);
            Console.WriteLine ("{0} ��renci no'lu {1}'�n epostas�: {2}", ��renci2.no, ��renci2.ad, ��renci2.eposta);
            Console.WriteLine ("{0} ��renci no'lu {1}'�n epostas�: {2}", ��renci3.no, ��renci3.ad, ��renci3.eposta);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}