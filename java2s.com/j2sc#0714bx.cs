// j2sc#0714bx.cs: Temel s�n�f�n harici uygulamadan miraslanmas� �rne�i.

using System;
namespace TemelS�n�fNS {
    public class TemelS�n�f {
        string m;
        public TemelS�n�f (string m) {this.m=m;}
        public void Yaz(int i) {Console.WriteLine ("{0}.Mesaj: [\"{1}\"]", i+1, m);}
   }
}
