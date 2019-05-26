using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameAssignment.BusinessLogic
{
    class NumberList
    {
        private int[] Numbers;
        private NumberRange Range;
        private Random rand;  

        /// <summary>
        /// NumberList constructo which initializes array, random numbers and range of random numbers from (0,9)
        /// </summary>
        /// <param name="size"></param>
        public NumberList(int size)
        {
            this.Numbers = new int[size];
            rand = new Random();
            Range = new NumberRange(0, 10);

        }
         
        /// <summary>
        /// Method which fills the number list with random number ranging from 0 to 9 
        /// </summary>
        public void FillNumberList()
        { 

            for (int counter = 0; counter < Numbers.Length; counter++)
            {
                Numbers[counter] = rand.Next(Range.GetLowerLimit(), Range.GetUpperLimit()); 
            } 
            
        }
        /// <summary>
        /// Calculates Frequency checks if numbers are sorted and then calculates the occurence of each number
        /// first iterates through array and then checks if numbers at indexes are equals to each other. If they are 
        /// it increments the counter. Flag variable acts like boolean it is initialized to false and 
        /// if numbers at both index are equal flag variable is true and then checks the next index variable 
        /// to see if they both equal to each other if not, it moves on and check the next till end of the array. 
        /// At the end it multiplies the frequency by 10 . So if 1 same number = 1 pair = 10 points 2 pair 20 points
        /// 
        /// </summary>
        /// <returns>frequency of same numbers </returns>
        public int CalculateFrequency() {
            int frequency = 0;

            Array.Sort(Numbers);  

            for (int i = 0; i < Numbers.Length; i++)
            {
                int counter = 0;   
                int k = -1;
                int flag = 0; 
                for (int j = i + 1; flag != 1 && j <= Numbers.Length-1; j++)
                {
                    if (Numbers[i] == Numbers[j])
                    {
                        counter++;
                        k = j;
                    }

                    else flag = 1; 
                }

                if (k != -1)
                {
                    i = k;
                }

                if(counter > 0)
                {
                    frequency += (counter * 10);
                }

            }
            return frequency;
        }

        /// <summary>
        /// Method to return index of number 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Index of Numbers</returns>
        public int GetNumberAt(int index)
        {
            return Numbers[index];
        }
        private class NumberRange
        {
            private int upperLimit;
            private int lowerLimit; 
            /// <summary>
            /// Number range for dice with numbers ranging in including lower limit and excluding upper limit
            /// </summary>
            /// <param name="lowerLimit"></param>
            /// <param name="upperLimit"></param>

            public NumberRange (int lowerLimit, int upperLimit)
            {
                this.lowerLimit = lowerLimit;
                this.upperLimit = upperLimit;

            }

            /// <summary>
            /// Getter for lower limit of number 
            /// </summary>
            /// <returns>lowerLimit</returns>
            public int GetLowerLimit() { return lowerLimit;  }

            /// <summary>
            /// Getter for upper limit of the number 
            /// </summary>
            /// <returns>upperLimit</returns>
            public int GetUpperLimit() { return upperLimit;  }
        }



    }
}
