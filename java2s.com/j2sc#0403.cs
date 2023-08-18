// j2sc#0403.cs: For döngüsünde (ilk; þart; tara) çeþitlemeleri örneði.

using System;
namespace Ýfadeler {
    class For {
        static void Main() {
            Console.Write ("'for(ilkleme;þart;tarama){ifade-ler}' tekrarlý döngüsü sonunda {} yoksa sadece müteakip tek ifade iþletilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("100 tekrarlý, tek iþletilebilir {} bloksuz ifadeli standart for:");
            int i, j;
            for (i = 0; i < 100; i++) Console.Write (i + " ");
            Console.WriteLine ("TAMAMLANDI!");

            Console.WriteLine ("\n10 tekrarlý, çift iþletilebilir {} blok ifadeli for:");
            int çarpým=1, toplam=0; 
            for (i=1; i <= 10; i++) {
                toplam +=i;
                çarpým *=i;
            }
            Console.WriteLine ("1+2+..+10 toplamý = " + toplam);
            Console.WriteLine ("1*2*..*10 çarpýmý = " + çarpým);

            Console.WriteLine ("\n5'er atlamalý 41 tekrarlý, {} bloksuz tek ifadeli for:");
            for(i = 100; i >= -100; i -= 5) Console.Write (i + " ");

            Console.WriteLine ("\n\n[2, 20] arasý asal ve enbüyükbölen(ebb)'li sayýlar içiçe çift for-listesi:");
            int ebb;
            bool asalMý;
            for (i = 2; i <= 20; i++) {
                asalMý = true;
                ebb = 0;
                for (j=2; j <= i/2; j++) if ((i % j) == 0) {asalMý = false; ebb = j;}
                if (asalMý) Console.WriteLine ("==> " + i + " bir bölünmez asal sayýdýr."); 
                else Console.WriteLine ("Asal olmayan " + i + "'nin enbüyükböleni: " + ebb + "'dir.");
            }

            Console.WriteLine ("\nTek for döngüsünde çift artan/azalan i/j kullanýlmasý:");
            for (i=0, j=10; i <= j; i++, j--) Console.WriteLine ("(i, j) = (" + i + ", " + j + ")");

            var r=new Random(); int ts1=r.Next (50, 1000), ekb;
            Console.Write ("\n\nTek for döngüsünde çift artan/azalan i/j ile rasgele {0}'nin enküçük ve enbüyük bölenleri: ", ts1);
            ekb=ebb=1;
            for (i=2, j=ts1/2; (i <= ts1/2) & (j >= 2); i++, j--) {
                if ((ekb == 1) & ((ts1 % i) == 0)) ekb = i;
                if ((ebb == 1) & ((ts1 % j) == 0)) ebb = j;
            }
            Console.WriteLine ("(EKB, EBB) = ({0}, {1})", ekb, ebb);

            Console.WriteLine ("\nFor döngüsünü sonlandýrma kontrolu:");
            bool sonlansýnMý=false;
            for (i=0, j=100; !sonlansýnMý; i++, j--) {
                if (i*i >= j) sonlansýnMý = true;
                Console.WriteLine ("(i, j) = (" + i + ", " + j + "): sonlansýnMý? " + sonlansýnMý);
            }

            Console.WriteLine ("\nFor döngüsünün tarama iç kontrolu:");
            for (i = 0; i <= 5;) {Console.WriteLine ("Geçiþ #" + i); i+=2; --i;}

            Console.WriteLine ("\nFor döngüsünün ilkleme dýþ ve tarama iç kontrolu:");
            i=0; for (;i <= 5;) {Console.WriteLine ("Geçiþ #" + i); i+=3; i-=2;}

            Console.WriteLine ("\nFor döngüsünün çift ilkleme ve tarama kontrolu:");
            for (i = j = 0; i <= 5; i++, j += 10) Console.WriteLine ("(i, j) = ({0}, {1})", i, j);

            Console.WriteLine ("\nÝfadesiz for döngüsünün toplama ve çarpma tarama sayýsýný [0, 19] girin:");
            ts1=0; long ls1=1; int ts2;
            try {ts2 = Math.Abs (int.Parse (Console.ReadLine()));}catch {ts2=10;}
            if (ts2 > 19) ts2=19;
            for (i=0; i<=ts2; ts1+=i++, ls1*=i);
            Console.WriteLine ("[1, {0}] ardýþýk sayýlarýn toplam ve çarpýmý: {1}, ve {2:#,#}", ts2, ts1, ls1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}