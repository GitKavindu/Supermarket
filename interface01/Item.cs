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
    public partial class Item : Form
    {
        string[] sendcol;
        string[] sendval;
        DatabaseConnect dv;
        List<string> combo1, combo2, combo3;
        public Item()
        {
            InitializeComponent();
            combo1 = new List<string>();
            RefreshItems();
        }

        void RefreshProducts()
        {
            dv = new DatabaseConnect();
            dv.Datagrid("Product", dataGridItems);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void users_Load(object sender, EventArgs e)
        {
            RefreshItems();

        }

        private void Add_Click(object sender, EventArgs e)
        {
           sendcol = new string[5];
           sendval = new string[5];

            dv = new DatabaseConnect();
           string productId= dv.selectone("ProductId", "Product", "ProductName",comboBox1.SelectedItem.ToString());

            sendcol[0] = "ItemId";            sendval[0] = textBox1.Text;
            sendcol[1] = "ProductId";         sendval[1] = productId;
            sendcol[2] = "Price";             sendval[2] = textBox3.Text;
            sendcol[3] = "ItemExpireDate";    sendval[3] = ExpireDate.Value.ToString("yyyy-MM-dd");
            sendcol[4] = "FacilityId";        sendval[4] = Users.UserType.getFacilityID();

            dv = new DatabaseConnect();
            dv.insertdata(sendcol, sendval, "Item");
            MessageBox.Show("inserted sucessfully");
            RefreshItems();

        }
       void RefreshItems() 
        {
            string[] take;
            dv = new DatabaseConnect();
            dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            take = dv.selectcolumn("ProductName", "Product", "IsActive", "1");
            for (int i = 0; i < take.Length; i++)
            {
                combo1.Add(take[i]);

            }
            comboBox1.DataSource = combo1;

            dv = new DatabaseConnect();
            dv.Datagrid("Item", dataGridItems);
        }
        private void EditItems(object sender, EventArgs e)
        {
            string productId = dv.selectone("ProductId", "Product", "ProductName", comboBox1.SelectedItem.ToString());
           
            string[] fields = new string[3], values = new string[3];
            fields[0] = "ProductId";         values[0] = productId;
            fields[1] = "Price";             values[1] = textBox3.Text;
            fields[2] = "ItemExpireDate";    values[2] = ExpireDate.Value.ToString("yyyy-MM-dd");

            dv = new DatabaseConnect();
            string ProductId = dv.selectone("ProductId", "Item", "ItemId", textBox1.Text);
            if (ProductId == "")
            {
                MessageBox.Show("No matching item,Please insert a one");
            }
            else
            {
                dv.UpdateData("Item", fields, values, "ItemId", textBox1.Text); //overloaded
                clear();

            }

            RefreshItems();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Products loadProducts = new Products()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Dashboard.db.LoadAnyForm(loadProducts);
        }

        private void ExpireDate_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(ExpireDate.Value.ToString("yyyy-MM-dd"));//dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void clearBoxes(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            
        }
    }
}
