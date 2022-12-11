// tpc#19f.cs: S�n�f�n yegane statik de�i�ken �yesi �rne�i.

using System;
namespace S�n�flar {
    class Statik�ye {
        public static int say�1;
        public int say�2 = 0;

        public void say1() {say�1++;}
        public void say2() {say�2++;}
        public int say�1Al() {return say�1;}
        public int say�2Al() {return say�2;}
    }
    class YeganeStatik�ye1 {
        static void Main (string[] args) {
            Console.Write ("S�n�f�n statik de�i�keni, �oklu s�n�f nesnesi yarat�lsa da bellekte tektir. S�n�f nesnesi yarat�lmadan da nokta i�lemcili eri�ilir, haricen de ilkde�er atanabilir.\nTu�..."); Console.ReadKey();

            Statik�ye.say�1 = 0;
            //Statik�ye.say�2 = 0; // Statik olmayan yarat�lmadan eri�im hata verir
            Statik�ye s1 = new Statik�ye(); Statik�ye s2 = new Statik�ye(); Statik�ye s3 = new Statik�ye();
            //s1.say�2 = 0; s2.say�2 = 0; s3.say�2 = 0; // Hata vermez, ancak s�n�fi�i ilk de�er atamas� daha pratik

            s1.say1(); s2.say1(); s2.say1(); s3.say1(); s3.say1(); s3.say1();
            s1.say2(); s2.say2(); s2.say2(); s3.say2(); s3.say2(); s3.say2();

            Console.WriteLine ("\n\n3 s�n�f nesnesinin statik de�i�ken de�erleri: [{0}, {1}, {2}].", s1.say�1Al(), s2.say�1Al(), s3.say�1Al());
            Console.WriteLine ("3 s�n�f nesnesinin statik-S�Z de�i�ken de�erleri: [{0}, {1}, {2}].", s1.say�2Al(), s2.say�2Al(), s3.say�2Al());
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}