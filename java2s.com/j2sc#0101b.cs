// j2sc#0101b.cs: C# derleyicisi ve baðlayýcýsý olan csc.exe örneði.

using System;
namespace DilTemelleri {
    class Giriþ2 {
        public static void Main() {
            Console.Write ("C:/Windows/Microsoft.NET/Aduzam/Framework içinde örn.'v4.0.30319' sürüm klasöründeki csc.exe derleyici-baðlayýcýsý ve system.?.dll kütüphaneleri C#5.0'a deðin yeterlidir. Daha üst (örn.C#11.0) derleyicisi için win10 ve Microsoft Visual Studio.NET yüklenmesi (8GB üstü) gerekmektedir. 'roslyn-4.0.1' veya 'dotnet-7.0.2' indirimleri içindeki csc.exe ve sys.?.dll yeterli olmamaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bu programýn çalýþmasý için csc.exe'ye path verip '>>csc j2sc#0101b.cs' ile hatalarýndan arýnýk j2sc#0101b.exe elde edilip ya komut satýrýndan ismen (j2sc#0101b) yada çift týklanarak koþturulabilir.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}