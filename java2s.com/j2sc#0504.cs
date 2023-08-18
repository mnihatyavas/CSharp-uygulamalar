// j2sc#0504.cs: Tek ve �ok boyutlu dizgesel diziler �rne�i.

using System;
namespace Dizgeler {
    class DizgeselDizi {
        static void Main() {
            Console.Write ("Mevcut dizi eleman� dizi[i]=\"veri\" ile de�itirilebilir. Array.Sort s�ralamada b�y�k/k���k-harf g�zetmez; t�rk�e harflere duyarl�d�r. �oklu [,,] dizi boyutu/Length sat�rvari tek boyutluymu�cas�nad�r; [][].. normal/�entikli dizilerde, dizi.Length ve dizi[i].Length kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgesel dizi elemanlar�n�n foreach'le taranmas�:");
            string[] dDizi1 = {"Merhaba", "D�nya", "Nas�ls�n?", ""};
            foreach (string dzg in dDizi1) Console.WriteLine (dzg);
            dDizi1[1]="T�rkiye"; dDizi1[3]="�yi misin?";
            foreach (string dzg in dDizi1) Console.WriteLine ("\t"+dzg);

            Console.WriteLine ("\nOrijinal ve artan s�ral� dizi elemanlar�n�n foreach'le taranmas�:");
            dDizi1[0]="Bir"; dDizi1[1]="�ki"; dDizi1[2]="��"; dDizi1[3]="d�rt";
            foreach (string dzg in dDizi1) Console.Write (dzg + " "); Console.WriteLine();
            Array.Sort (dDizi1);
            foreach (string dzg in dDizi1) Console.Write (dzg+" "); Console.WriteLine("\n");
            dDizi1[2]="���123"; dDizi1[0]="���456"; dDizi1[3]="dene"; dDizi1[1]="DENEME";
            foreach (string dzg in dDizi1) Console.Write (dzg + " "); Console.WriteLine();
            Array.Sort (dDizi1);
            foreach (string dzg in dDizi1) Console.Write (dzg+" ");

            Console.WriteLine ("\n\n�ift boyutlu dizi elemanlar�n�n i�i�e-for'la taranmas�:");
            const int sat�r = 4;
            const int s�tun = 4;
            string [,] dDizi2 = new string [sat�r, s�tun];
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
            dDizi2 [3, 0] = "�";
            dDizi2 [3, 1] = " ";
            dDizi2 [3, 2] = "4";
            dDizi2 [3, 3] = "4";
            for (int i = 0; i < sat�r; i++) {
                for (int j = 0; j < s�tun; j++) {Console.WriteLine ("dDizi2 [" + i + ", " + j + "] = " + dDizi2 [i, j]);}
            }

            Console.WriteLine ("\n�ift boyutlu normal ve �entikli dizi elemanlar�n�n i�i�e-for'la taranmas�:");
            string[,] dDizi3 = new string [2, 3];
            dDizi3 [0, 0] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; dDizi3 [0, 1] = "abcdefghijklmnopqrstuvwxyz"; dDizi3 [0, 2] = "I-II-III-IV-V-VI-VII-VIII-IX-X-XX-XXX-XL-L-D-C-M";
            dDizi3 [1, 0] = "ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ"; dDizi3 [1, 1] = "abc�defg�h�ijklmno�prstu�vyz"; dDizi3 [1, 2] = "0-1-2-3-4-5-6-7-8-9-10-20-30-40-50-100-500-1000";
            string[][] dDizi4 = new String [4][] {new string[]{"ABCDEFGHIJKLMNOPQRSTUVWXYZ", "abcdefghijklmnopqrstuvwxyz", "I-II-III-IV-V-VI-VII-VIII-IX-X-XX-XXX-XL-L-D-C-M"}, new string[]{"qQ", "xX", "wW", "I-V-X-L-D-C-M"}, new string[]{"ABC�DEFG�HI�JKLMNO�PRS�TU�VYZ", "abc�defg�h�ijklmno�prstu�vyz", "0-1-2-3-4-5-6-7-8-9-10-20-30-40-50-100-500-1000"}, new string[]{"��", "��", "�I", "i�",  "��", "��", "0-1-2-3-4-5-6"} };
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {Console.WriteLine ("dDizi3 [" + i + ", " + j + "] = " + dDizi3 [i, j]);}
            }
            Console.WriteLine ("\n�entikli dizinin de�i�ken kolonlu d�k�m�:");
            for (int i = 0; i < dDizi4.Length; i++) {
                Console.WriteLine ("\tBoyut = ({0}, {1})", dDizi4.Length, dDizi4 [i].Length);
                for (int j = 0; j < dDizi4 [i].Length; j++) {Console.WriteLine ("dDizi4 [" + i + ", " + j + "] = " + dDizi4 [i][j]);}
            }

            Console.WriteLine ("\nDizgesel dizi elemanlar�yla switch tercilerin uygulamas�:");
            string[] dDizi5 = { "Pazartesi", "Sal�", "sal�ar", "�ar�amba", "Per�embe", "Cuma", "cumartesi", "pazar"};
            foreach (string g�n in dDizi5) {
                switch (g�n.ToLower()) {
                    case "pazartesi": Console.WriteLine ("Haftan�n ilk i�g�n�: {0}", g�n.ToUpper()); break;
                    case "sal�": Console.WriteLine ("Haftan�n ilk i�g�n�: {0}", g�n.ToUpper()); break;
                    case "�ar�amba": Console.WriteLine ("Haftan�n ikinci i�g�n�: {0}", g�n.ToUpper()); break;
                    case "per�embe": Console.WriteLine ("Haftan�n ���nc� i�g�n�: {0}", g�n.ToUpper()); break;
                    case "cuma": Console.WriteLine ("Haftan�n d�rd�nc� i�g�n�: {0}", g�n.ToUpper()); break;
                    case "cumartesi": Console.WriteLine ("Haftan�n sonuncu i�g�n�: {0}", g�n.ToUpper()); break;
                    case "pazar": Console.WriteLine ("Haftasonunun ilk tatilg�n�: {0}", g�n.ToUpper()); break;
                    default: Console.WriteLine ("** Yanl�� g�n verisi: {0} **", g�n.ToUpper()); break;
                }
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}