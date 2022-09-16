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
            cmd = new SqlCommand("INSERT INTO ClientCredidentialsTb (title,surname,email) VALUES (@title,@surname,@email)",
                conn);
            cmd.Parameters.AddWithValue("@check-InDate", monthCalendarCheckIn.SelectionRange.ToString());
            cmd.Parameters.AddWithValue("@check-outDate", monthCalendarCheckOut.SelectionRange.ToString());
            cmd.Parameters.AddWithValue("@TotalCost", lblTotal.Text);
            cmd.Parameters.AddWithValue("@numberOfRooms", txtRooms.Text);
            cmd.Parameters.AddWithValue("@numberOfAdults", txtAdults.Text);
            cmd.Parameters.AddWithValue("@numberOfChildren", txtKids.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        private void MaintainClient_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
            
            string sql;
            SqlDataAdapter adapter = new SqlDataAdapter();

            sql = @"Select * FROM TableInformation";
            cmd = new SqlCommand(sql, conn);

            DataSet ds = new DataSet();

            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "Info"); 
 
            dataGridView1.DataSource = ds; // Set the datasource to the dataset
            dataGridView1.DataMember = "Info";//Point to the table in the dataset to
            
            conn.Close();




        }
    }
}
