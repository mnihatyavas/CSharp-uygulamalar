// j2sc#0507.cs: Equals/==/Compare ile dizgelerin karþýlaþtýrýlmalarý örneði.

using System;
using System.Text; // new StringBuilder()
namespace Dizgeler {
    class Kýyaslama {
        static void Main() {
            Console.Write ("Equals ile == ayný olup, doðru/yanlýþ sonuçludur. Bir dizgeye tek ifadeyle ardýþýk Insert ve ToUpper (yada daha çok) metodlar uygulanabilir. Compare 0-+ sonucu eþit/küçük/büyük göstergesidir. Compare ASCII küçükharf kodlarý büyükse de küçüktür sayar. Dizgesel eþit olsa da, bir dizgenin referanssal parçalýlýðý nesnel eþitliði bozar. StringBuider dizge deðil nesnedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bool: true/false Equals veya '==' ile eþitlik testi:");
            bool b1 = "merhaba" == "merhaba";
            Console.WriteLine ("\"merhaba\" == \"merhaba\"? {0}", b1);
            bool b2 = "merhaba" == "selam";
            Console.WriteLine ("\"merhaba\" == \"selam\"? {0}", b2);
            Console.WriteLine ("\"merhaba\".Equals (\"merhaba\")? {0}", "merhaba".Equals ("merhaba"));
            Console.WriteLine ("\"merhaba\".Equals (\"selam\")? {0}", "merhaba".Equals ("selam"));
            Console.WriteLine ("\"nasýlsýn\".Equals (\"Nasýlsýn\")? {0}", "nasýlsýn".Equals ("Nasýlsýn"));
            Console.WriteLine ("\"nasýlsýn\".Equals (\"Nasýlsýn\", StringComparison.OrdinalIgnoreCase)? {0}", "nasýlsýn".Equals ("Nasýlsýn", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine ("\n'==' sonucunun if-else ile irdelenmesi:");
            string dizge1 = "Bu bir deneme cümlesidir.";
            string dizge2 = dizge1.Insert (7, "EÞÝTLÝÐÝ ").ToUpper();
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"", dizge1, dizge2);
            if (dizge1 == dizge2) Console.WriteLine ("dizge1 dizge2'ye EÞÝTTÝR.");
            else Console.WriteLine ("dizge1 dizge2'ye EÞÝT DEÐÝLDÝR.");

            Console.WriteLine ("\n'==' ve '!=' sonuçlarýnýn if-else ile irdelenmesi:");
            dizge1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            dizge2 = string.Copy (dizge1);
            string dizge3 = string.Copy (dizge1).ToLower();
            Console.WriteLine ("dizge1 = \"{0}\"\ndizge2 = \"{1}\"\ndizge3 = \"{2}\"", dizge1, dizge2, dizge3);
            if (dizge1 == dizge2) Console.WriteLine ("dizge1 == dizge2");
            else Console.WriteLine ("dizge1 != dizge2");
            if (dizge1 != dizge3) Console.WriteLine ("dizge1 != dizge3");
            else Console.WriteLine ("dizge1 == dizge3");

            Console.WriteLine ("\nCompare'in 0-+ sonuçlarýnýn if-else-if ile irdelenmesi:");
            int sonuç;
            Console.WriteLine ("dizge1({0}: {1:X2}).CompareTo (dizge3({2}: {3:X2})): {4}", dizge1 [0], (ushort)dizge1 [0], dizge3 [0], (ushort)dizge3 [0], (sonuç = dizge1.CompareTo (dizge3)) );
            if (sonuç == 0) Console.WriteLine ("dizge1 == dizge3");
            else if (sonuç < 0) Console.WriteLine ("dizge1 < dizge3");
            else Console.WriteLine ("dizge1 > dizge3");

            Console.WriteLine ("\nString.Compare'in yalýn, true, ilk/son-krk çeþitlemeleri:");
            dizge1 = dizge2 = "bir";
            if (String.Compare (dizge1, dizge2) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " EÞÝTTÝR.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " eþit DEÐÝLDÝR.");
            dizge2 = "BÝR";
            if (String.Compare (dizge1, dizge2, true) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " (büyük/küçük-harf aynýlýðýyla) EÞÝTTÝR.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " (büyük/küçük-harf aynýlýðýyla) eþit DEÐÝLDÝR.");
            dizge2 = "birdir bir";
            if (String.Compare (dizge1, 0, dizge2, 0, 3) == 0) Console.WriteLine (dizge1 + "'in ilk parçasý ve " + dizge2 + " EÞÝTTÝR.");
            else Console.WriteLine (dizge1 + "'in ilk parçasý ve " + dizge2 + " eþit DEÐÝLDÝR.");
            dizge2 = "iki";
            sonuç = String.Compare (dizge1, dizge2);
            if (sonuç < 0) Console.WriteLine (dizge1 + ", " + dizge2 + "'den KÜÇÜKTÜR.");
            else if (sonuç > 0) Console.WriteLine (dizge1 + ", " + dizge2 + "'den BÜYÜKTÜR."); 
            else Console.WriteLine (dizge1 + ", " + dizge2 + "'ye EÞÝTTÝR.");
            dizge2 = "BIR".ToLower();
            if (String.Compare (dizge1, dizge2, StringComparison.InvariantCulture) == 0) Console.WriteLine (dizge1 + " ve " + dizge2 + " (kb-harf aynýlýðý ve ortak kültürde) EÞÝTTÝR.");
            else Console.WriteLine (dizge1 + " ve " + dizge2 + " (kb-harf aynýlýðý ve ortak kültürde) eþit DEÐÝLDÝR.");

            Console.WriteLine ("\nDizgesel eþitliðin nesnesel eþitlik olmamasý:");
            dizge1 = dizge2 = "Merhaba";
            dizge3 = "Merhaba".Substring (0, 6) + "a";
            Console.WriteLine ("dizge1 = {0}\tdizge2 = {1}\tdizge3 = {2}", dizge1, dizge2, dizge3);
            Console.WriteLine ("Str: dizge1 == dizge2: {0}", dizge1 == dizge2);
            Console.WriteLine ("Obj: (object)dizge1 == (object)dizge2: {0}", (object)dizge1 == (object)dizge2);
            Console.WriteLine ("Str: dizge1 == dizge3: {0}", dizge1 == dizge3);
            Console.WriteLine ("Obj: (object)dizge1 == (object)dizge3: {0}", (object)dizge1 == (object)dizge3);

            Console.WriteLine ("\nDizgesel '==/Equals' eþitliklerde deðiþken ve sabite kullanýlmasý:");
            dizge1 = "Merhaba"; dizge2 = "Selam";
            Console.WriteLine ("dizge1 = {0}\tdizge2 = {1}", dizge1, dizge2);
            Console.WriteLine ("dizge1 == dizge2: {0}", dizge1 == dizge2);
            Console.WriteLine ("dizge1.Equals (dizge2): {0}", dizge1.Equals (dizge2));
            Console.WriteLine ("dizge1 == \"Merhaba\": {0}", dizge1 == "Merhaba");
            Console.WriteLine ("\"Selam\".Equals (dizge2): {0}", "Selam".Equals (dizge2));

            Console.WriteLine ("\nDeðerleri ayný olsa da dizgeyle nesnenin eþit olmamasý:");
            dizge1 = "nihat";
            dizge2 = new String (new char[]{'n', 'i', 'h', 'a', 't'});
            StringBuilder nesne1 = new StringBuilder ("nihat");
            Console.WriteLine ("String.Equals (Object) = false");
            Console.WriteLine ("\tdizge1({0}).Equals (nesne1({1})) = {2}", dizge1, nesne1, dizge1.Equals (nesne1));
            Console.WriteLine ("String.Equals (Object.ToString()) = true");
            Console.WriteLine ("\tdizge1({0}).Equals (nesne1({1}).ToString()) = {2}", dizge1, nesne1.ToString(), dizge1.Equals (nesne1.ToString()));
            Console.WriteLine ("String.Equals (new String()) = true");
            Console.WriteLine ("\tdizge1({0}).Equals (dizge2({1})) = {2}", dizge1, dizge2, dizge1.Equals (dizge2));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}