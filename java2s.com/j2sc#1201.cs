// j2sc#1201.cs: AppDomain/UygSahasý ile program yükleme, çalýþtýrma ve boþaltma örneði.

using System;
using System.Collections; //ArrayList için
using System.Reflection; //Assembly için
using System.Runtime.Remoting; //ObjectHandle için
namespace Kurulum {
    public class SýnýfNesnesi {public String Göster (String dzg) {return(dzg.ToUpper());}}
    [Serializable]
    public class Sýnýf1 {
        public string UygSahasý {get {return AppDomain.CurrentDomain.FriendlyName;}}
        public String Göster() {return AppDomain.CurrentDomain.FriendlyName;}
    }
    class Kurgu1 {
        public static void uygSahasýnýBoþalt (object gönderen, EventArgs eArg) {Console.WriteLine ("Varsayýlý UygSahasý boþaltýldý!");}
        public static void uygSahasýnýSonlandýr (object gönderen, EventArgs eArg) {Console.WriteLine ("Varsayýlý UygSahasý sonlandýrýldý!");}
        static void Main (string[] giriþler) {
            Console.Write (".\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'AppDomain.CurrentDomain' ile aktüel dosya.exe'ye ulaþýlýr:");
            AppDomain ad1 = AppDomain.CreateDomain ("YeniUygSahasý");
            Console.WriteLine ("AppDomain.CurrentDomain.FriendlyName: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine ("AppDomain.FriendlyName: " + ad1.FriendlyName);

            //c#>j2sc#1201 mahmut nihat yavaþ
            Console.WriteLine ("\nKlavyeden girilen argümanlarla AppDomain iliþkilendirilebilir:");
            AppDomain uygSahasý;
            if (AppDomain.CurrentDomain.FriendlyName != "YeniUygSahasý") {
                uygSahasý = AppDomain.CreateDomain ("YeniUygSahasý");
                uygSahasý.ExecuteAssembly ("j2sc#1201.exe", null, giriþler); //Ýkaz, "obsolete"
            }
            foreach (string grþ in giriþler) Console.WriteLine (AppDomain.CurrentDomain.FriendlyName + ": " + grþ);

            Console.WriteLine ("\nHayvan adlarý listesiyle AppDomain iliþkilendirilebilir:");
            int i, j, ts1, ts2; string ad; var r=new Random();
            uygSahasý = AppDomain.CreateDomain ("Test");
            ArrayList liste = new ArrayList();
            for(i=0;i<5;i++) {
                ad=""; ts1=r.Next(3,11); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                liste.Add (ad);
            }
            uygSahasý.SetData ("Evcil hayvanlar", liste);
            foreach (string hyv in (ArrayList)uygSahasý.GetData ("Evcil hayvanlar")) Console.WriteLine ("  - " + hyv);

            Console.WriteLine ("\nÇalýþtýrýlan c#prog.exe'deki yüklü kurgular:");
            uygSahasý = AppDomain.CurrentDomain;
            Console.WriteLine ("Bu çaðrýyla System.Windows.Forms.dll ve System.dll yüklendi.");
            Assembly[] kurgular = uygSahasý.GetAssemblies();
            Console.WriteLine ("{0} içindeki yüklü kurgular:", uygSahasý.FriendlyName);
            foreach (Assembly kr in kurgular) {
                Console.WriteLine ("-> Ad: {0}", kr.GetName().Name);
                Console.WriteLine ("-> Sürüm: {0}", kr.GetName().Version);
            }

            Console.WriteLine ("\nUygSahasý'ný boþaltma ve iþlemini sonlandýrma:");
            uygSahasý = AppDomain.CreateDomain ("ÝkinciUygSahasý");
            uygSahasý.DomainUnload += new EventHandler (uygSahasýnýBoþalt);
            uygSahasý.ProcessExit +=new EventHandler (uygSahasýnýSonlandýr);
            AppDomain.Unload (uygSahasý);
            AppDomain uygSahasý2 = AppDomain.CreateDomain ("UygSahasýB");
            try {
                Kurgu1 kurgum = (Kurgu1)uygSahasý2.CreateInstanceAndUnwrap ("j2sc#1201", "Kurgu1");
                AppDomain us = AppDomain.CreateDomain ("YeniSaha");
                ObjectHandle nsYnt = us.CreateInstance ("j2sc#1201", "Kurulum.SýnýfNesnesi");
                SýnýfNesnesi sNs = (SýnýfNesnesi) nsYnt.Unwrap();
            } catch{}
            Console.WriteLine (new SýnýfNesnesi().Göster ("Bu tümceyi büyükharfe çevir"));
            uygSahasý = AppDomain.CreateDomain ("Yeni AppDomain");
            try {Sýnýf1 snf1 = (Sýnýf1)uygSahasý.CreateInstanceFromAndUnwrap ("j2sc#1201.exe", "Kurulum.Sýnýf1");
                Console.WriteLine ("snf1'in AppDomain = {0}", snf1.UygSahasý);
            } catch{}
            Console.WriteLine ("snf1'in AppDomain = {0}", new Sýnýf1().UygSahasý);
            Console.WriteLine (AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine (AppDomain.CurrentDomain.GetAssemblies().Length.ToString());
            AppDomain uygSahasý3 = AppDomain.CreateDomain ("Saham");
            uygSahasý3.SetData ("MYVALUE", "new Value");
            Kurulum.Sýnýf1 snf1Tip = (Kurulum.Sýnýf1)uygSahasý3.CreateInstanceFromAndUnwrap ("j2sc#1201.exe", "Kurulum.Sýnýf1");
            Console.WriteLine ("snf1Tip.Göster() = {0}", snf1Tip.Göster());
            AppDomain.Unload (uygSahasý3);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}