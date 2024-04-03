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

            itemA.SpecialOffers.Add(new Offer() { Quantity = 3, Price = 130 } );
            itemA.SpecialOffers.Add(new Offer() { Quantity = 5, Price = 200 } );
            itemB.SpecialOffers.Add(new Offer() { Quantity = 2, Price = 45 } );
            itemE.SpecialOffers.Add(new Offer() { Quantity = 2, Price = itemB.ItemPrice } );


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
                if (itemQuantities[item.Key.ItemCode] != 0)
                {
                    if (item.Key.SpecialOffers.Count == 0)
                    {
                        total += item.Value * itemQuantities[item.Key.ItemCode];
                    }
                    else if (item.Key.SpecialOffers.Count == 1)
                    {
                        int min = item.Key.SpecialOffers[0].Quantity;
                        int offerValue = item.Key.SpecialOffers[0].Price;
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
                            total += ComputeBOGOFDiscount(itemQuantities[item.Key.ItemCode], item.Value, min, offerValue);
                        }
                        else
                        {
                            total += ComputeDiscountPriceSingle(itemQuantities[item.Key.ItemCode], item.Value, min, offerValue);
                        }
                    }
                    else
                    {
                        item.Key.SpecialOffers = item.Key.SpecialOffers.OrderBy(i => i.Quantity + i.Price).ToList();
                        total += ComputeDiscountPriceMulti(itemQuantities[item.Key.ItemCode], item.Value, item.Key.SpecialOffers);
                    }
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

        public static int ComputeDiscountPriceMulti(int n, int price, List<Offer> offers)
        {
            int nOutOfOffer = 0;
            int totalPrice = 0;

            foreach (Offer offer in offers)
            {
                if (n >= offer.Quantity)
                {
                    nOutOfOffer = n % offer.Quantity == 0 ? 0 : n % offer.Quantity;
                    if (nOutOfOffer == 0)
                    {
                        totalPrice += n / offer.Quantity * offer.Price;
                    }
                    else
                    {
                        n -= nOutOfOffer;
                        totalPrice += n / offer.Quantity * offer.Price;
                    }
                }
                else
                {
                    totalPrice += n * price;
                }
            }


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

