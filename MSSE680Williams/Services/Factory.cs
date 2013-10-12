using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Services
{
    public class Factory
    {
        public static IMessageService GetMessageSvc()
        {
            return new MessageSvcImpl();
        }

        public static IOrganizationService GetOrganizationSvc()
        {
            return new OrganizationSvcImpl();
        }

        public static IUserService GetUserSvc()
        {
            return new UserSvcImpl();
        }
    }//end Factory
}
