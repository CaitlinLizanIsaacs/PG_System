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
            try
            {
               
                conn = new SqlConnection("Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");

                conn.Open();
                //cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                cmd = new SqlCommand("INSERT INTO OrderTb VALUES('"+txtOrderRef.Text+"','"+ this.dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss") +"','"+ this.dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss") +"', '"+txtAdults.Text+"', '"+txtKids+"', '"+txtRooms.Text+"')",
                    conn);



                /*cmd.Parameters.AddWithValue("@check-InDate", this.dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                cmd.Parameters.AddWithValue("@check-outDate", this.dateTimePicker2.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                cmd.Parameters.AddWithValue("@TotalCost", lblTotal.Text);
                cmd.Parameters.AddWithValue("@numberOfRooms", txtRooms.Text);
                cmd.Parameters.AddWithValue("@numberOfAdults", txtAdults.Text);
                cmd.Parameters.AddWithValue("@numberOfChildren", txtKids.Text);*/
                cmd.ExecuteNonQuery();

                conn.Close();
                Pay payment = new Pay();
                payment.Show();
                //check - InDate,check - outDate,TotalCost,numberOfRooms,numberOfAdults,numberOfChildren) VALUES(@check - InDate, @check - outDate, @TotalCost, @numberOfRooms, @numberOfAdults, @numberOfChildren)",
                    //conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
