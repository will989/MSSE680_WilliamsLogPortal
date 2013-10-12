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
    public class UserServiceTests
    {
        //insert a user into the database using the UserSvcImpl
        [TestMethod()]
        public void InsertUserUsingUserSvcImpl()
        {
            var factory = new Factory();
            DateTime current = System.DateTime.Now;
            User user = new User();
            user.UserName = "userSvcImpl";
            user.Password = "testing";
            user.OrganizationId = 1;
            user.FirstName = "Service";
            user.LastName = "Implementation";
            user.AdminFlag = false;
            user.ActiveDate = current;


            //add user using factory to create necessary service
            //IUserService userSvc = (IUserService)factory.GetService(typeof(IUserService).Name);
            //userSvc.AddUser(user);

            //add user to database using UserSvcImpl
            UserSvcImpl userSvcImpl = new UserSvcImpl();
            userSvcImpl.AddUser(user);

        }
    }
}

