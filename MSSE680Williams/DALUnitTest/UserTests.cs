using System;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DALUnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod()]
        public void addUserFindUserDeleteUserToDatabaseTest()
        {
            andy680Entities db = new andy680Entities();

            User user = new User();
            //user.UserId = 1; - this is auto-assigned by db
            user.UserName = "test";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Test";
            user.LastName = "User";
            user.AdminFlag = false;
            user.ActiveDate = System.DateTime.Now;

            //add user to database
            db.Users.Add(user);
            db.SaveChanges();
            Assert.IsTrue(user.validate());

            //find user
            User user2 = db.Users.Find(user.UserId);
            int id = user2.UserId;
            System.Diagnostics.Debug.WriteLine("The user's id is {0}", id);
            Assert.IsTrue(user2.Equals(user));

            //remove user
            db.Users.Remove(user);
            db.SaveChanges();

        }

        [TestMethod()]
        public void validateGoodUserTest()
        {
            User user = new User();
            user.UserId = 1;
            user.UserName = "test";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Test";
            user.LastName = "User";
            user.AdminFlag = false;
            user.ActiveDate = System.DateTime.Now;

            Assert.IsTrue(user.validate());

        }

        [TestMethod()]
        public void validateBadUserTest()
        {
            User user = new User();
            user.UserId = -1;
            user.UserName = "test";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Test";
            user.LastName = "User";
            user.AdminFlag = false;
            user.ActiveDate = System.DateTime.Now;

            Assert.IsFalse(user.validate());

        }

        //verify that users are equal
        [TestMethod()]
        public void userEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            User user1 = new User();
            user1.UserId = 1;
            user1.UserName = "test";
            user1.Password = "testing";
            user1.OrganizationId = 1;
            user1.FirstName = "Test";
            user1.LastName = "User";
            user1.AdminFlag = false;
            user1.ActiveDate = current;


            User user2 = new User();
            user2.UserId = 1;
            user2.UserName = "test";
            user2.Password = "testing";
            user2.OrganizationId = 1;
            user2.FirstName = "Test";
            user2.LastName = "User";
            user2.AdminFlag = false;
            user2.ActiveDate = current;

            Assert.IsTrue(user1.equals(user2));
        }

        //verify that users are different
        [TestMethod()]
        public void userNotEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            User user1 = new User();
            user1.UserId = 1;
            user1.UserName = "test";
            user1.Password = "testing";
            user1.OrganizationId = 1;
            user1.FirstName = "Test";
            user1.LastName = "User";
            user1.AdminFlag = false;
            user1.ActiveDate = current;


            User user2 = new User();
            user2.UserId = 1;
            user2.UserName = "test";
            user2.Password = "testing";
            user2.OrganizationId = 2;
            user2.FirstName = "Test";
            user2.LastName = "User";
            user2.AdminFlag = false;
            user2.ActiveDate = current;

            Assert.IsFalse(user1.equals(user2));
        }
    }
}

