using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            int total = 0;
            int totalAs = 0;
            int totalBs = 0;

            char itemA = 'A';
            char itemB = 'B';
            char itemC = 'C';
            char itemD = 'D';

            Dictionary<char, int> priceTable = new Dictionary<char, int>()
            {
                {itemA, 50 },
                {itemB, 30 },
                {itemC, 20 },
                {itemD, 15 }
            };

            Dictionary<char, Tuple<int, int>> specialOffers = new Dictionary<char, Tuple<int, int>>();
            specialOffers.Add(itemA, new Tuple<int, int>(3, 130));
            specialOffers.Add(itemB, new Tuple<int, int>(2, 45));

            foreach (char item in skus)
            {
                if (!priceTable.ContainsKey(item))
                {
                    return -1;
                }
                else
                {
                    if (priceTable.ContainsKey(item))
                    {
                        if (item == itemA || item == itemB)
                        {
                            totalAs += item == itemA ? 1 : 0;
                            totalBs += item == itemB ? 1 : 0;
                        }
                        else
                        {
                            total += priceTable[item];
                        }
                        
                    }

                }
            }

            if (totalAs != 0)
            {
                int outOfOfferA = totalAs % specialOffers[itemA].Item1;
                int offerATotal = totalAs / specialOffers[itemA].Item1 * specialOffers[itemA].Item2;

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
