// tpc#39b.cs: Yavru sicimin yaratýlmasý ve çalýþtýrýlmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class YavruSicim {
        public static void YavruSicimeÇaðrý() {Console.WriteLine ("Baðýmsýz çalýþan yavru sicim baþlatýlýyor");}
        static void Main() {
            Console.Write ("Thread sýnýfýnýn özellikleri þunlardýr:\nCurrentContext: AktüelBaðlam\nCurrentCulture: AktüelKültür\nCurrentPrinciple: AktüelPrensip\nCurrentThread: AktüelSicim\nCurrentUICulture: AktüelKAKültürü\nExecutionContext: ÝcraBaðlamý\nIsAlive: CanlýMý\nIsBackground: ArkaplandaMý\nIsThreadPoolThread: HavuzSicimMi\nIsThreadPoolThread: YönetilenSicimKimliði\nName: Adý\nPriority: Önceliði\nThreadState: SicimDurumu\n\nSicim sýnýfýnýn ekseri metodlarý þunlardýr:\npublic void Abort(): Kýr\npublic static LocalDataStoreSlot AllocateDataSlot(): VeriYarýkTahsisi\npublic static LocalDataStoreSlot AllocateNamedDataSlot(string ad): AdlýVeriYarýkTahsisi\npublic static void BeginCriticalRegion(): KritikBölgeBaþlayýþý\npublic static void BeginThreadAffinity(): SicimÝlgiBaþlayýþý\npublic static void EndCriticalRegion(): KritikBölgeSonu\npublic static void EndThreadAffinity(): SicimÝlgiSonu\npublic static void FreeNamedDataSlot(string ad): SerbestAdlýVeriYarýðý\npublic static Object GetData(LocalDataStoreSlot yarýk): VeriAl\npublic static AppDomain GetDomain(): AlanýAl\npublic static AppDomain GetDomainID(): AlanKimliðiAl\npublic static LocalDataStoreSlot GetNamedDataSlot(string name): AdlýVeriYarýðýAl\npublic void Interrupt(): Kýr\npublic void Join(): Baðla\npublic static void MemoryBarrier(): BellekEngeli\npublic static void ResetAbort()KesÝptali\npublic static void SetData(LocalDataStoreSlot yarýk, Object veri): VeriKoy\npublic void Start(): Baþlat\npublic static void Sleep(int mS): Uyu\npublic static void SpinWait(int kere): TekrarBekle\npublic static Object VolatileRead(ref Object adres): UçarýOku\npublic static void VolatileWrite(ref Object adres, Object deðer): UçarýYaz\npublic static bool Yield(): Aktar\n\nYeni bir yavru sicim Threading, ThreadStart, Thread sýnýflarý tiplemeli Start() metoduyla yaratýlýp iþletilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicimeÇaðrý);
            Console.WriteLine ("Main metodu: Yavru sicim yaratýlýyor");
            Thread ip = new Thread (ipRef);
            ip.Start();

            Console.WriteLine ("\nTuþ..."); Console.ReadKey();
        }
    }
}