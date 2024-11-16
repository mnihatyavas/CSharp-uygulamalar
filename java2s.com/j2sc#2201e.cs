// j2sc#2201e.cs: Cast, OfType tip ay�klama ve s�n�f �zellik get-set'le ilkde�erleme �rne�i.

using System;
using System.Collections.Generic; //Soysal IEnumerable<> i�in
using System.Linq; //Cast i�in
namespace Tipleme {
    class Ki�i {
        int _bordoNo;
        decimal _maa�;
        string _isim;
        string _meslek;
        public int BordoNo {get {return _bordoNo;} set {_bordoNo = value;}}
        public decimal Maa� {get {return _maa�;} set {_maa� = value;}}
        public string �sim {get {return _isim;} set {_isim = value;}}
        public string Meslek {get {return _meslek;} set {_meslek = value;}}
    }
    class Cast_OfType {
        static void Main() {
            Console.Write ("Cast tipleme: 'IEnumerable<double> d = nesneDizi.Cast<double>()' ile, OfType tipleme: 'IEnumerable<double> d=nesneDizi.OfType<double>()' ile yap�lmakta.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

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

            Console.WriteLine ("\nS�n�f alanlar�n� ilkde�erleme ve soysal listeye ekleme:");
            var ki�iler = new List<Ki�i>();
            Ki�i ki�i;
            string dzg;
            for(i=0;i<5;i++) {
                ki�i=new Ki�i();
                ts=r.Next(1299,2024);
                ki�i.BordoNo=ts;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                ki�i.�sim=dzg;
                ts=r.Next(5,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                ki�i.Meslek=dzg;
                ds=r.Next(12500,150000)+r.Next(10,100)/100.0;
                ki�i.Maa�=(decimal)ds;
                ki�iler.Add (ki�i);
            }
            foreach(var k in ki�iler) Console.WriteLine ("No: {0}  Ad: {1,-20} Meslek: {2,-10}  Maa�: {3,10:#,0.00} TL", k.BordoNo, k.�sim, k.Meslek, k.Maa�);
            Console.WriteLine ("-->'new List<Ki�i>()' yerine 'new Ki�i[]' y�ntemli ilkde�erleme ve d�k�m:");
            Ki�i[] ki�iDizi = new Ki�i [5];
            for(i=0;i<5;i++) {
                ki�i=new Ki�i();
                ts=r.Next(1299,2024);
                ki�i.BordoNo=ts;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91); ts=r.Next(3,10); dzg+=" "; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                ki�i.�sim=dzg;
                ts=r.Next(5,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,91);
                ki�i.Meslek=dzg;
                ds=r.Next(12500,150000)+r.Next(10,100)/100.0;
                ki�i.Maa�=(decimal)ds;
                ki�iDizi [i]=ki�i;
            }
            foreach(var k in ki�iDizi) Console.WriteLine ("No: {0}  Ad: {1,-20} Meslek: {2,-10}  Maa�: {3,10:#,0.00} TL", k.BordoNo, k.�sim, k.Meslek, k.Maa�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}