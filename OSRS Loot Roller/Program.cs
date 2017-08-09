using System;
using System.Collections.Generic;
using System.Linq;

namespace OSRS_Loot_Roller
{
    class Program
    {
        static List<Item> lootTable = new List<Item>(); //Stores the item
        static string itemToRoll = ""; // The item the user wants to roll for
        static bool found = false; // Have we found the item yet?
        static int numberOfTries = 0; // The current number of rolls
        static int randomNumber = 0;

        // Add all of the items and their drop rates to lootTable
        static void initializeLootTable()
        {
            lootTable.Add(new Item("Ranger Boots", 293));
        }

        static void askReroll()
        {
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

        // Generate a random roll until we get the item we want
        static void processItemToRoll(Item itemToProcess)
        {
            Random rndNum = new Random();
            randomNumber = rndNum.Next(1, itemToProcess.DropRate);
            while (!found)
            {
                if(randomNumber != itemToProcess.DropRate)
                {
                    numberOfTries++;
                    Console.WriteLine($"Rolling for {itemToProcess.Name}, current dry streak: " + numberOfTries);
                    randomNumber = rndNum.Next(1, itemToProcess.DropRate + 1);
                }
                else
                {
                    Console.WriteLine($"Got {itemToProcess.Name}! It took " + (numberOfTries + 1) + " clues!");
                    found = true;
                }
            }
            askReroll();
        }

        static void runRoller()
        {
            Console.WriteLine("What item would you like to roll for?");
            Console.WriteLine("Type /list for a list of all possible items.");
            itemToRoll = Console.ReadLine();

            if (itemToRoll.Equals("/list"))
            {
                foreach (Item item in lootTable)
                {
                    Console.WriteLine(item);
                }
                return;
            }
            if (!lootTable.Any(item => item.Name.Equals(itemToRoll, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("That item is not in the loot table, would you like to try a different item?");
                askReroll();
            }
            else
            {
                foreach (Item item in lootTable)
                {
                    if (item.Name.Equals(itemToRoll, StringComparison.OrdinalIgnoreCase))
                    {
                        processItemToRoll(item);
                    }
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
