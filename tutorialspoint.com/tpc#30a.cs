// tpc#30a.cs: Yans�tma kodlamas�yla tipli s�n�f vas�flar�n� tarama �rne�i.

using System;
using System.Reflection;
namespace Yans�tma {
    [AttributeUsage (AttributeTargets.All, AllowMultiple = true)]
    public class T�revVas�f : System.Attribute {
        public string adres; // Gerekli konumsal parametre
        private string konu; // Tercihi-adl� parametre
        public T�revVas�f (string yurel) {this.adres = yurel;}
        public string Konu {get {return konu;} set {konu = value;}}
        public string Yurel {get {return adres;}}
    }

    [T�revVas�f ("www.tutorialspoint.com", Konu="Bilgisayar e�itim adresi")]
    [T�revVas�f ("www.tutorialspoint.com/C#", Konu="CSharp e�itimi")]
    [T�revVas�f ("www.tutorialspoint.com/C#/Reflection", Konu="Yans�tma sayfas�")]
    class S�n�f�m {}

    class Vas�fG�r�nt�leme {
        static void Main() {
            Console.Write ("System.Reflection s�n�f�: �al��mazaman� vas�f bilgilerini g�sterir; kodlamadaki tip �e�itlerini inceler ve bunlarla tipleme yapar; metod ve �zellik �n� vas�f ba�lama yapar; �al��mazamanl� yeni tipler yarat�r ve bunlarla i�lem yapar.\nBir s�n�fdaki vas�flar� g�r�nt�lemek i�in �ncelikle o s�n�f�n tipini tan�mlar: System.Reflection.MemberInfo tip = typeof(S�n�f�m);\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            MemberInfo �yeBilgisi = typeof (S�n�f�m);
            object[] vas�flar = �yeBilgisi.GetCustomAttributes (false);
            for (int i = 0; i < vas�flar.Length; i++) {
                T�revVas�f tv = (T�revVas�f) vas�flar [i];
                Console.WriteLine ("Yurel: {0}\nKonu: {1}\n", tv.Yurel, tv.Konu);
            }

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}