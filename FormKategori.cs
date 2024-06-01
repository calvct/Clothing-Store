using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALP_AD
{
    public partial class FormKategori : Form
    {
        

        public FormKategori()
        {
            InitializeComponent();
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;
        }



        public void UpdateEmoneyBalanceLabel(decimal emoneyBalance)
        {
            label2.Text = emoneyBalance.ToString();
        }


        private void FormKategori_Load(object sender, EventArgs e)
        {
            lbl_username.Text = Form1.username;
            if(lbl_username.Text == "Guest")
            {
                label2.Text = "0";
            }
            else
            {
                string customerName = Form1.username;
                decimal emoneyBalance = GetEmoneyBalance(customerName);
                label2.Text = emoneyBalance.ToString();
            }

            string sounddir = Form1.projectDirectory + "\\Sound effect ALP\\click-124467.wav";

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(sounddir);
            player.Play();
        }

        private decimal GetEmoneyBalance(string customerName)
        {
            decimal emoneyBalance = 0;

            using (MySqlConnection sqlconnect = new MySqlConnection(Form1.connectionString))
            {
                sqlconnect.Open();

                string query = "SELECT e_money FROM Customer WHERE Nama_customer = @CustomerName";

                using (MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnect))
                {
                    sqlcommand.Parameters.AddWithValue("@CustomerName", customerName);

                    using (MySqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            emoneyBalance = reader.GetDecimal(0);
                        }
                    }
                }
            }

            return emoneyBalance;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "1"; // kategori t-shirt
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "2"; // kategori jeans
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "3"; // kategori dress
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "4"; // kategori sweater
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "5"; // kategori shoes
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "6"; // kategori aksesoris
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "7"; // kategori activewear
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1.cekkategori = "8"; // kategori outwear
            FormTshirt tshirtform = new FormTshirt();
            tshirtform.Show();
            
        }

        private void saldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbl_username.Text == "Guest")
            {
                MessageBox.Show("You Must Login First", "Error");
            }
            else
            {
                Saldo Saldo = new Saldo();
                Saldo.Show();
            }
        }

        private void lbl_username_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbl_username.Text == "Guest")
            {
                MessageBox.Show("You Must Login First", "Error");
            }
            else
            {
                Cart carts = new Cart();
                carts.Show();
            }
        }

        private void wishlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbl_username.Text == "Guest")
            {
                MessageBox.Show("You Must Login First", "Error");
            }
            else
            {
                Wishlist wish = new Wishlist();
                wish.Show();
            }
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To Log Out" + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 login = new Form1();

                //Form1.Login.Close();
                this.Close();
                MessageBox.Show("Successfully Log Out ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                login.Show();

            }
        }
    }
}
