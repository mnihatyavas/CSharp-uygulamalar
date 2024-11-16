// j2sc#2101d.cs: RegionInfo, InputLanguage, ResourceManager �rne�i.

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms; //InputLanguage i�in
using System.Resources; //ResourceManager i�in
using System.Drawing; //Form.Size/Point/Font/FontStyle i�in
namespace K�lt�rler {
    class K�lt�rB: Form {
        public K�lt�rB() {//Kurucu
            try {ResourceManager rm = new ResourceManager ("kaynak1", this.GetType().Assembly);
                this.Size = new Size (400,100);
                this.Text=rm.GetString ("WindowText");
                Label fi� = new Label();
                fi�.Location = new Point (3,5);
                fi�.Size = new Size (394,90);
                fi�.Font = new Font ("Tahoma",36F,FontStyle.Bold);
                fi�.Text=rm.GetString ("LabelText");
                this.Controls.Add (fi�);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
        }
        [STAThread]
        static void Main() {
            Console.Write ("K�lt�r bilgisi 'CultureInfo ci', 'Thread.CurrentThread.CurrentCulture = ci' atanmad�kca akt�el k�lt�r de�ildir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("CultureInfo, CurrentCulture'a atan�rsa akt�el k�lt�r olur:");
            Thread.CurrentThread.CurrentUICulture=new CultureInfo ("fr-FR");
            CultureInfo ci = new CultureInfo ("de-AT"); //: Avusturya, az-Latn-AZ: Azerbaycan, tg-Cyrl-TJ: Tacikistan
            Console.WriteLine ("K�lt�rBilgi ad�: {0}\t�ng.Ad�: {1}\tYerelAd�: {2}", ci.Name, ci.EnglishName, ci.NativeName);
            Console.WriteLine ("Akt�elK�lt�r ad�: {0}\t�ngiliceAd�: {1}\tYerelAd�: {2}",
                Thread.CurrentThread.CurrentUICulture.Name,
                Thread.CurrentThread.CurrentUICulture.EnglishName,
                Thread.CurrentThread.CurrentUICulture.NativeName);
            Thread.CurrentThread.CurrentCulture = ci;
            Console.WriteLine ("Akt�elK�lt�r ad�: {0}", Thread.CurrentThread.CurrentUICulture.Name);

            Console.WriteLine ("\nK�lt�rVeB�lgeB�lgeBilgiKurucu'yla kurulacak 'x-en-US-metric' testi:");
            RegionInfo ri;
            try {ri = new RegionInfo ("x-en-US-metric");
                Console.WriteLine ("RegionInfo(\"x-en-US-metric\") metrik midir? ", ri.IsMetric);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
/* using System.xxx olmad���ndan CultureAndRegionInfoBuilder ve CultureAndRegionModifiers hata vermekte
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

            Console.WriteLine ("\nK�lt�r bilgilerini akt�el dilden veya kimlikleyiciden sa�lama:");
            InputLanguage inL = InputLanguage.CurrentInputLanguage;
            ci = inL.Culture;
            Console.WriteLine ("\tK�lt�r kimlikleyici: {0}\n\tAd�n�G�ster: {1}\n\tTakvimi: {2}", ci, ci.DisplayName, ci.Calendar);
            ci = new CultureInfo ("tr-TR");
            Console.WriteLine ("K�lt�r kimlikleyici: {0}\nAd�n�G�ster: {1}\nTakvimi: {2}", ci, ci.DisplayName, ci.Calendar);

            Console.WriteLine ("\nK�lt�rlerde kabul g�ren k�yas i�aretleri ve sonu�lar�:");
            String[] i�aretler = new String[] {"<", "=", ">", "<=", ">=", "e�it"};
            String dzg1 = "�smail", dzg2 = "Zafer", dzg3 = "�smail";
            CompareInfo k�yas = new CultureInfo ("tr-TR").CompareInfo;
            Console.WriteLine ("-->{0} k�lt�r�n LCID no'su: {1}'d�r.", k�yas.Name, k�yas.LCID);
            Console.WriteLine ("({5}) i�in [{0} k�yas {1}]: {2}\t[{0} k�yas {3}]: {4}", dzg1, dzg2, i�aretler [k�yas.Compare (dzg1, dzg2) + 1], dzg3, i�aretler [k�yas.Compare (dzg1, dzg3) + 1], k�yas);
            k�yas = new CultureInfo ("en-US").CompareInfo;
            Console.WriteLine ("-->{0} k�lt�r�n LCID no'su: {1}'dir.", k�yas.Name, k�yas.LCID);
            Console.WriteLine ("({5}) i�in [{0} k�yas {1}]: {2}\t[{1} k�yas {3}]: {4}", dzg2, dzg1, i�aretler [k�yas.Compare (dzg2, dzg1) + 1], dzg3, i�aretler [k�yas.Compare (dzg1, dzg3) + 1], k�yas);

            Console.WriteLine ("\n�ki dizgenin genel k�lt�rde parametreli k�yaslanmalar�:");
            dzg1 = "Kek";
            dzg2 = "K";
            k�yas = CultureInfo.InvariantCulture.CompareInfo;
            Console.WriteLine ("Sonek, yal�n: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsSuffix (dzg1, dzg2));
            Console.WriteLine ("Sonek, None: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsSuffix (dzg1, dzg2, CompareOptions.None));
            Console.WriteLine ("Sonek, Ordinal: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsSuffix (dzg1, dzg2, CompareOptions.Ordinal));
            Console.WriteLine ("Sonek, IgnoreCase: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsSuffix (dzg1, dzg2, CompareOptions.IgnoreCase));
            Console.WriteLine ("\t�nek, yal�n: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsPrefix (dzg1, dzg2));
            Console.WriteLine ("\t�nek, None: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsPrefix (dzg1, dzg2, CompareOptions.None));
            Console.WriteLine ("\t�nek, Ordinal: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsPrefix (dzg1, dzg2, CompareOptions.Ordinal));
            Console.WriteLine ("\t�nek, IgnoreCase: [{0} k�yas {1}]? {2}", dzg1, dzg2, k�yas.IsPrefix (dzg1, dzg2, CompareOptions.IgnoreCase));

            Console.WriteLine ("\n�oklu kaynaklardan k�lt�re uygununun derlemede tercihi:");
            Application.Run (new K�lt�rB()); //Derleme: /resource:kaynak1.recourses

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}
/*
File: kaynak1.txt
#Varsay�l� k�lt�r kaynaklar�
WindowText = Uluslararas�la�t�rma
LabelText = Merhaba D�nya!!!
*/