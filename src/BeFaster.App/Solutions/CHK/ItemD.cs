using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class ItemD: IItem
    {
        private const char itemCode = 'D';

        private const int itemPrice = 15;

        public char ItemCode { get { return itemCode; } }

        public int ItemPrice { get { return itemPrice; } }

        public List<Offer> SpecialOffers { get; } = new List<Offer>();
    }
}
