// tpc#08a.cs: Tan�m sonras� de�i�meyen sabitler/dura�anlar �rne�i.

using System;
namespace SabilerDura�anlar {
    class SabitTan�m {
        static void Main (string[] args) {
            Console.Write ("Sabitler tan�mla ilkde�er atanma sonras� de�i�tirilmez, hata verirler.\nSabit de�erler: tamsay�, kayannokta, karakter, dizge ve say�sallanan olabilir.\nTamsay� ondal�k �neksiz, onalt�l�k �neki 0x, sonekler (k���k/b�y�k-harf, �nceliksiz u=unsigned/i�aretsiz, L=long/uzun). �rn:85, 85u, 85Lu, 0x59\nKayannoktal� dura�anlar ondal�k k�s�ratl� veya E/e �sl� olabilir. �rn: 3.14159, 314159e-5F\nKarakter sabitler tekt�rnakl� krk ('A'), esc-krk ('\t') veya evrensel krk ('\u02C0') olabilir.\nDizgesel sabitler �iftt�rnak (\"\") veya (@\"\") olabilir. �rn: \"Selam, can�m\", @\"Selam, can�m\", \"Selam, \" \"c\" \"an�m\". \"Selam, \\can�m\".\nTu�...");
            Console.ReadKey();
        }
    }
}