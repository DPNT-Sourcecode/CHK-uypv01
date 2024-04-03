using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            ItemA itemA = new ItemA();
            ItemB itemB = new ItemB();
            ItemC itemC = new ItemC();
            ItemD itemD = new ItemD();
            ItemE itemE = new ItemE();

            int total = 0;

            Dictionary<IItem, int> priceTable = new Dictionary<IItem, int>()
            {
                { itemA, itemA.ItemPrice },
                { itemB, itemB.ItemPrice },
                { itemC, itemC.ItemPrice },
                { itemD, itemD.ItemPrice },
                { itemE, itemE.ItemPrice }
            };

            Dictionary<char, int> itemQuantities = new Dictionary<char, int>();
            foreach (var item in priceTable)
            {
                itemQuantities.Add(item.Key.ItemCode, 0);
            }

            itemA.SpecialOffers.Add(3, 130);
            itemA.SpecialOffers.Add(5, 200);
            itemB.SpecialOffers.Add(2, 45);
            itemE.SpecialOffers.Add(2, 30);

            foreach (char item in skus)
            {
                if (!itemQuantities.ContainsKey(item))
                {
                    return -1;
                }
                else if (itemQuantities.ContainsKey(item))
                {
                    itemQuantities[item] += 1;
                }
            }






            if (totalAs != 0)
            {

                int outOfOfferA = 0;
                int offerAtotal = 0;

                //I don't really like using this method of hardcoding numbers, 
                //but I would need more time to think about how best to do this and would normally refactor later
                if (totalAs % 3 == 0 && totalAs % 5 == 0)
                {
                    offerAtotal += totalAs / 5 * itemA.SpecialOffers[5];
                }
                else 
                {
                    foreach (var offer in itemA.SpecialOffers)
                    {

                    }
                }


                if (outOfOfferA == 0)
                {
                    total += offerATotal;
                }
                else
                {
                    total += offerATotal + (outOfOfferA * priceTable[itemA]);
                }
            }

            if (totalBs != 0)
            {
                int outOfOfferB = totalBs % specialOffers[itemB].Item1;
                int offerBTotal = totalBs / specialOffers[itemB].Item1 * specialOffers[itemB].Item2;

                if (outOfOfferB == 0)
                {
                    total += offerBTotal;
                }
                else
                {
                    total += offerBTotal + (outOfOfferB * priceTable[itemB]);
                }
            }

            return total;
        }
    }
}
