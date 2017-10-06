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
    class Program
    {
        //  In a nutshell, the program is made up of four major classes:
        //
        //  1. This Program class
        //      It houses main; main's job is to drive the overall logic of the game
        //
        //  2. MarsLander
        //      This stores the current height, speed, and fuel of the lander (properly encapsulated)
        //      This also has an instance of the 'MarsLanderHistory' object, and the lander is
        //      responsible for adding to the history whenever it calculates the lander's new speed
        //
        //  3. UserInterface
        //      This handles ALL interactions with the user. 
        //      NO OTHER CLASS IS ALLOWED TO INTERACT WITH THE USER!!
        //
        //  3. MarsLanderHistory
        //      This manages an array of RoundInfo objects.  It will provide a method to add
        //      another round to the history of the lander (and will resize the array, if needed)
        //      It provides a Clone method so that the lander can return a copy of the 
        //      history (which will prevent other classes from changing it's history)
        //      And it provides a way to get the number of rounds, and (for each round) the
        //      height and speed of that round (the UserInterface.PrintHistory method will use these)
        //          (This class uses the provided, minor RoundInfo class)
        //
        //  Substantial amounts of this program have been commented out, so that the program will compile
        //
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            MarsLander lander = new MarsLander();
            const int MAX_SPEED = 10; // 10 m/s
                // const means that we can't change the value after this line

            ui.PrintGreeting();

            /* the lander's height */
            while (lander.GetCurrent().GetHeight() > 0)
            {
                ui.PrintLocation(lander);
                ui.PrintLanderInfo(lander);

                int fuelToBurn = ui.GetFuelToBurn(lander);

                lander.CalculateNewSpeed(fuelToBurn);
            }

            ui.PrintLocation(lander);
            ui.PrintLanderInfo(lander);
            ui.PrintEndOfGameResult(lander, MAX_SPEED);
        }
    }
}
