using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Documents;
using System.Windows.Forms;

namespace interface01
{
    public partial class register : Form
    {
        List<string> combo1, combo2, combo3;
        DatabaseConnect dv = new DatabaseConnect();
        string Usercategory;  // type of user
        NewUser user;
        private bool BranchType=false; // means it is a Sales Branch
        public register()
        {
            InitializeComponent();
            combo1 = new List<string>();
        }
        
        private void register_Load(object sender, EventArgs e)
        {
           // panel5.BackColor = Color.FromArgb(100, 0, 0);
            this.user = new NewUser();
            
            RefreshFacilities();
            

        }
        void RefreshFacilities()
        {
          
            string[] take;
            dv = new DatabaseConnect();
            combo1 = new List<string>();
            take = dv.selectcolumn("FacilityName", "Facility", "FacilityType", BranchType.ToString());
            for (int i = 0; i < take.Length; i++)
            {
                
                combo1.Add(take[i]);
               
            }
            
            comboBox2.DataSource = combo1;
        }

        private void setBranch(object sender, EventArgs e)
        {
            setBranch();
            RefreshFacilities();
        }

        void setBranch()
        {
            if(comboBox1.SelectedItem.ToString()== "Branch Manager")
            {
                BranchType =true;
            }
            else 
            {
                BranchType = false;
            }
            
        }

        private void SIgnUP_Click(object sender, EventArgs e)
        {
            user.Register(textBox1.Text,textBox4.Text,textBox2.Text,comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString());
        }
    }
}
