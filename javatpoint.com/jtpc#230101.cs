// jtpc#230101.cs: �ki ayr� k�smi altprogram�n anaprogramla �al��t�r�lmas� �rne�i.

using System;
namespace Yeni�zellikler {
    class K�smiTipler {
        static void Main() {
            Console.Write ("S�n�f, aray�z, yap� ve metodlar 'partial'/k�smi anahtarkelimeyle ayr� .cs kaynak programlar� olarak yaz�l�p, sonra birlikte derlenip birtek .exe ko�turulabilir program elde edilebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var m��teri = new M��teri();
            m��teri.Tutar = 25280;
            Console.WriteLine ("Akt�el bakiye: {0}.00 TL", m��teri.Tutar);
            m��teri.yat�r (3875); m��teri.�ek (1562); m��teri.yat�r (5898); m��teri.�ek (4589); m��teri.�ek (1265);

            Console.Write ("\nTu�...");Console.ReadKey();
            //>csc jtpc#230101a.cs jtpc#230101b.cs jtpc#230101.cs
            //>jtpc#230101
        }
    }
}