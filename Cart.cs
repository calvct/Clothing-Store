using System;
using System.Collections;
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
    public partial class Cart : Form
    {
        public static DataTable dtdetailed = new DataTable();
        DataTable dtmoney = new DataTable();
        Label total;
        PictureBox[] pb;
        Label[] lblname;
        Panel panel1;
        Button buy;
        Button[] plus;
        Button[] minus;
        Label qty;
        Label angka;
        public static int[] quantity;
        int itsminus = 0;
        int itsplus = 0;
        int totals = 0;
        public static int lastindex = 0;

        public Cart()
        {
            InitializeComponent();
            dtdetailed.Clear();
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;
            Form1.sqlquery = $"select p.Nama_produk, p.harga, p.produk_image, w.Nama_warna, u.Nama_ukuran, p.quantity from produk p, warna w, ukuran u, cart c, detail_cart d where c.Cart_id = d.Cart_id and p.Produk_id = d.Produk_id and w.Warna_id = d.Warna_id and u.Ukuran_id = d.Ukuran_id and c.Cart_id = (select Cart_id from cart where Nama_cartt = LOWER('Cart_{Form1.username}')); ";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtdetailed);
            int array = dtdetailed.Rows.Count;
            quantity = new int[array];
            if (quantity.Length > 0)
            {
                Array.Clear(quantity, 0, quantity.Length);
            }
            for (int i = 0; i < quantity.Length; i++)
            {
                quantity[i] = 1;
            }
            pb = new PictureBox[dtdetailed.Rows.Count];
            lblname = new Label[dtdetailed.Rows.Count];
            minus = new Button[dtdetailed.Rows.Count];
            plus = new Button[dtdetailed.Rows.Count];
        }

        private void Cart_Load(object sender, EventArgs e)
        {   
            updatelist();

        }

        private void Minus_Click(object sender, EventArgs e)
        {
            for(int i = 0; i< dtdetailed.Rows.Count; i++)
            {
                if(sender == minus[i])
                {
                    itsminus = i;
                }
            }
            if (quantity[itsminus] > 0)
            {
                quantity[itsminus] -= 1;
            }
            else
            {
                quantity[itsminus] = 0;
            }
            updatelist();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtdetailed.Rows.Count; i++)
            {
                if(sender == plus[i])
                {
                    itsplus = i;
                }
            }
            quantity[itsplus] += 1;
            updatelist();
        }
        public void updatelist()
        {
            this.SuspendLayout();
            this.Controls.Clear();
            int y = 0; int y1 = 33; int y3 = 85; int y4 = 135; int y6 = 185; int y7 = 225; int y8 = 226;
            for (int i = 0; i < dtdetailed.Rows.Count; i++)
            {
                Form1.full_url = Form1.projectDirectory + dtdetailed.Rows[i][2];
                pb[i] = new PictureBox();
                pb[i].SizeMode = PictureBoxSizeMode.Zoom;
                pb[i].ImageLocation = Form1.full_url;
                pb[i].Location = new Point(5, 5 + y);
                pb[i].Size = new Size(500, 550);
                pb[i].Tag = i;
                this.Controls.Add(pb[i]);
                y += 535;

                lblname[i] = new Label();
                lblname[i].Text = "Product Name      : " + dtdetailed.Rows[i][0].ToString();
                lblname[i].AutoSize = true;
                lblname[i].Location = new Point(525, y1);
                lblname[i].Font = new Font("Arial", 20);
                this.Controls.Add(lblname[i]);
                y1 += 535;

                Label lblharga = new Label();
                lblharga.Text = "Price                    : Rp. " + dtdetailed.Rows[i][1].ToString();
                lblharga.AutoSize = true;
                lblharga.Location = new Point(525, y3);
                lblharga.Font = new Font("Arial", 20);
                this.Controls.Add(lblharga);
                y3 += 535;

                Label wrn = new Label();
                wrn.Text = "Color                   : " + dtdetailed.Rows[i][3].ToString();
                wrn.AutoSize = true;
                wrn.Location = new Point(525, y4);
                wrn.Font = new Font("Arial", 20);
                this.Controls.Add(wrn);
                y4 += 535;

                Label sz = new Label();
                sz.Text = "Size                     : " + dtdetailed.Rows[i][4].ToString();
                sz.AutoSize = true;
                sz.Location = new Point(525, y6);
                sz.Font = new Font("Arial", 20);
                this.Controls.Add(sz);
                y6 += 535;

                qty = new Label();
                qty.AutoSize = true;
                qty.Text = "Quantity               :";
                qty.Location = new Point(525, y7);
                qty.Font = new Font("Arial", 20);
                this.Controls.Add(qty);

                minus[i] = new Button();
                minus[i].AutoSize = true;
                minus[i].Size = new Size(30, 10);
                minus[i].TextAlign = ContentAlignment.MiddleCenter;
                minus[i].Text = "-";
                minus[i].Font = new Font("Arial", 14);
                minus[i].Location = new Point(775, y8);
                minus[i].Click += Minus_Click;
                this.Controls.Add(minus[i]);

                angka = new Label();
                angka.AutoSize = true;
                angka.Text = quantity[i].ToString();
                angka.TextAlign = ContentAlignment.MiddleCenter;
                angka.Location = new Point(835, y7);
                angka.Font = new Font("Arial", 20);
                this.Controls.Add(angka);

                plus[i] = new Button();
                plus[i].AutoSize = true;
                plus[i].Size = new Size(30, 10);
                plus[i].TextAlign = ContentAlignment.MiddleCenter;
                plus[i].Text = "+";
                plus[i].Font = new Font("Arial", 14);
                plus[i].Location = new Point(895, y8);
                plus[i].Click += Plus_Click;
                this.Controls.Add(plus[i]);
                y7 += 535;
                y8 += 535;              
            }
            
            total = new Label();
            total.AutoSize = true;
            totals = 0;
            for (int i = 0; i < dtdetailed.Rows.Count; i++)
            {
                totals += Convert.ToInt32(dtdetailed.Rows[i][1]) * quantity[i];
                total.Text = "Total : Rp. " + totals.ToString();
            }
            total.Location = new Point(0, y7);
            total.Font = new Font("Arial", 20);
            this.Controls.Add(total);

            panel1 = new Panel();
            panel1.Size = new Size(1900, 70);
            panel1.Dock = DockStyle.Bottom;
            this.Controls.Add(panel1);

            buy = new Button();
            buy.Size = panel1.Size;
            buy.Tag = "beli";
            buy.Text = "Buy All Item";
            buy.TextAlign = ContentAlignment.MiddleCenter;
            buy.Font = new Font("Arial", 40);
            buy.BackColor = Color.Green;
            buy.ForeColor = Color.White;
            buy.Location = new Point(0, 0);
            buy.Click += Buy_Click;
            panel1.Controls.Add(buy);
            this.ResumeLayout(true);
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            Form1.sqlquery = $"select e_money from customer where Nama_customer = '{Form1.username}';";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtmoney);

            int uang = Convert.ToInt32(dtmoney.Rows[0][0]);
            if (uang < totals)
            {
                MessageBox.Show("Saldo tidak cukup. Silahkan Top-up terlebih dahulu","Saldo Kurang",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
            if (uang > totals)
            {
                int hasil = uang - totals;
                Saldo.wallet = hasil.ToString();

                // update uang user
                Form1.sqlquery = $"update customer set e_money = '{hasil}' where Nama_customer = '{Form1.username}';";
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


                // update quantity produk
                for (int i = 0; i < dtdetailed.Rows.Count; i++)
                {
                    Form1.sqlquery = $"update produk set quantity = '{Convert.ToInt32(dtdetailed.Rows[i][5]) - quantity[i]}' where Nama_produk = '{dtdetailed.Rows[i][0]}';";
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
                }

                Form1.sqlquery = $"insert into TRANSAKSI (Customer_id, Tanggal_transaksi, Total_harga)\r\nvalues\r\n((SELECT Customer_id FROM Customer WHERE Nama_customer = '{Form1.username}'),'{DateTime.Now.ToString("yyyy/MM/dd")}',{totals});";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                    Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();
                    lastindex = Convert.ToInt32(Form1.sqlcommand.LastInsertedId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Form1.sqlconnect.Close();
                }
                for (int i = 0; i < dtdetailed.Rows.Count; i++)
                {
                    Form1.sqlquery = $"insert into detail_transaksi(Transaksi_id, Produk_id, Warna_id, Ukuran_id, Jumlah) values({lastindex}, (select Produk_id from produk where Nama_produk = '{dtdetailed.Rows[i][0].ToString()}'),(select Warna_id from warna where Nama_warna = '{dtdetailed.Rows[i][3].ToString()}'), (select Ukuran_id from ukuran where Nama_ukuran = '{dtdetailed.Rows[i][4].ToString()}'), {quantity[i]});";
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
                }
                
                Form1.sqlquery = $"delete FROM detail_cart where Cart_id = (select Cart_id from cart where Nama_cartt = 'Cart_{Form1.username}');";
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

                this.Controls.Clear();
                this.Controls.Add(panel1);
                Transaksi byr = new Transaksi();
                byr.Show();
            }
            
        }
    }
    
}
