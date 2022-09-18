using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PG_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Client();
        }

        private void Client()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT email, Id FROM ClientCredTb WHERE email = '"+txtLogin.Text+"'and Id = '"+txtPassword.Text+"'",conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Order ord = new Order();
                ord.Show();

            }
            else
            {
                MessageBox.Show("Username or Password invalid, Please try again");
                txtLogin.Clear();
                txtPassword.Clear();
            }
            conn.Close();
        }

        private void Employee()
        {

        }

        private void Manager()
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
