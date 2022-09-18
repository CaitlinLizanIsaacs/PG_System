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
            
           
               
                conn = new SqlConnection("Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");


                cmd = new SqlCommand("INSERT INTO OrderTb (orderRef, checkIn,checkOut,numberOfAdults,numberOfChildren,numberOfRooms)VALUES('"+txtOrderRef.Text+"','"+ this.dateTimePicker1.Value.Date +"','"+ this.dateTimePicker1.Value.Date +"', '"+txtAdults.Text+"', '"+txtKids+"', '"+txtRooms.Text+"')",
                    conn);

                SqlDataReader myReader;


            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Please move to pay");
                while (myReader.Read())
                {

                }

                cmd.ExecuteNonQuery();

                conn.Close();
                Pay payment = new Pay();
                payment.Show();

            }
                /*cmd.ExecuteNonQuery();

                conn.Close();
                Pay payment = new Pay();
                payment.Show();*/
                
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
