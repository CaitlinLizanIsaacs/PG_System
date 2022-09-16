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
                cmd = new SqlCommand("INSERT INTO PayTb (PaymentDate,FullAmount) VALUES (@PaymentDate,@FullAmount)",
                    conn);
                cmd.Parameters.AddWithValue("@check-InDate", monthCalendar1.SelectionStart.ToString());
                cmd.Parameters.AddWithValue("@numberOfChildren", textBox1.Text);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
