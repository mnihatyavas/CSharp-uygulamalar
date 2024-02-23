// j2sc#1107.cs: Queue sona-ekle önden-çýkar ve Stack öne-ekle önden-çýkar örneði.

using System;
using System.Collections;//Queue, Stack için
using System.Collections.Generic;//Queue<T>, List<T> için
namespace VeriYapýlarý {
    class Sýnýf1 {
        public string Ad="";
        public Sýnýf1 (string a) {Ad=a;}//Kurucu
    }
    class Yýðýn {
        char[] yýðýn;//char yýðýnlarý dizisi
        int yýðýnTepesi;//dolan/boþalan yýðýn dizi endeksinin takibi
        public Yýðýn (int ebat) {//Kuucu
            yýðýn = new char [ebat];//Azami yýðýn dizin ebatýný sýnýrlar
            yýðýnTepesi = 0;
        }
        public void ÖneEkle (char krk) {
            if (yýðýnTepesi == yýðýn.Length) {Console.WriteLine (" -- Yýðýn doludur."); return;}
            yýðýn [yýðýnTepesi] = krk;
            yýðýnTepesi++;
        }
        public char ÖndenÇýkar() {
            if (yýðýnTepesi == 0) {Console.WriteLine (" -- Yýðýn boþtur."); return (char) 0;}
            yýðýnTepesi--;
            return yýðýn [yýðýnTepesi];
        }
        public bool doluMu() {return yýðýnTepesi == yýðýn.Length;}
        public bool boþMu() {return yýðýnTepesi == 0;}
        public int Kapasite() {return yýðýn.Length;}
        public int Sayý() {return yýðýnTepesi;}
    }
    class VeriYapýsý7 {
        static void Yaz (string klkAdý, ICollection klk) {
            Console.Write (klkAdý + ": " );
            foreach (object öðe in klk) Console.Write (öðe.ToString() + " ");Console.WriteLine();
        }
        static void YýðýnTesti (string[] kelimeler) {
            Stack yýðýn = new Stack();
            foreach (string kelime in kelimeler ) {
                yýðýn.Push (kelime);
                Console.WriteLine ("\tÖne itilen deðer: {0}", kelime);
                Yaz ("Yeni Yýðýn", yýðýn);
            }
            //Console.Write ("Kaç kez çýkarýlmakta?");
            int çýkarýlanlar = kelimeler.Length;//Int32.Parse (Console.ReadLine());
            for (int i = 1;i <= çýkarýlanlar;i++ ) {
                Console.WriteLine ("\tÖnden çýkarýlan deðer: " + yýðýn.Pop());
                Yaz ("Kalan Yýðýn-" + i.ToString() + ": ", yýðýn);
            }
        }
        static void KuyrukTesti (string[] kelimeler) {
            Queue kuyruk = new Queue();
            foreach (string kelime in kelimeler) {
                kuyruk.Enqueue (kelime);
                Console.WriteLine ("\tArkaya kuyruklanan deðer: {0}", kelime);
                Yaz ("Yeni Kuyruk", kuyruk);
            }
            //Console.Write ("Kaç kez kuyruksuzlanmakta?");
            int kuyruksuzlananlar = kelimeler.Length;//Int32.Parse( Console.ReadLine() );
            for (int i = 1;i <= kuyruksuzlananlar;i++ ) {
                Console.WriteLine ("\tÖnden kuyruksuzlanan deðer: " + kuyruk.Dequeue());
                Yaz ("Kalan Kuyruk-" + i.ToString() + ": ", kuyruk);
            }
        }
        static void Main() {
            Console.Write ("Enqueue kuyruðun arkasýna ekler, Dequeue ise kuyruðun önünden siler. Queue Capacity kullanmaz. Peek daima kuyrukbaþýndaki ilk kaydý okur.\nStack/Yýðýn'a (daima) öne veri ekleme Push(deðer), baþtan tek veri silme Pop() iledir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Queue/Kuyruk'a eleman ekleme, silme, temizleme, kopyalama ve sunma:");
            int i, j, ts1;var r=new Random();
            Queue kuyruk1 = new Queue();
            for(i=0;i<10;i++) {ts1=r.Next(-100,1000);kuyruk1.Enqueue (ts1);}
            Console.Write ("Kuyruk1({0}): ", kuyruk1.Count);foreach(int ts in kuyruk1) Console.Write (ts + " ");Console.WriteLine();
            Queue kopya1 = new Queue (kuyruk1.ToArray());
            Console.Write ("Kopya1({0}): ", kopya1.Count);foreach(int ts in kopya1) Console.Write (ts + " ");Console.WriteLine();
            Console.WriteLine ("Dequeue-1: {0},\tDequeue-2: {1}", kuyruk1.Dequeue(), kuyruk1.Dequeue());
            Console.Write ("Kuyruk1({0}): ", kuyruk1.Count);foreach(int ts in kuyruk1) Console.Write (ts + " ");Console.WriteLine();
            kuyruk1.Clear();Console.WriteLine ("kuyruk1.Clear() sonrasý sayý = {0}", kuyruk1.Count);

            Console.WriteLine ("\nQueue, Queue<Sýnýf1> ve List<Sýnýf1> ile eklenen ad'larýn sunumu:");
            string dzg1;
            Queue kuyruk2 = new Queue();
            for(i=0;i<10;i++) {
                dzg1="";for(j=0;j<5;j++) {ts1=r.Next(0,26);dzg1+=(char)(ts1+65);}
                kuyruk2.Enqueue (new Sýnýf1 (dzg1));
            }
            Console.Write ("Kuyruk2({0}): ", kuyruk2.Count);foreach(Sýnýf1 s1 in kuyruk2) Console.Write (s1.Ad + " ");Console.WriteLine();
            Console.Write ("Peek/Dequeue: ");ts1=kuyruk2.Count;for(i=0;i<ts1;i++) {Console.Write (((Sýnýf1)kuyruk2.Peek()).Ad + " ");kuyruk2.Dequeue();}Console.WriteLine();
            Queue<Sýnýf1> kuyruk2a = new Queue<Sýnýf1>();
            for(i=0;i<10;i++) {
                dzg1="";for(j=0;j<5;j++) {ts1=r.Next(0,26);dzg1+=(char)(ts1+65);}
                kuyruk2a.Enqueue (new Sýnýf1 (dzg1));
            }
            Console.Write ("Kuyruk2a({0}): ", kuyruk2a.Count);foreach(Sýnýf1 s1 in kuyruk2a) Console.Write (s1.Ad + " ");Console.WriteLine();
            IEnumerator<Sýnýf1> ie1 = kuyruk2a.GetEnumerator();
            Console.Write ("IEnumerator: ");while (ie1.MoveNext()) Console.Write ("{0}", ((Sýnýf1)ie1.Current).Ad);Console.WriteLine();
            List<Sýnýf1> liste2a = new List<Sýnýf1>(kuyruk2a);
            Console.Write ("liste2a({0}): ", liste2a.Count);foreach(Sýnýf1 s1 in liste2a) Console.Write (s1.Ad + " ");Console.WriteLine();

            Console.WriteLine ("\nStack/Yýðýn'a kayýt ekleme, silme, temizleme, kopya ve sunumlar:");
            Stack yýðýn1 = new Stack();
            for(i=0;i<10;i++) {ts1=r.Next(-100,1000);yýðýn1.Push (ts1);}
            Console.Write ("Yýðýn1({0}): ", yýðýn1.Count);foreach(int ts in yýðýn1) Console.Write (ts + " ");Console.WriteLine();
            IEnumerator ie2 = yýðýn1.GetEnumerator();
            Console.Write ("IEnumerator: ");while (ie2.MoveNext()) Console.Write ("{0}", ie2.Current);Console.WriteLine();
            int[] kopya2 = new int [yýðýn1.Count];
            yýðýn1.CopyTo (kopya2, 0);
            Console.Write ("Kopya2({0}): ", kopya2.Length);foreach(int ts in kopya2) Console.Write (ts + " ");Console.WriteLine();
            Console.WriteLine ("Pop-1: {0},\tPop-2: {1}", yýðýn1.Pop(), yýðýn1.Pop());
            Console.Write ("Yýðýn1({0}): ", yýðýn1.Count);foreach(int ts in yýðýn1) Console.Write (ts + " ");Console.WriteLine();
            yýðýn1.Clear();Console.WriteLine ("yýðýn1.Clear() sonrasý sayý = {0}", yýðýn1.Count);

            Console.WriteLine ("\nYýðýn'a öne-Push/önden-Pop, Kuyruk'a sona-Enqueue/önden-Dequeue testi:");
            string tümce = "Mahmut Nihat Yavaþ Toroslar Mersin TR";
            string[] kelimeler = tümce.Split (' ');
            Yaz ("Tümce", kelimeler);
            Console.WriteLine ("\t\t-----YIÐIN TESTÝ-----");
            YýðýnTesti (kelimeler);
            Console.WriteLine ("\t\t-----KUYRUK TESTÝ-----");
            KuyrukTesti (kelimeler);

            Console.WriteLine ("\nÖzel Yýðýn'a krk ekleme, çýkarma, ebat sorgulama ve sunumlar:");
            Yýðýn yðn1 = new Yýðýn (26);
            Yýðýn yðn2 = new Yýðýn (26);
            char krk;
            Console.WriteLine ("\tA-->Z harflerini yðn1'e ÖndenEkle...");
            for (i=0;!yðn1.doluMu();i++) yðn1.ÖneEkle ((char) ('A' + i));
            if (yðn1.doluMu()) Console.WriteLine ("yðn1 dolu mu? EVET");
            Console.Write ("yðn1: "); while (!yðn1.boþMu()) {krk = yðn1.ÖndenÇýkar(); Console.Write (krk);} Console.WriteLine();
            if (yðn1.boþMu()) Console.WriteLine ("yðn1 boþ mu? EVET");
            Console.WriteLine ("\tTekrar A-->Z harflerini yðn1'e ÖndenEkle...");
            for (i=0;!yðn1.doluMu();i++) yðn1.ÖneEkle ((char) ('A' + i));
            Console.WriteLine ("\tÞimdi yðn1'den ÖndenÇýkar'dýðýný yðn2'ye ÖneEkle...");
            while (!yðn1.boþMu()) {krk = yðn1.ÖndenÇýkar(); yðn2.ÖneEkle (krk);}
            Console.Write ("yðn2: "); while (!yðn2.boþMu()) {krk = yðn2.ÖndenÇýkar(); Console.Write (krk);} Console.WriteLine();
            Console.WriteLine ("\tyðn1 ve yðn2'nin kapasite ve sonuç sayý'larý...");
            Console.WriteLine ("yðn1 (Kapasite, Sayý) = ({0}, {1}): ", yðn1.Kapasite(), yðn1.Sayý());
            Console.WriteLine ("yðn2 (Kapasite, Sayý) = ({0}, {1}): ", yðn2.Kapasite(), yðn2.Sayý());

            Console.Write ("\nTuþ...");Console.ReadKey();
        }
    }
}