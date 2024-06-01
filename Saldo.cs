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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ALP_AD
{
    public partial class Saldo : Form
    {
        public static string wallets;
        public static string wallet;
       
        

        
        public Saldo()
        {
            InitializeComponent();
            
        }
        

        private void Saldo_Load(object sender, EventArgs e)
        {
            
            label4.Text =  Form1.username;
            string customerName = Form1.username;
            decimal emoneyBalance = GetEmoneyBalance(customerName);
            wallet = emoneyBalance.ToString();
            label3.Text = wallet;
            button10.Click += MoneyButton_Click;
            button20.Click += MoneyButton_Click;
            button50.Click += MoneyButton_Click;
            button100.Click += MoneyButton_Click;
            button150.Click += MoneyButton_Click;
            button200.Click += MoneyButton_Click;
            button500.Click += MoneyButton_Click;
            button1000.Click += MoneyButton_Click;
            if (Form1.username == "Guest")
            {
                button1.Enabled = false;
                button10.Enabled = false;
                button20.Enabled = false;
                button50.Enabled = false;
                button100.Enabled = false;
                button150.Enabled = false;
                button200.Enabled = false;
                button500.Enabled = false;
                button1000.Enabled = false;
            }
            
        }
        private void MoneyButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            
            DialogResult result = MessageBox.Show("Do you want to top up " + buttonText + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                string nominal = buttonText.Replace(".", "").Replace(",", "").Replace("Rp", "");
                decimal topUpAmount = decimal.Parse(nominal);

                
                string customerName = label4.Text;
                UpdateEmoneyBalance(customerName, topUpAmount);

                // Refresh the e-money balance display
                decimal emoneyBalance = GetEmoneyBalance(customerName);
                label3.Text = emoneyBalance.ToString();
                wallets = emoneyBalance.ToString();

                // Show a success message
                MessageBox.Show("Successfully topped up " + buttonText + " to e-money balance.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void UpdateEmoneyBalance(string customerName, decimal topUpAmount)
        {
            using (MySqlConnection sqlconnect = new MySqlConnection(Form1.connectionString))
            {
                sqlconnect.Open();

                string updateQuery = "UPDATE Customer SET e_money = e_money + @TopUpAmount WHERE Nama_customer = @CustomerName";

                using (MySqlCommand sqlcommand = new MySqlCommand(updateQuery, sqlconnect))
                {
                    sqlcommand.Parameters.AddWithValue("@TopUpAmount", topUpAmount);
                    sqlcommand.Parameters.AddWithValue("@CustomerName", customerName);

                    sqlcommand.ExecuteNonQuery();
                }
            }

            // Update the e-money balance in FormKategori
            if (Application.OpenForms["FormKategori"] is FormKategori formKategori)
            {
                decimal emoneyBalance = GetEmoneyBalance(customerName);
                formKategori.UpdateEmoneyBalanceLabel(emoneyBalance);
            }
        }

        private decimal GetEmoneyBalance(string customerName)
        {
            decimal emoneyBalance = 0;

            using (Form1.sqlconnect = new MySqlConnection(Form1.connectionString))
            {
                Form1.sqlconnect.Open();

                string query = "SELECT e_money FROM Customer WHERE Nama_customer = @CustomerName";

                using (Form1.sqlcommand = new MySqlCommand(query, Form1.sqlconnect))
                {
                    Form1.sqlcommand.Parameters.AddWithValue("@CustomerName", customerName);

                    using (MySqlDataReader reader = Form1.sqlcommand.ExecuteReader())
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


    }
}
