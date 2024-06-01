using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_AD
{
    public partial class Transaksi : Form
    {
        DataTable transaksi = new DataTable();
        DataTable idcust;
        DataTable totals = new DataTable();
        int x = 0;
        public Transaksi()
        {
            InitializeComponent();
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            FormKategori form1 = new FormKategori();
            form1.Hide();
            label6.Text = Form1.username;

            idcust = new DataTable();
            Form1.sqlquery = $"select Customer_id from customer where Nama_customer = '{Form1.username}';";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(idcust);
            label7.Text = idcust.Rows[0][0].ToString();

            //transaksi.Clear();
            label8.Text = DateTime.Now.ToString("yyyy/MM/dd");
            for (int i = 0; i < Cart.dtdetailed.Rows.Count; i++)
            {
                Label ket = new Label();
                transaksi = new DataTable();
                Form1.sqlquery = $"select p.Nama_produk, dt.Jumlah, p.harga, t.Total_harga from produk p, detail_transaksi dt, transaksi t where p.Produk_id = dt.Produk_id and dt.Transaksi_id = t.Transaksi_id and dt.transaksi_id = {Cart.lastindex};";
                Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
                Form1.mySqlDataAdapter.Fill(transaksi);

                
                ket.Text = transaksi.Rows[i][0].ToString();
                ket.Location = new Point(5, 5 + x);
                ket.AutoSize = true;
                panel1.Controls.Add(ket);

                Label ket2 = new Label();
                ket2.Text = transaksi.Rows[i][1].ToString();
                ket2.Location = new Point(255, 5 + x);
                ket2.AutoSize = true;
                panel1.Controls.Add(ket2);

                Label ket3 = new Label();
                ket3.Text = "Rp. " +transaksi.Rows[i][2].ToString();
                ket3.Location = new Point(420, 5 + x);
                ket3.AutoSize = true;
                panel1.Controls.Add(ket3);

                Label ket4 = new Label();
                int subtotal = Cart.quantity[i] * Convert.ToInt32(transaksi.Rows[i][2]);
                ket4.Text = "Rp. " + subtotal.ToString();
                ket4.Location = new Point(610, 5 + x);
                ket4.AutoSize = true;
                panel1.Controls.Add(ket4);
                x += 30;
            }
            Form1.sqlquery = $"select t.Total_harga from transaksi t where t.transaksi_id = {Cart.lastindex};";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(totals);
            label14.Text = "Rp. " + totals.Rows[0][0].ToString();
        }

        private void Transaksi_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormKategori form1 = new FormKategori();
            form1.Refresh();
            form1.Show();
        }
    }
}
