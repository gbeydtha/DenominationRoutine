using System;

namespace DenominationRoutine
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputChars = "";
            Console.Write("Give amount and Press ENTER and Input 'x' will exit the program \n");
            do
            {
                Console.Write("# Give an Amount (only divisible by 10, 50 and 100) : ");
                inputChars = Console.ReadLine();
                var combinations = new CartridgeCombination();

                int number;
                if (int.TryParse(inputChars, out number))
                {
                    foreach (var item in combinations.CartridgeCombinations(number))
                    {
                        Console.WriteLine(item);
                    }
                }

                Console.WriteLine(); 

            } while (inputChars != "x");

        }
    }
}

