// j2sc#0501b.cs: Dizgelerde join, split, indexof, insert, padleft, trim, substring metotlar� �rne�i.

using System;
namespace Dizgeler {
    class String2 {
        static void Main() {
            Console.Write ("Join \".\" dizgesel, Split ise '.' karaktersel ayra� kullan�r. IndexOf dizgesel ibare, IndexOfAny ise karakter-ler gerektirir. PadLeft/Right dizge a�an tamponu soldan/sa�dan bo�lukla/karakterle tamamlar; a�ans�z etkisizdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("String.Join ile dizgeleri ayra�l� birle�tirme:");
            string[] dizi1 = {"Olmak", "yada", "olmamak", "b�t�n", "mesele", "bu"};
            string sonu�1 = String.Join (".", dizi1);
            string sonu�2 = String.Join (":;", dizi1);
            Console.WriteLine ("{0} boyutlu dizi elemanlar�n�n \"{1}\" ayra�la birle�ik dizgesi:\n\t\"{2}\"", dizi1.Length, ".", sonu�1);
            Console.WriteLine ("Ayn� dizi elemanlar�n�n \"{0}\" ayra�la birle�ik dizgesi:\n\t\"{1}\"", ":;", sonu�2);

            Console.WriteLine ("\nString.Split ile ayra�la birle�ik dizgeyi tekrar dizi elemanlar�na ayr��t�rma:");
            string[] dizi2 = sonu�1.Split ('.'); string[] dizi3 = sonu�2.Split (':');
            Console.WriteLine ("Birle�ik \"{0}\" dizgeden dizi elemanlar�na:", sonu�1);
            foreach (string dzg in dizi2) {Console.WriteLine (dzg);}
            Console.WriteLine ("Birle�ik \"{0}\" dizgeden dizi elemanlar�na:", sonu�2);
            foreach (string dzg in dizi3) {Console.WriteLine (dzg);}

            Console.WriteLine ("\nLast/IndexOf ile dizge i�indeki ilk/son ibare endekslerinin tespiti:");
            Console.WriteLine ("Birle�ik \"{0}\" dizgede �LK \"{1}\" endeksi = {2}", sonu�1, "olma", (sonu�1.ToLower()).IndexOf ("olma"));
            Console.WriteLine ("Ayn� dizgede SON \"{0}\" ibaresinin endeksi = {1}", "olma", (sonu�1.ToLower()).LastIndexOf ("olma"));
            Console.WriteLine ("Ayn� dizgede �LK \"{0}\" ibaresinin endeksi = {1}", "nihat", sonu�1.IndexOf ("nihat"));
            char[] krk1 = {'u', 'l', 'm', 'a'};
            Console.WriteLine ("Herhangibir 'u' + 'l' +'m' + 'a' karakterden �LK endeks = {0}: {1}", sonu�1.IndexOfAny (krk1), sonu�1 [sonu�1.IndexOfAny (krk1)]);
            Console.WriteLine ("Herhangibir 'u' + 'l' +'m' + 'a' karakterden SON endeks = {0}: {1}", sonu�1.LastIndexOfAny (krk1), sonu�1 [sonu�1.LastIndexOfAny (krk1)]);

            Console.WriteLine ("\nInsert, Remove, Replace ise dizge i�inde sokma, silme, de�i�tirme:");
            Console.WriteLine ("Birle�ik \"{0}\" dizgede araya \"��TE \" girme:\n\t{1}", sonu�1, sonu�1.Insert (19, "��TE "));
            Console.WriteLine ("Ayn� dizgede aradan \"yada\" silme: {0}", sonu�1.Remove (6, 4));
            Console.WriteLine ("Ayn� dizgede \".\"lar� \":\" ile de�i�tirme: {0}", sonu�1.Replace ('.', ':'));
            Console.WriteLine ("Dizgede \"olma\"lar� \"�LME\" ile de�i�tirme: {0}", (sonu�1.ToLower()).Replace ("olma", "�LME"));

            Console.WriteLine ("\nPadLeft/Right ile tamponu a�an dizge ba��n�/sonunu bo�luk/karakterle tamamlama:");
            Console.WriteLine ("Birle�ik \"{0}\" dizgede a�an tampon ebat�n� sol bo�lukla tamamlama:\n\t({1})", sonu�1, sonu�1.PadLeft (40));
            Console.WriteLine ("Ayn� dizgede a�an tampon ebat�n� sol noktayla tamamlama:\n\t({0})", sonu�1.PadLeft (40, '.'));
            Console.WriteLine ("Ayn� dizgede a�an tampon ebat�n� sa� bo�lukla tamamlama:\n\t({0})", sonu�1.PadRight (40));
            Console.WriteLine ("Ayn� dizgede a�an tampon ebat�n� sa� noktayla tamamlama:\n\t({0})", sonu�1.PadRight (40, '.'));

            Console.WriteLine ("\nTrim, TrimStart, TrimEnd ile dizgenin ba�-son/ba�/son bo�luklar�n�n k�rp�lmas�:");
            string dizge1 = "      M.Nihat Yava�   ";
            Console.WriteLine ("({0}) dizgede Trim() = ({1})", dizge1, dizge1.Trim());
            Console.WriteLine ("Ayn� dizgede TrimStart() = ({0})", dizge1.TrimStart());
            Console.WriteLine ("Ayn� dizgede TrimEnd() = ({0})", dizge1.TrimEnd());
            dizge1 = "...Herkese Merhabalar!..";
            Console.WriteLine ("({0}) dizgede Trim ('.') = ({1})", dizge1, dizge1.Trim ('.'));
            Console.WriteLine ("Ayn� dizgede TrimStart ('.') = ({0})", dizge1.TrimStart ('.'));
            Console.WriteLine ("Ayn� dizgede TrimEnd ('.') = ({0})", dizge1.TrimEnd ('.'));

            Console.WriteLine ("\nSubstring ile dizgenin istenilen par�as�n� alma:");
            Console.WriteLine ("Birle�ik \"{0}\" dizgede Substring (19) =\n\t({1})", sonu�1, sonu�1.Substring (19));
            Console.WriteLine ("Ayn� dizgede Substring (25, 6) = ({0})", sonu�1.Substring (25, 6));
            Console.WriteLine ("Ayn� dizgede Substring (11, 7) = ({0})", sonu�1.Substring (11, 7));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}