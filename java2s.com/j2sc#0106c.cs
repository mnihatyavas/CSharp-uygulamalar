// j2sc#0106c.cs: ��i�e aduzaml� s�n�f armal� statik metotlar �rne�i.

using System;
using PenForm = System.Windows.Forms;
using A�Form = System.Web.UI.WebControls;
using �VTA = �irket.Bilgi��lem.VTAray�z�;
using �VT = �irket.Bilgi��lem.Veritaban�.Tablo;
namespace �irket.Bilgi��lem {
    public class VTAray�z� {
        public static void A�() {Console.WriteLine ("Veritaban� a��l�yor...");}
    }
    namespace Veritaban� {
        public class Tablo {
            public static void A� (string tabloAd�) {Console.WriteLine ("A��lan tablo ad�: {0}", tabloAd�);}
        }
    }
}
//namespace DilTemelleri {
    class Arma3 {
        static void Main() {
            Console.Write ("'System.Web.UI.WebControls' gibi uzun aduzam zinciri ve i�i�e �oklu aduzaml� s�n�flar�n armalar�, tek bir adla �oklu kere �a��rmalar� kolayla�t�rmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("PenForm.Button tipi: {0}", typeof (PenForm.Button));
            Console.WriteLine ("A�Form.Button tipi: {0}\n", typeof (A�Form.Button));

            �VTA.A�();
            �VT.A� ("Dr.Hilal");
            �VT.A� ("Amir Hostes Belk�s");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
//}