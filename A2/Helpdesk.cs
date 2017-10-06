using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// May Azcarraga
/// BIT 143
/// A2.0
/// </summary>
   

namespace Helpdesk
{
    class Helpdesk
    {
        //Initiates default listOfTickets LL.
        private ListOfTickets[] lists;

        /// <summary>
        /// Construct a help desk object.
        /// This is O(N), for-loop n = list.length.
        /// </summary>
        public Helpdesk()
        {
            int numPriorities = Enum.GetValues(typeof(Priority)).Length;
            lists = new ListOfTickets[numPriorities];

            for (int idx = 0; idx < lists.Length; idx++)
            {
                lists[idx] = new ListOfTickets();
            }
        }

        /// <summary>
        /// Indicate if there are tickets to work with
        /// This is O(n) checks one by one for-each loop n = lists.
        /// </summary>
        /// <returns>True if any tickets are left to work, otherwise false</returns>
        public bool isEmpty()
        {
            foreach (ListOfTickets list in lists)
            {
                if (!list.isEmpty())
                    return false;
            }
            // we only get to here if all of the lists were empty
            return true;
        }


        /// <summary>
        /// Print all the tickets, with the high priority items first.
        /// This is O(n) checks one by one for-loop, n = lists.Length-1.
        /// </summary>
        public void PrintAll()
        {
            for (int idx = lists.Length - 1; idx >= 0; idx--)
            {
                lists[idx].PrintAll();
            }
        }

        /// <summary>
        /// Add a ticket to the queue
        /// </summary>
        /// <param name="s">Ticket description</param>
        /// <param name="p">Ticket priority</param>
        public void AddTicket(string s, Priority p)
        {
            lists[(int)p].AddTicket(t: new Ticket(desc: s, prio: p));
        }

        /// <summary>
        /// Add a ticket to the queue
        /// O(1) for insertion
        /// </summary>
        /// <param name="t">Ticket</param>
        public void AddTicket(Ticket t)
        {
            lists[(int)t.Priority].AddTicket(t);
        }

        /// <summary>
        /// Remove the highest priority ticket from the queue.
        ///  O(1) for deletion
        /// </summary>
        /// <returns>Ticket</returns>
        public Ticket RemoveNextTicket()
        {
            Ticket ticket = null;
            for (int idx = lists.Length - 1; idx >= 0; idx--)
            {
                ListOfTickets list = lists[idx];
                if (!list.isEmpty())
                {
                    ticket = list.RemoveNextTicket();
                    break;
                }
            }
            //if (ticket == null) // the lists were all empty
            //    throw new Exception("No tickets to work!");
            return ticket;
        }

    }

}
