// j2sc#0722i.cs: ~S�n�f' bask�layan using'li/siz istemli S�n�f.Dispose() tipleme silme �rne�i.

using System;
using System.IO; //FileStream i�in
namespace S�n�flar {
    public class S�n�f1 : IDisposable {
        public S�n�f1(){}
        ~S�n�f1() {Console.WriteLine ("~S�n�f1 otomatik y�k�c�");} //Otomatik y�k�c�
        public void Dispose() {Console.WriteLine ("�stemli S�n�f1.Dispose() y�k�c�"); /*GC.SuppressFinalize (this);*/}
    }
    public class S�n�f2 {}
    class S�n�f3 : IDisposable {
        ~S�n�f3() {Console.WriteLine ("~S�n�f3 otomatik y�k�c�");}
        private FileStream ak�� = /*null*/ File.Create ("veri.dat");
        public void Dispose() {
            FileStream da = ak��;
            if (da != null) {
                ((IDisposable)da).Dispose();
                Console.WriteLine ("�stemli FileStream.Dispose() y�k�c�");
            }
            Console.WriteLine ("�stemli S�n�f3.Dispose() y�k�c�");
        }
    }
    class S�n�f4: IDisposable {
        private bool At�ld�M� = false;
        public void Dispose() {
           At (true);
           GC.SuppressFinalize (this);
        }
        private void At (bool at�l�yor) {
           if (!this.At�ld�M�) {if (at�l�yor) {Console.WriteLine ("S�n�f4.Dispose() at�l�yor");}}
           At�ld�M� = true;
        }
        ~S�n�f4() {At (false);} //Bask�land���ndan etkisiz
    }
    class S�n�f5 : IDisposable {
        private IntPtr kontrol = (IntPtr)20231122;
        ~S�n�f5() {Sil();}
        public void Dispose() {Sil(); GC.SuppressFinalize (this);}
        protected void Sil() {IntPtr k = kontrol; if (k == (IntPtr)20231122) {Console.WriteLine ("S�n�f5.Dispose() at�l�yor"); k = IntPtr.Zero;}}
    }
    class �e�itli9 {
        static void Main() {
            Console.Write ("~S�n�f, program sonlan�rken t�m S�n�f tiplemelerini otomatikmen temizler. IDisposable mirasl� s�n�f�n using tiplemeleri using blo�u hitam�nda otomatikmen �a�r�l�r. using'siz ise istemli �a�r�lmal�d�r. S�n�f i�i Dispose() metodunda 'GC.SuppressFinalize (this)' kullan�m� otomatik ~Y�k�c�'y� etkisizle�tirir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("~S�n�f1, Dispose()'la using'li S�n�f1 ve using'siz S�n�f1 tiplemeleri:");
            var r=new Random(); int i;
            using (S�n�f1 s1a = new S�n�f1()){} //using ��k��� Dispose() otomatikmen �a�r�l�r
            S�n�f1 s1b;
            for(i=0;i<5;i++) {
                s1b = new S�n�f1();
                s1b.Dispose(); //�stemli Dispose()
            }
            //using (S�n�f2 s2a = new S�n�f2()){} //IDisposable ebeveynsiz using derleme hatas� verir

            Console.WriteLine ("\n�stemli FileStream ve S�n�f3 at�klar�:");
            using (S�n�f3 s3a = new S�n�f3()){}
            S�n�f3 s3b=new S�n�f3();
            s3b.Dispose();

            Console.WriteLine ("\n~S�n�f4'� bask�layan bool kontrollu S�n�f4.Dispose():");
            S�n�f4 s4;
            for(i=0;i<5;i++) {
                s4 = new S�n�f4();
                s4.Dispose(); //�stemli ve ~S�n�f4 iptalli Dispose()
            }

            Console.WriteLine ("\n~S�n�f5'i bask�layan IntPtr kontrollu S�n�f5.Dispose():");
            using (S�n�f5 s5a = new S�n�f5()){} using (S�n�f5 s5b = new S�n�f5()){} using (S�n�f5 s5c = new S�n�f5()){} using (S�n�f5 s5d = new S�n�f5()){} using (S�n�f5 s5e = new S�n�f5()){}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}