// j2sc#1104.cs: ICollection, IDictionary ve SortedDictionary �rne�i.

using System;
using System.Collections.Generic; //Dictionary<T1,T2> ve ICollection<T> i�in
using System.Text.RegularExpressions; //Regex i�in
namespace VeriYap�lar� {
    class VeriYap�s�4 {
        static Dictionary<string,int> KelimeleriSay (string dzg) {
            Dictionary<string,int> s�kl�k = new Dictionary<string,int>();
            string[] kelimeler = Regex.Split (dzg, @"\W+");
            foreach (string kelime in kelimeler) {
                if (s�kl�k.ContainsKey (kelime)) s�kl�k [kelime]++;
                else s�kl�k [kelime] = 1;
            }
            return s�kl�k;
        }
        static void Main() {
            Console.Write ("Dictionary ikili anahtar/Key-de�er/Value �iftinden/KeyValuePair olu�ur. �lki anahtar, ikincisi de�erdir; her tipte tan�mlanabilirler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�zl�k kay�tlar�na ilk isim anahtar� endeksleriyle eri�me:");
            int i, j; double ds1; var r=new Random();
            string[] adlar= new string[] {"M.Nihat Yava�", "Zafer N.Candan", "Hilal G�kyi�it", "Serap K���kbay", "Selda �zbay"};
            Dictionary<string, double> s�zl�k1 = new Dictionary<string, double>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                s�zl�k1.Add (adlar [i], ds1);
            }
            ICollection<string> ik1 = s�zl�k1.Keys;
            foreach(string ad in ik1) Console.WriteLine ("{0},\tMaa�: {1,9:#,0.00} TL", ad, s�zl�k1 [ad]);

            Console.WriteLine ("\nS�zl�k kay�tlar�na ilk maa� anahtar� endeksleriyle eri�me:");
            Dictionary<double, string> s�zl�k2 = new Dictionary<double, string>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                s�zl�k2.Add (ds1, adlar [i]);
            }
            ICollection<double> ik2 = s�zl�k2.Keys;
            foreach(double maa� in ik2) Console.WriteLine ("{0},\tMaa�: {1,9:#,0.00} TL", s�zl�k2 [maa�], maa�);

            Console.WriteLine ("\nDizgedeki kelimeleri tekrar s�kl���yla i�eren s�zl�k:");
            string tekerleme = "�u k��e yaz k��esi �u k��e k�� k��esi bu k��e bahar k��esi bu k��e g�z k��esi";
            Console.WriteLine (tekerleme);
            Dictionary<string, int> s�kl�k = KelimeleriSay (tekerleme);
            foreach (KeyValuePair<string, int> �ift in s�kl�k) Console.WriteLine ("{0}: {1}", �ift.Key, �ift.Value);

            Console.WriteLine ("\nIDictionary ile isim-maa� �iftli anahtar-de�er'lerin sunumu:");
            decimal m1;
            IDictionary<string, decimal> bordro = new Dictionary<string, decimal>();
            for(i=0;i<adlar.Length;i++) {
                m1=r.Next(7500,100000)+r.Next(0,100)/100M;
                bordro.Add (adlar [i], m1);
            }
            foreach (KeyValuePair<string, decimal> �ift in bordro) Console.WriteLine ("{0},\tMaa�: {1,9:#,0.00} TL", �ift.Key, �ift.Value);
            Console.WriteLine ("��g�ren say�s�: {0}", bordro.Count);
            m1=r.Next(7500,100000)+r.Next(0,100)/100M; bordro.Add ("Hamza Candan", m1);
            m1=r.Next(7500,100000)+r.Next(0,100)/100M; bordro.Add ("Sevim Yava�", m1);
            Console.WriteLine ("2 ilaveli i�g�ren say�s�: {0}", bordro.Count);
            bordro.Remove ("Hamza Candan"); bordro.Remove ("Sevim Yava�");
            Console.WriteLine ("2 eksiltmeli i�g�ren say�s�: {0}", bordro.Count);
            Console.WriteLine ("Bordroda Selda �zbay var m�? {0}", bordro.ContainsKey ("Selda �zbay")==true? "Evet" : "Hay�r");
            Console.WriteLine ("Bordroda Sema �zbay var m�? {0}", bordro.ContainsKey ("Sema �zbay")==true? "Evet" : "Hay�r");
            m1=0; foreach (decimal m in bordro.Values) m1+=m;
            Console.WriteLine ("Maa�lar�n toplam�: {0,9:#,0.00} TL,\tOrtalamas�: {1,9:#,0.00} TL", m1, m1/bordro.Count);

            Console.WriteLine ("\nIDictionary veri �iftini List'e aktar�p g�r�nt�leme:");
            IDictionary<string, DateTime> tarih = new Dictionary<string, DateTime>();
            for(i=0;i<5;i++) {tarih.Add ((i+1)+".tarih", DateTime.Now); for(j=0;j<50000000;j++){}}
            List<KeyValuePair<string, DateTime>> tliste = new List<KeyValuePair<string, DateTime>>(tarih);
            foreach (KeyValuePair<string, DateTime> �ift in tliste) Console.WriteLine ("{0}: {1}:{2}", �ift.Key, �ift.Value, �ift.Value.Millisecond);

            Console.WriteLine ("\nAd'a ve maa�'a g�re s�ral� bordro kurma ve sunma:");
            SortedDictionary<string, double> s�ral�Bordro1 = new SortedDictionary<string, double>();
            SortedDictionary<double, string> s�ral�Bordro2 = new SortedDictionary<double, string>();
            for(i=0;i<adlar.Length;i++) {
                ds1=r.Next(7500,100000)+r.Next(0,100)/100D;
                s�ral�Bordro1.Add (adlar [i], ds1);
                s�ral�Bordro2.Add (ds1, adlar [i]);
            }
            Console.WriteLine ("\tAd'a g�re artan s�ral�:");
            foreach (KeyValuePair<string, double> �ift in s�ral�Bordro1) Console.WriteLine ("{0},\tMaa�: {1,9:#,0.00} TL", �ift.Key, �ift.Value);
            Console.WriteLine ("\tMaa�'a g�re artan s�ral�:");
            foreach (KeyValuePair<double, string> �ift in s�ral�Bordro2) Console.WriteLine ("{0},\tMaa�: {1,9:#,0.00} TL", �ift.Value, �ift.Key);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}