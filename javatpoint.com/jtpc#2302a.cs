// jtpc#2302a.cs: Anonim tipli kay�tlara de�er atama veya koleksiyon sorgusunda kullanma �rne�i.

using System;
using System.Collections.Generic;
using System.Linq; //Sorgu (from-select) gerektirir
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string �sim {get; set;}
        public string Eposta {get; set;}
    }
    class AnonimTip {
        static void Main() {
            Console.Write ("Anonim tip 'new' anahtarkelimesiyle yarat�lan bir nesne olup, do�rudan �zellik=de�er atamalar� yap�labilir. Koleksiyon sorgular�nda da kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci1 = new {No = 101, �sim = "Hatice Yava�", Eposta = "htyavas@misal.com"}; //Anonim tip
            var ��renci2 = new {No = 102, �sim = "S�leyha Yava�", Eposta = "slyavas@misal.com"};
            var ��renci3 = new {No = 103, �sim = "Nihal Yava�", Eposta = "nhyavas@misal.com"};
            var ��renci4 = new {No = 104, �sim = "Song�l Yava�", Eposta = "snyavas@misal.com"};
            var ��renci5 = new {No = 105, �sim = "Sevim Yava�", Eposta = "svyavas@misal.com"};
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]", ��renci1.No, ��renci1.�sim, ��renci1.Eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]", ��renci2.No, ��renci2.�sim, ��renci2.Eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]", ��renci3.No, ��renci3.�sim, ��renci3.Eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]", ��renci4.No, ��renci4.�sim, ��renci4.Eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]\n", ��renci5.No, ��renci5.�sim, ��renci5.Eposta);

            var ��renciler = new List<��renci> {
                new  ��renci {No=401, �sim="Fatma Yava�", Eposta="ftyavas@misal.com"},
                new  ��renci {No=402, �sim="Bekir Yava�", Eposta="bkyavas@misal.com"},
                new  ��renci {No=301, �sim="Han�m Yava�", Eposta="hnyavas@misal.com"},
                new  ��renci {No=302, �sim="Memet Yava�", Eposta="mmyavas@misal.com"},
                new  ��renci {No=201, �sim="M.Nihat Yava�", Eposta="niyavas@misal.com"},
                new  ��renci {No=202, �sim="M.Nedim Yava�", Eposta="neyavas@misal.com"},
            };
            var sorgu =
                from ��renci in ��renciler
                select new {��renci.No, ��renci.�sim, ��renci.Eposta}; //Anonim tip
            foreach (var ��r in sorgu) {Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: [{2}]", ��r.No, ��r.�sim, ��r.Eposta);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}