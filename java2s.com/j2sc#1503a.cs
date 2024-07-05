// j2sc#1503a.cs: Verileri dosyaya serile�tirip ikili veya xml bi�emde yazma �rne�i.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter i�in
using System.Runtime.Serialization;//IFormatter i�in
using System.Collections.Generic; //List<T> i�in
using System.Runtime.Serialization.Formatters.Soap; //SoapFormatter i�in
namespace S�r�c�Dizin {
    [Serializable()] //Gerekli
    class Nokta {
        public int xNokta, yNokta;
    }
    [Serializable]
    public class �r�n {
        public long kod;
        public string ad;
        public double fiyat;
        //[NonSerialized] //notlar okunmaz
        string notlar;
        public �r�n (long k, string a, double f, string n) {//Kurucu
            kod = k; ad = a; fiyat = f; notlar = n;
        }
        public override string ToString() {return string.Format ("{0}: {1} ({2:F2} TL) {3}", kod, ad, fiyat, notlar);}
    }
    [Serializable]
    public class Ki�i {
        public string ad {get; set;}
        public int ya�, boy, kilo;
        public Ki�i(){} //Kurucu
    }
    [Serializable]
    class Veriler {
        public string v1 = "M.Nihat Yava�", v2 = "Sevim Yava�", v3 = "Song�l Yava� G�kyi�it", v4 = "S�heyla Yava� �zbay", v5 = "Han�m Emanet Yava�";
        [OnSerializing]
        private void OnSerializing (StreamingContext i�erik) {
            v1 = v1.ToUpper(); v2 = v2.ToUpper(); v3 = v3.ToUpper(); v4 = v4.ToUpper(); v5 = v5.ToUpper();
        }
        [OnDeserialized]
        private void OnDeserialized (StreamingContext i�rk) {
            v1 = v1.ToLower(); v2 = v2.ToLower(); v3 = v3.ToLower(); v4 = v4.ToLower(); v5 = v5.ToLower();
        }
    }
    class Serile�tirmeA {
        public static void Serile�tir() {
            Stream s = File.Open ("ki�i.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Ki�i ki�i = new Ki�i(); ki�i.ad="M.Nihat Yava�"; ki�i.ya�=68; ki�i.boy=170; ki�i.kilo=62; bf.Serialize (s, ki�i);
            ki�i = new Ki�i(); ki�i.ad="M.Nedim Yava�"; ki�i.ya�=64; ki�i.boy=168; ki�i.kilo=70; bf.Serialize (s, ki�i);
            ki�i = new Ki�i(); ki�i.ad="Hatice Yava� Ka�ar"; ki�i.ya�=74; ki�i.boy=160; ki�i.kilo=90; bf.Serialize (s, ki�i);
            ki�i = new Ki�i(); ki�i.ad="Nihal Yava� Candan"; ki�i.ya�=70; ki�i.boy=165; ki�i.kilo=80; bf.Serialize (s, ki�i);
            ki�i = new Ki�i(); ki�i.ad="Sevim Yava�"; ki�i.ya�=62; ki�i.boy=160; ki�i.kilo=65; bf.Serialize (s, ki�i);
            s.Close();
        }
        public static void Serisizle�tir() {
            Stream s = File.Open ("ki�i.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Ki�i ki�i;
            try {while(true) {ki�i=(Ki�i)bf.Deserialize (s); Console.WriteLine ("{0}: [ya� {1}, boy {2} sm, kilo {3} kg]", ki�i.ad, ki�i.ya�, ki�i.boy, ki�i.kilo);}}catch{}
            s.Close();
        }
        static void Main() {
            Console.Write ("BinaryFormatter verileri ikili/binary bi�eme �evirerek serile�tirirken, SoapFormatter xml bi�em kullan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'nokta.bin' verileri serile�tirip yazma, serisizle�tirip okuma:");
            int i, ts1, ts2; var r=new Random();
            Stream ak�� = File.Open ("nokta.bin", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            Nokta n1 = new Nokta();
            for(i=0;i<5;i++) {//Dosyaya serile�tirilen 5 nokta yazma
                ts1=r.Next(1881,1939); ts2=r.Next(1881,1939);
                n1.xNokta = ts1; n1.yNokta = ts2;
                bf.Serialize (ak��, n1);
            }
            ak��.Close();
            ak�� = File.Open ("nokta.bin", FileMode.Open);
            n1 = new Nokta();
            for(i=0;i<5;i++) {//Dosyadan serisizle�tirilen 5 nokta okuma
                n1 = (Nokta)bf.Deserialize (ak��);
                Console.WriteLine ("{0}.Nokta(x,y) = ({1}, {2})", (i+1), n1.xNokta, n1.yNokta);
            }
            ak��.Close();

            Console.WriteLine ("\nList<�r�n>'leri '�r�n.bin'e serile�tirip yazma ve serisizle�tirip okuma:");
            List<�r�n> �r�n = new List<�r�n>();
            �r�n.Add (new �r�n (7, "Armut", 30.0, "Hocam�z armudu"));
            �r�n.Add (new �r�n (2, "Bal", 250.0, "Uluda� �am bal�"));
            �r�n.Add (new �r�n (4, "Cam", 120.0, "Kristalize kap� cam�"));
            �r�n.Add (new �r�n (3, "Alt�n", 2530.875, "24gr saf alt�n"));
            �r�n.Add (new �r�n (1, "Plastik", 450.0, "PVC14mm kablo borusu"));
            IFormatter serile = new BinaryFormatter();
            FileStream fs = new FileStream ("�r�n.bin", FileMode.Create, FileAccess.Write);
            serile.Serialize (fs, �r�n);
            fs.Flush(); fs.Close();
            fs = new FileStream ("�r�n.bin", FileMode.Open, FileAccess.Read);
            List<�r�n> �r�nler = serile.Deserialize (fs) as List<�r�n>;
            fs.Close();
            for(i=0;i<�r�nler.Count;i++) Console.WriteLine (�r�nler [i]);

            Console.WriteLine ("\nKi�i'leri 'ki�i.bin'e serile�tirip yazma ve serisizle�tirip okuma:");
            Serile�tir();
            Serisizle�tir();

            Console.WriteLine ("\nXML bi�emli 'veri.soap'a serile�tirip yazma ve serisizle�tirip okuma:");
            Veriler veri = new Veriler();
            SoapFormatter xml = new SoapFormatter();
            using (Stream s = new FileStream ("veri.soap", FileMode.Create, FileAccess.Write, FileShare.None)) {
                xml.Serialize (s, veri); s.Close();
            }
            using (Stream s = new FileStream ("veri.soap", FileMode.Open, FileAccess.Read, FileShare.None)) {
                veri=(Veriler)xml.Deserialize (s); s.Close();
                Console.WriteLine ("1.veri: {0}\n2.veri: {1}\n3.veri: {2}\n4.veri: {3}\n5.veri: {4}", veri.v1, veri.v2, veri.v3, veri.v4, veri.v5);
            }
 
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}