// j2sc#1501k.cs: BinaryWriter ve BinaryReader'la dosyaya yazma/okuma �rne�i.

using System;
using System.IO; 
namespace DosyaDizin {
    class DosyaK {
        static void Main() {
            Console.Write ("BinaryReader metotlar�: int Read(), int Read(byte[] dizi, int ilk, int adet), int Read(char[] dizi, int ilk, int adet), bool ReadBoolean(), byte ReadByte(), sbyte ReadSByte(), byte[] ReadBytes(int n), char ReadChar(), char[] ReadChar(int num), double ReadDouble(), float ReadSingle(), short ReadInt16(), int ReadInt32(), long ReadInt64(), ushort ReadUInt16(), uint ReadUInt32(), ulong ReadUInt64(), string ReadString().\nBinaryWriter metotlar�: void Write(sbyte d�r), void Write(byte d�r), void Write(byte[] dizi), void Write(short d�r), void Write(ushort d�r), void Write(int d�r), void Write(uint d�r), void Write(long d�r), void Write(ulong d�r), void Write(float d�r), void Write(double d�r), void Write(char d�r), void Write(char[] dizi), void Write(string d�r).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("using'li nihat1.bin dosyaya 5 farkl� tip veri yazma/okuma:");
            FileStream fs; BinaryWriter bw;
            using (fs = new FileStream ("nihat1.bin", FileMode.Create)) {
                using (bw = new BinaryWriter (fs)) {
                    bw.Write (20240516.010948M);
                    bw.Write ("M.Nihat Yava�");
                    bw.Write (20240516010948576L);
                    bw.Write (false);
                    bw.Write ('!');
                    bw.Flush(); bw.Close();
                }
            }
            BinaryReader br;
            using (fs = new FileStream ("nihat1.bin", FileMode.Open)) {
                fs.Position = 0;
                using (br = new BinaryReader (fs)) {
                    Console.WriteLine ("ReadDecimal: {0}", br.ReadDecimal());
                    Console.WriteLine ("ReadString: {0}", br.ReadString());
                    Console.WriteLine ("ReadLong: {0}", br.ReadInt64());
                    Console.WriteLine ("ReadBoolean: {0}", br.ReadBoolean());
                    Console.WriteLine ("ReadChar: {0}", br.ReadChar());
                    br.Close(); //Ayn� dosya kapanmadan tekrar a��lmaya �al���l�rsa hata f�rlat�r
                }
            }

            Console.WriteLine ("\nusing'siz nihat1.bin dosyaya 5 farkl� tip veri yazma/okuma:");
            fs = new FileStream ("nihat1.bin", FileMode.Create);
            bw = new BinaryWriter (fs);
            bw.Write (20240516.0133999M);
            bw.Write ("Zafer N.Candan");
            bw.Write (2024051601033999L);
            bw.Write (true);
            bw.Write ('!');
            bw.Flush(); bw.Close();
            fs = new FileStream ("nihat1.bin", FileMode.Open);
            fs.Position = 0;
            br = new BinaryReader (fs);
            Console.WriteLine ("ReadDecimal: {0}", br.ReadDecimal());
            Console.WriteLine ("ReadString: {0}", br.ReadString());
            Console.WriteLine ("ReadInt64: {0}", br.ReadInt64());
            Console.WriteLine ("ReadBoolean: {0}", br.ReadBoolean());
            Console.WriteLine ("ReadChar: {0}", br.ReadChar());
            br.Close();

            Console.WriteLine ("\ntry-catch'li nihat1.bin dosyaya 5 adet veri yazma/okuma:");
            int i = 20240516; double d = 20240516.013965897; bool b = true; string s="Nihal Zeliha Yava�";
            try {bw = new BinaryWriter (new FileStream ("nihat1.bin", FileMode.Create)); 
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("\t==>Veriler BinaryWriter'la dosyaya yaz�l�yor..."); 
                bw.Write (i); bw.Write (d); bw.Write (b); bw.Write (s); bw.Write (d*i);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            bw.Close();
            try {br = new BinaryReader (new FileStream ("nihat1.bin", FileMode.Open)); 
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("\t==>Veriler BinaryReader'la dosyadan okunuyor...");
                i=br.ReadInt32(); Console.WriteLine ("Tamsay�: {0}", i);
                d=br.ReadDouble(); Console.WriteLine ("Duble say�: {0}", d);
                b=br.ReadBoolean(); Console.WriteLine ("Bool say�: {0}", b);
                s=br.ReadString(); Console.WriteLine ("Dizge: {0}", s);
                d=br.ReadDouble(); Console.WriteLine ("i * d: {0}", d); //409678488228933.06
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            br.Close();

            Console.WriteLine ("\nnihat1.bin dosyay� �e�itli y�ntemlerle ��kt�lama:");
            fs = new FileStream ("nihat1.bin", FileMode.OpenOrCreate,FileAccess.ReadWrite);
            bw = new BinaryWriter (fs);
            Console.WriteLine ("\t==>Veriler BinaryWriter'la nihat1.bin dosyaya yaz�l�yor..."); 
            bw.Write ("M.Nihat Yava�, Toroslar - Mersin");
            i = 2024016;
            float f = 0.022351673F;
            b = false;
            char[] krkDizi = {'H', 'e', 'r', 'k', 'e', 's', 'e', ' ', 'M', 'e', 'r', 'h', 'a', 'b', 'a', 'l', 'a', 'r', '.'};
            bw.Write (i); bw.Write (f); bw.Write (b); bw.Write (krkDizi);
            bw.BaseStream.Position = 0;
            Console.WriteLine ("\t==>Veriler BinaryReader/ReadByte'la nihat1.bin dosyadan okunuyor...");
            br = new BinaryReader (fs);
            int j = 0, k=0;
            while(++k <= fs.Length) {
                i=br.ReadByte(); Console.Write ("{0}={1} ", i, (char)i);
                if(++j ==  5) {j = 0; Console.WriteLine();}
            }
            bw.Close(); br.Close(); fs.Close();
            Console.WriteLine ("\n\t==>Veriler StreamReader/ReadToEnd'le nihat1.bin dosyadan okunuyor...");
            StreamReader sr;
            using (fs = new FileStream ("nihat1.bin", FileMode.Open)) {
                using (sr = new StreamReader (fs)) {
                    Console.WriteLine (sr.ReadToEnd());
                    sr.Close();
                } fs.Close();
            }
            Console.WriteLine ("\t==>Veriler BinaryReader/ReadTip'le nihat1.bin dosyadan okunuyor...");
            br = new BinaryReader (new FileStream ("nihat1.bin", FileMode.Open)); 
            Console.WriteLine ("Dizge: [{0}]", br.ReadString());
            Console.WriteLine ("Tamsay�: [{0}]", br.ReadInt32());
            Console.WriteLine ("Kayan: [{0}]", br.ReadSingle());
            Console.WriteLine ("Bool: [{0}]", br.ReadBoolean());
            Console.Write ("char[] dizi: {0}=[", k=br.Read (krkDizi, 0, krkDizi.Length));
            for(i=0;i<k;i++) Console.Write (krkDizi [i]); Console.WriteLine ("]");
            br.Close();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}