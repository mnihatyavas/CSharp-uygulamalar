// tpc#08a.cs: Taným sonrasý deðiþmeyen sabitler/duraðanlar örneði.

using System;
namespace SabilerDuraðanlar {
    class SabitTaným {
        static void Main (string[] args) {
            Console.Write ("Sabitler tanýmla ilkdeðer atanma sonrasý deðiþtirilmez, hata verirler.\nSabit deðerler: tamsayý, kayannokta, karakter, dizge ve sayýsallanan olabilir.\nTamsayý ondalýk öneksiz, onaltýlýk öneki 0x, sonekler (küçük/büyük-harf, önceliksiz u=unsigned/iþaretsiz, L=long/uzun). Örn:85, 85u, 85Lu, 0x59\nKayannoktalý duraðanlar ondalýk küsüratlý veya E/e üslü olabilir. Örn: 3.14159, 314159e-5F\nKarakter sabitler tektýrnaklý krk ('A'), esc-krk ('\t') veya evrensel krk ('\u02C0') olabilir.\nDizgesel sabitler çifttýrnak (\"\") veya (@\"\") olabilir. Örn: \"Selam, caným\", @\"Selam, caným\", \"Selam, \" \"c\" \"aným\". \"Selam, \\caným\".\nTuþ...");
            Console.ReadKey();
        }
    }
}