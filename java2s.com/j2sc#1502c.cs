// j2sc#1502c.cs: Dizin kopyalama, toplam ebat hesaplama, dizin/altdizin/dosya listeleme �rne�i.

using System;
using System.IO;
namespace S�r�c�Dizin {
    class DirC {
        static void DiziniKopyala (DirectoryInfo kaynak, DirectoryInfo hedef) {
            if (!hedef.Exists) hedef.Create(); //Hedef dizin namevcutsa yarat�r
            else return;
            FileInfo[] dosyalar = kaynak.GetFiles();
            foreach (FileInfo dosya in dosyalar) dosya.CopyTo (Path.Combine (hedef.FullName, dosya.Name)); //Akt�el dizin dosyalar�n� kopyala
            DirectoryInfo[] altdizinler = kaynak.GetDirectories();
            foreach (DirectoryInfo altdizin in altdizinler) {//T�m altdizinler i�in �zyinelemeli �a�r�
                string hedefDizin = Path.Combine (hedef.FullName, altdizin.Name);
                DiziniKopyala (altdizin, new DirectoryInfo (hedefDizin));
            }
            Console.WriteLine ("'{0}'-->'{1}' �zyinelemeli kopyaland�.", kaynak, hedef);
        }
        static long ToplamDizinEbat� (DirectoryInfo dir, bool altdizinlerDahilMi) {
            long toplamEbat = 0;
            FileInfo[] dosyalar = dir.GetFiles();
            foreach (FileInfo dosya in dosyalar) toplamEbat += dosya.Length;
            if (altdizinlerDahilMi) {
                DirectoryInfo[] altdizinler = dir.GetDirectories();
                foreach (DirectoryInfo altdizin in altdizinler) toplamEbat += ToplamDizinEbat� (altdizin, true); //�zyinelemeli �a�r�
            }
            return toplamEbat;
        }
        DirectoryInfo dizinBilgi = null;
        public DirC (string yol) {//Kurucu
            dizinBilgi = new DirectoryInfo (yol);
        }
        public void Akt�elDizinBilgileri() {
            Console.WriteLine ("Yol: {0}", dizinBilgi.FullName);
            Console.WriteLine ("K�k: {0}", dizinBilgi.Root);
            if (dizinBilgi.Parent != null) Console.WriteLine ("Ebeveyn yol: {0}", dizinBilgi.Parent.FullName);
            else Console.WriteLine ("Ebeveyn yol: Yok");
            Console.WriteLine ("Vas�flar: {0}", dizinBilgi.Attributes);
            Console.WriteLine ("Yarat�lma tarihi: {0}", dizinBilgi.CreationTime);
            Console.WriteLine ("Son eri�im tarihi: {0}", dizinBilgi.LastAccessTime);
            Console.WriteLine ("Son g�ncelleme tarihi: {0}", dizinBilgi.LastWriteTime);
            Console.WriteLine ("Altdizin say�s�: {0}", dizinBilgi.GetDirectories().Length);
            foreach (DirectoryInfo altdizin in dizinBilgi.GetDirectories()) Console.WriteLine ("\t{0}", altdizin.Name);
            Console.WriteLine ("Altdizindeki dosya say�s�: {0}", dizinBilgi.GetFiles().Length);
            foreach (FileInfo dosya in dizinBilgi.GetFiles()) Console.WriteLine ("\t{0}", dosya.Name);
        }
        public void DizinAltizinDosyaListele() {Listele (dizinBilgi);}
        private void Listele (DirectoryInfo ilkDizin) {
            int i=0;
            foreach (FileSystemInfo sonraki in ilkDizin.GetFileSystemInfos()) {
                if (sonraki.GetType() == typeof (DirectoryInfo)) {
                    Console.WriteLine ("\t<" + sonraki.Name + ">");
                    i++;
                    Listele ((DirectoryInfo)sonraki); //�zyinelenen �a�r�
                }
                else {Console.WriteLine (sonraki.Name); i++;}
                if(i>20) {Console.Write ("\nTu� veya^C..."); Console.ReadKey(); i=0; Console.WriteLine();}
            }
        }
        static void Main() {
            Console.Write ("'DiziniKopyala (kaynakDizin, hedefDizin)' �zyinelemeli metotla t�m kaynak dizin/altdzinler/dosyalar hedef dizine kopyalan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verilen kaynak dizinin hedef dizine t�m altdizin/dosyalar� kopyalanmas�:");
            DirectoryInfo kaynakDizin = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham");
            DirectoryInfo hedefDizin = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\ham2");
            DiziniKopyala (kaynakDizin, hedefDizin);

            Console.WriteLine ("\nDizin ebat�n�n altdizinsiz/altdizinli hesaplanmas�:");
            DirectoryInfo dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("'{0}' altdizinsiz ebat: {1:#,0} Byte", dir,  ToplamDizinEbat� (dir, false));
            dir = new DirectoryInfo (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#");
            Console.WriteLine ("'{0}' altdizinli ebat: {1:#,0} Byte", dir,  ToplamDizinEbat� (dir, true));

            Console.WriteLine ("\nAkt�el dizin bilgileri ve altdizin/dosya listelenmesi:");
            DirC uyg = new DirC (Directory.GetCurrentDirectory());
            uyg.Akt�elDizinBilgileri();
            uyg.DizinAltizinDosyaListele();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}