//needed to add MSSE680_WilliamsLogMgmtPortal as a Reference
//under ServicesUnitTest
using System;
using Business;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace BusinessUnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        //insert a user into the database using the UserSvcImpl
        [TestMethod()]
        public void BusinessUserManagerInsertUserUsingUserSvcImpl()
        {
            var userManager = new UserManager();
            DateTime current = System.DateTime.Now;
            User user = new User();
            user.UserName = Randomizer.RandomString(12);
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Service";
            user.LastName = "Implementation";
            user.AdminFlag = false;
            user.ActiveDate = current;


            //use manager to add user
            userManager.AddUser(user);

            //pre-factory implementation
            //add user to database using UserSvcImpl
            //UserSvcImpl userSvcImpl = new UserSvcImpl();
            //userSvcImpl.AddUser(user);

        }
    }
}

