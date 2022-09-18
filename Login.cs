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
            Manager();
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
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            SqlCommand command;
            SqlDataReader dr;

            string sql, output = "";

            sql = "SELECT employeeId, shifts from employeeTb";
            command = new SqlCommand(sql, conn);
            dr = command.ExecuteReader();

            while(dr.Read())
            {
                output = output + dr.GetValue(1) + "-" + dr.GetValue(7);

                if(dr.GetString(1) != txtLogin.Text || dr.GetString(7)!= txtPassword.Text)
                {
                    MessageBox.Show("Username and password is incorrect, Please try again");
                }
                

            }
            dr.Close();
            conn.Close();

            MessageBox.Show("Successful Login");

            MaintainClient client = new MaintainClient();
            client.Show();

        }

        private void Manager()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            SqlDataAdapter adapt;
            SqlCommand command;

            connect.Open();

            command = new SqlCommand("SELECT * FROM ManagerTb WHERE surname = '"+txtLogin.Text+"' AND managerId = "+txtPassword,connect);
            adapt = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "ManagerTb");

            int i = ds.Tables[0].Rows.Count;

            if(i == 1)
            {
                MaintainEmployeeShifts employee = new MaintainEmployeeShifts();
                employee.Show();
                this.Hide();

            }

            connect.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
