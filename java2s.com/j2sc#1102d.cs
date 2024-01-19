// j2sc#1102d.cs: DiziListe ve ToArray sunumlarý, dosyaya ikili/sabun yazma/okuma örneði.

using System;
using System.Collections;
using System.IO; //FileStream için
using System.Runtime.Serialization.Formatters.Binary; //BinaryFormatter için
using System.Runtime.Serialization.Formatters.Soap; //SoapFormatter için
namespace VeriYapýlarý {
    class Sýnýf1 {
        public string ad="";
        public Sýnýf1 (string a) {ad=a;} //Kurucu
    }
    class VeriYapýsý2D {
        private static void ÝkiliSerile (ArrayList liste) {
            using (FileStream da = File.Create ("mny1.iki")) {
                BinaryFormatter ib = new BinaryFormatter();
                ib.Serialize (da, liste);
            }
        }
        private static ArrayList ÝkiliSerisizle() {
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
            Console.Write ("FileStream/DosyaAkýþ için 'using System.IO' ve Binary/SoapFormatter|Ýkili/SabunBiçimleyici içinse 'using System.Runtime.Serialization.Formatters.Binary/Soap' tanýmlanmalýdýr. Ayrýca ülke tanýmlayýcsýz, türkçe harflere çalýþmazamaný hatasý veriyor.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DiziListe'yi for ve foreach'le gösterme:");
            ArrayList dl1 = new ArrayList();
            int i, j, ts1;
            for(i=0;i<26;i++) dl1.Add ((char)(i+65));
            Console.Write ("For döngülü sunum: ");
            for(i=0;i<dl1.Count;i++) Console.Write (dl1 [i] + " ");
            Console.Write ("\nForEach döngülü sunum: ");
            foreach(char k in dl1) Console.Write (k + " ");
            IEnumerator ie=dl1.GetEnumerator();
            Console.Write ("\nIEnumerator-while döngülü sunum: ");
            while (ie.MoveNext()) Console.Write (ie.Current + " ");

            Console.WriteLine ("\n\nDiziListe'yi ToArray'le tamsayý diziye kopyalama:");
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
            dl4.AddRange (new Sýnýf1[] {new Sýnýf1 ("M.Nihat Yavaþ"), new Sýnýf1 ("Fatih Özbay"), new Sýnýf1 ("Atilla Gökyiðit"), new Sýnýf1 ("Sevim Yavaþ"), new Sýnýf1 ("Hamza Candan")});
            object[] dz3 = dl4.ToArray();
            for(i=0;i<dz3.Length;i++) Console.WriteLine ("{0}) {1}", i+1, ((Sýnýf1)dz3 [i]).ad);

            Console.WriteLine ("\nSayýsal/Dizgesel DiziListe'yi ikili/sabun-dosyaya yazma, okuma ve sunma:");
            ÝkiliSerile (dl2); ArrayList dl2a = ÝkiliSerisizle();
            Console.WriteLine ("\tÝkiliDosyadan okunan sayýsal liste:"); i=0; foreach (int ts in dl2a) Console.WriteLine ("{0}) {1}", ++i, ts);
            ÝkiliSerile (dl3); ArrayList dl3a = ÝkiliSerisizle(); //Türkçe harfler hata verir
            Console.WriteLine ("\tÝkiliDosyadan okunan dizgesel liste:"); i=0; foreach (string dzg in dl3a) Console.WriteLine ("{0}) {1}", ++i, dzg);
            SabunSerile (dl2); dl2a = SabunSerisizle();
            Console.WriteLine ("\tXML-SabunDosyadan okunan sayýsal liste:"); i=0; foreach (int ts in dl2a) Console.WriteLine ("{0}) {1}", ++i, ts);
            SabunSerile (dl3); dl3a = SabunSerisizle(); //Türkçe harfler hata verir
            Console.WriteLine ("\tXML-SabunDosyadan okunan dizgesel liste:"); i=0; foreach (string dzg in dl3a) Console.WriteLine ("{0}) {1}", ++i, dzg);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}