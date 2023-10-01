// j2sc#0703b.cs: Çoklu arayüz miraslý metotlar ve int/string/class/object eþitlikleri örneði.

using System;
namespace Sýnýflar {
    public interface Müzikçalar {void MüzikÇal();}
    public class Öðrenci : Müzikçalar {
        public void MüzikÇal() {Console.WriteLine ("Öðrenci müzik çalýyor");}
        public void DansEt() {Console.WriteLine ("Öðrenci dans ediyor");}
    }
    class Sýnýf1 {public int ts = 2023;}
    interface Arayüz1 {void Yaz (string dzg);}
    interface Arayüz2 {void Yaz (string dzg);}
    interface Arayüz3 {void Yaz (string dzg);}
    class Sýnýf2 : Arayüz1, Arayüz2, Arayüz3 {public void Yaz (string dzg) {Console.WriteLine (dzg);} }
    class SýnýfNesnesiReferansý2 {
        static void Metot1 (Sýnýf1 nsn, int a) {
            nsn.ts +=10;
            Console.WriteLine ("\ta = {0}", a+=1);
        }
        static void Main() {
            Console.Write ("Arayüz kendi þablon metotlarýný ancak miraslayan tiplenen yavruda detaylandýrýlmýþsa çaðýrabilir; fakat yavrudaki þablonsuz diðer metotlarý çaðýramaz. Ýki basit int deðersel eþitken nesnel (adressel) eþitsizdir; referanssal string, class ve object deðersel eþitlenmiþse adressel de eþitlerdir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Miraslanan arayüzün þablonlu metotlarýný çaðýrabilmesi:");
            Öðrenci öðr1 = new Öðrenci(); öðr1.MüzikÇal(); öðr1.DansEt();
            var öðr2 = new Öðrenci(); öðr2.MüzikÇal(); öðr2.DansEt();
            Müzikçalar mç1 = öðr1; mç1.MüzikÇal(); //mç1.DansEt();
            Müzikçalar mç2 = new Öðrenci(); mç2.MüzikÇal();

            Console.WriteLine ("\nTiplenen sýnýf alaný deðiþirken, ref'siz metot argümaný çaðýraný etkilemez:");
            Sýnýf1 nesne1 = new Sýnýf1();
            int ts = 5;
            Console.WriteLine ("Önce -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);
            Metot1 (nesne1, ts); Console.WriteLine ("Sonra  -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);
            Metot1 (nesne1, ts); Console.WriteLine ("Daha sonra  -- nesne1.ts: {0},\tts: {1}", nesne1.ts, ts);

            Console.WriteLine ("\nÇoklu arayüzleri miraslayan sýnýf metodunun çaðrýlma çeþitleri:");
            Sýnýf2 s2 = new Sýnýf2();
            Arayüz1 ay1 = (Arayüz1) s2;
            Arayüz2 ay2 = (Arayüz2) new Sýnýf2();
            Arayüz3 ay3 = (Arayüz3) s2;
            s2.Yaz ("sýnýf nesnesi yazýyor...");
            ay1.Yaz ("1.arayüz yazýyor...");
            ay2.Yaz ("2.arayüz yazýyor...");
            ay3.Yaz ("3.arayüz yazýyor...");

            Console.WriteLine ("\nint, string, class ve object'lerin deðersel ve referanssal eþitlik testleri:");
            var r=new Random(); 
            int a = r.Next (-10000, 10000);
            int b = a;
            Console.WriteLine ("a({0}) == b({1})? {2}", a, b, a == b);
            Console.WriteLine ("(object)a == (object)b? {0}", (object)a == (object)b);

            string c = "Merhaba";
            string d = "Merhaba";
            Console.WriteLine ("c({0}) == d({1})? {2}", c, d,  c == d );
            Console.WriteLine ("(object)c == (object)d? {0}",  (object) c==(object) d);

            Sýnýf1 x = new Sýnýf1();
            Sýnýf1 y;
            x.ts = r.Next (-10000, 10000);
            y = x;
            Console.WriteLine ("x[.ts({0})] == y[.ts({1})]? {2}", x.ts, y.ts, x == y);

            x.ts = r.Next (-10000, 10000);
            Console.WriteLine ("x.ts = y.ts = {0}", y.ts.ToString());
            Console.WriteLine ("x == y? {0}", x == y);

            y.ts = r.Next (-10000, 10000);
            Console.WriteLine ("x.ts = y.ts = {0}", y.ts.ToString());
            Console.WriteLine ("x == y? {0}", x == y);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}