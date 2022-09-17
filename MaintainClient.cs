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
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter adapt;
        string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

        public MaintainClient()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

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

        
        }

        private void loadAll()
        {
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

        private void MaintainClient_Load(object sender, EventArgs e)
        {
            loadAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
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

            MessageBox.Show("Client record updated");

            loadAll();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection con;
            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            con = new SqlConnection(connectionString);
            con.Open();

            string sql = "DELETE ClientCredTb WHERE Id=@Id,surname=@surname,name=@name,title=@title,email=@email";
            SqlCommand com = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("Id", txtId.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("Client recorded has been deleted");

            loadAll();
            
        }
    }
}
