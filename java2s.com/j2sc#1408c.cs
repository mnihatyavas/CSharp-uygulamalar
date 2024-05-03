// j2sc#1408c.cs: BitConverter, Context, derleme warning/ikaz�, SerialPort ve Beep �rne�i.

using System;
using System.Runtime.Remoting.Contexts; //Context i�in
using System.Threading; //Thread i�in
using System.Diagnostics; //[Conditional] i�in
using System.ComponentModel; //[RunInstaller] i�in
using System.Collections; //ArrayList i�in
//using System.Runtime.CompilerServices;
using System.IO.Ports; //SerialPort i�in
namespace Geli�imler {
    [Synchronization]
    [RunInstaller (true)]
    public class Senk��rkS�n�f : ContextBoundObject {
        public Senk��rkS�n�f() {//Kurucu
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("��erik sicim no: {0}", i�rk.ContextID);
            foreach (IContextProperty i��z in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik ad�: {0}", i��z.Name);
        }
    }
    class �e�itliC {
        [Conditional ("DEBUG")]
        //[MTAThread]
        [STAThread]
        static void Main() {
            Console.Write ("BitConverter verileri bir bit dizisine �evirir. Metotlar�: long DoubleToInt64Bits(double v), byte[] GetBytes(bool/char/double/float/int/long/short/uint/ulong/ushort v), double Int64BitsToDouble(long v), bool ToBoolean(byte[] a,int idx), char ToChar(byte[] a,int ilk), double ToDouble(byte[] a,int ilk), short ToInt16(byte[] a,int ilk), int ToInt32(byte[] a,int ilk), long ToInt64(byte[] a,int ilk), float ToSingle(byte[] a,int ilk), string ToString(byte[] a), string ToString(byte[] a, int ilk), string ToString(byte[] a, int ilk, int adet), ushort ToUInt16(byte[] a,int ilk), uint ToUInt32(byte[] a,int ilk), ulong ToUInt64(byte[] a,int ilk).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli tip say�lar� byte[] bit diziye ve hex-dizgeye �evirme:");
            byte[] bayt1 = null;
            bayt1 = BitConverter.GetBytes (true); Console.WriteLine ("{0}(true): {1}", bayt1, BitConverter.ToString (bayt1));
            bayt1 = BitConverter.GetBytes (20240409); Console.WriteLine ("{0}(20240409): {1}", bayt1, BitConverter.ToString (bayt1));
            Console.WriteLine ("{0}(20240409): {1}", bayt1, BitConverter.ToInt32 (bayt1, 0));
            int ts1 = 1881;
            int ts2 = -1234567890;
            double ds = Math.PI;
            bool bs = false;
            byte[] bayt2 = new byte [1024];
            string sonu�;
            bayt2 = BitConverter.GetBytes (ts1); sonu� = BitConverter.ToString (bayt2); Console.WriteLine ("ts1 = {0}, string = {1}", ts1, sonu�);
            bayt2 = BitConverter.GetBytes (ds); sonu� = BitConverter.ToString (bayt2); Console.WriteLine ("ds = {0}, string = {1}", ds, sonu�);
            bayt2 = BitConverter.GetBytes (ts2); sonu� = BitConverter.ToString (bayt2); Console.WriteLine ("ts2 = {0}, string = {1}", ts2, sonu�);
            bayt2 = BitConverter.GetBytes (bs); sonu� = BitConverter.ToString (bayt2); Console.WriteLine ("bs = {0}, string = {1}", bs, sonu�);

            Console.WriteLine ("\nAkt�el sicim ve s�n�f�n no'su ve i�erik �zellik adlar�:");
            Context i�rk = Thread.CurrentContext;
            Console.WriteLine ("��erik no: {0}", i�rk.ContextID);
            foreach (IContextProperty i��z in i�rk.ContextProperties) Console.WriteLine ("-> ��erik �zellik ad�: {0}", i��z.Name);
            Senk��rkS�n�f ns = new Senk��rkS�n�f();
            Thread ip = Thread.CurrentThread; ip.Name = "�lkSicim";
            Console.WriteLine ("Akt�el uygulama alan ad�: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine ("Akt�el i�erik no: {0}\tad�: {1}", Thread.CurrentContext.ContextID, ip.Name);

            Console.WriteLine ("\nKodlaman�n derleme ikaz�/warning vermesi:");
            try {ArrayList liste = new ArrayList();
                liste.Add (202404091028);
                liste.Add ("M.Nihat Yava�");
                liste.Add (2024-1957);
                liste.Add ("Toroslar-Mersin");
                for(ts1=0;ts1<10;ts1++) Console.WriteLine ("{0}.liste eleman� = {1}", ts1, liste [ts1]);
            }catch (ArgumentOutOfRangeException ht) {
                Console.WriteLine ("ArgumentOutOfRangeException �stisna-Y�netimi==>");
                Console.WriteLine ("HATA: [{0}]", ht);
            }catch (Exception ht) {
                Console.WriteLine ("Exception Genel-�stisna-Y�netimi==>");
                Console.WriteLine ("HATA: [{0}]", ht);
/*
j2sc#1408c.cs(67,9): warning CS1058: A previous catch clause already catches all
        exceptions. All non-exceptions thrown will be wrapped in a
        System.Runtime.CompilerServices.RuntimeWrappedException.
*/
            }catch {
                Console.WriteLine ("Umulmayan-�stisna-Y�netimi==>");
                Console.WriteLine ("Hi� ummad���m bir istisna olu�tu...");
            }finally {Console.WriteLine ("try-catch-finally temizli�i yap�l�yooor...");}

            Console.WriteLine ("\nSeri ��k�� COM1'le yazma ve okuma denemesi:");
            byte[] tampon = new byte [256];
            try {using (SerialPort ��k�� = new SerialPort ("COM1")) {
                // ��k��'�n �zellikleri
                ��k��.BaudRate = 9600;
                ��k��.Parity = Parity.None;
                ��k��.ReadTimeout = 10;
                ��k��.StopBits = StopBits.One;
                // ��k��'a mesaj g�nderme.
                ��k��.Open();
                ��k��.Write ("Merhaba COM1 ��k��!");
                //Do�rudan okuma
                ��k��.Read (tampon, 0, (int)tampon.Length);
                //Ak��la okuma
                ��k��.BaseStream.Read (tampon, 0, (int)tampon.Length);
                Console.WriteLine ("��k��'a mesaj g�nderme tamamland�.");
            }}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht);}

            Console.WriteLine ("\nConsole.Beep(n,m) ile tiz/pes bipleme �rnekleri:");
            for(ts1=0;ts1<5;ts1++) Console.Beep(); //5 tiz bip'le
            Thread.Sleep (1000); //1sn bekle
            for(ts1=0;ts1<5;ts1++) Console.Beep (200, 500); //5 pes bip'le

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}