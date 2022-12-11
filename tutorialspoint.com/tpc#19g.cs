// tpc#19g.cs: S�n�f�n yegane statik de�i�ken ve statik fonksiyon �yesi �rne�i.

using System;
namespace S�n�flar {
    class Statik�ye {
        public static int say�;

        public void say() {say�++;}
        public static int say�Al() {return say�;}
    }
    class YeganeStatik�ye2 {
        static void Main (string[] args) {
            Console.Write ("S�n�f�n statik de�i�ken ve statik fonksiyon �yelerine tiplenen nesne kullan�lmaks�z�n do�rudan s�n�f adl� nokta i�lemciyle eri�ilir.\nTu�..."); Console.ReadKey();

            Statik�ye.say� = 0;
            Statik�ye s1 = new Statik�ye(); Statik�ye s2 = new Statik�ye(); Statik�ye s3 = new Statik�ye();
            s1.say(); s2.say(); s2.say(); s3.say(); s3.say(); s3.say();
            //Console.WriteLine ("\n\n3 s�n�f nesnesinin statik de�i�ken de�erleri: [{0}, {1}, {2}].", s1.say�Al(), s2.say�Al(), s3.say�Al());// Hata, statik fonksiyona tiplemesiz do�rudan eri�ilmelidir
            Console.WriteLine ("\n\nStatik de�i�kene do�rudan s�n�f ad�yla eri�im: [{0}].", Statik�ye.say�Al());

            Statik�ye.say� = 10;
            Statik�ye s = new Statik�ye();
            s.say(); s.say(); s.say(); s.say(); s.say(); s.say();
            Console.WriteLine ("Statik de�i�kene do�rudan s�n�f ad�yla eri�im: [{0}].", Statik�ye.say�Al());
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}