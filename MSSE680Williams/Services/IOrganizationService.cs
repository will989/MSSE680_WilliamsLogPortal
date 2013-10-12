using System.Collections.Generic;
using DAL;

namespace Services
{
    public interface IOrganizationService : IService
    {
        void AddOrganization();
        void AddOrganization(Organization organization);
        Organization GetOrganization(int id);
        void UpdateOrganization(Organization organization);
        void DeleteOrganization(Organization organization);


        //System.Collections.Generic.List<Organization> GetAllOrganizations { get; set; }
        List<Organization> GetAllOrganizations();

    }
}
