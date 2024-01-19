// j2sc#1102d.cs: DiziListe ve ToArray sunumlar�, dosyaya ikili/sabun yazma/okuma �rne�i.

using System;
using System.Collections;
using System.IO; //FileStream i�in
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter i�in
using System.Runtime.Serialization.Formatters.Soap; //SoapFormatter i�in
namespace VeriYap�lar� {
    class S�n�f1 {
        public string ad="";
        public S�n�f1 (string a) {ad=a;} //Kurucu
    }
    class VeriYap�s�2D {
        private static void �kiliSerile (ArrayList liste) {
            using (FileStream da = File.Create ("mny1.iki")) {
                BinaryFormatter ib = new BinaryFormatter();
                ib.Serialize (da, liste);
            }
        }
        private static ArrayList �kiliSerisizle() {
            ArrayList dl = null;
            using (FileStream da = File.OpenRead ("mny1.iki")) {
                BinaryFormatter ib = new BinaryFormatter();
                dl = (ArrayList)ib.Deserialize (da);
            }
            return dl;
        }
        private static void SabunSerile (ArrayList liste) {
            using (FileStream da = File.Create ("mny2.iki")) {
                SoapFormatter sb = new SoapFormatter();
                sb.Serialize (da, liste);
            }
        }
        private static ArrayList SabunSerisizle() {
            ArrayList dl = null;
            using (FileStream da = File.OpenRead ("mny2.iki")) {
                SoapFormatter sb = new SoapFormatter();
                dl = (ArrayList)sb.Deserialize (da);
            }
            return dl;
        }
        static void Main() {
            Console.Write ("FileStream/DosyaAk�� i�in 'using System.IO' ve Binary/SoapFormatter|�kili/SabunBi�imleyici i�inse 'using System.Runtime.Serialization.Formatters.Binary/Soap' tan�mlanmal�d�r. Ayr�ca �lke tan�mlay�cs�z, t�rk�e harflere �al��mazaman� hatas� veriyor.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DiziListe'yi for ve foreach'le g�sterme:");
            ArrayList dl1 = new ArrayList();
            int i, j, ts1;
            for(i=0;i<26;i++) dl1.Add ((char)(i+65));
            Console.Write ("For d�ng�l� sunum: ");
            for(i=0;i<dl1.Count;i++) Console.Write (dl1 [i] + " ");
            Console.Write ("\nForEach d�ng�l� sunum: ");
            foreach(char k in dl1) Console.Write (k + " ");
            IEnumerator ie=dl1.GetEnumerator();
            Console.Write ("\nIEnumerator-while d�ng�l� sunum: ");
            while (ie.MoveNext()) Console.Write (ie.Current + " ");

            Console.WriteLine ("\n\nDiziListe'yi ToArray'le tamsay� diziye kopyalama:");
            ArrayList dl2 = new ArrayList();
            var r=new Random();
            for(i=0;i<5;i++) {ts1=r.Next(-50,1000); dl2.Add (ts1);}
            foreach (int ts in dl2) Console.Write (ts + " ");
            int[] dz1 = (int[])dl2.ToArray (typeof (int));
            ts1=0; for(i=0;i<dz1.Length;i++) ts1+=dz1 [i];
            Console.WriteLine ("\nToplam: " + ts1);

            Console.WriteLine ("\nDiziListe'yi ToArray'le dizgesel diziye kopyalama:");
            ArrayList dl3 = new ArrayList (5);
            string dzg1;
            for(i=0;i<5;i++) {
                dzg1=""; for(j=0;j<10;j++) {ts1=r.Next(0,26); dzg1+=(char)(ts1+65); if(j==4)dzg1+=" ";}
                dl3.Add (dzg1);
            }
            string[] dz2 = (string[])dl3.ToArray (typeof (String));
            i=0; foreach (string ad in dz2) Console.WriteLine ("{0}) {1}", ++i, ad);

            Console.WriteLine ("\nDiziListe'yi ToArray'le nesnesel diziye kopyalama:");
            ArrayList dl4 = new ArrayList();
            dl4.AddRange (new S�n�f1[] {new S�n�f1 ("M.Nihat Yava�"), new S�n�f1 ("Fatih �zbay"), new S�n�f1 ("Atilla G�kyi�it"), new S�n�f1 ("Sevim Yava�"), new S�n�f1 ("Hamza Candan")});
            object[] dz3 = dl4.ToArray();
            for(i=0;i<dz3.Length;i++) Console.WriteLine ("{0}) {1}", i+1, ((S�n�f1)dz3 [i]).ad);

            Console.WriteLine ("\nSay�sal/Dizgesel DiziListe'yi ikili/sabun-dosyaya yazma, okuma ve sunma:");
            �kiliSerile (dl2); ArrayList dl2a = �kiliSerisizle();
            Console.WriteLine ("\t�kiliDosyadan okunan say�sal liste:"); i=0; foreach (int ts in dl2a) Console.WriteLine ("{0}) {1}", ++i, ts);
            �kiliSerile (dl3); ArrayList dl3a = �kiliSerisizle(); //T�rk�e harfler hata verir
            Console.WriteLine ("\t�kiliDosyadan okunan dizgesel liste:"); i=0; foreach (string dzg in dl3a) Console.WriteLine ("{0}) {1}", ++i, dzg);
            SabunSerile (dl2); dl2a = SabunSerisizle();
            Console.WriteLine ("\tXML-SabunDosyadan okunan say�sal liste:"); i=0; foreach (int ts in dl2a) Console.WriteLine ("{0}) {1}", ++i, ts);
            SabunSerile (dl3); dl3a = SabunSerisizle(); //T�rk�e harfler hata verir
            Console.WriteLine ("\tXML-SabunDosyadan okunan dizgesel liste:"); i=0; foreach (string dzg in dl3a) Console.WriteLine ("{0}) {1}", ++i, dzg);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}