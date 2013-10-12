using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Services;

namespace ServicesUnitTest
{
    [TestClass]
    public class RepositoryFactoryTests
    {
        //inserts an organization into the database using the repository
        [TestMethod()]
        public void InsertOrganizationUsingRepositoryFactory()
        {

            Organization organization = new Organization();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "Repository Factory Organization";
            organization.Street = "Factory Blvd";
            organization.City = "Repository";
            organization.State = "CO";
            organization.Zip = "80601";
            organization.StartDate = System.DateTime.Now;

            //use repository factory to create a repository
            //of the correct type
            //var organizationRepository = RepositoryFactory.Create("Organization");
            var organizationRepository = new DataRepository<Organization>();
            if (organizationRepository == null) throw new ArgumentNullException("organizationRepository");

            //add org to database
            organizationRepository.Insert(organization);

            //get "Cannot convert instance argument IQueryable to IEnumerable error
            //List<Organization> orgList = organizationRepository.GetBySpecificKey("Name", "Repository Factory Organization").ToList<Organization>();

        }

        [TestMethod()]
        public void InsertMessageUsingRepositoryFactory()
        {

            DateTime current = System.DateTime.Now;

            Message message1 = new Message();
            message1.MessageId = 1;
            message1.CorrelationIdentifier = 1010101;
            message1.SendingOrgId = 1;
            message1.ReceivingOrgId = 1;
            message1.Severity = 3;
            message1.OrgMessage = "This is a test message";
            message1.Timestamp = current;

            //use repository factory to create a repository
            //of the correct type

            var messageRepository = RepositoryFactory.Create("Message");
            //var messageRepository = new DataRepository<Message>();
            if (messageRepository == null) throw new ArgumentNullException("messageRepository");

            //add message to database
            messageRepository.Insert(message1);

        }
    }
}

