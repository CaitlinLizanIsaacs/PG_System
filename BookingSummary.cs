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
           Login logout = new Login();
            logout.Show();
        }

        private void BookingReference()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            string query = "SELECT * FROM OrderTb ";
            SqlCommand comm;
            comm = new SqlCommand(query, conn);
            SqlDataReader read = comm.ExecuteReader();

            read.Read();
            lblBR.Text = read["orderRef"].ToString();



        }

        private void PaymentRef()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            string query = "SELECT * FROM paymentTb ";
            SqlCommand comm;
            comm = new SqlCommand(query, conn);
            SqlDataReader read = comm.ExecuteReader();

            read.Read();
            lblPR.Text = read["paymentId"].ToString();

        }

        private void EmailRetrieve()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            string query = "SELECT * FROM ClientCredTb ";
            SqlCommand comm;
            comm = new SqlCommand(query, conn);
            SqlDataReader read = comm.ExecuteReader();

            read.Read();
            lblEmail.Text = read["email"].ToString();

        }

        private void NumberOfRoomsBooked()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            string query = "SELECT * FROM OrderTb ";
            SqlCommand comm;
            comm = new SqlCommand(query, conn);
            SqlDataReader read = comm.ExecuteReader();

            read.Read();
            lblRoomsBooked.Text = read["numberOfRooms"].ToString();

        }

        private void TotalCost()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");
            conn.Open();

            string query = "SELECT * FROM paymentTb ";
            SqlCommand comm;
            comm = new SqlCommand(query, conn);
            SqlDataReader read = comm.ExecuteReader();

            read.Read();
            lblBalance.Text = read["totalCost"].ToString();

        }


        private void BookingSummary_Load(object sender, EventArgs e)
        {
            BookingReference();
            PaymentRef();
            EmailRetrieve();
            NumberOfRoomsBooked();
            TotalCost();




        }
    }
}
