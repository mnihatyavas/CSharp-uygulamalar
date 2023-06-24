// j2sc#0203.cs: Ýþaretli bayt ile çevrim ve kültürel biçimlemeler örneði.

using System;
using System.Globalization;
namespace VeriTipleri {
    class Sbyte {
        static void Main() {
            Console.Write ("'sbyte' iþaretli [-128, 127] tamsayýlarý kapsar. Belirtili (sbyte) gösterim taþan sayýlarý bu kapsama uyarlar. System.Globalization ile çeþitli ülke sayýsal biçimlemeleri farklarý görülebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            sbyte sb1, sb2; var r=new Random(); int ts1;
            Console.WriteLine ("sbyte: [enküçük, enbüyük] = [{0}, {1}]", sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine ("int={0}==> sbyte={1}\n", (ts1=r.Next (-1000, 1000)), (sb1 = (sbyte) ts1));

            CultureInfo[] kültürler = {
                    CultureInfo.CreateSpecificCulture ("en-US"), 
                    CultureInfo.CreateSpecificCulture ("fr-FR"), 
                    CultureInfo.CreateSpecificCulture ("es-ES"),
                    CultureInfo.CreateSpecificCulture ("tr-TR") };
            sb1 = (sbyte) r.Next (0, 1000);
            sb2 = (sbyte) -r.Next (0, 1000);
            string[] dizi = {"G", "C", "D6", "E2", "F", "N", "P", "X2"};
            foreach (string birim in dizi) {
                foreach (CultureInfo kültür in kültürler)
                    Console.WriteLine ("{0} kültürle biçimleme {1,2}: {2, 16} {3, 16}",
                            kültür, birim, sb1.ToString (birim, kültür), sb2.ToString (birim, kültür));
            }

            Console.WriteLine ("\n(sbyte = {0}) sayýsýnýn çeþitli biçimleniþleri:", sb1.ToString());
            Console.WriteLine ("Küsüratsýz: [{0}]", sb1.ToString ("G"));
            Console.WriteLine ("Para: [{0}]", sb1.ToString ("C", CultureInfo.CreateSpecificCulture ("en-US")));
            Console.WriteLine ("4 haneli: [{0}]", sb1.ToString ("D4"));
            Console.WriteLine ("Üslü: [{0}]", sb1.ToString ("E2"));
            Console.WriteLine ("5 küsüratlý: [{0}]", (sb1+0.123456789).ToString ("F5"));
            Console.WriteLine ("1 küsüratlý: [{0}]", (sb1+0.123456789).ToString ("N1"));
            Console.WriteLine ("Yüzde: [{0}]", sb1.ToString ("P"));
            Console.WriteLine ("Hexa: [{0}]", sb1.ToString ("X"));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}