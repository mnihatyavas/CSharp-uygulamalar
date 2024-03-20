// j2sc#1402.cs: Environment çevreye dair tüm komutlar örneði.

using System;
using System.Collections; //DictionaryEntry için
using System.Collections.Generic; //List<T> için
using System.Diagnostics; //Process için
namespace Geliþimler {
    class Çevre {
        static void Main() {
            Console.Write ("Environment çevreye dair tüm komutlar iþlenmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm çevre komutlarý:");
            Console.WriteLine ("Komut satýrý: {0}", Environment.CommandLine);
            Console.WriteLine ("Aktüel dizin: {0}", Environment.CurrentDirectory);
            Console.WriteLine ("Bilgisayarýn adý: {0}", Environment.MachineName);
            Console.WriteLine ("Yýðýn takibi:\n{0}", Environment.StackTrace);
            Console.WriteLine ("Sistem32 dizini: {0}", Environment.SystemDirectory);
            Console.WriteLine ("Tiktak sayýsý: {0}", Environment.TickCount);
            Console.WriteLine ("Sürüm: {0}", Environment.Version);
            Console.WriteLine ("Çalýþan küme: {0}", Environment.WorkingSet);
            Console.WriteLine ("\tMantýksal sürücüler:");
            string[] sürücüler = Environment.GetLogicalDrives();
            int i;
            for(i=0;i<sürücüler.Length;i++) Console.WriteLine ("Sürücü({0}): {1}", i, sürücüler [i]);
            Console.WriteLine ("\tÇevre deðiþkenleri:");
            foreach (DictionaryEntry çd in Environment.GetEnvironmentVariables()) Console.WriteLine ("Çvr.dðþk ({0}) = {1}", çd.Key, çd.Value);
            Console.WriteLine ("\tKomut satýrý: [{0}]", Environment.CommandLine); //"c#> j2sc#1402 Mahmut Nihat Yavaþ Toroslar Mersin" gir
            foreach (string arg in Environment.GetCommandLineArgs()) Console.WriteLine (arg);
            Console.WriteLine ("...alt satýra atla==>{0}...alt satýra atladým.", Environment.NewLine);
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.WriteLine ("\tÖzel klasörlerin adlarý ve yollarý:");
            foreach (Environment.SpecialFolder ök in Enum.GetValues (typeof (Environment.SpecialFolder))) Console.WriteLine ("{0} klasörü: {1}", ök, Environment.GetFolderPath (ök));
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.WriteLine ("Path = " + Environment.GetEnvironmentVariable ("Path"));
            Console.WriteLine (Environment.ExpandEnvironmentVariables ("%computername% bilgisayarýndaki yol [%Path%]"));
            Console.WriteLine ("\tÇevre deðiþkenleri:");
            IDictionary çdler = Environment.GetEnvironmentVariables (EnvironmentVariableTarget.Process);
            foreach (string çd in çdler.Keys) Console.WriteLine (çd + " = " + çdler [çd]);
            Console.Write ("\nTuþ..."); Console.ReadKey();
            AppDomain uygAlan = AppDomain.CurrentDomain;
            Console.WriteLine ("Uygulama alaný boþaltým için sonlanmýyor mu? {0}\nÇevre henüz kapanmayý baþlatmadý mý? {1}:", !uygAlan.IsFinalizingForUnload(), !Environment.HasShutdownStarted);
            if (!uygAlan.IsFinalizingForUnload() && !Environment.HasShutdownStarted) {
                Console.WriteLine ("Nesnenin çöpe gönderimi þimdilik baþarýsýz!!!");
                Console.WriteLine ("Uygulama alaný nesnesi = {0}", uygAlan);
            }
            Console.WriteLine ("Önceki çevre çalýþma kümesi: {0}", Environment.WorkingSet);
            Type uriTip = typeof (Uri); //System.dll yüklü deðilse yükler
            Console.WriteLine ("System.dll yüklendikten sonraki çevre çalýþma kümesi: {0}/{1}", uriTip, Environment.WorkingSet);
            List<AppDomain> uygAlanlar = new List<AppDomain>();
            for(i=0;i<10;i++) {
                AppDomain ua = AppDomain.CreateDomain (i.ToString());
                ua.DoCallBack (delegate {Type t = typeof (Uri);});
                uygAlanlar.Add (ua);
            }
            Console.WriteLine ("System.dll'yi 10 ayrý UygAlaný'na yükledikten sonraki küme: {0}", Environment.WorkingSet);
            foreach (AppDomain ua in uygAlanlar) AppDomain.Unload (ua);
            Console.WriteLine ("10 UygAlanboþaldýktan sonraki küme: {0}", Environment.WorkingSet);
            Console.WriteLine ("\tSýk kullanýlanlar Çubuðu klasörü ve Brave tarayýcý açýlacak:");
            string FavoritesYolu = Environment.GetFolderPath (Environment.SpecialFolder.Favorites);
            Console.WriteLine ("Favorites (Sýk kullanýlanlar Çubuðu) klasörün yolu: {0}", FavoritesYolu);
            Process.Start ("Brave.exe");
            Process.Start (FavoritesYolu);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}