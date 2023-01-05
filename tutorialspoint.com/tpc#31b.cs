// tpc#31b.cs: ��renci �zelliklerini soyut a��r�y�kl� t�rev eri�imcilerle yazma ve okuma �rne�i.

using System;
namespace �zellikler {
    public abstract class �ah�s {
        public abstract string Ad {get; set;}
        public abstract int Ya� {get; set;}
    }
    class ��renci: �ah�s {
        private string no = "MD"; // Mevcut De�il
        private string ad = "Bilinmiyor";
        private int ya� = 0;
        // No, Ad, Ya� �zellik beyanlar� ve set/get eri�imcileri
        public string No {get {return no;} set {no = value;} }
        public override string Ad {get {return ad;} set {ad = value;} }
        public override int Ya� {get {return ya�;} set {ya� = value;} }
        // A��r�y�klenen metod
        public override string ToString() {return "No'su = " + No +", Ad� = " + Ad + ", Ya�� = " + Ya�;}
    }
    class Soyut�zellikler {
        static void Main() {
            Console.Write ("Soyut �zellikler soyut s�n�fta tan�mlan�r ve t�rev s�n�flardaki a��r�y�kl� �zelliklerce y�r�t�l�rler.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

           ��renci ��r = new ��renci(); // Bir ��renci nesnesi yaratma
           ��r.No = "A-002"; ��r.Ad = "Z.Nihal Candan"; ��r.Ya� = 2022 - 1955; Console.WriteLine ("��renci Bilgileri:\n{0}\n", ��r);
           ��r.Ya� += 1; ��r.No = "B-002"; Console.WriteLine ("S�n�f�n� ge�en ��renci Bilgileri:\n{0}\n", ��r);
           ��r.Ya� += 1; ��r.No = "C-002"; Console.WriteLine ("S�n�f�n� ge�en ��renci Bilgileri:\n{0}\n", ��r);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}