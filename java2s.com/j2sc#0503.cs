// j2sc#0503.cs: Karakter dizisiyle dizge aras�nda �evrimler ve eri�imler �rne�i.

using System;
namespace Dizgeler {
    class DizgeKarakterleri {
        static void Main() {
            Console.Write ("ToCharArray() metodu dizgeden karakterler dizisini elde eder. Dizge/dizi uzunlu�una Length ile, herhangibir dizi/dizge eleman�na eri�im kDizi[i]/dizge[i] ile sa�lan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string dizge1 = "Merhaba, D�nya!";
            int i;
            Console.WriteLine ("ToCharArray metoduyla dizgeden \"{0}\" krk dizisi olu�turma:", dizge1);
            char[] kDizi1 = dizge1.ToCharArray();
            char[] kDizi2 = dizge1.ToCharArray (0, 7);
            char[] kDizi3 = dizge1.ToCharArray (9, 6);
            foreach (char k in kDizi1) Console.Write (k + " "); Console.WriteLine();
            foreach (char k in kDizi2) Console.Write (k + " "); Console.WriteLine();
            foreach (char k in kDizi3) Console.Write (k + " "); Console.WriteLine();

            Console.WriteLine ("\ndizge1[i] for-d�ng�s�yle dizge karakterlerini tarama:");
            dizge1 = "abc�defg��ijklmno�prs�tu�vyz0123456789";
            Console.WriteLine ("dizge1 = {0}", dizge1);
            for (i=0; i < dizge1.Length; i++) {Console.Write ("{0}={1} ", (short)dizge1 [i], dizge1 [i]);} Console.WriteLine();

            Console.WriteLine ("\nKarakter dizisinden dizgeye d�z/ters �evrim:");
            char[] kDizi4 = {'M', 'e', 'r', 'h', 'a', 'b', 'a', ',', ' ', 'D', '�', 'n', 'y', 'a', '!'};
            dizge1 =  new string (kDizi4);
            Console.WriteLine ("dizge1 = {0}", dizge1);
            dizge1 = "";
            for (i=1; i <= kDizi4.Length; i++) dizge1 +=kDizi4 [kDizi4.Length - i];
            Console.WriteLine ("dizge1 = {0}", dizge1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}