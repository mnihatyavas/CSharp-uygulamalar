// j2sc#0403.cs: For d�ng�s�nde (ilk; �art; tara) �e�itlemeleri �rne�i.

using System;
namespace �fadeler {
    class For {
        static void Main() {
            Console.Write ("'for(ilkleme;�art;tarama){ifade-ler}' tekrarl� d�ng�s� sonunda {} yoksa sadece m�teakip tek ifade i�letilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("100 tekrarl�, tek i�letilebilir {} bloksuz ifadeli standart for:");
            int i, j;
            for (i = 0; i < 100; i++) Console.Write (i + " ");
            Console.WriteLine ("TAMAMLANDI!");

            Console.WriteLine ("\n10 tekrarl�, �ift i�letilebilir {} blok ifadeli for:");
            int �arp�m=1, toplam=0; 
            for (i=1; i <= 10; i++) {
                toplam +=i;
                �arp�m *=i;
            }
            Console.WriteLine ("1+2+..+10 toplam� = " + toplam);
            Console.WriteLine ("1*2*..*10 �arp�m� = " + �arp�m);

            Console.WriteLine ("\n5'er atlamal� 41 tekrarl�, {} bloksuz tek ifadeli for:");
            for(i = 100; i >= -100; i -= 5) Console.Write (i + " ");

            Console.WriteLine ("\n\n[2, 20] aras� asal ve enb�y�kb�len(ebb)'li say�lar i�i�e �ift for-listesi:");
            int ebb;
            bool asalM�;
            for (i = 2; i <= 20; i++) {
                asalM� = true;
                ebb = 0;
                for (j=2; j <= i/2; j++) if ((i % j) == 0) {asalM� = false; ebb = j;}
                if (asalM�) Console.WriteLine ("==> " + i + " bir b�l�nmez asal say�d�r."); 
                else Console.WriteLine ("Asal olmayan " + i + "'nin enb�y�kb�leni: " + ebb + "'dir.");
            }

            Console.WriteLine ("\nTek for d�ng�s�nde �ift artan/azalan i/j kullan�lmas�:");
            for (i=0, j=10; i <= j; i++, j--) Console.WriteLine ("(i, j) = (" + i + ", " + j + ")");

            var r=new Random(); int ts1=r.Next (50, 1000), ekb;
            Console.Write ("\n\nTek for d�ng�s�nde �ift artan/azalan i/j ile rasgele {0}'nin enk���k ve enb�y�k b�lenleri: ", ts1);
            ekb=ebb=1;
            for (i=2, j=ts1/2; (i <= ts1/2) & (j >= 2); i++, j--) {
                if ((ekb == 1) & ((ts1 % i) == 0)) ekb = i;
                if ((ebb == 1) & ((ts1 % j) == 0)) ebb = j;
            }
            Console.WriteLine ("(EKB, EBB) = ({0}, {1})", ekb, ebb);

            Console.WriteLine ("\nFor d�ng�s�n� sonland�rma kontrolu:");
            bool sonlans�nM�=false;
            for (i=0, j=100; !sonlans�nM�; i++, j--) {
                if (i*i >= j) sonlans�nM� = true;
                Console.WriteLine ("(i, j) = (" + i + ", " + j + "): sonlans�nM�? " + sonlans�nM�);
            }

            Console.WriteLine ("\nFor d�ng�s�n�n tarama i� kontrolu:");
            for (i = 0; i <= 5;) {Console.WriteLine ("Ge�i� #" + i); i+=2; --i;}

            Console.WriteLine ("\nFor d�ng�s�n�n ilkleme d�� ve tarama i� kontrolu:");
            i=0; for (;i <= 5;) {Console.WriteLine ("Ge�i� #" + i); i+=3; i-=2;}

            Console.WriteLine ("\nFor d�ng�s�n�n �ift ilkleme ve tarama kontrolu:");
            for (i = j = 0; i <= 5; i++, j += 10) Console.WriteLine ("(i, j) = ({0}, {1})", i, j);

            Console.WriteLine ("\n�fadesiz for d�ng�s�n�n toplama ve �arpma tarama say�s�n� [0, 19] girin:");
            ts1=0; long ls1=1; int ts2;
            try {ts2 = Math.Abs (int.Parse (Console.ReadLine()));}catch {ts2=10;}
            if (ts2 > 19) ts2=19;
            for (i=0; i<=ts2; ts1+=i++, ls1*=i);
            Console.WriteLine ("[1, {0}] ard���k say�lar�n toplam ve �arp�m�: {1}, ve {2:#,#}", ts2, ts1, ls1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}