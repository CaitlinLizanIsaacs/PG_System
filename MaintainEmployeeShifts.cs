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
    public partial class MaintainEmployeeShifts : Form
    {
      

        public MaintainEmployeeShifts()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection conn;

            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO EmployeeTb (employeeId,orderReference,name,surname,shifts) VALUES (@employeeId,@orderReference,@name,@surname,@shifts)",
                conn);
            cmd.Parameters.AddWithValue("@employeeId", txtId.Text);
            cmd.Parameters.AddWithValue("@orderReference", txtOrderReference.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@shifts", txtShift.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Employee record inserted");

            loadAll();

            Clear();


        }

        private void loadAll()
        {
            SqlCommand cmd;

            SqlDataAdapter adapt;

            SqlConnection con;
            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            con = new SqlConnection(connectionString);

            con.Open();

            adapt = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT * FROM EmployeeTb";

            cmd = new SqlCommand(sql, con);
            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "EmployeeTb");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "EmployeeTb";

            con.Close();
        }

        private void Clear()
        {
            txtShift.Clear();
            txtId.Clear();
            txtOrderReference.Clear();
            txtSurname.Clear();
            txtName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();


            string Query = "UPDATE EmployeeTb SET shift = @shift WHERE employeeId = @employeeId";

            SqlCommand com = new SqlCommand(Query, connect);
            com.Parameters.AddWithValue("@shift", txtShift.Text);
            com.Parameters.AddWithValue("@employeeId", txtId.Text);


            com.ExecuteNonQuery();

            connect.Close();

            MessageBox.Show("Employee Record has been updated");
            loadAll();

            txtShift.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            string sql = "DELETE employeeId WHERE employeeId=@employeeId";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("employeeId", txtId.Text);

            com.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("Employee record has been deleted");

            loadAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();

            string id = txtId.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string orderRef = txtOrderReference.Text;
            string shifts = txtShift.Text;

            string Query = "SELECT * FROM EmployeeTb WHERE employeeId = " + txtId.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtId.Text = reader["employeeId"].ToString();
                txtName.Text = reader["name"].ToString();
                txtSurname.Text = reader["surname"].ToString();
                txtOrderReference.Text = reader["orderReference"].ToString();
                txtShift.Text = reader["shift"].ToString();
            }
            else
                MessageBox.Show("No record found");

            connect.Close();
        }
    }
}
