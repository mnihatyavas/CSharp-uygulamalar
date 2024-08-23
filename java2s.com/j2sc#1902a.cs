// j2sc#1902a.cs: Type, delegate, EventHandler ve tip.InvokeMember örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Reflection; //MethodInfo ve BindingFlags için 
namespace TipliÝþlemler {
    delegate void HesapDelegesi (Ýþgören iþg, Decimal artýþYüzdesi);
    public class Ýþgören {
        public Decimal Maaþ;
        public Ýþgören (Decimal maaþ) {Maaþ = maaþ;} //Kurucu
        public void ZamlýMaaþ (Decimal artýþYüzdesi) {Maaþ *=(1 + artýþYüzdesi);}
    }
    public class SýnýfA {
        private string metin;
        public string Metin {get {return metin;} set {metin = value; Deðiþirse();}}
        private void Deðiþirse() {if (Deðiþti != null) Deðiþti (this, System.EventArgs.Empty);}
        public event EventHandler Deðiþti;
    }
    public class SýnýfB {private string metin=null;}
    class Delege {
        private static void Deðiþirse (object kaynak, System.EventArgs olay) {Console.WriteLine (((SýnýfA)kaynak).Metin);}
        static void Main() {
            Console.Write ("Sýnýf içi private alan deðeri EventHandler'la dýþardan yönetilebilir; ayrýca delegesiz, olayyönetimsiz tip.InvokeMember da BindingFlags.NonPublic'le ayný eriþimi saðlayabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýþgörenlerin zamsýz ve delegeli hesaplanan %24.3 zamlý maaþlarý:");
            List<Ýþgören> iþgörenListesi = new List<Ýþgören>();
            var r=new Random(); int i; Decimal ds;
            for(i=0;i<5;i++) {
                ds=r.Next(10000,100000)+r.Next(10,100)/100m;
                iþgörenListesi.Add (new Ýþgören (ds));
            }
            MethodInfo mb = typeof (Ýþgören).GetMethod ("ZamlýMaaþ", BindingFlags.Public | BindingFlags.Instance);
            HesapDelegesi zamlýMaaþDelegesi = (HesapDelegesi) Delegate.CreateDelegate (typeof (HesapDelegesi), mb);
            foreach (Ýþgören iþg in iþgörenListesi) {
                Console.Write ("Zamsýz maaþ: {0,10:#,0.00} TL", iþg.Maaþ);
                zamlýMaaþDelegesi (iþg, (Decimal)0.243);
                Console.WriteLine ("\tZamlý maaþ: {0,10:#,0.00} TL", iþg.Maaþ);
            }

            Console.WriteLine ("\nPrivate SýnýfA.Deðiþirse, olay yönetimli Delege.Deðiþirse'yi yürütür:");
            Type tip = typeof (SýnýfA);
            object ns = Activator.CreateInstance (tip);
            EventInfo olayBilgisi = tip.GetEvent ("Deðiþti");
            olayBilgisi.AddEventHandler (ns, new EventHandler (Delege.Deðiþirse));
            string[] adlar={"M.Nihat Yavaþ", "Zafer N. Candan", "Atilla Gökyiðit", "Fatih Özbay", "Yücel Küçükbay"};
            for(i=0;i<5;i++) {((SýnýfA)ns).Metin = adlar [i];}

            Console.WriteLine ("\nPrivate SýnýfB.metin, doðrudan tip.InvokeMember('metin')'le BindingFlags.NonPublic deðer SetField/GetField yapýlmakta:");
            tip = typeof (SýnýfB);
            ns = Activator.CreateInstance (tip);
            for(i=0;i<5;i++) {
                tip.InvokeMember ("metin", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance, null, ns, new object[]{adlar [i]});
                Console.WriteLine ((string)tip.InvokeMember ("metin", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance, null, ns, new object[]{}));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}