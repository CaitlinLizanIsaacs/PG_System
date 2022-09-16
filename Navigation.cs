using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PG_System
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void clientsRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintainClient client = new MaintainClient();
            client.MdiParent = this;
            client.Show();

        }

        private void hotelBookingRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintainHotelBookings hotel = new MaintainHotelBookings();
            hotel.MdiParent = this;
            hotel.Show();
        }

        private void employeeShiftsRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaintainEmployeeShifts shifts = new MaintainEmployeeShifts();
            shifts.MdiParent = this;
            shifts.Show();
        }
    }
}
