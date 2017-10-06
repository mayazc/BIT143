using System;
using System.Collections.Generic;
using System.Text;

namespace Helpdesk.Unit_Tests
{
    class Helpdesk_TEST
    {
        /// <summary>
        /// These tests mostly operate by printing something out, and relying on the user
        /// to catch errors.  
        /// </summary>
        /// <returns>True if all tests passed ; false if one (or more) failed</returns>
        public bool RunTests()
        {

            Console.WriteLine("\n\n   Helpdesk::TESTS\n\n");

            Helpdesk hd = new Helpdesk();
            bool retVal = true;
            int iTest = 0;
            Ticket t; // for checking the return value of RemoveNextTicket
            Ticket t2;

            Console.WriteLine(" ================ Test #{0}: .isEmpty() on empty helpdesk ===============", iTest++);
            if (hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on empty helpdesk returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on empty helpdesk returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: PrintAll An Empty Queue =======================", iTest++);
            Console.WriteLine(" Should should see: an empty helpdesk, then \"End Of Test\"");
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Helpdesk.PrintAll With 1 Low Item =======", iTest++);
            Console.WriteLine(" Should should see: 1 Low item: \"Sample Item\", then \"End Of Test\"");
            hd.AddTicket("Sample Item", Priority.Low);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: .isEmpty on 1 Low item =================", iTest++);
            if (!hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on 1 Low item returns expected value (false)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on 1 Low item returns unexpected value (true)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: Add, Remove Low Prio Leaves Helpdesk Empty  ========", iTest++);
            Console.WriteLine(" Should should see: an empty helpdesk, then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"Sample Item\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: .isEmpty on empty helpdesk =================", iTest++);
            if (hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on empty helpdesk returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on empty helpdesk returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Helpdesk.PrintAll With 1 HighPrio Item =======", iTest++);
            Console.WriteLine(" Should should see: 1 high priority item: \"SAMPLE ITEM\", then \"End Of Test\"");
            hd.AddTicket("SAMPLE ITEM", Priority.High);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: .isEmpty on 1 High priority item =================", iTest++);
            if (!hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on 1 High item returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on 1 High item returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Add, Remove High Prio Leaves Helpdesk Empty  ========", iTest++);
            Console.WriteLine(" Should should see: an empty helpdesk, then \"End Of Test\"");
            t = hd.RemoveNextTicket(); ;
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"SAMPLE ITEM\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");



            Console.WriteLine(" ================ Test #{0}: .isEmpty on empty helpdesk =================", iTest++);
            if (hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on empty helpdesk returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on empty helpdesk returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: High Prio Enqueues Before Low ============", iTest++);
            Console.WriteLine(" Should should see: \"HIGH PRIORIT\", then \"Low Priority\", and then \"End Of Test\"");
            hd.AddTicket("HIGH PRIORITY", Priority.High);
            hd.AddTicket("Low Priority", Priority.Low);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: High Prio Removed Before Low ============", iTest++);
            Console.WriteLine(" Should should see: \"Low Priority\", then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"HIGH PRIORITY\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: High Prio Removed Before Low ============", iTest++);
            Console.WriteLine(" Should should see: empty helpdesk then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"Low Priority\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");



            Console.WriteLine(" ================ Test #{0}: High Prio Enqueues Before Low ============", iTest++);
            Console.WriteLine(" Regardless of order of enqueueing");
            Console.WriteLine(" Should should see: \"HIGH PRIORIT\", then \"Low Priority\", and then \"End Of Test\"");
            hd.AddTicket("Low Priority", Priority.Low);
            hd.AddTicket("HIGH PRIORITY", Priority.High);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: High Prio Removed Before Low ============", iTest++);
            Console.WriteLine(" Should should see: \"Low Priority\", then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"HIGH PRIORITY\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: Removed All Tickets ============", iTest++);
            Console.WriteLine(" Should should see: empty helpdesk then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"Low Priority\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: Multiple Tickets ============", iTest++);
            Console.WriteLine(" Should should see: no high priorities, then\n \"Low Priority\", \"Another Low Priority\", then \"Third Low Priority\"\nand then \"End Of Test\"");
            hd.AddTicket("Low Priority", Priority.Low);
            hd.AddTicket("Another Low Priority", Priority.Low);
            hd.AddTicket("Third Low Priority", Priority.Low);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove with Multiple Tickets ============", iTest++);
            Console.WriteLine(" Should should see: no high priorities, then\n \"Another Low Priority\", then \"Third Low Priority\"\nand then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"Low Priority\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");



            Console.WriteLine(" ================ Test #{0}: Add Several High Priorities to mix============", iTest++);
            Console.WriteLine(" Regardless of order of enqueueing");
            Console.WriteLine(" Should should see: \"HI PRIO\", then \"HI PRIO #2\", \"3RD HI PRIO\", then\n \"Another Low Priority\", then \"Third Low Priority\"\nand then \"End Of Test\"");
            hd.AddTicket("HI PRIO", Priority.High);
            hd.AddTicket("HI PRIO #2", Priority.High);
            hd.AddTicket("3RD HI PRIO", Priority.High);
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove High Prio ============", iTest++);
            Console.WriteLine(" Regardless of order of enqueueing");
            Console.WriteLine(" Should should see: then \"HI PRIO #2\", \"3RD HI PRIO\", then\n \"Another Low Priority\", then \"Third Low Priority\"\nand then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"HI PRIO\", then \"End Of Test\"");
            t.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: Remove All High Prios ============", iTest++);
            Console.WriteLine(" Should should see: no high prios, then\n \"Another Low Priority\", then \"Third Low Priority\"\nand then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            t2 = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"HI PRIO #2\", then \"3RD HI PRIO\", then \"End Of Test\"");
            t.Print();
            t2.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: Drain the Queue ============", iTest++);
            Console.WriteLine(" Should should see: no high prios, no Low prios \nand then \"End Of Test\"");
            t = hd.RemoveNextTicket();
            t2 = hd.RemoveNextTicket();
            hd.PrintAll();
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine(" ================ Test #{0}: Remove'd correct ticket========", iTest++);
            Console.WriteLine(" Should should see: \"Another Low Priority\", then \"Third Low Priority\", then \"End Of Test\"");
            t.Print();
            t2.Print();
            Console.WriteLine("End Of Test\n\n");


            Console.WriteLine(" ================ Test #{0}: .isEmpty() on empty helpdesk ===============", iTest++);
            if (hd.isEmpty())
                Console.WriteLine("Passed: .isEmpty on empty helpdesk returns expected value (true)");
            else
            {
                Console.WriteLine("FAILED FAILED: .isEmpty on empty helpdesk returns unexpected value (false)");
                retVal = false;
            }
            Console.WriteLine("End Of Test\n\n");

            Console.WriteLine("\n\n   Helpdesk::End of Tests\n\n");

            return retVal;
        }
    }
}
