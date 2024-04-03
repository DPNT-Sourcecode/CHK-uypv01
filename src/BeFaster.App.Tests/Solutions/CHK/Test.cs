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
            { "B" },
            { "AAAABC" },
            { "BBEE" },
            { "AAAAAAAA" },
            { "AAAAAAAAA" },
            { "ABCDE" },
            { "EE" },
            { "EEEEBB" }
        };

        [Test]
        public void test1()
        {
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[0]), 50);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[1]), 30);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[2]), 230);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[3]), 95);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[4]), 330);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[5]), 380);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[6]), 155);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[7]), 80);
            Assert.AreEqual(CheckoutSolution.ComputePrice(testStr[8]), 160);
        }

    }
}



