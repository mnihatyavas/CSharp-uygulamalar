// j2sc#1801c.cs: Stack y���na Push, Peek ve Pop'la kay�t koyma/alma �rne�i.

using System;
using System.Collections.Generic;
namespace SoysalListe {
    class S�n�f�m {
        int n;
        public S�n�f�m (int i) {n=i;} //Kurucu
        public override string ToString() {return "Benim "+n+".s�n�f�m";}
    }
    class Y���n�m<T> {
        int AzamiY���n = 1938-1881+1;
        T[] Y���nDizi;
        public int Y���nG�sterge� = 0;
        public Y���n�m() {Y���nDizi = new T [AzamiY���n];} //Kurucu
        public void �steKoy (T x) {if (Y���nG�sterge� < AzamiY���n) Y���nDizi [Y���nG�sterge�++] = x;}
        public T �stten��kar() {return (Y���nG�sterge� > 0)? Y���nDizi [--Y���nG�sterge�] : Y���nDizi [0];}
        public void G�ster() {for(int i = Y���nG�sterge� - 1; i >= 0; i--) Console.Write (Y���nDizi [i] + " "); Console.WriteLine();}
    }
    class Y���n {
        static void Main() {
            Console.Write ("Stack y���na kay�tlar Push'la �st�ste y���l�rken, Peek'le �stteki g�zlenir, Pop'la da �stten alta bo�alt�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal Stack<S�n�f�m> y���na �st�ste kay�t ekleme ve �stten ��karma:");
            Stack<S�n�f�m> y���n = new Stack<S�n�f�m>();
            int i, n;
            Console.WriteLine ("Y���n'daki ilk kay�t say�s�: " + y���n.Count);
            for(i=1;i<=5;i++) {
                y���n.Push (new S�n�f�m (i));
                S�n�f�m snf = y���n.Peek();
                Console.WriteLine ("Push'lanan kayda peek: [{0}]\tArtan kay�t say�s�: {1}", snf, y���n.Count);
            }
            //Liste ve koleksiyonlar gibi y���na endeksle eri�ilemez...
            //Console.Write ("==>Alttan �ste endeksli kay�tlar: "); for(i=0;i<y���n.Count;i++) Console.WriteLine (y���n [i]);
            //Console.Write ("==>�stten alta endeksli kay�tlar: "); for(i=y���n.Count-1;i>=0;i--) Console.WriteLine (y���n [i]);
            for(i=0;i<5;i++) {
                S�n�f�m snf = y���n.Pop();
                Console.WriteLine ("Pop'lanan kay�t: [{0}]\tKalan kay�t say�s�: {1}", snf, y���n.Count);
            }

            Console.WriteLine ("\nPush:�steKoy ve Pop:�stten��kar'la kendi �zel soysal<T> y���n�m�z:");
            Y���n�m<int> Tamsay�Y���n = new Y���n�m<int>();
            Y���n�m<string> DizgeY���n = new Y���n�m<string>();
            Console.WriteLine ("==>Tamsay�Y���n'daki ilk kay�t say�s�: " + Tamsay�Y���n.Y���nG�sterge�);
            for(i=1881;i<=1938;i++) Tamsay�Y���n.�steKoy (i);
            Console.WriteLine ("==>Tamsay�Y���n'daki �steKoy/Push sonras� kay�t say�s�: " + Tamsay�Y���n.Y���nG�sterge�);
            Console.Write ("Y���nDizi'yle y�llar: "); Tamsay�Y���n.G�ster();
            Console.WriteLine ("==>Tamsay�Y���n'daki G�ster/Y���nDizi sonras� kay�t say�s�: " + Tamsay�Y���n.Y���nG�sterge�);
            Console.Write ("�stten��kar()'la y�llar: "); n=Tamsay�Y���n.Y���nG�sterge�; for(i=0;i<n;i++) Console.Write (Tamsay�Y���n.�stten��kar()+" "); Console.WriteLine();
            Console.WriteLine ("==>Tamsay�Y���n'daki �stten��kar/Pop sonras� kay�t say�s�: " + Tamsay�Y���n.Y���nG�sterge�);
            Console.WriteLine ("==>DizgeY���n'daki ilk kay�t say�s�: " + DizgeY���n.Y���nG�sterge�);
            for(i=1919;i<=1938;i++) DizgeY���n.�steKoy ("Atat�rk"+"-"+i);
            Console.WriteLine ("==>DizgeY���n'daki �steKoy/Push sonras� kay�t say�s�: " + DizgeY���n.Y���nG�sterge�);
            Console.Write ("Y���nDizi'yle dizgeler: "); DizgeY���n.G�ster();
            Console.WriteLine ("==>DizgeY���n'daki G�ster/Y���nDizi sonras� kay�t say�s�: " + DizgeY���n.Y���nG�sterge�);
            Console.Write ("�stten��kar()'la dizgeler: "); n=DizgeY���n.Y���nG�sterge�; for(i=0;i<n;i++) Console.Write (DizgeY���n.�stten��kar()+" "); Console.WriteLine();
            Console.WriteLine ("==>DizgeY���n'daki �stten��kar/Pop sonras� kay�t say�s�: " + DizgeY���n.Y���nG�sterge�);

            Console.WriteLine ("\nPush, Peek ve Pop'la y���n kay�t �steleme, g�zetme ve eksiltme:");
            Stack<string> y���n2 = new Stack<string>();
            Console.WriteLine ("==>Dizgesel y���n2'deki ilk kay�t say�s�: " + y���n2.Count);
            Console.Write ("Kay�t Push: ");
            for(i=1957;i<=2024;i++) {
                y���n2.Push ("Nihat-"+i);
                Console.Write (y���n2.Peek()+" ");
            }
            Console.WriteLine ("\n==>Dizgesel y���n2'deki Push sonras� kay�t say�s�: " + y���n2.Count);
            Console.Write ("Kay�t Pop: ");
            while(y���n2.Count > 0) Console.Write (y���n2.Pop() + " ");
            Console.WriteLine ("\n==>Dizgesel y���n2'deki Pop sonras� kay�t say�s�: " + y���n2.Count);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}