// jtpc#230401.cs: Senkron, asenkron, gerid�n��l� await Task metodlar� �rne�i.

using System;
using System.Threading;
using System.Threading.Tasks;
namespace Yeni�zellikler {
    class E�zamans�zMetodlar {
        static void Senkron��lem1() {
            Console.WriteLine ("Senkron��lem1 ba�lad�");
            Thread.Sleep (4000); // 4 sn bekleti�
            Console.WriteLine ("4 sn'lik Senkron��lem1 tamamland�");
        }
        static void Senkron��lem2() {Console.WriteLine ("Senkron��lem2 ba�lad�");
            //Senkron��lem2 i�lemleri
            Console.WriteLine ("Senkron��lem2 tamamland�");
        }
        static async Task<int> Asenkron��lem1() {
            Console.WriteLine ("Gerid�n��l� Asenkron��lem1 ba�lad�");
            await Task.Delay (4000); // 4 sn bekleti�
            Console.WriteLine ("4 sn'lik Asenkron��lem1 tamamland�");
            return (2023-72);
        }
        static async Task<int> Asenkron��lem2() {
            Console.WriteLine ("Gerid�n��l� Asenkron��lem2 ba�lad�");
            await Task.Delay (4000); // 4 sn bekleti�
            Console.WriteLine ("4 sn'lik Asenkron��lem2 tamamland�");
            return (2023-66);
        }
        static async void Asenkron��lem3() {
            Console.WriteLine ("Gerid�n��s�z Asenkron��lem3 ba�lad�");
            await Task.Delay (4000); // 4 sn bekleti�
            Console.WriteLine ("4 sn'lik Asenkron��lem3 tamamland�");
        }
        static async Task G�revliFonk() {
            Task<int> sonu�1 = Asenkron��lem1();
            Task<int> sonu�2 = Asenkron��lem2();
            Asenkron��lem3();
            Senkron��lem1();
            Senkron��lem2();
            var de�er1 = await sonu�1; //Sonucu al�ncaya de�in bekler
            var de�er2 = await sonu�2; //Sonucu al�ncaya de�in bekler
            Console.WriteLine ("Asenkron��lem1() sonucu: {0}", de�er1);
            Console.WriteLine ("Asenkron��lem2() sonucu: {0}", de�er2);
        }
        static void Main() {
            Console.Write ("Normal senkron/e�zamanl� program ak��� yerine async ve await anahtarkelimeli ayn�zamanl� asenkron/e�zamans�z �oklu g�revler gerid�n��s�z Task veya gerid�n��l� Task<TResult> s�n�f tiplemeleriyle �al��t�r�labilir. Gerid�n��l� 'await' ifadeleri 'async Task' metodu i�inde kullan�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");
            G�revliFonk();
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}