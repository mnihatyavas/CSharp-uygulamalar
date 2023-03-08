// jtpc#2302f.cs: �lk yarat�m de�erlemesiyle nesne ve koleksiyon kay�tlar� atama �rne�i.

using System;
using System.Collections.Generic;
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string �sim {get; set;}
        public string Eposta {get; set;}
    }
    class NesneKoleksiyon�lkde�erleme {
        static void Main() {
            Console.Write ("Nesne ilkde�erleyici, s�n�f �ye de�i�kenlerine ilk yarat�mda de�er atar. Keza koleksiyon elemanlar� da 'add' ile de�il ilk yarat�m de�erlemeleriyle ard���k eklenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new ��renci {No = 101, �sim = "Hatice Yava�", Eposta = "htyavas@misal.com"};
            var ��renci2 = new ��renci {No = 102, �sim = "S�leyha Yava�", Eposta = "slyavas@misal.com"};
            Console.WriteLine ("{0} ��renci no'lu {1}'�n eposta adresi: {2}", ��renci1.No, ��renci1.�sim, ��renci1.Eposta);
            Console.WriteLine ("{0} ��renci no'lu {1}'�n eposta adresi: {2}\n", ��renci2.No, ��renci2.�sim, ��renci2.Eposta);

            var ��renciler = new List<��renci> {
                new ��renci {No = 103, �sim = "Nihal Yava�", Eposta = "nhyavas@misal.com"},
                new ��renci {No = 104, �sim = "Song�l Yava�", Eposta = "snyavas@misal.com"},
                new ��renci {No = 105, �sim = "Sevim Yava�", Eposta = "svyavas@misal.com"}
            };
            foreach (��renci � in ��renciler) {Console.WriteLine ("{0} ��renci no'lu {1}'�n eposta adresi: {2}", �.No, �.�sim, �.Eposta);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}