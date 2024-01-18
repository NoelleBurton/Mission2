using System;

// Dice Simulator
class DiceSimulator
{
    // Main
    static void Main()
    {
        // initialize variables
        int numRolls = 0;

        // introduce the code
        System.Console.WriteLine("Welcome to the dice throwing simulator!\n");

        // prompt for user input
        System.Console.Write("How many dice rolls would you like to simulate? ");

        // type cast to int
        // check for valid input
        if (int.TryParse(System.Console.ReadLine(), out numRolls))
        {
            // create an instance
            DiceRoller diceRoller = new DiceRoller();
            int[] results = diceRoller.SimulateRolls(numRolls);

            // display results
            Histogram(results, numRolls);

            Console.ReadLine();
        }

        // handle invalid input
        else
        {
            System.Console.WriteLine("Invalid input. Please enter a valid number of rolls.");
        }
    }

    // Histogram
    static void Histogram(int[] results, int numRolls)
    {
        // introduce histogram
        System.Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS\n" +
            "Each '*' represents 1% of the total number of rolls.\n" +
            "Number of rolls: " + numRolls + "\n");

        // calculate percentage & display histogram
        for (int i = 2; i <= 12; i++)
        {
            Console.Write($"{i}: ");
            // calculate the percentage
            double percentage = (results[i - 2] * 100.0) / numRolls;

            // calculate the number of '*' characters based on the percentage (rounded to the nearest integer)
            int numStars = (int)Math.Round(percentage);
        
            // print the little stars
            for (int j = 0; j < numStars; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}

// DiceRoller Class 
class DiceRoller
{
    // declare a random variable
    private Random random = new Random();

    // calculate total and append to array
    public int[] SimulateRolls(int numRolls)
    {
        int[] results = new int[11];

        for (int i = 0; i < numRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum - 2]++;
        }

        return results;
    }
}
