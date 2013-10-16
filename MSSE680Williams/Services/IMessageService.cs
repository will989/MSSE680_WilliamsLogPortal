using System.Collections.Generic;
using System.Data;
using DAL;

namespace Services
{
    public interface IMessageService : IService
    {
        void AddMessage(Message message);
        Message GetMessage(int id);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
        List<Message> GetOrganizationMessages(int organizationId);
        List<Message> GetCorrelatedMessages(int correlationId);
    }
}

