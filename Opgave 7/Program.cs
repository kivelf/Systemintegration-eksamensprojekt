using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Messaging;

namespace Opgave_7
{
    internal class Program
    {
        // Opgave 7
        // Implementerer oversættelsen (translation) mellem systemerne Medlem og Nyhedsbrev.

        // queues and objects representing our systems
        private static MessageQueue outQueue;   // beskeder fra Medlemsregisteret bliver først sendt her
        private static MessageQueue translatedMessageQueue; // translated messages som går til Nyhedsbrevsystemet
        private static Medlemsregister medlemsregister;
        private static Nyhedsbrev nyhedsbrev;
        private static Translator translator;

        static void Main(string[] args)
        {
            // opretter queues
            createQueues();
        }

        private static void createQueues()
        {
            if (!MessageQueue.Exists(@".\Private$\L21OutQueue"))
            {
                MessageQueue.Create(@".\Private$\L21OutQueue");
            }
            outQueue = new MessageQueue(@".\Private$\L21OutQueue");
            outQueue.Label = "Out Queue";

            if (!MessageQueue.Exists(@".\Private$\L21TranslatedMessageQueue"))
            {
                MessageQueue.Create(@".\Private$\L21TranslatedMessageQueue");
            }
            translatedMessageQueue = new MessageQueue(@".\Private$\L21TranslatedMessageQueue");
            translatedMessageQueue.Label = "Medlemsregister Queue";
        }
    }
}
