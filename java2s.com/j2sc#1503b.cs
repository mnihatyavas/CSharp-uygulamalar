// j2sc#1503b.cs: BinaryFormatter.Serialize/Deserialize, Path.GetTempFileName ve Path.GetRandomFileName �rne�i.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter i�in
using System.Collections; //ArrayList i�in
using System.Runtime.Serialization; //ISerializable, SerializationInfo, StreamingContext i�in
using System.Text; //StringBuilder i�in
namespace S�r�c�Dizin {
    [Serializable]
    class ��g�ren {
        private int no;
        private string isim;
        private float maa�;
        public ��g�ren (int n, string i, float m) {no = n; isim = i; maa�=m;} //Kurucu
        public void i�g�reniYaz() {Console.WriteLine ("no: {0}\tisim: {1}\tmaa�: {2:#,0.00} TL", no, isim, maa�);}
    }
    [Serializable]
    public class Eleman {
        string isim;
        [NonSerialized] //Bu de�er dosyaya yaz�lmaz (0)
        float maa�;
        public Eleman (string isim, float maa�) {this.isim = isim; this.maa� = maa�;} //Kurucu
        public override string ToString() {return (String.Format ("{0}: {1:#,0.00} TL", isim, maa�));}
    }
    [Serializable]
    public class Eleman2 {
        private string isim;
        private float maa�;
        public Eleman2 (string isim, float maa�) {this.isim = isim; this.maa�=maa�;}
        public override string ToString() {return (String.Format ("{0}: {1:#,0.00} TL", isim, maa�));}
    }
    [Serializable]
    public class ElemanListesi {
        ArrayList liste = new ArrayList();
        public void Ekle (Eleman2 elm) {liste.Add (elm);}
        public override string ToString() {
            string arac� = null;
            foreach (Eleman2 elm in liste) arac� += elm.ToString() + "\n";
            return (arac�);
        }
    }
    [Serializable]
    public class Adres : ISerializable {
        private string isim;
        private int ya�;
        private string adres;
        public Adres (string i, int y, string a) {isim = i; ya� = y; adres = a;}
        private Adres (SerializationInfo bilgi, StreamingContext i�erik) {
            isim = bilgi.GetString ("�sim");
            ya� = bilgi.GetInt32 ("Ya�");
            adres = bilgi.GetString ("Adres");
        }
        public void GetObjectData (SerializationInfo blg, StreamingContext i�rk) {
            blg.AddValue ("�sim", isim);
            blg.AddValue ("Ya�", ya�);
            blg.AddValue ("Adres", adres);
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat ("�sim: {0}\t", isim);
            sb.AppendFormat ("Ya�: {0}\t", ya�);
            sb.AppendFormat ("Adres: {0}", adres);
            return sb.ToString();
        }
    }
    class Serile�tirmeB {
        static void Main() {
            Console.Write ("BinaryFormatter bf.Serialize(stream,kay�t)'la serile�tirilen kayd� stream dosyaya yazar ve kay�t=(Kay�tS�n�f)bf.Deserialize(stream) ak�� dosyas�ndan bir tiplemeli kayd� serisizle�tirerek okur (ekrana sunar).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("i�g�ren.dat'a BinaryFormatter'la 5 i�g�ren yazma ve okuma:");
            float f; var r=new Random();
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ��g�ren i�g = new ��g�ren (1, "M.Nihat Yava�", f);
            FileStream fs = new FileStream ("i�g�ren.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize (fs, i�g);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; i�g = new ��g�ren (2, "Zafer N.Candan", f); bf.Serialize (fs, i�g);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; i�g = new ��g�ren (3, "Atilla G�kt�rk", f); bf.Serialize (fs, i�g);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; i�g = new ��g�ren (4, "Hamza Candan", f); bf.Serialize (fs, i�g);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; i�g = new ��g�ren (5, "Nihat Ka�ar", f); bf.Serialize (fs, i�g);
            fs.Flush(); fs.Close();
            Console.WriteLine ("==>5 kayd� dosyaya yazd�");
            fs = new FileStream ("i�g�ren.dat", FileMode.Open);
            try {while(true) {i�g = (��g�ren) bf.Deserialize (fs); i�g.i�g�reniYaz();}}catch{}
            fs.Close();

            Console.WriteLine ("\n[NonSerialized]maa� kayd� dosyaya yaz�lmaz, 0 okunur:");
            Stream s = File.Create ("eleman.bin");
            f=r.Next(10000,100000)+r.Next(10,100)/100f; Eleman ele = new Eleman ("M.Nihat Yava�", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Zafer N.Candan", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Atilla G�kt�rk", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Hamza Candan", f); bf.Serialize (s, ele);
            f=r.Next(10000,100000)+r.Next(10,100)/100f; ele = new Eleman ("Nihat Ka�ar", f); bf.Serialize (s, ele);
            s.Flush(); s.Close();
            Console.WriteLine ("==>5 kayd� dosyaya yazd�");
            s = File.OpenRead ("eleman.bin");
            try {while(true) {ele = (Eleman) bf.Deserialize (s); Console.WriteLine ("{0}", ele);}}catch{}
            s.Close();
       
            Console.WriteLine ("\nArrayList'i 'eleman2.bin'e yazma ve okuma:");
            ElemanListesi liste = new ElemanListesi();
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("M.Nihat Yava�", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Zafer N.Candan", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Atilla G�kt�rk", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Hamza Candan", f));
            f=r.Next(10000,100000)+r.Next(10,100)/100f; liste.Ekle (new Eleman2 ("Nihat Ka�ar", f));
            s = File.Create ("eleman2.bin");
            bf = new BinaryFormatter();
            bf.Serialize (s, liste);
            s.Close();
            Console.WriteLine ("==>5 kayd� dosyaya yazd�");
            s = File.OpenRead ("eleman2.bin");
            bf = new BinaryFormatter();
            liste = (ElemanListesi) bf.Deserialize (s);
            s.Close();
            Console.WriteLine ("{0}", liste);

            Console.WriteLine ("Adres kay�tlar�n�n 'adres.bin'e yaz�l�p okunmas�:");
            s = File.Create ("adres.bin");
            bf = new BinaryFormatter();
            bf.Context = new StreamingContext (StreamingContextStates.CrossAppDomain);
            Adres birAdres = new Adres ("M.Nihat Yava�", 2024-1957, "Toroslar - Mersin"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Zafer N.Candan", 2024-1976, "Bak�rk�y - �stanbul"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Atilla G�kt�rk", 2024-1982, "Ku�adas� - Ayd�n"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Hamza Candan", 2024-1947, "Ye�ilyurt - Malatya"); bf.Serialize (s, birAdres);
            birAdres = new Adres ("Nihat Ka�ar", 2024-1937, "F.S.Mehmet - Bursa"); bf.Serialize (s, birAdres);
            s.Close();
            Console.WriteLine ("==>5 kayd� dosyaya yazd�");
            s = File.OpenRead ("adres.bin");
            bf = new BinaryFormatter();
            try {while(true) {birAdres = (Adres) bf.Deserialize (s); Console.WriteLine (birAdres);}}catch{}
            s.Close();

            Console.WriteLine ("\nGe�ici tmpXXXX dosyaya veri yazma, okuma ve silme:");
            string tmpDosya = Path.GetTempFileName();
            int i;
            Console.WriteLine ("Kullan�lan ge�ici dosya: [{0}]", tmpDosya);
            using (fs = new FileStream (tmpDosya, FileMode.Open)) {
                for(i=65;i<65+26;i++)fs.WriteByte ((Byte)i);
                fs.Position = 0;
                while ((i=fs.ReadByte()) != -1) Console.Write ("{0}={1} ", i, (char)i);
            }
            File.Delete (tmpDosya); Console.WriteLine ("\n==>Ge�ici tmpDosya silindi");

            Console.WriteLine ("\nRasgele xxxxxxxx.xxx dosyaya veri yazma, okuma ve silme:");
            string rasgeleDosya = Path.GetRandomFileName();
            Console.WriteLine ("Kullan�lan rasgele dosya: [{0}]", rasgeleDosya);
            using (fs = new FileStream (rasgeleDosya, FileMode.Create)) {
                for(i=97;i<97+26;i++)fs.WriteByte ((Byte)i);
                fs.Position = 0;
                while ((i=fs.ReadByte()) != -1) Console.Write ("{0}={1} ", i, (char)i);
            }
            File.Delete (rasgeleDosya); Console.WriteLine ("\n==>Ge�ici rasgeleDosya silindi");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}