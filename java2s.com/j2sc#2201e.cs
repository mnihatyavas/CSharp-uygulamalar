// j2sc#2201e.cs: Cast, OfType tip ayýklama ve sýnýf özellik get-set'le ilkdeðerleme örneði.

using System;
using System.Collections.Generic; //Soysal IEnumerable<> için
using System.Linq; //Cast için
namespace Tipleme {
    class Kiþi {
        int _bordoNo;
        decimal _maaþ;
        string _isim;
        string _meslek;
        public int BordoNo {get {return _bordoNo;} set {_bordoNo = value;}}
        public decimal Maaþ {get {return _maaþ;} set {_maaþ = value;}}
        public string Ýsim {get {return _isim;} set {_isim = value;}}
        public string Meslek {get {return _meslek;} set {_meslek = value;}}
    }
    class Cast_OfType {
        static void Main() {
            Console.Write ("Cast tipleme: 'IEnumerable<double> d = nesneDizi.Cast<double>()' ile, OfType tipleme: 'IEnumerable<double> d=nesneDizi.OfType<double>()' ile yapýlmakta.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("nesneDizi'yi Cast<double> tipleyip IEnumerable'a atama:");
            int i, j, ts; double ds; var r=new Random();
            object[] nesneDizi = new object [10];
            for(i=0;i<10;i++) {
                ds=r.Next(1881,1939)+r.Next(10,100)/100.0;
                nesneDizi [i]=ds;
            }
            IEnumerable<double> dbl = nesneDizi.Cast<double>();
            Console.WriteLine ("nesneDizi tiplemesi: {0}\nIEnumerable-Linq-Cast tiplemesi: {1}", nesneDizi, dbl);
            for(i=0;i<10;i++) Console.Write ("{0,8:#,0.00}  ", nesneDizi [i]); Console.WriteLine();
            foreach(var d in dbl) Console.Write ("{0,8:#,0.00}  ", d); Console.WriteLine();

            Console.WriteLine ("\nnesneDizi'deki karma tipleri OfType<> tipleyip IEnumerable'a atama:");
            nesneDizi = new object[]{false, 33, 1.71, "Mersin", 44, 2*2==3, "Malatya", 61.5, 20241026, true, 14584.72};
            IEnumerable<int> ints=nesneDizi.OfType<int>();
            foreach(var t in ints) Console.Write ("{0:#,0}  ", t); Console.WriteLine();
            IEnumerable<string> str=nesneDizi.OfType<string>();
            foreach(var s in str) Console.Write ("{0}  ", s); Console.WriteLine();
            IEnumerable<bool> ikili=nesneDizi.OfType<bool>();
            foreach(var b in ikili) Console.Write ("{0}  ", b); Console.WriteLine();
            var duble=nesneDizi.OfType<double>();
            foreach(var d in duble) Console.Write ("{0:#,0.00}  ", d); Console.WriteLine();

            Console.WriteLine ("\nSýnýf alanlarýný ilkdeðerleme ve soysal listeye ekleme:");
            var kiþiler = new List<Kiþi>();
            Kiþi kiþi;
            string dzg;
            for(i=0;i<5;i++) {
                kiþi=new Kiþi();
                ts=r.Next(1299,2024);
                kiþi.BordoNo=ts;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                kiþi.Ýsim=dzg;
                ts=r.Next(5,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                kiþi.Meslek=dzg;
                ds=r.Next(12500,150000)+r.Next(10,100)/100.0;
                kiþi.Maaþ=(decimal)ds;
                kiþiler.Add (kiþi);
            }
            foreach(var k in kiþiler) Console.WriteLine ("No: {0}  Ad: {1,-20} Meslek: {2,-10}  Maaþ: {3,10:#,0.00} TL", k.BordoNo, k.Ýsim, k.Meslek, k.Maaþ);
            Console.WriteLine ("-->'new List<Kiþi>()' yerine 'new Kiþi[]' yöntemli ilkdeðerleme ve döküm:");
            Kiþi[] kiþiDizi = new Kiþi [5];
            for(i=0;i<5;i++) {
                kiþi=new Kiþi();
                ts=r.Next(1299,2024);
                kiþi.BordoNo=ts;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                kiþi.Ýsim=dzg;
                ts=r.Next(5,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                kiþi.Meslek=dzg;
                ds=r.Next(12500,150000)+r.Next(10,100)/100.0;
                kiþi.Maaþ=(decimal)ds;
                kiþiDizi [i]=kiþi;
            }
            foreach(var k in kiþiDizi) Console.WriteLine ("No: {0}  Ad: {1,-20} Meslek: {2,-10}  Maaþ: {3,10:#,0.00} TL", k.BordoNo, k.Ýsim, k.Meslek, k.Maaþ);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}