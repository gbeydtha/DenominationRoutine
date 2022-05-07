using System.Collections.Generic;

namespace DenominationRoutine
{
    public class CartridgeCombination
    {
        const int TEN_EURO_CARTRIDGE = 10;
        const int FIFTY_EURO_CARTRIDGE = 50;
        const int HUN_EURO_CARTRIDGE = 100;
        string euroSign = " EUR ";
        string mSign = " x ";
        string pSign = " + ";

        /// <summary>
        /// Will return possile combinations for certain amount. 
        /// But the ammount must be feasible by 10, 50 and 100
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<string> CartridgeCombinations(int number)
        {
            var items = new List<string>();
            int modTen = number % TEN_EURO_CARTRIDGE;
            int modFifty = number % FIFTY_EURO_CARTRIDGE;
            int modHundred = number % HUN_EURO_CARTRIDGE;

            if (modTen == 0) items.Add(OnlyTenCombination(number));
            if (modFifty == 0) items.Add(OnlyFiftyCombination(number));
            if (modHundred == 0) items.Add(OnlyHundredCombination(number));

            if (modTen == 0 && modFifty > 0 && number > FIFTY_EURO_CARTRIDGE)
            {
                int fiftyMult = number / FIFTY_EURO_CARTRIDGE;
                items.Add(fiftyMult.ToString() + mSign + FIFTY_EURO_CARTRIDGE + euroSign + pSign + OnlyTenCombination(modFifty));
            }

            if (modTen == 0 && modFifty == 0)
            {
                int fiftyMult = number / FIFTY_EURO_CARTRIDGE;
                if (fiftyMult > 1)
                {
                    items.Add((fiftyMult - 1).ToString() + mSign + FIFTY_EURO_CARTRIDGE + euroSign + pSign + OnlyTenCombination(FIFTY_EURO_CARTRIDGE));
                }
            }

            if (number > HUN_EURO_CARTRIDGE && modTen == 0 && modFifty > 0 && modHundred > 0)
            {
                int multHundred = number / HUN_EURO_CARTRIDGE;
                if (multHundred >= 1)
                {
                    string combs = multHundred.ToString() + mSign + HUN_EURO_CARTRIDGE + euroSign;
                    if (modHundred > 50)
                    {
                        string combination = combs + pSign
                            + (modHundred / FIFTY_EURO_CARTRIDGE).ToString() + mSign + FIFTY_EURO_CARTRIDGE + euroSign + pSign
                            + (modFifty / TEN_EURO_CARTRIDGE).ToString() + mSign + TEN_EURO_CARTRIDGE + euroSign;

                        items.Add(combination);
                    }
                    else
                    {
                        string combination = combs + pSign
                                             + (modHundred / TEN_EURO_CARTRIDGE).ToString() + mSign + TEN_EURO_CARTRIDGE + euroSign;

                        items.Add(combination);
                    }
                }
            }

            return items;
        }
        public string OnlyTenCombination(int number)
        {
            int mutiplied = number / TEN_EURO_CARTRIDGE; ;
            return mutiplied.ToString() + mSign + TEN_EURO_CARTRIDGE.ToString() + euroSign;
        }
        public string OnlyFiftyCombination(int number)
        {
            int mutiplied = number / FIFTY_EURO_CARTRIDGE; ;
            return mutiplied.ToString() + mSign + FIFTY_EURO_CARTRIDGE.ToString() + euroSign;
        }
        public string OnlyHundredCombination(int number)
        {
            int mutiplied = number / HUN_EURO_CARTRIDGE;
            return mutiplied.ToString() + mSign + HUN_EURO_CARTRIDGE.ToString() + euroSign;
        }
    }
}
