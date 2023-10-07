// j2sc#0714bx.cs: Temel sýnýfýn harici uygulamadan miraslanmasý örneði.

using System;
namespace TemelSýnýfNS {
    public class TemelSýnýf {
        string m;
        public TemelSýnýf (string m) {this.m=m;}
        public void Yaz(int i) {Console.WriteLine ("{0}.Mesaj: [\"{1}\"]", i+1, m);}
   }
}
