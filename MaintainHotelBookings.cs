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
    public partial class MaintainHotelBookings : Form
    {
        public MaintainHotelBookings()
        {
            InitializeComponent();
        }

        private void MaintainHotelBookings_Load(object sender, EventArgs e)
        {
            loadAll();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection conn;

            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO OrderTb (orderRef,surname,checkIn,checkOut,totalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES (@orderRef,@surname,@checkIn,@checkOut,@totalCost,@numberOfRooms,@numberOfAdults,@numberOfChildren)",
                conn);
            cmd.Parameters.AddWithValue("@orderRef", txtOrderReference.Text + DBNull.Value);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@checkIn", SqlDbType.DateTime).Value = dateTimePickerIn.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            cmd.Parameters.AddWithValue("@checkOut", SqlDbType.DateTime).Value = dateTimePickerOut.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            cmd.Parameters.AddWithValue("@totalCost", txtTotalCost.Text);
            cmd.Parameters.AddWithValue("@numberOfAdults", txtNumberOfAdults.Text);
            cmd.Parameters.AddWithValue("@numberOfChildren", txtNumberOfKids.Text);
            cmd.Parameters.AddWithValue("@numberOfRooms", txtNumberOfRooms.Text);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Order record inserted");

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

            string sql = "SELECT * FROM OrderTb";

            cmd = new SqlCommand(sql, con);
            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "OrderTb");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "OrderTb";

            con.Close();
        }

        private void Clear()
        {
            txtOrderReference.Clear();
            txtNumberOfAdults.Clear();
            txtNumberOfRooms.Clear();
            txtNumberOfKids.Clear();
            txtSurname.Clear();
            txtTotalCost.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();

            string Query = "UPDATE OrderTb SET numberOfRooms = @numberOfRooms WHERE orderRef = @orderRef";

            SqlCommand com = new SqlCommand(Query, connect);
            com.Parameters.AddWithValue("@numberOfRooms", txtNumberOfRooms.Text);
            com.Parameters.AddWithValue("@orderRef", txtOrderReference.Text);


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

            string sql = "DELETE OrderTb WHERE orderRef=@orderRef";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("orderRef", txtOrderReference.Text);

            com.ExecuteNonQuery();


            con.Close();

            MessageBox.Show("Hotel Booking has been deleted");

            loadAll();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            SqlConnection connect = new SqlConnection(ConnectionString);

            connect.Open();

            string Name = txtOrderReference.Text;

            string Query = "SELECT * FROM OrderTb WHERE orderRef = " + txtOrderReference.Text;

            SqlCommand com = new SqlCommand(Query, connect);
            var reader = com.ExecuteReader();

            if (reader.Read())
            {
                txtOrderReference.Text = reader["orderRef"].ToString();
                txtSurname.Text = reader["surname"].ToString();
                txtTotalCost.Text = reader["totalCost"].ToString();
                txtNumberOfKids.Text = reader["numberOfCHildren"].ToString();
                txtNumberOfAdults.Text = reader["numberOfAdults"].ToString();
                txtNumberOfRooms.Text = reader["numberOfRooms"].ToString();
            }
            else
                MessageBox.Show("No record found");

            connect.Close();
        }
    }
}
