// j2sc#0507.cs: Equals/==/Compare ile dizgelerin kar��la�t�r�lmalar� �rne�i.

using System;
using System.Text; // new StringBuilder()
namespace Dizgeler {
    class K�yaslama {
        static void Main() {
            Console.Write ("Equals ile == ayn� olup, do�ru/yanl�� sonu�ludur. Bir dizgeye tek ifadeyle ard���k Insert ve ToUpper (yada daha �ok) metodlar uygulanabilir. Compare 0-+ sonucu e�it/k���k/b�y�k g�stergesidir. Compare ASCII k���kharf kodlar� b�y�kse de k���kt�r sayar. Dizgesel e�it olsa da, bir dizgenin referanssal par�al�l��� nesnel e�itli�i bozar. StringBuider dizge de�il nesnedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bool: true/false Equals veya '==' ile e�itlik testi:");
            bool b1 = "merhaba" == "merhaba";
            Console.WriteLine ("\"merhaba\" == \"merhaba\"? {0}", b1);
            bool b2 = "merhaba" == "selam";
            Console.WriteLine ("\"merhaba\" == \"selam\"? {0}", b2);
            Console.WriteLine ("\"merhaba\".Equals (\"merhaba\")? {0}", "merhaba".Equals ("merhaba"));
            Console.WriteLine ("\"merhaba\".Equals (\"selam\")? {0}", "merhaba".Equals ("selam"));
            Console.WriteLine ("\"nas�ls�n\".Equals (\"Nas�ls�n\")? {0}", "nas�ls�n".Equals ("Nas�ls�n"));
            Console.WriteLine ("\"nas�ls�n\".Equals (\"Nas�ls�n\", StringComparison.OrdinalIgnoreCase)? {0}", "nas�ls�n".Equals ("Nas�ls�n", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine ("\n'==' sonucunun if-else ile irdelenmesi:");
            string dizge1 = "Bu bir deneme c�mlesidir.";
            string dizge2 = dizge1.Insert (7, "E��TL��� ").ToUpper();
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"", dizge1, dizge2);
            if (dizge1 == dizge2) Console.WriteLine ("dizge1 dizge2'ye E��TT�R.");
            else Console.WriteLine ("dizge1 dizge2'ye E��T DE��LD�R.");

            Console.WriteLine ("\n'==' ve '!=' sonu�lar�n�n if-else ile irdelenmesi:");
            dizge1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            dizge2 = string.Copy (dizge1);
            string dizge3 = string.Copy (dizge1).ToLower();
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"\ndizge3 = \"{2}\"", dizge1, dizge2, dizge3);
            if (dizge1 == dizge2) Console.WriteLine ("dizge1 == dizge2");
            else Console.WriteLine ("dizge1 != dizge2");
            if (dizge1 != dizge3) Console.WriteLine ("dizge1 != dizge3");
            else Console.WriteLine ("dizge1 == dizge3");

            Console.WriteLine ("\nCompare'in 0-+ sonu�lar�n�n if-else-if ile irdelenmesi:");
            int sonu�;
            Console.WriteLine ("dizge1({0}: {1:X2}).CompareTo (dizge3({2}: {3:X2})): {4}", dizge1 [0], (ushort)dizge1 [0], dizge3 [0], (ushort)dizge3 [0], (sonu� = dizge1.CompareTo (dizge3)) );
            if (sonu� == 0) Console.WriteLine ("dizge1 == dizge3");
            else if (sonu� < 0) Console.WriteLine ("dizge1 < dizge3");
            else Console.WriteLine ("dizge1 > dizge3");

            Console.WriteLine ("\nString.Compare'in yal�n, true, ilk/son-krk �e�itlemeleri:");
            dizge1 = dizge2 = "bir";
            if (String.Compare (dizge1, dizge2) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " E��TT�R.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " e�it DE��LD�R.");
            dizge2 = "B�R";
            if (String.Compare (dizge1, dizge2, true) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " (b�y�k/k���k-harf ayn�l���yla) E��TT�R.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " (b�y�k/k���k-harf ayn�l���yla) e�it DE��LD�R.");
            dizge2 = "birdir bir";
            if (String.Compare (dizge1, 0, dizge2, 0, 3) == 0) Console.WriteLine (dizge1 + "'in ilk par�as� ve " + dizge2 + " E��TT�R.");
            else Console.WriteLine (dizge1 + "'in ilk par�as� ve " + dizge2 + " e�it DE��LD�R.");
            dizge2 = "iki";
            sonu� = String.Compare (dizge1, dizge2);
            if (sonu� < 0) Console.WriteLine (dizge1 + ", " + dizge2 + "'den K���KT�R.");
            else if (sonu� > 0) Console.WriteLine (dizge1 + ", " + dizge2 + "'den B�Y�KT�R."); 
            else Console.WriteLine (dizge1 + ", " + dizge2 + "'ye E��TT�R.");
            dizge2 = "BIR".ToLower();
            if (String.Compare (dizge1, dizge2, StringComparison.InvariantCulture) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " (kb-harf ayn�l��� ve ortak k�lt�rde) E��TT�R.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " (kb-harf ayn�l��� ve ortak k�lt�rde) e�it DE��LD�R.");

            Console.WriteLine ("\nDizgesel e�itli�in nesnesel e�itlik olmamas�:");
            dizge1 = dizge2 = "Merhaba";
            dizge3 = "Merhaba".Substring (0, 6) + "a";
            Console.WriteLine ("dizge1 = {0}\tdizge2 = {1}\tdizge3 = {2}", dizge1, dizge2, dizge3);
            Console.WriteLine ("Str: dizge1 == dizge2: {0}", dizge1 == dizge2);
            Console.WriteLine ("Obj: (object)dizge1 == (object)dizge2: {0}", (object)dizge1 == (object)dizge2);
            Console.WriteLine ("Str: dizge1 == dizge3: {0}", dizge1 == dizge3);
            Console.WriteLine ("Obj: (object)dizge1 == (object)dizge3: {0}", (object)dizge1 == (object)dizge3);

            Console.WriteLine ("\nDizgesel '==/Equals' e�itliklerde de�i�ken ve sabite kullan�lmas�:");
            dizge1 = "Merhaba"; dizge2 = "Selam";
            Console.WriteLine ("dizge1 = {0}\tdizge2 = {1}", dizge1, dizge2);
            Console.WriteLine ("dizge1 == dizge2: {0}", dizge1 == dizge2);
            Console.WriteLine ("dizge1.Equals (dizge2): {0}", dizge1.Equals (dizge2));
            Console.WriteLine ("dizge1 == \"Merhaba\": {0}", dizge1 == "Merhaba");
            Console.WriteLine ("\"Selam\".Equals (dizge2): {0}", "Selam".Equals (dizge2));

            Console.WriteLine ("\nDe�erleri ayn� olsa da dizgeyle nesnenin e�it olmamas�:");
            dizge1 = "nihat";
            dizge2 = new String (new char[]{'n', 'i', 'h', 'a', 't'});
            StringBuilder nesne1 = new StringBuilder ("nihat");
            Console.WriteLine ("String.Equals (Object) = false");
            Console.WriteLine ("\tdizge1({0}).Equals (nesne1({1})) = {2}", dizge1, nesne1, dizge1.Equals (nesne1));
            Console.WriteLine ("String.Equals (Object.ToString()) = true");
            Console.WriteLine ("\tdizge1({0}).Equals (nesne1({1}).ToString()) = {2}", dizge1, nesne1.ToString(), dizge1.Equals (nesne1.ToString()));
            Console.WriteLine ("String.Equals (new String()) = true");
            Console.WriteLine ("\tdizge1({0}).Equals (dizge2({1})) = {2}", dizge1, dizge2, dizge1.Equals (dizge2));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}