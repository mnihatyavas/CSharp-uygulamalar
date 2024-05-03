// j2sc#1408c.cs: BitConverter, Context, derleme warning/ikazý, SerialPort ve Beep örneði.

using System;
using System.Runtime.Remoting.Contexts; //Context için
using System.Threading; //Thread için
using System.Diagnostics; //[Conditional] için
using System.ComponentModel; //[RunInstaller] için
using System.Collections; //ArrayList için
//using System.Runtime.CompilerServices;
using System.IO.Ports; //SerialPort için
namespace Geliþimler {
    [Synchronization]
    [RunInstaller (true)]
    public class SenkÝçrkSýnýf : ContextBoundObject {
        public SenkÝçrkSýnýf() {//Kurucu
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("Ýçerik sicim no: {0}", içrk.ContextID);
            foreach (IContextProperty içöz in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik adý: {0}", içöz.Name);
        }
    }
    class ÇeþitliC {
        [Conditional ("DEBUG")]
        //[MTAThread]
        [STAThread]
        static void Main() {
            Console.Write ("BitConverter verileri bir bit dizisine çevirir. Metotlarý: long DoubleToInt64Bits(double v), byte[] GetBytes(bool/char/double/float/int/long/short/uint/ulong/ushort v), double Int64BitsToDouble(long v), bool ToBoolean(byte[] a,int idx), char ToChar(byte[] a,int ilk), double ToDouble(byte[] a,int ilk), short ToInt16(byte[] a,int ilk), int ToInt32(byte[] a,int ilk), long ToInt64(byte[] a,int ilk), float ToSingle(byte[] a,int ilk), string ToString(byte[] a), string ToString(byte[] a, int ilk), string ToString(byte[] a, int ilk, int adet), ushort ToUInt16(byte[] a,int ilk), uint ToUInt32(byte[] a,int ilk), ulong ToUInt64(byte[] a,int ilk).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli tip sayýlarý byte[] bit diziye ve hex-dizgeye çevirme:");
            byte[] bayt1 = null;
            bayt1 = BitConverter.GetBytes (true); Console.WriteLine ("{0}(true): {1}", bayt1, BitConverter.ToString (bayt1));
            bayt1 = BitConverter.GetBytes (20240409); Console.WriteLine ("{0}(20240409): {1}", bayt1, BitConverter.ToString (bayt1));
            Console.WriteLine ("{0}(20240409): {1}", bayt1, BitConverter.ToInt32 (bayt1, 0));
            int ts1 = 1881;
            int ts2 = -1234567890;
            double ds = Math.PI;
            bool bs = false;
            byte[] bayt2 = new byte [1024];
            string sonuç;
            bayt2 = BitConverter.GetBytes (ts1); sonuç = BitConverter.ToString (bayt2); Console.WriteLine ("ts1 = {0}, string = {1}", ts1, sonuç);
            bayt2 = BitConverter.GetBytes (ds); sonuç = BitConverter.ToString (bayt2); Console.WriteLine ("ds = {0}, string = {1}", ds, sonuç);
            bayt2 = BitConverter.GetBytes (ts2); sonuç = BitConverter.ToString (bayt2); Console.WriteLine ("ts2 = {0}, string = {1}", ts2, sonuç);
            bayt2 = BitConverter.GetBytes (bs); sonuç = BitConverter.ToString (bayt2); Console.WriteLine ("bs = {0}, string = {1}", bs, sonuç);

            Console.WriteLine ("\nAktüel sicim ve sýnýfýn no'su ve içerik özellik adlarý:");
            Context içrk = Thread.CurrentContext;
            Console.WriteLine ("Ýçerik no: {0}", içrk.ContextID);
            foreach (IContextProperty içöz in içrk.ContextProperties) Console.WriteLine ("-> Ýçerik özellik adý: {0}", içöz.Name);
            SenkÝçrkSýnýf ns = new SenkÝçrkSýnýf();
            Thread ip = Thread.CurrentThread; ip.Name = "ÝlkSicim";
            Console.WriteLine ("Aktüel uygulama alan adý: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine ("Aktüel içerik no: {0}\tadý: {1}", Thread.CurrentContext.ContextID, ip.Name);

            Console.WriteLine ("\nKodlamanýn derleme ikazý/warning vermesi:");
            try {ArrayList liste = new ArrayList();
                liste.Add (202404091028);
                liste.Add ("M.Nihat Yavaþ");
                liste.Add (2024-1957);
                liste.Add ("Toroslar-Mersin");
                for(ts1=0;ts1<10;ts1++) Console.WriteLine ("{0}.liste elemaný = {1}", ts1, liste [ts1]);
            }catch (ArgumentOutOfRangeException ht) {
                Console.WriteLine ("ArgumentOutOfRangeException Ýstisna-Yönetimi==>");
                Console.WriteLine ("HATA: [{0}]", ht);
            }catch (Exception ht) {
                Console.WriteLine ("Exception Genel-Ýstisna-Yönetimi==>");
                Console.WriteLine ("HATA: [{0}]", ht);
/*
j2sc#1408c.cs(67,9): warning CS1058: A previous catch clause already catches all
        exceptions. All non-exceptions thrown will be wrapped in a
        System.Runtime.CompilerServices.RuntimeWrappedException.
*/
            }catch {
                Console.WriteLine ("Umulmayan-Ýstisna-Yönetimi==>");
                Console.WriteLine ("Hiç ummadýðým bir istisna oluþtu...");
            }finally {Console.WriteLine ("try-catch-finally temizliði yapýlýyooor...");}

            Console.WriteLine ("\nSeri çýkýþ COM1'le yazma ve okuma denemesi:");
            byte[] tampon = new byte [256];
            try {using (SerialPort çýkýþ = new SerialPort ("COM1")) {
                // çýkýþ'ýn özellikleri
                çýkýþ.BaudRate = 9600;
                çýkýþ.Parity = Parity.None;
                çýkýþ.ReadTimeout = 10;
                çýkýþ.StopBits = StopBits.One;
                // çýkýþ'a mesaj gönderme.
                çýkýþ.Open();
                çýkýþ.Write ("Merhaba COM1 çýkýþ!");
                //Doðrudan okuma
                çýkýþ.Read (tampon, 0, (int)tampon.Length);
                //Akýþla okuma
                çýkýþ.BaseStream.Read (tampon, 0, (int)tampon.Length);
                Console.WriteLine ("çýkýþ'a mesaj gönderme tamamlandý.");
            }}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht);}

            Console.WriteLine ("\nConsole.Beep(n,m) ile tiz/pes bipleme örnekleri:");
            for(ts1=0;ts1<5;ts1++) Console.Beep(); //5 tiz bip'le
            Thread.Sleep (1000); //1sn bekle
            for(ts1=0;ts1<5;ts1++) Console.Beep (200, 500); //5 pes bip'le

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}