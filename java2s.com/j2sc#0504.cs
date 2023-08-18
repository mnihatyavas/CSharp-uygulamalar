// j2sc#0504.cs: Tek ve çok boyutlu dizgesel diziler örneði.

using System;
namespace Dizgeler {
    class DizgeselDizi {
        static void Main() {
            Console.Write ("Mevcut dizi elemaný dizi[i]=\"veri\" ile deðitirilebilir. Array.Sort sýralamada büyük/küçük-harf gözetmez; türkçe harflere duyarlýdýr. Çoklu [,,] dizi boyutu/Length satýrvari tek boyutluymuþcasýnadýr; [][].. normal/çentikli dizilerde, dizi.Length ve dizi[i].Length kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgesel dizi elemanlarýnýn foreach'le taranmasý:");
            string[] dDizi1 = {"Merhaba", "Dünya", "Nasýlsýn?", ""};
            foreach (string dzg in dDizi1) Console.WriteLine (dzg);
            dDizi1[1]="Türkiye"; dDizi1[3]="Ýyi misin?";
            foreach (string dzg in dDizi1) Console.WriteLine ("\t"+dzg);

            Console.WriteLine ("\nOrijinal ve artan sýralý dizi elemanlarýnýn foreach'le taranmasý:");
            dDizi1[0]="Bir"; dDizi1[1]="Ýki"; dDizi1[2]="Üç"; dDizi1[3]="dört";
            foreach (string dzg in dDizi1) Console.Write (dzg + " "); Console.WriteLine();
            Array.Sort (dDizi1);
            foreach (string dzg in dDizi1) Console.Write (dzg+" "); Console.WriteLine("\n");
            dDizi1[2]="üöþ123"; dDizi1[0]="ÜÖÞ456"; dDizi1[3]="dene"; dDizi1[1]="DENEME";
            foreach (string dzg in dDizi1) Console.Write (dzg + " "); Console.WriteLine();
            Array.Sort (dDizi1);
            foreach (string dzg in dDizi1) Console.Write (dzg+" ");

            Console.WriteLine ("\n\nÇift boyutlu dizi elemanlarýnýn içiçe-for'la taranmasý:");
            const int satýr = 4;
            const int sütun = 4;
            string [,] dDizi2 = new string [satýr, sütun];
            dDizi2 [0, 0] = "M";
            dDizi2 [0, 1] = ".";
            dDizi2 [0, 2] = "N";
            dDizi2 [0, 3] = "i";
            dDizi2 [1, 0] = "h";
            dDizi2 [1, 1] = "a";
            dDizi2 [1, 2] = "t";
            dDizi2 [1, 3] = " ";
            dDizi2 [2, 0] = "Y";
            dDizi2 [2, 1] = "a";
            dDizi2 [2, 2] = "v";
            dDizi2 [2, 3] = "a";
            dDizi2 [3, 0] = "þ";
            dDizi2 [3, 1] = " ";
            dDizi2 [3, 2] = "4";
            dDizi2 [3, 3] = "4";
            for (int i = 0; i < satýr; i++) {
                for (int j = 0; j < sütun; j++) {Console.WriteLine ("dDizi2 [" + i + ", " + j + "] = " + dDizi2 [i, j]);}
            }

            Console.WriteLine ("\nÇift boyutlu normal ve çentikli dizi elemanlarýnýn içiçe-for'la taranmasý:");
            string[,] dDizi3 = new string [2, 3];
            dDizi3 [0, 0] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; dDizi3 [0, 1] = "abcdefghijklmnopqrstuvwxyz"; dDizi3 [0, 2] = "I-II-III-IV-V-VI-VII-VIII-IX-X-XX-XXX-XL-L-D-C-M";
            dDizi3 [1, 0] = "ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ"; dDizi3 [1, 1] = "abcçdefgðhýijklmnoöprstuüvyz"; dDizi3 [1, 2] = "0-1-2-3-4-5-6-7-8-9-10-20-30-40-50-100-500-1000";
            string[][] dDizi4 = new String [4][] {new string[]{"ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz", "I-II-III-IV-V-VI-VII-VIII-IX-X-XX-XXX-XL-L-D-C-M"}, new string[]{"qQ", "xX", "wW", "I-V-X-L-D-C-M"}, new string[]{"ABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ", "abcçdefgðhýijklmnoöprstuüvyz", "0-1-2-3-4-5-6-7-8-9-10-20-30-40-50-100-500-1000"}, new string[]{"çÇ", "ðÐ", "ýI", "iÝ",  "öÖ", "üÜ", "0-1-2-3-4-5-6"} };
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {Console.WriteLine ("dDizi3 [" + i + ", " + j + "] = " + dDizi3 [i, j]);}
            }
            Console.WriteLine ("\nÇentikli dizinin deðiþken kolonlu dökümü:");
            for (int i = 0; i < dDizi4.Length; i++) {
                Console.WriteLine ("\tBoyut = ({0}, {1})", dDizi4.Length, dDizi4 [i].Length);
                for (int j = 0; j < dDizi4 [i].Length; j++) {Console.WriteLine ("dDizi4 [" + i + ", " + j + "] = " + dDizi4 [i][j]);}
            }

            Console.WriteLine ("\nDizgesel dizi elemanlarýyla switch tercilerin uygulamasý:");
            string[] dDizi5 = { "Pazartesi", "Salý", "salÇar", "Çarþamba", "Perþembe", "Cuma", "cumartesi", "pazar"};
            foreach (string gün in dDizi5) {
                switch (gün.ToLower()) {
                    case "pazartesi": Console.WriteLine ("Haftanýn ilk iþgünü: {0}", gün.ToUpper()); break;
                    case "salý": Console.WriteLine ("Haftanýn ilk iþgünü: {0}", gün.ToUpper()); break;
                    case "çarþamba": Console.WriteLine ("Haftanýn ikinci iþgünü: {0}", gün.ToUpper()); break;
                    case "perþembe": Console.WriteLine ("Haftanýn üçüncü iþgünü: {0}", gün.ToUpper()); break;
                    case "cuma": Console.WriteLine ("Haftanýn dördüncü iþgünü: {0}", gün.ToUpper()); break;
                    case "cumartesi": Console.WriteLine ("Haftanýn sonuncu iþgünü: {0}", gün.ToUpper()); break;
                    case "pazar": Console.WriteLine ("Haftasonunun ilk tatilgünü: {0}", gün.ToUpper()); break;
                    default: Console.WriteLine ("** Yanlýþ gün verisi: {0} **", gün.ToUpper()); break;
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}