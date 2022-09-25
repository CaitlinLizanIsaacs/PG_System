using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace PG_System
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter adapt;

       

        private void btnPay_Click(object sender, EventArgs e)
        {


            SqlCommand cmd;
            SqlConnection conn;

            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            conn = new SqlConnection(connectionString);
            conn.Open();
            cmd = new SqlCommand("INSERT INTO OrderTb (orderRef,surname,checkIn,checkOut,totalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES (@orderRef,@surname,@checkIn,@checkOut,@totalCost,@numberOfRooms,@numberOfAdults,@numberOfChildren)",
                conn);
            cmd.Parameters.AddWithValue("@orderRef", txtOrderRef.Text + DBNull.Value);
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@checkIn", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            cmd.Parameters.AddWithValue("@checkOut", SqlDbType.DateTime).Value = dateTimePicker2.Value.ToString("yyyy-MM-ddTHH:mm:ss");
            cmd.Parameters.AddWithValue("@totalCost", txtTotalCost.Text);
            cmd.Parameters.AddWithValue("@numberOfAdults", txtAdults.Text);
            cmd.Parameters.AddWithValue("@numberOfChildren", txtKids.Text);
            cmd.Parameters.AddWithValue("@numberOfRooms", txtRooms.Text); 
            cmd.ExecuteNonQuery();

            conn.Close();

            Pay pay = new Pay();
            pay.Show();

            

            
        }
    }
}
