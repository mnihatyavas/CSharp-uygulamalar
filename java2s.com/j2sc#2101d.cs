// j2sc#2101d.cs: RegionInfo, InputLanguage, ResourceManager örneði.

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms; //InputLanguage için
using System.Resources; //ResourceManager için
using System.Drawing; //Form.Size/Point/Font/FontStyle için
namespace Kültürler {
    class KültürB: Form {
        public KültürB() {//Kurucu
            try {ResourceManager rm = new ResourceManager ("kaynak1", this.GetType().Assembly);
                this.Size = new Size (400,100);
                this.Text=rm.GetString ("WindowText");
                Label fiþ = new Label();
                fiþ.Location = new Point (3,5);
                fiþ.Size = new Size (394,90);
                fiþ.Font = new Font ("Tahoma",36F,FontStyle.Bold);
                fiþ.Text=rm.GetString ("LabelText");
                this.Controls.Add (fiþ);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
        }
        [STAThread]
        static void Main() {
            Console.Write ("Kültür bilgisi 'CultureInfo ci', 'Thread.CurrentThread.CurrentCulture = ci' atanmadýkca aktüel kültür deðildir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("CultureInfo, CurrentCulture'a atanýrsa aktüel kültür olur:");
            Thread.CurrentThread.CurrentUICulture=new CultureInfo ("fr-FR");
            CultureInfo ci = new CultureInfo ("de-AT"); //: Avusturya, az-Latn-AZ: Azerbaycan, tg-Cyrl-TJ: Tacikistan
            Console.WriteLine ("KültürBilgi adý: {0}\tÝng.Adý: {1}\tYerelAdý: {2}", ci.Name, ci.EnglishName, ci.NativeName);
            Console.WriteLine ("AktüelKültür adý: {0}\tÝngiliceAdý: {1}\tYerelAdý: {2}",
                Thread.CurrentThread.CurrentUICulture.Name,
                Thread.CurrentThread.CurrentUICulture.EnglishName,
                Thread.CurrentThread.CurrentUICulture.NativeName);
            Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("AktüelKültür adý: {0}", Thread.CurrentThread.CurrentUICulture.Name);

            Console.WriteLine ("\nKültürVeBölgeBölgeBilgiKurucu'yla kurulacak 'x-en-US-metric' testi:");
            RegionInfo ri;
            try {ri = new RegionInfo ("x-en-US-metric");
                Console.WriteLine ("RegionInfo(\"x-en-US-metric\") metrik midir? ", ri.IsMetric);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
/* using System.xxx olmadýðýndan CultureAndRegionInfoBuilder ve CultureAndRegionModifiers hata vermekte
            CultureAndRegionInfoBuilder cib = new CultureAndRegionInfoBuilder ("x-en-US-metric", CultureAndRegionModifiers.None);
            cib.LoadDataFromCultureInfo (new CultureInfo ("en-US"));
            cib.LoadDataFromRegionInfo (new RegionInfo ("US"));
            cib.IsMetric = true;
            cib.Save ("x-en-US-metric.ldml");
            cib.Register();
            try {ri = new RegionInfo ("x-en-US-metric");
                Console.WriteLine ("RegionInfo(\"x-en-US-metric\") metrik midir? ", ri.IsMetric);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
*/

            Console.WriteLine ("\nKültür bilgilerini aktüel dilden veya kimlikleyiciden saðlama:");
            InputLanguage inL = InputLanguage.CurrentInputLanguage;
            ci = inL.Culture;
            Console.WriteLine ("\tKültür kimlikleyici: {0}\n\tAdýnýGöster: {1}\n\tTakvimi: {2}", ci, ci.DisplayName, ci.Calendar);
            ci = new CultureInfo ("tr-TR");
            Console.WriteLine ("Kültür kimlikleyici: {0}\nAdýnýGöster: {1}\nTakvimi: {2}", ci, ci.DisplayName, ci.Calendar);

            Console.WriteLine ("\nKültürlerde kabul gören kýyas iþaretleri ve sonuçlarý:");
            String[] iþaretler = new String[] {"<", "=", ">", "<=", ">=", "eþit"};
            String dzg1 = "Ýsmail", dzg2 = "Zafer", dzg3 = "Ýsmail";
            CompareInfo kýyas = new CultureInfo ("tr-TR").CompareInfo;
            Console.WriteLine ("-->{0} kültürün LCID no'su: {1}'dýr.", kýyas.Name, kýyas.LCID);
            Console.WriteLine ("({5}) için [{0} kýyas {1}]: {2}\t[{0} kýyas {3}]: {4}", dzg1, dzg2, iþaretler [kýyas.Compare (dzg1, dzg2) + 1], dzg3, iþaretler [kýyas.Compare (dzg1, dzg3) + 1], kýyas);
            kýyas = new CultureInfo ("en-US").CompareInfo;
            Console.WriteLine ("-->{0} kültürün LCID no'su: {1}'dir.", kýyas.Name, kýyas.LCID);
            Console.WriteLine ("({5}) için [{0} kýyas {1}]: {2}\t[{1} kýyas {3}]: {4}", dzg2, dzg1, iþaretler [kýyas.Compare (dzg2, dzg1) + 1], dzg3, iþaretler [kýyas.Compare (dzg1, dzg3) + 1], kýyas);

            Console.WriteLine ("\nÝki dizgenin genel kültürde parametreli kýyaslanmalarý:");
            dzg1 = "Kek";
            dzg2 = "K";
            kýyas = CultureInfo.InvariantCulture.CompareInfo;
            Console.WriteLine ("Sonek, yalýn: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsSuffix (dzg1, dzg2));
            Console.WriteLine ("Sonek, None: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsSuffix (dzg1, dzg2, CompareOptions.None));
            Console.WriteLine ("Sonek, Ordinal: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsSuffix (dzg1, dzg2, CompareOptions.Ordinal));
            Console.WriteLine ("Sonek, IgnoreCase: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsSuffix (dzg1, dzg2, CompareOptions.IgnoreCase));
            Console.WriteLine ("\tÖnek, yalýn: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsPrefix (dzg1, dzg2));
            Console.WriteLine ("\tÖnek, None: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsPrefix (dzg1, dzg2, CompareOptions.None));
            Console.WriteLine ("\tÖnek, Ordinal: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsPrefix (dzg1, dzg2, CompareOptions.Ordinal));
            Console.WriteLine ("\tÖnek, IgnoreCase: [{0} kýyas {1}]? {2}", dzg1, dzg2, kýyas.IsPrefix (dzg1, dzg2, CompareOptions.IgnoreCase));

            Console.WriteLine ("\nÇoklu kaynaklardan kültüre uygununun derlemede tercihi:");
            Application.Run (new KültürB()); //Derleme: /resource:kaynak1.recourses

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}
/*
File: kaynak1.txt
#Varsayýlý kültür kaynaklarý
WindowText = Uluslararasýlaþtýrma
LabelText = Merhaba Dünya!!!
*/