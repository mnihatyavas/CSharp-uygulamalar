// j2sc#0601.cs: Yapý, yaratma, deðer ve ref tipli üyeleri, kopyalama örneði.

using System;
namespace Yapýlar {
    struct Bölüm {
        public int pay;
        public int payda;
        public void Yaz() {Console.WriteLine ("{0}/{1}", pay, payda);}
    }
    class Sýnýf2 {public int ts;}
    struct Yapý2 {public int ts;}
    struct Nokta {
        public int X;
        public int Y;
    }
    struct Nokta2 {public int x, y;}
    class Sýnýf3 {
        public string x;
        public Sýnýf3 (string s)  {x = s;} //Sýnýf3 kurucusu
    }
    struct Yapý3 {
        public Sýnýf3 refTip; //Ref tipli
        public int deðerTip; //Deðer tipli
        public Yapý3 (string s) {// Yapý3 kurucusu
            refTip = new Sýnýf3 (s);
            deðerTip = 98;
        }
    }
    class Yapý {
        static void Main() {
            Console.Write ("Yapý, sýnýfa benzer ama deðer tiplidir, referans deðil; bir yapý birdiðerine atandýðýnda kopyasý atanýr. Yapý çoklu arabaðlaç miraslanabilir; sýnýf veya baþka yapý deðil. Yapý üyeleri: alan, metot, özellik, iþlemci metot, endeksleyici ve olay. Yapýlar soyut veya korumalý olamaz. 'new Yapý'da tanýmlý yada varsayýlý kurucu kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kopyalanan yapýlardaki deðiþiklikler birdiðerini etkilemez:");
            Bölüm b1; b1.pay = 5; b1.payda = 10; b1.Yaz(); //5/10
            Bölüm b2 = b1; b1.payda=20; b1.Yaz(); //5/20
            b2.pay = 3; b1.Yaz(); //5/20
            b2.Yaz(); //3/10

            Console.WriteLine ("\nSýnýf referans kopyalarý birbirini etkilerken, sýnýf deðer kopyalarý eykilemez:");
            Sýnýf2 nesneA = new Sýnýf2();
            Sýnýf2 nesneB = nesneA; //Referanssal atama
            nesneA.ts = 10; Console.WriteLine ("Ref: nesneA.ts = {0}\tnesneB.ts = {1}", nesneA.ts, nesneB.ts);
            nesneB.ts = 20; Console.WriteLine ("Ref: nesneA.ts = {0}\tnesneB.ts = {1}", nesneA.ts, nesneB.ts);
            Yapý2 yapýA = new Yapý2();
            Yapý2 yapýB = yapýA; //Deðersel atama
            yapýA.ts = 30; Console.WriteLine ("yapýA.ts = {0}\tyapýB.ts = {1}", yapýA.ts, yapýB.ts);
            yapýB.ts = 40; Console.WriteLine ("yapýA.ts = {0}\tyapýB.ts = {1}", yapýA.ts, yapýB.ts);

            Console.WriteLine ("\nÇift boyutlu noktalarý toplama, çýkarma ve gösterme:");
            Nokta n1, n2, n3, n4;
            n1.X = n1.Y = 10;
            n2.X = n2.Y = 20;
            n3.X = n1.X + n2.X;
            n3.Y = n1.Y + n2.Y;
            n4.X = n3.X - n2.X;
            n4.Y = n3.Y + n1.Y;
            Console.WriteLine ("n1:  ({0}, {1})", n1.X, n1.Y);
            Console.WriteLine ("n2: ({0}, {1})", n2.X, n2.Y);
            Console.WriteLine ("n3:  ({0}, {1})", n3.X, n3.Y);
            Console.WriteLine ("n4:  ({0}, {1})", n4.X, n4.Y);

            Console.WriteLine ("\nDeðersel yapý kopyalarý deðiþiklikleri birdiðerini etkilemez:");
            Nokta2 N1 = new Nokta2(); //Varsayýlý parametresiz "new" kuruculu
            N1.x = 100; N1.y = 200;
            Nokta2 N2 = N1;
            Console.WriteLine ("N1:  ({0}, {1})", N1.x, N1.y);
            Console.WriteLine ("N2:  ({0}, {1})", N2.x, N2.y);
            Console.WriteLine ("-> N2.x ve N2.y deðiþiyor");
            N2.x *=5; N2.y *=5;
            Console.WriteLine ("N1:  ({0}, {1})", N1.x, N1.y);
            Console.WriteLine ("N2:  ({0}, {1})", N2.x, N2.y);

            Console.WriteLine ("\nYapýnýn ref üyesi kopya deðiþikliðinden etkilenir:");
            Yapý3 yapý3A = new Yapý3 ("Ýlk deðer");
            yapý3A.deðerTip = 88;
            Yapý3 yapý3B;
            yapý3B = yapý3A;
            Console.WriteLine ("yapý3A.deðerTip = {0}\tyapý3A.refTip.x = {1}", yapý3A.deðerTip, yapý3A.refTip.x);
            Console.WriteLine ("yapý3B.deðerTip = {0}\tyapý3B.refTip.x = {1}", yapý3B.deðerTip, yapý3B.refTip.x);
            yapý3B.refTip.x = "Ben 'new' ile yaratýlaným!";
            yapý3B.deðerTip = 77;
            Console.WriteLine ("Yapý3B.deðerTip/.refTip.x deðiþiklikleri sonrasý:");
            Console.WriteLine ("yapý3A.deðerTip = {0}\tyapý3A.refTip.x = {1}", yapý3A.deðerTip, yapý3A.refTip.x);
            Console.WriteLine ("yapý3B.deðerTip = {0}\tyapý3B.refTip.x = {1}", yapý3B.deðerTip, yapý3B.refTip.x);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}