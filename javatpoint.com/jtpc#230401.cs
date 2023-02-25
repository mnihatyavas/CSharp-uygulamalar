// jtpc#230401.cs: Senkron, asenkron, geridönüþlü await Task metodlarý örneði.

using System;
using System.Threading;
using System.Threading.Tasks;
namespace YeniÖzellikler {
    class EþzamansýzMetodlar {
        static void SenkronÝþlem1() {
            Console.WriteLine ("SenkronÝþlem1 baþladý");
            Thread.Sleep (4000); // 4 sn bekletiþ
            Console.WriteLine ("4 sn'lik SenkronÝþlem1 tamamlandý");
        }
        static void SenkronÝþlem2() {Console.WriteLine ("SenkronÝþlem2 baþladý");
            //SenkronÝþlem2 iþlemleri
            Console.WriteLine ("SenkronÝþlem2 tamamlandý");
        }
        static async Task<int> AsenkronÝþlem1() {
            Console.WriteLine ("Geridönüþlü AsenkronÝþlem1 baþladý");
            await Task.Delay (4000); // 4 sn bekletiþ
            Console.WriteLine ("4 sn'lik AsenkronÝþlem1 tamamlandý");
            return (2023-72);
        }
        static async Task<int> AsenkronÝþlem2() {
            Console.WriteLine ("Geridönüþlü AsenkronÝþlem2 baþladý");
            await Task.Delay (4000); // 4 sn bekletiþ
            Console.WriteLine ("4 sn'lik AsenkronÝþlem2 tamamlandý");
            return (2023-66);
        }
        static async void AsenkronÝþlem3() {
            Console.WriteLine ("Geridönüþsüz AsenkronÝþlem3 baþladý");
            await Task.Delay (4000); // 4 sn bekletiþ
            Console.WriteLine ("4 sn'lik AsenkronÝþlem3 tamamlandý");
        }
        static async Task GörevliFonk() {
            Task<int> sonuç1 = AsenkronÝþlem1();
            Task<int> sonuç2 = AsenkronÝþlem2();
            AsenkronÝþlem3();
            SenkronÝþlem1();
            SenkronÝþlem2();
            var deðer1 = await sonuç1; //Sonucu alýncaya deðin bekler
            var deðer2 = await sonuç2; //Sonucu alýncaya deðin bekler
            Console.WriteLine ("AsenkronÝþlem1() sonucu: {0}", deðer1);
            Console.WriteLine ("AsenkronÝþlem2() sonucu: {0}", deðer2);
        }
        static void Main() {
            Console.Write ("Normal senkron/eþzamanlý program akýþý yerine async ve await anahtarkelimeli aynýzamanlý asenkron/eþzamansýz çoklu görevler geridönüþsüz Task veya geridönüþlü Task<TResult> sýnýf tiplemeleriyle çalýþtýrýlabilir. Geridönüþlü 'await' ifadeleri 'async Task' metodu içinde kullanýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");
            GörevliFonk();
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}