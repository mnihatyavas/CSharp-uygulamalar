// jtpc#1408.cs: Tiplenen nesnenin ikili serile�tirilmesi ve serisizle�tirilmesi �rne�i.

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace DosyaG� {
    [Serializable]
    class ��renci {
        public int no;
        public string ad;
        public ��renci (int no, string ad) {this.no = no; this.ad = ad;} //Parametreli kurucu
    }  
    class Serile�S�Zle�tirme {
        static void Main() {
            Console.Write ("Serile�tirme tiplenen nesnenin dosya, bellek veya veritaban�na ikili-veriye �evrilip kaydedilmesidir. Serisizle�tirme ise bunun tersi, yani kay�tl� ikili verinin tekrar tiplenen nesnel bilgiye �evrilmesidir. BinaryFormatter().Serialize(ak��,��r)/Deserialize(ak��) kullan�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string yol = "jtpc#1408.txt";
            FileStream da1 = new FileStream (yol, FileMode.OpenOrCreate);
            BinaryFormatter ib1 = new BinaryFormatter(); //�kili bi�imleyici
            ��renci ��r1 = new ��renci (101, "M.Nihat Yava�"); ib1.Serialize (da1, ��r1); //�kili bi�imleyicinin serile�tirip dosyaya kaydetmesi
            ��r1 = new ��renci (102, "Hamit Derdiyok"); ib1.Serialize (da1, ��r1);
            ��r1 = new ��renci (103, "Nihat Alt�nel"); ib1.Serialize (da1, ��r1);
            for (int i=104; i < 111; i++) {��r1 = new ��renci (i, "��renci-"+i); ib1.Serialize (da1, ��r1);}
            da1.Close();
            Console.WriteLine ("10 ��renci kayd� serile�tirilip [{0}] dosyaya kaydedildi.", yol);

            FileStream da2 = new FileStream (yol, FileMode.OpenOrCreate);
            BinaryFormatter ib2 = new BinaryFormatter();
            ��renci ��r2;
            Console.WriteLine ("\n��renci kay�tlar� [{0}] dosyadan serisizle�tirilip d�k�mlenecek:", yol);
            //Sonsuz while d�ng�s�ndeki dosyasonu istisnas�n� try-catch y�netecek
            try {while (true) {��r2 = (��renci)ib2.Deserialize (da2); Console.WriteLine ("{0} no'lu ��renci: {1}", ��r2.no, ��r2.ad);} }catch(Exception){}
            da2.Close();  

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}