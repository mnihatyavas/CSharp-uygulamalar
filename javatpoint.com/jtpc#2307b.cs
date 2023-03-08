// jtpc#2307b.cs: Varsay�l� ifadeyle tiplemelerin �zellik ve metodlar�n� g�sterme �rne�i.

using System;
using System.Linq.Expressions;
namespace Yeni�zellikler {
    class Varsay�l��fade {
        // Default ifadesinin �zellik ve metotlar�:
        static void G�ster (Expression vi) {Console.WriteLine ("Tiplemesi: {0}\nTipi: {1}\n�ndirgenebilir mi?: {2}\nTipleme tipi: {3}\nYumru tipi: {4}\n", vi, vi.Type, vi.CanReduce, vi.GetType(), vi.NodeType);}
        static void Main() {
            Console.Write ("'Expression.Default(typeof(Tip))' ile veri tiplerinin �e�itli �zellik ve metotlar� sergilenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            G�ster (Expression.Default (typeof(int) ));
            G�ster (Expression.Default (typeof(bool) ));
            G�ster (Expression.Default (typeof(string) ));
            G�ster (Expression.Default (typeof(DateTime) ));
            G�ster (Expression.Default (typeof(Varsay�l��fade) ));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}