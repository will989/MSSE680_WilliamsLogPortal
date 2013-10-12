using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Business;

namespace BusinessUnitTests
{
    [TestClass]
    public class AuthenticateUserTests
    {
        [TestMethod()]
        public void AuthenticateUserTest()
        {
            string username = "Seed";
            string password = "testing";

            bool authorized = false;
            authorized = AuthenticateUser.AuthUser(username, password);

            Assert.IsTrue(authorized);

        }

        //this authentication should fail
        [TestMethod()]
        public void AuthenticateBadUserTest()
        {
            string username = "BadSeed";
            string password = "testingBadUser";

            bool authorized = false;
            try
            {
                authorized = AuthenticateUser.AuthUser(username, password);
            }
            catch (UserNotFoundException)
            {
                Debug.WriteLine("User was not found");
            }

            Assert.IsFalse(authorized);

        }
    }

}