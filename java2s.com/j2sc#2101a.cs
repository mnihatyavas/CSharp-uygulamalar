// j2sc#2101a.cs: Thread.CurrentThread.CurrentCulture ve CultureInfo �rne�i.

using System;
using System.Threading;
using System.Globalization; //CultureInfo i�in
namespace K�lt�rler {
    class K�lt�rA {
        static void Main() {
            Console.Write ("Herhangi bir k�lt�r bilgisi 'CultureInfo ci = new CultureInfo('tr-TR')' ile, ve bu k�lt�re d�n���m 'Thread.CurrentThread.CurrentCulture = ci' ile sa�lan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Varsay�l�, de�i�tirilen, UI k�lt�rleri:");
            Console.WriteLine ("Varsay�l� k�lt�r: " + Thread.CurrentThread.CurrentCulture.Name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE"); Console.WriteLine ("De�i�tirilen k�lt�r: " + Thread.CurrentThread.CurrentCulture.Name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US"); Console.WriteLine ("De�i�tirilen k�lt�r: " + Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine ("CurrentCulture = {0}", CultureInfo.CurrentCulture);
            Console.WriteLine ("CurrentUICulture = {0}", CultureInfo.CurrentUICulture);
            CultureInfo ci = new CultureInfo ("nl-BE");
            Console.WriteLine ("'nl-BE' i�in (NativeName, EnglishName) = ({0}, {1})", ci.NativeName, ci.EnglishName);


            Console.WriteLine ("\nAkt�el k�lt�rle IConvertible ve do�rudan int-->byte �evrimleri:");
            int i=2358999, ts = 20241009;
            byte bs;
            Console.WriteLine("IConvertible arac�l���yla System.Int32'den System.Byte'a �evriliyor...");
            IConvertible ic = (IConvertible)(ts%256);
            bs = ic.ToByte (CultureInfo.CurrentCulture);
            Console.WriteLine ("int ts: (tipi, de�eri) = ({0}, {1})", ts.GetTypeCode(), ts);
            Console.WriteLine ("IConvertible ile �evrilen 'byte bs': (tipi, de�eri) = ({0}, {1})", bs.GetTypeCode(), bs);
            Console.WriteLine ("Do�rudan �evrilen 'byte bs': (tipi, de�eri) = ({0}, {1}/{2})", bs.GetTypeCode(), bs=(byte)i, i);

            Console.WriteLine ("\nRasgele double/decimal paralar�n t�rk, ingiliz, abd sunumu:");
            var r=new Random(); double ds; decimal ms;
            CultureInfo ingiliz = new CultureInfo ("en-GB");
            CultureInfo abd = new CultureInfo ("en-US");
            CultureInfo t�rk = new CultureInfo ("tr-TR");
            for(i=0;i<10;i++) {
                ds=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000D;
                Console.WriteLine ("D({0,18}), ({1,17}), ({2,17})", ds.ToString ("C", t�rk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
            }
            for(i=0;i<10;i++) {
                ms=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000M;
                Console.WriteLine ("   M({0,19}), ({1,18}), ({2,18})", ms.ToString ("C3", t�rk), ms.ToString ("C3", ingiliz), ms.ToString ("C3", abd));
            }

            Console.WriteLine ("\n354 adetlik t�m d�nya k�lt�rleri ve akronimleri:");
            i=0;
            foreach (CultureInfo c in CultureInfo.GetCultures (CultureTypes.AllCultures)) {
                Console.WriteLine ("{0,3}) {1}: {2}", ++i, c.EnglishName, c.Name);
                if(i%20==0) {Console.Write ("\nTu�..."); Console.ReadKey(); Console.WriteLine();}
            }

            Console.WriteLine ("\n�ngilizce i/I ve t�rk�e �zel harfler (i/�, �/I, �/�, �/�, �/�, �/�, �/�):");
            ci = CultureInfo.GetCultureInfo ("en-US"); Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("{0}", ci.DisplayName);
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", 'i', (int)'i', Char.ToUpper ('i'), (int)Char.ToUpper ('i'));
            ci = CultureInfo.GetCultureInfo ("tr-TR"); Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("{0}", ci.DisplayName);
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", 'i', (int)'i', Char.ToUpper ('i'), (int)Char.ToUpper ('i'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));
            Console.WriteLine ("K���k->B�y�k: {0} ({1}) -> {2} ({3})", '�', (int)'�', Char.ToUpper ('�'), (int)Char.ToUpper ('�'));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}