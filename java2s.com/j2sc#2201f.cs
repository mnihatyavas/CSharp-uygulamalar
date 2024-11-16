// j2sc#2201f.cs: Anonim soysal delegeli/lambda'l� Func<> �rne�i.

using System;
using System.Linq; // Where ve Select i�in
namespace AnonimFunc {
    static class S�n�fA {
        public static Func<T, T> ��le<T> (this Func<T, T> ilkFunc) {return x => ilkFunc (ilkFunc (ilkFunc (x)));}
    }
    static class S�n�fB {
        public static Func<A, Func<B, R>> uzant�<A, B, R> (this Func<A, B, R > f) {return a => b => f (a, b);}
    }
    class Delegeli_Lambdal� {
        static void y�r�t (Func<int> de�er) {Console.WriteLine ("Parametrik 'de�er' bir int-tamsay�'d�r: [{0}]", de�er());}
        static void y�r�t (Func<double> de�er) {Console.WriteLine ("Parametrik 'de�er' bir double-dublesay�'d�r: [{0}]", de�er());}
        static void y�r�t (Func<bool> de�er) {Console.WriteLine ("Parametrik 'de�er' bir bool-ikili'dir: [{0}]", de�er());}
        static void y�r�t (Func<string> de�er) {Console.WriteLine ("Parametrik 'de�er' bir string-dizge'dir: [{0}]", de�er());}
        static void Main() {
            Console.Write ("'Func<int,int,string> f = (x, y) => (x + y).ToString()' lambda'l� anonim soysal fonksiyonda int-x, int-y girenler, string-return ise geri d�nen tip-de�er'lerdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim lambda Func'la say�n�n bir ve �� kat�n� d�nd�rme:");
            int i, j, ts;
            Func<int, int> birart�r = x => x + x;
            Func<int, int> ��art�r = birart�r.��le();
            for(i=1;i<11;i++) Console.WriteLine ("S�ral� say�: {0}\t�ki kat�: {1}\t�� kat�: {2}", i, birart�r (i), ��art�r (i));

            Console.WriteLine ("\n��i�e for-i[0-->10+=100]-j[1000-->1008] ile topla-toplay�c� (11x9) �retme:");
            Func<int, Func<int, int>> toplay�c� = (n => (x => n += x+100));
            var topla=toplay�c� (0);
            for(i=0;i<=10;i++) {
                topla = toplay�c� (i);
                for(j=1000;j<1009;j++) Console.Write (topla (j) + " "); Console.WriteLine();
            }

            Console.WriteLine ("\n�oklu Func'la 1881+=[0-->57] ikili toplama sonu�lar�n� sunma:");
            Func<int, int, int> toplaTek = (x, y) => (x + y);
            Func<int, Func<int, int>> uzant�l�ToplaTek = toplaTek.uzant�();
            Func<int, int> topla�ki = uzant�l�ToplaTek (1881);
            for(i=0;i<=57;i++) Console.Write (topla�ki (i) + " "); Console.WriteLine();

            Console.WriteLine ("\nFunc ve Where-OrderBy-Select'le t�m, uzn>6 ve uzn<=6 �ehirleri listeleme:");
            string[] �ehirler = {"�anl�Urfa", "Mersin", "Bursa", "Malatya", "Van", "�stanbul", "Ankara", "�zmir", "KahramanMara�", "Bolu"};
            Func<string, bool> �artl�Arama1 = delegate (string �ehir) {return �ehir.Length > 6;};
            Func<string, bool> �artl�Arama2 = delegate (string �ehir) {return �ehir.Length <= 6;};
            Func<string, string> �ehirleriTarama = delegate (string �ehir) {return �ehir;};
            var se�ilen�ehirler = �ehirler
                //.Where (�artl�Arama1)
                .OrderBy (�ehirleriTarama) //Artan s�ralar
                .Select (�ehirleriTarama);
            Console.Write ("T�m �ehirler: "); foreach (var �ehir in /*se�ilen�ehirler*/ �ehirler) Console.Write (�ehir+" "); Console.WriteLine();
            se�ilen�ehirler = �ehirler
                .Where (�artl�Arama1)
                .OrderBy (�ehirleriTarama) //Artan s�ralar
                .Select (�ehirleriTarama);
            Console.Write ("�ehir.Length > 6: "); foreach (var �ehir in se�ilen�ehirler) Console.Write (�ehir+" "); Console.WriteLine();
            se�ilen�ehirler = �ehirler
                .Where (�artl�Arama2)
                .OrderBy (�ehirleriTarama) //Artan s�ralar
                .Select (�ehirleriTarama);
            Console.Write ("�ehir.Length <= 6: "); foreach (var �ehir in se�ilen�ehirler) Console.Write (�ehir+" "); Console.WriteLine();

            Console.WriteLine ("\nSoysal Func<T> uygun arg�man tipli fonksiyonun y�r�t�lmesi:");
            y�r�t (() => "Nihat");
            y�r�t (() => 2*2==5);
            y�r�t (() => 20241102);
            y�r�t (() => 20241102.1707);

            Console.WriteLine ("\nLambda'l� Func'la rasgele dizge uzunlu�u ve y�la toplam sunumlar�:");
            string dzg; var r=new Random();
            Func<int, int, string> y�l = (x, y) => (x + y).ToString();
            Func<string, int> uzn = (string str) => {return str.Length;};
            for(i=0;i<=10;i++) {
                dzg=""; ts=r.Next(3,10); for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(0,58); dzg+="-->"+ts; 
                Console.WriteLine ("Dizge: {0,-25}\tUzunluk: {1}\tY�l: {2}", dzg, uzn (dzg), y�l (ts, 1881));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}