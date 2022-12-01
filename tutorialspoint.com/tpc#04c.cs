// tpc#04c.cs: C# kodlamalarýndaki temel sözdizim kurallarý örneði.

using System;
class TemelSözdizim {
    static void Main (string[] args) {
        Console.WriteLine ("Bu kodlamaki anahtar kelimeler: using, class, static, void ve string.\nSýnýf altý deðiþkenlere 'üye deðiþkenler', metodlara da 'üye fonksiyonlar' denir.\nÝlk çalýþtýrýlan 'Main' metodudur.\nDeðiþken, sýnýf ve metod adlarý bir harf yada _ ile baþlar, sonrasýnda harf, rakam ve _ olabilir, ancak ? - + ! @ # % ^ & * ( ) [ ] { } . ; : \" ' / \\ gibi özel karakterler veya anahtar kelimeler kullanýlamaz.\nHer c# ifadesi sonuna ; konulmalýdýr.\nAçýlan { mutlaka } ile kapatýlmalýdýr.");
        Console.WriteLine ("\nTüm c# ayrýlmýþ anahtarkelimeler listesi:\nabstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in in(generic modifier) int interface internal is lock long namespace new null object operator out out(generic modifier) override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while");
        Console.Write ("\nTüm c# baðlamsal anahtarkelimeler listesi:\nadd alias ascending descending dynamic from get global group into join let orderby partial(type) partial(method) remove select set\n\nTuþ...");
        Console.ReadKey();
    }
}