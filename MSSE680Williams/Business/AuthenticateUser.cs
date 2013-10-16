using System;
using System.Diagnostics;
using System.Security.Policy;
using Services;
using DAL;

namespace Business
{
    public class AuthenticateUser
    {
        public static bool AuthUser(string username, string password)
        {
            bool authorized = false;
            //try to authenticate user
            try
            {
                User user = new User();

                //if the factory is working, do it this way...
                //user factory to get service implementations
                var userSvc = Factory.GetUserSvc();

                if (userSvc != null)
                {
                    user = userSvc.GetUser(username);
                }

                else
                {
                    //if the factory isn't working, do it the old way
                    UserSvcImpl userSvcImpl = new UserSvcImpl();
                    user = userSvcImpl.GetUser(username);
                }
                Debug.WriteLine("username = " + user.UserName);
                Debug.WriteLine("password = " + user.Password);

                if (user.Password.Equals(password))
                {
                    authorized = true;
                    //for debugging
                    Debug.WriteLine("user is authorized!");
                }
                else
                    throw new UserNotFoundException("User not found!");
            }
            catch (UserNotFoundException unfe)
            {
                Debug.WriteLine("Caught UserNotFoundException" + unfe);
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Caught Exception" + e);
            }

            return authorized;
        }
    }
}
