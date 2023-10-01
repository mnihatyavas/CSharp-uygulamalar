// j2sc#0706b.cs: Deðer, params, out, ref ve delegeli parametreler örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {public int ts = 20230911;}
    public class Araba {
        public int imalYýlý;
        public double azamiHýzý;
        public int Yaþ (int yýl) {
            int azamiHýzý = 500; //Üye alan'la ayný adlý farklý (lokal ve etkisiz) deðiþken
            Console.WriteLine ("Yaþ(): azamiHýzý = " + azamiHýzý);
            int yaþý = yýl - imalYýlý;
            return yaþý;
        }
        public double KatettiðiYol (double ilkHýzý, double süre) {
            Console.WriteLine ("KatettiðiYol(): azamiHýzý = " + azamiHýzý);
            return (ilkHýzý + azamiHýzý) / 2 * süre;
        }
    }
    class MetotParametresi2 {
        static void DeðerMetot (int x) {
            Console.WriteLine ("\tDeðerMetot'a girereken. X = {0}", x);
            x +=10;
            Console.WriteLine ("\tDeðerMetot'dan çýkarken. X = {0}", x);
        }
        static void RefMetot (ref int x) {
            Console.WriteLine ("\tRefMetot'a girereken. X = {0}", x);
            x +=10;
            Console.WriteLine ("\tRefMetot'dan çýkarken. X = {0}", x);
        }
        static void Metot1 (out Sýnýf1 nesne, out int? ts) {
            nesne = new Sýnýf1(); Console.WriteLine ("Orijinal nesne.ts = {0}", nesne.ts);
            nesne.ts = 11092023;
            ts = 19381110;
        }
        public static void ParamsYaz (params object[] liste) {
            for (int i = 0; i < liste.Length; ++i)
                Console.WriteLine ("object {0} = {1} ({2})", i, liste [i], liste [i].GetType());
        }
        delegate void MesajDelegesi (string mesaj);
        static void UzunSürenMetot (MesajDelegesi yaz) {for (int i = 1; i <= 100; i++) if (i % 25 == 0) yaz (string.Format ("Ýþlenen süreç: {0}% tamamlandý.", i));}
        static void MesajYaz (string mesaj) {Console.WriteLine ("[MesajYaz] \"{0}\" tamamlandý.", mesaj);}
        static void Main() {
            Console.Write ("'out argümaný deðer atamasýz/null olmalý ve deðer atmalarý parametrik metotla (return'süz) geriye/dýþarýya olmalýdýr. 'ref' ve 'out' anahtarkelimeleri hem argümanda hem de parametrede kullanýlýrken, 'params' sadece parametrede kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'out'la önatamasýz argüman deðiþkene metottan dýþa deðer aktarma:");
            Sýnýf1 ns1 = null; int? ts1=null;
            Console.WriteLine ("Önce  -- ns1.ts: {0},\tts1: {1}", new Sýnýf1().ts, (ts1 == null? 0 : ts1) );
            Metot1 (out ns1, out ts1);
            Console.WriteLine ("Sonra  -- ns1.ts: {0},\tts1: {1}", ns1.ts, ts1);

            Console.WriteLine ("\nDeðerMetot argüman deðiþkeni etkilemezken RefMetot etkiler:");
            int ts2 = 2023;
            Console.WriteLine ("DeðerMetot'u çaðýrmadan önce, x = {0}", ts2);
            DeðerMetot (ts2);
            Console.WriteLine ("DeðerMetot'u çaðýrdýktan sonra, x = {0}", ts2);
            RefMetot (ref ts2);
            Console.WriteLine ("RefMetot'u çaðýrdýktan sonra, x = {0}", ts2);

            Console.WriteLine ("\n'params object[]'le her tip ve adet argüman aktarýlabilir:");
            ParamsYaz ("M.Nihat Yavaþ", (2023-1957), "Toroslar - Mersin", 905515554433, false, 7852.75, 'E'); //False deðil: false

            Console.WriteLine ("\nSýnýf üye alan ve metot parametrelerine deðer aktarýmlarý:");
            Araba kýzýlPorsche = new Araba();
            kýzýlPorsche.imalYýlý = 2020;
            kýzýlPorsche.azamiHýzý = 200;
            int yaþý = kýzýlPorsche.Yaþ (2023);
            Console.WriteLine ("kýzýlPorsche " + yaþý + " yaþýndadýr.");
            Console.WriteLine ("kýzýlPorsche son sürüþte " + kýzýlPorsche.KatettiðiYol (45.25, 2.54) + " km katetti.");

            Console.WriteLine ("\nDelegeli 4 etaplý ve doðrudan tek seferde yazdýrma:");
            string kaynak = "Delegeli Yazdýrma";
            MesajDelegesi yaz = delegate (string mesaj) {Console.WriteLine ("[{0}] {1}", kaynak, mesaj);};
            UzunSürenMetot (yaz);
            kaynak = "Doðrudan Yazdýrma";
            MesajYaz (kaynak);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}