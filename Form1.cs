using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PG_System
{
    public partial class Login : Form
    {
   

        
        public Login()
        {
            InitializeComponent();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlDataAdapter adapt;
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-EM51E9U;Initial Catalog=PacificGuesthouseDb;Integrated Security=True");

                String username, password;

                username = txtLogin.Text;
                password = txtPassword.Text;

                String query = "SELECT * FROM ClientCreditialsTable WHERE clientReference = '" + txtLogin.Text + "' AND surname = '" + txtPassword.Text + "'";
                adapt = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                adapt.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtLogin.Text;
                    password = txtPassword.Text;

                    Order order = new Order();
                    order.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
