// tpc#18a.cs: Say�sallanan haftan�n g�nad� sabitleri �rne�i.

using System;
namespace Say�sallananlar {
    class Haftan�nG�nleri {
        enum G�nler {Paz=1, Pzt, Sal, �ar, Per, Cum, Cmt}; // "G�nler" tipli g�nad� sabitleri
        static void Main (string[] args) {
            Console.Write ("Genel tan�m�: enum <say�sal-ad> {sayasallanan liste};\nSay�sallanan ad listesinin ilki varsay�l� o'da itibaren endekslenir.\nTu�..."); Console.ReadKey();

            int[] haftaG�nS�ralamas� = new int [7] {(int)G�nler.Paz, (int)G�nler.Pzt, (int)G�nler.Sal, (int)G�nler.�ar, (int)G�nler.Per, (int)G�nler.Cum, (int)G�nler.Cmt};
            Console.WriteLine ("\n\nHaftan�n g�nadlar� ve numaralar�:");
            byte i = 0;
            foreach (string g�n in Enum.GetNames (typeof (G�nler))) {Console.WriteLine ("G�n ad�: [{0}], G�n no: [{1}]", g�n, haftaG�nS�ralamas� [i++]);}
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}