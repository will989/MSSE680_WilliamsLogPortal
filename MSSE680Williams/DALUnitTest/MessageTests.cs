using System;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DALUnitTest
{
    [TestClass]
    public class MessageTests
    {

        //Workflow test adds a message, retrieves a message
        //and deletes the message from a database
        [TestMethod()]
        public void AddMessageFindMessageDeleteMessageDatabaseTest()
        {
            //get database connection
            andy680Entities db = new andy680Entities();

            Message message = new Message();
            //message.MessageId = 1;  - this is auto-assigned by db
            message.CorrelationIdentifier = 1010101;
            message.SendingOrgId = 1;
            message.ReceivingOrgId = 1;
            message.Severity = 3;
            message.OrgMessage = "This is a test message";
            message.Timestamp = System.DateTime.Now;

            //add message to database
            db.Messages.Add(message);
            db.SaveChanges();
            Assert.IsTrue(message.validate());

            //find message
            Message message2 = db.Messages.Find(message.MessageId);
            int id = message2.MessageId;
            System.Diagnostics.Debug.WriteLine("The messages's id is {0}", id);
            Assert.IsTrue(message2.Equals(message));

            //clean up by removing message
            db.Messages.Remove(message);
            db.SaveChanges();
        }

        //validates that a message has the correct attributes
        [TestMethod()]
        public void ValidateGoodMessageTest()
        {
            Message message = new Message();
            message.MessageId = 1;
            message.CorrelationIdentifier = 1010101;
            message.SendingOrgId = 10;
            message.ReceivingOrgId = 20;
            message.Severity = 3;
            message.OrgMessage = "This is a test message";
            message.Timestamp = System.DateTime.Now;

            Assert.IsTrue(message.validate());

        }

        //verifies that an incomplete message fails validation
        [TestMethod()]
        public void ValidateBadMessageTest()
        {
            Message message = new Message();
            message.MessageId = -1;
            message.CorrelationIdentifier = 1010101;
            message.SendingOrgId = 10;
            message.ReceivingOrgId = 20;
            message.Severity = 3;
            message.OrgMessage = "This is a test message";
            message.Timestamp = System.DateTime.Now;

            Assert.IsFalse(message.validate());

        }

        //verify that messages are equal
        [TestMethod()]
        public void MessageEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            Message message1 = new Message();
            message1.MessageId = 1;
            message1.CorrelationIdentifier = 1010101;
            message1.SendingOrgId = 10;
            message1.ReceivingOrgId = 20;
            message1.Severity = 3;
            message1.OrgMessage = "This is a test message";
            message1.Timestamp = current;

            Message message2 = new Message();
            message2.MessageId = 1;
            message2.CorrelationIdentifier = 1010101;
            message2.SendingOrgId = 10;
            message2.ReceivingOrgId = 20;
            message2.Severity = 3;
            message2.OrgMessage = "This is a test message";
            message2.Timestamp = current;

            Assert.IsTrue(message1.equals(message2));
        }

        //verify that messages are different
        [TestMethod()]
        public void MessageNotEqualsTest()
        {
            DateTime current = System.DateTime.Now;

            Message message1 = new Message();
            message1.MessageId = 1;
            message1.CorrelationIdentifier = 1010101;
            message1.SendingOrgId = 10;
            message1.ReceivingOrgId = 20;
            message1.Severity = 3;
            message1.OrgMessage = "This is a test message";
            message1.Timestamp = current;


            Message message2 = new Message();
            message2.MessageId = 1;
            message2.CorrelationIdentifier = 1010101;
            message2.SendingOrgId = 10;
            message2.ReceivingOrgId = 20;
            message2.Severity = 1;//different severity
            message2.OrgMessage = "This is a test message";
            message2.Timestamp = current;

            Assert.IsFalse(message1.equals(message2));
        }
    }
}
