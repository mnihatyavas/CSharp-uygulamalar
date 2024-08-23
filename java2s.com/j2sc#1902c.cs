// j2sc#1902c.cs: Assembly kurgu detaylarý ve metot.Invoke (ns,null) örneði.

using System;
using System.Reflection; //Assembly için
using System.Collections; //ArrayList için
using System.Windows.Forms; //Form ve TreeNode için
using System.Reflection.Emit; //AssemblyBuilder, AssemblyBuilderAccess, ModuleBuilder, TypeBuilder, ILGenerator ve OpCodes için
using System.Runtime.CompilerServices; //InternalsVisibleTo için
[assembly: InternalsVisibleTo ("M.Nihat Yavaþ")] //InternalsVisibleToAttribute
namespace TipliÝþlemler {
    class SýnýfA{}
    class SýnýfB{}
    class SýnýfC {public void MetotC() {Console.WriteLine ("\tSýnýfC.MetotC() çaðrýldý");}}
    class SýnýfD {public void MetotD() {Console.WriteLine ("\tSýnýfD.MetotD() çaðrýldý");}}
    class Kurgu: Form {
        public static bool MevcutMu (MemberInfo üye, object liste) {
            ArrayList al = (ArrayList) liste;
            if (al.Contains (üye.Name)) return true;
            if (al.Contains (üye.MemberType)) return true;
            return false;
        }
        private MainMenu anaMenü  = new MainMenu();
        private MenuItem menüBirimi = new MenuItem();
        private MenuItem menüAç = new MenuItem();
        private OpenFileDialog dosyaAçDiyaloðu = new OpenFileDialog();
        private Assembly kurgum;
        private TreeView aðaçÞemasý = new TreeView();
        private PropertyGrid özellikNesnesi = new PropertyGrid();
        public Kurgu() {//Kurucu
            this.SuspendLayout();
            this.anaMenü.MenuItems.AddRange (new MenuItem[] {this.menüBirimi});
            this.menüBirimi.Index = 0;
            this.menüBirimi.MenuItems.AddRange (new MenuItem[] {this.menüAç});
            this.menüBirimi.Text = "&Dosya";
            this.menüAç.Index = 0;
            this.menüAç.Text = "&Aç";
            this.menüAç.Click += new System.EventHandler (this.menüAç_Týkla);
            this.dosyaAçDiyaloðu.CheckFileExists = false;
            this.dosyaAçDiyaloðu.CheckPathExists = false;
            this.dosyaAçDiyaloðu.Filter = "Assemblies|*.exe;*.dll";
            this.dosyaAçDiyaloðu.ValidateNames = false;
            this.aðaçÞemasý.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.aðaçÞemasý.ImageIndex = -1;
            this.aðaçÞemasý.Location = new System.Drawing.Point (8, 8);
            this.aðaçÞemasý.Name = "aðaçÞemasý";
            this.aðaçÞemasý.SelectedImageIndex = -1;
            this.aðaçÞemasý.Size = new System.Drawing.Size (672, 400);
            this.aðaçÞemasý.TabIndex = 0;
            this.aðaçÞemasý.AfterSelect += new TreeViewEventHandler (this.aðaçÞemasý_Seçilince);
            this.aðaçÞemasý.BackColor = System.Drawing.Color.Cyan;
            this.aðaçÞemasý.ForeColor = System.Drawing.Color.Red;
            this.özellikNesnesi.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.özellikNesnesi.BackColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.CommandsBackColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.CommandsForeColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.CommandsVisibleIfAvailable = true;
            this.özellikNesnesi.HelpBackColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.HelpForeColor = System.Drawing.Color.Maroon;
            this.özellikNesnesi.HelpVisible = false;
            this.özellikNesnesi.LargeButtons = false;
            this.özellikNesnesi.LineColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.Location = new System.Drawing.Point (8, 416);
            this.özellikNesnesi.Name = "özellikNesnesi";
            this.özellikNesnesi.Size = new System.Drawing.Size (672, 128);
            this.özellikNesnesi.TabIndex = 1;
            this.özellikNesnesi.Text = "Özellik Nesnesi";
            this.özellikNesnesi.ToolbarVisible = false;
            this.özellikNesnesi.ViewBackColor = System.Drawing.Color.Lime;
            this.özellikNesnesi.ViewForeColor = System.Drawing.Color.Maroon;
            this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
            this.ClientSize = new System.Drawing.Size (688, 553);
            this.Controls.Add (this.özellikNesnesi);
            this.Controls.Add (this.aðaçÞemasý);
            this.Menu = this.anaMenü;
            this.Text = "Kurgular Vitrini";
            this.ResumeLayout (false);
        }
        private void menüAç_Týkla (object kaynak, System.EventArgs olay) {
            if (dosyaAçDiyaloðu.ShowDialog (this) == DialogResult.OK) {
                try {kurgum = Assembly.LoadFile (dosyaAçDiyaloðu.FileName); aðacýKur();
                }catch (Exception ht) {MessageBox.Show (ht.Message);}
            }
        }
        private void aðacýKur() {
            TreeNode yeniDüðüm = new TreeNode (kurgum.GetName().Name);
            yeniDüðüm.Tag = kurgum;
            aðaçÞemasý.Nodes.Add (yeniDüðüm);
            foreach (Module modül in kurgum.GetModules()) modülEkle (modül, yeniDüðüm);
        }
        private void modülEkle (Module modül, TreeNode ebeveyn) {
            TreeNode yeniDüðüm = new TreeNode (modül.Name);
            yeniDüðüm.Tag = modül;
            ebeveyn.Nodes.Add (yeniDüðüm);
            foreach (Type t in modül.GetTypes()) tipEkle (t, yeniDüðüm);
        }
        private void tipEkle (Type t, TreeNode ebeveyn) {
            TreeNode yeniDüðüm = new TreeNode (t.Name);
            yeniDüðüm.Tag = t;
            TreeNode aktüelTip;
            TreeNode aktüelÜye;
            aktüelTip = new TreeNode ("Kurucular");
            foreach (ConstructorInfo ci in t.GetConstructors()) {
                aktüelÜye = new TreeNode (ci.Name);
                aktüelÜye.Tag = ci;
                aktüelTip.Nodes.Add (aktüelÜye);
            }
            yeniDüðüm.Nodes.Add (aktüelTip);
            aktüelTip = new TreeNode ("Metotlar");
            foreach (MethodInfo mb in t.GetMethods()) {
                string metot = mb.Name + "( ";
                int sayaç = mb.GetParameters().Length;
                foreach (ParameterInfo pi in mb.GetParameters()) {
                    metot += pi.ParameterType;
                    if (pi.Position < sayaç-1) metot += ", ";
                }
                metot += " )";
                aktüelÜye = new TreeNode (metot);
                aktüelÜye.Tag = mb;
                aktüelTip.Nodes.Add (aktüelÜye);
            }
            yeniDüðüm.Nodes.Add (aktüelTip);
            aktüelTip = new TreeNode ("Özellikler");
            foreach (PropertyInfo pi in t.GetProperties()) {
                aktüelÜye = new TreeNode (pi.Name);
                aktüelÜye.Tag = pi;
                aktüelTip.Nodes.Add (aktüelÜye);
            }
            yeniDüðüm.Nodes.Add (aktüelTip);
            aktüelTip = new TreeNode ("Alanlar");
            foreach (FieldInfo alan in t.GetFields (BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField)) {
                string fi = alan.FieldType.Name;
                fi += " " + alan.Name;
                aktüelÜye = new TreeNode (fi);
                aktüelÜye.Tag = alan;
                aktüelTip.Nodes.Add (aktüelÜye);
            }
            yeniDüðüm.Nodes.Add (aktüelTip);
            aktüelTip = new TreeNode ("Olaylar");
            foreach (EventInfo ei in t.GetEvents()) {
                string info = ei.Name;
                info += " Delegate Type=" + ei.EventHandlerType;
                aktüelÜye = new TreeNode (info);
                aktüelÜye.Tag = ei;
                aktüelTip.Nodes.Add (aktüelÜye);
            }
            yeniDüðüm.Nodes.Add (aktüelTip);
            ebeveyn.Nodes.Add (yeniDüðüm);
        }
        private void aðaçÞemasý_Seçilince (object kaynak, TreeViewEventArgs olay) {
            if (olay.Node.Tag != null) özellikNesnesi.SelectedObject = olay.Node.Tag;
            else özellikNesnesi.SelectedObject = null;
        }
        static void DinamikTipYarat (AppDomain saha) {
            try {saha.CreateInstance ("Assembly ad, Version, Culture, PublicKeyToken", "DinamikTip");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
        }   
        static Assembly OlayYönetimiÇözümü (object kaynak, ResolveEventArgs arg) {
            AppDomain saha = (AppDomain) kaynak;
            AssemblyName kurguAdý = new AssemblyName();
            kurguAdý.Name = "DinamikTip";
            AssemblyBuilder ab = saha.DefineDynamicAssembly (kurguAdý, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule ("DinamikTip");
            TypeBuilder tb = mb.DefineType ("DinamikTip", TypeAttributes.Public);
            ConstructorBuilder cb = tb.DefineConstructor (MethodAttributes.Public, CallingConventions.Standard, null);
            ILGenerator ig = cb.GetILGenerator();
            ig.EmitWriteLine ("DinamikTip yaratýldý!");
            ig.Emit (OpCodes.Ret);
            tb.CreateType();
            return ab;
        }
        [STAThread]
        static void Main() {
            Console.Write ("Çalýþan exe kurgu 'Assembly.GetExecutingAssembly()', tam yollu baþka kurgu 'Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory+'\\iþli\\j2sc#1902a.exe')', mevcut dizindeyse 'Assembly.Load('j2sc#1902a')' ile alýnabilir. [assembly:Vasýflar()], namespace üzerinde bulunmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýþleyen ve duraðan iki exe kurgunun incelenmesi:");
            Assembly krg = Assembly.GetExecutingAssembly();
            Console.WriteLine ("Çalýþan kurgu adý: {0}\nKonumu: {1}", krg.GetName().Name, krg.Location);
            Console.WriteLine ("Global önbellek kurgusu mu? {0}", krg.GlobalAssemblyCache);
            Console.WriteLine ("Kurgunun sürümü: {0}", krg.ImageRuntimeVersion);
            Assembly krg2 = Assembly.LoadFile (AppDomain.CurrentDomain.BaseDirectory + ".\\iþli\\j2sc#1902a.exe");
            //Assembly krg2 = Assembly.Load ("j2sc#1902a");
            Console.WriteLine ("Diðer kurgu adý: {0}", krg2.GetName().Name);
            Console.WriteLine ("{0} kurgudaki mevcut tipler:", krg2.GetName().Name);
            foreach (Type t in krg2.GetTypes()) Console.WriteLine ("\t"+t.Name);

            Console.WriteLine ("\nYollu kurgu Mscorlib.dll'un tüm tiplerinin 10'arlý listesi:");
            krg = Assembly.Load ("Mscorlib.dll");
            int i; ConsoleKeyInfo tuþ;
            Type[] tipler = krg.GetTypes();
            for(i=0;i<tipler.Length;i++) {
                Console.WriteLine ("Tip-{0}: [{1}]", i, tipler [i]);
                if ((i+1)%10==0) {Console.Write ("\nDevam[e/h]:"); tuþ=Console.ReadKey(); if(tuþ.KeyChar=='h') break;}
            }
            Type tip = Type.GetType ("System.Reflection.Assembly");
            Console.WriteLine ("\n==>Bir sistem arþiv tipi: {0}", tip);
            Console.WriteLine ("==>Ýki ayrý AppDomain:UygSaha'da iki ayrý exe'nin koþturulmasý...");
            AppDomain uygSaha1 = AppDomain.CurrentDomain;
            AppDomain uygSaha2 = AppDomain.CreateDomain ("uygSaha2");
            uygSaha1.ExecuteAssembly (".\\iþli\\j2sc#0101a.exe"); //AppDomain.Unload (uygSaha1);
            uygSaha2.ExecuteAssembly (".\\iþli\\j2sc#0101b.exe"); //AppDomain.Unload (uygSaha2);

            Console.WriteLine ("\nVerili Kurgudaki tiplerin aramaListesi'nde mevcudiyetleri kontrolu:");
            ArrayList aramaListesi = new ArrayList();
            aramaListesi.Add ("Kurgu"); aramaListesi.Add ("SýnýfA"); aramaListesi.Add ("SýnýfB"); aramaListesi.Add ("Delege");
            krg = Assembly.LoadFile (AppDomain.CurrentDomain.BaseDirectory + ".\\iþli\\j2sc#1902a.exe");
            MemberFilter süzgeç = new MemberFilter (MevcutMu);
            foreach (Module modül in krg.GetModules()) {
                foreach (Type t in modül.GetTypes()) {
                    if (aramaListesi.Contains (t.Name)) Console.WriteLine ("Tip: {0}-->BULUNDU", t.Name);
                    else Console.WriteLine ("Tip: {0}-->BULUNAMADI", t.Name );
                    MemberInfo[] mi = t.FindMembers (MemberTypes.All, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly, süzgeç, aramaListesi);
                    foreach (MemberInfo üb in mi) Console.WriteLine ("Bulunan üye adý: {0} Üye tipi: {1} Tipleme adý: {2}", üb.Name, üb.MemberType, t.Name);
                }
            }

            Console.WriteLine ("\nDiyalogla seçilen exe dosya detaylarýnýn altta açýklamalý aðaç þemasý:");
            Application.Run (new Kurgu());

            Console.WriteLine ("\nAktüel sahada DinamikTip bir DinamikTip yaratma:");
            AppDomain aktüelSaha = AppDomain.CurrentDomain;
            aktüelSaha.AssemblyResolve += new ResolveEventHandler (OlayYönetimiÇözümü);
            DinamikTipYarat (aktüelSaha);

            Console.WriteLine ("\nInternalsVisibleTo vasfý için 'using System.Runtime.CompilerServices' gerekir:");
            Console.WriteLine ("==>Sýnýf metodunu 'snf.Metot()'la çaðýrma...");
            SýnýfC snfC = new SýnýfC(); snfC.MetotC();
            SýnýfD snfD = new SýnýfD(); snfD.MetotD();
            Console.WriteLine ("==>Sýnýf metodunu 'metot.Invoke (ns,null)'la çaðýrma...");
            krg = Assembly.Load ("j2sc#1902c");
            tip = krg.GetType (new SýnýfD().ToString()); MethodInfo metot = tip.GetMethod ("MetotD"); Object ns = Activator.CreateInstance (tip); metot.Invoke (ns, null);
            tip = krg.GetType (new SýnýfC().ToString()); metot = tip.GetMethod ("MetotC"); ns = Activator.CreateInstance (tip); metot.Invoke (ns, null);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}