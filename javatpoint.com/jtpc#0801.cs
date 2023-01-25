// jtpc#0801.cs: Ebeveyn-yavru-lar miras�yla atalar�n t�m �yelerini kullanabilme �rne�i.

using System;
namespace Kal�tsall�k {
    public class ��g�ren {
        public float asgari�cret = 4000;
        public float bayram�kramiyesi = 1000;
    }
    public class Programc�: ��g�ren {// Ebeveyn alanlar�n� miraslar
        public float te�vikPrimi = 500;
        public float ba�ar�Bonusu = 1500;
        public float kariyerEki = 2500;
    }
    public class Hayvanlar {public void ye() {Console.WriteLine ("\nYiyor...");} }
    public class AnaK�pek: Hayvanlar {public void havla() {Console.WriteLine ("Havl�yor...");} }
    public class �ocukK�pek: AnaK�pek {public void g�l() {Console.WriteLine ("G�l�yor...");} }
    public class TorunK�pek: �ocukK�pek {public void a�la() {Console.WriteLine ("A�l�yor...");} } //Ebeveyn metodlar�n� miraslar
    class Miras {
        static void Main() {
            Console.Write ("T�rev s�n�f, miraslanan temel s�n�f�n t�m �yelerinin (alan, metod vb) davran�� ve �zelliklerini, yeniden kodlamadan aynen kullanabilir, de�i�tirebilir veya alt-yavrulara esnetebilir. Tek temel-t�rev ili�kisi tek-seviyeli, �ok ebeveyn-yavrular ise �ok-seviyeli mirast�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Programc� p = new Programc�(); float toplamMaa� = p.asgari�cret+p.bayram�kramiyesi+p.te�vikPrimi+p.ba�ar�Bonusu+p.kariyerEki;
            Console.WriteLine ("Maa�: [�cret+�kramiye+Prim+Bonus+Ek] = [{0}+{1}+{2}+{3}+{4} = {5}]TL", p.asgari�cret, p.bayram�kramiyesi, p.te�vikPrimi, p.ba�ar�Bonusu, p.kariyerEki, toplamMaa�);

            AnaK�pek ak = new AnaK�pek(); ak.ye(); ak.havla(); //Tek-seviyeli (1) miras

            TorunK�pek tk = new TorunK�pek(); tk.ye(); tk.havla(); tk.g�l(); tk.a�la(); //�ok-seviyeli (3) miras

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}