// jtpc#2305e.cs: 'set'siz oto ilkde�erlemeyle de�itirilemez �zellik �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        public string �sim {get; set;} //csc-5 set'siz ilk de�er atam�yor
        public string Eposta {get;set;}
        public ��renci() {�sim = "M.Nihat Yava�"; Eposta = "mnihatyavas@gmail.com";}
    }
    class Setsiz�zellik {
        static void Main() {
            Console.Write ("S�n�f de�i�ken �zelli�ini set'siz k�larak ilkde�erleme harici de�i�tirilemezli�i sa�lan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            ��renci nesne = new ��renci(); Console.WriteLine ("�sim ve eposta: [{0} - {1}]", nesne.�sim, nesne.Eposta);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}