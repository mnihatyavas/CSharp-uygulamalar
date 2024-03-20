// j2sc#1402.cs: Environment �evreye dair t�m komutlar �rne�i.

using System;
using System.Collections; //DictionaryEntry i�in
using System.Collections.Generic; //List<T> i�in
using System.Diagnostics; //Process i�in
namespace Geli�imler {
    class �evre {
        static void Main() {
            Console.Write ("Environment �evreye dair t�m komutlar i�lenmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�m �evre komutlar�:");
            Console.WriteLine ("Komut sat�r�: {0}", Environment.CommandLine);
            Console.WriteLine ("Akt�el dizin: {0}", Environment.CurrentDirectory);
            Console.WriteLine ("Bilgisayar�n ad�: {0}", Environment.MachineName);
            Console.WriteLine ("Y���n takibi:\n{0}", Environment.StackTrace);
            Console.WriteLine ("Sistem32 dizini: {0}", Environment.SystemDirectory);
            Console.WriteLine ("Tiktak say�s�: {0}", Environment.TickCount);
            Console.WriteLine ("S�r�m: {0}", Environment.Version);
            Console.WriteLine ("�al��an k�me: {0}", Environment.WorkingSet);
            Console.WriteLine ("\tMant�ksal s�r�c�ler:");
            string[] s�r�c�ler = Environment.GetLogicalDrives();
            int i;
            for(i=0;i<s�r�c�ler.Length;i++) Console.WriteLine ("S�r�c�({0}): {1}", i, s�r�c�ler [i]);
            Console.WriteLine ("\t�evre de�i�kenleri:");
            foreach (DictionaryEntry �d in Environment.GetEnvironmentVariables()) Console.WriteLine ("�vr.d��k ({0}) = {1}", �d.Key, �d.Value);
            Console.WriteLine ("\tKomut sat�r�: [{0}]", Environment.CommandLine); //"c#> j2sc#1402 Mahmut Nihat Yava� Toroslar Mersin" gir
            foreach (string arg in Environment.GetCommandLineArgs()) Console.WriteLine (arg);
            Console.WriteLine ("...alt sat�ra atla==>{0}...alt sat�ra atlad�m.", Environment.NewLine);
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.WriteLine ("\t�zel klas�rlerin adlar� ve yollar�:");
            foreach (Environment.SpecialFolder �k in Enum.GetValues (typeof (Environment.SpecialFolder))) Console.WriteLine ("{0} klas�r�: {1}", �k, Environment.GetFolderPath (�k));
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.WriteLine ("Path = " + Environment.GetEnvironmentVariable ("Path"));
            Console.WriteLine (Environment.ExpandEnvironmentVariables ("%computername% bilgisayar�ndaki yol [%Path%]"));
            Console.WriteLine ("\t�evre de�i�kenleri:");
            IDictionary �dler = Environment.GetEnvironmentVariables (EnvironmentVariableTarget.Process);
            foreach (string �d in �dler.Keys) Console.WriteLine (�d + " = " + �dler [�d]);
            Console.Write ("\nTu�..."); Console.ReadKey();
            AppDomain uygAlan = AppDomain.CurrentDomain;
            Console.WriteLine ("Uygulama alan� bo�alt�m i�in sonlanm�yor mu? {0}\n�evre hen�z kapanmay� ba�latmad� m�? {1}:", !uygAlan.IsFinalizingForUnload(), !Environment.HasShutdownStarted);
            if (!uygAlan.IsFinalizingForUnload() && !Environment.HasShutdownStarted) {
                Console.WriteLine ("Nesnenin ��pe g�nderimi �imdilik ba�ar�s�z!!!");
                Console.WriteLine ("Uygulama alan� nesnesi = {0}", uygAlan);
            }
            Console.WriteLine ("�nceki �evre �al��ma k�mesi: {0}", Environment.WorkingSet);
            Type uriTip = typeof (Uri); //System.dll y�kl� de�ilse y�kler
            Console.WriteLine ("System.dll y�klendikten sonraki �evre �al��ma k�mesi: {0}/{1}", uriTip, Environment.WorkingSet);
            List<AppDomain> uygAlanlar = new List<AppDomain>();
            for(i=0;i<10;i++) {
                AppDomain ua = AppDomain.CreateDomain (i.ToString());
                ua.DoCallBack (delegate {Type t = typeof (Uri);});
                uygAlanlar.Add (ua);
            }
            Console.WriteLine ("System.dll'yi 10 ayr� UygAlan�'na y�kledikten sonraki k�me: {0}", Environment.WorkingSet);
            foreach (AppDomain ua in uygAlanlar) AppDomain.Unload (ua);
            Console.WriteLine ("10 UygAlanbo�ald�ktan sonraki k�me: {0}", Environment.WorkingSet);
            Console.WriteLine ("\tS�k kullan�lanlar �ubu�u klas�r� ve Brave taray�c� a��lacak:");
            string FavoritesYolu = Environment.GetFolderPath (Environment.SpecialFolder.Favorites);
            Console.WriteLine ("Favorites (S�k kullan�lanlar �ubu�u) klas�r�n yolu: {0}", FavoritesYolu);
            Process.Start ("Brave.exe");
            Process.Start (FavoritesYolu);


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}