// tpc#19f.cs: Sınıfın yegane statik değişken üyesi örneği.

using System;
namespace Sınıflar {
    class StatikÜye {
        public static int sayı1;
        public int sayı2 = 0;

        public void say1() {sayı1++;}
        public void say2() {sayı2++;}
        public int sayı1Al() {return sayı1;}
        public int sayı2Al() {return sayı2;}
    }
    class YeganeStatikÜye1 {
        static void Main (string[] args) {
            Console.Write ("Sınıfın statik değişkeni, çoklu sınıf nesnesi yaratılsa da bellekte tektir. Sınıf nesnesi yaratılmadan da nokta işlemcili erişilir, haricen de ilkdeğer atanabilir.\nTuş..."); Console.ReadKey();

            StatikÜye.sayı1 = 0;
            //StatikÜye.sayı2 = 0; // Statik olmayan yaratılmadan erişim hata verir
            StatikÜye s1 = new StatikÜye(); StatikÜye s2 = new StatikÜye(); StatikÜye s3 = new StatikÜye();
            //s1.sayı2 = 0; s2.sayı2 = 0; s3.sayı2 = 0; // Hata vermez, ancak sınıfiçi ilk değer ataması daha pratik

            s1.say1(); s2.say1(); s2.say1(); s3.say1(); s3.say1(); s3.say1();
            s1.say2(); s2.say2(); s2.say2(); s3.say2(); s3.say2(); s3.say2();

            Console.WriteLine ("\n\n3 sınıf nesnesinin statik değişken değerleri: [{0}, {1}, {2}].", s1.sayı1Al(), s2.sayı1Al(), s3.sayı1Al());
            Console.WriteLine ("3 sınıf nesnesinin statik-SİZ değişken değerleri: [{0}, {1}, {2}].", s1.sayı2Al(), s2.sayı2Al(), s3.sayı2Al());
            Console.Write ("Tuş..."); Console.ReadKey();

        }
    }
}