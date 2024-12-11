using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Messaging;
using System.Threading;

namespace Delopgave_3_2
{
    internal class Program
    {
        // Delopgave 3.2
        // Der skal kunne tjekkes, om den, der ønsker at tilmelde sig en aktivitet, er medlem.

        // queues
        private static MessageQueue TilmeldingssystemQueue;
        private static MessageQueue MedlemsregisterQueue;

        static void Main(string[] args)
        {
            // opretter queues
            createQueues();
            String request = @".\Private$\L21MedlemsregisterQueue";
            String reply = @".\Private$\L21TilmeldingssystemQueue";

            // opretter objekter der repræsenterer vores 2 systemer
            Requestor req1 = new Requestor(request, reply, "22334");    // request for medlem
            Requestor req2 = new Requestor(request, reply, "98765");    // request for ikke-medlem
            Requestor req3 = new Requestor(request, reply, "22334");    // request for medlem
            Replier replier = new Replier(request);

            // sender nogle requests og får nogle replies tilbage (med simulering af lidt ventetid mellem beskederne :) )
            req1.Send();
            Thread.Sleep(5000);

            req2.Send();
            Thread.Sleep(5000);

            req3.Send();

            while (true) { }
        }

        private static void createQueues()
        {
            if (!MessageQueue.Exists(@".\Private$\L21TilmeldingssystemQueue"))
            {
                MessageQueue.Create(@".\Private$\L21TilmeldingssystemQueue");
            }
            TilmeldingssystemQueue = new MessageQueue(@".\Private$\L21TilmeldingssystemQueue");
            TilmeldingssystemQueue.Label = "Tilmeldingssystem Queue";

            if (!MessageQueue.Exists(@".\Private$\L21MedlemsregisterQueue"))
            {
                MessageQueue.Create(@".\Private$\L21MedlemsregisterQueue");
            }
            MedlemsregisterQueue = new MessageQueue(@".\Private$\L21MedlemsregisterQueue");
            MedlemsregisterQueue.Label = "Medlemsregister Queue";
        }
    }
}
