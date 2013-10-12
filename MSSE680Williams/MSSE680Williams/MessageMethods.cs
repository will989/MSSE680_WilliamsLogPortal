using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Message
    {
        //verify that message properties are valid
        public bool validate()
        {
            if (MessageId < 0) return false;
            if (CorrelationIdentifier < 0) return false;
            if (SendingOrgId < 0) return false;
            if (ReceivingOrgId < 0) return false;
            if (Severity < 0 || Severity > 4) return false;
            if (OrgMessage == null) return false;
            if (Timestamp == null) return false;
            return true;
        }//end validate

        public bool equals(Message message)
        {
            if (MessageId != message.MessageId) return false;
            if (CorrelationIdentifier != message.CorrelationIdentifier) return false;
            if (ReceivingOrgId != message.ReceivingOrgId) return false;
            if (Severity != message.Severity) return false;
            if (OrgMessage != message.OrgMessage) return false;
            if (Timestamp != message.Timestamp) return false;
            return true;
        }//end equals
    }
}
