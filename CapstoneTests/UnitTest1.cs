using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoesTheListOfItemsShowUpInProgram()
        {
            VendingMachine vend = new VendingMachine();

            Assert.AreEqual("Potato Crisps", vend.inventory["A1"].Name);
            Assert.AreEqual("Moonpie", vend.inventory["B1"].Name);
            Assert.AreEqual("Drink", vend.inventory["C1"].Type);
            Assert.AreEqual(0.85M, vend.inventory["D1"].Price);

        }

        [TestMethod]
        public void DoesQuantityDropWithPurchaseOfItem()
        {
            VendingMachine vend = new VendingMachine();

            vend.DispenseProduct("C4");

            Assert.AreEqual(4, vend.inventory["C4"].Quantity);

        }

        // New Unit Test to Test the Sold Value, Can't Figure Out How to Get it Higher Than 1
        [DataTestMethod]
        [DataRow("C4", 1)]
        [DataRow("D2", 1)]
        [DataRow("B4", 1)]
        [DataRow("A1", 1)]
        public void SalesReportPopulatesCorrectlyWith0Quantity(string input, int expected)
        {
            VendingMachine vending = new VendingMachine();

            vending.DispenseProduct(input);

            Assert.AreEqual(expected, vending.inventory[input].Sold);
        }

    }
}
