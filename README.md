# OSRS-LOOT-ROLLER

## WHAT THIS IS
This is a simple command line program that allows you to emulate how many clue scrolls a unique item may take to get from a clue scroll in [OldSchool Runescape](https://www.oldschool.runescape.com). 

It's a very simple program, and is the first one I've ever written in C#, so there are probably parts that could be done more efficiently that I may not be aware of.

## WHY THIS EXISTS
I saw a [Reddit post](https://www.reddit.com/r/2007scape/comments/6s9bfi/osrs_loot_roller/) showing something similar off, and many people were interested in seeing a program like this released. Upon seeing how the original poster [implemented the concept](https://pastebin.com/XvGXyDHH), I took it as an opportunity to build something that I thought would be better, more user friendly, and more concise.

I also wrote this as a way to learn a bit of C#, which is a new language to me.

## HOW TO USE
Simply run the .exe file located at the root of the repository, or import the project into Visual Studio and run through that.

### How to add items
Currently only three item is available to roll, but it is very simple to add your own.

1. Open "Program.cs" in Visual Studio
2. locate the "initializeLootTable" method.
3. To add a new object, simply add "lootTable.Add(new Item("ITEM\_NAME\_HERE", DROP\_RATE\_HERE);

If you are trying to add an item, and don't know its drop rate, you can search various threads [here](https://reddit.com/r/2007scape/).

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
