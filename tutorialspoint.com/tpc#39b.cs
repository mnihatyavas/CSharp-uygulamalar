// tpc#39b.cs: Yavru sicimin yarat�lmas� ve �al��t�r�lmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class YavruSicim {
        public static void YavruSicime�a�r�() {Console.WriteLine ("Ba��ms�z �al��an yavru sicim ba�lat�l�yor");}
        static void Main() {
            Console.Write ("Thread s�n�f�n�n �zellikleri �unlard�r:\nCurrentContext: Akt�elBa�lam\nCurrentCulture: Akt�elK�lt�r\nCurrentPrinciple: Akt�elPrensip\nCurrentThread: Akt�elSicim\nCurrentUICulture: Akt�elKAK�lt�r�\nExecutionContext: �craBa�lam�\nIsAlive: Canl�M�\nIsBackground: ArkaplandaM�\nIsThreadPoolThread: HavuzSicimMi\nIsThreadPoolThread: Y�netilenSicimKimli�i\nName: Ad�\nPriority: �nceli�i\nThreadState: SicimDurumu\n\nSicim s�n�f�n�n ekseri metodlar� �unlard�r:\npublic void Abort(): K�r\npublic static LocalDataStoreSlot AllocateDataSlot(): VeriYar�kTahsisi\npublic static LocalDataStoreSlot AllocateNamedDataSlot(string ad): Adl�VeriYar�kTahsisi\npublic static void BeginCriticalRegion(): KritikB�lgeBa�lay���\npublic static void BeginThreadAffinity(): Sicim�lgiBa�lay���\npublic static void EndCriticalRegion(): KritikB�lgeSonu\npublic static void EndThreadAffinity(): Sicim�lgiSonu\npublic static void FreeNamedDataSlot(string ad): SerbestAdl�VeriYar���\npublic static Object GetData(LocalDataStoreSlot yar�k): VeriAl\npublic static AppDomain GetDomain(): Alan�Al\npublic static AppDomain GetDomainID(): AlanKimli�iAl\npublic static LocalDataStoreSlot GetNamedDataSlot(string name): Adl�VeriYar���Al\npublic void Interrupt(): K�r\npublic void Join(): Ba�la\npublic static void MemoryBarrier(): BellekEngeli\npublic static void ResetAbort()Kes�ptali\npublic static void SetData(LocalDataStoreSlot yar�k, Object veri): VeriKoy\npublic void Start(): Ba�lat\npublic static void Sleep(int mS): Uyu\npublic static void SpinWait(int kere): TekrarBekle\npublic static Object VolatileRead(ref Object adres): U�ar�Oku\npublic static void VolatileWrite(ref Object adres, Object de�er): U�ar�Yaz\npublic static bool Yield(): Aktar\n\nYeni bir yavru sicim Threading, ThreadStart, Thread s�n�flar� tiplemeli Start() metoduyla yarat�l�p i�letilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicime�a�r�);
            Console.WriteLine ("Main metodu: Yavru sicim yarat�l�yor");
            Thread ip = new Thread (ipRef);
            ip.Start();

            Console.WriteLine ("\nTu�..."); Console.ReadKey();
        }
    }
}