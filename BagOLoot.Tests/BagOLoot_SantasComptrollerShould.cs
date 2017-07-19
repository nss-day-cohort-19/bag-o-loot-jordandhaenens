using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests 
{
    public class SantasComptrollerShould
    {
        SantasComptroller _comptroller;
        public SantasComptrollerShould()
        {
            _comptroller = new SantasComptroller();
        }

        [Fact]
        public void GetChildrenWhoWillReceiveToys()
        {
            List<int> goodKids = _comptroller.GetGoodKids();

            Assert.IsType<List<int>>(goodKids);
        }

        [Fact]
        public void GetListOfAChildsToys()
        {
            int childID = 312;
            List<int> toys = _comptroller.GetChildsToys(childID);

            Assert.IsType<List<int>>(toys);
        }

        [Fact]
        public void IndicateChildsToyAreDelivered()
        {
            int childID = 312;
            bool deliveryStatus = _comptroller.DeliveryComplete(childID);

            Assert.Equal(deliveryStatus, true);
        }

    }

}