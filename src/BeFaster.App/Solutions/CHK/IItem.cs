using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Solutions.CHK
{
    /// <summary>
    /// Interface for the properties of an item.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Item code or SKU.
        /// </summary>
        char ItemCode { get; }

        /// <summary>
        /// Item price.
        /// </summary>
        int ItemPrice { get; }

        /// <summary>
        /// Special offers that apply to the item.
        /// </summary>
        List<Offer> SpecialOffers { get; }
    }
}

