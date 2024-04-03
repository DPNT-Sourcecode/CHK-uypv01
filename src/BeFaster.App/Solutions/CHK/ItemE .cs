using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class ItemE: IItem
    {
        private const char itemCode = 'E';

        private const int itemPrice = 40;

        public char ItemCode { get { return itemCode; } }

        public int ItemPrice { get { return itemPrice; } }

        public List<Offer> SpecialOffers { get; set; } = new List<Offer>();
    }
}
