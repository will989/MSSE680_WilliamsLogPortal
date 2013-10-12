using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using DAL;

namespace ServicesUnitTest
{
    [TestClass]
    public class OrganizationServiceTests
    {
        [TestMethod()]
        public void InsertOrganizationUsingOrganizationServiceImpl()
        {
            var factory = new Factory();
            Organization organization = new Organization();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "Service Implementation Organization";
            organization.Street = "Service Blvd";
            organization.City = "Service";
            organization.State = "CO";
            organization.Zip = "80601";
            organization.StartDate = System.DateTime.Now;

            //add organization using factory to create necessary service
            //IOrganizationService organizationSvc = (IOrganizationService)factory.GetService(typeof(IOrganizationService).Name);
            //organizationSvc.AddOrganization(organization);

            //pre-factory implementation
            //add organization to database using OrganizationSvcImpl
            OrganizationSvcImpl orgSvcImpl = new OrganizationSvcImpl();
            orgSvcImpl.AddOrganization(organization);

        }
    }
}

