// j2sc#2101a.cs: Thread.CurrentThread.CurrentCulture ve CultureInfo örneði.

using System;
using System.Threading;
using System.Globalization; //CultureInfo için
namespace Kültürler {
    class KültürA {
        static void Main() {
            Console.Write ("Herhangi bir kültür bilgisi 'CultureInfo ci = new CultureInfo('tr-TR')' ile, ve bu kültüre dönüþüm 'Thread.CurrentThread.CurrentCulture = ci' ile saðlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Varsayýlý, deðiþtirilen, UI kültürleri:");
            Console.WriteLine ("Varsayýlý kültür: " + Thread.CurrentThread.CurrentCulture.Name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE"); Console.WriteLine ("Deðiþtirilen kültür: " + Thread.CurrentThread.CurrentCulture.Name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US"); Console.WriteLine ("Deðiþtirilen kültür: " + Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine ("CurrentCulture = {0}", CultureInfo.CurrentCulture);
            Console.WriteLine ("CurrentUICulture = {0}", CultureInfo.CurrentUICulture);
            CultureInfo ci = new CultureInfo ("nl-BE");
            Console.WriteLine ("'nl-BE' için (NativeName, EnglishName) = ({0}, {1})", ci.NativeName, ci.EnglishName);


            Console.WriteLine ("\nAktüel kültürle IConvertible ve doðrudan int-->byte çevrimleri:");
            int i=2358999, ts = 20241009;
            byte bs;
            Console.WriteLine("IConvertible aracýlýðýyla System.Int32'den System.Byte'a çevriliyor...");
            IConvertible ic = (IConvertible)(ts%256);
            bs = ic.ToByte (CultureInfo.CurrentCulture);
            Console.WriteLine ("int ts: (tipi, deðeri) = ({0}, {1})", ts.GetTypeCode(), ts);
            Console.WriteLine ("IConvertible ile çevrilen 'byte bs': (tipi, deðeri) = ({0}, {1})", bs.GetTypeCode(), bs);
            Console.WriteLine ("Doðrudan çevrilen 'byte bs': (tipi, deðeri) = ({0}, {1}/{2})", bs.GetTypeCode(), bs=(byte)i, i);

            Console.WriteLine ("\nRasgele double/decimal paralarýn türk, ingiliz, abd sunumu:");
            var r=new Random(); double ds; decimal ms;
            CultureInfo ingiliz = new CultureInfo ("en-GB");
            CultureInfo abd = new CultureInfo ("en-US");
            CultureInfo türk = new CultureInfo ("tr-TR");
            for(i=0;i<10;i++) {
                ds=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000D;
                Console.WriteLine ("D({0,18}), ({1,17}), ({2,17})", ds.ToString ("C", türk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
            }
            for(i=0;i<10;i++) {
                ms=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000M;
                Console.WriteLine ("   M({0,19}), ({1,18}), ({2,18})", ms.ToString ("C3", türk), ms.ToString ("C3", ingiliz), ms.ToString ("C3", abd));
            }

            Console.WriteLine ("\n354 adetlik tüm dünya kültürleri ve akronimleri:");
            i=0;
            foreach (CultureInfo c in CultureInfo.GetCultures (CultureTypes.AllCultures)) {
                Console.WriteLine ("{0,3}) {1}: {2}", ++i, c.EnglishName, c.Name);
                if(i%20==0) {Console.Write ("\nTuþ..."); Console.ReadKey(); Console.WriteLine();}
            }

            Console.WriteLine ("\nÝngilizce i/I ve türkçe özel harfler (i/Ý, ý/I, ç/Ç, ð/Ð, ö/Ö, þ/Þ, ü/Ü):");
            ci = CultureInfo.GetCultureInfo ("en-US"); Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("{0}", ci.DisplayName);
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'i', (int)'i', Char.ToUpper ('i'), (int)Char.ToUpper ('i'));
            ci = CultureInfo.GetCultureInfo ("tr-TR"); Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("{0}", ci.DisplayName);
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'i', (int)'i', Char.ToUpper ('i'), (int)Char.ToUpper ('i'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'ý', (int)'ý', Char.ToUpper ('ý'), (int)Char.ToUpper ('ý'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'ç', (int)'ç', Char.ToUpper ('ç'), (int)Char.ToUpper ('ç'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'ð', (int)'ð', Char.ToUpper ('ð'), (int)Char.ToUpper ('ð'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'ö', (int)'ö', Char.ToUpper ('ö'), (int)Char.ToUpper ('ö'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'þ', (int)'þ', Char.ToUpper ('þ'), (int)Char.ToUpper ('þ'));
            Console.WriteLine ("Küçük->Büyük: {0} ({1}) -> {2} ({3})", 'ü', (int)'ü', Char.ToUpper ('ü'), (int)Char.ToUpper ('ü'));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}