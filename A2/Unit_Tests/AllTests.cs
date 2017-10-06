using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk.Unit_Tests
{
    class AllTests
    {
        public bool RunTests()
        {
            bool retVal = true;

            ListOfTickets_TEST lot = new ListOfTickets_TEST();
            if (!lot.RunTests())
            {
                Console.WriteLine("\n\nFAILED ONE OR MORE TESTSListOfTicketsts\n\n");
                retVal = false;
            }

            Helpdesk_TEST hdmT = new Helpdesk_TEST();
            if (!hdmT.RunTests())
            {
                Console.WriteLine("\n\nFAILED ONE OR MORE TESTS: Helpdesk\n");
                retVal = false;
            }

            return retVal;
        }
    }
}
