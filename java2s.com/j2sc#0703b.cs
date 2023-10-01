// j2sc#0703b.cs: �oklu aray�z mirasl� metotlar ve int/string/class/object e�itlikleri �rne�i.

using System;
namespace S�n�flar {
    public interface M�zik�alar {void M�zik�al();}
    public class ��renci : M�zik�alar {
        public void M�zik�al() {Console.WriteLine ("��renci m�zik �al�yor");}
        public void DansEt() {Console.WriteLine ("��renci dans ediyor");}
    }
    class S�n�f1 {public int ts = 2023;}
    interface Aray�z1 {void Yaz (string dzg);}
    interface Aray�z2 {void Yaz (string dzg);}
    interface Aray�z3 {void Yaz (string dzg);}
    class S�n�f2 : Aray�z1, Aray�z2, Aray�z3 {public void Yaz (string dzg) {Console.WriteLine (dzg);} }
    class S�n�fNesnesiReferans�2 {
        static void Metot1 (S�n�f1 nsn, int a) {
            nsn.ts +=10;
            Console.WriteLine ("\ta = {0}", a+=1);
        }
        static void Main() {
            Console.Write ("Aray�z kendi �ablon metotlar�n� ancak miraslayan tiplenen yavruda detayland�r�lm��sa �a��rabilir; fakat yavrudaki �ablonsuz di�er metotlar� �a��ramaz. �ki basit int de�ersel e�itken nesnel (adressel) e�itsizdir; referanssal string, class ve object de�ersel e�itlenmi�se adressel de e�itlerdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Miraslanan aray�z�n �ablonlu metotlar�n� �a��rabilmesi:");
            ��renci ��r1 = new ��renci(); ��r1.M�zik�al(); ��r1.DansEt();
            var ��r2 = new ��renci(); ��r2.M�zik�al(); ��r2.DansEt();
            M�zik�alar m�1 = ��r1; m�1.M�zik�al(); //m�1.DansEt();
            M�zik�alar m�2 = new ��renci(); m�2.M�zik�al();

            Console.WriteLine ("\nTiplenen s�n�f alan� de�i�irken, ref'siz metot arg�man� �a��ran� etkilemez:");
            S�n�f1 nesne1 = new S�n�f1();
            int ts = 5;
            Console.WriteLine ("�nce -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);
            Metot1 (nesne1, ts); Console.WriteLine ("Sonra  -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);
            Metot1 (nesne1, ts); Console.WriteLine ("Daha sonra  -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);

            Console.WriteLine ("\n�oklu aray�zleri miraslayan s�n�f metodunun �a�r�lma �e�itleri:");
            S�n�f2 s2 = new S�n�f2();
            Aray�z1 ay1 = (Aray�z1) s2;
            Aray�z2 ay2 = (Aray�z2) new S�n�f2();
            Aray�z3 ay3 = (Aray�z3) s2;
            s2.Yaz ("s�n�f nesnesi yaz�yor...");
            ay1.Yaz ("1.aray�z yaz�yor...");
            ay2.Yaz ("2.aray�z yaz�yor...");
            ay3.Yaz ("3.aray�z yaz�yor...");

            Console.WriteLine ("\nint, string, class ve object'lerin de�ersel ve referanssal e�itlik testleri:");
            var r=new Random(); 
            int a = r.Next (-10000, 10000);
            int b = a;
            Console.WriteLine ("a({0}) == b({1})? {2}", a, b, a == b);
            Console.WriteLine ("(object)a == (object)b? {0}", (object)a == (object)b);

            string c = "Merhaba";
            string d = "Merhaba";
            Console.WriteLine ("c({0}) == d({1})? {2}", c, d,  c == d );
            Console.WriteLine ("(object)c == (object)d? {0}",  (object) c==(object) d);

            S�n�f1 x = new S�n�f1();
            S�n�f1 y;
            x.ts = r.Next (-10000, 10000);
            y = x;
            Console.WriteLine ("x[.ts({0})] == y[.ts({1})]? {2}", x.ts, y.ts, x == y);

            x.ts = r.Next (-10000, 10000);
            Console.WriteLine ("x.ts = y.ts = {0}", y.ts.ToString());
            Console.WriteLine ("x == y? {0}", x == y);

            y.ts = r.Next (-10000, 10000);
            Console.WriteLine ("x.ts = y.ts = {0}", y.ts.ToString());
            Console.WriteLine ("x == y? {0}", x == y);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}