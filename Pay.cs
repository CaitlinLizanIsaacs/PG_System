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
    public partial class Pay : Form
    {

        SqlCommand cmd;
        SqlConnection conn;
        SqlDataAdapter adapt;

        public Pay()
        {
            InitializeComponent();
        }

        private void btnPayFull_Click(object sender, EventArgs e)
        {
            try
            {
                BookingSummary bs = new BookingSummary();
                bs.Show();

                conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
                conn.Open();
                cmd = new SqlCommand("INSERT INTO paymentTb (paymentId, paymentDate,totalCost, orderRef) VALUES (@paymentId,@paymentDate,@totalCost, @orderRef)",
                    conn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@paymentId", txtPayment.Text + DBNull.Value);
                cmd.Parameters.Add("@orderRef",txtOrder.Text.ToString());
                cmd.Parameters.Add("@paymentDate", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                cmd.Parameters.Add("@totalCost", textBox1.Text.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();

                BookingSummary bookingReceipt = new BookingSummary();
                bookingReceipt.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            
        }
    }
    }

