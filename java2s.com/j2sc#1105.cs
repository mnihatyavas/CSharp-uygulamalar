// j2sc#1105.cs: Hashtable/AdreslemeTablosu verilerinin say�sal/dizgesel anahtarla �zg� s�ralanmas� �rne�i.

using System;
using System.Collections; // Hashtable i�in
namespace VeriYap�lar� {
    class VeriYap�s�5 {
        static void Main() {
            Console.Write ("AdreslemeTablosu anahtar� yegane olmal�d�r, ayr�ca KeyValuePair bunda ge�ersizdir. AdreslemeTablosu'nun foreach s�ralamas� tamsay� anahtarda sondan ba�a, dizgesel anahtarda ise �zg�-sabittir. Ayn� anahtar� Add'le ekstra ilave de�il = atamayla de�er de�i�ikli�ine hata vermez. Clear t�m adrestablosunu s�f�rlarken, Remove ilgili anahtar�n sadece de�erini silerken anahtar kal�r. Kar���k eklenen ayn� basamakl� b�y�k/k���k-harf duyarl� tablo anahtarlar� otomatikmen artan s�ralan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yegane trafik kodlu 81 �ehirli AdreslemeTablosu:");
            int i, ts1; var r=new Random();
            string[] �ehirler=new string[]{"Adana","Ad�yaman","Afyonkarahisar","A�r�","Amasya","Ankara","Antalya","Artvin","Ayd�n","Bal�kesir","Bilecik","Bing�l","Bitlis","Bolu","Burdur","Bursa","�anakkale","�ank�r�","�orum","Denizli","Diyarbak�r","Edirne","Elaz��","Erzincan","Erzurum","Eski�ehir","Gaziantep","Giresun","G�m��hane","Hakkari","Hatay","Isparta","Mersin","�stanbul","�zmir","Kars","Kastamonu","Kayseri","K�rklareli","K�r�ehir","Kocaeli","Konya","K�tahya","Malatya","Manisa","Kahramanmara�","Mardin","Mu�la","Mu�","Nev�ehir","Ni�de","Ordu","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirda�","Tokat","Trabzon","Tunceli","�anl�urfa","U�ak","Van","Yozgat","Zonguldak","Aksaray","Bayburt","Karaman","K�r�kkale","Batman","��rnak","Bart�n","Ardahan","I�d�r","Yalova","Karab�k","Kilis","Osmaniye","D�zce"};
            Hashtable at1 = new Hashtable();
            for(i=0;i<�ehirler.Length;i++) at1.Add (i+1, �ehirler [i]);
            try{at1.Add (4, "A�r�");}catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);}
            at1 [81] = "D�zce";
            ICollection ik1 = at1.Keys;
            foreach (int kod in ik1) Console.Write (kod + ")" + at1 [kod] + ", "); Console.WriteLine();
            //foreach (KeyValuePair<int, string> �ift in at1) Console.Write ("{0}){1}, ", �ift.Key, �ift.Value);
            for(i=0;i<at1.Count;i++) Console.Write ("{0}:{1}, ", i+1, at1 [i+1]); Console.WriteLine();
            foreach (int plaka in at1.Keys) Console.Write ("{0}={1} ", plaka, at1 [plaka]); Console.WriteLine();

            Console.WriteLine ("\n�ehirleri rastgele �ehirleraras� telefon kodlu adreslemetablosu:");
            Hashtable at2 = new Hashtable(81);
            for(i=0;i<�ehirler.Length;i++) {ts1=r.Next(200, 500); at2 [�ehirler [i]] = ts1;}
            foreach (string �ehir in at2.Keys) Console.Write ("{0}:{1} ", �ehir, at2 [�ehir]); Console.WriteLine();
            Hashtable.Synchronized (at2); at2.Remove ("Adana"); at2.Remove ("D�zce");
            foreach (string �ehir in at2.Keys) Console.Write ("{0}:{1} ", �ehir, at2 [�ehir]); Console.WriteLine();
            for(i=0;i<�ehirler.Length;i++) Console.Write ("{0}={1}, ", �ehirler [i], at2 [�ehirler [i]]); Console.WriteLine();
            at2.Clear(); Console.WriteLine ("at2.Clear() sonras� at2.Count: {0}", at2.Count);

            Console.WriteLine ("\nAdreslemeTablosu'na eklenen 5 ABD eyaletiyle i�lemler:");
            Hashtable at3 = new Hashtable();
            at3.Add ("WY", "Wyoming"); at3. Add ("AL", "Alabama"); at3.Add ("FL", "Florida"); at3.Add ("NY", "New York"); at3.Add ("CA", "California");
            foreach (string anh in at3.Keys) Console.Write (anh+" "); Console.WriteLine();
            foreach (string d�r in at3.Values) Console.Write (d�r+" "); Console.WriteLine();
            foreach (string anh in at3.Keys) Console.Write ("{0}={1} ", anh, at3 [anh]); Console.WriteLine();
            Console.WriteLine ("at3'de 'FL' anahtar� mevcut mu? {0}", at3.ContainsKey ("FL"));
            Console.WriteLine ("at3'de '�ST' anahtar� mevcut mu? {0}", at3.ContainsKey ("�ST"));
            Console.WriteLine ("at3'de 'Florida' de�eri mevcut mu? {0}", at3.ContainsValue ("Florida")==true? "Evet" : "Hay�r");
            Console.WriteLine ("at3'de '�stanbul' de�eri mevcut mu? {0}", at3.ContainsValue ("�stanbul")==true? "Evet" : "Hay�r");
            Console.WriteLine ("at3 anahtarlar� dizi1'e kopyalan�yor..."); string[] dizi1 = new string [at3.Count]; at3.Keys.CopyTo (dizi1, 0);
            Console.WriteLine ("at3 de�erleri dizi2'ye kopyalan�yor..."); string[] dizi2 = new string [at3.Count]; at3.Values.CopyTo (dizi2, 0);
            for(i=0;i<at3.Count;i++) Console.Write ("{0}={1} ", dizi1 [i], dizi2 [i]); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}