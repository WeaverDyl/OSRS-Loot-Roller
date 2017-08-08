using System;
using System.Collections.Generic;

namespace OSRS_Loot_Roller
{
    class Program
    {
        static Dictionary<string, int> lootTable = new Dictionary<string, int>(); //Stores the item and it's droprate (1/int)
        static string itemToRoll = ""; // The item the user wants to roll for
        static bool found = false; // Have we found the item yet?
        static int numberOfTries = 0; // The current number of rolls
        static int randomNumber = 0;

        // Add all of the items and their drop rates to lootTable
        static void initializeLootTable()
        {
            lootTable.Add("Ranger Boots", 293);
        }

        // Generate a random roll until we get the item we want
        static void processItemToRoll(string itemToProcess)
        {
            Random rndNum = new Random();
            randomNumber = rndNum.Next(1, lootTable[itemToProcess] + 1);
            while (!found)
            {
                if(randomNumber != lootTable[itemToProcess])
                {
                    numberOfTries++;
                    Console.WriteLine($"Rolling for {itemToProcess}, current dry streak: " + numberOfTries);
                    randomNumber = rndNum.Next(1, lootTable[itemToProcess] + 1);
                }
                else
                {
                    Console.WriteLine($"Got {itemToProcess}! It took " + (numberOfTries + 1) + " clues!");
                    found = true;
                }
            }
            Console.WriteLine("Would you like to try again? [y/n]");
            String rollAgain = Console.ReadLine();
            if (rollAgain.Equals("y", StringComparison.OrdinalIgnoreCase) || rollAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                itemToRoll = "";
                found = false;
                numberOfTries = 0;
                randomNumber = 0;
                runRoller();
            }
            else return;
        }

        static void runRoller()
        {
            Console.WriteLine("What item would you like to roll for?");
            Console.WriteLine("Type /list for a list of all possible items.");
            itemToRoll = Console.ReadLine();

            if (itemToRoll.Equals("/list"))
            {
                foreach (KeyValuePair<string, int> item in lootTable)
                {
                    Console.WriteLine(item.Key);
                }
                return;
            }

            foreach (KeyValuePair<string, int> item in lootTable)
            {
                if (item.Key.Equals(itemToRoll, StringComparison.OrdinalIgnoreCase))
                {
                    processItemToRoll(item.Key);
                }
            }
        }

        static void Main(string[] args)
        {
            initializeLootTable();
            runRoller();
        }
    }
}
