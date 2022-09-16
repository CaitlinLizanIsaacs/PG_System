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
            cmd = new SqlCommand("INSERT INTO ClientCredidentialsTable (clientReference,title,surname,email) VALUES (@clientReference,@title,@surname,@email)",
                conn);
            cmd.Parameters.AddWithValue("@clientReference",lblRef.Text);
            cmd.Parameters.AddWithValue("@title", txtTitle.Text );
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void MaintainClient_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
            
            string sql;
            SqlDataAdapter adapter = new SqlDataAdapter();

            sql = @"Select * FROM ClientCredentialsTable";
            cmd = new SqlCommand(sql, conn);

            DataSet ds = new DataSet();

            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "Info"); 
 
            dataGridView1.DataSource = ds; 
            dataGridView1.DataMember = "Info";
            
            conn.Close();

            Random rand = new Random();
            rand.Next(1,100);


            string word = "CLIREF";

            string clientRef = word + rand;

            clientRef = lblRef.Text;
            




        }
    }
}
