using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BagOLoot.Tests
{

    public class SantaHelperShould
    {
        SantaHelper _helper;
        SantasComptroller _comptroller;
        public SantaHelperShould()
        {
            _helper = new SantaHelper();
            _comptroller = new SantasComptroller();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
        //Given
            string toyName = "Skateboard";
            int childID = 1;
            //Add toy and childID to Toy table 
            bool toyID = _helper.AddToyToBag(childID, toyName);
    
            Assert.True(toyID);
        //Then
        }

        [Fact]
        public void RemoveToyFromChildsBag()
        {
            int toyID = 2;
            int childID = 1;
            _helper.RemoveChildsToy(1, 2);
            List<Toy> toys = _comptroller.GetChildsToys(childID);

            Assert.DoesNotContain<Toy>(toys.Find(n => n.ToyID == toyID), toys);
        }

    }
}