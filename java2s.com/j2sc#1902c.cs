// j2sc#1902c.cs: Assembly kurgu detaylar� ve metot.Invoke (ns,null) �rne�i.

using System;
using System.Reflection; //Assembly i�in
using System.Collections; //ArrayList i�in
using System.Windows.Forms; //Form ve TreeNode i�in
using System.Reflection.Emit; //AssemblyBuilder, AssemblyBuilderAccess, ModuleBuilder, TypeBuilder, ILGenerator ve OpCodes i�in
using System.Runtime.CompilerServices; //InternalsVisibleTo i�in
[assembly: InternalsVisibleTo ("M.Nihat Yava�")] //InternalsVisibleToAttribute
namespace Tipli��lemler {
    class S�n�fA{}
    class S�n�fB{}
    class S�n�fC {public void MetotC() {Console.WriteLine ("\tS�n�fC.MetotC() �a�r�ld�");}}
    class S�n�fD {public void MetotD() {Console.WriteLine ("\tS�n�fD.MetotD() �a�r�ld�");}}
    class Kurgu: Form {
        public static bool MevcutMu (MemberInfo �ye, object liste) {
            ArrayList al = (ArrayList) liste;
            if (al.Contains (�ye.Name)) return true;
            if (al.Contains (�ye.MemberType)) return true;
            return false;
        }
        private MainMenu anaMen�  = new MainMenu();
        private MenuItem men�Birimi = new MenuItem();
        private MenuItem men�A� = new MenuItem();
        private OpenFileDialog dosyaA�Diyalo�u = new OpenFileDialog();
        private Assembly kurgum;
        private TreeView a�a��emas� = new TreeView();
        private PropertyGrid �zellikNesnesi = new PropertyGrid();
        public Kurgu() {//Kurucu
            this.SuspendLayout();
            this.anaMen�.MenuItems.AddRange (new MenuItem[] {this.men�Birimi});
            this.men�Birimi.Index = 0;
            this.men�Birimi.MenuItems.AddRange (new MenuItem[] {this.men�A�});
            this.men�Birimi.Text = "&Dosya";
            this.men�A�.Index = 0;
            this.men�A�.Text = "&A�";
            this.men�A�.Click += new System.EventHandler (this.men�A�_T�kla);
            this.dosyaA�Diyalo�u.CheckFileExists = false;
            this.dosyaA�Diyalo�u.CheckPathExists = false;
            this.dosyaA�Diyalo�u.Filter = "Assemblies|*.exe;*.dll";
            this.dosyaA�Diyalo�u.ValidateNames = false;
            this.a�a��emas�.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right)));
            this.a�a��emas�.ImageIndex = -1;
            this.a�a��emas�.Location = new System.Drawing.Point (8, 8);
            this.a�a��emas�.Name = "a�a��emas�";
            this.a�a��emas�.SelectedImageIndex = -1;
            this.a�a��emas�.Size = new System.Drawing.Size (672, 400);
            this.a�a��emas�.TabIndex = 0;
            this.a�a��emas�.AfterSelect += new TreeViewEventHandler (this.a�a��emas�_Se�ilince);
            this.a�a��emas�.BackColor = System.Drawing.Color.Cyan;
            this.a�a��emas�.ForeColor = System.Drawing.Color.Red;
            this.�zellikNesnesi.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            this.�zellikNesnesi.BackColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.CommandsBackColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.CommandsForeColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.CommandsVisibleIfAvailable = true;
            this.�zellikNesnesi.HelpBackColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.HelpForeColor = System.Drawing.Color.Maroon;
            this.�zellikNesnesi.HelpVisible = false;
            this.�zellikNesnesi.LargeButtons = false;
            this.�zellikNesnesi.LineColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.Location = new System.Drawing.Point (8, 416);
            this.�zellikNesnesi.Name = "�zellikNesnesi";
            this.�zellikNesnesi.Size = new System.Drawing.Size (672, 128);
            this.�zellikNesnesi.TabIndex = 1;
            this.�zellikNesnesi.Text = "�zellik Nesnesi";
            this.�zellikNesnesi.ToolbarVisible = false;
            this.�zellikNesnesi.ViewBackColor = System.Drawing.Color.Lime;
            this.�zellikNesnesi.ViewForeColor = System.Drawing.Color.Maroon;
            this.AutoScaleBaseSize = new System.Drawing.Size (5, 13);
            this.ClientSize = new System.Drawing.Size (688, 553);
            this.Controls.Add (this.�zellikNesnesi);
            this.Controls.Add (this.a�a��emas�);
            this.Menu = this.anaMen�;
            this.Text = "Kurgular Vitrini";
            this.ResumeLayout (false);
        }
        private void men�A�_T�kla (object kaynak, System.EventArgs olay) {
            if (dosyaA�Diyalo�u.ShowDialog (this) == DialogResult.OK) {
                try {kurgum = Assembly.LoadFile (dosyaA�Diyalo�u.FileName); a�ac�Kur();
                }catch (Exception ht) {MessageBox.Show (ht.Message);}
            }
        }
        private void a�ac�Kur() {
            TreeNode yeniD���m = new TreeNode (kurgum.GetName().Name);
            yeniD���m.Tag = kurgum;
            a�a��emas�.Nodes.Add (yeniD���m);
            foreach (Module mod�l in kurgum.GetModules()) mod�lEkle (mod�l, yeniD���m);
        }
        private void mod�lEkle (Module mod�l, TreeNode ebeveyn) {
            TreeNode yeniD���m = new TreeNode (mod�l.Name);
            yeniD���m.Tag = mod�l;
            ebeveyn.Nodes.Add (yeniD���m);
            foreach (Type t in mod�l.GetTypes()) tipEkle (t, yeniD���m);
        }
        private void tipEkle (Type t, TreeNode ebeveyn) {
            TreeNode yeniD���m = new TreeNode (t.Name);
            yeniD���m.Tag = t;
            TreeNode akt�elTip;
            TreeNode akt�el�ye;
            akt�elTip = new TreeNode ("Kurucular");
            foreach (ConstructorInfo ci in t.GetConstructors()) {
                akt�el�ye = new TreeNode (ci.Name);
                akt�el�ye.Tag = ci;
                akt�elTip.Nodes.Add (akt�el�ye);
            }
            yeniD���m.Nodes.Add (akt�elTip);
            akt�elTip = new TreeNode ("Metotlar");
            foreach (MethodInfo mb in t.GetMethods()) {
                string metot = mb.Name + "( ";
                int saya� = mb.GetParameters().Length;
                foreach (ParameterInfo pi in mb.GetParameters()) {
                    metot += pi.ParameterType;
                    if (pi.Position < saya�-1) metot += ", ";
                }
                metot += " )";
                akt�el�ye = new TreeNode (metot);
                akt�el�ye.Tag = mb;
                akt�elTip.Nodes.Add (akt�el�ye);
            }
            yeniD���m.Nodes.Add (akt�elTip);
            akt�elTip = new TreeNode ("�zellikler");
            foreach (PropertyInfo pi in t.GetProperties()) {
                akt�el�ye = new TreeNode (pi.Name);
                akt�el�ye.Tag = pi;
                akt�elTip.Nodes.Add (akt�el�ye);
            }
            yeniD���m.Nodes.Add (akt�elTip);
            akt�elTip = new TreeNode ("Alanlar");
            foreach (FieldInfo alan in t.GetFields (BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField)) {
                string fi = alan.FieldType.Name;
                fi += " " + alan.Name;
                akt�el�ye = new TreeNode (fi);
                akt�el�ye.Tag = alan;
                akt�elTip.Nodes.Add (akt�el�ye);
            }
            yeniD���m.Nodes.Add (akt�elTip);
            akt�elTip = new TreeNode ("Olaylar");
            foreach (EventInfo ei in t.GetEvents()) {
                string info = ei.Name;
                info += " Delegate Type=" + ei.EventHandlerType;
                akt�el�ye = new TreeNode (info);
                akt�el�ye.Tag = ei;
                akt�elTip.Nodes.Add (akt�el�ye);
            }
            yeniD���m.Nodes.Add (akt�elTip);
            ebeveyn.Nodes.Add (yeniD���m);
        }
        private void a�a��emas�_Se�ilince (object kaynak, TreeViewEventArgs olay) {
            if (olay.Node.Tag != null) �zellikNesnesi.SelectedObject = olay.Node.Tag;
            else �zellikNesnesi.SelectedObject = null;
        }
        static void DinamikTipYarat (AppDomain saha) {
            try {saha.CreateInstance ("Assembly ad, Version, Culture, PublicKeyToken", "DinamikTip");
            }catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
        }   
        static Assembly OlayY�netimi��z�m� (object kaynak, ResolveEventArgs arg) {
            AppDomain saha = (AppDomain) kaynak;
            AssemblyName kurguAd� = new AssemblyName();
            kurguAd�.Name = "DinamikTip";
            AssemblyBuilder ab = saha.DefineDynamicAssembly (kurguAd�, AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule ("DinamikTip");
            TypeBuilder tb = mb.DefineType ("DinamikTip", TypeAttributes.Public);
            ConstructorBuilder cb = tb.DefineConstructor (MethodAttributes.Public, CallingConventions.Standard, null);
            ILGenerator ig = cb.GetILGenerator();
            ig.EmitWriteLine ("DinamikTip yarat�ld�!");
            ig.Emit (OpCodes.Ret);
            tb.CreateType();
            return ab;
        }
        [STAThread]
        static void Main() {
            Console.Write ("�al��an exe kurgu 'Assembly.GetExecutingAssembly()', tam yollu ba�ka kurgu 'Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory+'\\i�li\\j2sc#1902a.exe')', mevcut dizindeyse 'Assembly.Load('j2sc#1902a')' ile al�nabilir. [assembly:Vas�flar()], namespace �zerinde bulunmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��leyen ve dura�an iki exe kurgunun incelenmesi:");
            Assembly krg = Assembly.GetExecutingAssembly();
            Console.WriteLine ("�al��an kurgu ad�: {0}\nKonumu: {1}", krg.GetName().Name, krg.Location);
            Console.WriteLine ("Global �nbellek kurgusu mu? {0}", krg.GlobalAssemblyCache);
            Console.WriteLine ("Kurgunun s�r�m�: {0}", krg.ImageRuntimeVersion);
            Assembly krg2 = Assembly.LoadFile (AppDomain.CurrentDomain.BaseDirectory + ".\\i�li\\j2sc#1902a.exe");
            //Assembly krg2 = Assembly.Load ("j2sc#1902a");
            Console.WriteLine ("Di�er kurgu ad�: {0}", krg2.GetName().Name);
            Console.WriteLine ("{0} kurgudaki mevcut tipler:", krg2.GetName().Name);
            foreach (Type t in krg2.GetTypes()) Console.WriteLine ("\t"+t.Name);

            Console.WriteLine ("\nYollu kurgu Mscorlib.dll'un t�m tiplerinin 10'arl� listesi:");
            krg = Assembly.Load ("Mscorlib.dll");
            int i; ConsoleKeyInfo tu�;
            Type[] tipler = krg.GetTypes();
            for(i=0;i<tipler.Length;i++) {
                Console.WriteLine ("Tip-{0}: [{1}]", i, tipler [i]);
                if ((i+1)%10==0) {Console.Write ("\nDevam[e/h]:"); tu�=Console.ReadKey(); if(tu�.KeyChar=='h') break;}
            }
            Type tip = Type.GetType ("System.Reflection.Assembly");
            Console.WriteLine ("\n==>Bir sistem ar�iv tipi: {0}", tip);
            Console.WriteLine ("==>�ki ayr� AppDomain:UygSaha'da iki ayr� exe'nin ko�turulmas�...");
            AppDomain uygSaha1 = AppDomain.CurrentDomain;
            AppDomain uygSaha2 = AppDomain.CreateDomain ("uygSaha2");
            uygSaha1.ExecuteAssembly (".\\i�li\\j2sc#0101a.exe"); //AppDomain.Unload (uygSaha1);
            uygSaha2.ExecuteAssembly (".\\i�li\\j2sc#0101b.exe"); //AppDomain.Unload (uygSaha2);

            Console.WriteLine ("\nVerili Kurgudaki tiplerin aramaListesi'nde mevcudiyetleri kontrolu:");
            ArrayList aramaListesi = new ArrayList();
            aramaListesi.Add ("Kurgu"); aramaListesi.Add ("S�n�fA"); aramaListesi.Add ("S�n�fB"); aramaListesi.Add ("Delege");
            krg = Assembly.LoadFile (AppDomain.CurrentDomain.BaseDirectory + ".\\i�li\\j2sc#1902a.exe");
            MemberFilter s�zge� = new MemberFilter (MevcutMu);
            foreach (Module mod�l in krg.GetModules()) {
                foreach (Type t in mod�l.GetTypes()) {
                    if (aramaListesi.Contains (t.Name)) Console.WriteLine ("Tip: {0}-->BULUNDU", t.Name);
                    else Console.WriteLine ("Tip: {0}-->BULUNAMADI", t.Name );
                    MemberInfo[] mi = t.FindMembers (MemberTypes.All, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly, s�zge�, aramaListesi);
                    foreach (MemberInfo �b in mi) Console.WriteLine ("Bulunan �ye ad�: {0} �ye tipi: {1} Tipleme ad�: {2}", �b.Name, �b.MemberType, t.Name);
                }
            }

            Console.WriteLine ("\nDiyalogla se�ilen exe dosya detaylar�n�n altta a��klamal� a�a� �emas�:");
            Application.Run (new Kurgu());

            Console.WriteLine ("\nAkt�el sahada DinamikTip bir DinamikTip yaratma:");
            AppDomain akt�elSaha = AppDomain.CurrentDomain;
            akt�elSaha.AssemblyResolve += new ResolveEventHandler (OlayY�netimi��z�m�);
            DinamikTipYarat (akt�elSaha);

            Console.WriteLine ("\nInternalsVisibleTo vasf� i�in 'using System.Runtime.CompilerServices' gerekir:");
            Console.WriteLine ("==>S�n�f metodunu 'snf.Metot()'la �a��rma...");
            S�n�fC snfC = new S�n�fC(); snfC.MetotC();
            S�n�fD snfD = new S�n�fD(); snfD.MetotD();
            Console.WriteLine ("==>S�n�f metodunu 'metot.Invoke (ns,null)'la �a��rma...");
            krg = Assembly.Load ("j2sc#1902c");
            tip = krg.GetType (new S�n�fD().ToString()); MethodInfo metot = tip.GetMethod ("MetotD"); Object ns = Activator.CreateInstance (tip); metot.Invoke (ns, null);
            tip = krg.GetType (new S�n�fC().ToString()); metot = tip.GetMethod ("MetotC"); ns = Activator.CreateInstance (tip); metot.Invoke (ns, null);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}