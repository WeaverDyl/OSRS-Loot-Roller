using System;
using System.Collections.Generic;
using System.Linq;

namespace OSRS_Loot_Roller
{
    class Program
    {
        static List<Item> lootTable = new List<Item>(); //Stores the item
        static string itemToRoll = ""; // The item the user wants to roll for
        static bool obtained = false; // Have we obtained the item yet?
        static int numberOfTries = 0; // The current number of rolls
        static int randomNumber = 0; // Used as the upper limit for a random number generation

        // Add all of the items and their drop rates to lootTable
        static void initializeLootTable()
        {
            lootTable.Add(new Item("Ranger Boots", 293, "clue"));
            lootTable.Add(new Item("Third Age Platebody", 42140, "clue"));
            lootTable.Add(new Item("Armadyl Hilt", 508, "kill"));
        }

        // Used to ask the user if they want to roll again, handles accepting their response
        static void askReroll()
        {
            Console.WriteLine("Would you like to roll for a new item? [y/n]");
            String rollAgain = Console.ReadLine();
            if (rollAgain.Equals("y", StringComparison.OrdinalIgnoreCase) || rollAgain.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                // Reset all of the fields so that the statistics remain correct
                itemToRoll = "";
                obtained = false;
                numberOfTries = 0;
                randomNumber = 0;
                runRoller();
            }
            else if (rollAgain.Equals("n", StringComparison.OrdinalIgnoreCase) || rollAgain.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            else
            {
                // If the user didn't produce a valid response, ask again.
                askReroll();
            }
        }

        // Processes "itemToProcess", which is the item that the user chose to roll for.
        static void processItemToRoll(Item itemToProcess)
        {
            // Create a new random number ranging from 1 -> the items drop rate
            Random rndNum = new Random();
            randomNumber = rndNum.Next(1, itemToProcess.DropRate);
            // Generates a new random number and increases the number of tries until the magic number is rolled.
            while (!obtained)
            {
                // The magic number is just the drop rate of the item. If the random number is the drop rate, the item is obtained.
                // Otherwise, we try again.
                if (randomNumber != itemToProcess.DropRate)
                {
                    numberOfTries++;
                    Console.WriteLine($"Rolling for {itemToProcess.Name}, current dry streak: " + numberOfTries);
                    randomNumber = rndNum.Next(1, itemToProcess.DropRate + 1);
                }
                else
                {
                    Console.WriteLine($"Got {itemToProcess.Name}! It took " + (numberOfTries + 1) + $" {itemToProcess.Type}s!");
                    obtained = true;
                }
            }
            // After the item is obtained, ask the user if they want to try again
            askReroll();
        }

        static void runRoller()
        {
            Console.WriteLine("What item would you like to roll for?");
            Console.WriteLine("Type /list for a list of all possible items.");
            itemToRoll = Console.ReadLine();

            // This allows the user to see every available item to roll
            if (itemToRoll.Equals("/list"))
            {
                foreach (Item item in lootTable)
                {
                    Console.WriteLine(item.Name);
                }
                askReroll();
            }
            // If the item the user wants to roll for isn't in the list, let them know
            else if (!lootTable.Any(item => item.Name.Equals(itemToRoll, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("That item is not in the loot table, would you like to try a different item?");
                askReroll();
            }
            // Otherwise, find the item in the list, and start rolling for it, using its drop rate
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
