using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{

    public class SantaHelper
    {
        private List<int> _toyBag;
        public int AddToyToBag(int child, string toy)
        {
            return 4;
        }

        public List<int> RemoveChildsToy(int child, int toy)
        {
           // _toyBag = 
            return new List<int> { 6,7,8 };
        }
        public List<int> GetChildsToys(int child)
        {

            return new List<int>() { 4,6,7,8 };
        }
    }
}