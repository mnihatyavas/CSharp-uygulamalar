// j2sc#0106c.cs: Ýçiçe aduzamlý sýnýf armalý statik metotlar örneði.

using System;
using PenForm = System.Windows.Forms;
using AðForm = System.Web.UI.WebControls;
using ÞVTA = Þirket.BilgiÝþlem.VTArayüzü;
using ÞVT = Þirket.BilgiÝþlem.Veritabaný.Tablo;
namespace Þirket.BilgiÝþlem {
    public class VTArayüzü {
        public static void Aç() {Console.WriteLine ("Veritabaný açýlýyor...");}
    }
    namespace Veritabaný {
        public class Tablo {
            public static void Aç (string tabloAdý) {Console.WriteLine ("Açýlan tablo adý: {0}", tabloAdý);}
        }
    }
}
//namespace DilTemelleri {
    class Arma3 {
        static void Main() {
            Console.Write ("'System.Web.UI.WebControls' gibi uzun aduzam zinciri ve içiçe çoklu aduzamlý sýnýflarýn armalarý, tek bir adla çoklu kere çaðýrmalarý kolaylaþtýrmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("PenForm.Button tipi: {0}", typeof (PenForm.Button));
            Console.WriteLine ("AðForm.Button tipi: {0}\n", typeof (AðForm.Button));

            ÞVTA.Aç();
            ÞVT.Aç ("Dr.Hilal");
            ÞVT.Aç ("Amir Hostes Belkýs");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
//}