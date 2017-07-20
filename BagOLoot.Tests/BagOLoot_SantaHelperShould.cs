using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{

    public class SantaHelperShould
    {
        SantaHelper _helper;
        public SantaHelperShould()
        {
            _helper = new SantaHelper();
        }

        [Fact]
        public void AddToyToChildsBag()
        {
        //Given
            string toyName = "Skateboard";
            int childID = 1;
            //Add toy and childID to Toy table 
            bool toyID = _helper.AddToyToBag(childID, toyName);
            //Check Toy Table for all toys associated with childID
            // List<int> toys = _helper.GetChildsToys(childID);
    
            Assert.True(toyID);
        //Then
        }

        [Fact]
        public void RemoveToyFromChildsBag()
        {
            int toyID = 4;
            int childID = 715;
            _helper.RemoveChildsToy(715, 12);
            List<int> toys = _helper.GetChildsToys(childID);

            Assert.DoesNotContain(toyID, toys);
        }

    }
}