using System;

namespace Services
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException(String s)
            : base(s)
        {

        }

        public MessageNotFoundException()
        {
            throw new NotImplementedException();
        }
    }
}