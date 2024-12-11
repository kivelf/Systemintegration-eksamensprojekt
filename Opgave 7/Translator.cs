using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_7
{
    internal class Translator
    {
        protected MessageQueue InQueue;
        protected MessageQueue OutQueue;

        public Translator(MessageQueue inQueue, MessageQueue outQueue)
        {
            InQueue = inQueue;
            OutQueue = outQueue;

            inQueue.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }

        public void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            // modtager beskeden
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            // read the content from the original message
            string XMLDocument;
            using (Stream body = message.BodyStream)
            using (StreamReader reader = new StreamReader(body))
            {
                XMLDocument = reader.ReadToEnd();
            }

            // extracts the needed data
            // TODO

            // translates the data
            // TODO

            // sends the translated message to the receiving channel
            // TODO
        }
    }
}
