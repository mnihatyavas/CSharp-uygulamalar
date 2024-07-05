// j2sc#1502c.cs: Dizin kopyalama, toplam ebat hesaplama, dizin/altdizin/dosya listeleme örneði.

using System;
using System.IO;
namespace SürücüDizin {
    class DirC {
        static void DiziniKopyala (DirectoryInfo kaynak, DirectoryInfo hedef) {
            if (!hedef.Exists) hedef.Create(); //Hedef dizin namevcutsa yaratýr
            else return;
            FileInfo[] dosyalar = kaynak.GetFiles();
            foreach (FileInfo dosya in dosyalar) dosya.CopyTo (Path.Combine (hedef.FullName, dosya.Name)); //Aktüel dizin dosyalarýný kopyala
            DirectoryInfo[] altdizinler = kaynak.GetDirectories();
            foreach (DirectoryInfo altdizin in altdizinler) {//Tüm altdizinler için özyinelemeli çaðrý
                string hedefDizin = Path.Combine (hedef.FullName, altdizin.Name);
                DiziniKopyala (altdizin, new DirectoryInfo (hedefDizin));
            }
            Console.WriteLine ("'{0}'-->'{1}' özyinelemeli kopyalandý.", kaynak, hedef);
        }
        static long ToplamDizinEbatý (DirectoryInfo dir, bool altdizinlerDahilMi) {
            long toplamEbat = 0;
            FileInfo[] dosyalar = dir.GetFiles();
            foreach (FileInfo dosya in dosyalar) toplamEbat += dosya.Length;
            if (altdizinlerDahilMi) {
                DirectoryInfo[] altdizinler = dir.GetDirectories();
                foreach (DirectoryInfo altdizin in altdizinler) toplamEbat += ToplamDizinEbatý (altdizin, true); //Özyinelemeli çaðrý
            }
            return toplamEbat;
        }
        DirectoryInfo dizinBilgi = null;
        public DirC (string yol) {//Kurucu
            dizinBilgi = new DirectoryInfo (yol);
        }
        public void AktüelDizinBilgileri() {
            Console.WriteLine ("Yol: {0}", dizinBilgi.FullName);
            Console.WriteLine ("Kök: {0}", dizinBilgi.Root);
            if (dizinBilgi.Parent != null) Console.WriteLine ("Ebeveyn yol: {0}", dizinBilgi.Parent.FullName);
            else Console.WriteLine ("Ebeveyn yol: Yok");
            Console.WriteLine ("Vasýflar: {0}", dizinBilgi.Attributes);
            Console.WriteLine ("Yaratýlma tarihi: {0}", dizinBilgi.CreationTime);
            Console.WriteLine ("Son eriþim tarihi: {0}", dizinBilgi.LastAccessTime);
            Console.WriteLine ("Son güncelleme tarihi: {0}", dizinBilgi.LastWriteTime);
            Console.WriteLine ("Altdizin sayýsý: {0}", dizinBilgi.GetDirectories().Length);
            foreach (DirectoryInfo altdizin in dizinBilgi.GetDirectories()) Console.WriteLine ("\t{0}", altdizin.Name);
            Console.WriteLine ("Altdizindeki dosya sayýsý: {0}", dizinBilgi.GetFiles().Length);
            foreach (FileInfo dosya in dizinBilgi.GetFiles()) Console.WriteLine ("\t{0}", dosya.Name);
        }
        public void DizinAltizinDosyaListele() {Listele (dizinBilgi);}
        private void Listele (DirectoryInfo ilkDizin) {
            int i=0;
            foreach (FileSystemInfo sonraki in ilkDizin.GetFileSystemInfos()) {
                if (sonraki.GetType() == typeof (DirectoryInfo)) {
                    Console.WriteLine ("\t<" + sonraki.Name + ">");
                    i++;
                    Listele ((DirectoryInfo)sonraki); //Özyinelenen çaðrý
                }
                else {Console.WriteLine (sonraki.Name); i++;}
                if(i>20) {Console.Write ("\nTuþ veya^C..."); Console.ReadKey(); i=0; Console.WriteLine();}
            }
        }
        static void Main() {
            Console.Write ("'DiziniKopyala (kaynakDizin, hedefDizin)' özyinelemeli metotla tüm kaynak dizin/altdzinler/dosyalar hedef dizine kopyalanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verilen kaynak dizinin hedef dizine tüm altdizin/dosyalarý kopyalanmasý:");
            DirectoryInfo kaynakDizin = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham");
            DirectoryInfo hedefDizin = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham2");
            DiziniKopyala (kaynakDizin, hedefDizin);

            Console.WriteLine ("\nDizin ebatýnýn altdizinsiz/altdizinli hesaplanmasý:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("'{0}' altdizinsiz ebat: {1:#,0} Byte", dir,  ToplamDizinEbatý (dir, false));
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("'{0}' altdizinli ebat: {1:#,0} Byte", dir,  ToplamDizinEbatý (dir, true));

            Console.WriteLine ("\nAktüel dizin bilgileri ve altdizin/dosya listelenmesi:");
            DirC uyg = new DirC (Directory.GetCurrentDirectory());
            uyg.AktüelDizinBilgileri();
            uyg.DizinAltizinDosyaListele();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}