using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ALP_AD
{
    public partial class Login : Form
    {
        Form1 signn = new Form1(); //karena pakai caranya ko steven form 2 "login" sudah tidak dipakai
        public Login()
        {
            InitializeComponent();
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {   
            /*
            this.Visible = false;
            //Form1.cek++;

            /*
            this.Visible = false;
                MainMenu goToMainMenu = new MainMenu();
                goToMainMenu.ShowDialog();
            


            SignUp formsign = new SignUp();
            formsign.FormBorderStyle = FormBorderStyle.None;
            formsign.TopLevel = false;
            //signn.panel1.Controls.Add(formsign);
            formsign.Show();

            MessageBox.Show("test");
            
            

            //MessageBox.Show(Form1.cek.ToString() + " Weleh");
            */
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            /*
            string usernameoremail = tb_username.Text;
            string password = tb_pass.Text;

            DataTable Login = new DataTable();
            Form1.sqlquery = "SELECT COUNT(*) FROM Customer WHERE(Nama_customer = '" + usernameoremail + "' or Email_customer = '" + usernameoremail + "') AND Password_customer = '" + password + "';";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Login);

            if (Login.Rows[0][0].ToString() == "1")
            {               
                //this.Hide();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            */

        }

        private void lbl_guestmode_Click(object sender, EventArgs e)
        {
            /*
            DataTable Guest = new DataTable();
            Form1.sqlquery = "SELECT COUNT(*) FROM Customer WHERE(Nama_customer = 'Guest' or Email_customer = 'guest@gmail.com') AND Password_customer = '000000000';";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Guest);

            if (Guest.Rows[0][0].ToString() == "1")
            {
                //this.Hide();
                MessageBox.Show("Success");
            }
            */
        }
    }
}
