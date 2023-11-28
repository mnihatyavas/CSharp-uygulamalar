// j2sc#0722h.cs: IFormattable �ablonla g�sterim bi�emlerini �zelle�tirme �rne�i.

using System;
using System.Text; //StringBuilder i�in
using System.Globalization; //CultureInfo i�in
namespace S�n�flar {
    public class KompleksBi�imleyici : ICustomFormatter, IFormatProvider {
        public object GetFormat (Type bi�emTipi) {//System.IFormatProvider.GetFormat(System.Type)
            if (bi�emTipi == typeof (ICustomFormatter)) {return this;}
            else {return CultureInfo.CurrentCulture.GetFormat (bi�emTipi);}
        }
        public string Format (string bi�em, object arg�man, IFormatProvider bi�emTedarikci ) {//System.ICustomFormatter.Format(string, object, System.IFormatProvider)
            if (arg�man.GetType() == typeof (KompleksSay�) && bi�em == "DBG") {
                KompleksSay� ks = (KompleksSay�) arg�man;
                StringBuilder sb = new StringBuilder();
                sb.Append (arg�man.GetType().ToString() + " " );
                sb.AppendFormat ("Ger�el: {0} ", ks.Ger�el);
                sb.AppendFormat ("Sanal: {0} ", ks.Sanal);
                return sb.ToString();}
            else {
                IFormattable bi�imlenebilir = arg�man as IFormattable;
                if (bi�imlenebilir != null ) {return bi�imlenebilir.ToString (bi�em, bi�emTedarikci);}
                else {return arg�man.ToString();}}
        }
    }
    public struct KompleksSay� : IFormattable {
        public double Ger�el, Sanal;
        public KompleksSay� (double Ger�el, double Sanal) {this.Ger�el = Ger�el; this.Sanal = Sanal;} //Kurucu
        public string ToString (string bi�em, IFormatProvider bi�emTedarikci ) {
            StringBuilder sb = new StringBuilder();
            sb.Append ("(" + Ger�el.ToString (bi�em, bi�emTedarikci));
            sb.Append (" : " + Sanal.ToString(bi�em, bi�emTedarikci));
            sb.Append (")");
            return sb.ToString();
        }
    }
    public class M��teriBi�emci : IFormatProvider, ICustomFormatter {
        public object GetFormat (Type bi�emTipi) {
            if (bi�emTipi == typeof (ICustomFormatter)) return this; 
            else return null;
        }
        public string Format (string bi�em, object arg�man, IFormatProvider bi�emTedarikci) {
            if (!this.Equals (bi�emTedarikci)) {return null;}
            else {
                if (String.IsNullOrEmpty (bi�em)) bi�em = "G";
                string m��teriDizgesi = arg�man.ToString();
                if (m��teriDizgesi.Length < 8) m��teriDizgesi = m��teriDizgesi.PadLeft (8, '0');
                bi�em = bi�em.ToUpper();
                switch (bi�em) {
                    case "G": return m��teriDizgesi.Substring (0, 1) + "-" + m��teriDizgesi.Substring (1, 5) + "-" + m��teriDizgesi.Substring (6);
                    default: throw new FormatException (String.Format ("'{0}' bi�em belirteci desteklenmiyor.", bi�em));
                }
            }
        }
    }
    struct Vekt�r : IFormattable {
        public double x, y, z;
        public Vekt�r (double x, double y, double z) {this.x = x; this.y = y; this.z = z;}
        public string ToString (string bi�em, IFormatProvider bi�emTedarikci) {
            if (bi�em == null) return ToString();
            string bi�emBykHrf = bi�em.ToUpper();
            switch (bi�emBykHrf) {
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
        public Vekt�r (Vekt�r sa�a) {x = sa�a.x; y = sa�a.y; z = sa�a.z;}
        public override string ToString() {return "( " + x + " , " + y + " , " + z + " )";}
        public double this [uint i] {
            get {
                switch (i) {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException ("Eri�ilmeye te�ebb�s edilen Vekt�r eleman�: " + i);
                }
            }
            set {
                switch (i) {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException ("Eri�ilmeye te�ebb�s edilen Vekt�r eleman�: " + i);
                }
            }
        }
        private const double Epsilon = 0.0000001;
        public static bool operator == (Vekt�r sola, Vekt�r sa�a) {
            if (Math.Abs (sola.x - sa�a.x) < Epsilon && Math.Abs (sola.y - sa�a.y) < Epsilon && Math.Abs (sola.z - sa�a.z) < Epsilon) return true;
            else return false;
        }
        public static bool operator != (Vekt�r sola, Vekt�r sa�a) {return !(sola == sa�a);}
        public static Vekt�r operator + (Vekt�r sola, Vekt�r sa�a) {
            Vekt�r sonu� = new Vekt�r (sola);
            sonu�.x += sa�a.x;
            sonu�.y += sa�a.y;
            sonu�.z += sa�a.z;
            return sonu�;
        }
        public static Vekt�r operator * (double sola, Vekt�r sa�a) {return new Vekt�r (sola * sa�a.x, sola * sa�a.y, sola * sa�a.z);}
        public static Vekt�r operator * (Vekt�r sola, double sa�a) {return sa�a * sola;}
        public static double operator * (Vekt�r sola, Vekt�r sa�a) {return sola.x * sa�a.x + sola.y + sa�a.y + sola.z * sa�a.z;}
        public double Norm() {return (x * x + y * y + z * z);}
        public override bool Equals (object o){return false;}
        public override int GetHashCode(){return 0;}
    }
    public class Ki�iler : IFormattable {
        private string hitap;
        private string[] adlar;
        public Ki�iler (string hitap, params string[] adlar) {this.hitap = hitap; this.adlar = adlar;}
        public override string ToString() {return ToString ("G", null);}
        public string ToString (string bi�em, IFormatProvider bi�emTedarikci) {
            string sonu� = null;
            if (bi�em == null) bi�em = "G";
            switch (bi�em.ToUpper() [0]) {
                case 'S': sonu� = adlar [0][0] + "." + adlar [adlar.Length - 1]; break;
                case 'P': if (hitap != null && hitap.Length != 0) {sonu� = hitap + " " + adlar [1];} break;
                case 'I': sonu� = adlar [2]; break;
                case 'G': sonu� = hitap + " " + adlar [0][0] + "." + adlar [adlar.Length - 1]; break;
                default: sonu� = adlar [0] + " ve " + adlar [adlar.Length - 1]; break;
            }
            return sonu�;
        }
    }
    class �e�itli8 {
        static void Main() {
            Console.Write ("ICustomFormatter, IFormatProvider, IFormattable ve CultureInfo.CurrentCulture.GetFormat �zel kompleks/vekt�rel say�sal ve dizgesel g�sterimler sunmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Lokal, t�rkiye ve DBG bi�emli kompleks say� g�sterimleri:");
            CultureInfo yerelK�lt�r = CultureInfo.CurrentCulture;
            CultureInfo t�rkiye = new CultureInfo ("tr-TR");
            KompleksSay� ks; var r=new Random(); double ds1, ds2, ds3; int ts1, ts2, ts3, i;
            KompleksBi�imleyici dbgBi�imleyici = new KompleksBi�imleyici();
            for(i=0;i<5;i++) {
                ds1=r.Next(-100,100)+r.Next(1000,10000)/10000D; ds2=r.Next(-100,100)+r.Next(1000,10000)/10000D;
                ks = new KompleksSay� (ds1, ds2);
                string sks = ks.ToString ("F", yerelK�lt�r);
                Console.Write ("F-lokal bi�em = {0}", sks);
                sks = ks.ToString ("F", t�rkiye);
                Console.WriteLine ("\tF-t�rkiye bi�em = {0}", sks);
                sks = String.Format (dbgBi�imleyici,"{0:DBG}",  ks);
                Console.WriteLine (" Hataay�klay�c� bi�em = {0}", sks);
            }


            Console.WriteLine ("\n0 ve 0:G bi�emlerinin M��No'yu �zel G dizgesiyle bi�imlemesi:");
            for(i=0;i<5;i++) {
                ts1=r.Next(10000000,100000000);
                int m��HesNo = ts1;
                Console.Write ("[{0}] m��no bi�emleri: ", ts1);
                Console.Write ("0 bi�em [{0}], ", String.Format (new M��teriBi�emci(), "{0}", m��HesNo));
                Console.Write ("0:G bi�em [{0}], ", String.Format (new M��teriBi�emci(), "{0:G}", m��HesNo));
                try {Console.WriteLine ("0:X bi�em [{0}]", String.Format (new M��teriBi�emci(), "{0:X}", m��HesNo));
                }catch (FormatException h) {Console.WriteLine ("\n\tHATA: [{0}]", h.Message);}
            }

            Console.WriteLine ("\nVekt�rel de�erlerin sade, (i,j,k)'li, bilimsel ve [Norm] g�sterimi:");
            for(i=0;i<5;i++) {
                ts1=r.Next(-100,100); ts2=r.Next(-100,100); ts3=r.Next(-100,100); 
                ds1=r.Next(-100,100)+r.Next(10,100)/100D; ds2=r.Next(-100,100)+r.Next(10,100)/100D; ds3=r.Next(-100,100)+r.Next(10,100)/100D;
                Vekt�r v1 = new Vekt�r (ts1, ts2, ts3);
                Vekt�r v2 = new Vekt�r (ds1, ds2, ds3);
                Console.WriteLine ("{0,30:IJK}\t{1,30:IJK}", v1, v2);
                Console.WriteLine ("{0,30}\t{1,30}", v1, v2);
                Console.WriteLine ("{0,60:VE}\n{1,60:VE}", v1, v2);
                Console.WriteLine ("{0,25:N}\t{1,25:N}", v1, v2);
            }

            Console.WriteLine ("\nIFormattable'la �zel G, P, I, S, varsay�l� bi�imleme sonu�lar�:");
            Ki�iler k = new Ki�iler ("Say�n", "Nihat Yava�", "Canan Candan", "Nur K���kbay", "Zafer Candan");
            Console.WriteLine ("{0:G}\n{0:P}\n{0:I}\n{0}\n{0:S}", k);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}