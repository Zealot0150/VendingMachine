using System;
using Xunit;
using VendingMachine;

namespace TestVendingMachine
{
    public class UnitTest1
    {
        [Fact]
        public void TestVending()
        {
            VendingMachine.VendingMachine vm = new VendingMachine.VendingMachine();
            bool result = vm.ValidDenomination(100);
            Assert.True(result);
        }
    }
}
