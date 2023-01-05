// tpc#21c.cs: Temel s�n�f�n sanal metodunu t�rev s�n�f a��r�y�klemeli metoduyla dinamik �oklu �a��rma �rne�i.

using System;
namespace �oklubi�im {
    class �ekil {
        protected int en, boy;
        public �ekil (int e = 0, int b = 0) {en = e; boy = b;}
        public virtual int alan() {Console.WriteLine ("\nEbeveyn s�n�f�n sanal alan() metodu:"); return 0;} // Fiili �a�r�lmaz
    }
    class Dikd�rtgen: �ekil {
        public Dikd�rtgen (int e = 0, int b = 0): base (e, b) {}
        public override int alan () {Console.WriteLine ("\n\nDikd�rtgen s�n�f�n�n alan() metodu:"); return (en * boy);}
    }
    class Dik��gen: �ekil {
        public Dik��gen (int e = 0, int b = 0): base (e, b) {}
        public override int alan() {Console.WriteLine ("\nDik��gen s�n�f�n�n alan() metodu:"); return (en * boy / 2);}
    }
    class �a��ran {public void alan��a��ran (�ekil �) {Console.WriteLine ("Alan: {0}", �.alan());} } 
    class DinamikSanalMetod {
        static void Main() {
            Console.Write ("Farkl� t�rev s�n�flarda farkl� bi�imde kullan�lacak a��r�y�klenen fonksiyon temel s�n�fta virtual/sanal ve i�i bo� kal�p olarak tan�mlan�r. Dinamik �oklubi�im soyut ve sanal fonksiyonlarca y�r�t�l�r.\nTu�..."); Console.ReadKey();

            �a��ran � = new �a��ran();
            Dikd�rtgen dd = new Dikd�rtgen (15, 6);
            Dik��gen d� = new Dik��gen (15, 6);
            �.alan��a��ran (dd);
            �.alan��a��ran (d�);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}