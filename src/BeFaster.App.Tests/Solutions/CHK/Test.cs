using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class Test
    {
        List<string> testStr = new List<string>()
        {
            { "A" },
            { "B" }
        };

        [Test]
        public void test1()
        {
            foreach (var str in testStr)
            {
                CheckoutSolution.ComputePrice(str);
            }
        }

    }
}



