using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace Services
{
    public class MessageSvcImpl : IMessageService
    {

        // Factory not working with repositories, use RepositoryFactory
        public void AddMessage(Message message)
        {
            Factory factory = new Factory();
            //use the factory to create a repository
            //var myRepo = (Message) factory.GetRepository(typeof (IRepository).Name);
            //myRepo.Insert(message);

            var messageRepository = RepositoryFactory.Create("Message");
            messageRepository.Insert(message);
        }


        public Message GetMessage(int id)
        {
            Message message = new Message();
            message = null;
            try
            {
                //use the factory to create a repository
                //IMessageRepository messageRepository = (IMessageRepository)factory.GetRepository(typeof(IMessageRepository).Name);

                var msgRepo = new DataRepository<Message>();
                List<Message> myMsgs = msgRepo.GetBySpecificKey("MessageId", id).ToList<Message>();

                //Repository factory method:
                var messageRepository = Services.RepositoryFactory.Create("Message");
                //List<Message> myMessages = messageRepository.GetBySpecificKey("MessageId", id).ToList<Message>();

                message = myMsgs[0];

                if (message == null)
                {
                    throw new MessageNotFoundException("Message not found!");
                }


            }

            catch (OrganizationNotFoundException onfe)
            {
                System.Console.WriteLine("Caught OrganizationNotFoundException" + onfe);
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Caught Exception" + e);
            }

            return message;

        }

        public void UpdateMessage(Message message)
        {
            //use the factory to create a repository
            var messageRepository = RepositoryFactory.Create("Message");
            messageRepository.Update(message);
        }

        public void DeleteMessage(Message message)
        {
            //use the factory to create a repository
            var messageRepository = RepositoryFactory.Create("Message");
            messageRepository.Delete(message);
        }

        public List<Message> GetOrganizationMessages(int organizationId)
        {
            //use the factory to create a new repository
            var messageRepository = RepositoryFactory.Create("Message");
            var msgRepo = new DataRepository<Message>();
            List<Message> myMsgs = msgRepo.GetBySpecificKey("OrganizationId", organizationId).ToList<Message>();

            //List<Message> orgMessages = messageRepository.GetBySpecificKey("OrganizationId", organizationId).ToList<Message>(); 
            return myMsgs;

        }

        public List<Message> GetCorrelatedMessages(int correlationId)
        {
            //use the factory to create a new repository
            var messageRepository = RepositoryFactory.Create("Message");
            var msgRepo = new DataRepository<Message>();
            List<Message> myMsgs = msgRepo.GetBySpecificKey("CorrelationId", correlationId).ToList<Message>();

            //List<Message> myMsgsMessages = messageRepository.GetBySpecificKey("CorrelationId", correlationId).ToList<Message>(); 
            return myMsgs;

        }

    }
}
