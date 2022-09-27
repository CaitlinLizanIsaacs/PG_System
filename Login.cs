using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PG_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Client()
        {

            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();

            string username = txtLogin.Text;
            string password = txtPassword.Text;

            DataTable table = new DataTable();

            SqlDataAdapter adapt = new SqlDataAdapter();

            string Query = "SELECT * FROM ClientCredTb WHERE email= @email AND password = @password";

            SqlCommand com = new SqlCommand(Query, connect);

            com.Parameters.Add("@email",SqlDbType.VarChar).Value = username;
            com.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            adapt.SelectCommand = com;

            adapt.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("You are logged in");
                Order ord = new Order();
                ord.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Your details are incorrect, Please try again");
            }
            

            connect.Close();


        }

        private void Employee()
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();


            string Query = "SELECT * FROM EmployeeTb WHERE employeeId = " +txtLogin.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["employeeId"].ToString();

                MaintainClient client = new MaintainClient();
                client.Show();
                this.Hide();
            }
            else

                MessageBox.Show("No record found");


            connect.Close();

          

        }
        private void Manager()
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();


            string Query = "SELECT * FROM ManagerTb WHERE managerId = '" + txtLogin.Text+"' AND surname = '"+txtPassword.Text+"'";

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["managerId"].ToString();
                txtPassword.Text = reader["surname"].ToString();
                MaintainEmployeeShifts maintain = new MaintainEmployeeShifts();
                maintain.Show();
                this.Hide();
            }
            else

                MessageBox.Show("No record found");


            connect.Close();

            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp add = new SignUp();
            add.Show();
            this.Hide();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Client();
            
        }
    }
}
