using System.Collections.Generic;
using DAL;

namespace Services
{
    //interface for User Service
    public interface IUserService : IService
    {
        void AddUser(User user);
        User GetUser(int id);
        User GetUser(string userName);
        void UpdateUser(User user);
        void DeleteUser(User user);
        List<User> GetOrganizationUsers(int orgId);

    }
}

