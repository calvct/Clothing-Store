using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ALP_AD
{
    public partial class FormTshirt : Form
    {
        public static List<string> newcart = new List<string>();
        
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtcart = new DataTable();
        DataTable dtwish = new DataTable();
        int y = 0; int y1 = 33;int y2 =75;int y3 = 115; int y4 = 155; int y5 = 190; int y6 = 225; int y7 = 258;
        int y8 = 345; int y9 = 0;
        Button[] cart;
        Button[] wish;
        ComboBox[] cbwrn;
        ComboBox[] cbsz;
        PictureBox[] pb;
        Label[] lblname;
        int cartcount = 0;
        string query = "";
        int wrncount = 0;
        int szcount = 0;
        int wrn = 0;
        int sz = 0;
        bool cbwrnchanged = false;
        bool cbszchanged = false;
        bool cartfounded = false;
        bool wishfounded = false;
        int wishcount = 0;
        public FormTshirt()
        {
            InitializeComponent();
            // select warna
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;

            // select keterangan
            Form1.sqlquery = $"select Produk_id, Nama_produk, harga, quantity, produk_image from produk where kategori_id = '{Form1.cekkategori}';";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dt);

            // select warna
            Form1.sqlquery = "select Warna_id, Nama_warna from warna;";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dt1);

            // select size
            Form1.sqlquery = "select Ukuran_id, Nama_ukuran from ukuran;";
            Form1.sqlconnect = new MySqlConnection(Form1.connectionString);
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dt2);
        }


        private void FormTshirt_Load(object sender, EventArgs e)
        {
            pb = new PictureBox[dt.Rows.Count];
            cbwrn = new ComboBox[dt.Rows.Count];
            cbsz = new ComboBox[dt.Rows.Count];
            wish = new Button[dt.Rows.Count];
            cart = new Button[dt.Rows.Count];
            lblname = new Label[dt.Rows.Count];

            // print tampilan product
            if (Form1.username == "Guest")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Form1.full_url = Form1.projectDirectory + dt.Rows[i][4];
                    MessageBox.Show(Form1.projectDirectory);
                    MessageBox.Show(dt.Rows[i][4].ToString());
                    MessageBox.Show(Form1.full_url);
                    pb[i] = new PictureBox();
                    pb[i].SizeMode = PictureBoxSizeMode.Zoom;
                    pb[i].ImageLocation = Form1.full_url;
                    pb[i].Location = new Point(5, 5 + y);
                    pb[i].Size = new Size(500, 550);
                    pb[i].Tag = i;
                    panel1.Controls.Add(pb[i]);
                    y += 535;

                    lblname[i] = new Label();
                    lblname[i].Text = "Product Name      : " + dt.Rows[i][1].ToString();
                    lblname[i].AutoSize = true;
                    lblname[i].Location = new Point(525, y1);
                    lblname[i].Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblname[i]);
                    y1 += 535;

                    Label lblqyt = new Label();
                    if (dt.Rows[i][3].ToString() != "0")
                    {
                        lblqyt.Text = $"Product Quantity  : {dt.Rows[i][3]}";
                        lblqyt.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        lblqyt.Text = "Product Quantity  : Sold Out";
                        lblqyt.BackColor = Color.Red;
                    }
                    lblqyt.AutoSize = true;
                    lblqyt.Location = new Point(525, y2);
                    lblqyt.Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblqyt);
                    y2 += 535;

                    Label lblharga = new Label();
                    lblharga.Text = "Price                    : Rp. " + dt.Rows[i][2].ToString();
                    lblharga.AutoSize = true;
                    lblharga.Location = new Point(525, y3);
                    lblharga.Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblharga);
                    y3 += 535;

                    Label wrn = new Label();
                    wrn.Text = "Color";
                    wrn.AutoSize = true;
                    wrn.Location = new Point(525, y4);
                    wrn.Font = new Font("Arial", 20);
                    panel1.Controls.Add(wrn);
                    y4 += 535;

                    cbwrn[i] = new ComboBox();
                    cbwrn[i].DataSource = dt1;
                    cbwrn[i].DisplayMember = "Nama_warna";
                    cbwrn[i].ValueMember = "Warna_id";
                    cbwrn[i].Location = new Point(525, y5);
                    cbwrn[i].Font = new Font("Arial", 15);
                    cbwrn[i].Tag = i;
                    panel1.Controls.Add(cbwrn[i]); ;
                    y5 += 535;

                    Label sz = new Label();
                    sz.Text = "Size";
                    sz.AutoSize = true;
                    sz.Location = new Point(525, y6);
                    sz.Font = new Font("Arial", 20);
                    panel1.Controls.Add(sz);
                    y6 += 535;

                    cbsz[i] = new ComboBox();
                    cbsz[i].DataSource = dt2;
                    cbsz[i].DisplayMember = "Nama_ukuran";
                    cbsz[i].ValueMember = "Ukuran_id";
                    cbsz[i].Font = new Font("Arial", 15);
                    cbsz[i].Location = new Point(525, y7);
                    cbsz[i].Tag = i;
                    panel1.Controls.Add(cbsz[i]);
                    y7 += 535;

                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Form1.full_url = Form1.projectDirectory + dt.Rows[i][4];
                    pb[i] = new PictureBox();
                    pb[i].SizeMode = PictureBoxSizeMode.Zoom;
                    pb[i].ImageLocation = Form1.full_url;
                    pb[i].Location = new Point(5, 5 + y);
                    pb[i].Size = new Size(500, 550);
                    pb[i].Tag = i;
                    panel1.Controls.Add(pb[i]);
                    y += 535;

                    lblname[i] = new Label();
                    lblname[i].Text = "Product Name      : " + dt.Rows[i][1].ToString();
                    lblname[i].AutoSize = true;
                    lblname[i].Location = new Point(525, y1);
                    lblname[i].Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblname[i]);
                    y1 += 535;

                    Label lblqyt = new Label();
                    if (dt.Rows[i][3].ToString() != "0")
                    {
                        lblqyt.Text = $"Product Quantity  : {dt.Rows[i][3]}";
                        lblqyt.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        lblqyt.Text = "Product Quantity  : Sold Out";
                        lblqyt.BackColor = Color.Red;
                    }
                    lblqyt.AutoSize = true;
                    lblqyt.Location = new Point(525, y2);
                    lblqyt.Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblqyt);
                    y2 += 535;

                    Label lblharga = new Label();
                    lblharga.Text = "Price                    : Rp. " + dt.Rows[i][2].ToString();
                    lblharga.AutoSize = true;
                    lblharga.Location = new Point(525, y3);
                    lblharga.Font = new Font("Arial", 20);
                    panel1.Controls.Add(lblharga);
                    y3 += 535;

                    Label wrn = new Label();
                    wrn.Text = "Color";
                    wrn.AutoSize = true;
                    wrn.Location = new Point(525, y4);
                    wrn.Font = new Font("Arial", 20);
                    panel1.Controls.Add(wrn);
                    y4 += 535;

                    cbwrn[i] = new ComboBox();
                    cbwrn[i].DataSource = dt1;
                    cbwrn[i].DisplayMember = "Nama_warna";
                    cbwrn[i].ValueMember = "Warna_id";
                    cbwrn[i].Location = new Point(525, y5);
                    cbwrn[i].Font = new Font("Arial", 15);
                    cbwrn[i].Tag = i;
                    cbwrn[i].SelectionChangeCommitted += Cbwrn_SelectionChangeCommitted;
                    panel1.Controls.Add(cbwrn[i]);
                    y5 += 535;

                    Label sz = new Label();
                    sz.Text = "Size";
                    sz.AutoSize = true;
                    sz.Location = new Point(525, y6);
                    sz.Font = new Font("Arial", 20);
                    panel1.Controls.Add(sz);
                    y6 += 535;

                    cbsz[i] = new ComboBox();
                    cbsz[i].DataSource = dt2;
                    cbsz[i].DisplayMember = "Nama_ukuran";
                    cbsz[i].ValueMember = "Ukuran_id";
                    cbsz[i].Font = new Font("Arial", 15);
                    cbsz[i].Location = new Point(525, y7);
                    cbsz[i].Tag = i;
                    cbsz[i].SelectionChangeCommitted += Cbsz_SelectionChangeCommitted;
                    panel1.Controls.Add(cbsz[i]);
                    y7 += 535;

                    cart[i] = new Button();
                    wish[i] = new Button();
                    cart[i].AutoSize = true;
                    cart[i].Text = "Add to Cart";
                    cart[i].Font = new Font("Arial", 10);
                    cart[i].Size = new Size(90, 50);
                    cart[i].Location = new Point(525, y8);
                    cart[i].Tag = dt.Rows[i][1].ToString();
                    cart[i].Visible = false;
                    cart[i].Click += Cart_Click; 
                    panel1.Controls.Add(cart[i]);

                    wish[i].AutoSize = true;
                    wish[i].Text = "Add to wishlist";
                    wish[i].Font = new Font("Arial", 10);
                    wish[i].Location = new Point(640, y8);
                    wish[i].Size = new Size(90, 50);
                    wish[i].Visible = false;
                    wish[i].Tag = dt.Rows[i][1].ToString();
                    wish[i].Click += wish_Click;
                    panel1.Controls.Add(wish[i]);
                    y8 += 535;
                }
            }
        }


        private void wish_Click(object sender, EventArgs e)
        {
            MessageBox.Show(wish.Length.ToString());
            string penampung = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sender == wish[i])
                {
                    wishcount = i;
                }
            }
            MessageBox.Show(wishcount.ToString());
            penampung = wish[wishcount].Tag.ToString();
            dtwish.Clear();
            query = "select Wishlist_id, Nama_Wishlist from wishlists";
            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtwish);
            if(dtwish.Rows.Count == 0)
            {
                query = $"insert into wishlists(Customer_id, Nama_Wishlist) values ((select Customer_id from Customer where Nama_Customer = '{Form1.username}'), lower('Wish_{Form1.username}'));";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                query = $"insert into detail_wishlist(Wishlist_id, Produk_id, Warna_id, Ukuran_id) values((select Wishlist_id from wishlists where Wishlist_id = (select Wishlist_id from wishlists where Nama_Wishlist = lower('Wish_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
            else
            {
                for (int i = 0; i < dtwish.Rows.Count; i++)
                {
                    
                    if (dtwish.Rows[i][1].ToString() == "wish_"+Form1.username.ToLower())
                    {
                        wishfounded = true;
                    }
                }
                if (wishfounded == true)
                {
                    query = $"insert into detail_wishlist(Wishlist_id, Produk_id, Warna_id, Ukuran_id) values((select Wishlist_id from wishlists where Wishlist_id = (select Wishlist_id from wishlists where Nama_Wishlist = lower('Wish_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                else if (wishfounded == false)
                {

                    query = $"insert into wishlists(Customer_id, Nama_Wishlist) values ((select Customer_id from Customer where Nama_Customer = '{Form1.username}'), lower('Wish_{Form1.username}'));";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                    query = $"insert into detail_wishlist(Wishlist_id, Produk_id, Warna_id, Ukuran_id) values((select Wishlist_id from wishlists where Wishlist_id = (select Wishlist_id from wishlists where Nama_Wishlist = lower('Wish_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                    try
                    {
                        Form1.sqlconnect.Open();
                        Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
            }
            
            
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            string penampung = "";
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if(sender == cart[i])
                {
                    cartcount = i;
                }
            }
            penampung = cart[cartcount].Tag.ToString();
            dtcart.Clear();
            query = "select Cart_id, Nama_cartt from cart";
            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(dtcart);
            
            if (dtcart.Rows.Count == 0) 
            {
                query = $"insert into cart(Customer_id, Nama_cartt) values ((select Customer_id from Customer where Nama_Customer = '{Form1.username}'), lower('Cart_{Form1.username}'));";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                query = $"insert into detail_cart(Cart_id, Produk_id, Warna_id, Ukuran_id) values((select Cart_id from cart where Cart_id = (select Cart_id from cart where Nama_cartt = lower('Cart_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                try
                {
                    Form1.sqlconnect.Open();
                    Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
            else
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i][1].ToString() == "cart_" + Form1.username.ToLower())
                    {
                        cartfounded = true;
                    }
                }
                if (cartfounded == true)
                {
                        query = $"insert into detail_cart(Cart_id, Produk_id, Warna_id, Ukuran_id) values((select Cart_id from cart where Cart_id = (select Cart_id from cart where Nama_cartt = lower('Cart_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                else if(cartfounded == false)
                {

                        query = $"insert into cart(Customer_id, Nama_cartt) values ((select Customer_id from Customer where Nama_Customer = '{Form1.username}'), lower('Cart_{Form1.username}'));";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
                        query = $"insert into detail_cart(Cart_id, Produk_id, Warna_id, Ukuran_id) values((select Cart_id from cart where Cart_id = (select Cart_id from cart where Nama_cartt = lower('Cart_{Form1.username}'))),(select Produk_id from produk where Nama_Produk = '{penampung}'), {wrn},{sz});";
                        try
                        {
                            Form1.sqlconnect.Open();
                            Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect);
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
            }

            
           
        }

        private void Cbsz_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbszchanged = true;
            
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (sender == cbsz[i])
                {
                    szcount = i;
                    
                     
                    
                }
            }
            if (dt.Rows[szcount][3].ToString() != "0")
            {
                if (cbszchanged == true && cbwrnchanged == true)
                {
                    wish[szcount].Visible = true;
                    cart[szcount].Visible = true;
                }
                else
                {
                    wish[szcount].Visible = false;
                    cart[szcount].Visible = false;
                }
            }
            sz = Convert.ToInt32(cbsz[szcount].SelectedValue.ToString());
            //MessageBox.Show(sz.ToString());
        }

        private void Cbwrn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbwrnchanged = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sender == cbwrn[i])
                {
                    wrncount = i;
                    
                    
                }
            }
            if(dt.Rows[wrncount][3].ToString() != "0")
            {
                if (cbszchanged == true && cbwrnchanged == true)
                {
                    wish[wrncount].Visible = true;
                    cart[wrncount].Visible = true;
                }
                else
                {
                    wish[wrncount].Visible = false;
                    cart[wrncount].Visible = false;
                }
            }
           
            wrn = Convert.ToInt32(cbwrn[wrncount].SelectedValue.ToString());
            //MessageBox.Show(wrn.ToString());
        }
    }
}
