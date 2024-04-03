using BeFaster.Runner.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            itemE.SpecialOffers.Add(2, itemB.ItemPrice);

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

            foreach (var item in priceTable)
            {
                if (item.Key.SpecialOffers.Count == 0)
                {
                    total += item.Value * itemQuantities[item.Key.ItemCode];
                }
                else if (item.Key.SpecialOffers.Count == 1)
                {
                    int min = item.Key.SpecialOffers.Keys.Single();
                    int offerValue = item.Key.SpecialOffers.Values.Single();
                    bool match = false;
                    string matchItem = "";

                    foreach (var i in priceTable)
                    {
                        if (i.Value == offerValue)
                        {
                            match = true;
                            matchItem = i.Key.ItemCode.ToString();
                        }
                    }

                    if (match && skus.Contains(matchItem))
                    {
                        ComputeBOGOFDiscount(itemQuantities[item.Key.ItemCode], item.Value, min, item.Key.SpecialOffers[min]);
                    }
                    else
                    {
                        ComputeDiscountPriceSingle(itemQuantities[item.Key.ItemCode], item.Value, min, item.Key.SpecialOffers[min]);
                    }   
                }
                else
                {
                    ComputeDiscountPriceMulti(itemQuantities[item.Key.ItemCode], item.Value, min, item.Key.SpecialOffers[min]);
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


            return total;
        }

        public static int ComputeDiscountPriceSingle(int n, int price, int min, int offerPrice)
        {
            int nOutOfOffer = n % min;
            int totalPrice = 0;

            if (n >= min && nOutOfOffer == 0)
            {
                totalPrice = n / min * offerPrice;
            }
            else if (n > min)
            {
                n -= nOutOfOffer;
                totalPrice = (nOutOfOffer * price) + (n / min * offerPrice);
            }
            else
            {
                totalPrice = n * price;
            }

            return totalPrice;
        }

        public static int ComputeDiscountPriceMulti(int n, int price, int min, int offerPrice)
        {
            int nOutOfOffer = n % min;
            int totalPrice = 0;


            return totalPrice;
        }

        public static int ComputeBOGOFDiscount(int n, int price, int min, int offerPrice)
        {
            int nOutOfOffer = n % min;
            int totalPrice = 0;

            if (n >= min && nOutOfOffer == 0)
            {
                totalPrice = (n * price) - (n / min * offerPrice);
            }
            else if (n > min)
            {
                totalPrice = (n * price) - ((n - nOutOfOffer) / min * offerPrice);
            }

            return totalPrice;
        }


    }
}
