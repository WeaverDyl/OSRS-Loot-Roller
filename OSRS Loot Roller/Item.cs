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

        public Item(string name, int dropRate)
        {
            this.name = name;
            this.dropRate = dropRate;
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
    }
}
