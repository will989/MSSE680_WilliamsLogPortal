using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            List<Message> myMsgs = msgRepo.GetBySpecificKey("SendingOrgId", organizationId).ToList<Message>();

            return myMsgs;
        }

        public List<Message> GetCorrelatedMessages(int correlationId)
        {
            //use the factory to create a new repository
            var messageRepository = RepositoryFactory.Create("Message");
            var msgRepo = new DataRepository<Message>();
            List<Message> myMsgs = msgRepo.GetBySpecificKey("CorrelationIdentifier", correlationId).ToList<Message>();

            return myMsgs;
        }

        public ICollection<Message> GetAllMessages()
        {
            //use factory to get service implementations
            var messageSvc = Factory.GetMessageSvc();
            List<Message> msgList = new List<Message>();


            try
            {
                var msgRepo = new DataRepository<Message>();
                msgList = msgRepo.GetAll().ToList<Message>();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while getting list of messages" + e);
            }

            return msgList;
        }

        // From:  http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.objectdatasource.filterexpression.aspx
        // To support basic filtering, the messages cannot 
        // be returned as an array of objects, they need to be
        // returned as a DataSet of the raw data values.  
        public DataSet GetAllMessagesAsDataSet()
        {
            ICollection<Message> messages = GetAllMessages();

            var ds = new DataSet("Table");

            // Create the schema of the DataTable.
            DataTable dt = new DataTable();
            DataColumn dc;
            dc = new DataColumn("MessageId", typeof (int));
            dt.Columns.Add(dc);
            dc = new DataColumn("CorrelationIdentifier", typeof (int));
            dt.Columns.Add(dc);
            dc = new DataColumn("SendingOrgId", typeof (int));
            dt.Columns.Add(dc);
            dc = new DataColumn("ReceivingOrgId", typeof (int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Severity", typeof (int));
            dt.Columns.Add(dc);
            dc = new DataColumn("OrgMessage", typeof (string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Timestamp", typeof (DateTime));
            dt.Columns.Add(dc);

            // Add rows to the DataTable.
            DataRow row;

            //Loop through all the messages
            foreach (Message message in messages)
            {
                row = dt.NewRow();
                row["MessageId"] = message.MessageId;
                row["CorrelationIdentifier"] = message.CorrelationIdentifier;
                row["SendingOrgId"] = message.SendingOrgId;
                row["ReceivingOrgId"] = message.ReceivingOrgId;
                row["Severity"] = message.Severity;
                row["OrgMessage"] = message.OrgMessage;
                row["Timestamp"] = message.Timestamp;
                dt.Rows.Add(row);
            }
            // Add the complete DataTable to the DataSet.
            ds.Tables.Add(dt);

            return ds;
        }
    }
}
