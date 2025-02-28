// j2sc#2204g.cs: Join-on ile çoklu liste alanlarý iliþkili sorgular örneði.

using System;
using System.Linq; //join için
using System.Collections.Generic; //List<> için
namespace Query_Sorgu {
    public class Ýþgören {
        public int _yýl;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
    }
    class Rol {
        int _meslekNo;
        string meslek;
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Meslek {get {return meslek;} set {meslek = value;}}
    }
    class Maaþ {
        int _meslekNo;
        double _maaþ;
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public double Maaþý {get {return _maaþ;} set {_maaþ = value;}}
    }
    class Join {
        static void Main() {
            Console.Write ("'from-whereXfrom-where' dengi 'from-join-on' kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberler ve endekslerin birleþik sorgularý:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Zerdüþt", "Buda", "Brahman", "Konfiçyus"};
            String[] endeksler = {"A", "B", "C", "Ç", "D", "E", "F", "G", "Ð", "H", "I", "Ý", "J", "K", "L", "M", "N", "O", "Ö", "P", "Q", "R", "S", "Þ", "T", "U", "Ü", "V", "W", "X", "Y", "Z"};
            var sorgu1a = from p in peygamberler
                join e in endeksler on p.Substring (0, 1) equals e
                select new {p, e};
            Console.Write ("-->Tüm {0} adet endeksli peygamberler: ", sorgu1a.Count());
            foreach(var pey in sorgu1a) Console.Write ("{0}-{1} ", pey.e, pey.p); Console.WriteLine();
            var sorgu1b = from p in peygamberler
                join e in endeksler on p.Substring (0, 1) equals e
                where Convert.ToChar (e) > 'H'
                orderby e descending
                select new {p, e};
            Console.Write ("-->Tüm {0} adet 'p[0] > H' azalan endeksli peygamberler: ", sorgu1b.Count());
            foreach(var pey in sorgu1b) Console.Write ("{0}-{1} ", pey.e, pey.p); Console.WriteLine();

            Console.WriteLine ("\nFrom-from-where ile from-join-on sorgularý:");
            Int32[] DiziA = new Int32[10]; Int32[] DiziB = new Int32[10];
            int i, ts; var r=new Random();
            for(i=0;i<10;i++) {ts=r.Next(1881,1938); DiziA [i] = ts; ts=r.Next(1881,1938); DiziB [i] = ts;}
            var sorgu2a = from a in DiziA //Herbir DiziA-yýl, tüm DiziB-yýl'larý tarar
                from b in DiziB
                where a == b //from-from-where
                select a;
            Console.Write ("-->Tüm {0} adet fromXfrom 'DiziA[i]==DiziB[i]' yýllar: ", sorgu2a.Count());
            foreach(var yýl in sorgu2a) Console.Write (yýl+" "); Console.WriteLine();
            var sorgu2b = from a in DiziA //Herbir DiziA-yýl, tüm DiziB-yýl'larý tarar
                join b in DiziB on a equals b //from-join-on
                select a;
            Console.Write ("-->Tüm {0} adet join 'DiziA[i]==DiziB[i]' yýllar: ", sorgu2b.Count());
            foreach(var yýl in sorgu2b) Console.Write (yýl+" "); Console.WriteLine();
            var sorgu2c = from ilk in Enumerable.Range (1, 5)
                from ikinci in Enumerable.Range (1, ilk)
                select new {ilk, ikinci};
            Console.WriteLine ("-->Tüm {0} adet fromXfrom Rank: ", sorgu2c.Count());
            foreach(var n in sorgu2c) Console.WriteLine ("\t{0}", n);
            var sorgu2d = from ilk in Enumerable.Range (1, 5)
                join ikinci in Enumerable.Range (1, 5) on ilk equals ikinci
                select new {ilk, ikinci};
            Console.WriteLine ("-->Tüm {0} adet join Rank: ", sorgu2d.Count());
            foreach(var n in sorgu2d) Console.WriteLine ("\t{0}", n);

            Console.WriteLine ("Ýþgören-->meslekno ile roller&maaþlar-->meslekno join iliþkili sorgu:");
            List<Ýþgören> iþgörenler = new List<Ýþgören> {
                new Ýþgören {Yýl = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1931, MeslekNo = 1, Ad = "Haným", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Kaçar"},
                new Ýþgören {Yýl = 1953, MeslekNo = 3, Ad = "Süheyla", Soyad = "Özbay"},
                new Ýþgören {Yýl = 1955, MeslekNo = 3, Ad = "Zeliha", Soyad = "Candan"},
                new Ýþgören {Yýl = 1957, MeslekNo = 5, Ad = "M.Nihat", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1959, MeslekNo = 4, Ad = "Songül", Soyad = "Gökyiðit"},
                new Ýþgören {Yýl = 1961, MeslekNo = 3, Ad = "M.Nedim", Soyad = "Yavaþ"},
                new Ýþgören {Yýl = 1963, MeslekNo = 4, Ad = "Sevim", Soyad = "Yavaþ"}
            };
            List<Rol> roller = new List<Rol> {
                new Rol {MeslekNo = 1, Meslek = "Yönetici"},
                new Rol {MeslekNo = 2, Meslek = "Ýþgören"}
            };
            var sorgu3a = from iþ in iþgörenler
                where iþ.MeslekNo == 1
                from rl in roller
                where rl.MeslekNo == iþ.MeslekNo
                select new {iþ.Ad, iþ.Soyad, iþ.Yýl, rl.Meslek};
            Console.WriteLine ("-->Tüm {0} adet from-whereXfrom-where iþçiler: ", sorgu3a.Count());
            foreach(var iþ in sorgu3a) Console.WriteLine (iþ);
            var sorgu3b = from iþ in iþgörenler
                join rl in roller on iþ.MeslekNo equals rl.MeslekNo
                select new {iþ.Ad, iþ.Soyad, iþ.Yýl, rl.Meslek};
            Console.WriteLine ("-->Tüm {0} adet from-join-on iþçiler: ", sorgu3b.Count());
            foreach(var iþ in sorgu3b) Console.WriteLine (iþ);
            List<Maaþ> maaþlar = new List<Maaþ> {
                new Maaþ {MeslekNo = 3, Maaþý = 125672.63},
                new Maaþ {MeslekNo = 4, Maaþý = 65241.24},
                new Maaþ {MeslekNo = 5, Maaþý = 97650.35}
            };
            var sorgu3c = from iþ in iþgörenler
                join m in maaþlar on iþ.MeslekNo equals m.MeslekNo
                select new {iþ.Ad, iþ.Soyad, m.Maaþý};
            Console.WriteLine ("-->Tüm {0} adet from-join-on maaþlar: ", sorgu3c.Count());
            foreach(var iþ in sorgu3c) Console.WriteLine (iþ);
            var sorgu3d = from iþ in iþgörenler
                join m in maaþlar on iþ.MeslekNo equals m.MeslekNo
                where iþ.MeslekNo == 3
                select new {iþ.Ad, iþ.Soyad, iþ.MeslekNo, m.Maaþý};
            Console.WriteLine ("-->Tüm {0} adet 'MeslekNo == 3' maaþlar: ", sorgu3d.Count());
            foreach(var iþ in sorgu3d) Console.WriteLine (iþ);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}