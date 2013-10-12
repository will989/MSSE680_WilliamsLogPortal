using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALUnitTest
{
    [TestClass()]
    public class RepositoryTests
    {

        //inserts an organization into the database using the repository
        [TestMethod()]
        public void InsertOrganizationUsingRepository()
        {

            var organizationRepository = new DataRepository<Organization>();
            Organization organization = new Organization();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "Repository Organization";
            organization.Street = "Testing St";
            organization.City = "Anytown";
            organization.State = "CO";
            organization.Zip = "80601";
            organization.StartDate = System.DateTime.Now;

            //add org to database
            organizationRepository.Insert(organization);

        }

        //retrieves an organization from the database using the repository
        [TestMethod()]
        public void RetrieveOrganizationsUsingRepository()
        {
            var organizationRepository = new DataRepository<Organization>();

            List<Organization> myList = organizationRepository.GetAll().ToList<Organization>();
            System.Diagnostics.Debug.WriteLine("The lists's size is {0}", myList.Count);
            Assert.IsTrue(myList.Count > 0);
        }

        //deletes an organization from the database using the repository
        [TestMethod()]
        public void DeleteOrganizationUsingRepositoryTest()
        {
            var organizationRepository = new DataRepository<Organization>();
            Organization organization = new Organization();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "DeleteTest Repository Organization";
            organization.Street = "Testing St";
            organization.City = "Anytown";
            organization.State = "CO";
            organization.Zip = "80601";
            organization.StartDate = System.DateTime.Now;

            //add org to database
            organizationRepository.Insert(organization);

            //now delete the organization
            organizationRepository.Delete(organization);
        }

        //insert a user into the database using the repository
        [TestMethod()]
        public void InsertUserUsingRepository()
        {

            var userRepository = new DataRepository<User>();

            DateTime current = System.DateTime.Now;
            User user = new User();
            user.UserName = "Repository";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Repository";
            user.LastName = "User";
            user.AdminFlag = false;
            user.ActiveDate = current;

            //add user to database
            userRepository.Insert(user);

        }

        //retrieves a user from the database using the repository
        [TestMethod()]
        public void RetrieveUsersUsingRepository()
        {
            var userRepository = new DataRepository<User>();

            List<User> myList = userRepository.GetAll().ToList<User>();
            System.Diagnostics.Debug.WriteLine("The lists's size is {0}", myList.Count);
            Assert.IsTrue(myList.Count > 0);
        }

        //deletes an organization from the database using the repository
        [TestMethod()]
        public void DeleteUserUsingRepositoryTest()
        {
            var userRepository = new DataRepository<User>();
            User user = new User();
            user.UserName = "Repository";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Repository";
            user.LastName = "DeleteUser";
            user.AdminFlag = false;
            user.ActiveDate = System.DateTime.Now;

            //add user to database
            userRepository.Insert(user);

            //now delete the user
            userRepository.Delete(user);

        }

        //insert a message into the database using the repository
        [TestMethod()]
        public void AddMessageUsingRepository()
        {
            var messageRepository = new DataRepository<Message>();

            DateTime current = System.DateTime.Now;

            Message message1 = new Message();
            message1.MessageId = 1;
            message1.CorrelationIdentifier = 1010101;
            message1.SendingOrgId = 1;
            message1.ReceivingOrgId = 1;
            message1.Severity = 3;
            message1.OrgMessage = "This is a test message";
            message1.Timestamp = current;

            //add message to database
            messageRepository.Insert(message1);
        }

        //rerieve a message from the database using the repository
        [TestMethod()]
        public void RetrieveMessagesUsingRepository()
        {
            var messageRepository = new DataRepository<Message>();

            List<Message> myList = messageRepository.GetAll().ToList<Message>();
            System.Diagnostics.Debug.WriteLine("The lists's size is {0}", myList.Count);
            Assert.IsTrue(myList.Count > 0);
        }

        //delete a message from the database using the repository
        [TestMethod()]
        public void DeleteMessageUsingRepositoryTest()
        {
            var messageRepository = new DataRepository<Message>();
            DateTime current = System.DateTime.Now;

            Message message = new Message();
            message.MessageId = 1;
            message.CorrelationIdentifier = 1010101;
            message.SendingOrgId = 1;
            message.ReceivingOrgId = 1;
            message.Severity = 3;
            message.OrgMessage = "This is a test message";
            message.Timestamp = current;

            //add message to database
            messageRepository.Insert(message);

            //now delete the message
            messageRepository.Delete(message);

        }
    }
}

