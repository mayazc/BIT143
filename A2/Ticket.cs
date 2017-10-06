using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// May Azcarraga
/// BIT 143
/// A2.0
/// </summary>

namespace Helpdesk
{
    enum Priority
    {
        Low,
        High
    }

    class Ticket
    {
        private string m_description;
        private Priority m_prio;

        public Priority Priority {  get { return m_prio; } }

        public Ticket(string desc, Priority prio)
        {
            m_description = desc;
            m_prio = prio;
        }

        public void Print()
        {
            Console.WriteLine("{0}\nPriority:{1}", m_description, m_prio == Priority.High ? "High" : "Low");
        }
    }
}
