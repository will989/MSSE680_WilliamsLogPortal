using System;

namespace Services
{
    public class OrganizationNotFoundException : Exception
    {
        public OrganizationNotFoundException(String s)
            : base(s)
        {

        }
    }
}

