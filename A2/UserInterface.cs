using System;
using Helpdesk.Unit_Tests;

/// <summary>
/// BIT 143
/// A2.0
/// </summary>

// Given user interface to test List + helpdesk.
namespace Helpdesk
{
    class UserInterface
    {
        public void RunProgram()
        {
            Helpdesk theHelpdeskObject = new Helpdesk();
            Ticket tempTicket;

            bool fContinue = true;
            string desc; // description of problem, for inputting new problems

            while (fContinue)
            {
                int userChoice = -1;
                while (userChoice < 1 || userChoice > 6)
                {
                    Console.WriteLine(); // visual spacer
                    Console.WriteLine(" Your options are:");
                    Console.WriteLine("1) View all unsolved tickets");
                    Console.WriteLine("2) Add a high-priority ticket");
                    Console.WriteLine("3) Add a low-priority ticket");
                    Console.WriteLine("4) Resolve the first ticket");
                    Console.WriteLine("5) Run tests");
                    Console.WriteLine("6) Quit");
                    Console.Write("Type in your choice here:");
                    if (!Int32.TryParse(Console.ReadLine(), out userChoice))
                    {
                        Console.WriteLine("You need to type in a number!");
                    }
                    Console.WriteLine(); // visual spacer
                }

                switch (userChoice)
                {
                    case 1:
                        theHelpdeskObject.PrintAll();
                        break;
                    case 2:
                        Console.WriteLine("Type in a description of the high priority task:");
                        desc = Console.ReadLine();
                        theHelpdeskObject.AddTicket(desc, Priority.High);
                        break;
                    case 3:
                        Console.WriteLine("Type in a description of the low priority task:");
                        desc = Console.ReadLine();
                        theHelpdeskObject.AddTicket(desc, Priority.Low);
                        break;
                    case 4:
                        if (theHelpdeskObject.isEmpty())
                        {
                            Console.WriteLine("No items to resolve!");
                        }
                        else
                        {
                            Console.WriteLine("Resolving the following item:");
                            tempTicket = theHelpdeskObject.RemoveNextTicket();
                            tempTicket.Print();
                        }
                        break;
                    case 5:
                        AllTests allTests = new AllTests();
                        if (!allTests.RunTests())
                        {
                            Console.WriteLine("WARNING: One or more tests failed ; program probably won't run correctly");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Thanks for using the program!\nGoodbye!\n\n");
                        Console.WriteLine("<Press the enter key to exit>");
                        Console.ReadLine();
                        return;
                }
            }
        }
    }
}
