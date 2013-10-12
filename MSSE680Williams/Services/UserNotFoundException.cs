using System;

namespace Services
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(String s)
            : base(s)
        {

        }
    }
}

