using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface01
{
    public partial class FormRelease : Form
    {
        public FormRelease()
        {

            InitializeComponent();
            dv = new DatabaseConnect();
            combo1 = new List<string>();
            combo2 = new List<string>();
            combo3 = new List<string>();
            RefreshItems();
            RefreshBranches();
            RefreshStocks();
            this.req = (StockManager)Users.UserType;
        }

        DatabaseConnect dv;
        List<string> combo1, combo2, combo3;
        StockManager req;
       
      
       
        void RefreshItems()
        {
            string[] take;
            dv = new DatabaseConnect();
            // dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            take = dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            for (int i = 0; i < take.Length; i++)
            {
                combo1.Add(take[i]);
            }
            comboBox1.DataSource = combo1;
        }

        void ShowItemID()
        {
            label4.Text = dv.selectone("ProductId", "Product", "ProductName", comboBox1.SelectedItem.ToString());
        }

        private void ShowItemID(object sender, EventArgs e)
        {
            ShowItemID();
        }

        void RefreshBranches()
        {
            string[] take;
            dv = new DatabaseConnect();
            // dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            take = dv.selectcolumn("FacilityName", "Facility", "FacilityType", "1");

            for (int i = 0; i < take.Length; i++)
            {
                combo2.Add(take[i]);
            }
            comboBox2.DataSource = combo2;

         

        }
        void RefreshStocks()
        {
            string[] take;
            dv = new DatabaseConnect();
            // dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            take = dv.selectcolumn("FacilityName", "Facility", "FacilityType", "0");

            for (int i = 0; i < take.Length; i++)
            {
                combo3.Add(take[i]);
            }
            comboBox3.DataSource = combo3;

            showremainCount();

        }
        void showremainCount()
        {
           string FacilityID= dv.selectone("FacilityId", "Facility", "FacilityName", comboBox3.SelectedItem.ToString());
          
            string[] Items = dv.selectcolumn("ItemId", "RemainingItems", "FacilityId", FacilityID, "ProductId",comboBox1.SelectedItem.ToString());
            int itemcount = Items.Length;
            Remaining.Text = itemcount.ToString();
           // Pending.Text = Users.UserType.getAvailableItemCount(FacilityID, comboBox1.SelectedItem.ToString()).ToString();
           // Available.Text = (int.Parse(Remaining.Text) - int.Parse(Pending.Text)).ToString();
        }
        private void BtnRelease_Click(object sender, EventArgs e)
        {
            req.CompleteRelease(int.Parse(Quantity.Text),label4.Text,comboBox2.SelectedItem.ToString());
        }

        private void FormRelease_Load(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

    }
}
