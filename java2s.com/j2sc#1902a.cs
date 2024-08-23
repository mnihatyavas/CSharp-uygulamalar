// j2sc#1902a.cs: Type, delegate, EventHandler ve tip.InvokeMember �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Reflection; //MethodInfo ve BindingFlags i�in 
namespace Tipli��lemler {
    delegate void HesapDelegesi (��g�ren i�g, Decimal art��Y�zdesi);
    public class ��g�ren {
        public Decimal Maa�;
        public ��g�ren (Decimal maa�) {Maa� = maa�;} //Kurucu
        public void Zaml�Maa� (Decimal art��Y�zdesi) {Maa� *=(1 + art��Y�zdesi);}
    }
    public class S�n�fA {
        private string metin;
        public string Metin {get {return metin;} set {metin = value; De�i�irse();}}
        private void De�i�irse() {if (De�i�ti != null) De�i�ti (this, System.EventArgs.Empty);}
        public event EventHandler De�i�ti;
    }
    public class S�n�fB {private string metin=null;}
    class Delege {
        private static void De�i�irse (object kaynak, System.EventArgs olay) {Console.WriteLine (((S�n�fA)kaynak).Metin);}
        static void Main() {
            Console.Write ("S�n�f i�i private alan de�eri EventHandler'la d��ardan y�netilebilir; ayr�ca delegesiz, olayy�netimsiz tip.InvokeMember da BindingFlags.NonPublic'le ayn� eri�imi sa�layabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��g�renlerin zams�z ve delegeli hesaplanan %24.3 zaml� maa�lar�:");
            List<��g�ren> i�g�renListesi = new List<��g�ren>();
            var r=new Random(); int i; Decimal ds;
            for(i=0;i<5;i++) {
                ds=r.Next(10000,100000)+r.Next(10,100)/100m;
                i�g�renListesi.Add (new ��g�ren (ds));
            }
            MethodInfo mb = typeof (��g�ren).GetMethod ("Zaml�Maa�", BindingFlags.Public | BindingFlags.Instance);
            HesapDelegesi zaml�Maa�Delegesi = (HesapDelegesi) Delegate.CreateDelegate (typeof (HesapDelegesi), mb);
            foreach (��g�ren i�g in i�g�renListesi) {
                Console.Write ("Zams�z maa�: {0,10:#,0.00} TL", i�g.Maa�);
                zaml�Maa�Delegesi (i�g, (Decimal)0.243);
                Console.WriteLine ("\tZaml� maa�: {0,10:#,0.00} TL", i�g.Maa�);
            }

            Console.WriteLine ("\nPrivate S�n�fA.De�i�irse, olay y�netimli Delege.De�i�irse'yi y�r�t�r:");
            Type tip = typeof (S�n�fA);
            object ns = Activator.CreateInstance (tip);
            EventInfo olayBilgisi = tip.GetEvent ("De�i�ti");
            olayBilgisi.AddEventHandler (ns, new EventHandler (Delege.De�i�irse));
            string[] adlar={"M.Nihat Yava�", "Zafer N. Candan", "Atilla G�kyi�it", "Fatih �zbay", "Y�cel K���kbay"};
            for(i=0;i<5;i++) {((S�n�fA)ns).Metin = adlar [i];}

            Console.WriteLine ("\nPrivate S�n�fB.metin, do�rudan tip.InvokeMember('metin')'le BindingFlags.NonPublic de�er SetField/GetField yap�lmakta:");
            tip = typeof (S�n�fB);
            ns = Activator.CreateInstance (tip);
            for(i=0;i<5;i++) {
                tip.InvokeMember ("metin", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance, null, ns, new object[]{adlar [i]});
                Console.WriteLine ((string)tip.InvokeMember ("metin", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, ns, new object[]{}));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}