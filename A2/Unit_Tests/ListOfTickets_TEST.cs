using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk.Unit_Tests
{
    class ListOfTickets_TEST
    {
        /// <summary>
        /// These tests mostly operate by printing something out, and relying on the user
        /// to catch errors.  
        /// There is some limited automation around the 'isEmpty' method
        /// </summary>
        /// <returns>True if all tests passed ; false if one (or more) failed</returns>
        public bool RunTests()
        {
            bool retVal = true;
            ListOfTickets lot = new ListOfTickets();
            Ticket t;

            Console.WriteLine("\n\n ListOfTicketsts::TESTS \n\n");

            Console.WriteLine(" ================ Test #0: Empty ListOfTickets.isEmpty() =======================");
            if (lot.isEmpty())
                Console.WriteLine("Passed: .isEmpty on empty ListOfTickets returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on empty ListOfTickets returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #1: Print An Empty ListOfTickets =======================");
            Console.WriteLine(" Should should see: \"End Of Test\" on the next line");
            lot.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #2: Print A ListOfTickets With 1 Item ==================");
            Console.WriteLine(" Should should see: \"Sample Item\", then \"End Of Test\" on the next 2 lines");
            lot.AddTicket(new Ticket("Sample Item", Priority.Low));
            lot.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #3: ListOfTickets with 1 item.isEmpty() =================");
            if (!lot.isEmpty())
                Console.WriteLine("Passed: .isEmpty on ListOfTickets with 1 item returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on ListOfTickets with 1 item returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #4: Add, Remove Leaves ListOfTickets Empty  ========");
            Console.WriteLine(" Should should see: next part of this test, on the next line");
            t = lot.RemoveNextTicket();
            lot.PrintAll();
            Console.WriteLine("\nShould should see: \"Sample Item\", then \"End Of Test\" on the next lines");
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #5: Empty ListOfTickets.isEmpty() =======================");
            if (lot.isEmpty())
                Console.WriteLine("Passed: .isEmpty on (once again) empty ListOfTickets returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on (once again) empty ListOfTickets returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #6: Multiple Adds Preserve Order ============");
            Console.WriteLine(" Should should see: \"Sample Item\", then \"Another Item\", then \"Final Item\", and then \"End Of Test\" on the next 4 lines");
            lot.AddTicket(new Ticket("Sample Item", Priority.Low));
            lot.AddTicket(new Ticket("Another Item", Priority.Low));
            lot.AddTicket(new Ticket("Final Item", Priority.Low));
            lot.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #7: ListOfTickets with several items.isEmpty() ===========");
            if (!lot.isEmpty())
                Console.WriteLine("Passed: .isEmpty on ListOfTickets with 1 item returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on ListOfTickets with 1 item returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine("\n\n ListOfTicketsts::End of Tests\n\n");

            return retVal;
        }
    }
}
