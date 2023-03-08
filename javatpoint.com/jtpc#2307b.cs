// jtpc#2307b.cs: Varsayýlý ifadeyle tiplemelerin özellik ve metodlarýný gösterme örneði.

using System;
using System.Linq.Expressions;
namespace YeniÖzellikler {
    class VarsayýlýÝfade {
        // Default ifadesinin özellik ve metotlarý:
        static void Göster (Expression vi) {Console.WriteLine ("Tiplemesi: {0}\nTipi: {1}\nÝndirgenebilir mi?: {2}\nTipleme tipi: {3}\nYumru tipi: {4}\n", vi, vi.Type, vi.CanReduce, vi.GetType(), vi.NodeType);}
        static void Main() {
            Console.Write ("'Expression.Default(typeof(Tip))' ile veri tiplerinin çeþitli özellik ve metotlarý sergilenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Göster (Expression.Default (typeof(int) ));
            Göster (Expression.Default (typeof(bool) ));
            Göster (Expression.Default (typeof(string) ));
            Göster (Expression.Default (typeof(DateTime) ));
            Göster (Expression.Default (typeof(VarsayýlýÝfade) ));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}