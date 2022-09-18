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
        }

        private void Client()
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);
            connect.Open();

            string Employee = txtLogin.Text;
            //string Surname = txtPassword.Text;


            string Query = "SELECT * FROM ClientCredTb WHERE Id = " + txtLogin.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["Id"].ToString();
                //txtPassword.Text = reader["surname"].ToString();
                Order order = new Order();
                order.Show();
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

            string Employee = txtLogin.Text;
            //string Surname = txtPassword.Text;


            string Query = "SELECT * FROM EmployeeTb WHERE employeeId = " + txtLogin.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["employeeId"].ToString();
                //txtPassword.Text = reader["surname"].ToString();
                MaintainClient maintain = new MaintainClient();
                maintain.Show();
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

            string Manager = txtLogin.Text;
            //string Surname = txtPassword.Text;


            string Query = "SELECT * FROM ManagerTb WHERE managerId = " + txtLogin.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtLogin.Text = reader["managerId"].ToString();
                //txtPassword.Text = reader["surname"].ToString();
                MaintainEmployeeShifts maintain = new MaintainEmployeeShifts();
                maintain.Show();
            }
            else

                MessageBox.Show("No record found");


            connect.Close();

        }
    }
}
