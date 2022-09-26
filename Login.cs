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

namespace PG_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client();
            Employee();
            Manager();
        }

        private void Client()
        {

            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();


            string Query = "SELECT * FROM ClientCredTb WHERE email = '" + txtLogin.Text + "' AND surname = '" + txtPassword.Text + "'";

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["email"].ToString();
                txtPassword.Text = reader["surname"].ToString();

                Order ord = new Order();
                ord.Show();
                this.Hide();

            }
            else

                MessageBox.Show("No record found");


            connect.Close();

        }

        private void Employee()
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();


            string Query = "SELECT * FROM EmployeeTb WHERE employeeId = '" + txtLogin.Text + "' AND surname = '" + txtPassword.Text + "'";

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["employeeId"].ToString();
                txtPassword.Text = reader["surname"].ToString();

                MaintainClient client = new MaintainClient();
                client.Show();
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
            }
            else

                MessageBox.Show("No record found");


            connect.Close();

        }
    }
}
