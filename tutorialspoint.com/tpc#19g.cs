// tpc#19g.cs: Sınıfın yegane statik değişken ve statik fonksiyon üyesi örneği.

using System;
namespace Sınıflar {
    class StatikÜye {
        public static int sayı;

        public void say() {sayı++;}
        public static int sayıAl() {return sayı;}
    }
    class YeganeStatikÜye2 {
        static void Main (string[] args) {
            Console.Write ("Sınıfın statik değişken ve statik fonksiyon üyelerine tiplenen nesne kullanılmaksızın doğrudan sınıf adlı nokta işlemciyle erişilir.\nTuş..."); Console.ReadKey();

            StatikÜye.sayı = 0;
            StatikÜye s1 = new StatikÜye(); StatikÜye s2 = new StatikÜye(); StatikÜye s3 = new StatikÜye();
            s1.say(); s2.say(); s2.say(); s3.say(); s3.say(); s3.say();
            //Console.WriteLine ("\n\n3 sınıf nesnesinin statik değişken değerleri: [{0}, {1}, {2}].", s1.sayıAl(), s2.sayıAl(), s3.sayıAl());// Hata, statik fonksiyona tiplemesiz doğrudan erişilmelidir
            Console.WriteLine ("\n\nStatik değişkene doğrudan sınıf adıyla erişim: [{0}].", StatikÜye.sayıAl());

            StatikÜye.sayı = 10;
            StatikÜye s = new StatikÜye();
            s.say(); s.say(); s.say(); s.say(); s.say(); s.say();
            Console.WriteLine ("Statik değişkene doğrudan sınıf adıyla erişim: [{0}].", StatikÜye.sayıAl());
            Console.Write ("Tuş..."); Console.ReadKey();

        }
    }
}