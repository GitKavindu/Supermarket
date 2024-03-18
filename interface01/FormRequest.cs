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
    public partial class FormRequest : Form
    {
        DatabaseConnect dv;
        List<string> combo1, combo2, combo3;
        BranchManager req;
      
            public FormRequest()
        {
            InitializeComponent();
            dv = new DatabaseConnect();
            combo1 = new List<string>();
            combo2 = new List<string>();
            RefreshItems();
            RefreshStock();
            this.req = (BranchManager)Users.UserType;

        }
        
        private void Request_Click(object sender, EventArgs e)
        {
            req.CompleteRequest(int.Parse(Quantity.Text), label4.Text);
        }

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
            comboProducts.DataSource = combo1;
        }

        void ShowItemID()
        {
            label4.Text = dv.selectone("ProductId", "Product", "ProductName", comboProducts.SelectedItem.ToString());
        }

        private void ShowItemID(object sender, EventArgs e) //comboProducts
        {
            ShowItemID();
            RefreshStock();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        void RefreshStock()
        {
            string[] take;
            dv = new DatabaseConnect();
            // dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            take = dv.selectcolumn("FacilityName", "Facility", "FacilityType", "0");
            
            for (int i = 0; i < take.Length; i++)
            {
                combo2.Add(take[i]);
            }
            comboStocks.DataSource = combo2;

            showremainCount();

        }
        void showremainCount()
        {
            
            string FacilityID= dv.selectone("FacilityId", "Facility", "FacilityName", comboStocks.SelectedItem.ToString());
            
            string[] Items = dv.selectcolumn("ItemId", "RemainingItems", "FacilityId", FacilityID, "ProductId", label4.Text);
            int itemcount = Items.Length;
            label8.Text= itemcount.ToString();
        }
    }
}
