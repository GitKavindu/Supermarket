using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface01
{
    internal class BranchManager:Users
    {  
        Random random=new Random();
        DatabaseConnect Connect=new DatabaseConnect();
       // private string UserID;
        internal BranchManager() { }
        internal BranchManager(string userID) : base(userID)
        {
             
        }
       
        internal override void Gointo()
        {
             Dashboard dashboard = new Dashboard();
             dashboard.Show();
            /*MessageBox.Show(UserType.ToString());
            FormRequest form = new FormRequest();
           
            form.ShowDialog();*/
        }

        // for request
        internal void CompleteRequest(int Quantity, string Product)
        {
            // DateTime dt = new DateTime();

            string requestID = random.Next(0, 10000).ToString();
            string requestDate = DateTime.Now.ToString("M/d/yyyy");
            string requestTime = DateTime.Now.ToString("h:mm:ss tt");

            //add details to database
            addToDatabase(requestID, requestTime, requestDate, Quantity,UserType.getUserID(), Product);
            //show a description
        }

        internal void addToDatabase(string requestID, string requestTime, string requestDate, int quantity, string UserID, string Product)
        {
            string[] fieldNames = new string[6];
            string[] Values = new string[6];

            fieldNames[0] = "RequestId"; Values[0] = requestID;
            fieldNames[1] = "ReleaseDate"; Values[1] = requestDate;
            fieldNames[2] = "ReleaseTime"; Values[2] = requestTime;
            fieldNames[3] = "Quantity"; Values[3] = quantity.ToString();
            fieldNames[4] = "UserId"; Values[4] = UserID;
            fieldNames[5] = "ProductId"; Values[5] = Product;

            Connect.insertdata(fieldNames, Values, "Request");
            MessageBox.Show("Request sent sucessfully");
        }

        internal override string WhoAmI()
        {
            return "Branch Manager";
        }

        internal override void PressRequest()
        {
            Form frm1 = new FormRequest() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Dashboard.db.LoadAnyForm(frm1);
        }

        internal override void PressRemove()
        {
            throw new NotImplementedException();
        }
        // end of request 


    }
}
