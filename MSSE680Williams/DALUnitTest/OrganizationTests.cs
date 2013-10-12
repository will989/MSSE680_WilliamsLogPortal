using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALUnitTest
{
    [TestClass()]
    public class OrganizationTests
    {

        //Workflow test adds an organization, retrieves an organization
        //and deletes the organization from a database
        [TestMethod()]
        public void addOrganizationFindOrganizationDeleteOrganizationDatabaseTest()
        {
            //get database connection
            andy680Entities db = new andy680Entities();

            Organization organization = new Organization();
            //organization.OrganizationId = 1;  - this is auto-assigned in db
            organization.Name = "testorg";
            organization.Street = "Testing St";
            organization.City = "Anytown";
            organization.State = "CO";
            organization.Zip = "80000";
            organization.StartDate = System.DateTime.Now;

            //add org to database
            db.Organizations.Add(organization);
            db.SaveChanges();
            Assert.IsTrue(organization.validate());

            //find organization
            Organization organization2 = db.Organizations.Find(organization.OrganizationId);
            int id = organization2.OrganizationId;
            System.Diagnostics.Debug.WriteLine("The organization's id is {0}", id);
            Assert.IsTrue(organization2.Equals(organization));

            //clean up by removing organization
            db.Organizations.Remove(organization);
            db.SaveChanges();
        }

        //validates that an organization has the correct attributes
        [TestMethod()]
        public void validateGoodOrganizationTest()
        {
            Organization organization = new Organization();
            organization.OrganizationId = 1;
            organization.Name = "testorg";
            organization.Street = "Testing St";
            organization.City = "Anytown";
            organization.State = "CO";
            organization.Zip = "80000";
            organization.StartDate = System.DateTime.Now;

            Assert.IsTrue(organization.validate());

        }

        //verifies that an incomplete organization fails validation
        [TestMethod()]
        public void validateBadOrganizationTest()
        {
            Organization organization = new Organization();
            organization.OrganizationId = -1;
            organization.Name = "testorg";
            organization.Street = "Testing St";
            organization.City = "Anytown";
            organization.State = "CO";
            organization.Zip = "80000";
            organization.StartDate = System.DateTime.Now;

            Assert.IsFalse(organization.validate());

        }

        //verify that organizations are equal
        [TestMethod()]
        public void organizationEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            Organization organization1 = new Organization();
            organization1.OrganizationId = 1;
            organization1.Name = "testorg";
            organization1.Street = "Testing St";
            organization1.City = "Anytown";
            organization1.State = "CO";
            organization1.Zip = "80000";
            organization1.StartDate = current;


            Organization organization2 = new Organization();
            organization2.OrganizationId = 1;
            organization2.Name = "testorg";
            organization2.Street = "Testing St";
            organization2.City = "Anytown";
            organization2.State = "CO";
            organization2.Zip = "80000";
            organization2.StartDate = current;

            Assert.IsTrue(organization1.equals(organization2));
        }

        //verify that organizations are different
        [TestMethod()]
        public void organizationNotEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            Organization organization1 = new Organization();
            organization1.OrganizationId = 1;
            organization1.Name = "testorg";
            organization1.Street = "Testing St";
            organization1.City = "Anytown";
            organization1.State = "CO";
            organization1.Zip = "80000";
            organization1.StartDate = current;


            Organization organization2 = new Organization();
            organization2.OrganizationId = 2;
            organization2.Name = "testorg";
            organization2.Street = "Testing St";
            organization2.City = "Anytown";
            organization2.State = "CO";
            organization2.Zip = "80000";
            organization2.StartDate = current;

            Assert.IsFalse(organization1.equals(organization2));
        }
    }
}

