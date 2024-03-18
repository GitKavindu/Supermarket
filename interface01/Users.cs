using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace interface01
{
    internal abstract  class Users
    {            
        private string UserID;
        private string username;
        private string FacilityID;
        internal string getFacilityID()
        {
            return FacilityID;
        }
        internal static Users UserType;
        public string gettUsername()
        {
           return username;
        }
        public string getUserID()
        {
            return UserID;
        }
        internal abstract string WhoAmI();

        Random random = new Random();
        DatabaseConnect Connect = new DatabaseConnect();
        internal Users() 
        {
          /*if (this.UserType==null)
            {
                UserType=new NewUser();
            }*/
        }
        internal Users(string UserID)
        {
            this.UserID = UserID;
            FillDetails();
        }
        private void FillDetails()
        {
            this.username = Connect.selectone("FullName", "Users", "UserID", UserID);
            this.FacilityID= Connect.selectone("FacilityId", "Users", "UserID", UserID);
        }
       

     
        //Login
        internal void Login(string enteredUserID, string password, NewLogin logUser,Users user)
        {
            UserType = user;
           if( UserType.BeginLogin(enteredUserID, password) == true)
            {
                logUser.Hide();
                //go into
                
                UserType.Gointo();
                
            }
            
        }

        private bool BeginLogin(string enteredUserID, string password)
        {
            bool NextPhase = false;
            string output = Connect.selectone("UserPassword", "Users", "UserID", enteredUserID);
            if (output != "")
            {
               // MessageBox.Show(output);
                if (output == password)
                {
                    output = Connect.selectone("userstat", "Users", "UserID", enteredUserID);
                    if (output == "True") //means account is valid
                    {
                        //setUserID(UserID);
                        NextPhase = true;
                        output = Connect.selectone("UserType", "Users", "UserID", enteredUserID);
                         if (output == "Stock Manager") //login type
                         {
                            UserType=new StockManager(enteredUserID);
                         }
                         else if(output == "Branch Manager")
                         {
                           UserType = new BranchManager(enteredUserID);
                         }
                        else
                        {
                            UserType = new Staff(enteredUserID);
                        }
                    }
                     else
                     {
                         MessageBox.Show("oops, your account is not valid now");
                     }
                     
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                MessageBox.Show("Incorrect username");
            }
            return NextPhase;
        }

        internal abstract void Gointo();
        // end of login
        internal abstract void PressRequest();
        internal abstract void PressRemove();

        internal int getAvailableItemCount(string FacilityID, string Product)
        {
            throw new NotImplementedException();
            
        }
       
        

    }
}
