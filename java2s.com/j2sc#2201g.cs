// j2sc#2201g.cs: Anonim Func'un parametrik lambdal� Expression ifadeli derlenmesi �rne�i.

using System;
using System.Linq.Expressions; //Expression, BinaryExpression i�in
namespace AnonimFunc {
    class DerlemeExpression {
        static void Main() {
            Console.Write ("Anonim lambda parametrik Func, derlemeli Expression ile de kurulabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Anonim lambda'l� Func ve derlemeli Expression:");
            Func<int, int> fonk1 = x => x + 1881;
            var sonu�1 = fonk1 (42);
            Expression<Func<int, int>> ifade = fonk => fonk + 1881;
            var derlenen�fade = ifade.Compile();
            var sonu�2 = derlenen�fade.Invoke (42);
            BinaryExpression i�lem = (BinaryExpression)ifade.Body;
            Console.WriteLine ("fonk1(42) = {0}\tderlenen�fade.Invoke(42) = {1}\t��lem: {2}", sonu�1, sonu�2, i�lem.NodeType);
            int i, ts; var r=new Random();
            for(i=0;i<5;i++) {ts=r.Next(0,58); Console.WriteLine ("fonk1({0})={1}\tderlenen�fade.Invoke({0})={2}", ts, fonk1 (ts), derlenen�fade.Invoke (ts));}

            Console.WriteLine ("\nDerlemeli Expression'la iki arg�man� toplayan lambda Func:");
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

            Console.WriteLine ("\n�artl�/bool lambda Func'taki �art�n sol-sa� b�l�mleri:");
            Expression<Func<String, bool>> labda�fade = �ehir => �ehir.Length >= 6;
            ParameterExpression parametre = (ParameterExpression)labda�fade.Parameters [0];
            BinaryExpression �art = (BinaryExpression)labda�fade.Body;
            MemberExpression �art�nSolu = (MemberExpression)�art.Left;
            ConstantExpression �art�nSa�� = (ConstantExpression)�art.Right;
            Console.WriteLine ("Lambda parametresi: " + parametre + "\n�art: " + �art + "\n�art�n solu: " + �art�nSolu + "\n�art�n sa��: " + �art�nSa��);

            Console.WriteLine ("\nParametresiz sabit int-d�nen derlemeli lambda Func'la y�llar:");
            Expression<Func<int>> d�nen = () => 1881;
            Func<int> derle2 = d�nen.Compile();
            for(i=0;i<=57;i++) Console.Write (i + derle2()+" "); Console.WriteLine();

            Console.WriteLine ("\n�art-true/false d�nd�ren �ift lambda parametreli derleme Func ifade:");
            Expression<Func<string, string, bool>> ifade2 = ((x, y) => x.StartsWith (y));
            var derle3 = ifade2.Compile();
            string dzg1="Atat�rk", dzg2="t�rk";
            Console.WriteLine ("{0}.Ba�l�yorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hay�r");
            dzg2="Ata"; Console.WriteLine ("{0}.Ba�l�yorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hay�r");
            dzg2="ata"; Console.WriteLine ("{0}.Ba�l�yorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hay�r");
            dzg2="A"; Console.WriteLine ("{0}.Ba�l�yorMu({1})? {2}", dzg1, dzg2, derle3 (dzg1, dzg2)?"Evet":"Hay�r");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}