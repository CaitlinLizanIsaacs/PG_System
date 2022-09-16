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
            try
            {
                Pay payment = new Pay();
                payment.Show();

                conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
                conn.Open();
                cmd = new SqlCommand("INSERT INTO OrderTb (check-InDate,check-outDate,TotalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES (@check-InDate,@check-outDate,@TotalCost,@numberOfRooms,@numberOfAdults,@numberOfChildren)",
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }
    }
}
