// j2sc#1408a.cs: Komut sat�r� arg�manlar�, ReadLine(), xml ve Connection �rne�i.

using System;
using System.Xml; //XmlDocument, XmlTextWriter ve Formatting i�in
using System.Configuration; //AppSettingsReader ve ConfigurationManager i�in
using System.Data.SqlClient; //SqlConnection i�in
namespace Geli�imler {
    class �e�itliA {
        static void Main (string[] ksarg) {
            Console.Write ("Komut sat�r�ndan girilecek arg�manlar� yakalamak i�in parametresiz 'Main()' yerine 'Main(string[] ksarg)' kodlanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Komut sat�r�ndan girilecek arg�manlar�n y�netimi:");
            Console.WriteLine ("Bu ko�turmada {0} adet komut-sat�r� arg�manlar� mevcut.", ksarg.Length);
            if (ksarg.Length > 0) {//c#>j2sc#1408a kodla/kod��z m. nihat yava� mersin 2024.04.06
                Console.WriteLine ("Bunlar:");
                for (int i=0; i < ksarg.Length; i++) Console.WriteLine ("{0}) {1}", i, ksarg [i]);
            }
            if(ksarg.Length < 2) Console.WriteLine ("Arg�manlar: 'kodla/kod��z kelime1 [kelime2...kelimeN]' olmal�.");
            else if (ksarg [0] != "kodla" & ksarg [0] != "kod��z") Console.WriteLine ("�lk arg�man 'kodla' veya 'kod��z' olmal�.");
            else {
                for(int n=1; n < ksarg.Length; n++) {Console.Write (n+"=[");
                    for(int i=0; i < ksarg [n].Length; i++) { 
                        if(ksarg [0] == "kodla") Console.Write ("Kodla");
                        else Console.Write ("Kod��z");
                    }
                    Console.Write ("] ");
                } Console.WriteLine();
            }

            Console.WriteLine ("\nKomut-sat�r� de�il, program ko�turulurken klavyeden verigiri�i:");
            Console.Write ("L�tfen ad�n�z� girin [Ent]: "); string ad = Console.ReadLine();
            if (ad.Length < 3) ad="Nihat";
            Console.Write ("L�tfen ya��n�z� girin [Ent]: "); int ya�; try {ya�=int.Parse (Console.ReadLine());}catch {ya�=67;}
            if (ya� < 0 | ya� > 150) ya�=67;
            ConsoleColor renk = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Merhaba {0}! Ya��n�z {1}'dir.", ad, ya�);
            Console.ForegroundColor = renk;

            Console.WriteLine ("\nxml.Load('j2sc#1408a.config')'la okunan, xml.WriteTo ile ekrana sunulur:");
            XmlDocument xml = new XmlDocument();
            xml.Load (Environment.GetCommandLineArgs() [0] + ".config"); //xml i�erikli "j2sc#1408a.config" dosyas� haz�rlanmal�d�r
            XmlTextWriter yaz�c� = new XmlTextWriter (Console.Out);
            yaz�c�.Formatting = Formatting.Indented;
            xml.WriteTo (yaz�c�);

            Console.WriteLine ("\nAppSettingsReader'le xml'den key'in value'suna eri�me:");
            //System.Configuration.AppSettingsReader cas = new System.Configuration.AppSettingsReader();
            //Console.WriteLine ((string)(cas.GetValue ("label1.Text", typeof (string))));
/*          AppSettingsReader ar = new AppSettingsReader();
            Console.WriteLine ("��te appConStr dizgen:");
            Console.WriteLine (ar.GetValue ("appConStr", typeof (string)));
            int d�rt = (int)ar.GetValue ("intValue", typeof (int));
            for(int i = 0; i < d�rt; i++) Console.WriteLine ("Yo");
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="appConStr" value="server=localhost;uid=sa;pwd=;database=Cars" />
    <add key="intValue" value="4" />
  </appSettings>
</configuration>
*/
            Console.WriteLine ("\nVeri sunucu ve m��terisine dair ba�lant� bilgileri:");
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings) {
                Console.WriteLine ("Ba�lant� sunucusunun ad�: " + css.Name);
                Console.WriteLine ("Veri m��terisinin ad�: " + css.ProviderName);
                Console.WriteLine ("Veri kayna��: " + css.ConnectionString);
            }
            try {
            string ba�1 = ConfigurationManager.ConnectionStrings ["AdventureWorks"].ConnectionString;
            SqlConnection ba�2 = new SqlConnection (ba�1);
            ba�2.Open(); Console.WriteLine ("A��kken ba�lant� dizgesinin durumu = {0}", ba�2.State);
            ba�2.Close(); Console.WriteLine ("Kapal�yken ba�lant� dizgesinin durumu = {0}", ba�2.State);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}