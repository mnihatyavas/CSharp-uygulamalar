// j2sc#1703.cs: Tlf, eposta, para, sayýsal-kod'larýn geçerlilik testi örneði.

using System;
using System.Text.RegularExpressions;
using System.Reflection; //AssemblyName için
namespace DüzenliÝfade {
    class Düzif {
        public static bool GeçerliEpostaMý (string tümce) {return Regex.IsMatch (tümce, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");}
        static void Main() {
            Console.Write ("Geçerli/geçersiz testi '(Match uyan = Regex.Match (tlf, kalýp)).Success' veya 'düzif.IsMatch (tümce)' ile yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nVerili ve girilen tlfno'larýn geçerli/geçersiz testi:");
            String[] tlfDizi = {"800-888-1211", "212-555-1212", "888-111-1315", "1111-1234-4567", "650-2229-1214"};
            string kalýp = "[0-9]{3}-[0-9]{3}-[0-9]{4}", tümce;
            foreach (String tlf in tlfDizi) {
                Match uyan = Regex.Match (tlf, kalýp);
                if (uyan.Success) Console.WriteLine (tlf+" -->GEÇERLÝ");
                else Console.WriteLine (tlf+" -->GEÇERSÝZ");
            }
            Regex düzif = new Regex (@"^\(\d{3}\)\s\d{3}-\d{4}$");
            Console.Write ("(xxx) xxx-xxxx biçemli tlfno gir: "); tümce = Console.ReadLine();
            while (düzif.Match (tümce).Success == false) {
                Console.WriteLine ("GEÇERSÝZ tlfno, tekrar dene.");
                Console.Write ("(xxx) xxx-xxxx biçemli tlfno gir: "); if((tümce = Console.ReadLine())=="") tümce="(551) 555-6575"; //2 kez Enter'la
            }
            Console.WriteLine (tümce+" -->GEÇERLÝ");

            Console.WriteLine ("\nVerili eposta'larýn geçerli/geçersiz'lik testi:");
            düzif = new Regex (@"\w+@(\w+\.)+\w+"); //@ ve . gerekliliði
            tümce="x@y.com"; Console.WriteLine ("'{0}' geçerli bir eposta mý? {1}", tümce, düzif.IsMatch (tümce)?"Evet":"Hayýr");
            tümce="2024a@xyz.com"; Console.WriteLine ("'{0}' geçerli bir eposta mý? {1}", tümce, düzif.IsMatch (tümce));
            tümce="mny@gmail.mny"; Console.WriteLine ("'{0}' geçerli bir eposta mý? {1}", tümce, düzif.IsMatch (tümce)?"Evet":"Hayýr");
            tümce="eosta@xyzcom"; Console.WriteLine ("'{0}' geçerli bir eposta mý? {1}", tümce, düzif.IsMatch (tümce));
            tümce="mny&gmail.mny"; Console.WriteLine ("'{0}' geçerli bir eposta mý? {1}", tümce, düzif.IsMatch (tümce)?"Evet":"Hayýr");
            string[] epostaDizi = {"a.j@p.com", "d.j@s.p.com", "j@m.p.com", "j.@s.p.com", "mny@hotmail.com"};
            foreach (string eposta in epostaDizi) {
                if (Düzif.GeçerliEpostaMý (eposta)) Console.WriteLine ("\t{0}->GEÇERLÝ", eposta);
                else Console.WriteLine ("\t{0}->GEÇERSÝZ", eposta);
            }

            Console.WriteLine ("\nVerili parasal rakamlarýn geçerlilik testi:");
            kalýp=@"\$\d+\.\d{2}"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            string[] paraDizi = new string[] {"$0.99", "$0.997", "$1099999.00", "$10.2557", "$90,999.99", "$1,990,999.99", "$1,999999.99"};
            foreach (string para in paraDizi) Console.WriteLine ("'{0}' geçerli para temsili mi? {1}", para, düzif.IsMatch (para)?"EVET":"HAYIR");
            kalýp=@"\$(\d{1,3},)*\d+\.\d{2}"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            foreach (string para in paraDizi) Console.WriteLine ("\t'{0}' geçerli para temsili mi? {1}", para, düzif.IsMatch (para)?"EVET":"HAYIR");
            kalýp=@"\$(((\d{1,3},)+\d{3})|\d+)\.\d{2}"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            foreach (string para in paraDizi) Console.WriteLine ("'{0}' geçerli para temsili mi? {1}", para, düzif.IsMatch (para)?"EVET":"HAYIR");
            kalýp=@"\$((\d{1,3},)*\d+)\.(\d{2})"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            foreach (string para in paraDizi) Console.WriteLine ("\t'{0}' geçerli para temsili mi? {1}", para, düzif.IsMatch (para)?"EVET":"HAYIR");

            Console.WriteLine ("\nVerili tireli rakamlarýn geçerlilik testi:");
            kalýp = "[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            string[] sayýDizi = new string[] {"011-01-0111", "abc-01-0111", "0111-01-0111", "011-011-0111", "0111-01-011a"};
            foreach (string sayý in sayýDizi) Console.WriteLine ("'{0}' geçerli sayý temsili mi? {1}", sayý, düzif.IsMatch (sayý)?"EVET":"HAYIR");
            kalýp = "[0-9]{3}-[0-9]{2}-[0-9]{4}"; düzif = new Regex (kalýp); Console.WriteLine ("==>Kullanýlan Regex kalýbý: {0}", kalýp);
            foreach (string sayý in sayýDizi) Console.WriteLine ("\t'{0}' geçerli sayý temsili mi? {1}", sayý, düzif.IsMatch (sayý)?"EVET":"HAYIR");

            Console.WriteLine ("\nÖzel PinNo vr KrediKartNo derleme Regexim.dll dosyasý yaratma:");
            RegexCompilationInfo[] düzifBilgi = new RegexCompilationInfo [2];
            düzifBilgi [0] = new RegexCompilationInfo (@"^\d{4}$", RegexOptions.Compiled, "PinRegex", "", true);
            düzifBilgi [1] = new RegexCompilationInfo (@"^\d{4}-?\d{4}-?\d{4}-?\d{4}$", RegexOptions.Compiled, "CreditCardRegex", "", true);
            AssemblyName kurgu = new AssemblyName();
            kurgu.Name = "Regexim";
            Regex.CompileToAssembly (düzifBilgi, kurgu);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}