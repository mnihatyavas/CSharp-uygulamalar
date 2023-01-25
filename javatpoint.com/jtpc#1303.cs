// jtpc#1303.cs: Özel kullanıcı-tanımlı türev istiana fırlatma örneği.

using System;
namespace İstisnaYönetimi {
    public class GeçersizYaşİstisnası: Exception {
        public GeçersizYaşİstisnası (String mesaj): base (mesaj){} //Parametreli türev kurucusu
    }
    class Özelİstisna {
        static void yaşKontrolu (int yaş) {
            if (yaş < 18) {throw new GeçersizYaşİstisnası ("Yaşınız " + yaş + ". Üzgünüm, ama reşit olmayanlar giremez!..");
            }else {Console.WriteLine ("\nYaşınız {0}. Buyrun, girebilirsiniz!..", yaş);}
        }
        static void Main() {
            Console.Write ("Temel Exception miraslanarak, istenilen anlamlı özel kullanıcı-tanımlı istisnalar yaratılıp yönetilebilir.\nTuş..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            for (int i=0; i < 10; i++) {
                try {yaşKontrolu (rasgele.Next (0, 51));
                }catch (GeçersizYaşİstisnası hata) {Console.WriteLine ("\nHATA: [{0}]", hata);} //hata, throw mesajını içerir
            }
            Console.WriteLine ("\nNormal program akışına devam"); 

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    }
}