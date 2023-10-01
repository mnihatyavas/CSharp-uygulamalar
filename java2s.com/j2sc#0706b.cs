// j2sc#0706b.cs: De�er, params, out, ref ve delegeli parametreler �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {public int ts = 20230911;}
    public class Araba {
        public int imalY�l�;
        public double azamiH�z�;
        public int Ya� (int y�l) {
            int azamiH�z� = 500; //�ye alan'la ayn� adl� farkl� (lokal ve etkisiz) de�i�ken
            Console.WriteLine ("Ya�(): azamiH�z� = " + azamiH�z�);
            int ya�� = y�l - imalY�l�;
            return ya��;
        }
        public double Katetti�iYol (double ilkH�z�, double s�re) {
            Console.WriteLine ("Katetti�iYol(): azamiH�z� = " + azamiH�z�);
            return (ilkH�z� + azamiH�z�) / 2 * s�re;
        }
    }
    class MetotParametresi2 {
        static void De�erMetot (int x) {
            Console.WriteLine ("\tDe�erMetot'a girereken. X = {0}", x);
            x +=10;
            Console.WriteLine ("\tDe�erMetot'dan ��karken. X = {0}", x);
        }
        static void RefMetot (ref int x) {
            Console.WriteLine ("\tRefMetot'a girereken. X = {0}", x);
            x +=10;
            Console.WriteLine ("\tRefMetot'dan ��karken. X = {0}", x);
        }
        static void Metot1 (out S�n�f1 nesne, out int? ts) {
            nesne = new S�n�f1(); Console.WriteLine ("Orijinal nesne.ts = {0}", nesne.ts);
            nesne.ts = 11092023;
            ts = 19381110;
        }
        public static void ParamsYaz (params object[] liste) {
            for (int i = 0; i < liste.Length; ++i)
                Console.WriteLine ("object {0} = {1} ({2})", i, liste [i], liste [i].GetType());
        }
        delegate void MesajDelegesi (string mesaj);
        static void UzunS�renMetot (MesajDelegesi yaz) {for (int i = 1; i <= 100; i++) if (i % 25 == 0) yaz (string.Format ("��lenen s�re�: {0}% tamamland�.", i));}
        static void MesajYaz (string mesaj) {Console.WriteLine ("[MesajYaz] \"{0}\" tamamland�.", mesaj);}
        static void Main() {
            Console.Write ("'out arg�man� de�er atamas�z/null olmal� ve de�er atmalar� parametrik metotla (return's�z) geriye/d��ar�ya olmal�d�r. 'ref' ve 'out' anahtarkelimeleri hem arg�manda hem de parametrede kullan�l�rken, 'params' sadece parametrede kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'out'la �natamas�z arg�man de�i�kene metottan d��a de�er aktarma:");
            S�n�f1 ns1 = null; int? ts1=null;
            Console.WriteLine ("�nce  -- ns1.ts: {0},\tts1: {1}", new S�n�f1().ts, (ts1 == null? 0 : ts1) );
            Metot1 (out ns1, out ts1);
            Console.WriteLine ("Sonra  -- ns1.ts: {0},\tts1: {1}", ns1.ts, ts1);

            Console.WriteLine ("\nDe�erMetot arg�man de�i�keni etkilemezken RefMetot etkiler:");
            int ts2 = 2023;
            Console.WriteLine ("De�erMetot'u �a��rmadan �nce, x = {0}", ts2);
            De�erMetot (ts2);
            Console.WriteLine ("De�erMetot'u �a��rd�ktan sonra, x = {0}", ts2);
            RefMetot (ref ts2);
            Console.WriteLine ("RefMetot'u �a��rd�ktan sonra, x = {0}", ts2);

            Console.WriteLine ("\n'params object[]'le her tip ve adet arg�man aktar�labilir:");
            ParamsYaz ("M.Nihat Yava�", (2023-1957), "Toroslar - Mersin", 905515554433, false, 7852.75, 'E'); //False de�il: false

            Console.WriteLine ("\nS�n�f �ye alan ve metot parametrelerine de�er aktar�mlar�:");
            Araba k�z�lPorsche = new Araba();
            k�z�lPorsche.imalY�l� = 2020;
            k�z�lPorsche.azamiH�z� = 200;
            int ya�� = k�z�lPorsche.Ya� (2023);
            Console.WriteLine ("k�z�lPorsche " + ya�� + " ya��ndad�r.");
            Console.WriteLine ("k�z�lPorsche son s�r��te " + k�z�lPorsche.Katetti�iYol (45.25, 2.54) + " km katetti.");

            Console.WriteLine ("\nDelegeli 4 etapl� ve do�rudan tek seferde yazd�rma:");
            string kaynak = "Delegeli Yazd�rma";
            MesajDelegesi yaz = delegate (string mesaj) {Console.WriteLine ("[{0}] {1}", kaynak, mesaj);};
            UzunS�renMetot (yaz);
            kaynak = "Do�rudan Yazd�rma";
            MesajYaz (kaynak);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}