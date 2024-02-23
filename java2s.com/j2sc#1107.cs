// j2sc#1107.cs: Queue sona-ekle �nden-��kar ve Stack �ne-ekle �nden-��kar �rne�i.

using System;
using System.Collections;//Queue, Stack i�in
using System.Collections.Generic;//Queue<T>, List<T> i�in
namespace VeriYap�lar� {
    class S�n�f1 {
        public string Ad="";
        public S�n�f1 (string a) {Ad=a;}//Kurucu
    }
    class Y���n {
        char[] y���n;//char y���nlar� dizisi
        int y���nTepesi;//dolan/bo�alan y���n dizi endeksinin takibi
        public Y���n (int ebat) {//Kuucu
            y���n = new char [ebat];//Azami y���n dizin ebat�n� s�n�rlar
            y���nTepesi = 0;
        }
        public void �neEkle (char krk) {
            if (y���nTepesi == y���n.Length) {Console.WriteLine (" -- Y���n doludur."); return;}
            y���n [y���nTepesi] = krk;
            y���nTepesi++;
        }
        public char �nden��kar() {
            if (y���nTepesi == 0) {Console.WriteLine (" -- Y���n bo�tur."); return (char) 0;}
            y���nTepesi--;
            return y���n [y���nTepesi];
        }
        public bool doluMu() {return y���nTepesi == y���n.Length;}
        public bool bo�Mu() {return y���nTepesi == 0;}
        public int Kapasite() {return y���n.Length;}
        public int Say�() {return y���nTepesi;}
    }
    class VeriYap�s�7 {
        static void Yaz (string klkAd�, ICollection klk) {
            Console.Write (klkAd� + ": " );
            foreach (object ��e in klk) Console.Write (��e.ToString() + " ");Console.WriteLine();
        }
        static void Y���nTesti (string[] kelimeler) {
            Stack y���n = new Stack();
            foreach (string kelime in kelimeler ) {
                y���n.Push (kelime);
                Console.WriteLine ("\t�ne itilen de�er: {0}", kelime);
                Yaz ("Yeni Y���n", y���n);
            }
            //Console.Write ("Ka� kez ��kar�lmakta?");
            int ��kar�lanlar = kelimeler.Length;//Int32.Parse (Console.ReadLine());
            for (int i = 1;i <= ��kar�lanlar;i++ ) {
                Console.WriteLine ("\t�nden ��kar�lan de�er: " + y���n.Pop());
                Yaz ("Kalan Y���n-" + i.ToString() + ": ", y���n);
            }
        }
        static void KuyrukTesti (string[] kelimeler) {
            Queue kuyruk = new Queue();
            foreach (string kelime in kelimeler) {
                kuyruk.Enqueue (kelime);
                Console.WriteLine ("\tArkaya kuyruklanan de�er: {0}", kelime);
                Yaz ("Yeni Kuyruk", kuyruk);
            }
            //Console.Write ("Ka� kez kuyruksuzlanmakta?");
            int kuyruksuzlananlar = kelimeler.Length;//Int32.Parse( Console.ReadLine() );
            for (int i = 1;i <= kuyruksuzlananlar;i++ ) {
                Console.WriteLine ("\t�nden kuyruksuzlanan de�er: " + kuyruk.Dequeue());
                Yaz ("Kalan Kuyruk-" + i.ToString() + ": ", kuyruk);
            }
        }
        static void Main() {
            Console.Write ("Enqueue kuyru�un arkas�na ekler, Dequeue ise kuyru�un �n�nden siler. Queue Capacity kullanmaz. Peek daima kuyrukba��ndaki ilk kayd� okur.\nStack/Y���n'a (daima) �ne veri ekleme Push(de�er), ba�tan tek veri silme Pop() iledir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Queue/Kuyruk'a eleman ekleme, silme, temizleme, kopyalama ve sunma:");
            int i, j, ts1;var r=new Random();
            Queue kuyruk1 = new Queue();
            for(i=0;i<10;i++) {ts1=r.Next(-100,1000);kuyruk1.Enqueue (ts1);}
            Console.Write ("Kuyruk1({0}): ", kuyruk1.Count);foreach(int ts in kuyruk1) Console.Write (ts + " ");Console.WriteLine();
            Queue kopya1 = new Queue (kuyruk1.ToArray());
            Console.Write ("Kopya1({0}): ", kopya1.Count);foreach(int ts in kopya1) Console.Write (ts + " ");Console.WriteLine();
            Console.WriteLine ("Dequeue-1: {0},\tDequeue-2: {1}", kuyruk1.Dequeue(), kuyruk1.Dequeue());
            Console.Write ("Kuyruk1({0}): ", kuyruk1.Count);foreach(int ts in kuyruk1) Console.Write (ts + " ");Console.WriteLine();
            kuyruk1.Clear();Console.WriteLine ("kuyruk1.Clear() sonras� say� = {0}", kuyruk1.Count);

            Console.WriteLine ("\nQueue, Queue<S�n�f1> ve List<S�n�f1> ile eklenen ad'lar�n sunumu:");
            string dzg1;
            Queue kuyruk2 = new Queue();
            for(i=0;i<10;i++) {
                dzg1="";for(j=0;j<5;j++) {ts1=r.Next(0,26);dzg1+=(char)(ts1+65);}
                kuyruk2.Enqueue (new S�n�f1 (dzg1));
            }
            Console.Write ("Kuyruk2({0}): ", kuyruk2.Count);foreach(S�n�f1 s1 in kuyruk2) Console.Write (s1.Ad + " ");Console.WriteLine();
            Console.Write ("Peek/Dequeue: ");ts1=kuyruk2.Count;for(i=0;i<ts1;i++) {Console.Write (((S�n�f1)kuyruk2.Peek()).Ad + " ");kuyruk2.Dequeue();}Console.WriteLine();
            Queue<S�n�f1> kuyruk2a = new Queue<S�n�f1>();
            for(i=0;i<10;i++) {
                dzg1="";for(j=0;j<5;j++) {ts1=r.Next(0,26);dzg1+=(char)(ts1+65);}
                kuyruk2a.Enqueue (new S�n�f1 (dzg1));
            }
            Console.Write ("Kuyruk2a({0}): ", kuyruk2a.Count);foreach(S�n�f1 s1 in kuyruk2a) Console.Write (s1.Ad + " ");Console.WriteLine();
            IEnumerator<S�n�f1> ie1 = kuyruk2a.GetEnumerator();
            Console.Write ("IEnumerator: ");while (ie1.MoveNext()) Console.Write ("{0}", ((S�n�f1)ie1.Current).Ad);Console.WriteLine();
            List<S�n�f1> liste2a = new List<S�n�f1>(kuyruk2a);
            Console.Write ("liste2a({0}): ", liste2a.Count);foreach(S�n�f1 s1 in liste2a) Console.Write (s1.Ad + " ");Console.WriteLine();

            Console.WriteLine ("\nStack/Y���n'a kay�t ekleme, silme, temizleme, kopya ve sunumlar:");
            Stack y���n1 = new Stack();
            for(i=0;i<10;i++) {ts1=r.Next(-100,1000);y���n1.Push (ts1);}
            Console.Write ("Y���n1({0}): ", y���n1.Count);foreach(int ts in y���n1) Console.Write (ts + " ");Console.WriteLine();
            IEnumerator ie2 = y���n1.GetEnumerator();
            Console.Write ("IEnumerator: ");while (ie2.MoveNext()) Console.Write ("{0}", ie2.Current);Console.WriteLine();
            int[] kopya2 = new int [y���n1.Count];
            y���n1.CopyTo (kopya2, 0);
            Console.Write ("Kopya2({0}): ", kopya2.Length);foreach(int ts in kopya2) Console.Write (ts + " ");Console.WriteLine();
            Console.WriteLine ("Pop-1: {0},\tPop-2: {1}", y���n1.Pop(), y���n1.Pop());
            Console.Write ("Y���n1({0}): ", y���n1.Count);foreach(int ts in y���n1) Console.Write (ts + " ");Console.WriteLine();
            y���n1.Clear();Console.WriteLine ("y���n1.Clear() sonras� say� = {0}", y���n1.Count);

            Console.WriteLine ("\nY���n'a �ne-Push/�nden-Pop, Kuyruk'a sona-Enqueue/�nden-Dequeue testi:");
            string t�mce = "Mahmut Nihat Yava� Toroslar Mersin TR";
            string[] kelimeler = t�mce.Split (' ');
            Yaz ("T�mce", kelimeler);
            Console.WriteLine ("\t\t-----YI�IN TEST�-----");
            Y���nTesti (kelimeler);
            Console.WriteLine ("\t\t-----KUYRUK TEST�-----");
            KuyrukTesti (kelimeler);

            Console.WriteLine ("\n�zel Y���n'a krk ekleme, ��karma, ebat sorgulama ve sunumlar:");
            Y���n y�n1 = new Y���n (26);
            Y���n y�n2 = new Y���n (26);
            char krk;
            Console.WriteLine ("\tA-->Z harflerini y�n1'e �ndenEkle...");
            for (i=0;!y�n1.doluMu();i++) y�n1.�neEkle ((char) ('A' + i));
            if (y�n1.doluMu()) Console.WriteLine ("y�n1 dolu mu? EVET");
            Console.Write ("y�n1: "); while (!y�n1.bo�Mu()) {krk = y�n1.�nden��kar(); Console.Write (krk);} Console.WriteLine();
            if (y�n1.bo�Mu()) Console.WriteLine ("y�n1 bo� mu? EVET");
            Console.WriteLine ("\tTekrar A-->Z harflerini y�n1'e �ndenEkle...");
            for (i=0;!y�n1.doluMu();i++) y�n1.�neEkle ((char) ('A' + i));
            Console.WriteLine ("\t�imdi y�n1'den �nden��kar'd���n� y�n2'ye �neEkle...");
            while (!y�n1.bo�Mu()) {krk = y�n1.�nden��kar(); y�n2.�neEkle (krk);}
            Console.Write ("y�n2: "); while (!y�n2.bo�Mu()) {krk = y�n2.�nden��kar(); Console.Write (krk);} Console.WriteLine();
            Console.WriteLine ("\ty�n1 ve y�n2'nin kapasite ve sonu� say�'lar�...");
            Console.WriteLine ("y�n1 (Kapasite, Say�) = ({0}, {1}): ", y�n1.Kapasite(), y�n1.Say�());
            Console.WriteLine ("y�n2 (Kapasite, Say�) = ({0}, {1}): ", y�n2.Kapasite(), y�n2.Say�());

            Console.Write ("\nTu�...");Console.ReadKey();
        }
    }
}