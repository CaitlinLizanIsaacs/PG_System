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
            //lblShow.Text = email;
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
            cmd = new SqlCommand("INSERT INTO OrderTb (surname,checkIn,checkOut,totalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES (@surname,@checkIn,@checkOut,@totalCost,@numberOfRooms,@numberOfAdults,@numberOfChildren)",
                conn);
            
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

            this.Hide();

            

            
        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("If you experience any problems with bookings please contact our office hotline on 011-249-5589, our customer care line on 0623569987 or email us on pgguesthouse@guesyhouse.co.za, we respond within the hour");
        }
    }
}
