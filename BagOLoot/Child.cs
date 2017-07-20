using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class Child
    {
        public int ChildID { get; }
        public string Name { get; }
        public bool Delivered = false;

        public Child (int kidID, string name, int delivered)
        {
            ChildID = kidID;
            Name = name; 
            if ( delivered == 1 ) 
            {
                Delivered = true;
            } else
            {
                Delivered = false;
            }
        }
    }

}