// j2sc#1201.cs: AppDomain/UygSahas� ile program y�kleme, �al��t�rma ve bo�altma �rne�i.

using System;
using System.Collections; //ArrayList i�in
using System.Reflection; //Assembly i�in
using System.Runtime.Remoting; //ObjectHandle i�in
namespace Kurulum {
    public class S�n�fNesnesi {public String G�ster (String dzg) {return(dzg.ToUpper());}}
    [Serializable]
    public class S�n�f1 {
        public string UygSahas� {get {return AppDomain.CurrentDomain.FriendlyName;}}
        public String G�ster() {return AppDomain.CurrentDomain.FriendlyName;}
    }
    class Kurgu1 {
        public static void uygSahas�n�Bo�alt (object g�nderen, EventArgs eArg) {Console.WriteLine ("Varsay�l� UygSahas� bo�alt�ld�!");}
        public static void uygSahas�n�Sonland�r (object g�nderen, EventArgs eArg) {Console.WriteLine ("Varsay�l� UygSahas� sonland�r�ld�!");}
        static void Main (string[] giri�ler) {
            Console.Write (".\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'AppDomain.CurrentDomain' ile akt�el dosya.exe'ye ula��l�r:");
            AppDomain ad1 = AppDomain.CreateDomain ("YeniUygSahas�");
            Console.WriteLine ("AppDomain.CurrentDomain.FriendlyName: " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine ("AppDomain.FriendlyName: " + ad1.FriendlyName);

            //c#>j2sc#1201 mahmut nihat yava�
            Console.WriteLine ("\nKlavyeden girilen arg�manlarla AppDomain ili�kilendirilebilir:");
            AppDomain uygSahas�;
            if (AppDomain.CurrentDomain.FriendlyName != "YeniUygSahas�") {
                uygSahas� = AppDomain.CreateDomain ("YeniUygSahas�");
                uygSahas�.ExecuteAssembly ("j2sc#1201.exe", null, giri�ler); //�kaz, "obsolete"
            }
            foreach (string gr� in giri�ler) Console.WriteLine (AppDomain.CurrentDomain.FriendlyName + ": " + gr�);

            Console.WriteLine ("\nHayvan adlar� listesiyle AppDomain ili�kilendirilebilir:");
            int i, j, ts1, ts2; string ad; var r=new Random();
            uygSahas� = AppDomain.CreateDomain ("Test");
            ArrayList liste = new ArrayList();
            for(i=0;i<5;i++) {
                ad=""; ts1=r.Next(3,11); for(j=0;j<ts1;j++) {ts2=r.Next(0,26); ad+=(char)(65+ts2);}
                liste.Add (ad);
            }
            uygSahas�.SetData ("Evcil hayvanlar", liste);
            foreach (string hyv in (ArrayList)uygSahas�.GetData ("Evcil hayvanlar")) Console.WriteLine ("  - " + hyv);

            Console.WriteLine ("\n�al��t�r�lan c#prog.exe'deki y�kl� kurgular:");
            uygSahas� = AppDomain.CurrentDomain;
            Console.WriteLine ("Bu �a�r�yla System.Windows.Forms.dll ve System.dll y�klendi.");
            Assembly[] kurgular = uygSahas�.GetAssemblies();
            Console.WriteLine ("{0} i�indeki y�kl� kurgular:", uygSahas�.FriendlyName);
            foreach (Assembly kr in kurgular) {
                Console.WriteLine ("-> Ad: {0}", kr.GetName().Name);
                Console.WriteLine ("-> S�r�m: {0}", kr.GetName().Version);
            }

            Console.WriteLine ("\nUygSahas�'n� bo�altma ve i�lemini sonland�rma:");
            uygSahas� = AppDomain.CreateDomain ("�kinciUygSahas�");
            uygSahas�.DomainUnload += new EventHandler (uygSahas�n�Bo�alt);
            uygSahas�.ProcessExit +=new EventHandler (uygSahas�n�Sonland�r);
            AppDomain.Unload (uygSahas�);
            AppDomain uygSahas�2 = AppDomain.CreateDomain ("UygSahas�B");
            try {
                Kurgu1 kurgum = (Kurgu1)uygSahas�2.CreateInstanceAndUnwrap ("j2sc#1201", "Kurgu1");
                AppDomain us = AppDomain.CreateDomain ("YeniSaha");
                ObjectHandle nsYnt = us.CreateInstance ("j2sc#1201", "Kurulum.S�n�fNesnesi");
                S�n�fNesnesi sNs = (S�n�fNesnesi) nsYnt.Unwrap();
            } catch{}
            Console.WriteLine (new S�n�fNesnesi().G�ster ("Bu t�mceyi b�y�kharfe �evir"));
            uygSahas� = AppDomain.CreateDomain ("Yeni AppDomain");
            try {S�n�f1 snf1 = (S�n�f1)uygSahas�.CreateInstanceFromAndUnwrap ("j2sc#1201.exe", "Kurulum.S�n�f1");
                Console.WriteLine ("snf1'in AppDomain = {0}", snf1.UygSahas�);
            } catch{}
            Console.WriteLine ("snf1'in AppDomain = {0}", new S�n�f1().UygSahas�);
            Console.WriteLine (AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine (AppDomain.CurrentDomain.GetAssemblies().Length.ToString());
            AppDomain uygSahas�3 = AppDomain.CreateDomain ("Saham");
            uygSahas�3.SetData ("MYVALUE", "new Value");
            Kurulum.S�n�f1 snf1Tip = (Kurulum.S�n�f1)uygSahas�3.CreateInstanceFromAndUnwrap ("j2sc#1201.exe", "Kurulum.S�n�f1");
            Console.WriteLine ("snf1Tip.G�ster() = {0}", snf1Tip.G�ster());
            AppDomain.Unload (uygSahas�3);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}