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
    public partial class BookingSummary : Form
    {
        public BookingSummary()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void Balance()
        {
            SqlCommand cmd;

            SqlDataAdapter adapt;

            SqlConnection con;
            string connectionString = @"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True";

            con = new SqlConnection(connectionString);

            con.Open();

            adapt = new SqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = "SELECT totalCost FROM paymentTb";

            cmd = new SqlCommand(sql, con);
            adapt.SelectCommand = cmd;
            adapt.Fill(ds, "Order");

           



            con.Close();
        }
    }
}
