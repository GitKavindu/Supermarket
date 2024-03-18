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
    public partial class StaffRelease : Form
    {


        DatabaseConnect Connect;
        List<string> combo1, combo2, combo3;
        Staff req;
        int Addeditems=0;
        string[] items;
        public StaffRelease()
        {
            InitializeComponent();
            
            combo1 = new List<string>();
            RefreshItems();
            loaddataGrid();
            label10.Text = "";
        }

        void RefreshItems()
        {
            string[] take;
            Connect = new DatabaseConnect();
            
            string StockManagerID = Connect.selectone("UserId", "Users", "FacilityId", Users.UserType.getFacilityID(), "UserType", "Stock Manager");

            take = Connect.selectcolumn("ReleaseId", "Release", "Iscompleted", "0", "UserId", StockManagerID);
            for (int i = 0; i < take.Length; i++)
            {
                combo1.Add(take[i]);
            }
            ReleaseIDs.DataSource = combo1;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


      
        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void ReleaseIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Addeditems = 0;
            label10.Text = "";

            string ProductID = Connect.selectone("ProductId", "Release", "ReleaseId", ReleaseIDs.SelectedItem.ToString());
            product.Text = Connect.selectone("ProductName", "Product", "ProductId", ProductID);

            itemcount.Text = Connect.selectone("Quantity", "Release", "ReleaseId", ReleaseIDs.SelectedItem.ToString());
        }  

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Add_Click(object sender, EventArgs e)
        {
            if (Addeditems == 0) 
            items = new string[int.Parse(itemcount.Text)];

            if (Addeditems <int.Parse(itemcount.Text))
            {
                string productID1 = Connect.selectone("ProductId"," RemainingItems", "FacilityId",Users.UserType.getFacilityID(), "ItemId", textBox1.Text);
                //productID,ReleaseID
                string productID2 = Connect.selectone("ProductId", "Release", "ReleaseId",ReleaseIDs.SelectedItem.ToString());
                if (productID1 == productID2)
                {
                    items[Addeditems] = textBox1.Text;
                    label10.Text = label10.Text + items[Addeditems] + "\n";
                    Addeditems++;
                }
                else
                {
                    MessageBox.Show("Item is not allowed in this release");
                }
            
            }
            else
            {
                MessageBox.Show("cant add any more items");
            }

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string[] sendval=new string[1];string []sendfield =new string[1];
            if (checkDuplicate() == false)
            {
                //add to database
                for (int i = 0; i < Addeditems; i++)
                {
                    sendfield[0] = "ReleaseId"; sendval[0] =ReleaseIDs.SelectedItem.ToString();
                    //sendfield[0] = "UserId";    sendval[1] =Users.UserType.getUserID();
                    Connect.UpdateData("Item", sendfield, sendval, "ItemId", items[i]);
                    Connect.UpdateData("Release", "Iscompleted","1", "ReleaseId", ReleaseIDs.SelectedItem.ToString());
                    loaddataGrid();
                    RefreshItems();
                }
            }
            else
            {
                MessageBox.Show("You have entered a single item twice");
            }
        }

        bool checkDuplicate()
        {
            bool returnval = false;
            for(int i = 0; i < Addeditems; i++)
            {
                for (int j = i+1; j < Addeditems; j++)
                {
                    if (items[i] == items[j])
                    {
                        returnval = true;
                    }
                }
            }
            return returnval;
        }
        void loaddataGrid()
        {
            Connect = new DatabaseConnect();
            Connect.Datagrid("item", dataGridItems);
        }
    }
}
