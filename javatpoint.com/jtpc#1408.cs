// jtpc#1408.cs: Tiplenen nesnenin ikili serileþtirilmesi ve serisizleþtirilmesi örneði.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace DosyaGÇ {
    [Serializable]
    class Öðrenci {
        public int no;
        public string ad;
        public Öðrenci (int no, string ad) {this.no = no; this.ad = ad;} //Parametreli kurucu
    }  
    class SerileþSÝZleþtirme {
        static void Main() {
            Console.Write ("Serileþtirme tiplenen nesnenin dosya, bellek veya veritabanýna ikili-veriye çevrilip kaydedilmesidir. Serisizleþtirme ise bunun tersi, yani kayýtlý ikili verinin tekrar tiplenen nesnel bilgiye çevrilmesidir. BinaryFormatter().Serialize(akýþ,öðr)/Deserialize(akýþ) kullanýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string yol = "jtpc#1408.txt";
            FileStream da1 = new FileStream (yol, FileMode.OpenOrCreate);
            BinaryFormatter ib1 = new BinaryFormatter(); //Ýkili biçimleyici
            Öðrenci öðr1 = new Öðrenci (101, "M.Nihat Yavaþ"); ib1.Serialize (da1, öðr1); //Ýkili biçimleyicinin serileþtirip dosyaya kaydetmesi
            öðr1 = new Öðrenci (102, "Hamit Derdiyok"); ib1.Serialize (da1, öðr1);
            öðr1 = new Öðrenci (103, "Nihat Altýnel"); ib1.Serialize (da1, öðr1);
            for (int i=104; i < 111; i++) {öðr1 = new Öðrenci (i, "Öðrenci-"+i); ib1.Serialize (da1, öðr1);}
            da1.Close();
            Console.WriteLine ("10 öðrenci kaydý serileþtirilip [{0}] dosyaya kaydedildi.", yol);

            FileStream da2 = new FileStream (yol, FileMode.OpenOrCreate);
            BinaryFormatter ib2 = new BinaryFormatter();
            Öðrenci öðr2;
            Console.WriteLine ("\nÖðrenci kayýtlarý [{0}] dosyadan serisizleþtirilip dökümlenecek:", yol);
            //Sonsuz while döngüsündeki dosyasonu istisnasýný try-catch yönetecek
            try {while (true) {öðr2 = (Öðrenci)ib2.Deserialize (da2); Console.WriteLine ("{0} no'lu öðrenci: {1}", öðr2.no, öðr2.ad);} }catch(Exception){}
            da2.Close();  

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}