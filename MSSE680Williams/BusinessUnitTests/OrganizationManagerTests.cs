using Business;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace BusinessUnitTests
{
    [TestClass]
    public class OrganizationServiceTests
    {
        [TestMethod()]
        public void BusinessOrgManagerInsertOrganizationUsingOrganizationServiceImpl()
        {
            var factory = new Factory();
            Organization organization = new Organization();
            var organizationManager = new OrganizationManager();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "Service Implementation Organization";
            organization.Street = "Service Blvd";
            organization.City = "Service";
            organization.State = "CO";
            organization.Zip = "80601";
            organization.StartDate = System.DateTime.Now;

            //use org manager to add organization
            organizationManager.AddOrganization(organization);


            //pre-factory implementation
            //add organization to database using OrganizationSvcImpl
            //OrganizationSvcImpl orgSvcImpl = new OrganizationSvcImpl();
            //orgSvcImpl.AddOrganization(organization);

        }
    }
}

