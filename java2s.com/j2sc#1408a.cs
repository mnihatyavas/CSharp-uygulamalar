// j2sc#1408a.cs: Komut satýrý argümanlarý, ReadLine(), xml ve Connection örneði.

using System;
using System.Xml; //XmlDocument, XmlTextWriter ve Formatting için
using System.Configuration; //AppSettingsReader ve ConfigurationManager için
using System.Data.SqlClient; //SqlConnection için
namespace Geliþimler {
    class ÇeþitliA {
        static void Main (string[] ksarg) {
            Console.Write ("Komut satýrýndan girilecek argümanlarý yakalamak için parametresiz 'Main()' yerine 'Main(string[] ksarg)' kodlanmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Komut satýrýndan girilecek argümanlarýn yönetimi:");
            Console.WriteLine ("Bu koþturmada {0} adet komut-satýrý argümanlarý mevcut.", ksarg.Length);
            if (ksarg.Length > 0) {//c#>j2sc#1408a kodla/kodçöz m. nihat yavaþ mersin 2024.04.06
                Console.WriteLine ("Bunlar:");
                for (int i=0; i < ksarg.Length; i++) Console.WriteLine ("{0}) {1}", i, ksarg [i]);
            }
            if(ksarg.Length < 2) Console.WriteLine ("Argümanlar: 'kodla/kodçöz kelime1 [kelime2...kelimeN]' olmalý.");
            else if (ksarg [0] != "kodla" & ksarg [0] != "kodçöz") Console.WriteLine ("Ýlk argüman 'kodla' veya 'kodçöz' olmalý.");
            else {
                for(int n=1; n < ksarg.Length; n++) {Console.Write (n+"=[");
                    for(int i=0; i < ksarg [n].Length; i++) { 
                        if(ksarg [0] == "kodla") Console.Write ("Kodla");
                        else Console.Write ("Kodçöz");
                    }
                    Console.Write ("] ");
                } Console.WriteLine();
            }

            Console.WriteLine ("\nKomut-satýrý deðil, program koþturulurken klavyeden verigiriþi:");
            Console.Write ("Lütfen adýnýzý girin [Ent]: "); string ad = Console.ReadLine();
            if (ad.Length < 3) ad="Nihat";
            Console.Write ("Lütfen yaþýnýzý girin [Ent]: "); int yaþ; try {yaþ=int.Parse (Console.ReadLine());}catch {yaþ=67;}
            if (yaþ < 0 | yaþ > 150) yaþ=67;
            ConsoleColor renk = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Merhaba {0}! Yaþýnýz {1}'dir.", ad, yaþ);
            Console.ForegroundColor = renk;

            Console.WriteLine ("\nxml.Load('j2sc#1408a.config')'la okunan, xml.WriteTo ile ekrana sunulur:");
            XmlDocument xml = new XmlDocument();
            xml.Load (Environment.GetCommandLineArgs() [0] + ".config"); //xml içerikli "j2sc#1408a.config" dosyasý hazýrlanmalýdýr
            XmlTextWriter yazýcý = new XmlTextWriter (Console.Out);
            yazýcý.Formatting = Formatting.Indented;
            xml.WriteTo (yazýcý);

            Console.WriteLine ("\nAppSettingsReader'le xml'den key'in value'suna eriþme:");
            //System.Configuration.AppSettingsReader cas = new System.Configuration.AppSettingsReader();
            //Console.WriteLine ((string)(cas.GetValue ("label1.Text", typeof (string))));
/*          AppSettingsReader ar = new AppSettingsReader();
            Console.WriteLine ("Ýþte appConStr dizgen:");
            Console.WriteLine (ar.GetValue ("appConStr", typeof (string)));
            int dört = (int)ar.GetValue ("intValue", typeof (int));
            for(int i = 0; i < dört; i++) Console.WriteLine ("Yo");
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="appConStr" value="server=localhost;uid=sa;pwd=;database=Cars" />
    <add key="intValue" value="4" />
  </appSettings>
</configuration>
*/
            Console.WriteLine ("\nVeri sunucu ve müþterisine dair baðlantý bilgileri:");
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings) {
                Console.WriteLine ("Baðlantý sunucusunun adý: " + css.Name);
                Console.WriteLine ("Veri müþterisinin adý: " + css.ProviderName);
                Console.WriteLine ("Veri kaynaðý: " + css.ConnectionString);
            }
            try {
            string bað1 = ConfigurationManager.ConnectionStrings ["AdventureWorks"].ConnectionString;
            SqlConnection bað2 = new SqlConnection (bað1);
            bað2.Open(); Console.WriteLine ("Açýkken baðlantý dizgesinin durumu = {0}", bað2.State);
            bað2.Close(); Console.WriteLine ("Kapalýyken baðlantý dizgesinin durumu = {0}", bað2.State);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}