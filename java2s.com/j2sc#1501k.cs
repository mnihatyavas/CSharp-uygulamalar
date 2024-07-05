// j2sc#1501k.cs: BinaryWriter ve BinaryReader'la dosyaya yazma/okuma örneði.

using System;
using System.IO; 
namespace DosyaDizin {
    class DosyaK {
        static void Main() {
            Console.Write ("BinaryReader metotlarý: int Read(), int Read(byte[] dizi, int ilk, int adet), int Read(char[] dizi, int ilk, int adet), bool ReadBoolean(), byte ReadByte(), sbyte ReadSByte(), byte[] ReadBytes(int n), char ReadChar(), char[] ReadChar(int num), double ReadDouble(), float ReadSingle(), short ReadInt16(), int ReadInt32(), long ReadInt64(), ushort ReadUInt16(), uint ReadUInt32(), ulong ReadUInt64(), string ReadString().\nBinaryWriter metotlarý: void Write(sbyte dðr), void Write(byte dðr), void Write(byte[] dizi), void Write(short dðr), void Write(ushort dðr), void Write(int dðr), void Write(uint dðr), void Write(long dðr), void Write(ulong dðr), void Write(float dðr), void Write(double dðr), void Write(char dðr), void Write(char[] dizi), void Write(string dðr).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("using'li nihat1.bin dosyaya 5 farklý tip veri yazma/okuma:");
            FileStream fs; BinaryWriter bw;
            using (fs = new FileStream ("nihat1.bin", FileMode.Create)) {
                using (bw = new BinaryWriter (fs)) {
                    bw.Write (20240516.010948M);
                    bw.Write ("M.Nihat Yavaþ");
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
                    br.Close(); //Ayný dosya kapanmadan tekrar açýlmaya çalýþýlýrsa hata fýrlatýr
                }
            }

            Console.WriteLine ("\nusing'siz nihat1.bin dosyaya 5 farklý tip veri yazma/okuma:");
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
            int i = 20240516; double d = 20240516.013965897; bool b = true; string s="Nihal Zeliha Yavaþ";
            try {bw = new BinaryWriter (new FileStream ("nihat1.bin", FileMode.Create)); 
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("\t==>Veriler BinaryWriter'la dosyaya yazýlýyor..."); 
                bw.Write (i); bw.Write (d); bw.Write (b); bw.Write (s); bw.Write (d*i);
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            bw.Close();
            try {br = new BinaryReader (new FileStream ("nihat1.bin", FileMode.Open)); 
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {Console.WriteLine ("\t==>Veriler BinaryReader'la dosyadan okunuyor...");
                i=br.ReadInt32(); Console.WriteLine ("Tamsayý: {0}", i);
                d=br.ReadDouble(); Console.WriteLine ("Duble sayý: {0}", d);
                b=br.ReadBoolean(); Console.WriteLine ("Bool sayý: {0}", b);
                s=br.ReadString(); Console.WriteLine ("Dizge: {0}", s);
                d=br.ReadDouble(); Console.WriteLine ("i * d: {0}", d); //409678488228933.06
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            br.Close();

            Console.WriteLine ("\nnihat1.bin dosyayý çeþitli yöntemlerle çýktýlama:");
            fs = new FileStream ("nihat1.bin", FileMode.OpenOrCreate,FileAccess.ReadWrite);
            bw = new BinaryWriter (fs);
            Console.WriteLine ("\t==>Veriler BinaryWriter'la nihat1.bin dosyaya yazýlýyor..."); 
            bw.Write ("M.Nihat Yavaþ, Toroslar - Mersin");
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
            Console.WriteLine ("Tamsayý: [{0}]", br.ReadInt32());
            Console.WriteLine ("Kayan: [{0}]", br.ReadSingle());
            Console.WriteLine ("Bool: [{0}]", br.ReadBoolean());
            Console.Write ("char[] dizi: {0}=[", k=br.Read (krkDizi, 0, krkDizi.Length));
            for(i=0;i<k;i++) Console.Write (krkDizi [i]); Console.WriteLine ("]");
            br.Close();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}