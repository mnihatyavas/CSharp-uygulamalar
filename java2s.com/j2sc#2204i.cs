// j2sc#2204i.cs: Tehirli sorgu, sql, DataGridView, DataSet �rne�i.

using System;
using System.Linq; //Enumerable i�in
using System.Collections.Generic; //List<> i�in
using System.Data.Linq; //DataContext i�in
using System.Data.Linq.Mapping; //Table ve Column i�in
using System.Windows.Forms; //Form i�in
using System.Data.SqlClient; //SqlConnection i�in
using System.Data; //DataSet i�in
namespace Query_Sorgu {
    public class Book {
        public String Title {get; set;}
        public override String ToString() {return Title;}
    }
    [Table(Name="Sales.Customer")]
    public class Customer {
        [Column] public string FirstName    {get; set;}
        [Column] public string LastName     {get; set;}
        [Column] public string EmailAddress {get; set;}
        public override string ToString() {return string.Format("{0} {1}\nEmail:   {2}", FirstName, LastName, EmailAddress);}
    }
    [Table]
    public class Customers {
        [Column]
        public string customerId;
        [Column]
        public string companyName;
        [Column]
        public string city;
        [Column]
        public string country;
    }
    class TehirliSorgu: Form {
        public TehirliSorgu() {InitializeComponent();}
        static public Book[] Books = {
            new Book {Title="Fas�lyenin Nimetleri"},
            new Book {Title="B�ib�l�n G�l A�k�"}
        };
        private void FormStrings_Load (object sender, EventArgs e) {
            String[] books = {"Fadimenin Pabucu", "Aytenin Bluzu", "Bilalin K�lah�", "R�dvan�n Sakal�", "Bekirin Derhesi"};
            var query =
                from book in books
                where book.Length > 10
                orderby book
                select new {Book = book.ToUpper()};
            dataGridView1.DataSource = query.ToList();
        }
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(272, 251);
            this.dataGridView1.TabIndex = 0;
            //
            // FormStrings
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (292, 271);
            this.Controls.Add (this.dataGridView1);
            this.Name = "FormStrings";
            this.Padding = new System.Windows.Forms.Padding (10);
            this.Text = "FormStrings";
            this.Load += new System.EventHandler (this.FormStrings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout (false);

        }
        private System.Windows.Forms.DataGridView dataGridView1;
        [Table (Name = "Contacts")]
        class Contact {
            [Column (IsPrimaryKey = true)]
            public int ContactID {get; set;}
            [Column (Name = "ContactName")]
            public string Name {get; set;}
            [Column]
            public string City {get; set;}
        }
        static void Main() {
            Console.Write ("Sorguya temel dizgedeki de�i�iklik, ba�kaca i�lem gerektirmeden sorguyu da tehiren g�nceller.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sorgunun temel dizisi sonradan de�i�irse sorgu da de�i�ir:");
            var y�llar=Enumerable.Range (1881, 58);
            Console.Write ("-->Y�llar(y): "); foreach (var y in y�llar) Console.Write(y+" "); Console.WriteLine();
            int i = 0;
            var sorgu1 =
                from y in y�llar
                select (++i + y);
            Console.Write ("-->Sorgu1(y):++i "); foreach (var n in sorgu1) Console.Write ("{0}:{1} ", n, i); Console.WriteLine();
            i = 0;
            var sorgu2 =
                from y in y�llar
                select (--i + y);
            Console.Write ("-->Sorgu2(y):--i "); foreach (var n in sorgu2) Console.Write ("{0}:{1} ", n, i); Console.WriteLine();
            y�llar=Enumerable.Range (2025, 58); //sorgular� etkiler
            Console.Write ("-->Sorgu1(y): "); foreach (var y in sorgu1) Console.Write(y+" "); Console.WriteLine();
            y�llar = Enumerable.Range (1881, 58);
            var sorgu3 = y�llar.Select (y => y + 58);
            Console.Write ("-->Sorgu3(y): "); foreach (var y in sorgu3) Console.Write(y+"|"); Console.WriteLine();
            var y�llar2 = new List<int>();
            y�llar2.Add (1881); y�llar2.Add (1938);
            var sorgu4 = y�llar2.Select (n => n + 10);
            y�llar2.Add (1957); y�llar2.Add (2025); //sorgular� etkiler
            Console.Write ("-->Sorgu4(y): "); foreach (int y in sorgu4) Console.Write(y+" | "); Console.WriteLine();

            Console.Write ("Kitap listesi formu: "); Application.Run (new TehirliSorgu());

            Console.WriteLine ("\n\n�evrimi�i veri taban�ndan tablo verileri okuma:");
            try {
            string yol = System.IO.Path.GetFullPath ("northwnd.mdf");
            DataContext db = new DataContext (yol);
            var contacts =
                from contact in db.GetTable<Contact>()
                where contact.City == "Paris"
                select contact;
            foreach (var contact in contacts) Console.WriteLine ("Bonjour " + contact.Name);
            }catch (Exception ht) {Console.WriteLine ("HATA = [{0}]", ht.Message);}

            Console.WriteLine ("\n:");
            try {
            SqlConnection thisConnection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;" +
                @"AttachDbFilename='NORTHWND.MDF';" +
                @"Integrated Security=True;Connect Timeout=30;User Instance=true");
            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", thisConnection);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();
            SqlDataAdapter custAdapter = new SqlDataAdapter("SELECT * FROM Customers", thisConnection);
            SqlDataAdapter orderAdapter = new SqlDataAdapter("SELECT * FROM Orders", thisConnection);
            custAdapter.Fill(thisDataSet, "Customers");
            orderAdapter.Fill(thisDataSet, "Orders");
            DataRelation custOrderRel = thisDataSet.Relations.Add("CustOrders",
                 thisDataSet.Tables["Customers"].Columns["CustomerID"],
                 thisDataSet.Tables["Orders"].Columns["CustomerID"]);
            var customers = thisDataSet.Tables["Customers"].AsEnumerable();
            var orders = thisDataSet.Tables["Orders"].AsEnumerable();
            var preferredCustomers = from c in customers
                where c.GetChildRows("CustOrders").Length > 10
                select c;
            foreach (var customer in preferredCustomers) {
                Console.WriteLine(customer.GetChildRows("CustOrders").Length);
                Console.WriteLine(customer["CustomerID"]);
            }
            thisConnection.Close();
            }catch (Exception ht) {Console.WriteLine ("HATA = [{0}]", ht.Message);}

            Console.WriteLine ("\n:");
            try {
            DataContext db = new DataContext(@"Data Source=.\SqlExpress;Initial Catalog=AdventureWorks;Integrated Security=True");
            Table<Customer> customers = db.GetTable<Customer>();
            var query = from customer in customers where customer.FirstName == "D" select customer;
            foreach(var c in query) Console.WriteLine (c.ToString());
            }catch (Exception ht) {Console.WriteLine ("HATA = [{0}]", ht.Message);}

            Console.WriteLine ("\n:");
            try {
            string connString = @"server = .\sqlexpress;integrated security = true;database = northwind";
            DataContext db = new DataContext(connString);
            Table<Customers> customers = db.GetTable<Customers>();
            var custs = from c in customers where c.country == "USA" orderby c.city select c;
            foreach (var c in custs) Console.WriteLine ("{0}, {1}, {2}, {3}", c.customerId, c.companyName, c.city, c.country);
            }catch (Exception ht) {Console.WriteLine ("HATA = [{0}]", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}