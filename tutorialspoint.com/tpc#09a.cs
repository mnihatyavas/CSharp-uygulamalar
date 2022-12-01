// tpc#09a.cs: Tüm c# iþlemcileri ve öncelikleri örneði.

using System;
namespace Ýþlemciler {
    class TümÝþlemciler {
        static void Main (string[] args) {
            Console.WriteLine ("Ýþlemciler çeþitli matematiksel veya mantýksal iþlemelerde kullanýlan þu hazýr arþiv sembol/tabirlerdir: Aritmetik, iliþkisel, mantýksal, bit-bit, atama, diðer iþlemciler.");
            Console.WriteLine ("\nAritmetik Ýþlemciler: A=10, B=20 ise; A+B=30, A-B=-10, A*B=200, B/A=2, B%A=0, A++=11, B--=19");
            Console.WriteLine ("\nÝliþkisel Ýþlemciler: A=10, B=20 ise; (A == B) yanlýþ, (A != B) doðru, (A > B) yanlýþ, (A < B) doðru, (A >= B) yanlýþ, (A <= B) doðru. A=true, B=false ise; (A && B) yanlýþ, (A || B) doðru, !(A && B) doðru.");
            Console.WriteLine ("\nBit-bit Ýþlemciler: p=0,0,1,1 ve q=0,1,0,1 ise VE p&q=0,0,0,1; VEYA p|q=0,1,1,1; FARKLIYSA p^q=0,1,1,0. A = 0011 1100=60 ve B = 0000 1101=13 ise A&B = 0000 1100=12, A|B = 0011 1101=61, A^B = 0011 0001=49, ~A = 1100 0011=-61 (tümleyen + 1), A << 2 = 240 = 1111 0000, A >> 2 = 15 = 0000 1111");
            Console.WriteLine ("\nAtama Ýþlemciler: C = A + B, C += A: C = C + A, C -= A: C = C - A, C *= A: C = C * A, C /= A: C = C / A, C %= A: C = C % A, C <<= 2: C = C << 2, C >>= 2: C = C >> 2, C &= 2: C = C & 2, C |= 2: C = C | 2, C ^= 2: C = C ^ 2");
            Console.WriteLine ("\nDiðer Ýþlemciler: sizeof(int)=4, typeof(StreamReader): sýnýf tipi, &a: deðiþkenin adresi, *a: deðiþkene a göstergesi, (true/false? : X, Y), if(Ford is Araba) Ford Araba sýnýfý nesnesi?, (object nesne = new StringReader('Selam'); StringReader okur = nesne as StringReader;)");
            Console.WriteLine ("\nÝþlemci önceliði: (Ýlköncelikli-->Sonöncelikli, LR:SoldanSaða, RL:SaðdanSola) Grup: () [] -> . ++ -- LR, Birli: + - ! ~ ++ -- (type)* & sizeof RL, Çarpan: * / % LR, Toplayan: + - LR, Kayan: << >> LR, Ýliþki: < <= > >= LR, Eþitlik: == != LR, Ýkili VE: & LR, Ýkili FARKLIYSA: ^ LR, Ýkili VEYA: | LR, Mantýksal VE && LR, Mantýksal VEYA: || LR, Þartlý: ?: RL, Atama: = += -= *= /= %=>>= <<= &= ^= |= RL, Virgül: , LR");
            Console.Write ("\nTuþ...");
            Console.ReadKey();
        }
    }
}