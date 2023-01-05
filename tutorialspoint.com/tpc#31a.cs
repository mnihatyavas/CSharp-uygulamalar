// tpc#31a.cs: ��renci �zelliklerini eri�imcilerle yazma ve okuma �rne�i.

using System;
namespace �zellikler {
    class ��renci {
        private string no = "MD"; // Mevcut De�il
        private string ad = "Bilinmiyor";
        private int ya� = 0;
        // No, Ad, Ya� �zellik beyanlar� ve set/get eri�imcileri
        public string No {get {return no;} set {no = value;} }
        public string Ad {get {return ad;} set {ad = value;} }
        public int Ya� {get {return ya�;} set {ya� = value;} }
        // A��r�y�klenen metod
        public override string ToString() {return "No'su = " + No +", Ad� = " + Ad + ", Ya�� = " + Ya�;}
    }
    class �zelliklereEri�im {
        static void Main() {
            Console.Write ("S�n�f ve yap� de�i�ken ve metodlar� birer alan olup, de�erleri �zelliklerdir ve eri�imcilerle (set/koy ve get/al) yaz�l�p okunurlar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

           ��renci ��r = new ��renci(); // Bir ��renci nesnesi yaratma
           ��r.No = "A-001"; ��r.Ad = "M.Nihat Yava�"; ��r.Ya� = 2022 - 1957; Console.WriteLine ("��renci Bilgileri:\n{0}\n", ��r);
           ��r.Ya� += 1; ��r.No = "B-001"; Console.WriteLine ("S�n�f�n� ge�en ��renci Bilgileri:\n{0}\n", ��r);
           ��r.Ya� += 1; ��r.No = "C-001"; Console.WriteLine ("S�n�f�n� ge�en ��renci Bilgileri:\n{0}\n", ��r);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}