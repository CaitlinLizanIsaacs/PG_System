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
            Pay payment = new Pay();
            payment.Show();

            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO ClientCredTb WHERE (clientReference,title,surname,email) VALUES (@clientReference,@title,@surname,@email)",
                conn);
            cmd.Parameters.AddWithValue("@clientReference",lblRef.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text );
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Client record inserted");
        }

        private void loadAll()
        {
            conn.Open();
            adapt = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT * FROM ClientCredTb";

            cmd = new SqlCommand(sql, conn);
            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "ClientCredTb");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ClientCredTb";

            conn.Close();
        }

        private void MaintainClient_Load(object sender, EventArgs e)
        {

            Random rand = new Random();
            rand.Next(1,100);


            string word = "CLIREF";

            string clientRef = word + rand;

            clientRef = lblRef.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE FROM ClientCredentialsTable WHERE (clientReference,title,surname,email) VALUES (@clientReference,@title,@surname,@email)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@clientReference", lblRef.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Client record has been update");

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();

            string sql = "DELETE FROM ClientCredentialsTable WHERE (clientReference,title,surname,email) VALUES (@clientReference,@title,@surname,@email)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@clientReference", lblRef.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Client recorded has been deleted");
        }
    }
}
