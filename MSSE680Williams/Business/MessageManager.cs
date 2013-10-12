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
    public class MessageManager
    {

        public void AddMessage(Message message)
        {
            //user factory to get message service
            var messageSvc = Factory.GetMessageSvc();

            try
            {
                messageSvc.AddMessage(message);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while adding message" + e);
                throw new Exception();
            }
        }

        public Message GetMessage(int messageId)
        {
            Message message = new Message();
            try
            {
                //user factory to get message service
                var messageSvc = Factory.GetMessageSvc();

                message = messageSvc.GetMessage(messageId);
            }
            catch (MessageNotFoundException mnfe)
            {
                Debug.WriteLine("Message with that id was not found" + mnfe);
                throw new MessageNotFoundException("Message with that id was not found" + mnfe);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while getting message" + e);
            }

            return message;
        }

        public List<Message> GetOrganizationMessages(int organizationId)
        {
            //user factory to get message service
            var messageSvc = Factory.GetMessageSvc();
            List<Message> orgMessages = new List<Message>();

            try
            {
                orgMessages = messageSvc.GetOrganizationMessages(organizationId);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while getting list of messages" + e);
            }

            return orgMessages;
        }

        public List<Message> GetCorrelatedMessages(int correlationId)
        {
            //user factory to get message service
            var messageSvc = Factory.GetMessageSvc();
            List<Message> correlatedMessages = new List<Message>();

            try
            {
                correlatedMessages = messageSvc.GetOrganizationMessages(correlationId);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception caught while getting list of messages" + e);
            }

            return correlatedMessages;
        }
    }
}

