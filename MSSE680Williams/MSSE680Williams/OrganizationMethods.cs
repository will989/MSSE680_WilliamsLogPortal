using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Organization
    {

        //verify that organization properties are valid
        public bool validate()
        {
            if (OrganizationId < 0) return false;
            if (Name == null) return false;
            if (Street == null) return false;
            if (City == null) return false;
            if (State == null) return false;
            if (Zip == null) return false;
            if (StartDate == null) return false;
            return true;
        }//end validate

        public bool equals(Organization organization)
        {
            if (OrganizationId != organization.OrganizationId) return false;
            if (Name != organization.Name) return false;
            if (Street != organization.Street) return false;
            if (City != organization.City) return false;
            if (State != organization.State) return false;
            if (Zip != organization.Zip) return false;
            if (StartDate != organization.StartDate) return false;
            return true;
        }//end equals

        public virtual ICollection<Organization> Organizations { get; set; }

    }
}

