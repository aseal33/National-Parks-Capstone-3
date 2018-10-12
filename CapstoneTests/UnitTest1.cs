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

    }
}
