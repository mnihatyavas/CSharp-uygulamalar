// j2sc#1503b.cs: BinaryFormatter.Serialize/Deserialize, Path.GetTempFileName ve Path.GetRandomFileName örneði.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter için
using System.Collections; //ArrayList için
using System.Runtime.Serialization; //ISerializable, SerializationInfo, StreamingContext için
using System.Text; //StringBuilder için
namespace SürücüDizin {
    [Serializable]
    class Ýþgören {
        private int no;
        private string isim;
        private float maaþ;
        public Ýþgören (int n, string i, float m) {no = n; isim = i; maaþ=m;} //Kurucu
        public void iþgöreniYaz() {Console.WriteLine ("no: {0}\tisim: {1}\tmaaþ: {2:#,0.00} TL", no, isim, maaþ);}
    }
    [Serializable]
    public class Eleman {
        string isim;
        [NonSerialized] //Bu deðer dosyaya yazýlmaz (0)
        float maaþ;
        public Eleman (string isim, float maaþ) {this.isim = isim; this.maaþ = maaþ;} //Kurucu
        public override string ToString() {return (String.Format ("{0}: {1:#,0.00} TL", isim, maaþ));}
    }
    [Serializable]
    public class Eleman2 {
        private string isim;
        private float maaþ;
        public Eleman2 (string isim, float maaþ) {this.isim = isim; this.maaþ=maaþ;}
        public override string ToString() {return (String.Format ("{0}: {1:#,0.00} TL", isim, maaþ));}
    }
    [Serializable]
    public class ElemanListesi {
        ArrayList liste = new ArrayList();
        public void Ekle (Eleman2 elm) {liste.Add (elm);}
        public override string ToString() {
            string aracý = null;
            foreach (Eleman2 elm in liste) aracý += elm.ToString() + "\n";
            return (aracý);
        }
    }
    [Serializable]
    public class Adres : ISerializable {
        private string isim;
        private int yaþ;
        private string adres;
        public Adres (string i, int y, string a) {isim = i; yaþ = y; adres = a;}
        private Adres (SerializationInfo bilgi, StreamingContext içerik) {
            isim = bilgi.GetString ("Ýsim");
            yaþ = bilgi.GetInt32 ("Yaþ");
            adres = bilgi.GetString ("Adres");
        }
        public void GetObjectData (SerializationInfo blg, StreamingContext içrk) {
            blg.AddValue ("Ýsim", isim);
            blg.AddValue ("Yaþ", yaþ);
            blg.AddValue ("Adres", adres);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("Ýsim: {0}\t", isim);
            sb.AppendFormat ("Yaþ: {0}\t", yaþ);
            sb.AppendFormat ("Adres: {0}", adres);
            return sb.ToString();
        }
    }
    class SerileþtirmeB {
        static void Main() {
            Console.Write ("BinaryFormatter bf.Serialize(stream,kayýt)'la serileþtirilen kaydý stream dosyaya yazar ve kayýt=(KayýtSýnýf)bf.Deserialize(stream) akýþ dosyasýndan bir tiplemeli kaydý serisizleþtirerek okur (ekrana sunar).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("iþgören.dat'a BinaryFormatter'la 5 iþgören yazma ve okuma:");
            float f; var r=new Random();
            f=r.Next(10000,100000)+r.Next(10,100)/100f; Ýþgören iþg = new Ýþgören (1, "M.Nihat Yavaþ", f);
            FileStream fs = new FileStream ("iþgören.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize (fs, iþg);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; iþg = new Ýþgören (2, "Zafer N.Candan", f); bf.Serialize (fs, iþg);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; iþg = new Ýþgören (3, "Atilla Göktürk", f); bf.Serialize (fs, iþg);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; iþg = new Ýþgören (4, "Hamza Candan", f); bf.Serialize (fs, iþg);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; iþg = new Ýþgören (5, "Nihat Kaçar", f); bf.Serialize (fs, iþg);
            fs.Flush(); fs.Close();
            Console.WriteLine ("==>5 kaydý dosyaya yazdý");
            fs = new FileStream ("iþgören.dat", FileMode.Open);
            try {while(true) {iþg = (Ýþgören) bf.Deserialize (fs); iþg.iþgöreniYaz();}}catch{}
            fs.Close();

            Console.WriteLine ("\n[NonSerialized]maaþ kaydý dosyaya yazýlmaz, 0 okunur:");
            Stream s = File.Create ("eleman.bin");
            f=r.Next(10000,100000)+r.Next(10,100)/100f; Eleman ele = new Eleman ("M.Nihat Yavaþ", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Zafer N.Candan", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Atilla Göktürk", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Hamza Candan", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Nihat Kaçar", f); bf.Serialize (s, ele);
            s.Flush(); s.Close();
            Console.WriteLine ("==>5 kaydý dosyaya yazdý");
            s = File.OpenRead ("eleman.bin");
            try {while(true) {ele = (Eleman) bf.Deserialize (s); Console.WriteLine ("{0}", ele);}}catch{}
            s.Close();
       
            Console.WriteLine ("\nArrayList'i 'eleman2.bin'e yazma ve okuma:");
            ElemanListesi liste = new ElemanListesi();
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("M.Nihat Yavaþ", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Zafer N.Candan", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Atilla Göktürk", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Hamza Candan", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Nihat Kaçar", f));
            s = File.Create ("eleman2.bin");
            bf = new BinaryFormatter();
            bf.Serialize (s, liste);
            s.Close();
            Console.WriteLine ("==>5 kaydý dosyaya yazdý");
            s = File.OpenRead ("eleman2.bin");
            bf = new BinaryFormatter();
            liste = (ElemanListesi) bf.Deserialize (s);
            s.Close();
            Console.WriteLine ("{0}", liste);

            Console.WriteLine ("Adres kayýtlarýnýn 'adres.bin'e yazýlýp okunmasý:");
            s = File.Create ("adres.bin");
            bf = new BinaryFormatter();
            bf.Context = new StreamingContext (StreamingContextStates.CrossAppDomain);
            Adres birAdres = new Adres ("M.Nihat Yavaþ", 2024-1957, "Toroslar - Mersin"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Zafer N.Candan", 2024-1976, "Bakýrköy - Ýstanbul"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Atilla Göktürk", 2024-1982, "Kuþadasý - Aydýn"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Hamza Candan", 2024-1947, "Yeþilyurt - Malatya"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Nihat Kaçar", 2024-1937, "F.S.Mehmet - Bursa"); bf.Serialize (s, birAdres);
            s.Close();
            Console.WriteLine ("==>5 kaydý dosyaya yazdý");
            s = File.OpenRead ("adres.bin");
            bf = new BinaryFormatter();
            try {while(true) {birAdres = (Adres) bf.Deserialize (s); Console.WriteLine (birAdres);}}catch{}
            s.Close();

            Console.WriteLine ("\nGeçici tmpXXXX dosyaya veri yazma, okuma ve silme:");
            string tmpDosya = Path.GetTempFileName();
            int i;
            Console.WriteLine ("Kullanýlan geçici dosya: [{0}]", tmpDosya);
            using (fs = new FileStream (tmpDosya, FileMode.Open)) {
                for(i=65;i<65+26;i++)fs.WriteByte ((Byte)i);
                fs.Position = 0;
                while ((i=fs.ReadByte()) != -1) Console.Write ("{0}={1} ", i, (char)i);
            }
            File.Delete (tmpDosya); Console.WriteLine ("\n==>Geçici tmpDosya silindi");

            Console.WriteLine ("\nRasgele xxxxxxxx.xxx dosyaya veri yazma, okuma ve silme:");
            string rasgeleDosya = Path.GetRandomFileName();
            Console.WriteLine ("Kullanýlan rasgele dosya: [{0}]", rasgeleDosya);
            using (fs = new FileStream (rasgeleDosya, FileMode.Create)) {
                for(i=97;i<97+26;i++)fs.WriteByte ((Byte)i);
                fs.Position = 0;
                while ((i=fs.ReadByte()) != -1) Console.Write ("{0}={1} ", i, (char)i);
            }
            File.Delete (rasgeleDosya); Console.WriteLine ("\n==>Geçici rasgeleDosya silindi");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}