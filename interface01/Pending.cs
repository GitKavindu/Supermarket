using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface01
{
    public partial class Pending : Form
    {
        DatabaseConnect Connect=new DatabaseConnect();
        public Pending()
        {
            InitializeComponent();
            
            dataGridReleases.Visible = false;
            dataGridRequests.Visible = false;
            RefreshProducts();
            /* if (Users.UserType.WhoAmI() == "Stock Manager")
             {
                 Connect.storeProc("Requests", textBox1.Text, Users.UserType.getUserID());

             }
             else if (Users.UserType.WhoAmI() == "Branch Manager")
             {
                 Connect.storeProc("PendingReleases", textBox1.Text, Users.UserType.getUserID());
             }
             else
             {
                 Connect.storeProc("PendingReleases", textBox1.Text, Users.UserType.getUserID());
             }*/

        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
        
        void RefreshProducts()
        {
            Connect = new DatabaseConnect();
            if (Users.UserType.WhoAmI() == "Stock Manager")
            {
                dataGridReleases.Visible = true;
                dataGridRequests.Visible = true;
                Connect.Datagrid("PendingReleases", dataGridReleases, Users.UserType.getUserID());
                Connect.Datagrid("Request", dataGridRequests);
            }
            else if( Users.UserType.WhoAmI() == "Branch Manager")
            {
                dataGridRequests.Visible = true;
                Connect.Datagrid("Request", dataGridRequests);
            }
            else
            {
                dataGridReleases.Visible = true;
                Connect.Datagrid("Release", dataGridReleases);
            }
        }

        private void Pending_Load(object sender, EventArgs e)
        {

        }
    }
}
