// j2sc#2204g.cs: Join-on ile �oklu liste alanlar� ili�kili sorgular �rne�i.

using System;
using System.Linq; //join i�in
using System.Collections.Generic; //List<> i�in
namespace Query_Sorgu {
    public class ��g�ren {
        public int _y�l;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Y�l {get {return _y�l;} set {_y�l = value;}}
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
    class Maa� {
        int _meslekNo;
        double _maa�;
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public double Maa�� {get {return _maa�;} set {_maa� = value;}}
    }
    class Join {
        static void Main() {
            Console.Write ("'from-whereXfrom-where' dengi 'from-join-on' kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Peygamberler ve endekslerin birle�ik sorgular�:");
            string[] peygamberler = {"Adem", "Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Zerd��t", "Buda", "Brahman", "Konfi�yus"};
            String[] endeksler = {"A", "B", "C", "�", "D", "E", "F", "G", "�", "H", "I", "�", "J", "K", "L", "M", "N", "O", "�", "P", "Q", "R", "S", "�", "T", "U", "�", "V", "W", "X", "Y", "Z"};
            var sorgu1a = from p in peygamberler
                join e in endeksler on p.Substring (0, 1) equals e
                select new {p, e};
            Console.Write ("-->T�m {0} adet endeksli peygamberler: ", sorgu1a.Count());
            foreach(var pey in sorgu1a) Console.Write ("{0}-{1} ", pey.e, pey.p); Console.WriteLine();
            var sorgu1b = from p in peygamberler
                join e in endeksler on p.Substring (0, 1) equals e
                where Convert.ToChar (e) > 'H'
                orderby e descending
                select new {p, e};
            Console.Write ("-->T�m {0} adet 'p[0] > H' azalan endeksli peygamberler: ", sorgu1b.Count());
            foreach(var pey in sorgu1b) Console.Write ("{0}-{1} ", pey.e, pey.p); Console.WriteLine();

            Console.WriteLine ("\nFrom-from-where ile from-join-on sorgular�:");
            Int32[] DiziA = new Int32[10]; Int32[] DiziB = new Int32[10];
            int i, ts; var r=new Random();
            for(i=0;i<10;i++) {ts=r.Next(1881,1938); DiziA [i] = ts; ts=r.Next(1881,1938); DiziB [i] = ts;}
            var sorgu2a = from a in DiziA //Herbir DiziA-y�l, t�m DiziB-y�l'lar� tarar
                from b in DiziB
                where a == b //from-from-where
                select a;
            Console.Write ("-->T�m {0} adet fromXfrom 'DiziA[i]==DiziB[i]' y�llar: ", sorgu2a.Count());
            foreach(var y�l in sorgu2a) Console.Write (y�l+" "); Console.WriteLine();
            var sorgu2b = from a in DiziA //Herbir DiziA-y�l, t�m DiziB-y�l'lar� tarar
                join b in DiziB on a equals b //from-join-on
                select a;
            Console.Write ("-->T�m {0} adet join 'DiziA[i]==DiziB[i]' y�llar: ", sorgu2b.Count());
            foreach(var y�l in sorgu2b) Console.Write (y�l+" "); Console.WriteLine();
            var sorgu2c = from ilk in Enumerable.Range (1, 5)
                from ikinci in Enumerable.Range (1, ilk)
                select new {ilk, ikinci};
            Console.WriteLine ("-->T�m {0} adet fromXfrom Rank: ", sorgu2c.Count());
            foreach(var n in sorgu2c) Console.WriteLine ("\t{0}", n);
            var sorgu2d = from ilk in Enumerable.Range (1, 5)
                join ikinci in Enumerable.Range (1, 5) on ilk equals ikinci
                select new {ilk, ikinci};
            Console.WriteLine ("-->T�m {0} adet join Rank: ", sorgu2d.Count());
            foreach(var n in sorgu2d) Console.WriteLine ("\t{0}", n);

            Console.WriteLine ("��g�ren-->meslekno ile roller&maa�lar-->meslekno join ili�kili sorgu:");
            List<��g�ren> i�g�renler = new List<��g�ren> {
                new ��g�ren {Y�l = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1931, MeslekNo = 1, Ad = "Han�m", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Ka�ar"},
                new ��g�ren {Y�l = 1953, MeslekNo = 3, Ad = "S�heyla", Soyad = "�zbay"},
                new ��g�ren {Y�l = 1955, MeslekNo = 3, Ad = "Zeliha", Soyad = "Candan"},
                new ��g�ren {Y�l = 1957, MeslekNo = 5, Ad = "M.Nihat", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1959, MeslekNo = 4, Ad = "Song�l", Soyad = "G�kyi�it"},
                new ��g�ren {Y�l = 1961, MeslekNo = 3, Ad = "M.Nedim", Soyad = "Yava�"},
                new ��g�ren {Y�l = 1963, MeslekNo = 4, Ad = "Sevim", Soyad = "Yava�"}
            };
            List<Rol> roller = new List<Rol> {
                new Rol {MeslekNo = 1, Meslek = "Y�netici"},
                new Rol {MeslekNo = 2, Meslek = "��g�ren"}
            };
            var sorgu3a = from i� in i�g�renler
                where i�.MeslekNo == 1
                from rl in roller
                where rl.MeslekNo == i�.MeslekNo
                select new {i�.Ad, i�.Soyad, i�.Y�l, rl.Meslek};
            Console.WriteLine ("-->T�m {0} adet from-whereXfrom-where i��iler: ", sorgu3a.Count());
            foreach(var i� in sorgu3a) Console.WriteLine (i�);
            var sorgu3b = from i� in i�g�renler
                join rl in roller on i�.MeslekNo equals rl.MeslekNo
                select new {i�.Ad, i�.Soyad, i�.Y�l, rl.Meslek};
            Console.WriteLine ("-->T�m {0} adet from-join-on i��iler: ", sorgu3b.Count());
            foreach(var i� in sorgu3b) Console.WriteLine (i�);
            List<Maa�> maa�lar = new List<Maa�> {
                new Maa� {MeslekNo = 3, Maa�� = 125672.63},
                new Maa� {MeslekNo = 4, Maa�� = 65241.24},
                new Maa� {MeslekNo = 5, Maa�� = 97650.35}
            };
            var sorgu3c = from i� in i�g�renler
                join m in maa�lar on i�.MeslekNo equals m.MeslekNo
                select new {i�.Ad, i�.Soyad, m.Maa��};
            Console.WriteLine ("-->T�m {0} adet from-join-on maa�lar: ", sorgu3c.Count());
            foreach(var i� in sorgu3c) Console.WriteLine (i�);
            var sorgu3d = from i� in i�g�renler
                join m in maa�lar on i�.MeslekNo equals m.MeslekNo
                where i�.MeslekNo == 3
                select new {i�.Ad, i�.Soyad, i�.MeslekNo, m.Maa��};
            Console.WriteLine ("-->T�m {0} adet 'MeslekNo == 3' maa�lar: ", sorgu3d.Count());
            foreach(var i� in sorgu3d) Console.WriteLine (i�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}