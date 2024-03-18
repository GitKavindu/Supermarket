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
    public partial class NewLogin : Form
    {

        Users users;
        public NewLogin()
        {
            InitializeComponent();
            

        }

     

        private void button1_Click(object sender, EventArgs e) //login 
        {
            users.Login(textBox3.Text, textBox4.Text,this, users);
        }
        private void login2_Load(object sender, EventArgs e)
        {
            users = new NewUser();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //reg
        {
            register r1 = new register();
            this.Hide();
            r1.Show();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
            textBox4.PasswordChar = '*';
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
        }
    }

}
