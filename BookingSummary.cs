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
using PG_System;

namespace PG_System
{
    public partial class BookingSummary : Form
    {
        public BookingSummary(string paymentRef, string bookingref, string totalCost)
        {
            InitializeComponent();
            lblSurname.Text = paymentRef;
            lblBR.Text = bookingref;
            lblTotalCost.Text = totalCost;
            


            
           
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

            read.Close();
            conn.Close();



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
            lblSurname.Text = read["paymentId"].ToString();

            read.Close();
            conn.Close();

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
            lblTotalCost.Text = read["email"].ToString();

            read.Close();
            conn.Close();

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
            //lblRoomsBooked.Text = read["numberOfRooms"].ToString();

            read.Close();
            conn.Close();

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
            lblTotalCost.Text = read["totalCost"].ToString();

            read.Close();
            conn.Close();

        }


        private void BookingSummary_Load(object sender, EventArgs e)
        {
            /*BookingReference();
            PaymentRef();
            EmailRetrieve();
            NumberOfRoomsBooked();
            TotalCost();*/




        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        
    }
}
