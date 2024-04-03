using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    public class ItemA : IItem
    {
        private const char itemCode = 'A';

        private const int itemPrice = 50;

        public char ItemCode { get { return itemCode; } }

        public int ItemPrice { get { return itemPrice; } }

        public List<Dictionary<int, int>> SpecialOffers { get; } = new List<Dictionary<int, int>>();
    }
}
