using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace interface01
{
    internal class StockManager : Users
    {
        static Users user;
        Random random = new Random();
        DatabaseConnect Connect=new DatabaseConnect();
        internal StockManager(string userID):base(userID)
        {
            
        }

      

        internal override void Gointo()
        {
            Dashboard dashboard = new Dashboard();  
            dashboard.ShowDialog();
            /*FormRelease formRelease = new FormRelease();

            MessageBox.Show("StockManager");
            formRelease.ShowDialog();
            */
        }

        internal void CompleteRelease(int Quantity, string Product, string ReleaseFacilityName)
        {
            // set values 
            string releaseID = random.Next(0, 10000).ToString();
            string releaseDate = DateTime.Now.ToString("M/d/yyyy");
            string releaseTime = DateTime.Now.ToString("h:mm:ss tt");
            string Release_FacID = Connect.selectone("FacilityId", "Facility", "FacilityName", ReleaseFacilityName);
            // check availability
            if ( check_avalilabity( Quantity,UserType.getFacilityID(), Product) == true)
            {
               addToDatabase(releaseID, releaseTime, releaseDate, Quantity, UserType.getUserID(), Product, Release_FacID);
            }
            else
            {
                // show error
                System.Windows.Forms.MessageBox.Show("Not enough items");
            }
            

        }


        internal bool check_avalilabity(int quantity, string FacilityID, string Product)
        {
            bool avalilabity = false;
            int itemcount = getAvailableItemCount( FacilityID, Product);

            //System.Windows.MessageBox.Show(itemcount.ToString());

            if (itemcount >= quantity)
            { 
                avalilabity = true;
            }

            return avalilabity;
        }
        internal int getAvailableItemCount(string FacilityID, string Product)
        {
            // Find RemainingItems in the facility
            string[] getCount = Connect.selectcolumn("ItemId", "RemainingItems", "ProductID", Product, "FacilityId", FacilityID);
            int itemcount = getCount.Length;

            //select stock manager in facility
            string StockManagerID = Connect.selectone("UserId", "Users", "FacilityId", FacilityID);

            //find quantities of his pending requests to relavant product
            getCount = Connect.selectcolumn("Quantity", "Release", "ProductID", Product, "UserId", StockManagerID, "Iscompleted", "0");
            

            int pendingItems = 0;
            for (int i = 0; i < getCount.Length; i++)
            {
                pendingItems = pendingItems + int.Parse(getCount[i]);
            }

            //get final item count
            itemcount = itemcount - pendingItems;

            return itemcount;
        }

        internal void addToDatabase(string releaseID, string ReleaseTime, string ReleaseDate, int quantity, string UserID, string Product, string FacID)
        {
            string[] fieldNames = new string[8];
            string[] Values = new string[8];
       

            fieldNames[0] = "ReleaseId"; Values[0] = releaseID;
            fieldNames[1] = "ReleaseDate"; Values[1] = ReleaseDate;
            fieldNames[2] = "ReleaseTime"; Values[2] = ReleaseTime;
            fieldNames[3] = "Quantity"; Values[3] = quantity.ToString();
            fieldNames[4] = "UserId"; Values[4] = UserID;
            fieldNames[5] = "ProductId"; Values[5] = Product;
            fieldNames[6] = "FacilityId"; Values[6] = FacID;
            fieldNames[7] = "Iscompleted"; Values[7] ="0";
            Connect.insertdata(fieldNames, Values, "Release");
            System.Windows.Forms.MessageBox.Show("inserted sucessfully");
        }

        internal override string WhoAmI()
        {
            return "Stock Manager";
        }

        internal override void PressRequest()
        {
            Form frm2 = new FormRelease() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Dashboard.db.LoadAnyForm(frm2);
        }

        internal override void PressRemove()
        {
            throw new NotImplementedException();
        }
    }
}
