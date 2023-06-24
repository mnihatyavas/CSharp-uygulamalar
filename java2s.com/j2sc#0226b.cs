// j2sc#0226b.cs: Hi�lenebilir say�n�n kontrollu g�sterimleri �rne�i.

using System;
namespace VeriTipleri {
    class �ah�s {
        public string isim;
        public DateTime dTarih;
        public DateTime? �Tarih;
        public �ah�s (string isim, DateTime dTarih, DateTime? �Tarih) {
            this.isim = isim;
            this.dTarih = dTarih;
            this.�Tarih = �Tarih;
        }
        public TimeSpan ya� {
            get {if (�Tarih == null) {return DateTime.Now - dTarih;
                 }else {return �Tarih.Value - dTarih;}
            }
        }
    }
    class Hi�lenebilir2 {
        static void G�ster (Nullable<int> x) {
            Console.WriteLine ("De�erli mi: {0}", x.HasValue);
            if (x.HasValue) {
                Console.WriteLine ("De�er: {0}", x.Value);
                Console.WriteLine ("Aleni �evrim: {0}", (int) x);
                Console.WriteLine ("Do�rudan g�sterim: {0}", x);
            }else {
                Console.WriteLine ("Null: {0}", x);
                Console.WriteLine ("Kontrollu g�sterim: {0}", x ?? -1);
                Console.WriteLine ("x == null? {0}", (x == null));
            }

            Console.WriteLine ("ToString() �evrim: \"{0}\"", x.ToString());
        }
        static void Main() {
            Console.Write ("Hi�lenebilir de�i�ken 'int? say�', 'new int?()' veya 'Nullable<int> say�', 'new Nullable<int>()' ile kontrolu ise 'say� == null' veya 'say�.HasValue' ile yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hi�lenebilir say�n�n kutulanmas�/kutusuzlanmas� ve hi�'lik kontrolu:");
            int? ts1 = 5;
            object ns1 = ts1;
            Console.WriteLine ("Nesneye kutulanan hi�lenebilir ts1: ({0}, {1}) = ns1: ({2}, {3})", ts1, ts1.GetType(), ns1, ns1.GetType() );
            int ts2 = (int) ns1;
            Console.WriteLine ("Kutusuzlanan ts2 = ({0}, {1})", ts2, ts2.GetTypeCode() );
            ts1 = (int?) ns1;
            Console.WriteLine ("Kutusuzlanan hi�lenebilir ts1 = ({0}, {1})", ts1, ts1.GetType() );
            ts1 = new int?();
            ns1 = ts1;
            Console.WriteLine ("ts1({0})'den kutulanan ns1({1}) hi� mi? {2}", ts1, ns1, (ns1 == null) );
            ts1 = (int?) ns1;
            Console.WriteLine ("ns1({0})'den kutusuzlanan ts1({1})'in de�eri var m�? {2}", ns1, ts1, ts1.HasValue);

            Console.WriteLine ("\nHi�lenebilirli�i 'int?' yerine 'Nullable<int>' ile yapma:");
            Nullable<int> ts3 = 8;
            object ns2 = ts3;
            Console.WriteLine ("Nesneye kutulanan hi�lenebilir ts3: ({0}) = ns2: ({1})", ts3, ns2);
            ts3 = (Nullable<int>) ns2;
            Console.WriteLine ("Kutusuzlanan hi�lenebilir ts3 = ({0})", ts3);
            ts3 = new Nullable<int>();
            ns2 = ts3;
            Console.WriteLine ("ts3({0})'den kutulanan ns2({1}) hi� mi? {2}", ts3, ns2, (ns2 == null) );
            ts3 = (Nullable<int>) ns2;
            Console.WriteLine ("ns2({0})'den kutusuzlanan ts3({1})'in de�eri var m�? {2}", ns2, ts3, ts3.HasValue);

            Console.WriteLine ("\nYa�ayan/m�teveffa ki�i (isim, do�um, �l�m, ya�:saat/365) bilgileri:");
            �ah�s �ah�s1 = new �ah�s ("Memet Yava�", new DateTime (1934, 1, 1), new DateTime (2018, 1, 1));
            Console.WriteLine ("==>{0}'�n do�.tarih, �l.tarih ve ya�� = ({1}, {2}, {3})", �ah�s1.isim, �ah�s1.dTarih, (�ah�s1.�Tarih ?? new DateTime (1, 1, 1)), �ah�s1.ya�);
            �ah�s �ah�s2 = new �ah�s ("Sevim Yava�", new DateTime (1963, 1, 1), null);
            Console.WriteLine ("==>{0}'�n do�.tarih, �l.tarih ve ya�� = ({1}, {2}, {3})", �ah�s2.isim, �ah�s2.dTarih, (�ah�s2.�Tarih ?? new DateTime (1, 1, 1)), �ah�s2.ya�);
            �ah�s �ah�s3 = new �ah�s ("Fatma Yava�", new DateTime (1895, 1, 1), new DateTime (1969, 1, 1));
            Console.WriteLine ("==>{0}'�n do�.tarih, �l.tarih ve ya�� = ({1}, {2}, {3})", �ah�s3.isim, �ah�s3.dTarih, (�ah�s3.�Tarih ?? new DateTime (1, 1, 1)), �ah�s3.ya�);
            �ah�s �ah�s4 = new �ah�s ("Hatice Yava� Ka�ar", new DateTime (1951, 1, 1), null);
            Console.WriteLine ("==>{0}'�n do�.tarih, �l.tarih ve ya�� = ({1}, {2}, {3})", �ah�s4.isim, �ah�s4.dTarih, (�ah�s4.�Tarih ?? new DateTime (1, 1, 1)), �ah�s4.ya�);

            Console.WriteLine ("\nHi�lenebilir tamsay� de�i�kenin kontrollu g�sterimi:");
            Nullable<int> x = 20230602; /* veya */ x = new Nullable<int> (20230602);
            Console.WriteLine ("==>De�er tiplemeli g�sterim:"); G�ster (x);
            x = new Nullable<int>();
            Console.WriteLine ("==>Hi� tiplemeli g�sterim:"); G�ster (x);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}