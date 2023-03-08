// jtpc#2304b.cs: Çaðýran ifadenin metod adý, tam yollu dosya adý ve satýr no vasýflarý örneði.

using System;
using System.Runtime.CompilerServices;
namespace YeniÖzellikler {
    class ÇaðýranVasýflarý {
        static void ÇaðýranýnVasýflarýnýGöster (
                [CallerMemberName] string çaðýranMetodAdý = null,
                [CallerFilePath] string çaðýranDosyaYolu = null,
                [CallerLineNumber] int çaðýranSatýrNo = -1) {
            Console.WriteLine ("Çaðýran metodun adý: [{0}]", çaðýranMetodAdý);
            Console.WriteLine ("Çaðýran dosyanýn tam yolu: [{0}]", çaðýranDosyaYolu);
            Console.WriteLine ("Çaðýran ifadenin satýr no'su: [{0}]", çaðýranSatýrNo);
        }
        static void Main() {
            Console.Write ("Çaðýran metod ifadesine dair metodadý (string CallerMemberNameAttribute), satýr numarasý (int CallerLineNumberAttribute) ve tam yollu dosya adý (string CallerFilePathAttribute) vasýflarý elde edilebilir. Bu vasýf parametreleri çaðrýlan metodun seçenekli parametreleri olarak tanýmlanmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");
            ÇaðýranýnVasýflarýnýGöster();
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}