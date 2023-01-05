// tpc#29a.cs: Ön-tanýmlý þartlý hata-ayýklayýcý vasýf örneði.

#define DEBUG
using System;
using System.Diagnostics;
namespace Vasýflar {
    public class VasýflýSýnýfým {
        [Conditional ("DEBUG")]
        public static void Mesajým (string mesaj) {Console.WriteLine (mesaj);}
    }
    class ÞartlýVasýf {
        static void fonk1() {VasýflýSýnýfým.Mesajým ("Þimdi ÞartlýVasýf-->fonk1() içindeyim."); fonk2();}
        static void fonk2() {VasýflýSýnýfým.Mesajým ("Þimdi ÞartlýVasýf-->fonk2() içindeyim.");}
        static void Main() {
            Console.Write ("Vasýflar, çalýþmazamanýnda, sýnýf, metod, yapý, sayýsallanan gibi elemanlara dair bilgi beyan etiketleridir; ve [] içinde eleman önündedir. Ön-tanýmlý veya özel-yapýlý olabilirler. Ön-tanýmlýlar 3 türlüdür: AttributeUsage/VasýfKullanýmý, Conditional/Þartlý, Obsolete/Demode.\nÝlkine örnek: [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = inherited)]\nÞartlý ise derleme-zamanlý DEBUG gibi öniþlemci direktifine hata-ayýklama kimlikleyici sunar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            VasýflýSýnýfým.Mesajým ("VasýflýSýnýfým'ýn DEBUG þartlý vasýflý Mesajým metodunu kullanarak:\nÞimdi ÞartlýVasýf-->Main() içindeyim.");
            fonk1();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}