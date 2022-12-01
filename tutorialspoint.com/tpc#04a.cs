// tpc#04a.cs: Verili en ve boy de�erleriyle dikd�rtgen alan�n�n hesaplanmas� �rne�i.

using System;
namespace TemelS�zdizim {
    class Dikd�rtgen {
        // S�n�f alt� "�ye de�i�kenler"
        double en;
        double boy;
        // S�n�f alt� "�ye fonksiyonlar"
        public void De�erleriAl() {
            en = 4.5;
            boy = 3.5;
        }
        public double Alan�Hesapla() {return en * boy;}
        public void G�ster() {
            Console.WriteLine ("En: {0}", en);
            Console.WriteLine ("Boy: {0}", boy);
            Console.Write ("Dikd�rtgenin Alan�: {0}\nEnt..", Alan�Hesapla());
        }
    }

    class Dikd�rtgenAlan� {
        static void Main (string[] args) {
            Dikd�rtgen d = new Dikd�rtgen();
            d.De�erleriAl();
            d.G�ster();
            Console.ReadLine(); // Enter bas
        }
    }
}