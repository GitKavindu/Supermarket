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
    public partial class Products : Form
    {
        string[] sendcol;
        string[] sendval;
        DatabaseConnect Connect;
        bool BtnFill_Click_state=false;
        public Products()
        {
            InitializeComponent();
          
            if(Users.UserType.WhoAmI() == "Stock Manager")
            {
                BranchManagerPanel.Visible = true;
            }
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
            RefreshProducts();

        }

        private void Add_Click(object sender, EventArgs e)
        {
           sendcol = new string[5];
           sendval = new string[5];
            sendcol[0] = "ProductId";       sendval[0] = textBox1.Text;
            sendcol[1] = "ProductName";     sendval[1] = textBox2.Text;
            sendcol[2] = "ProductDesc";     sendval[2] = textBox3.Text;
            sendcol[3] = "Manufacturer";    sendval[3] = textBox4.Text;
            sendcol[4] = "IsActive";        sendval[4] = "1";
            Connect.insertdata(sendcol, sendval, "Product");
            MessageBox.Show("inserted sucessfully");
            RefreshProducts();
            clear();

        }
       void RefreshProducts() 
        {
            Connect = new DatabaseConnect();
            Connect.Datagrid("Product", dataGridProducts);
        }

        private void EditProduct(object sender, EventArgs e)
        {
            string[] fields = new string[3], values=new string[3];
            fields[0] = "ProductName";     values[0] = textBox2.Text;
            fields[1] = "ProductDesc";     values[1] = textBox3.Text;
            fields[2] = "Manufacturer";    values[2] = textBox4.Text;

            Connect=new DatabaseConnect();
            string ProductName = Connect.selectone("ProductName", "Product", "ProductId", textBox1.Text);
            if(ProductName =="")
            {
                MessageBox.Show("No matching product,Please insert a one");
            }
            else
            {
                Connect.UpdateData("Product", fields, values, "ProductId", textBox1.Text); //overloaded
                clear();


            }
            
            RefreshProducts();
        }
        private void clearBoxes(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        
        private void BtnFill_Click(object sender, EventArgs e)
        {
            Item loaditems = new Item()
            { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Dashboard.db.LoadAnyForm(loaditems);
        }
    }
}
