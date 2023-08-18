// j2sc#0601.cs: Yap�, yaratma, de�er ve ref tipli �yeleri, kopyalama �rne�i.

using System;
namespace Yap�lar {
    struct B�l�m {
        public int pay;
        public int payda;
        public void Yaz() {Console.WriteLine ("{0}/{1}", pay, payda);}
    }
    class S�n�f2 {public int ts;}
    struct Yap�2 {public int ts;}
    struct Nokta {
        public int X;
        public int Y;
    }
    struct Nokta2 {public int x, y;}
    class S�n�f3 {
        public string x;
        public S�n�f3 (string s)  {x = s;} //S�n�f3 kurucusu
    }
    struct Yap�3 {
        public S�n�f3 refTip; //Ref tipli
        public int de�erTip; //De�er tipli
        public Yap�3 (string s) {// Yap�3 kurucusu
            refTip = new S�n�f3 (s);
            de�erTip = 98;
        }
    }
    class Yap� {
        static void Main() {
            Console.Write ("Yap�, s�n�fa benzer ama de�er tiplidir, referans de�il; bir yap� birdi�erine atand���nda kopyas� atan�r. Yap� �oklu araba�la� miraslanabilir; s�n�f veya ba�ka yap� de�il. Yap� �yeleri: alan, metot, �zellik, i�lemci metot, endeksleyici ve olay. Yap�lar soyut veya korumal� olamaz. 'new Yap�'da tan�ml� yada varsay�l� kurucu kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kopyalanan yap�lardaki de�i�iklikler birdi�erini etkilemez:");
            B�l�m b1; b1.pay = 5; b1.payda = 10; b1.Yaz(); //5/10
            B�l�m b2 = b1; b1.payda=20; b1.Yaz(); //5/20
            b2.pay = 3; b1.Yaz(); //5/20
            b2.Yaz(); //3/10

            Console.WriteLine ("\nS�n�f referans kopyalar� birbirini etkilerken, s�n�f de�er kopyalar� eykilemez:");
            S�n�f2 nesneA = new S�n�f2();
            S�n�f2 nesneB = nesneA; //Referanssal atama
            nesneA.ts = 10; Console.WriteLine ("Ref: nesneA.ts = {0}\tnesneB.ts = {1}", nesneA.ts, nesneB.ts);
            nesneB.ts = 20; Console.WriteLine ("Ref: nesneA.ts = {0}\tnesneB.ts = {1}", nesneA.ts, nesneB.ts);
            Yap�2 yap�A = new Yap�2();
            Yap�2 yap�B = yap�A; //De�ersel atama
            yap�A.ts = 30; Console.WriteLine ("yap�A.ts = {0}\tyap�B.ts = {1}", yap�A.ts, yap�B.ts);
            yap�B.ts = 40; Console.WriteLine ("yap�A.ts = {0}\tyap�B.ts = {1}", yap�A.ts, yap�B.ts);

            Console.WriteLine ("\n�ift boyutlu noktalar� toplama, ��karma ve g�sterme:");
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

            Console.WriteLine ("\nDe�ersel yap� kopyalar� de�i�iklikleri birdi�erini etkilemez:");
            Nokta2 N1 = new Nokta2(); //Varsay�l� parametresiz "new" kuruculu
            N1.x = 100; N1.y = 200;
            Nokta2 N2 = N1;
            Console.WriteLine ("N1:  ({0}, {1})", N1.x, N1.y);
            Console.WriteLine ("N2:  ({0}, {1})", N2.x, N2.y);
            Console.WriteLine ("-> N2.x ve N2.y de�i�iyor");
            N2.x *=5; N2.y *=5;
            Console.WriteLine ("N1:  ({0}, {1})", N1.x, N1.y);
            Console.WriteLine ("N2:  ({0}, {1})", N2.x, N2.y);

            Console.WriteLine ("\nYap�n�n ref �yesi kopya de�i�ikli�inden etkilenir:");
            Yap�3 yap�3A = new Yap�3 ("�lk de�er");
            yap�3A.de�erTip = 88;
            Yap�3 yap�3B;
            yap�3B = yap�3A;
            Console.WriteLine ("yap�3A.de�erTip = {0}\tyap�3A.refTip.x = {1}", yap�3A.de�erTip, yap�3A.refTip.x);
            Console.WriteLine ("yap�3B.de�erTip = {0}\tyap�3B.refTip.x = {1}", yap�3B.de�erTip, yap�3B.refTip.x);
            yap�3B.refTip.x = "Ben 'new' ile yarat�lan�m!";
            yap�3B.de�erTip = 77;
            Console.WriteLine ("Yap�3B.de�erTip/.refTip.x de�i�iklikleri sonras�:");
            Console.WriteLine ("yap�3A.de�erTip = {0}\tyap�3A.refTip.x = {1}", yap�3A.de�erTip, yap�3A.refTip.x);
            Console.WriteLine ("yap�3B.de�erTip = {0}\tyap�3B.refTip.x = {1}", yap�3B.de�erTip, yap�3B.refTip.x);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}