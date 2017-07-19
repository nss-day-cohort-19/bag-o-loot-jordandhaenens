using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantasComptroller
    {
        public List<int> GetGoodKids()
        {
            return new List<int> () { 712, 432, 543, 124 };
        }

        public List<int> GetChildsToys(int childID)
        {
            return new List<int> () { 1, 2, 3, 4, 5, 6 };
        }

        public bool DeliveryComplete(int childID) 
        {
            return true;
        }
    }

}