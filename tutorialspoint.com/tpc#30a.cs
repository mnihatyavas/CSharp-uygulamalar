// tpc#30a.cs: Yansýtma kodlamasýyla tipli sýnýf vasýflarýný tarama örneði.

using System;
using System.Reflection;
namespace Yansýtma {
    [AttributeUsage (AttributeTargets.All, AllowMultiple = true)]
    public class TürevVasýf : System.Attribute {
        public string adres; // Gerekli konumsal parametre
        private string konu; // Tercihi-adlý parametre
        public TürevVasýf (string yurel) {this.adres = yurel;}
        public string Konu {get {return konu;} set {konu = value;}}
        public string Yurel {get {return adres;}}
    }

    [TürevVasýf ("www.tutorialspoint.com", Konu="Bilgisayar eðitim adresi")]
    [TürevVasýf ("www.tutorialspoint.com/C#", Konu="CSharp eðitimi")]
    [TürevVasýf ("www.tutorialspoint.com/C#/Reflection", Konu="Yansýtma sayfasý")]
    class Sýnýfým {}

    class VasýfGörüntüleme {
        static void Main() {
            Console.Write ("System.Reflection sýnýfý: Çalýþmazamaný vasýf bilgilerini gösterir; kodlamadaki tip çeþitlerini inceler ve bunlarla tipleme yapar; metod ve özellik önü vasýf baðlama yapar; çalýþmazamanlý yeni tipler yaratýr ve bunlarla iþlem yapar.\nBir sýnýfdaki vasýflarý görüntülemek için öncelikle o sýnýfýn tipini tanýmlar: System.Reflection.MemberInfo tip = typeof(Sýnýfým);\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            MemberInfo üyeBilgisi = typeof (Sýnýfým);
            object[] vasýflar = üyeBilgisi.GetCustomAttributes (false);
            for (int i = 0; i < vasýflar.Length; i++) {
                TürevVasýf tv = (TürevVasýf) vasýflar [i];
                Console.WriteLine ("Yurel: {0}\nKonu: {1}\n", tv.Yurel, tv.Konu);
            }

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}