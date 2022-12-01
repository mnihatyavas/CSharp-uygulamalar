// tpc#04c.cs: C# kodlamalar�ndaki temel s�zdizim kurallar� �rne�i.

using System;
class TemelS�zdizim {
    static void Main (string[] args) {
        Console.WriteLine ("Bu kodlamaki anahtar kelimeler: using, class, static, void ve string.\nS�n�f alt� de�i�kenlere '�ye de�i�kenler', metodlara da '�ye fonksiyonlar' denir.\n�lk �al��t�r�lan 'Main' metodudur.\nDe�i�ken, s�n�f ve metod adlar� bir harf yada _ ile ba�lar, sonras�nda harf, rakam ve _ olabilir, ancak ? - + ! @ # % ^ & * ( ) [ ] { } . ; : \" ' / \\ gibi �zel karakterler veya anahtar kelimeler kullan�lamaz.\nHer c# ifadesi sonuna ; konulmal�d�r.\nA��lan { mutlaka } ile kapat�lmal�d�r.");
        Console.WriteLine ("\nT�m c# ayr�lm�� anahtarkelimeler listesi:\nabstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in in(generic modifier) int interface internal is lock long namespace new null object operator out out(generic modifier) override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while");
        Console.Write ("\nT�m c# ba�lamsal anahtarkelimeler listesi:\nadd alias ascending descending dynamic from get global group into join let orderby partial(type) partial(method) remove select set\n\nTu�...");
        Console.ReadKey();
    }
}