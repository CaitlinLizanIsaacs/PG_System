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
        public BookingSummary(string paymentdate, string bookingref, string totalCost)
        {
            InitializeComponent();
            label5.Text = paymentdate;
            lblBR.Text = bookingref;
            lblTotalCost.Text = totalCost;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           Login logout = new Login();
            logout.Show();
            this.Hide();
        }

       

       
        private void BookingSummary_Load(object sender, EventArgs e)
        {
            


        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        
    }
}
