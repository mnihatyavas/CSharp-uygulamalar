// j2sc#1503a.cs: Verileri dosyaya serileþtirip ikili veya xml biçemde yazma örneði.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter için
using System.Runtime.Serialization;//IFormatter için
using System.Collections.Generic; //List<T> için
using System.Runtime.Serialization.Formatters.Soap; //SoapFormatter için
namespace SürücüDizin {
    [Serializable()] //Gerekli
    class Nokta {
        public int xNokta, yNokta;
    }
    [Serializable]
    public class Ürün {
        public long kod;
        public string ad;
        public double fiyat;
        //[NonSerialized] //notlar okunmaz
        string notlar;
        public Ürün (long k, string a, double f, string n) {//Kurucu
            kod = k; ad = a; fiyat = f; notlar = n;
        }
        public override string ToString() {return string.Format ("{0}: {1} ({2:F2} TL) {3}", kod, ad, fiyat, notlar);}
    }
    [Serializable]
    public class Kiþi {
        public string ad {get; set;}
        public int yaþ, boy, kilo;
        public Kiþi(){} //Kurucu
    }
    [Serializable]
    class Veriler {
        public string v1 = "M.Nihat Yavaþ", v2 = "Sevim Yavaþ", v3 = "Songül Yavaþ Gökyiðit", v4 = "Süheyla Yavaþ Özbay", v5 = "Haným Emanet Yavaþ";
        [OnSerializing]
        private void OnSerializing (StreamingContext içerik) {
            v1 = v1.ToUpper(); v2 = v2.ToUpper(); v3 = v3.ToUpper(); v4 = v4.ToUpper(); v5 = v5.ToUpper();
        }
        [OnDeserialized]
        private void OnDeserialized (StreamingContext içrk) {
            v1 = v1.ToLower(); v2 = v2.ToLower(); v3 = v3.ToLower(); v4 = v4.ToLower(); v5 = v5.ToLower();
        }
    }
    class SerileþtirmeA {
        public static void Serileþtir() {
            Stream s = File.Open ("kiþi.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Kiþi kiþi = new Kiþi(); kiþi.ad="M.Nihat Yavaþ"; kiþi.yaþ=68; kiþi.boy=170; kiþi.kilo=62; bf.Serialize (s, kiþi);
            kiþi = new Kiþi(); kiþi.ad="M.Nedim Yavaþ"; kiþi.yaþ=64; kiþi.boy=168; kiþi.kilo=70; bf.Serialize (s, kiþi);
            kiþi = new Kiþi(); kiþi.ad="Hatice Yavaþ Kaçar"; kiþi.yaþ=74; kiþi.boy=160; kiþi.kilo=90; bf.Serialize (s, kiþi);
            kiþi = new Kiþi(); kiþi.ad="Nihal Yavaþ Candan"; kiþi.yaþ=70; kiþi.boy=165; kiþi.kilo=80; bf.Serialize (s, kiþi);
            kiþi = new Kiþi(); kiþi.ad="Sevim Yavaþ"; kiþi.yaþ=62; kiþi.boy=160; kiþi.kilo=65; bf.Serialize (s, kiþi);
            s.Close();
        }
        public static void Serisizleþtir() {
            Stream s = File.Open ("kiþi.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Kiþi kiþi;
            try {while(true) {kiþi=(Kiþi)bf.Deserialize (s); Console.WriteLine ("{0}: [yaþ {1}, boy {2} sm, kilo {3} kg]", kiþi.ad, kiþi.yaþ, kiþi.boy, kiþi.kilo);}}catch{}
            s.Close();
        }
        static void Main() {
            Console.Write ("BinaryFormatter verileri ikili/binary biçeme çevirerek serileþtirirken, SoapFormatter xml biçem kullanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'nokta.bin' verileri serileþtirip yazma, serisizleþtirip okuma:");
            int i, ts1, ts2; var r=new Random();
            Stream akýþ = File.Open ("nokta.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Nokta n1 = new Nokta();
            for(i=0;i<5;i++) {//Dosyaya serileþtirilen 5 nokta yazma
                ts1=r.Next(1881,1939); ts2=r.Next(1881,1939);
                n1.xNokta = ts1; n1.yNokta = ts2;
                bf.Serialize (akýþ, n1);
            }
            akýþ.Close();
            akýþ = File.Open ("nokta.bin", FileMode.Open);
            n1 = new Nokta();
            for(i=0;i<5;i++) {//Dosyadan serisizleþtirilen 5 nokta okuma
                n1 = (Nokta)bf.Deserialize (akýþ);
                Console.WriteLine ("{0}.Nokta(x,y) = ({1}, {2})", (i+1), n1.xNokta, n1.yNokta);
            }
            akýþ.Close();

            Console.WriteLine ("\nList<Ürün>'leri 'ürün.bin'e serileþtirip yazma ve serisizleþtirip okuma:");
            List<Ürün> ürün = new List<Ürün>();
            ürün.Add (new Ürün (7, "Armut", 30.0, "Hocamýz armudu"));
            ürün.Add (new Ürün (2, "Bal", 250.0, "Uludað çam balý"));
            ürün.Add (new Ürün (4, "Cam", 120.0, "Kristalize kapý camý"));
            ürün.Add (new Ürün (3, "Altýn", 2530.875, "24gr saf altýn"));
            ürün.Add (new Ürün (1, "Plastik", 450.0, "PVC14mm kablo borusu"));
            IFormatter serile = new BinaryFormatter();
            FileStream fs = new FileStream ("ürün.bin", FileMode.Create, FileAccess.Write);
            serile.Serialize (fs, ürün);
            fs.Flush(); fs.Close();
            fs = new FileStream ("ürün.bin", FileMode.Open, FileAccess.Read);
            List<Ürün> ürünler = serile.Deserialize (fs) as List<Ürün>;
            fs.Close();
            for(i=0;i<ürünler.Count;i++) Console.WriteLine (ürünler [i]);

            Console.WriteLine ("\nKiþi'leri 'kiþi.bin'e serileþtirip yazma ve serisizleþtirip okuma:");
            Serileþtir();
            Serisizleþtir();

            Console.WriteLine ("\nXML biçemli 'veri.soap'a serileþtirip yazma ve serisizleþtirip okuma:");
            Veriler veri = new Veriler();
            SoapFormatter xml = new SoapFormatter();
            using (Stream s = new FileStream ("veri.soap", FileMode.Create, FileAccess.Write, FileShare.None)) {
                xml.Serialize (s, veri); s.Close();
            }
            using (Stream s = new FileStream ("veri.soap", FileMode.Open, FileAccess.Read, FileShare.None)) {
                veri=(Veriler)xml.Deserialize (s); s.Close();
                Console.WriteLine ("1.veri: {0}\n2.veri: {1}\n3.veri: {2}\n4.veri: {3}\n5.veri: {4}", veri.v1, veri.v2, veri.v3, veri.v4, veri.v5);
            }
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}