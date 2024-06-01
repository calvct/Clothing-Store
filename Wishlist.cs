using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ALP_AD
{
    public partial class Wishlist : Form
    {
        DataTable dtdetail = new DataTable();
        public Wishlist()
        {
            InitializeComponent();
        }

        private void Wishlist_Load(object sender, EventArgs e)
        {
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;
            updatedgv();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Grid1Click();
            
        }
        public void Grid1Click()
        {
            if (dataGridView1.CurrentCell.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                tbox_name.Text = row.Cells["Nama Produk"].Value.ToString();
                tbox_harga.Text = row.Cells["Harga"].Value.ToString();
                tbox_warna.Text = row.Cells["Warna"].Value.ToString();
                tbox_ukuran.Text = row.Cells["Ukuran"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.sqlquery = $"delete from detail_wishlist where Produk_id = (select Produk_id from produk where Nama_produk = '{tbox_name.Text}');";
            try
            {
                Form1.sqlconnect.Open();
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Form1.sqlconnect.Close();
            }
            updatedgv();
        }
        public void updatedgv()
        {
            dtdetail.Clear();
            Form1.sqlquery = $"select p.Nama_produk as 'Nama Produk', p.harga as 'Harga', w.Nama_warna as 'Warna', u.Nama_ukuran as 'Ukuran' from produk p, warna w, ukuran u, wishlists ws, detail_wishlist d where ws.Wishlist_id = d.Wishlist_id and p.Produk_id = d.Produk_id and w.Warna_id = d.Warna_id and u.Ukuran_id = d.Ukuran_id and ws.Wishlist_id = (select Wishlist_id from wishlists where Nama_Wishlist = LOWER('Wish_{Form1.username}')); ";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtdetail);
            dataGridView1.DataSource = dtdetail;
        }
    }
}
