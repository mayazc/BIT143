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
    //double linked list
    class ListOfTickets
    {
        //Instance Variables
        private Node start = null;
        private Node end = null;

        /// <summary>
        /// Checks if list is empty.
        /// </summary>
        /// <returns>True if start is null, otherwise false</returns>
        public bool isEmpty()
        {
            return start == null;
        }

        /// <summary>
        /// Prints tickets in the list
        /// O(n), walks through node list and checks while not empty (null).
        /// </summary>
        public void PrintAll()
        {
            Node node = start;

            //checks if node is not empty, prints contents.
            while (node != null)
            {
                node.Ticket.Print();
                node = node.Next;
            }
        }

        /// <summary>
        /// Adds ticket to the end of the list
        /// This is O(1) if statements, constant.
        /// </summary>
        /// <param name="t"></param>
        public void AddTicket(Ticket t)
        {
            Node node = new Node(ticket: t, prev: end);

            if (start == null) //fills in empty node.
                start = node;
            if (end != null) //keeps end link empty
                end.Next = node;

            end = node;
        }

        /// <summary>
        /// Removes ticket at the end of the list
        /// This is O(1) if statements, constant.
        /// </summary>
        /// <returns>Exception when list is empty, msg No tickets to remove</returns>
        /// <return>Ticket with priority</return>
        public Ticket RemoveNextTicket()
        {
            //Empty handler
            if (isEmpty())
                throw new Exception("There are no Tickets to be removed");

            Node node = start;
            start = start.Next;

            if (start == null)
            {
                end = null;
            }
            else
            {
                start.Prev = null;
            }

            return node.Ticket;


        }

        //Inner Class Node
        private class Node
        {
            /// <summary>
            /// The Ticket at this node.  We do not want to allow
            /// other classes to change this value.
            /// </summary>
            public Ticket Ticket { get; protected set; }

            /// <summary>
            /// The previous node in the list.  This will need to be updated
            /// as tickets are cleared from the list.
            /// </summary>
            public Node Prev { get; set; }

            /// <summary>
            /// The next node in the list.  This will need to be updated as
            /// tickets are added and removed.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Construct a node in the list
            /// </summary>
            /// <param name="ticket">Ticket object</param>
            /// <param name="prev"></param>
            /// <param name="next"></param>
            public Node(Ticket ticket, Node prev = null, Node next = null)
            {
                this.Ticket = ticket;
                this.Prev = prev;
                this.Next = next;
            }
        }
    }
}
