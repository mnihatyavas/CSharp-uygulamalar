// tpc#09a.cs: T�m c# i�lemcileri ve �ncelikleri �rne�i.

using System;
namespace ��lemciler {
    class T�m��lemciler {
        static void Main (string[] args) {
            Console.WriteLine ("��lemciler �e�itli matematiksel veya mant�ksal i�lemelerde kullan�lan �u haz�r ar�iv sembol/tabirlerdir: Aritmetik, ili�kisel, mant�ksal, bit-bit, atama, di�er i�lemciler.");
            Console.WriteLine ("\nAritmetik ��lemciler: A=10, B=20 ise; A+B=30, A-B=-10, A*B=200, B/A=2, B%A=0, A++=11, B--=19");
            Console.WriteLine ("\n�li�kisel ��lemciler: A=10, B=20 ise; (A == B) yanl��, (A != B) do�ru, (A > B) yanl��, (A < B) do�ru, (A >= B) yanl��, (A <= B) do�ru. A=true, B=false ise; (A && B) yanl��, (A || B) do�ru, !(A && B) do�ru.");
            Console.WriteLine ("\nBit-bit ��lemciler: p=0,0,1,1 ve q=0,1,0,1 ise VE p&q=0,0,0,1; VEYA p|q=0,1,1,1; FARKLIYSA p^q=0,1,1,0. A = 0011 1100=60 ve B = 0000 1101=13 ise A&B = 0000 1100=12, A|B = 0011 1101=61, A^B = 0011 0001=49, ~A = 1100 0011=-61 (t�mleyen + 1), A << 2 = 240 = 1111 0000, A >> 2 = 15 = 0000 1111");
            Console.WriteLine ("\nAtama ��lemciler: C = A + B, C += A: C = C + A, C -= A: C = C - A, C *= A: C = C * A, C /= A: C = C / A, C %= A: C = C % A, C <<= 2: C = C << 2, C >>= 2: C = C >> 2, C &= 2: C = C & 2, C |= 2: C = C | 2, C ^= 2: C = C ^ 2");
            Console.WriteLine ("\nDi�er ��lemciler: sizeof(int)=4, typeof(StreamReader): s�n�f tipi, &a: de�i�kenin adresi, *a: de�i�kene a g�stergesi, (true/false? : X, Y), if(Ford is Araba) Ford Araba s�n�f� nesnesi?, (object nesne = new StringReader('Selam'); StringReader okur = nesne as StringReader;)");
            Console.WriteLine ("\n��lemci �nceli�i: (�lk�ncelikli-->Son�ncelikli, LR:SoldanSa�a, RL:Sa�danSola) Grup: () [] -> . ++ -- LR, Birli: + - ! ~ ++ -- (type)* & sizeof RL, �arpan: * / % LR, Toplayan: + - LR, Kayan: << >> LR, �li�ki: < <= > >= LR, E�itlik: == != LR, �kili VE: & LR, �kili FARKLIYSA: ^ LR, �kili VEYA: | LR, Mant�ksal VE && LR, Mant�ksal VEYA: || LR, �artl�: ?: RL, Atama: = += -= *= /= %=>>= <<= &= ^= |= RL, Virg�l: , LR");
            Console.Write ("\nTu�...");
            Console.ReadKey();
        }
    }
}