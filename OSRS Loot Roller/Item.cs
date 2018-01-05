using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Loot_Roller
{
    class Item
    {
        private string name;
        private int dropRate;
        private string type; // Specified how the item is obtained (through a clue / killing a monster)

        public Item(string name, int dropRate, string type)
        {
            this.name = name;
            this.dropRate = dropRate;
            this.type = type;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int DropRate
        {
            get { return this.dropRate; }
            set { this.dropRate = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
