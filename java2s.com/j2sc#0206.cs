// j2sc#0206.cs: Tamsayý deðeri dizgeye/nesneye kutulama ve tekrar geri kutusuzlama örneði.

using System;
namespace VeriTipleri {
    class TamsayýyýKutulamaKutusuzlama {
        static int kare (object ns) {return (int)ns * (int)ns;}
        public static void Kutu (object ns) {
            Console.WriteLine ("Tamsayýdan kutulananýn deðeri ve tipi = ({0}, {1})", ns, ns.GetType());
            string dzg=ns.ToString(); Console.WriteLine ("Tamsayýdan kutulananýn deðeri ve tipi = ({0}, {1})", dzg, dzg.GetType());
            int ts=(int)ns; Console.WriteLine ("Nesneden kutusuzlananýn deðeri ve tipi = ({0}, {1})", ts, ts.GetTypeCode());
        }
        static void Main() {
            Console.Write ("Bir tamsayý, dizge veya nesne tipli deðiþkene kutulanabilir ve geriye belirtili (int) ile tamsayýya kutusuzlanabilir. Tamsayý, deðer tipli, dizge/nesne ise referans tipli olduðundan birindeki deðiþiklik diðerine yansýmaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tamsayýyý dizgeye kutulama:");
            Console.WriteLine ("2023.GetType(), (2023.ToString()).GetType() = ({0}, {1})", 2023.GetType(), (2023.ToString()).GetType());

            int ts1 = 1881;
            object ns = ts1; // Tamsayý ts1'i nesne ns'ye kutulama
            Console.WriteLine ("\nNesneye kutulanan tamsayýnýn deðeri ve tipi = ({0}, {1})", ns, ns.GetType());
            int ts2 = (int) ns; // Kutulu tamsayý nesneyi tekrar tamsayýya kutusuzlama
            Console.WriteLine ("Kutulanan tamsayý nesnenin tekrar kutusuzlanan deðeri ve tipi = ({0}, {1})", ts2, ts2.GetType());

            ts1 = 1938;
            Console.WriteLine ("\nDeðiþen kutusuz tamsayýnýn ve kutulu nesnenin son deðerleri = ({0}, {1})", ts1, ns);

            var r=new Random();
            Console.WriteLine ("\nTamsayý, object argümana gönderilince otomatikmen kutulanýr.\nSonuç geridönüþünde tekrar tamsayýya kutusuzlanýr.:");
            for (int i=0; i < 5; i++) {ts1=r.Next (-100, 100); Console.WriteLine ("{0} sayýsýnýn karesi = {1}", ts1, kare (ts1));}

            Console.WriteLine ("\n***** Kutu() çaðrýlýyor *****");
            Kutu (ts1);

            Console.WriteLine ("\nTamsayý ve kutulanan nesne ayrý bellek deðiþkenleridir.\nGeniþleyen object=int imaen, daralan int=(int)object alenen çevrilir:");
            ts1=r.Next (-100, 100);
            ns=ts1;
            Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);
            ts1=r.Next (-100, 100); Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);
            ns=r.Next (-100, 100); Console.WriteLine ("int ts: {0}, object ns: {1}", ts1, ns);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}