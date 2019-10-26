/*
 * FILE         : MoneyData.cs
 * PROJECT      : Assignment 4
 * PROGRAMMER   : Group 3: Jackson Ruby, Mounika Kasarla, Artem Nahornyi, Sukhwinder Singh, Dipalee Gupta
 * DATE         : Oct. 1, 2019
 * DESCRIPTION  :
 *      Money class, holding information about the game.
 */

namespace ChangeGame
{
    public class MoneyData
    {
        //constants for multiplying values in CalculateTotal()
        private const decimal VALUE_CENT = 0.01M;
        private const decimal VALUE_NICKEL = 0.05M;
        private const decimal VALUE_DIME = 0.1M;
        private const decimal VALUE_QUARTER = 0.25M;
        private const decimal VALUE_LOONIE = 1;
        private const decimal VALUE_TOONIE = 2;

        /*
        * FUNCTION      : Money()
        * DESCRIPTION   :
        *       Constructor. Sets up the money object.
        */
        public MoneyData()
        {
            Pennys = 0;
            Nickels = 0;
            Dimes = 0;
            Quarters = 0;
            Loonies = 0;
            Toonies = 0;
        }

        //properties with getters and setters
        public int Pennys { get; set; }
        public int Nickels { get; set; }
        public int Dimes { get; set; }
        public int Quarters { get; set; }
        public int Loonies { get; set; }
        public int Toonies { get; set; }

        /*
        * FUNCTION      : CalculateTotal()
        * RETURNS       :
        *       decimal   : The total value of user inputted coins.
        * DESCRIPTION   :
        *       Occurs on a text change in the input textbox. 
        */
        public decimal CalculateTotal()
        {
            //calculate each total
            decimal pennyTotal = Pennys * VALUE_CENT;
            decimal nickelTotal = Nickels * VALUE_NICKEL;
            decimal dimeTotal = Dimes * VALUE_DIME;
            decimal quarterTotal = Quarters * VALUE_QUARTER;
            decimal loonieTotal = Loonies * VALUE_LOONIE;
            decimal toonieTotal = Toonies * VALUE_TOONIE;

            //add totals and return
            return pennyTotal + nickelTotal + dimeTotal + quarterTotal + loonieTotal + toonieTotal;
        }
    }
}
