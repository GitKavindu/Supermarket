using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace interface01
{
    public partial class Dashboard : Form
    {
        Users user;
        internal static Dashboard db;
        DatabaseConnect Connect = new DatabaseConnect();
        
        public Dashboard()
        {
            InitializeComponent();
            db = this;
            label4.Text = Connect.selectone("UserType", "Users", "UserId", Users.UserType.getUserID());
            Account.Text=Users.UserType.gettUsername();
           
        }
        internal Dashboard(Users user) 
        {
            this.user=user;
        }


        private void iconButton3_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Products frm3 = new Products() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            LoadAnyForm(frm3);
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            
                Pending pending = new Pending()
                { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                LoadAnyForm(pending);
            

        }


        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();//ffwefwewfwe
        }

        private void Request(object sender, EventArgs e)
        {
            
            if (Users.UserType.WhoAmI() == "Stock Manager")
            {
                FormRelease frm2 = new FormRelease() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                LoadAnyForm(frm2);
            }
            else if(Users.UserType.WhoAmI() == "Branch Manager")
            {
                Form frm1=new FormRequest() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                LoadAnyForm(frm1);
            }
            else
            {
                Form frm1 = new StaffRelease() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                LoadAnyForm(frm1);
            }
        }
        internal void LoadAnyForm(Form loadMe)
        {
            
           
            this.pnlFormLoader.Controls.Clear();

            Form form = loadMe;
            form.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(form);
            form.Show();
        }
        private void ViewUsers_click(object sender, EventArgs e)
        {
            ManageUsers m1=new ManageUsers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true }; ;
            LoadAnyForm(m1);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if(Users.UserType.WhoAmI()== "Stock Manager")
            {
                StockManagerPreferences();
            }
            else if(Users.UserType.WhoAmI() == "Branch Manager")
            {
                BranchManagerPreferences();
            }
            else
            {
                StaffPreferences();
            }
        }

        private void StaffPreferences()
        {
            iconButton6.Text = "Complete Releases";

        }

        private void BranchManagerPreferences()
        {
            iconButton6.Text = "Request";
        }

        private void StockManagerPreferences()
        {
            iconButton6.Text = "Release";
            ViewUsers.Visible = true;
        }
    }
}
