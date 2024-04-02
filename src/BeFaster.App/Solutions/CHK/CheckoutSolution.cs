using BeFaster.Runner.Exceptions;
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

            Dictionary<char, int> priceTable = new Dictionary<char, int>()
            {
                {'A', 50 },
                {'B', 30 },
                {'C', 20 },
                {'D', 15 }
            };

            List<char> specialOfferItems = new List<char>();
            specialOfferItems.Add('A');
            specialOfferItems.Add('B');

            foreach (char item in skus)
            {
                if (!priceTable.ContainsKey(item))
                {
                    return -1;
                }
                else
                {
                    if (specialOfferItems.Contains(item))
                    {
                        totalAs += item == 'A' ? 1 : 0;
                        totalBs += item == 'B' ? 1 : 0;
                    }
                    else
                    {
                        total += priceTable[item];
                    }

                }
            }

            return total;
        }
    }
}

