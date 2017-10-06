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
    class MarsLander
    {
        //starting variables
        private const int initialHeight = 1000;
        private const int intitialSpeed = 100;
        private const int deltaSpeed = 50; //change in acceleration * time m/s
        private const int initialFuel = 500;
        private RoundInfo current;
        private int fuel = initialFuel;
        // positive speed == speed towards Mars (DOWNWARD)

        //mlh object newly constructed
        private MarsLanderHistory mlh = new MarsLanderHistory();

        // you'll need to add data fields & methods so that the rest of the program
        // can use the various properties of the lander (such as height, speed, etc)


        public MarsLander()
        {
            mlh.AddRound(height: initialHeight, speed: intitialSpeed);
            current = mlh.Last();
        }

        //param name="burnDelta">Integer local variable</param>
        public void CalculateNewSpeed(int burnDelta)
        {
            int speed = current.GetSpeed() + deltaSpeed - burnDelta;
            int height = current.GetHeight() - speed;
            fuel -= burnDelta;
            // create a new current and add it to the history
            mlh.AddRound(height: height, speed: speed);
            current = mlh.Last();
        }
        /// <summary>
        /// Get the History of this landing attempt
        /// </summary>
        /// <returns>MarsLanderHistory</returns>
        public MarsLanderHistory GetHistory()
        {
            return mlh;
        }
        /// <summary>
        /// Get the amount of fuel points available
        /// </summary>
        /// <returns></returns>
        public int GetFuel()
        {
            return fuel;
        }
        /// <summary>
        /// Get the current position of the lander
        /// </summary>
        /// <returns>RoundInfo</returns>
        public RoundInfo GetCurrent()
        {
            return current;
        }
    }
}
