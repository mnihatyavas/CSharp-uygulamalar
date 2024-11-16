// j2sc#2201g.cs: Anonim Func'un parametrik lambdalý Expression ifadeli derlenmesi örneði.

using System;
using System.Linq.Expressions; //Expression, BinaryExpression için
namespace AnonimFunc {
    class DerlemeExpression {
        static void Main() {
            Console.Write ("Anonim lambda parametrik Func, derlemeli Expression ile de kurulabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim lambda'lý Func ve derlemeli Expression:");
            Func<int, int> fonk1 = x => x + 1881;
            var sonuç1 = fonk1 (42);
            Expression<Func<int, int>> ifade = fonk => fonk + 1881;
            var derlenenÝfade = ifade.Compile();
            var sonuç2 = derlenenÝfade.Invoke (42);
            BinaryExpression iþlem = (BinaryExpression)ifade.Body;
            Console.WriteLine ("fonk1(42) = {0}\tderlenenÝfade.Invoke(42) = {1}\tÝþlem: {2}", sonuç1, sonuç2, iþlem.NodeType);
            int i, ts; var r=new Random();
            for(i=0;i<5;i++) {ts=r.Next(0,58); Console.WriteLine ("fonk1({0})={1}\tderlenenÝfade.Invoke({0})={2}", ts, fonk1 (ts), derlenenÝfade.Invoke (ts));}

            Console.WriteLine ("\nDerlemeli Expression'la iki argümaný toplayan lambda Func:");
            Expression arg1 = Expression.Constant (1881);
            Expression arg2 = Expression.Constant (0);
            Expression topla = Expression.Add (arg1, arg2);
            Func<int> derle = Expression.Lambda<Func<int>>(topla).Compile();
            for(i=0;i<=57;i++) {
                arg2 = Expression.Constant (i);
                topla = Expression.Add (arg1, arg2);
                derle = Expression.Lambda<Func<int>>(topla).Compile();
                Console.Write (derle()+" ");
            } Console.WriteLine();

            Console.WriteLine ("\nÞartlý/bool lambda Func'taki þartýn sol-sað bölümleri:");
            Expression<Func<String, bool>> labdaÝfade = þehir => þehir.Length >= 6;
            ParameterExpression parametre = (ParameterExpression)labdaÝfade.Parameters [0];
            BinaryExpression þart = (BinaryExpression)labdaÝfade.Body;
            MemberExpression þartýnSolu = (MemberExpression)þart.Left;
            ConstantExpression þartýnSaðý = (ConstantExpression)þart.Right;
            Console.WriteLine ("Lambda parametresi: " + parametre + "\nÞart: " + þart + "\nÞartýn solu: " + þartýnSolu + "\nÞartýn saðý: " + þartýnSaðý);

            Console.WriteLine ("\nParametresiz sabit int-dönen derlemeli lambda Func'la yýllar:");
            Expression<Func<int>> dönen = () => 1881;
            Func<int> derle2 = dönen.Compile();
            for(i=0;i<=57;i++) Console.Write (i + derle2()+" "); Console.WriteLine();

            Console.WriteLine ("\nÞart-true/false döndüren çift lambda parametreli derleme Func ifade:");
            Expression<Func<string, string, bool>> ifade2 = ((x, y) => x.StartsWith (y));
            var derle3 = ifade2.Compile();
            string dzg1="Atatürk", dzg2="türk";
            Console.WriteLine ("{0}.BaþlýyorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hayýr");
            dzg2="Ata"; Console.WriteLine ("{0}.BaþlýyorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hayýr");
            dzg2="ata"; Console.WriteLine ("{0}.BaþlýyorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hayýr");
            dzg2="A"; Console.WriteLine ("{0}.BaþlýyorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hayýr");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}