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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ALP_AD
{
    public partial class Form1 : Form
    {
        public static MySqlConnection sqlconnect;
        public static MySqlCommand sqlcommand;
        public static MySqlDataAdapter mySqlDataAdapter;
        public static MySqlDataReader mySqlDataReader;
        public static string connectionString;
        public static string sqlquery;
        public static string username;
        public static string cekkategori;
        public static string workingDirectory;
        public static string projectDirectory;
        public static string full_url;

        public static int cek = 0;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            Form1.workingDirectory = Environment.CurrentDirectory;
            Form1.projectDirectory = Directory.GetParent(Form1.workingDirectory).Parent.FullName;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = "server=localhost;uid=root;pwd=;database=clothingstore"; //ini ganti conection string kalian
            sqlconnect = new MySqlConnection(connectionString);
            MessageBox.Show(Form1.projectDirectory.ToString());
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string usernameoremail = tb_username.Text;
            string password = tb_pass.Text;
            username = usernameoremail;
            DataTable Login = new DataTable();
            Form1.sqlquery = "SELECT COUNT(*) FROM Customer WHERE(Nama_customer COLLATE utf8mb4_bg_0900_as_cs  LIKE '" + usernameoremail + "' COLLATE utf8mb4_bg_0900_as_cs  or Email_customer  COLLATE utf8mb4_bg_0900_as_cs like '" + usernameoremail + "' COLLATE utf8mb4_bg_0900_as_cs) AND Password_customer COLLATE utf8mb4_bg_0900_as_cs = '" + password + "' COLLATE utf8mb4_bg_0900_as_cs;";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Login);

            if (Login.Rows[0][0].ToString() == "1")
            {
                //this.Hide();
                //MessageBox.Show("Success");

                this.Visible = false;
                FormKategori kategori = new FormKategori();
                kategori.Show();


            }
            else
            {
                string incorrectlogin = Form1.projectDirectory + "\\Sound effect ALP\\639427__laurenponder__incorrect-chime.wav";

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(incorrectlogin);
                player.Play();

                MessageBox.Show("Invalid username or password");
            }
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            SignUp formsign = new SignUp();
            formsign.Show();

        }

        private void lbl_guestmode_Click(object sender, EventArgs e)
        {
            username = "Guest";
            DataTable Guest = new DataTable();
            Form1.sqlquery = "SELECT COUNT(*) FROM Customer WHERE(Nama_customer = 'Guest' or Email_customer = 'guest@gmail.com') AND Password_customer = '000000000';";
            Form1.sqlcommand = new MySqlCommand(Form1.sqlquery, Form1.sqlconnect);
            Form1.mySqlDataAdapter = new MySqlDataAdapter(Form1.sqlcommand);
            Form1.mySqlDataAdapter.Fill(Guest);

            if (Guest.Rows[0][0].ToString() == "1")
            {
                //this.Hide();
                //MessageBox.Show("Success");

                this.Visible = false;
                FormKategori kategori = new FormKategori();
                kategori.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                // Mengambil gambar dari file yang dipilih
                string imagePath = dialog.FileName;
                MessageBox.Show(imagePath);
                string fileName = Path.GetFileNameWithoutExtension(dialog.FileName);
                string newFileName = fileName;
                string fileExtension = Path.GetExtension(dialog.FileName);
                string folderPath = Form1.projectDirectory + "\\resource";
                img.Save(Path.Combine(folderPath, newFileName + fileExtension));
            }

            // Tampilkan gambar di PictureBox

        }
        
    }
}
