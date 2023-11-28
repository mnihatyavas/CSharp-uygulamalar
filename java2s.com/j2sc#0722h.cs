// j2sc#0722h.cs: IFormattable þablonla gösterim biçemlerini özelleþtirme örneði.

using System;
using System.Text; //StringBuilder için
using System.Globalization; //CultureInfo için
namespace Sýnýflar {
    public class KompleksBiçimleyici : ICustomFormatter, IFormatProvider {
        public object GetFormat (Type biçemTipi) {//System.IFormatProvider.GetFormat(System.Type)
            if (biçemTipi == typeof (ICustomFormatter)) {return this;}
            else {return CultureInfo.CurrentCulture.GetFormat (biçemTipi);}
        }
        public string Format (string biçem, object argüman, IFormatProvider biçemTedarikci ) {//System.ICustomFormatter.Format(string, object, System.IFormatProvider)
            if (argüman.GetType() == typeof (KompleksSayý) && biçem == "DBG") {
                KompleksSayý ks = (KompleksSayý) argüman;
                StringBuilder sb = new StringBuilder();
                sb.Append (argüman.GetType().ToString() + " " );
                sb.AppendFormat ("Gerçel: {0} ", ks.Gerçel);
                sb.AppendFormat ("Sanal: {0} ", ks.Sanal);
                return sb.ToString();}
            else {
                IFormattable biçimlenebilir = argüman as IFormattable;
                if (biçimlenebilir != null ) {return biçimlenebilir.ToString (biçem, biçemTedarikci);}
                else {return argüman.ToString();}}
        }
    }
    public struct KompleksSayý : IFormattable {
        public double Gerçel, Sanal;
        public KompleksSayý (double Gerçel, double Sanal) {this.Gerçel = Gerçel; this.Sanal = Sanal;} //Kurucu
        public string ToString (string biçem, IFormatProvider biçemTedarikci ) {
            StringBuilder sb = new StringBuilder();
            sb.Append ("(" + Gerçel.ToString (biçem, biçemTedarikci));
            sb.Append (" : " + Sanal.ToString(biçem, biçemTedarikci));
            sb.Append (")");
            return sb.ToString();
        }
    }
    public class MüþteriBiçemci : IFormatProvider, ICustomFormatter {
        public object GetFormat (Type biçemTipi) {
            if (biçemTipi == typeof (ICustomFormatter)) return this; 
            else return null;
        }
        public string Format (string biçem, object argüman, IFormatProvider biçemTedarikci) {
            if (!this.Equals (biçemTedarikci)) {return null;}
            else {
                if (String.IsNullOrEmpty (biçem)) biçem = "G";
                string müþteriDizgesi = argüman.ToString();
                if (müþteriDizgesi.Length < 8) müþteriDizgesi = müþteriDizgesi.PadLeft (8, '0');
                biçem = biçem.ToUpper();
                switch (biçem) {
                    case "G": return müþteriDizgesi.Substring (0, 1) + "-" + müþteriDizgesi.Substring (1, 5) + "-" + müþteriDizgesi.Substring (6);
                    default: throw new FormatException (String.Format ("'{0}' biçem belirteci desteklenmiyor.", biçem));
                }
            }
        }
    }
    struct Vektör : IFormattable {
        public double x, y, z;
        public Vektör (double x, double y, double z) {this.x = x; this.y = y; this.z = z;}
        public string ToString (string biçem, IFormatProvider biçemTedarikci) {
            if (biçem == null) return ToString();
            string biçemBykHrf = biçem.ToUpper();
            switch (biçemBykHrf) {
                case "N": return "[" + Norm().ToString() + "]";
                case "VE": return String.Format ("({0:E}, {1:E}, {2:E})", x, y, z);
                case "IJK": StringBuilder sb = new StringBuilder (x.ToString(), 20);
                                sb.Append (" i + ");
                                sb.Append (y.ToString());
                                sb.Append (" j + ");
                                sb.Append (z.ToString());
                                sb.Append (" k");
                            return sb.ToString();
                default: return ToString();
            }
        }
        public Vektör (Vektör saða) {x = saða.x; y = saða.y; z = saða.z;}
        public override string ToString() {return "( " + x + " , " + y + " , " + z + " )";}
        public double this [uint i] {
            get {
                switch (i) {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException ("Eriþilmeye teþebbüs edilen Vektör elemaný: " + i);
                }
            }
            set {
                switch (i) {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException ("Eriþilmeye teþebbüs edilen Vektör elemaný: " + i);
                }
            }
        }
        private const double Epsilon = 0.0000001;
        public static bool operator == (Vektör sola, Vektör saða) {
            if (Math.Abs (sola.x - saða.x) < Epsilon && Math.Abs (sola.y - saða.y) < Epsilon && Math.Abs (sola.z - saða.z) < Epsilon) return true;
            else return false;
        }
        public static bool operator != (Vektör sola, Vektör saða) {return !(sola == saða);}
        public static Vektör operator + (Vektör sola, Vektör saða) {
            Vektör sonuç = new Vektör (sola);
            sonuç.x += saða.x;
            sonuç.y += saða.y;
            sonuç.z += saða.z;
            return sonuç;
        }
        public static Vektör operator * (double sola, Vektör saða) {return new Vektör (sola * saða.x, sola * saða.y, sola * saða.z);}
        public static Vektör operator * (Vektör sola, double saða) {return saða * sola;}
        public static double operator * (Vektör sola, Vektör saða) {return sola.x * saða.x + sola.y + saða.y + sola.z * saða.z;}
        public double Norm() {return (x * x + y * y + z * z);}
        public override bool Equals (object o){return false;}
        public override int GetHashCode(){return 0;}
    }
    public class Kiþiler : IFormattable {
        private string hitap;
        private string[] adlar;
        public Kiþiler (string hitap, params string[] adlar) {this.hitap = hitap; this.adlar = adlar;}
        public override string ToString() {return ToString ("G", null);}
        public string ToString (string biçem, IFormatProvider biçemTedarikci) {
            string sonuç = null;
            if (biçem == null) biçem = "G";
            switch (biçem.ToUpper() [0]) {
                case 'S': sonuç = adlar [0][0] + "." + adlar [adlar.Length - 1]; break;
                case 'P': if (hitap != null && hitap.Length != 0) {sonuç = hitap + " " + adlar [1];} break;
                case 'I': sonuç = adlar [2]; break;
                case 'G': sonuç = hitap + " " + adlar [0][0] + "." + adlar [adlar.Length - 1]; break;
                default: sonuç = adlar [0] + " ve " + adlar [adlar.Length - 1]; break;
            }
            return sonuç;
        }
    }
    class Çeþitli8 {
        static void Main() {
            Console.Write ("ICustomFormatter, IFormatProvider, IFormattable ve CultureInfo.CurrentCulture.GetFormat özel kompleks/vektörel sayýsal ve dizgesel gösterimler sunmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Lokal, türkiye ve DBG biçemli kompleks sayý gösterimleri:");
            CultureInfo yerelKültür = CultureInfo.CurrentCulture;
            CultureInfo türkiye = new CultureInfo ("tr-TR");
            KompleksSayý ks; var r=new Random(); double ds1, ds2, ds3; int ts1, ts2, ts3, i;
            KompleksBiçimleyici dbgBiçimleyici = new KompleksBiçimleyici();
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(1000,10000)/10000D; ds2=r.Next(-100,100)+r.Next(1000,10000)/10000D;
                ks = new KompleksSayý (ds1, ds2);
                string sks = ks.ToString ("F", yerelKültür);
                Console.Write ("F-lokal biçem = {0}", sks);
                sks = ks.ToString ("F", türkiye);
                Console.WriteLine ("\tF-türkiye biçem = {0}", sks);
                sks = String.Format (dbgBiçimleyici,"{0:DBG}",  ks);
                Console.WriteLine (" Hataayýklayýcý biçem = {0}", sks);
            }


            Console.WriteLine ("\n0 ve 0:G biçemlerinin MüþNo'yu özel G dizgesiyle biçimlemesi:");
            for(i=0;i<5;i++) {
                ts1=r.Next(10000000,100000000);
                int müþHesNo = ts1;
                Console.Write ("[{0}] müþno biçemleri: ", ts1);
                Console.Write ("0 biçem [{0}], ", String.Format (new MüþteriBiçemci(), "{0}", müþHesNo));
                Console.Write ("0:G biçem [{0}], ", String.Format (new MüþteriBiçemci(), "{0:G}", müþHesNo));
                try {Console.WriteLine ("0:X biçem [{0}]", String.Format (new MüþteriBiçemci(), "{0:X}", müþHesNo));
                }catch (FormatException h) {Console.WriteLine ("\n\tHATA: [{0}]", h.Message);}
            }

            Console.WriteLine ("\nVektörel deðerlerin sade, (i,j,k)'li, bilimsel ve [Norm] gösterimi:");
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); 
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D;
                Vektör v1 = new Vektör (ts1, ts2, ts3);
                Vektör v2 = new Vektör (ds1, ds2, ds3);
                Console.WriteLine ("{0,30:IJK}\t{1,30:IJK}", v1, v2);
                Console.WriteLine ("{0,30}\t{1,30}", v1, v2);
                Console.WriteLine ("{0,60:VE}\n{1,60:VE}", v1, v2);
                Console.WriteLine ("{0,25:N}\t{1,25:N}", v1, v2);
            }

            Console.WriteLine ("\nIFormattable'la özel G, P, I, S, varsayýlý biçimleme sonuçlarý:");
            Kiþiler k = new Kiþiler ("Sayýn", "Nihat Yavaþ", "Canan Candan", "Nur Küçükbay", "Zafer Candan");
            Console.WriteLine ("{0:G}\n{0:P}\n{0:I}\n{0}\n{0:S}", k);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}