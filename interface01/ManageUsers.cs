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
    public partial class ManageUsers : Form
    {
        DatabaseConnect Connect = new DatabaseConnect();
        public ManageUsers()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            Connect.UpdateData("Users", "Userstat", "0", "UserId", textBox1.Text);
            LoadUsers();
        }
        private void BtnEnableClick(object sender, EventArgs e)
        {
            Connect.UpdateData("Users", "Userstat", "1", "UserId", textBox1.Text);
            LoadUsers();
        }
        void LoadUsers()
        {
            Connect.Datagrid("User_detais", dataGridUsers);
        }
    }
}
