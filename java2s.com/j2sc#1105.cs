// j2sc#1105.cs: Hashtable/AdreslemeTablosu verilerinin sayýsal/dizgesel anahtarla özgü sýralanmasý örneði.

using System;
using System.Collections; // Hashtable için
namespace VeriYapýlarý {
    class VeriYapýsý5 {
        static void Main() {
            Console.Write ("AdreslemeTablosu anahtarý yegane olmalýdýr, ayrýca KeyValuePair bunda geçersizdir. AdreslemeTablosu'nun foreach sýralamasý tamsayý anahtarda sondan baþa, dizgesel anahtarda ise özgü-sabittir. Ayný anahtarý Add'le ekstra ilave deðil = atamayla deðer deðiþikliðine hata vermez. Clear tüm adrestablosunu sýfýrlarken, Remove ilgili anahtarýn sadece deðerini silerken anahtar kalýr. Karýþýk eklenen ayný basamaklý büyük/küçük-harf duyarlý tablo anahtarlarý otomatikmen artan sýralanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yegane trafik kodlu 81 þehirli AdreslemeTablosu:");
            int i, ts1; var r=new Random();
            string[] þehirler=new string[]{"Adana","Adýyaman","Afyonkarahisar","Aðrý","Amasya","Ankara","Antalya","Artvin","Aydýn","Balýkesir","Bilecik","Bingöl","Bitlis","Bolu","Burdur","Bursa","Çanakkale","Çankýrý","Çorum","Denizli","Diyarbakýr","Edirne","Elazýð","Erzincan","Erzurum","Eskiþehir","Gaziantep","Giresun","Gümüþhane","Hakkari","Hatay","Isparta","Mersin","Ýstanbul","Ýzmir","Kars","Kastamonu","Kayseri","Kýrklareli","Kýrþehir","Kocaeli","Konya","Kütahya","Malatya","Manisa","Kahramanmaraþ","Mardin","Muðla","Muþ","Nevþehir","Niðde","Ordu","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirdað","Tokat","Trabzon","Tunceli","Þanlýurfa","Uþak","Van","Yozgat","Zonguldak","Aksaray","Bayburt","Karaman","Kýrýkkale","Batman","Þýrnak","Bartýn","Ardahan","Iðdýr","Yalova","Karabük","Kilis","Osmaniye","Düzce"};
            Hashtable at1 = new Hashtable();
            for(i=0;i<þehirler.Length;i++) at1.Add (i+1, þehirler [i]);
            try{at1.Add (4, "Aðrý");}catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);}
            at1 [81] = "Düzce";
            ICollection ik1 = at1.Keys;
            foreach (int kod in ik1) Console.Write (kod + ")" + at1 [kod] + ", "); Console.WriteLine();
            //foreach (KeyValuePair<int, string> çift in at1) Console.Write ("{0}){1}, ", çift.Key, çift.Value);
            for(i=0;i<at1.Count;i++) Console.Write ("{0}:{1}, ", i+1, at1 [i+1]); Console.WriteLine();
            foreach (int plaka in at1.Keys) Console.Write ("{0}={1} ", plaka, at1 [plaka]); Console.WriteLine();

            Console.WriteLine ("\nÞehirleri rastgele þehirlerarasý telefon kodlu adreslemetablosu:");
            Hashtable at2 = new Hashtable(81);
            for(i=0;i<þehirler.Length;i++) {ts1=r.Next(200, 500); at2 [þehirler [i]] = ts1;}
            foreach (string þehir in at2.Keys) Console.Write ("{0}:{1} ", þehir, at2 [þehir]); Console.WriteLine();
            Hashtable.Synchronized (at2); at2.Remove ("Adana"); at2.Remove ("Düzce");
            foreach (string þehir in at2.Keys) Console.Write ("{0}:{1} ", þehir, at2 [þehir]); Console.WriteLine();
            for(i=0;i<þehirler.Length;i++) Console.Write ("{0}={1}, ", þehirler [i], at2 [þehirler [i]]); Console.WriteLine();
            at2.Clear(); Console.WriteLine ("at2.Clear() sonrasý at2.Count: {0}", at2.Count);

            Console.WriteLine ("\nAdreslemeTablosu'na eklenen 5 ABD eyaletiyle iþlemler:");
            Hashtable at3 = new Hashtable();
            at3.Add ("WY", "Wyoming"); at3. Add ("AL", "Alabama"); at3.Add ("FL", "Florida"); at3.Add ("NY", "New York"); at3.Add ("CA", "California");
            foreach (string anh in at3.Keys) Console.Write (anh+" "); Console.WriteLine();
            foreach (string dðr in at3.Values) Console.Write (dðr+" "); Console.WriteLine();
            foreach (string anh in at3.Keys) Console.Write ("{0}={1} ", anh, at3 [anh]); Console.WriteLine();
            Console.WriteLine ("at3'de 'FL' anahtarý mevcut mu? {0}", at3.ContainsKey ("FL"));
            Console.WriteLine ("at3'de 'ÝST' anahtarý mevcut mu? {0}", at3.ContainsKey ("ÝST"));
            Console.WriteLine ("at3'de 'Florida' deðeri mevcut mu? {0}", at3.ContainsValue ("Florida")==true? "Evet" : "Hayýr");
            Console.WriteLine ("at3'de 'Ýstanbul' deðeri mevcut mu? {0}", at3.ContainsValue ("Ýstanbul")==true? "Evet" : "Hayýr");
            Console.WriteLine ("at3 anahtarlarý dizi1'e kopyalanýyor..."); string[] dizi1 = new string [at3.Count]; at3.Keys.CopyTo (dizi1, 0);
            Console.WriteLine ("at3 deðerleri dizi2'ye kopyalanýyor..."); string[] dizi2 = new string [at3.Count]; at3.Values.CopyTo (dizi2, 0);
            for(i=0;i<at3.Count;i++) Console.Write ("{0}={1} ", dizi1 [i], dizi2 [i]); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}