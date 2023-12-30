// j2sc#0904a.cs: Delegeli olay yönetimleri eklemeli sýnýf tiplemeleri örneði.

using System;
namespace YetkiAktarma {
    public delegate void OlayYönetimi2 (int i);
    public delegate void OlayYönetimi3();
    delegate void OlayYönetimi4();
    delegate void OlayYönetimi5();
    public delegate void OlayYönetimi6 (int yaþ, object nesne, ref bool deðiþtirme);
    public class Olay1 {
        private int n;
        public Olay1 (int i) {DeðerKoy (i);} //Kurucu
        public delegate void OlayYönetimi1();
        public event OlayYönetimi1 Deðiþti;
        public void Deðiþtiyse() {
            if (Deðiþti != null) {Console.WriteLine ("Deðer deðiþti: "+n);}
            else Console.WriteLine ("Yönetilmeyen olay fýrlatýldý!");
        }
        public void DeðerKoy (int m) {if (n != m) {n = m; Deðiþtiyse();} else Console.WriteLine ("Deðer deðiþmedi...");}
    }
    public class Olay2 {
        public event OlayYönetimi2 Olayým2;
        public double Metot2 (int i) {Olayým2 (i); return(i >= 0? Math.Sqrt (i): -1);}
    }
    class Olay3a {
        public event OlayYönetimi3 Olayým3;
        public void Olayým3se() {if (Olayým3 != null) Olayým3();}
    }
    class Olay3b {
        public void Olay3bYönetimi() {Console.WriteLine ("Olay3bYönetimi fare olayý algýladý");}
    }
    class Olay3c {
        public void Olay3cYönetimi() {Console.WriteLine ("Olay3cYönetimi klavye olayý algýladý");}
    }
    class Olay4a {
        public event OlayYönetimi4 Olayým4;
        public void Olayým4se() {if (Olayým4 != null) Olayým4();}
    }
    class Olay4b {
        int no;
        public Olay4b (int x) {no = x;} //Kurucu
        public void Olay4bYönetimi() {Console.WriteLine ("Olay no: " + no);}
    }
    class Olay5a {
        public event OlayYönetimi5 Olayým5;
        public void Olayým5se() {if (Olayým5 != null) Olayým5();}
    }
    class Olay5b {
        public static void Olay5bYönetimi() {Console.WriteLine ("Olay5b sýnýfýnca algýlanan olay...");}
    }
    class Olay6 {
        public event OlayYönetimi6 YaþýDeðiþtir;
        int yaþ;
        public Olay6() {yaþ = 0;} //Kurucu
        public int Yaþ {
            set {Boolean deðiþtirme = false;
                YaþýDeðiþtir (value, this, ref deðiþtirme);
                if (!deðiþtirme) yaþ = value;
            }
            get {return yaþ;}
        }
    }
    class Delege4a {
        static void Olay3aYönetimi() {Console.WriteLine ("\tnull olmayan Olayým3() ekran olayý algýladý");}
        private static void Olay6Yönetimi (int y, object n, ref bool d) {
            Console.WriteLine ("Olay6Yönetimi [Yeni yaþ: {0} ve Eski yaþ = {1}] için çaðrýldý.", y, ((Olay6)n).Yaþ);
            if (y < 18 || y > 65) d = true;
        }
        static void Main() {
            Console.Write ("Delege olayla adlandýrýlýp sýnýf tiplemeli olay yöneten metota baðlanarak eklenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("OlayYönetimi1 delegeli 'event Deðiþti' Deðiþtiyse() metodunu çaðýrýr:");
            var r=new Random(); int i, ts1;
            Olay1 oy1 = new Olay1 (3); oy1 = new Olay1 (3); oy1 = new Olay1 (5);
            oy1.Deðiþti += new Olay1.OlayYönetimi1 (oy1.Deðiþtiyse);
            for(i=0;i<10;i++) {ts1=r.Next(0,5); oy1.DeðerKoy (ts1);}

            Console.WriteLine ("\nKarekök için -sayýyý yakalayan anonim delegeli olay:");
            Olay2 o2 = new Olay2();
            OlayYönetimi2 oy2 = delegate (int x) {if (x<0) Console.Write ("Negatif sayýnýn karekökü olmaz!\t");};
            o2.Olayým2 += oy2;
            double ds1;
            for(i=0;i<10;i++) {ts1=r.Next(-1000,1000); ds1=o2.Metot2 (ts1); Console.WriteLine ("{0}) Sayý={1}, Karekökü=[{2}]", i+1, ts1, ds1);}

            Console.WriteLine ("\nOlay yönetimine baðlanan 3 olay, sonra 2'ye ve 1'e düþürülür:");
            Olay3a o3a = new Olay3a(); Olay3b o3b = new Olay3b(); Olay3c o3c = new Olay3c();
            o3a.Olayým3 += Olay3aYönetimi; o3a.Olayým3 += o3b.Olay3bYönetimi; o3a.Olayým3 += o3c.Olay3cYönetimi;
            o3a.Olayým3se(); //Her 3 yönetimi de yürütür
            o3a.Olayým3 -= o3c.Olay3cYönetimi;
            o3a.Olayým3se(); //Ýlk 2 yönetim yürütülür
            o3a.Olayým3 -= o3b.Olay3bYönetimi;
            o3a.Olayým3se(); //Ýlk yönetim yürütülür

            Console.WriteLine ("\nOlay4a'ya eklenen Olay4b'nin 3 yönetimi:");
            Olay4a o4a = new Olay4a();
            Olay4b o4b1 = new Olay4b (1); Olay4b o4b2 = new Olay4b (2); Olay4b o4b3 = new Olay4b (3);
            o4a.Olayým4 += o4b1.Olay4bYönetimi; o4a.Olayým4 += o4b2.Olay4bYönetimi; o4a.Olayým4 += o4b3.Olay4bYönetimi;
            o4a.Olayým4se(); //Ýlk o4a yönetimi eklenmediðinden, ekli 3 adet o4b yönetimleri yürütülür

            Console.WriteLine ("\nDelegeli Oly5a'ya baðlý 5 adet Olay5b algýsý:");
            Olay5a o5a = new Olay5a();
            o5a.Olayým5+=Olay5b.Olay5bYönetimi; o5a.Olayým5+=Olay5b.Olay5bYönetimi; o5a.Olayým5+=Olay5b.Olay5bYönetimi; o5a.Olayým5+=Olay5b.Olay5bYönetimi; o5a.Olayým5+=Olay5b.Olay5bYönetimi;
            o5a.Olayým5se();

            Console.WriteLine ("\n[18,65] arasý deðiþen yeni yaþlarý güncelleyen delegeli olay yönetimi:");
            Olay6 o6 = new Olay6();
            o6.YaþýDeðiþtir += new OlayYönetimi6 (Olay6Yönetimi);
            for(i=0;i<10;i++) {
                ts1=r.Next(0,120);
                o6.Yaþ = ts1;
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}