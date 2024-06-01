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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void lbl_login_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Visible = false;
            Form1 formlogin = new Form1();
            formlogin.Show();
        }

        private void tb_newemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_newuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_newpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            string newusername = tb_newuser.Text;
            string newemail = tb_newemail.Text;
            string newpassword = tb_newpass.Text;

            Form1.sqlquery = $"insert into Customer (Nama_customer, Email_customer, Password_customer)\r\nvalues\r\n('{newusername}','{newemail}','{newpassword}');";

            try
            {
                Form1.sqlconnect.Open();
                Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
                Form1.mySqlDataReader = Form1.sqlcommand.ExecuteReader();

                tb_newuser.Clear();
                tb_newemail.Clear();
                tb_newpass.Clear();

                MessageBox.Show("Sign Up is Successful");
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
