using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

/// <summary>
/// May Azcarraga
/// BIT 143
/// A1.0
/// </summary>


namespace MarsLander
{
    //IEnumerable used for making foreach on the UserInterface class
    class MarsLanderHistory : IEnumerable
    {
        
        int numRounds = 0;
        RoundInfo first = null;
        RoundInfo current = null;
        RoundInfo last = null;

        // Clone is provided to you; it'll create a copy of the current history
        // Look for opportunities to use it elsewhere.
        //RoundInfo[] rounds = new RoundInfo[10];

        // used foreach and INumerable instead of another array 
        // list-type I'll keep this code though for later projects.
        //public MarsLanderHistory Clone()
        //{
        //    MarsLanderHistory copy = new MarsLanderHistory();

        //    copy.rounds = new RoundInfo[this.rounds.Length];
        //    copy.numRounds = this.numRounds;
        //    for (int i = 0; i < copy.numRounds; i++)
        //        copy.rounds[i] = this.rounds[i];

        //    return copy;
        //}

       // <param name="height">Integer local variable</param>
       // <param name="speed">Integer local variable</param>
        public void AddRound(int height, int speed)
        {
            RoundInfo round = new RoundInfo(t: numRounds++, h: height, s: speed);

            if(first == null)
            {
                first = round;
                last = round;
                current = round;
            }
            else
            {
                last.Next = round;
                last = round;
                current = round;
            }
        }

        //Gets the last element of the list
        public RoundInfo Last()
        {
            return last;
        }

        //IEnumerator checks if current is empty and the next space after that if it's not
        //basically this class returns the methods and properties for iteration
        public IEnumerator GetEnumerator()
        {
            current = null;

            while (current != last)
            {
                if (current == null) current = first;
                else current = current.Next;

                yield return current;
            }
        }
        // you'll need other methods in order to make the PrintHistory command work

        public int NumberOfRounds()
        {
            return numRounds;
        }

    }

    // This is provided to you; you shouldn't need to add anything to it, but
    // if you want to you are welcome to do so
    // Inner class for rounding the current height and speed of the lander
    class RoundInfo
    {
        private int height;
        private int speed;

        public RoundInfo Next { get; set;}

    #region Accessors

    public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }

        #endregion Accessors

        public RoundInfo(int h, int s, int t)
        {
            height = h;
            speed = s;
            Next = null;

        }
    }
}
