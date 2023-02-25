// jtpc#230207.cs: S�n�f �zelliklerine 'get-set'le de�er atama-okuma �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string �sim {get; set;}
        public string GSM; // get-set protokols�z de olabilir
        public string Eposta {get; set;}
    }
    class AlKoy�zellikler {
        static void Main() {
            Console.Write ("Eri�ilebilir s�n�f �ye de�i�kenlerine yal�n 'get; set;' anahtarkelimeli �zellik atfederek kolayca de�er atama-okuma y�r�tme kazand�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��r = new ��renci();
            ��r.No = 1047; ��r.�sim = "M.Nihat Yava�"; ��r.Eposta = "mnihatyavas@gmail.com"; ��r.GSM = "+90-551-555-95-65";
            Console.WriteLine ("GSM'i {0} olan {1} ��renci no'lu {2}'�n eposta adresi: {3}", ��r.GSM, ��r.No, ��r.�sim, ��r.Eposta);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}