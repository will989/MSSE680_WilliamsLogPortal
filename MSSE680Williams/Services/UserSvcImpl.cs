using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DAL;

namespace Services
{
    public class UserSvcImpl : IUserService
    {
        public void AddUser(User user)
        {
            //use the factory to create a repository
            var userRepository = RepositoryFactory.Create("User");
            userRepository.Insert(user);
        }

        public User GetUser(int id)
        {
            User user = new User();
            try
            {
                //use the factory to create a repository
                var userRepo = new DataRepository<User>();
                List<User> myUsers = userRepo.GetBySpecificKey("UserId", id).ToList<User>();
                user = myUsers[0];


                if (user == null)
                {
                    throw new UserNotFoundException("User not found!");
                }
            }
            catch (UserNotFoundException onfe)
            {
                System.Console.WriteLine("Caught UserNotFoundException" + onfe);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception" + e);
            }

            return user;
        }

        public User GetUser(string username)
        {
            //use the factory to create a repository

            User user = new User();
            User myUser = new User();
            if (username != null)
            {
                try
                {
                    andy680Entities db = new andy680Entities();

                    // use linq to find the user
                    myUser = (from d in db.Users where d.UserName == username select d).Single();
                    Debug.WriteLine("User's name is " + myUser.FirstName);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Caught exception" + e);
                    throw;
                }
            }
            return myUser;
            //return user;
        }

        public List<User> GetOrganizationUsers(int orgId)
        {
            //use the factory to create a new repository
            //var userRepository = RepositoryFactory.Create("User");
            //List<User> orgUsers = userRepository.GetBySpecificKey("OrganizationId", organizationId).ToList<User>();

            var userRepo = new DataRepository<User>();
            List<User> orgUsers = userRepo.GetBySpecificKey("OrganizationId", orgId).ToList<User>();

            return orgUsers;
        }

        public void UpdateUser(User user)
        {
            //use the factory to create a repository
            var userRepository = RepositoryFactory.Create("User");
            userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            //use the factory to create a repository
            var userRepository = RepositoryFactory.Create("User");
            userRepository.Delete(user);
        }
    }
}