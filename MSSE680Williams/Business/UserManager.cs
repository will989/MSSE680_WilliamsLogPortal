using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using DAL;

namespace Business
{
    public class UserManager
    {
        public void AddUser(User user)
        {

            try
            {
                //user factory to get service implementations
                var userSvc = Factory.GetUserSvc();
                userSvc.AddUser(user);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while adding user" + e);
                throw new Exception();
            }
        }

        public User GetUser(int userId)
        {

            User user = new User();

            try
            {
                //user factory to get service implementations
                var userSvc = Factory.GetUserSvc();
                user = userSvc.GetUser(userId);
            }
            catch (UserNotFoundException unfe)
            {
                Debug.WriteLine("User with that id was not found" + unfe);
                throw new UserNotFoundException("User with that id was not found" + unfe);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while getting user" + e);
            }

            return user;
        }

        public void UpdateUser(User user)
        {

            try
            {
                //user factory to get service implementations
                var userSvc = Factory.GetUserSvc();
                userSvc.UpdateUser(user);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while updating user" + e);
            }

        }


        //a user should really only be inactivated but I will implement this
        public void DeleteUser(User user)
        {

            try
            {
                int userId = user.UserId;
                //user factory to get service implementations
                var userSvc = Factory.GetUserSvc();
                userSvc.DeleteUser(user);
                Debug.WriteLine("User with userId " + userId + "was deleted.");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while deleting user" + e);
            }

        }

        public List<User> GetOrganizationUsers(int orgId)
        {

            var userRepo = new DataRepository<User>();
            List<User> orgUsers = userRepo.GetBySpecificKey("OrganizationId", orgId).ToList<User>();

            return orgUsers;
        }

    }
}
