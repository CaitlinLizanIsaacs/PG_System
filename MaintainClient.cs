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
    public partial class MaintainClient : Form
    { 

        public MaintainClient()
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
            cmd = new SqlCommand("INSERT INTO ClientCredTb (Id,surname,name,title,email) VALUES (@Id,@surname,@name,@title,@email)",
                conn);
            cmd.Parameters.AddWithValue("@Id",txtId.Text);
            cmd.Parameters.AddWithValue("@name",txtName.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text );
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Client record inserted");

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

            string sql = "SELECT * FROM ClientCredTb";

            cmd = new SqlCommand(sql, con);
            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "ClientCredTb");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ClientCredTb";

            con.Close();
        }

        private void Clear()
        {
            txtEmail.Clear();
            txtId.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtTitle.Clear();
        }

        private void MaintainClient_Load(object sender, EventArgs e)
        {
            loadAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();

            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Title = txtTitle.Text;
            string email = txtEmail.Text;

            string Query = "UPDATE ClientCredTb SET email = @email WHERE Id = @Id";

            SqlCommand com = new SqlCommand(Query, connect);
            com.Parameters.AddWithValue("@email",email);
            com.Parameters.AddWithValue("@Id",txtId.Text);
          
            com.ExecuteNonQuery();

            connect.Close();

            MessageBox.Show("Record has been updated");
            loadAll();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            SqlConnection con;
            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            string sql = "DELETE ClientCredTb WHERE Id=@Id";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("Id", txtId.Text);
            /*cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);*/
            //con.Open();
            com.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("Client record has been deleted");

            loadAll();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            /*conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ClientCredTb SET Id=@Id,surname=@surname,name=@name,title=@title,email=@email",
                conn);
            cmd.Parameters.AddWithValue("Id", txtId.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            name = '"+Name+"', surname = '"+Surname+"', title = '"+Title+"', email = '"+email+ "'WHERE Id = '"+txtId.Text;

            MessageBox.Show("Client record updated");

            loadAll();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();

            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Title = txtTitle.Text;
            string email = txtEmail.Text;

            string Query = "SELECT * FROM ClientCredTb WHERE Id = "+txtId.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["name"].ToString();
                txtSurname.Text = reader["surname"].ToString();
                txtTitle.Text = reader["title"].ToString();
                txtEmail.Text = reader["email"].ToString();
            }
            else
                MessageBox.Show("No record found");

            connect.Close();

        }
    }
}
