using System;

namespace BagOLoot
{
    public class Toy
    {
        public int ToyID { get; }
        public string ToyName { get; }
        public int ChildId { get; }
        public Toy(int toyID, string toyName, int childID)
        {
            ToyID = toyID;
            ToyName = toyName;
            ChildId = childID;
        }
    }
}