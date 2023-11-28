// j2sc#0722i.cs: ~Sýnýf' baskýlayan using'li/siz istemli Sýnýf.Dispose() tipleme silme örneði.

using System;
using System.IO; //FileStream için
namespace Sýnýflar {
    public class Sýnýf1 : IDisposable {
        public Sýnýf1(){}
        ~Sýnýf1() {Console.WriteLine ("~Sýnýf1 otomatik yýkýcý");} //Otomatik yýkýcý
        public void Dispose() {Console.WriteLine ("Ýstemli Sýnýf1.Dispose() yýkýcý"); /*GC.SuppressFinalize (this);*/}
    }
    public class Sýnýf2 {}
    class Sýnýf3 : IDisposable {
        ~Sýnýf3() {Console.WriteLine ("~Sýnýf3 otomatik yýkýcý");}
        private FileStream akýþ = /*null*/ File.Create ("veri.dat");
        public void Dispose() {
            FileStream da = akýþ;
            if (da != null) {
                ((IDisposable)da).Dispose();
                Console.WriteLine ("Ýstemli FileStream.Dispose() yýkýcý");
            }
            Console.WriteLine ("Ýstemli Sýnýf3.Dispose() yýkýcý");
        }
    }
    class Sýnýf4: IDisposable {
        private bool AtýldýMý = false;
        public void Dispose() {
           At (true);
           GC.SuppressFinalize (this);
        }
        private void At (bool atýlýyor) {
           if (!this.AtýldýMý) {if (atýlýyor) {Console.WriteLine ("Sýnýf4.Dispose() atýlýyor");}}
           AtýldýMý = true;
        }
        ~Sýnýf4() {At (false);} //Baskýlandýðýndan etkisiz
    }
    class Sýnýf5 : IDisposable {
        private IntPtr kontrol = (IntPtr)20231122;
        ~Sýnýf5() {Sil();}
        public void Dispose() {Sil(); GC.SuppressFinalize (this);}
        protected void Sil() {IntPtr k = kontrol; if (k == (IntPtr)20231122) {Console.WriteLine ("Sýnýf5.Dispose() atýlýyor"); k = IntPtr.Zero;}}
    }
    class Çeþitli9 {
        static void Main() {
            Console.Write ("~Sýnýf, program sonlanýrken tüm Sýnýf tiplemelerini otomatikmen temizler. IDisposable miraslý sýnýfýn using tiplemeleri using bloðu hitamýnda otomatikmen çaðrýlýr. using'siz ise istemli çaðrýlmalýdýr. Sýnýf içi Dispose() metodunda 'GC.SuppressFinalize (this)' kullanýmý otomatik ~Yýkýcý'yý etkisizleþtirir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("~Sýnýf1, Dispose()'la using'li Sýnýf1 ve using'siz Sýnýf1 tiplemeleri:");
            var r=new Random(); int i;
            using (Sýnýf1 s1a = new Sýnýf1()){} //using çýkýþý Dispose() otomatikmen çaðrýlýr
            Sýnýf1 s1b;
            for(i=0;i<5;i++) {
                s1b = new Sýnýf1();
                s1b.Dispose(); //Ýstemli Dispose()
            }
            //using (Sýnýf2 s2a = new Sýnýf2()){} //IDisposable ebeveynsiz using derleme hatasý verir

            Console.WriteLine ("\nÝstemli FileStream ve Sýnýf3 atýklarý:");
            using (Sýnýf3 s3a = new Sýnýf3()){}
            Sýnýf3 s3b=new Sýnýf3();
            s3b.Dispose();

            Console.WriteLine ("\n~Sýnýf4'ü baskýlayan bool kontrollu Sýnýf4.Dispose():");
            Sýnýf4 s4;
            for(i=0;i<5;i++) {
                s4 = new Sýnýf4();
                s4.Dispose(); //Ýstemli ve ~Sýnýf4 iptalli Dispose()
            }

            Console.WriteLine ("\n~Sýnýf5'i baskýlayan IntPtr kontrollu Sýnýf5.Dispose():");
            using (Sýnýf5 s5a = new Sýnýf5()){} using (Sýnýf5 s5b = new Sýnýf5()){} using (Sýnýf5 s5c = new Sýnýf5()){} using (Sýnýf5 s5d = new Sýnýf5()){} using (Sýnýf5 s5e = new Sýnýf5()){}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}