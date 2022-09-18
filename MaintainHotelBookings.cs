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

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlConnection conn;

            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO OrderTb (orderRed,surname,check-InDate,check-OutDate,totalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES (@orderRed,@surname,@check-InDate,@check-OutDate,@totalCost,@numberOfRooms,@numberOfAdults,@numberOfChildren)",
                conn);
            cmd.Parameters.AddWithValue("@orderRef", txtOrderReference.Text);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@check-InDate", dateTimePickerIn.Value.ToString());
            cmd.Parameters.AddWithValue("@check-OutDate", dateTimePickerOut.Value.ToString());
            cmd.Parameters.AddWithValue("@totalCost", txtTotalCost.Text);
            cmd.Parameters.AddWithValue("@numberOfAdults", txtNumberOfAdults.Text);
            cmd.Parameters.AddWithValue("@numberOfChildren", txtNumberOfKids.Text);
            cmd.Parameters.AddWithValue("@numberOfRooms", txtNumberOfRooms.Text);
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
    }
}
