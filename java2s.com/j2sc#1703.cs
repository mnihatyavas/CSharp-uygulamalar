// j2sc#1703.cs: Tlf, eposta, para, say�sal-kod'lar�n ge�erlilik testi �rne�i.

using System;
using System.Text.RegularExpressions;
using System.Reflection; //AssemblyName i�in
namespace D�zenli�fade {
    class D�zif {
        public static bool Ge�erliEpostaM� (string t�mce) {return Regex.IsMatch (t�mce, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");}
        static void Main() {
            Console.Write ("Ge�erli/ge�ersiz testi '(Match uyan = Regex.Match (tlf, kal�p)).Success' veya 'd�zif.IsMatch (t�mce)' ile yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nVerili ve girilen tlfno'lar�n ge�erli/ge�ersiz testi:");
            String[] tlfDizi = {"800-888-1211", "212-555-1212", "888-111-1315", "1111-1234-4567", "650-2229-1214"};
            string kal�p = "[0-9]{3}-[0-9]{3}-[0-9]{4}", t�mce;
            foreach (String tlf in tlfDizi) {
                Match uyan = Regex.Match (tlf, kal�p);
                if (uyan.Success) Console.WriteLine (tlf+" -->GE�ERL�");
                else Console.WriteLine (tlf+" -->GE�ERS�Z");
            }
            Regex d�zif = new Regex (@"^\(\d{3}\)\s\d{3}-\d{4}$");
            Console.Write ("(xxx) xxx-xxxx bi�emli tlfno gir: "); t�mce = Console.ReadLine();
            while (d�zif.Match (t�mce).Success == false) {
                Console.WriteLine ("GE�ERS�Z tlfno, tekrar dene.");
                Console.Write ("(xxx) xxx-xxxx bi�emli tlfno gir: "); if((t�mce = Console.ReadLine())=="") t�mce="(551) 555-6575"; //2 kez Enter'la
            }
            Console.WriteLine (t�mce+" -->GE�ERL�");

            Console.WriteLine ("\nVerili eposta'lar�n ge�erli/ge�ersiz'lik testi:");
            d�zif = new Regex (@"\w+@(\w+\.)+\w+"); //@ ve . gereklili�i
            t�mce="x@y.com"; Console.WriteLine ("'{0}' ge�erli bir eposta m�? {1}", t�mce, d�zif.IsMatch (t�mce)?"Evet":"Hay�r");
            t�mce="2024a@xyz.com"; Console.WriteLine ("'{0}' ge�erli bir eposta m�? {1}", t�mce, d�zif.IsMatch (t�mce));
            t�mce="mny@gmail.mny"; Console.WriteLine ("'{0}' ge�erli bir eposta m�? {1}", t�mce, d�zif.IsMatch (t�mce)?"Evet":"Hay�r");
            t�mce="eosta@xyzcom"; Console.WriteLine ("'{0}' ge�erli bir eposta m�? {1}", t�mce, d�zif.IsMatch (t�mce));
            t�mce="mny&gmail.mny"; Console.WriteLine ("'{0}' ge�erli bir eposta m�? {1}", t�mce, d�zif.IsMatch (t�mce)?"Evet":"Hay�r");
            string[] epostaDizi = {"a.j@p.com", "d.j@s.p.com", "j@m.p.com", "j.@s.p.com", "mny@hotmail.com"};
            foreach (string eposta in epostaDizi) {
                if (D�zif.Ge�erliEpostaM� (eposta)) Console.WriteLine ("\t{0}->GE�ERL�", eposta);
                else Console.WriteLine ("\t{0}->GE�ERS�Z", eposta);
            }

            Console.WriteLine ("\nVerili parasal rakamlar�n ge�erlilik testi:");
            kal�p=@"\$\d+\.\d{2}"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            string[] paraDizi = new string[] {"$0.99", "$0.997", "$1099999.00", "$10.2557", "$90,999.99", "$1,990,999.99", "$1,999999.99"};
            foreach (string para in paraDizi) Console.WriteLine ("'{0}' ge�erli para temsili mi? {1}", para, d�zif.IsMatch (para)?"EVET":"HAYIR");
            kal�p=@"\$(\d{1,3},)*\d+\.\d{2}"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            foreach (string para in paraDizi) Console.WriteLine ("\t'{0}' ge�erli para temsili mi? {1}", para, d�zif.IsMatch (para)?"EVET":"HAYIR");
            kal�p=@"\$(((\d{1,3},)+\d{3})|\d+)\.\d{2}"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            foreach (string para in paraDizi) Console.WriteLine ("'{0}' ge�erli para temsili mi? {1}", para, d�zif.IsMatch (para)?"EVET":"HAYIR");
            kal�p=@"\$((\d{1,3},)*\d+)\.(\d{2})"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            foreach (string para in paraDizi) Console.WriteLine ("\t'{0}' ge�erli para temsili mi? {1}", para, d�zif.IsMatch (para)?"EVET":"HAYIR");

            Console.WriteLine ("\nVerili tireli rakamlar�n ge�erlilik testi:");
            kal�p = "[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            string[] say�Dizi = new string[] {"011-01-0111", "abc-01-0111", "0111-01-0111", "011-011-0111", "0111-01-011a"};
            foreach (string say� in say�Dizi) Console.WriteLine ("'{0}' ge�erli say� temsili mi? {1}", say�, d�zif.IsMatch (say�)?"EVET":"HAYIR");
            kal�p = "[0-9]{3}-[0-9]{2}-[0-9]{4}"; d�zif = new Regex (kal�p); Console.WriteLine ("==>Kullan�lan Regex kal�b�: {0}", kal�p);
            foreach (string say� in say�Dizi) Console.WriteLine ("\t'{0}' ge�erli say� temsili mi? {1}", say�, d�zif.IsMatch (say�)?"EVET":"HAYIR");

            Console.WriteLine ("\n�zel PinNo vr KrediKartNo derleme Regexim.dll dosyas� yaratma:");
            RegexCompilationInfo[] d�zifBilgi = new RegexCompilationInfo [2];
            d�zifBilgi [0] = new RegexCompilationInfo (@"^\d{4}$", RegexOptions.Compiled, "PinRegex", "", true);
            d�zifBilgi [1] = new RegexCompilationInfo (@"^\d{4}-?\d{4}-?\d{4}-?\d{4}$", RegexOptions.Compiled, "CreditCardRegex", "", true);
            AssemblyName kurgu = new AssemblyName();
            kurgu.Name = "Regexim";
            Regex.CompileToAssembly (d�zifBilgi, kurgu);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}