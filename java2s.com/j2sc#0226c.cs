// j2sc#0226c.cs: Hiçlenebilir sayýnýn kontrollu gösterimleri ve kompleks iþlemler örneði.

using System;
namespace VeriTipleri {
    public class Kompleks  {
        public double? x = null;
        public double? y = null;
        public Kompleks (double? x, double? y) {this.x = x; this.y = y;}
        public static void topla (Kompleks km1, Kompleks km2) {
            double X = km1.x.Value + km2.x.Value;
            double Y = km1.y.Value + km2.y.Value;
            double B = Math.Sqrt (X * X + Y * Y);
            double A = Math.Atan (Math.Abs(Y / X)) * 180.0 / Math.PI; if (X<0 && Y>0) A=180-A; else if (X<0 && Y<0) A=180+A; else if (X>0 && Y<0) A=360-A;
            Console.WriteLine ("==>Topla: [{0} + {1}] = [{2} = {3:0.##}<{4:0.##}]", km1, km2, new Kompleks (X, Y), B, A);
        }
        public static void çýkar (Kompleks km1, Kompleks km2) {
            double X = km1.x.Value - km2.x.Value;
            double Y = km1.y.Value - km2.y.Value;
            double B = Math.Sqrt (X * X + Y * Y);
            double A = Math.Atan (Math.Abs(Y / X)) * 180.0 / Math.PI; if (X<0 && Y>0) A=180-A; else if (X<0 && Y<0) A=180+A; else if (X>0 && Y<0) A=360-A;
            Console.WriteLine ("==>Çýkar: [{0} - {1}] = [{2} = {3:0.##}<{4:0.##}]", km1, km2, new Kompleks (X, Y), B, A);
        }
        public static void çarp (Kompleks km1, Kompleks km2) {
            double B1 = Math.Sqrt (km1.x.Value * km1.x.Value + km1.y.Value * km1.y.Value);
            double A1 = Math.Atan (Math.Abs(km1.y.Value / km1.x.Value)) * 180.0 / Math.PI; if (km1.x.Value<0 && km1.y.Value>0) A1=180-A1; else if (km1.x.Value<0 && km1.y.Value<0) A1=180+A1; else if (km1.x.Value>0 && km1.y.Value<0) A1=360-A1;
            double B2 = Math.Sqrt (km2.x.Value * km2.x.Value + km2.y.Value * km2.y.Value);
            double A2 = Math.Atan (Math.Abs(km2.y.Value / km2.x.Value)) * 180.0 / Math.PI; if (km2.x.Value<0 && km2.y.Value>0) A2=180-A2; else if (km2.x.Value<0 && km2.y.Value<0) A2=180+A2; else if (km2.x.Value>0 && km2.y.Value<0) A2=360-A2;
            double B = B1 * B2;
            double A = A1 + A2; if (A > 360) A = A % 360;
            double X = Math.Round(B*Math.Cos(A*Math.PI/180), 4); double Y = Math.Round(B*Math.Sin(A*Math.PI/180), 4);
            Console.WriteLine ("==>Çarp: [({0} = {1:0.##}<{2:0.##}) * ({3} = {4:0.##}<{5:0.##})] = [{6} = {7:0.##}<{8:0.##}]", km1, B1, A1, km2, B2, A2, new Kompleks (X, Y), B, A);
        }
        public static void böl (Kompleks km1, Kompleks km2) {
            double B1 = Math.Sqrt (km1.x.Value * km1.x.Value + km1.y.Value * km1.y.Value);
            double A1 = Math.Atan (Math.Abs(km1.y.Value / km1.x.Value)) * 180.0 / Math.PI; if (km1.x.Value<0 && km1.y.Value>0) A1=180-A1; else if (km1.x.Value<0 && km1.y.Value<0) A1=180+A1; else if (km1.x.Value>0 && km1.y.Value<0) A1=360-A1;
            double B2 = Math.Sqrt (km2.x.Value * km2.x.Value + km2.y.Value * km2.y.Value);
            double A2 = Math.Atan (Math.Abs(km2.y.Value / km2.x.Value)) * 180.0 / Math.PI; if (km2.x.Value<0 && km2.y.Value>0) A2=180-A2; else if (km2.x.Value<0 && km2.y.Value<0) A2=180+A2; else if (km2.x.Value>0 && km2.y.Value<0) A2=360-A2;
            double B = B1 / B2;
            double A = A1 - A2; if (A < 0) A = A + 360;
            double X = Math.Round(B*Math.Cos(A*Math.PI/180), 4); double Y = Math.Round(B*Math.Sin(A*Math.PI/180), 4);
            Console.WriteLine ("==>Böl: [({0} = {1:0.##}<{2:.##}) / ({3} = {4:0.##}<{5:0.##})] = [{6} = {7:0.##}<{8:0.##}]", km1, B1, A1, km2, B2, A2, new Kompleks (X, Y), B, A);
        }
        public override string ToString() {
            string xString = x.HasValue ? x.ToString() : "0";
            string yString = y.HasValue ? y.ToString() : "0";
            return string.Format ("({0}, {1})", xString, yString);
        }
    }
    class Hiçlenebilir3 {
        static double? HiçlenebilirDuble() {
            double? ds;
            Console.Write ("==>Duble sayý gir: ");
            string girdi = Console.ReadLine();
            try {ds = double.Parse (girdi);
            }catch {ds = null;}
            Console.WriteLine ("GetHashCode(): {0}", ds.GetHashCode());
            Console.WriteLine ("HasValue: {0}", ds.HasValue);
            Console.WriteLine("GetValueOrDefault(): {0}", ds.GetValueOrDefault());
            return ds;
        }
        static int? TryParse (string veri) {
            int cevap;
            if (int.TryParse (veri, out cevap)) {return cevap;
            }else {return null;}
        }
        static void Main() {
            Console.Write ("Hiçlenebilir sayý kontrollarýnda kullanýlan 'sayý.HasValue' = True/False, 'sayý.GetHashCode()' = sayý/0, 'sayý.GetValueOrDefault()' = sayý/0 döndürür. Kompleks sayýlarýn toplama-çýkarma'larýnda kartezyen, çarpma-bölme'lerdeyse kutupsal kipleri kullanýlýr. Ýster vektörel/yöneysel/kutupsal/büyüklük<açý, ister de kompleks/kartezyen/'reel+jsanal' birinden diðerine çevrilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sayý girilmezse ilkinde -1, ikincisinde \"\" görülecektir:");
            double? ds1 = HiçlenebilirDuble(); Console.WriteLine ("Girilen ilk double sayý = {0}", (ds1 ?? -1));
            ds1 = HiçlenebilirDuble(); Console.WriteLine ("Girilen ikinci double sayý = \"{0}\"", ds1);

            Console.WriteLine ("\nNull kontrolu doðrudan '==' ile yapýlmaktadýr:");
            int? sonuç = TryParse ("Tamsayý deðil");
            if (sonuç != null) {Console.WriteLine ("Çevrilen tamsayý = {0}", sonuç.Value);
            }else {Console.WriteLine ("Geçersiz tamsayý çevrilemedi");}
            sonuç = TryParse ("2023");
            if (sonuç == null) {Console.WriteLine ("Geçersiz tamsayý çevrilemedi");
            }else {Console.WriteLine ("Çevrilen tamsayý = {0}", sonuç.Value);}

            Console.WriteLine ("\nKompleks sayýlarla +, -, *, / iþlemleri:");
            var r=new Random();
            var k1 = new Kompleks (((double)r.Next (-10, 10) + r.Next (1000, 10000) / 10000D), ((double)r.Next (-10, 10) + r.Next (1000, 10000) / 10000D));
            var k2 = new Kompleks (((double)r.Next (-10, 10) + r.Next (1000, 10000) / 10000D), ((double)r.Next (-10, 10) + r.Next (1000, 10000) / 10000D));
            Kompleks.topla (k1, k2); Kompleks.çýkar (k1, k2); Kompleks.çarp (k1, k2); Kompleks.böl (k1, k2);
            
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}