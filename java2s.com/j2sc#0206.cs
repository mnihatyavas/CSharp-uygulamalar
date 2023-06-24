// j2sc#0206.cs: Tamsay� de�eri dizgeye/nesneye kutulama ve tekrar geri kutusuzlama �rne�i.

using System;
namespace VeriTipleri {
    class Tamsay�y�KutulamaKutusuzlama {
        static int kare (object ns) {return (int)ns * (int)ns;}
        public static void Kutu (object ns) {
            Console.WriteLine ("Tamsay�dan kutulanan�n de�eri ve tipi = ({0}, {1})", ns, ns.GetType());
            string dzg=ns.ToString(); Console.WriteLine ("Tamsay�dan kutulanan�n de�eri ve tipi = ({0}, {1})", dzg, dzg.GetType());
            int ts=(int)ns; Console.WriteLine ("Nesneden kutusuzlanan�n de�eri ve tipi = ({0}, {1})", ts, ts.GetTypeCode());
        }
        static void Main() {
            Console.Write ("Bir tamsay�, dizge veya nesne tipli de�i�kene kutulanabilir ve geriye belirtili (int) ile tamsay�ya kutusuzlanabilir. Tamsay�, de�er tipli, dizge/nesne ise referans tipli oldu�undan birindeki de�i�iklik di�erine yans�maz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tamsay�y� dizgeye kutulama:");
            Console.WriteLine ("2023.GetType(), (2023.ToString()).GetType() = ({0}, {1})", 2023.GetType(), (2023.ToString()).GetType());

            int ts1 = 1881;
            object ns = ts1; // Tamsay� ts1'i nesne ns'ye kutulama
            Console.WriteLine ("\nNesneye kutulanan tamsay�n�n de�eri ve tipi = ({0}, {1})", ns, ns.GetType());
            int ts2 = (int) ns; // Kutulu tamsay� nesneyi tekrar tamsay�ya kutusuzlama
            Console.WriteLine ("Kutulanan tamsay� nesnenin tekrar kutusuzlanan de�eri ve tipi = ({0}, {1})", ts2, ts2.GetType());

            ts1 = 1938;
            Console.WriteLine ("\nDe�i�en kutusuz tamsay�n�n ve kutulu nesnenin son de�erleri = ({0}, {1})", ts1, ns);

            var r=new Random();
            Console.WriteLine ("\nTamsay�, object arg�mana g�nderilince otomatikmen kutulan�r.\nSonu� gerid�n���nde tekrar tamsay�ya kutusuzlan�r.:");
            for (int i=0; i < 5; i++) {ts1=r.Next (-100, 100); Console.WriteLine ("{0} say�s�n�n karesi = {1}", ts1, kare (ts1));}

            Console.WriteLine ("\n***** Kutu() �a�r�l�yor *****");
            Kutu (ts1);

            Console.WriteLine ("\nTamsay� ve kutulanan nesne ayr� bellek de�i�kenleridir.\nGeni�leyen object=int imaen, daralan int=(int)object alenen �evrilir:");
            ts1=r.Next (-100, 100);
            ns=ts1;
            Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);
            ts1=r.Next (-100, 100); Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);
            ns=r.Next (-100, 100); Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}