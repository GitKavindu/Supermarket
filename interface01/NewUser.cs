using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interface01
{
    internal class NewUser:Users
    {
        DatabaseConnect Connect=new DatabaseConnect();
        internal override void Gointo()
        {
            throw new NotImplementedException();
        }

        internal override void PressRemove()
        {
            throw new NotImplementedException();
        }

        internal override void PressRequest()
        {
            throw new NotImplementedException();
        }

        internal void Register(string UserID, string Username, string Password, string FacilityName,string userCategory)
        {
            string facilityID = Connect.selectone("FacilityId", "Facility", "FacilityName", FacilityName);

            string[] fields = new string[6];
            string[] values = new string[6];

            fields[0] = "UserId"; values[0] = UserID;
            fields[1] = "FullName"; values[1] = Username;
            fields[2] = "UserPassword"; values[2] = Password;
            fields[3] = "FacilityId"; values[3] = facilityID;
            fields[4] = "Userstat"; values[4] = "0";
            fields[5] = "UserType"; values[5] = userCategory;
            Connect.insertdata(fields, values, "Users");
            MessageBox.Show("inserted sucessfully");
            Application.Exit();
        }

        internal override string WhoAmI()
        {
            throw new NotImplementedException();
        }
    }
}
