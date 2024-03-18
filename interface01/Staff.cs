using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface01
{
    internal class Staff : Users
    {
        internal Staff(string userID) : base(userID)
        {

        }

        internal override void Gointo()
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

      //  internal void

        internal override void PressRemove()
        {
            throw new NotImplementedException();
        }

        internal override void PressRequest()
        {
            throw new NotImplementedException();
        }

        internal override string WhoAmI()
        {
            return "Staff";
        }
    }
}
