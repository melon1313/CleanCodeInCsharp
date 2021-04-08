using NUnit.Framework;
using CleanCodeInCsharp.Ch05重構;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeInCsharp.Ch05重構.Tests
{
    [TestFixture()]
    public class GeneratePrimesTests
    {
        [Test()]
        public void GeneratePrimeNumbersTest()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
            Assert.AreEqual(nullArray.Length, 0);

            int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
            Assert.AreEqual(minArray.Length, 1);
            Assert.AreEqual(minArray[0], 2);

            int[] threeArray = PrimeGenerator.GeneratePrimeNumbers(3);
            Assert.AreEqual(threeArray.Length, 2);
            Assert.AreEqual(threeArray[0], 2);
            Assert.AreEqual(threeArray[1], 3);

            int[] centArray = PrimeGenerator.GeneratePrimeNumbers(100);
            Assert.AreEqual(centArray.Length, 25);
            Assert.AreEqual(centArray[24], 97);
        }
    }
}