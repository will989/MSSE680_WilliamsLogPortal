using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class User
    {
        //verify that user properties are valid
        public bool validate()
        {
            if (UserId < 0) return false;
            if (UserName == null) return false;
            if (Password == null) return false;
            if (FirstName == null) return false;
            if (LastName == null) return false;
            if (OrganizationId < 0) return false;
            if (ActiveDate == null) return false;
            return true;
        }//end validate

        public bool equals(User user)
        {
            if (UserId != user.UserId) return false;
            if (UserName != user.UserName) return false;
            if (Password != user.Password) return false;
            if (FirstName != user.FirstName) return false;
            if (LastName != user.LastName) return false;
            if (OrganizationId != user.OrganizationId) return false;
            if (AdminFlag != user.AdminFlag) return false;
            if (ActiveDate != user.ActiveDate) return false;
            if (InactiveDate != user.InactiveDate) return false;
            return true;
        }//end equals
    }
}
