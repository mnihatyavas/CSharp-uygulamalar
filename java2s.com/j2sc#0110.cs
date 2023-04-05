// j2sc#0110.cs: Deðiþkenlerin tanýmlandýklarý blok ve altbloklarýnda geçerliliði örneði.

using System;
namespace DilTemelleri {
    class DeðiþkenKapsamý {
        static void Main() {
            Console.Write ("Deðiþkenler tanýmlandýklarý {} blok ve alt-bloklarý kapamýnda geçerli olup, bloða her giriþte yaratýlýr, bir üst bloða çýkýldýðýna imha edilirler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int x;
            for (x = 0; x < 3; x++) {
                int y = -1;
                Console.WriteLine ("y for bloðuna her giriþte {0} ilk deðerle yeniden yaratýlýr.", y);
                y = 100;
                Console.WriteLine ("y for bloðundan çýkarken son deðeri: " + y);
            } Console.WriteLine();

            int yýl; //Main() içindeki her blokta geçerli
            yýl = 2023;
            if (yýl%2 == 1) {//Yeni iç-blok kapsamý
                int yaþ = yýl - 1957; //yaþ bu blok kapsamýnda geçerli
                Console.WriteLine ("Abimin {0} yýlýndaki yaþý: {1}", yýl, yaþ); 
            }else {
                int yaþ = yýl - 1951; //yaþ bu blok kapsamýnda geçerli
                Console.WriteLine ("Ablamýn {0} yýlýndaki yaþý: {1}", yýl, yaþ); 
            }
            Console.WriteLine ("Yýl deðeri: " + yýl);
            //Console.WriteLine ("Yaþ deðeri: " + yaþ); //Derleme hatasý verir

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}