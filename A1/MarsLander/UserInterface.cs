using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// May Azcarraga
/// BIT 143
/// A1.0
/// </summary>

namespace MarsLander
{
    // Interfaces with User
    class UserInterface
    {
        // Print a greeting to the user
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        /// <summary>
        /// This will print the 'picture' of the lander
        /// for example:
        ///      1000m: *
        ///      
        ///      900m:
        ///      800m:
        /// etc, etc
        /// </summary>
        ///  /// <param name="ml">MarsLander</param>
        public void PrintLocation(MarsLander ml)
        {
            // use integer math to determine which 100's block the current height is in.
            int alt = (ml.GetCurrent().GetHeight()) / 100;
            Console.WriteLine("{0}00m: *", alt);

            while (alt > 0)
            {
                alt--;
                Console.WriteLine("{0}00m:", alt);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// This prints out the info about the lander
        /// For example:
        ///      Exact height: 1350 meters
        ///      Current (downward) speed: -350 meters/second
        ///      Fuel points left: 0
        //// </summary>
        /// <param name="ml">MarsLander</param>
        public void PrintLanderInfo(MarsLander ml)
        {
            Console.WriteLine("Exact height: {0} meters", ml.GetCurrent().GetHeight());
            Console.WriteLine("Current (downward)speed: {0} meters / second", ml.GetCurrent().GetSpeed());
            Console.WriteLine("Fuel points left: {0}", ml.GetFuel());
            Console.WriteLine();
        }

        /// <summary>
        /// This will ask the user for how much fuel he/she wants to burn,
        /// verify that he/she's typed in an acceptable integer,
        /// (repeatedly asking the user for input if needed),
        /// and will then return that number back to the main method
        /// </summary>
        /// <param name="ml">MarsLander</param>
        /// <returns>Amount of fuel to burn</returns>
        public int GetFuelToBurn(MarsLander ml)
        {
            int avail = ml.GetFuel(); //available fuel
            int fuel = 0;
            while (true)
            {
                Console.WriteLine("How many points of fuel would you like to burn?");
                string line = Console.ReadLine();
                if (!int.TryParse(line, out fuel))
                {
                    Console.WriteLine("You need to type a whole number of fuel points to burn!");
                }
                else if (fuel < 0)
                {
                    Console.WriteLine("You can't burn less than 0 points of fuel!");
                }
                else if (fuel > avail)
                {
                    Console.WriteLine("You don't have {0} points of fuel!", fuel);
                }
                else
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("Just as a reminder, here's where the lander is: ");
                PrintLanderInfo(ml);
            }
            return fuel;
        }

        /// <summary>
        /// This will only be called once the lander is on the surface of Mars,
        /// and will tell the player if they successly landed or if they crashed
        /// </summary>
        /// <param name="ml">MarsLander</param>
        /// <param name="maxSpeed">Maximum speed at landing</param>
        public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
        {
            if (ml.GetCurrent().GetSpeed() > maxSpeed)
            {
                Console.WriteLine("The maximum speed for a safe landing is {0}; your lander's current speed is {1}", maxSpeed, ml.GetCurrent().GetSpeed());
                Console.WriteLine("You have crashed the lander into the surface of Mars, killing everyone on board,");
                Console.WriteLine("costing NASA millions of dollars, and setting the space program back by decades!");
            }
            else
            {
                Console.WriteLine("Congratulations!! You've successfully landed your Mars Lander, without crashing!!!");
            }
            Console.WriteLine("Here's the height/speed info for you:");
            PrintHistory(ml.GetHistory());
        }

        // This will print out, for example:
        //      Round #    Height (in m)    Speed (downwards, in m/s)
        //      0        850        150
        //      1        650        200
        // etc
        //
        // This is provided to you, but you'll need to add stuff elsewhere in order to make it work
        /// <summary>
        /// Print the history of the MarsLander descent with a header row and a row for
        /// each round.
        /// </summary>
        /// <param name="mlh">MarsLanderHistory object</param>
        public void PrintHistory(MarsLanderHistory mlh)
        {
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");

            int time = 0;

            // My failed attempt on trying to make this code work.
            // I'm wondering why mlh cannot touch the roundInfo nested class....
            //for (int i = 0; i < mlh.NumberOfRounds(); i++)
            //{
            //    Console.WriteLine("{0}\t\t{1}\t\t{2}", i, mlh.GetHeight(), mlh.GetSpeed());
            //}

            foreach (RoundInfo round in mlh)
            {
                time++;
                Console.WriteLine("{0}\t\t{1}\t\t\t\t{2}", time, round.GetHeight(), round.GetSpeed());
            }
        }
    }
}

